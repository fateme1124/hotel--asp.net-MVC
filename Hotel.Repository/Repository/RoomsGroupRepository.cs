using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models.Models;
using Hotel.Models.Context;

namespace Hotel.Repository.Repository
{
    public class RoomsGroupRepository : GenericRepository<RoomsGroup>, IRoomsGroupRepository
    {
        public RoomsGroupRepository(DbHotelContext context) : base(context)
        {
        }
    }
}
