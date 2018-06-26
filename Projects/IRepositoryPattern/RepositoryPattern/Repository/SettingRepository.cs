namespace RepositoryPattern.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using RepositoryPattern.Entities;

    public class SettingRepository : EntityFrameworkBase<Setting>, ISettingRepository
    {
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
