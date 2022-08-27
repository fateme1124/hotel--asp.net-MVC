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
    public class GenericService<T> : GenericRepository<T> where T : BaseEntity
    {
        public GenericService(DbHotelContext context) : base(context)
        {
        }
    }
}
