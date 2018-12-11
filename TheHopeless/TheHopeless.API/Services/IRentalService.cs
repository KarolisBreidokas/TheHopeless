using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Contracts;
using TheHopeless.API.Contracts.RentalController;

namespace TheHopeless.API.Services
{
    public interface IRentalService
    {
        Task<ICollection<RentalAgreementDto>> Get();
        Task<RentalAgreementDto> GetSpecific(int id);
        Task<RentalAgreementDto> Add(NewRentalAgreementDto newAgreement);
        Task<RentalAgreementDto> Edit(int id, NewRentalAgreementDto product);
        Task<bool> TerminateAgreement(int id);
        Task<string> FindContact(string name);
        Task<ICollection<RentalAgreementDto>> RentReport(DateTime from, DateTime to);

    }
}
