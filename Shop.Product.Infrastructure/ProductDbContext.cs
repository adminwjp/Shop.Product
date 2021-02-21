using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shop.Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Utility;
using Utility.Ef;
//using Utility.Domain.Entities;
using Utility.Infrastructure;

namespace Shop.Product.Infrastructure
{
    /// <summary>
    /// 产品 数据库 上下文
    /// </summary>
    public class ProductDbContext:BaseDbContext<ProductDbContext,BaseEntity>
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options, IMediator mediator) :base(options, mediator)
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }
        public DbSet<CatalogEntity> Catalogs { get; set; }
        public DbSet<CatalogAttribueEntity> CatalogAttribues { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<SpecEntity> Specs { get; set; }
        public DbSet<ProductAttribueEntity> ProductAttribues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BaseEntity>(entity =>
            //{
            //    entity.HasKey(it => it.Id);
            //    entity.Property(it => it.Id).HasColumnName("id").HasMaxLength(36);
            //    entity.Property(it => it.CreationTime).HasColumnName("creation_time").HasColumnType("datatime");
            //    entity.Property(it => it.LastModificationTime).HasColumnName("last_modification_time").HasColumnType("datatime");
            //    entity.Property(it => it.DeletionTime).HasColumnName("deletion_time").HasColumnType("datatime");
            //    entity.Property(it => it.IsDeleted).HasColumnName("is_deleted");
            //});


            modelBuilder.Entity<CatalogEntity>(entity =>
            {
                entity.HasKey(it => it.Id);
                entity.Property(it => it.Id).HasColumnName("id").HasMaxLength(36);
                if (DbConfig.Flag == DbFlag.MySql)
                {
                    entity.Property(it => it.CreationTime).HasColumnName("creation_time").HasColumnType("datetime");
                    entity.Property(it => it.LastModificationTime).HasColumnName("last_modification_time").HasColumnType("datetime");
                    entity.Property(it => it.DeletionTime).HasColumnName("deletion_time").HasColumnType("datetime");
                }
                entity.Property(it => it.IsDeleted).HasColumnName("is_deleted");
            });
            modelBuilder.Entity<CatalogAttribueEntity>(entity =>
            {
                entity.HasKey(it => it.Id);
                entity.Property(it => it.Id).HasColumnName("id").HasMaxLength(36);
                if (DbConfig.Flag == DbFlag.MySql)
                {
                    entity.Property(it => it.CreationTime).HasColumnName("creation_time").HasColumnType("datetime");
                    entity.Property(it => it.LastModificationTime).HasColumnName("last_modification_time").HasColumnType("datetime");
                    entity.Property(it => it.DeletionTime).HasColumnName("deletion_time").HasColumnType("datetime");
                }
                entity.Property(it => it.IsDeleted).HasColumnName("is_deleted");
            });
            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.HasKey(it => it.Id);
                entity.Property(it => it.Id).HasColumnName("id").HasMaxLength(36);
                if (DbConfig.Flag == DbFlag.MySql)
                {
                    entity.Property(it => it.CreationTime).HasColumnName("creation_time").HasColumnType("datetime");
                    entity.Property(it => it.LastModificationTime).HasColumnName("last_modification_time").HasColumnType("datetime");
                    entity.Property(it => it.DeletionTime).HasColumnName("deletion_time").HasColumnType("datetime");
                }
                entity.Property(it => it.IsDeleted).HasColumnName("is_deleted");
            });
            modelBuilder.Entity<SpecEntity>(entity =>
            {
                entity.HasKey(it => it.Id);
                entity.Property(it => it.Id).HasColumnName("id").HasMaxLength(36);
                if (DbConfig.Flag == DbFlag.MySql)
                {
                    entity.Property(it => it.CreationTime).HasColumnName("creation_time").HasColumnType("datetime");
                    entity.Property(it => it.LastModificationTime).HasColumnName("last_modification_time").HasColumnType("datetime");
                    entity.Property(it => it.DeletionTime).HasColumnName("deletion_time").HasColumnType("datetime");
                }
                entity.Property(it => it.IsDeleted).HasColumnName("is_deleted");
            });
            modelBuilder.Entity<ProductAttribueEntity>(entity =>
            {
                entity.HasKey(it => it.Id);
                entity.Property(it => it.Id).HasColumnName("id").HasMaxLength(36);
                if (DbConfig.Flag == DbFlag.MySql)
                {
                    entity.Property(it => it.CreationTime).HasColumnName("creation_time").HasColumnType("datetime");
                    entity.Property(it => it.LastModificationTime).HasColumnName("last_modification_time").HasColumnType("datetime");
                    entity.Property(it => it.DeletionTime).HasColumnName("deletion_time").HasColumnType("datetime");
                }
                entity.Property(it => it.IsDeleted).HasColumnName("is_deleted");
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
