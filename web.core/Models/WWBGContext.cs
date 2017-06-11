using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using web.core.Models.Mapping;

namespace web.core.Models
{
    public partial class WWBGContext : DbContext
    {
        static WWBGContext()
        {
            Database.SetInitializer<WWBGContext>(null);
        }

        public WWBGContext()
            : base("Name=WWBGContext")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<ContactTable> ContactTables { get; set; }
        public DbSet<UserInfo> UserInfoes { get; set; }
        public DbSet<UserPostTable> UserPostTables { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new ContactTableMap());
            modelBuilder.Configurations.Add(new UserInfoMap());
            modelBuilder.Configurations.Add(new UserPostTableMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
        }
    }
}
