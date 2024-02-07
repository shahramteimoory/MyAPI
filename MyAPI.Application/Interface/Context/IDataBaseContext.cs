using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Interface.Context
{
    public interface IDataBaseContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<SalePerson> SalePeople { get; set; }
        DbSet<OrderItems> OrderItems { get; set; }
        DbSet<Order> Orders{ get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DatabaseFacade Database { get; }
        ChangeTracker ChangeTracker { get; }
        DbConnection GetDbConnection(DatabaseFacade databaseFacade);
    }
}
