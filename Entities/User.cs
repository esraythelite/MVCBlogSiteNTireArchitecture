using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User:BaseEntity
    {
        public User()
        {
            Articles = new HashSet<Article>();
            Topics = new HashSet<Topic>();
            ArticlesLiked = new HashSet<Article>();
        }
        public int? UserDetailId { get; set; }
        public UserDetail UserDetail { get; set; }
        public string UserMail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<Article> ArticlesLiked { get; set; }
    }
}
