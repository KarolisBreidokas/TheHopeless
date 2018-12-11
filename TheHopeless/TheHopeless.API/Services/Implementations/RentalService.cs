using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Contracts.RentalController;
using TheHopeless.API.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheHopeless.API.Database.Entities.RentalControl;
using TheHopeless.API.Database.Entities.UserControl;

namespace TheHopeless.API.Services.Implementations
{
    public class RentalService : IRentalService
    {
        private readonly EshopDbContext _context;
        private readonly DbSet<RentalAgreement> _agreements;
        private readonly DbSet<RentalPaymentType> _paymentMethods;
        private readonly DbSet<RegisteredUser> _users;
        private IMapper _mapper;
        public RentalService(EshopDbContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }
        public async Task<ICollection<RentalAgreementDto>> Get()
        {
            var ans = await IncludeDependencies().ToListAsync();
            return _mapper.Map<ICollection < RentalAgreementDto >>( ans);
        }
        private IQueryable<RentalAgreement> IncludeDependencies()
        {
            return _agreements.Include(x => x.Id).Include(x => x.SignedDate).Include(x => x.LoanPeriodStart).Include(x => x.LoanPeriodEnd).
                Include(x => x.Deposit).Include(x => x.Price).Include(x => x.ProductId).Include(x => x.MadeBy).Include(x => x.PaymentTypeId);
        }
        public async Task<RentalAgreementDto> GetSpecific(int id)
        {
            var ans = await IncludeDependencies().Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<RentalAgreementDto>(ans);
        }
        public async Task<RentalAgreementDto> Add(NewRentalAgreementDto newAgreement)
        {
            var entity = _mapper.Map<RentalAgreement>(newAgreement);
            _agreements.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<RentalAgreementDto>(entity);
        }
        public async Task<RentalAgreementDto> Edit(int id, NewRentalAgreementDto agreement)
        {
            var entity = await IncludeDependencies().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
                return null;
            _context.Update(entity);
            _mapper.Map(agreement, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<RentalAgreementDto>(entity);

        }
        public async Task<bool> TerminateAgreement(int id)
        {
            var entity = await IncludeDependencies().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
                return false;
            _context.Update(entity);
            entity.State = Constants.AgreementState.Canceled;
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<ICollection<RentalAgreementDto>> RentReport(DateTime from, DateTime to)
        {
            var ans = await IncludeDependencies().Where(x => x.SignedDate > from).Where(x => x.SignedDate < to).ToListAsync();
            return _mapper.Map<ICollection<RentalAgreementDto>>(ans);
        }
        public async Task<string> FindContact(string name)
        {
            var entity = await IncludeDependenciesForUser().Where(x => x.Name == name).FirstOrDefaultAsync();
            if (entity is null)
                return "";
            return entity.EMail;
        }
        private IQueryable<RegisteredUser> IncludeDependenciesForUser()
        {
            return _users.Include(x => x.EMail);
        }
    }
}
