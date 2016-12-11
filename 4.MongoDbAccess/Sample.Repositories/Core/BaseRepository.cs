using Sample.EntityModels.Core;
using Sample.IRepositories.Core;
using Sample.Utility;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Repositories.Core
{
    public class BaseRepository<EntityModel> : IBaseRepository<EntityModel> where EntityModel : BaseEntityModel
    {
        public IMongoDatabase Database { get; set; }

        protected IMongoCollection<EntityModel> DbSet
        {
            get
            {
                return Database.GetCollection<EntityModel>(AppMethods.CorrectCollectionName(typeof(EntityModel).Name));
            }
        }

        public List<EntityModel> GetAll()
        {
            return DbSet.AsQueryable().ToList();
        }

        public Task<List<EntityModel>> GetAllAsync()
        {
            return DbSet.AsQueryable().ToListAsync();
        }

        public Task<List<EntityModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            return DbSet.AsQueryable().ToListAsync(cancellationToken);
        }

        public List<EntityModel> PageAll(int skip, int take)
        {
            return DbSet.AsQueryable().Skip(skip).Take(take).ToList();
        }

        public Task<List<EntityModel>> PageAllAsync(int skip, int take)
        {
            return DbSet.Aggregate().Skip(skip).Limit(take).ToListAsync();
        }

        public Task<List<EntityModel>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            return DbSet.Aggregate().Skip(skip).Limit(take).ToListAsync(cancellationToken);
        }

        public EntityModel FindById(ObjectId id)
        {
            return DbSet.AsQueryable().Where(o=>o.Id == id).FirstOrDefault();
        }

        public Task<EntityModel> FindByIdAsync(ObjectId id)
        {
            return DbSet.Aggregate().Match(o => o.Id == id).FirstOrDefaultAsync();
        }

        public Task<EntityModel> FindByIdAsync(CancellationToken cancellationToken, ObjectId id)
        {
            return DbSet.Aggregate().Match(o => o.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public void Add(EntityModel entity)
        {
            DbSet.InsertOne(entity);
        }

        public Task AddAsync(EntityModel entity)
        {
            return DbSet.InsertOneAsync(entity); 
        }

        public void Update(EntityModel entity)
        {
            DbSet.ReplaceOne(Builders<EntityModel>.Filter.Where(o=>o.Id == entity.Id),entity);
        }

        public Task UpdateAsync(EntityModel entity)
        {
           return DbSet.ReplaceOneAsync(Builders<EntityModel>.Filter.Where(o => o.Id == entity.Id), entity);
        }

        public virtual EntityModel GetById(ObjectId id)
        {
            return DbSet.Find(o => o.Id == id).FirstOrDefault();
        }

        public virtual EntityModel Get(Expression<Func<EntityModel, bool>> predicate)
        {
            return DbSet.Aggregate().Match(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<EntityModel> GetMany(Expression<Func<EntityModel, bool>> predicate)
        {
            return DbSet.Aggregate().Match(predicate).ToList();
        }

        public virtual bool Contains(Expression<Func<EntityModel, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }


        public virtual void Delete(EntityModel model)
        {
            DbSet.DeleteOne(Builders<EntityModel>.Filter.Where(o=>o.Id == model.Id));
        }

        public virtual Task DeleteAsync(EntityModel model)
        {
            return DbSet.DeleteOneAsync(Builders<EntityModel>.Filter.Where(o => o.Id == model.Id));
        }

        public virtual void Delete(Expression<Func<EntityModel, bool>> predicate)
        {
                DbSet.DeleteOne(Builders<EntityModel>.Filter.Where(predicate));
        }

        public virtual void Delete(ObjectId id)
        {
            DbSet.DeleteOne(Builders<EntityModel>.Filter.Where(o => o.Id == id));

        }

        public virtual long Count
        {
            get { return DbSet.Count(Builders<EntityModel>.Filter.Empty); }
        }
    }
}
