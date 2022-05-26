using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public bool Add(T entity)
        {
            return genericRepository.Add(entity);
        }

        public bool Delete(T entity)
        {
            return genericRepository.Delete(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return genericRepository.GetAll();
        }

        public T GetById(int id)
        {
            if (id==0)
            {
                throw new Exception("Id is null!");
            }
            return genericRepository.GetById(id);
        }

        public bool Update(T entity)
        {
            return genericRepository.Update(entity);
        }
    }
}
