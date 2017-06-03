using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace web.core.Models.Mapping
{
    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserName)
                .HasMaxLength(50);

            this.Property(t => t.Country)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(50);

            this.Property(t => t.AcademicLevel)
                .HasMaxLength(50);

            this.Property(t => t.Faculty)
                .HasMaxLength(50);

            this.Property(t => t.Class)
                .HasMaxLength(50);

            this.Property(t => t.Sex)
                .HasMaxLength(50);

            this.Property(t => t.PhoneNumber)
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Picture)
                .HasMaxLength(50);

            this.Property(t => t.UserId)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("UserInfo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.AcademicLevel).HasColumnName("AcademicLevel");
            this.Property(t => t.Faculty).HasColumnName("Faculty");
            this.Property(t => t.Class).HasColumnName("Class");
            this.Property(t => t.Sex).HasColumnName("Sex");
            this.Property(t => t.DateBirth).HasColumnName("DateBirth");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Picture).HasColumnName("Picture");
            this.Property(t => t.UserId).HasColumnName("UserId");
        }
    }
}
