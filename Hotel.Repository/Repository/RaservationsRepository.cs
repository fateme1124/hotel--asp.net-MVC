using Hotel.Models.Context;
using Hotel.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repository.Repository
{
    public class RaservationsRepository : GenericRepository<Raservations>, IRaservationsRepository
    {
        public RaservationsRepository(DbHotelContext context) : base(context)
        {
        }

    }
}

