using Microsoft.EntityFrameworkCore;
using TheHopeless.API.Database.Entities.DeliveryControl;
using TheHopeless.API.Database.Entities.OrdersControl;
using TheHopeless.API.Database.Entities.ProductControl;
using TheHopeless.API.Database.Entities.RentalControl;
using TheHopeless.API.Database.Entities.UserControl;

namespace TheHopeless.API.Database
{
    public class EshopDbContext : DbContext
    {
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<GroupAttribute> GroupAttributes { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }

        public DbSet<RentalPaymentType> RentalPaymentTypes { get; set; }
        public DbSet<RentalAggrement> RentalAggrements { get; set; }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AdministratorPrivilege> AdministratorPrivileges{get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }

        public EshopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //ProductControl BLU
            SetUpProduct(modelBuilder);
            SetUpProductAttribute(modelBuilder);
            SetUpProductGroup(modelBuilder);
            SetUpAttribute(modelBuilder);
            SetUpPicture(modelBuilder);
            SetUpGroupAttribte(modelBuilder);

            //DeliveryControl GRY
            SetUpCurrier(modelBuilder);
            SetUpProductOrder(modelBuilder);

            //OrdersControl YEL
            SetUpOrder(modelBuilder);

            //UserContol GRN
            SetUpRegisteredUser(modelBuilder);
            SetUpAdministrator(modelBuilder);
            SetUpPrivilege(modelBuilder);
            SetUpAdministratorPrivilege(modelBuilder);

            //RentalControl ROS
            SetUpRentalAggrement(modelBuilder);
            SetUpRentalPaymentType(modelBuilder);
        }


        #region BLU
        private void SetUpProduct(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Product>();
            entity.HasKey(x => x.Id);
            entity.HasMany(x => x.Pictures)
                .WithOne(x => x.BaseProduct)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(x => x.Values)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(x => x.Orders)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(x => x.Rentals)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetUpProductGroup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ProductGroup>();

            entity.HasKey(x => x.Id);

            entity.HasMany(x => x.Products)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(x => x.Attributes)
                .WithOne(x => x.Group)
                .HasForeignKey(x => x.ProductGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void SetUpAttribute(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Attribute>();
            entity.HasKey(x => x.Id);

            entity.HasMany(x => x.Values)
                .WithOne(x => x.Attribute)
                .HasForeignKey(x => x.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(x => x.Groups)
                .WithOne(x => x.Attribute)
                .HasForeignKey(x => x.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void SetUpPicture(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Picture>();
            entity.HasKey(x => x.Id);
        }

        private void SetUpGroupAttribte(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<GroupAttribute>();
            entity.HasKey(x => new { x.ProductGroupId, x.AttributeId });
        }

        private void SetUpProductAttribute(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ProductAttribute>();
            entity.HasKey(x => new { x.AttributeId, x.ProductId });
        }
        #endregion

        #region GRY
        private void SetUpCurrier(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Courier>();
            entity.HasKey(x => x.Id);
            entity.HasMany(x => x.AssignedOrders)
                .WithOne(x => x.AssignedCourier)
                .HasForeignKey(x => x.CurrierId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SetUpProductOrder(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ProductOrder>();
            entity.HasKey(x => new { x.OrderId, x.ProductId });
        }
        #endregion

        #region YEL
        private void SetUpOrder(ModelBuilder modelBuilder)
        {

            var entity = modelBuilder.Entity<Order>();
            entity.HasKey(x => x.Id);
            entity.HasMany(x => x.Products)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        private void SetUpReview(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Review>();
            entity.HasKey(x => x.Id);
        }





        #endregion

        #region GRN
        private void SetUpRegisteredUser(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<RegisteredUser>();
            entity.HasKey(x => x.Id);
        }

        private void SetUpAdministrator(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Administrator>();
            entity.HasKey(x => x.UserId);

            entity.HasOne(x => x.User)
                .WithOne(x => x.Administrator)
                .HasForeignKey<Administrator>(x => x.UserId);

            entity.HasMany(x => x.Privileges)
                .WithOne(x => x.Administrator)
                .HasForeignKey(x => x.AdministratorId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(x => x.Aggrements)
                .WithOne(x => x.MadeBy)
                .HasForeignKey(x => x.AdministratorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(x => x.PaymentTypes)
                .WithOne(x => x.Administers)
                .HasForeignKey(x => x.AdministratorId)
                .OnDelete(DeleteBehavior.Restrict);


        }

        private void SetUpPrivilege(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Privilege>();
            entity.HasKey(x => x.Id);

            entity.HasMany(x => x.Administrators)
                .WithOne(x => x.Privilege)
                .HasForeignKey(x => x.PrivilegeId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        private void SetUpAdministratorPrivilege(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<AdministratorPrivilege>();
            entity.HasKey(x => new { x.AdministratorId, x.PrivilegeId });
        }
        #endregion

        #region ROS
        private void SetUpRentalAggrement(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<RentalAggrement>();
            entity.HasKey(x => x.Id);
        }

        private void SetUpRentalPaymentType(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<RentalPaymentType>();
            entity.HasKey(x => x.Id);

            entity.HasMany(x => x.Agreements)
                .WithOne(x => x.PaymentType)
                .HasForeignKey(x => x.PaymentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        #endregion

    }
}
