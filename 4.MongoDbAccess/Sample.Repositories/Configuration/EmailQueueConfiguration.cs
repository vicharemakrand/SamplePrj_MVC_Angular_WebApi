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
    internal class EmailQueueConfiguration : EntityTypeConfiguration<EmailQueueEntityModel>
    {

        internal EmailQueueConfiguration()
        {
            ToTable("EmailQueue");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.FromEmailId)
                .HasColumnName("FromEmailId")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.ToEmailId)
                .HasColumnName("ToEmailId")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.EmailSubject)
                .HasColumnName("EmailSubject")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.MessageBody)
                .HasColumnName("MessageBody")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.AttachedFiles)
                .HasColumnName("AttachedFiles")
                .HasColumnType("nvarchar");

            Property(x => x.IsSucceedEmailSent)
                .HasColumnName("IsSucceedEmailSent")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.ErrorMessage)
                .HasColumnName("ErrorMessage")
                .HasColumnType("nvarchar");

        }
    }
}
