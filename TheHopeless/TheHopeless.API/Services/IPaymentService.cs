using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Contracts.RentalController;

namespace TheHopeless.API.Services
{
    interface IPaymentService
    {
        Task<ICollection<RentalPaymentTypeDto>> GetPaymentMethodList();
        Task<bool> ChangeMethodState(int id, bool state);
        
    }
}
