namespace AccountingProgram.Test.Mocks
{
    using AccountingProgram.Data;
    using Microsoft.EntityFrameworkCore;
    using System;

    public static class DatabaseMock
    {
        public static AccountingDbContext Instance
        {
            get 
            {
                var dbContextOptions = new DbContextOptionsBuilder<AccountingDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new AccountingDbContext(dbContextOptions);
            }
        }
    }
}
