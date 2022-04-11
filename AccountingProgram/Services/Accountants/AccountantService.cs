namespace AccountingProgram.Services.Accountants
{
    using System.Linq;

    using AccountingProgram.Data;
    
    public class AccountantService : IAccountantService
    {
        private readonly AccountingDbContext data;

        public AccountantService(AccountingDbContext data)
        {
            this.data = data;
        }

        public int GetIdByUser(string userId)
        {
            return this.data
                .Accountants
                .Where(a => a.UserId == userId)
                .Select(a => a.Id)
                .FirstOrDefault();
        }

        public bool IsAccountant(string userId)
        {
            return this.data
                .Accountants
                .Any(a => a.UserId == userId);
        }
    }
}
