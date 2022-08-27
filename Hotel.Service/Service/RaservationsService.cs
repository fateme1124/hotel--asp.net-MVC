using Hotel.Models.Context;
using Hotel.Models.Models;
using Hotel.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Service.Service
{
    public class RaservationsService : GenericService<Raservations>, IRaservationsService
    {
        private IRaservationsRepository _raservationsRepository;
        public RaservationsService(DbHotelContext context) : base(context)
        {
            _raservationsRepository = new RaservationsRepository(context);
        }
    }
}
