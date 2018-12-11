using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Contracts.RentalController;
using TheHopeless.API.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheHopeless.API.Database.Entities.RentalControl;

namespace TheHopeless.API.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly EshopDbContext _context;
        private readonly DbSet<RentalPaymentType> _paymentMethods;
        private IMapper _mapper;
        public PaymentService(EshopDbContext context, IMapper map)
        {
            _context = context;
            _mapper = map;
        }
        public async Task<ICollection<RentalPaymentTypeDto>> GetPaymentMethodList()
        {
            var ans = await IncludeDependenciesForPaymentMethods().ToListAsync();
            return _mapper.Map<ICollection<RentalPaymentTypeDto>>(ans);

        }
        private IQueryable<RentalPaymentType> IncludeDependenciesForPaymentMethods()
        {
            return _paymentMethods.Include(x => x.Id).Include(x => x.Name).Include(x => x.State);
        }
        public async Task<bool> ChangeMethodState(int id, bool state)
        {
            var entity = await IncludeDependenciesForPaymentMethods().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
                return false;
            _context.Update(entity);
            entity.State = !state;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
