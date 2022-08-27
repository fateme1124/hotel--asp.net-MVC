using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models.Models;
using Hotel.Models.Context;

namespace Hotel.Service.Service
{
    public class CommentService : GenericService<Comment>, ICommentService
    {
        public CommentService(DbHotelContext context) : base(context)
        {

        }
    }
}
