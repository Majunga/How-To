namespace RepositoryPattern.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using RepositoryPattern.Entities;

    /// <summary>
    /// Repository access for settings
    /// </summary>
    public class SettingRepository : EntityFrameworkBase<Setting>, ISettingRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingRepository"/> class.
        ///
        /// </summary>
        /// <param name="context">DBContext</param>
        public SettingRepository(DataContext context)
            : base(context)
        {
        }

        public Setting Get_ByKey(string key)
        {
           return this.Context.Set<Setting>().SingleOrDefault(x => x.Key == key);
        }
    }
}
