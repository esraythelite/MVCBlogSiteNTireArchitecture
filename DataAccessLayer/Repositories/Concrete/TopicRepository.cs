using DataAccessLayer.Repositories.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TopicRepository:GenericRepository<Topic>,ITopicRepository
    {
        private readonly ApplicationDbContext context;

        public TopicRepository(ApplicationDbContext db) : base(db)
        {
            this.context = db;
        }

        public IEnumerable<Topic> GelAllIncludeArticles()
        {
            throw new NotImplementedException();
        }
    }
}
