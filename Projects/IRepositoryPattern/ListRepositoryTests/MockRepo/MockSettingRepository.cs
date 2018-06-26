namespace ListRepositoryTests.MockRepo
{
    using System.Collections.Generic;
    using System.Linq;
    using RepositoryPattern.Entities;
    using RepositoryPattern.Repository;

    public class MockSettingRepository : MockRepositoryBase<Setting>, ISettingRepository
    {
        public MockSettingRepository(IList<Setting> context)
            : base(context)
        {
        }

        public Setting Get_ByKey(string key)
        {
            return this.Context.FirstOrDefault(x => x.Key == key);
        }
    }
}
