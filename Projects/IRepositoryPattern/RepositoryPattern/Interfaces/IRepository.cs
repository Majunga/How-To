namespace RepositoryPattern.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Repository implementation
    /// </summary>
    /// <typeparam name="TEntity">Entities Data Model Class</typeparam>
    public interface IRepository<TEntity>
         where TEntity : class, IEntity
    {
        /// <summary>
        /// Adds a Entity to the repository
        /// </summary>
        /// <param name="entity">The Entity to add</param>
        /// <returns>The ID of the entity</returns>
        int Add(TEntity entity);

        /// <summary>
        /// Gets an Entity using the ID
        /// </summary>
        /// <param name="id">The ID of the Entity</param>
        /// <returns>Entity that has been found</returns>
        TEntity Get(int id);

        /// <summary>
        /// Updates an already existing Entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(TEntity entity);

        /// <summary>
        /// Removes an existing Entity
        /// </summary>
        /// <param name="id">The ID of the Entity to be deleted</param>
        void Remove(int id);
    }
}
