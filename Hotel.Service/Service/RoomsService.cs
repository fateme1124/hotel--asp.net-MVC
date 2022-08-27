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
    
    public class RoomsService : GenericService<Rooms>, IRoomsService
    {
        RoomsRepository _roomsRepository;
        public RoomsService(DbHotelContext context) : base(context)
        {
            _roomsRepository = new RoomsRepository(context);
        }
        public List<Rooms> GetLastRooms(int count) 
        {
            return _roomsRepository.GetAll().Where(t => t.IsActive).OrderByDescending(u => u.RoomsId).Take(count).ToList();
        }

        public int NextRoomsId()
        {
            int max = 1;
            var rooms = _roomsRepository.GetAll().ToList();
            if (rooms.Count > 0)
            {
                max = rooms.Max(t => t.RoomsId) + 1;
            }
            return max;
        }
    }
}
