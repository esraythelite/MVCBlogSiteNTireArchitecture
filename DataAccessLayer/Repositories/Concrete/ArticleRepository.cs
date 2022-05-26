using DataAccessLayer.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ArticleRepository:GenericRepository<Article>,IArticleRepository
    {
        private readonly ApplicationDbContext context;

        public ArticleRepository(ApplicationDbContext db) : base(db)
        {
            this.context = db;
        }

        public IEnumerable<Article> GetAllIncludeTopics()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetArticlesByUserID(int id)
        {
            return context.Articles.Where(x => x.UserId == id).ToList();
        }

        public Article GetByIdIncludeUser(int id)
        {
            return context.Articles.Include(x=>x.User).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Article> GetlAllIncludeUsers()
        {
            return context.Articles.Include(x => x.User).Include(x=>x.Topics);
        }
    }
}
