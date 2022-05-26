using Entities;
using System.Collections.Generic;

namespace WebUI.Models.ViewModels
{
    public class UserAndArticlesVM
    {
        public User User { get; set; }
        public IEnumerable<Article> Articles { get; set; }

        public UserAndArticlesVM(User user)
        {
            Articles = User.Articles;
        }

    }
}
