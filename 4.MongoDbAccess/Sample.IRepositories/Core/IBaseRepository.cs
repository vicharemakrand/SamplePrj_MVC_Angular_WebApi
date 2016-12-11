using Sample.EntityModels;
using Sample.EntityModels.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.IRepositories.Core
{
    public interface IBaseRepository<EntityModel> where EntityModel : BaseEntityModel
    {
        long Count { get; }
        IMongoDatabase Database { get; set; }
        void Add(EntityModel entity);

        Task AddAsync(EntityModel entity);
        bool Contains(Expression<Func<EntityModel, bool>> predicate);
        void Delete(ObjectId id);
        void Delete(Expression<Func<EntityModel, bool>> predicate);
        void Delete(EntityModel model);

        Task DeleteAsync(EntityModel model);
        EntityModel FindById(ObjectId id);
        Task<EntityModel> FindByIdAsync(ObjectId id);
        Task<EntityModel> FindByIdAsync(CancellationToken cancellationToken, ObjectId id);
        EntityModel Get(Expression<Func<EntityModel, bool>> predicate);
        List<EntityModel> GetAll();
        Task<List<EntityModel>> GetAllAsync();
        Task<List<EntityModel>> GetAllAsync(CancellationToken cancellationToken);
        EntityModel GetById(ObjectId id);
        IEnumerable<EntityModel> GetMany(Expression<Func<EntityModel, bool>> predicate);
        List<EntityModel> PageAll(int skip, int take);
        Task<List<EntityModel>> PageAllAsync(int skip, int take);
        Task<List<EntityModel>> PageAllAsync(CancellationToken cancellationToken, int skip, int take);
        void Update(EntityModel entity);

        Task UpdateAsync(EntityModel entity);
    }
}
