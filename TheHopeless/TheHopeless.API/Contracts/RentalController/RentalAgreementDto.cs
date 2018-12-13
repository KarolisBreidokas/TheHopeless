using System;
using System.Collections.Generic;
using TheHopeless.API.Constants;

namespace TheHopeless.API.Contracts.RentalController
{
    public class RentalAgreementDto
    {
        public int Id;
        public DateTime SignedDate;
        public DateTime LoanPeriodStart;
        public DateTime LoanPeriodEnd;
        public decimal Price;
        public decimal Deposit;
        public AgreementState State;
        public int PaymentTypeId;
        public int AdministratorId;
        public int ProductId;
    }
}
