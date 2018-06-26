namespace ListRepositoryTests.MockRepo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using RepositoryPattern.Interfaces;
    using RepositoryPattern.Repository.Exceptions;

    public class MockRepositoryBase<TEntity> : IRepository<TEntity>, IRepositoryExtended<TEntity>
         where TEntity : class, IEntity
    {
        public MockRepositoryBase(IList<TEntity> context)
        {
            this.Context = context;
        }

        internal IList<TEntity> Context { get; set; }

        public int Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            var newId = 1;
            if (this.Context.Count > 0)
            {
                newId = this.Context.Max(x => x.Id) + 1;
            }

            entity.Id = newId;

            this.Context.Add(entity);

            return newId;

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

            foreach (var entity in entities)
            {
                var newId = 1;
                if (this.Context.Count > 0)
                {
                    newId = this.Context.Max(x => x.Id) + 1;
                }
                entity.Id = newId;
                this.Context.Add(entity);
            }

            return entities;
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Any(predicate.Compile());
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.FirstOrDefault(predicate.Compile());
        }

        public TEntity Get(int id)
        {
            if (id == 0)
            {
                return null;
            }

            return this.Context.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            if (id == 0)
            {
                return;
            }

            var entity = this.Context.FirstOrDefault(x => x.Id == id);

            this.Context.Remove(entity);
        }

        public List<TEntity> ToList(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Where(predicate.Compile()).ToList();
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

            if (!this.Context.Any(e => e.Id == entity.Id))
            {
                throw new EntityNotFoundException("Entity not found", entity.Id);
            }

            var entityToUpdate = this.Context.FirstOrDefault(e => e.Id == entity.Id);

            if (entityToUpdate.Id == entity.Id) {
                entityToUpdate = entity;
            }
        }
    }
}
