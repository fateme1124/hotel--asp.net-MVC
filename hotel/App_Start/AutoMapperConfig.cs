using System.Web;
using System.Web.Mvc;
using Hotel.Models.Models;
using AutoMapper;
using hotel.Models.ViewModels;
using Hotel.Models.ViewModels;

namespace hotel
{
    public class AutoMapperConfig
    {
        public static IMapper mapper;
        public static void ConfigureMapping()
        {
            MapperConfiguration config = new MapperConfiguration(t =>
            {
                t.CreateMap<RoomsGroup, RoomsGroupViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<RoomsGroupViewModel, RoomsGroup>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Rooms, RoomsViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<RoomsViewModel, Rooms>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Comment, CommentViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<CommentViewModel, Comment>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<User, UserViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<UserViewModel, User>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                t.CreateMap<Raservations, RaservationsViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<RaservationsViewModel, Raservations>().IgnoreAllPropertiesWithAnInaccessibleSetter();

                //فاکتور ها  
                t.CreateMap<FactorsViewModel, Factors>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<Factors, FactorsViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
        
                //پرداخت 
                t.CreateMap<PaymentViewModel, Payments>().IgnoreAllPropertiesWithAnInaccessibleSetter();
                t.CreateMap<Payments, PaymentViewModel>().IgnoreAllPropertiesWithAnInaccessibleSetter();
               
            });
            mapper = config.CreateMapper();
        }
    }
}
