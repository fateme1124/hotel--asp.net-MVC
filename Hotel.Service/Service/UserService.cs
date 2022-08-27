using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models.Models;
using Hotel.Models.Context;
using Hotel.Repository.Repository;

namespace Hotel.Service.Service
{
    public class UserService : GenericService<User>, IUserService
    {
        private IUserRepository _userRepository;
        public UserService(DbHotelContext context): base(context)
        {
            _userRepository = new UserRepository(context);
        }

        public int GetUserId(string mobileNUmber)
        {
            return _userRepository.GetAll().FirstOrDefault(t => t.MobileNumber == mobileNUmber).UserId;
        }
        public bool CheckMobileNumber(string mobileNumber)
        {
            return _userRepository.GetAll().Any(t => t.MobileNumber == mobileNumber);
        }
    }
}
