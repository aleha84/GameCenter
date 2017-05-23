using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameCenter.DAL.DAO;
using GameCenter.Models;

namespace GameCenter.BLL
{
    public class ApplicationsBLL : IApplicationsBLL
    {
        private readonly IApplicationsDAO _applicationsDAO;
        private readonly IMapper _mapper;

        public ApplicationsBLL(IApplicationsDAO applicationsDAO,
            IMapper mapper)
        {
            if(applicationsDAO == null)
                throw new ArgumentNullException(nameof(applicationsDAO));

            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            _applicationsDAO = applicationsDAO;
            _mapper = mapper;
        }
        public IEnumerable<ApplicationDescriptionModel> GetAll()
        {
            return _applicationsDAO.GetAll().Select(ad => _mapper.Map<ApplicationDescriptionModel>(ad)).ToList();
        }
    }
}
