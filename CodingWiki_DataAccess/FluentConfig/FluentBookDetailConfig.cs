using CodingWiki_Model.Models.Fluent_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            //name of the table
            modelBuilder.ToTable("Fluent_BookDetails");

            //name of the column
            modelBuilder.Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");

            //other validation
            modelBuilder.Property(u => u.NumberOfChapters).IsRequired();

            //primarykey
            modelBuilder.HasKey(u => u.BookDetail_Id);

            //relation
            modelBuilder.HasOne(b => b.Book).WithOne(b => b.BookDetail).HasForeignKey
                <Fluent_BookDetail>(u => u.Book_Id);
        }
    }
}
