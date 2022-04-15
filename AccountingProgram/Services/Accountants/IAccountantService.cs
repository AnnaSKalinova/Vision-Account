using AccountingProgram.Data.Models;

namespace AccountingProgram.Services.Accountants
{
    public interface IAccountantService
    {
        public int GetIdByUser(string userId);

        public bool IsUserAccountant(string userId);

        public void AddAccountant(User user);
    }
}
