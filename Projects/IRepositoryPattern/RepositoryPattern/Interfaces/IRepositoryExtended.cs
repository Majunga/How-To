namespace RepositoryPattern.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Extended version based off the IRepository interface, to include more Linq based methods
    /// </summary>
    /// <typeparam name="TEntity">Entities Data Model Class</typeparam>
    public interface IRepositoryExtended<TEntity>
         where TEntity : class, IEntity
    {

        /// <summary>
        /// Adds a range of Entities to the repository
        /// </summary>
        /// <param name="entities">List of Entities to add</param>
        /// <returns>The List of Entities including the Primary Key</returns>
        List<TEntity> AddRange(List<TEntity> entities);

        /// <summary>
        /// Filters a sequence of values based on a predicate
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>if source is empty or if no element passes the test specified
        // by predicate; otherwise, the first element in source that passes the test specified
        // by predicate.</returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Filters a sequence of values based on a predicate
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A filtered System.Collections.Generic.List`1 that contains elements from the input sequence.</returns>
        List<TEntity> ToList(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Filters a sequence of values based on a predicate
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>Returns true if Any Entities exist where the predicate is true</returns>
        bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}
