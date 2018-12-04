﻿using Microsoft.EntityFrameworkCore;
using TheHopeless.API.Database.Entities.DeliveryControl;
using TheHopeless.API.Database.Entities.OrdersControl;
using TheHopeless.API.Database.Entities.ProductControl;
using TheHopeless.API.Database.Entities.UserControl;

namespace TheHopeless.API.Database
{
    public class EshopDbContext : DbContext
    {

        public DbSet<Product> ProductSet { get; set; }
        public DbSet<ProductGroup> GroupSet { get; set; }

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

            //OrdersControl YEL
            SetUpOrder(modelBuilder);
            SetUpProductOrder(modelBuilder);

            //UserContol GRN
        }

        #region GRN


        private void SetUp(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<RegisteredUser>();
            entity.HasKey(x =>x.Id);
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

        private void SetUpProductOrder(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ProductOrder>();
            entity.HasKey(x =>new {x.OrderId,x.ProductId});
        }



        #endregion


        #region GRY
        private void SetUpCurrier(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Curier>();
            entity.HasKey(x => x.Id);
            entity.HasMany(x => x.AssignedOrders)
                .WithOne(x => x.AssignedCurier)
                .HasForeignKey(x => x.CurrierId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        #endregion


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
    }
}
