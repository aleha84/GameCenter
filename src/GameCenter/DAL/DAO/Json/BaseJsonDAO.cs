using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCenter.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace GameCenter.DAL.DAO.Json
{
    public class BaseJsonDAO<TBaseEntity> : IBaseDAO<TBaseEntity> where TBaseEntity : BaseEntity
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private string _path;
        protected IEnumerable<TBaseEntity> _data;

        public BaseJsonDAO(IHostingEnvironment hostingEnvironment)
        {
            var path = Path.Combine(hostingEnvironment.ContentRootPath, "JSONData", typeof(TBaseEntity).Name + ".json");

            if(!File.Exists(path))
                throw new FileNotFoundException(path);

            _path = path;

            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using(var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    _data = JsonConvert.DeserializeObject<IEnumerable<TBaseEntity>>(streamReader.ReadToEnd());
                }
        }

        public IEnumerable<TBaseEntity> GetAll()
        {
            return _data.Select(x => (TBaseEntity) x.Clone()).ToList();
        }

        public TBaseEntity GetById(int id)
        {
            var result = _data.FirstOrDefault(x => x.Id == id);

            return (TBaseEntity) result?.Clone();
        }

        private void Sync()
        {
            
        }
    }
}
