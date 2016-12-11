using DatingSite.EntityModels;
using DatingSite.EntityModels.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingSite.Repositories.Configuration
{
    internal class ClientConfiguration : EntityTypeConfiguration<ClientEntityModel>
    {

        internal ClientConfiguration()
        {
            ToTable("Client");

            HasKey(x => x.ClientId)
                .Property(x => x.ClientId)
                .HasColumnName("ClientId")
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("bigint")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Secret)
                .HasColumnName("Secret")
                .HasColumnType("nvarchar")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.ApplicationType)
                .HasColumnName("ApplicationType")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.Active)
                .HasColumnName("Active")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.RefreshTokenLifeTime)
                .HasColumnName("RefreshTokenLifeTime")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.AllowedOrigin)
                .HasColumnName("AllowedOrigin")
                .HasColumnType("nvarchar")
                .HasMaxLength(200)
                .IsRequired();

            HasMany(x => x.RefreshTokens)
                .WithRequired(x => x.Client)
                .HasForeignKey(x => x.ClientId);
        }
    }
}
