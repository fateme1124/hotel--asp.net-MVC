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
    public class RoomsGroupService : GenericService<RoomsGroup>, IRoomsGroupService
    {
        private RoomsGroupRepository _roomsGroupRepository;
        public RoomsGroupService(DbHotelContext context) : base(context)
        {
            _roomsGroupRepository = new RoomsGroupRepository(context);
        }
      
        public int NextRoomsGroupId()  
        {
            int max = 1;
            var roomsGroups = _roomsGroupRepository.GetAll().ToList();
            if (roomsGroups.Count > 0)
            {
                max = roomsGroups.Max(t => t.RoomsGroupId) + 1;
            }
            return max;
        }
    }
}
