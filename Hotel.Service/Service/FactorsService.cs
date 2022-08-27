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
  public  class FactorsService : GenericService<Factors>, IFactorsService
  {
      private IFactorsRepository _factorsRepository;
        public FactorsService(DbHotelContext context) : base(context)
        {
            _factorsRepository = new FactorsRepository(context);
        }
    }
}
