namespace RepositoryPattern.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.EntityFrameworkCore;
    using RepositoryPattern.Interfaces;
    using RepositoryPattern.Repository.Exceptions;

    /// <summary>
    /// Entity Framework base class
    /// </summary>
    /// <typeparam name="TEntity">Entities Data Model Class</typeparam>
    public class EntityFrameworkBase<TEntity> : IRepository<TEntity>, IRepositoryExtended<TEntity>
         where TEntity : class, IEntity
    {
        internal DbContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFrameworkBase{TEntity}"/> class.
        ///
        /// </summary>
        /// <param name="context">DBcontext of Database</param>
        public EntityFrameworkBase(DbContext context)
        {
            this.Context = context;
        }

        public int Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            this.Context.Set<TEntity>().Add(entity);

            this.Context.SaveChanges();

            return entity.Id;
        }

        public List<TEntity> AddRange(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentException(nameof(entities));
            }

            if (entities.Count == 0)
            {
                return entities;
            }

            this.Context.Set<TEntity>().AddRange(entities);

            this.Context.SaveChanges();

            return entities;
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Any(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity Get(int id)
        {
            if (id == 0)
            {
                return null;
            }

            return this.Context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            if (id == 0)
            {
                return;
            }

            var entity = this.Context.Set<TEntity>().FirstOrDefault(x => x.Id == id);

            this.Context.Set<TEntity>().Remove(entity);

            this.Context.SaveChanges();
        }

        public List<TEntity> ToList(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate).ToList();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.Id == 0)
            {
                throw new EntityInvalidException("Cannot update with empty Id", entity.Id);
            }

            if (!this.Context.Set<TEntity>().Any(e => e.Id == entity.Id))
            {
                throw new EntityNotFoundException("Entity not found", entity.Id);
            }

            this.Context.Set<TEntity>().Attach(entity);

            this.Context.Entry(entity).State = EntityState.Modified;

            this.Context.SaveChanges();
        }
    }
}
