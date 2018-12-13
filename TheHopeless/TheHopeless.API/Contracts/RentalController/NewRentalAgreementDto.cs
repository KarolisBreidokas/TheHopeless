using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHopeless.API.Contracts.RentalController
{
    public class NewRentalAgreementDto
    {
        public DateTime LoanPeriodStart;
        public DateTime LoanPeriodEnd;
        public decimal Price;
        public decimal Deposit;
        public int PaymentTypeId;
        public int ProductId;
    }
}
