using DatingSite.EntityModels;
using DatingSite.EntityModels.Identity;
using DatingSite.EntityModels.Queues;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingSite.Repositories.Configuration
{
    internal class PdfQueueConfiguration : EntityTypeConfiguration<PdfQueueEntityModel>
    {

        internal PdfQueueConfiguration()
        {
            ToTable("PdfQueue");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.CriminalId)
                .HasColumnName("CriminalId")
                .HasColumnType("bigint")
                .IsRequired();

            Property(x => x.GeneratedHtml)
                .HasColumnName("GeneratedHtml")
                .HasColumnType("nvarchar");

            Property(x => x.ReGenerationRequired)
                .HasColumnName("ReGenerationRequired")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.IsPdfGenerationSucceed)
                .HasColumnName("IsPdfGenerationSucceed")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.ErrorMessage)
                .HasColumnName("ErrorMessage")
                .HasColumnType("nvarchar");
        }
    }
}
