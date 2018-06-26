namespace EntityRepositoryTests.Repository
{
    using RepositoryPattern.Entities;
    using RepositoryPattern.Repository;
    using Xunit;

    public class SettingTests
    {
        [Fact]
        public void AddEntityTest()
        {
            var context = new MockDbContext().CreateContext("AddEntityTest");
            var settingRepo = new SettingRepository(context);

            var settingId = settingRepo.Add(new Setting
            {
                Key = "TestKey",
                Value = "TestValue"
            });

            Assert.True(settingId > 0);
        }

        [Fact]
        public void GetEntityTest()
        {
            var context = new MockDbContext().CreateContext("GetEntityTest");
            var settingRepo = new SettingRepository(context);

            var settingId = settingRepo.Add(new Setting
            {
                Key = "TestKey",
                Value = "TestValue"
            });

            Assert.True(settingId > 0);

            var setting = settingRepo.Get(settingId);

            Assert.True(setting.Id > 0);
            Assert.True(setting.Key == "TestKey");
            Assert.True(setting.Value == "TestValue");
        }

        [Fact]
        public void UpdateEntityTest()
        {
            var context = new MockDbContext().CreateContext("UpdateEntityTest");
            var settingRepo = new SettingRepository(context);

            var settingId = settingRepo.Add(new Setting
            {
                Key = "TestKey",
                Value = "TestValue"
            });

            Assert.True(settingId > 0);

            var setting = settingRepo.Get(settingId);
            setting.Key = "TestKeyUpdated";
            setting.Value = "TestValueUpdated";

            settingRepo.Update(setting);

            var updatedSetting = settingRepo.Get(settingId);

            Assert.True(updatedSetting.Id > 0);
            Assert.True(updatedSetting.Key == "TestKeyUpdated");
            Assert.True(updatedSetting.Value == "TestValueUpdated");
        }

        [Fact]
        public void RemoveEntityTest()
        {
            var context = new MockDbContext().CreateContext("RemoveEntityTest");
            var settingRepo = new SettingRepository(context);

            var settingId = settingRepo.Add(new Setting
            {
                Key = "TestKey",
                Value = "TestValue"
            });

            Assert.True(settingId > 0);

            settingRepo.Remove(settingId);

            Assert.False(settingRepo.Any(x => x.Id == settingId));
        }

        [Fact]
        public void GetEntity_ByKeyTest()
        {
            var context = new MockDbContext().CreateContext("GetEntity_ByKeyTest");
            var settingRepo = new SettingRepository(context);

            var settingId = settingRepo.Add(new Setting
            {
                Key = "TestKey",
                Value = "TestValue"
            });

            Assert.True(settingId > 0);

            var setting = settingRepo.Get_ByKey("TestKey");
            Assert.True(setting.Id > 0);
            Assert.True(setting.Key == "TestKey");
            Assert.True(setting.Value == "TestValue");
        }
    }
}
