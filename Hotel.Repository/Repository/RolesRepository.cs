using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models.Models;
using Hotel.Models.Context;

namespace Hotel.Repository.Repository
{
   public class RolesRepository:GenericRepository<Roles>, IRolesRepository
    {
        public RolesRepository(DbHotelContext context) : base(context)
        {

        }
    }
}
