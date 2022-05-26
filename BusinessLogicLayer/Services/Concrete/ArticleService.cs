using BusinessLogicLayer.Services.Abstract;
using DataAccessLayer.Repositories.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ArticleService:GenericService<Article>,IArticleService
    {
        private readonly IArticleRepository articleRepository;

        public ArticleService(IArticleRepository articleRepository):base(articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public IEnumerable<Article> GetArticlesByUserID(int id)
        {
            if (id != 0)
            {
                return articleRepository.GetArticlesByUserID(id);
            }
            else
            {
                throw new Exception("UserId is null");
            }
        }

        public Article GetByIdIncludeUser(int id)
        {
            return articleRepository.GetByIdIncludeUser(id);
        }

        public IEnumerable<Article> GetlAllIncludeUsers()
        {
            return articleRepository.GetlAllIncludeUsers();
        }
    }
}
