

using LibrarySystem.DbContext;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.UnitTest
{
    public class TestUtilities
    {
        public static DbContextOptions<LibrarySystemContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<LibrarySystemContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }
    }
}
