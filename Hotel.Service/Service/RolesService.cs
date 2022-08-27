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
   public class RolesService : GenericService<Roles>, IRolesService
    {
        public RolesService(DbHotelContext context) : base(context)
        {

        }
    }
}
