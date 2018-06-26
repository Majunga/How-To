namespace ListRepositoryTests.Repository
{
    using System.Collections.Generic;
    using ListRepositoryTests.MockRepo;
    using RepositoryPattern.Entities;
    using RepositoryPattern.Repository;
    using Xunit;

    public class SettingTests
    {
        [Fact]
        public void AddEntityTest()
        {
            MockDataContext.Settings = new List<Setting>();
            var settingRepo = new MockSettingRepository(MockDataContext.Settings);

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
            MockDataContext.Settings = new List<Setting>();
            var settingRepo = new MockSettingRepository(MockDataContext.Settings);

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
            MockDataContext.Settings = new List<Setting>();
            var settingRepo = new MockSettingRepository(MockDataContext.Settings);

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
            MockDataContext.Settings = new List<Setting>();
            var settingRepo = new MockSettingRepository(MockDataContext.Settings);

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
            MockDataContext.Settings = new List<Setting>();
            var settingRepo = new MockSettingRepository(MockDataContext.Settings);

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
