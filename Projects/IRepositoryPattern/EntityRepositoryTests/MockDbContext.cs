namespace EntityRepositoryTests
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using RepositoryPattern;
    using Xunit;

    public class MockDbContext
    {
        public DataContext CreateContext(string name)
        {
            var builder = new DbContextOptionsBuilder<DataContext>()
                            .UseInMemoryDatabase(name);
            return new DataContext(builder.Options);
        }
    }
}
