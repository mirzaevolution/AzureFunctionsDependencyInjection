using Microsoft.EntityFrameworkCore;
using System;
using Welcome.DataEntities;

namespace Welcome.DataAccessLayer
{
    public class WelcomeDbContext : DbContext
    {
        public WelcomeDbContext(DbContextOptions<WelcomeDbContext> options) : base(options)
        {
        }
        public virtual DbSet<ConfigMap> ConfigMaps { get; set; }
    }
}
