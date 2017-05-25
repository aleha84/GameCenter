using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Hubs;
using Microsoft.Extensions.Logging;

namespace GameCenter.Infrastructure.SignalR
{
    public class ExceptionPipelineModule : HubPipelineModule
    {
        private readonly ILogger<ExceptionPipelineModule> _logger;
        public ExceptionPipelineModule(ILogger<ExceptionPipelineModule> logger)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
        }
        protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
        {
            _logger.LogError($"HUB ERROR: {ProcessException(exceptionContext.Error)}");
            base.OnIncomingError(exceptionContext, invokerContext);
        }

        private string ProcessException(Exception ex)
        {
            return $"Message: {ex.Message}{Environment.NewLine}StackTrace: {(!string.IsNullOrEmpty(ex.StackTrace) ? ex.StackTrace : "No stack trace")}{Environment.NewLine}{(ex.InnerException != null ? $"Inner exception: {Environment.NewLine}{ProcessException(ex.InnerException)}{Environment.NewLine}" : string.Empty)}";
        }
    }
}
