using Microsoft.EntityFrameworkCore;

namespace UsersWebAPI.Models
{
    public class MarketContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CompanyUser> CompanyUsers { get; set; }

        public MarketContext(DbContextOptions<MarketContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyUser>().HasKey(companyUser => new { companyUser.CompanyID, companyUser.UserID });

            modelBuilder.Entity<CompanyUser>()
                .HasOne(companyUser => companyUser.Company)
                .WithMany(company => company.CompanyUsers)
                .HasForeignKey(companyUser => companyUser.CompanyID);

            modelBuilder.Entity<CompanyUser>()
                .HasOne(companyUser => companyUser.User)
                .WithMany(user => user.CompanyUsers)
                .HasForeignKey(companyUser => companyUser.UserID);

            modelBuilder.Entity<Company>()
                .HasData(
                    new Company
                    {
                        ID = 1,
                        Name = "BVB Borussia Dortmund 09"
                    },
                    new Company
                    {
                        ID = 2,
                        Name = "FC Schalke 04"
                    },
                    new Company
                    {
                        ID = 3,
                        Name = "DFL"
                    });

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        ID = 1,
                        Username = "oliver",
                        Email = "oliver.bierhoff@dfl.de"
                    },
                    new User
                    {
                        ID = 2,
                        Username = "roman",
                        Email = "roman.weidenfeller@bvb.de"
                    },
                    new User
                    {
                        ID = 3,
                        Username = "lars",
                        Email = "lars.ricken@bvb.de"
                    },
                    new User
                    {
                        ID = 4,
                        Username = "kevin",
                        Email = "kevin.kuranyi@schalke.de"
                    });

            modelBuilder.Entity<CompanyUser>()
                .HasData(
                    new CompanyUser
                    {
                        UserID = 1,
                        CompanyID = 3
                    },
                    new CompanyUser
                    {
                        UserID = 2,
                        CompanyID = 1
                    },
                    new CompanyUser
                    {
                        UserID = 3,
                        CompanyID = 1
                    },
                    new CompanyUser
                    {
                        UserID = 4,
                        CompanyID = 2
                    });
        }
    }
}