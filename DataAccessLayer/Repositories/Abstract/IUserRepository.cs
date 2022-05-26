using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IUserRepository:IGenericRepository<User>
    {
        IEnumerable<User> GetAllIncludeArticles();
        User GetByEmailAndPassword(int id);
        

    }
}
