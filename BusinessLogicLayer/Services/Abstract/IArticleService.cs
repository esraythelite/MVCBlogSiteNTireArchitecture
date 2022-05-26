using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Abstract
{
    public interface IArticleService:IGenericService<Article>
    {
        public Article GetByIdIncludeUser(int id);
        public IEnumerable<Article> GetlAllIncludeUsers();
    }
}
