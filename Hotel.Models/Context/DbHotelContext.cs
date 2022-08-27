using Hotel.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Hotel.Models.Context
{
    
     public class DbHotelContext:DbContext
     {
         public DbSet<Rooms> Rooms{ get; set; }
         public DbSet<RoomsGroup> RoomsGroup { get; set; }
         public DbSet<User> Users { get; set; }
         public DbSet<Comment> Comments { get; set; }
         public DbSet<Payments> Payments { get; set; }
         public DbSet<Factors> Factors { get; set; }
         public DbSet<Roles> Roles { get; set; }
         public DbSet<Raservations> Raservations { get; set; }
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
             modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
         }

        //public System.Data.Entity.DbSet<hotel.Models.ViewModels.RaservationsViewModel> RaservationsViewModels { get; set; }

        //public System.Data.Entity.DbSet<hotel.Models.ViewModels.RaservationsViewModel> RaservationsViewModels { get; set; }

    }
}
