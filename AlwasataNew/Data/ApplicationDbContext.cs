using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AlwasataNew.Models;
using System.Reflection.Emit;
using System.Reflection.Metadata;


namespace AlwasataNew.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var ConStr = Configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(ConStr);
        }
        public ApplicationDbContext() { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Identity Tables
            builder.Entity<ApplicationUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

            //application user configuration
            builder.Entity<ApplicationUser>().Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
            builder.Entity<ApplicationUser>().Property(x => x.CreatedBy).HasDefaultValue("Admin Admin");

            //Customer configuration
            builder.Entity<Customer>().Property(x=>x.Id).ValueGeneratedNever();
            builder.Entity<Customer>()
            .HasMany(e => e.Projects)
            .WithOne(e => e.Customer)
            .HasForeignKey(e => e.CustomerId)
            .IsRequired(false);
            builder.Entity<Customer>().Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
            //Project configuration
            builder.Entity<Project>().Property(x => x.Id).ValueGeneratedNever();
            builder.Entity<Project>().Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");

            //company configuration
            builder.Entity<Company>().Property(x => x.Id).ValueGeneratedNever();

            //customer state descripption table configuration
            builder.Entity<CustomerStateDescription>().Property(x=>x.Id).ValueGeneratedNever();
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CustomerStateDescription> CustomerStateDescriptions { get; set; }

    }
}