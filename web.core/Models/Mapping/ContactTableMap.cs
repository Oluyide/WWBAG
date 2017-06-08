using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace web.core.Models.Mapping
{
    public class ContactTableMap : EntityTypeConfiguration<ContactTable>
    {
        public ContactTableMap()
        {
            // Primary Key
            this.HasKey(t => t.ContactId);

            // Properties
            this.Property(t => t.ContactName)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.ContactEmail)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Message)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ContactTable");
            this.Property(t => t.ContactId).HasColumnName("ContactId");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
            this.Property(t => t.ContactEmail).HasColumnName("ContactEmail");
            this.Property(t => t.Message).HasColumnName("Message");
        }
    }
}
