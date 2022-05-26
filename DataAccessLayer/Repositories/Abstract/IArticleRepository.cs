using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IArticleRepository:IGenericRepository<Article>
    {
        public IEnumerable<Article> GetArticlesByUserID(int id);

        public Article GetByIdIncludeUser(int id);

        public IEnumerable<Article> GetlAllIncludeUsers();

        public IEnumerable<Article> GetAllIncludeTopics();
    }
}
