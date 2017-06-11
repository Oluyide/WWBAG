using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace web.core.Models.Mapping
{
    public class UserPostTableMap : EntityTypeConfiguration<UserPostTable>
    {
        public UserPostTableMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Text)
                .IsRequired();

            this.Property(t => t.Media)
                .HasMaxLength(50);

            this.Property(t => t.UserId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UserPostTable");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.Media).HasColumnName("Media");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Date).HasColumnName("Date");
        }
    }
}
