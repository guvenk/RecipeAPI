using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;

namespace Tests
{
    public class DbContextHelper
    {
        public static DbContextOptions<AppDbContext> GetInMemoryOptions() =>
           new DbContextOptionsBuilder<AppDbContext>()
           .UseInMemoryDatabase($"{Guid.NewGuid()}")
           .Options;
    }
}
