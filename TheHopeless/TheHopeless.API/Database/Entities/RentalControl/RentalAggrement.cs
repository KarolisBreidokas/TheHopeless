using System;
using TheHopeless.API.Constants;
using TheHopeless.API.Database.Entities.ProductControl;
using TheHopeless.API.Database.Entities.UserControl;

namespace TheHopeless.API.Database.Entities.RentalControl
{
    public class RentalAggrement:BaseEntity
    {
        //properties
        public DateTime SignedDate { get; set; }
        public DateTime LoanPeriodStart { get; set; }
        public DateTime LoanPeriodEnd { get; set; }
        public decimal Price { get; set; }
        public decimal Deposit { get; set; }
        public AggementState State { get; set; }
        //FKs
        public int PaymentTypeId { get; set; }
        public int AdministratorId { get; set; }
        public int ProductId { get; set; }
        //Foreign entities
        public Product Product { get; set; }
        public RentalPaymentType PaymentType { get;set; }
        public Administrator MadeBy { get; set; }
    }
}