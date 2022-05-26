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
    public class UserService:GenericService<User>,IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository):base(userRepository)
        {
            this.userRepository = userRepository;
        }

    }
}
