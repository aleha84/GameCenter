using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameCenter.DAL.DAO;
using GameCenter.Models;
using GameCenter.BLL.Processers;

namespace GameCenter.BLL
{
    public class ApplicationsBLL : IApplicationsBLL
    {
        private readonly IApplicationsProcesser _applicationProcesser;
        private readonly IApplicationsDAO _applicationsDAO;
        private readonly IMapper _mapper;

        public ApplicationsBLL(
            IApplicationsDAO applicationsDAO,
            IMapper mapper,
            IApplicationsProcesser applicationProcesser)
        {
            if(applicationsDAO == null)
                throw new ArgumentNullException(nameof(applicationsDAO));

            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            _applicationProcesser = applicationProcesser ?? throw new ArgumentNullException(nameof(applicationProcesser));

            _applicationsDAO = applicationsDAO;
            _mapper = mapper;
        }
        public IEnumerable<ApplicationDescriptionModel> GetAll()
        {
            return _applicationsDAO.GetAll().Select(ad => _mapper.Map<ApplicationDescriptionModel>(ad)).ToList();
        }

        public ApplicationDescriptionModel GetById(int applicationId)
        {
            if (applicationId <= 0)
                return null;

            var dao = _applicationsDAO.GetById(applicationId);

            if (dao == null)
                return null;

            return _mapper.Map<ApplicationDescriptionModel>(dao);
        }

        public void Start(int id, Guid creatorConnectionId)
        {
            var appModel = GetById(id);
            if (appModel == null)
                throw new ArgumentException("id");

            _applicationProcesser.Add(appModel);
        }
    }
}
