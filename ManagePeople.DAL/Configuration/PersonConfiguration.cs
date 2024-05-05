using ManagePeople.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.DAL.Configuration
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //throw new NotImplementedException();
            //Configuration de ma table dans la DB:
            builder.ToTable("Person");
            builder.HasKey(p => p.Id);
            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false);

            // If exists a date:
            //builder
            //    .Property(p => p.DateNaissance)
            //    .IsRequired()
            //    .HasColumnType("DATE");

        }
    }
}
