using EHI.UserManagement.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHI.UserManagement.Repository.Configuration
{
    /// <summary>
    /// Databse configurations for Contact Entity
    /// </summary>
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(g => g.FirstName).HasMaxLength(30);
            builder.Property(g => g.LastName).HasMaxLength(30);
            builder.Property(g => g.Email).HasMaxLength(30);
            builder.Property(g => g.PhoneNumber).HasMaxLength(15);
        }        
    }
}
