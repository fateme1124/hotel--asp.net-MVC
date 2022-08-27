
using System.Collections.Generic;
using hotel.Models.ViewModels;
using Hotel.Models.Models;
using hotel;
using Hotel.Models.ViewModels;

namespace Hotel.Classes
{
    public static class ExtensionClass
    {
        //کاربران 
        public static List<UserViewModel> ToUsersViewModels(this IEnumerable<User> users)
        {
            return AutoMapperConfig.mapper.Map<IEnumerable<User>, List<UserViewModel>>(users);
        }
        public static UserViewModel ToUsersViewModel(this User users)
        {
            return AutoMapperConfig.mapper.Map<User, UserViewModel>(users);
        }
        public static User ToUsers(this UserViewModel usersViewModel)
        {
            return AutoMapperConfig.mapper.Map<UserViewModel, User>(usersViewModel);
        }

        // پرداخت 
        public static List<PaymentViewModel> ToPaymentViewModels(this IEnumerable<Payments> payments)
        {
            return AutoMapperConfig.mapper.Map<IEnumerable<Payments>, List<PaymentViewModel>>(payments);
        }
        public static PaymentViewModel ToPaymentViewModel(this Payments payments)
        {
            return AutoMapperConfig.mapper.Map<Payments, PaymentViewModel>(payments);
        }

        // فاکتور 
        public static List<FactorsViewModel> ToFactorsViewModels(this IEnumerable<Factors> factors)
        {
            return AutoMapperConfig.mapper.Map<IEnumerable<Factors>, List<FactorsViewModel>>(factors);
        }
        public static FactorsViewModel ToFactorViewModel(this Factors factors)
        {
            return AutoMapperConfig.mapper.Map<Factors, FactorsViewModel>(factors);
        }
        public static Factors ToFactor(this FactorsViewModel factorsViewModel)
        {
            return AutoMapperConfig.mapper.Map<FactorsViewModel, Factors>(factorsViewModel);
        }

        // رزرو 
        public static List<RaservationsViewModel> ToRaservationsViewModels(this IEnumerable<Raservations> raservations)
        {
            return AutoMapperConfig.mapper.Map<IEnumerable<Raservations>, List<RaservationsViewModel>>(raservations);
        }
        public static RaservationsViewModel ToRaservationsViewModel(this Raservations raservations)
        {
            return AutoMapperConfig.mapper.Map<Raservations, RaservationsViewModel>(raservations);
        }


    }
}
