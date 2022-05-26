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
    public class UserDetailService:GenericService<UserDetail>,IUserDetailService
    {
        private readonly IUserDetailRepository userDetailRepository;

        public UserDetailService(IUserDetailRepository userDetailRepository):base(userDetailRepository)
        {
            this.userDetailRepository = userDetailRepository;
        }

    }
}
