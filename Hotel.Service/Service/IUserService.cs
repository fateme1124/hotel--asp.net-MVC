using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models.Models;

namespace Hotel.Service.Service
{
    public interface IUserService : IGenericService<User>
    {
        int GetUserId(string mobileNUmber);
    }
}
