using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace web.core.Models.Mapping
{
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Country)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(50);

            this.Property(t => t.Academic)
                .HasMaxLength(50);

            this.Property(t => t.Faculty)
                .HasMaxLength(50);

            this.Property(t => t.Class)
                .HasMaxLength(50);

            this.Property(t => t.Sex)
                .HasMaxLength(50);

            this.Property(t => t.DateBirth)
                .HasMaxLength(50);

            this.Property(t => t.PhoneNumber)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Picture)
                .HasMaxLength(50);

            this.Property(t => t.UserId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UserProfile");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Academic).HasColumnName("Academic");
            this.Property(t => t.Faculty).HasColumnName("Faculty");
            this.Property(t => t.Class).HasColumnName("Class");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.DateBirth).HasColumnName("DateBirth");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Picture).HasColumnName("Picture");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Date).HasColumnName("Date");
        }
    }
}
