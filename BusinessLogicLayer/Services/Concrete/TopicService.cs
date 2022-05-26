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
    public class TopicService:GenericService<Topic>,ITopicService
    {
        private readonly ITopicRepository topicRepository;

        public TopicService(ITopicRepository topicRepository) : base(topicRepository)
        {
            this.topicRepository = topicRepository;
        }
    }
}
