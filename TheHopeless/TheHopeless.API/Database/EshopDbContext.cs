using Microsoft.EntityFrameworkCore;
using TheHopeless.API.Database.Entities.ProductControl;

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

            //Product control BLU
            SetUpProduct(modelBuilder);
            SetUpProductAttribute(modelBuilder);
            SetUpProductGroup(modelBuilder);
            SetUpAttribute(modelBuilder);
            SetUpPicture(modelBuilder);
            SetUpGroupAttribte(modelBuilder);


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
            entity.HasKey(x => new {x.ProductGroupId, x.AttributeId});
        }
        private void SetUpProductAttribute(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ProductAttribute>();
            entity.HasKey(x => new {x.AttributeId, x.ProductId});
        }
        #endregion
    }
}
