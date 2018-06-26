namespace RepositoryPattern.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RepositoryPattern.Entities;
    using RepositoryPattern.Interfaces;

    /// <summary>
    /// Setting Repository interface
    /// </summary>
    public interface ISettingRepository : IRepository<Setting>, IRepositoryExtended<Setting>
    {
        /// <summary>
        /// Get's the setting by Key
        /// </summary>
        /// <param name="key">The Key of the Key Value Pair</param>
        /// <returns>Key Value pair by Key</returns>
        Setting Get_ByKey(string key);
    }
}
