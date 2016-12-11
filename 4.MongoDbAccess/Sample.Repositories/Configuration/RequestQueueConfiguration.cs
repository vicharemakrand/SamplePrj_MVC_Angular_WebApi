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
    internal class RequestQueueConfiguration : EntityTypeConfiguration<RequestQueueEntityModel>
    {
        internal RequestQueueConfiguration()
        {
            ToTable("RequestQueue");

            HasKey(x => x.Id)
                 .Property(x => x.Id)
                 .HasColumnName("Id")
                 .HasColumnType("bigint")
                 .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                 .IsRequired();

            Property(x => x.SearchParameters)
                .HasColumnName("SearchParameters")
                .HasColumnType("nvarchar");

            Property(x => x.IsRequestSucceed)
                .HasColumnName("IsRequestSucceed")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.ErrorMessage)
                .HasColumnName("ErrorMessage")
                .HasColumnType("nvarchar");
        }
    }
}
