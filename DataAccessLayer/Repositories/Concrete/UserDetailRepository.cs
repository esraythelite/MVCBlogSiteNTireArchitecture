using DataAccessLayer.Repositories.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserDetailRepository:GenericRepository<UserDetail>,IUserDetailRepository
    {
        private readonly ApplicationDbContext context;

        public UserDetailRepository(ApplicationDbContext db):base(db)
        {
            this.context = db;
        }
    }
}
