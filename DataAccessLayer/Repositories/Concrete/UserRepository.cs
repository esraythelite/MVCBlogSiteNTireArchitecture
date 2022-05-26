using DataAccessLayer.Repositories.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            this.context = db;
        }

        public IEnumerable<User> GetAllIncludeArticles()
        {
            throw new NotImplementedException();
        }

        public User GetByEmailAndPassword(int id)
        {
            throw new NotImplementedException();
        }
    }
}
