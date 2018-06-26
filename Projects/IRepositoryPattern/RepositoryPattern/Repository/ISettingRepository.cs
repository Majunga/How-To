namespace RepositoryPattern.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RepositoryPattern.Entities;
    using RepositoryPattern.Interfaces;

    public interface ISettingRepository : IRepository<Setting>, IRepositoryExtended<Setting>
    {
        Setting Get_ByKey(string key);
    }
}
