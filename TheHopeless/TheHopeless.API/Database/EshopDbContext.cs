using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace TheHopeless.API.Database
{
    public class EshopDbContext : DbContext
    {
        public EshopDbContext(DbContextOptions options) : base(options)
        {
        }
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
