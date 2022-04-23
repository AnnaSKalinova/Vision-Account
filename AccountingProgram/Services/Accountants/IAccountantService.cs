namespace AccountingProgram.Services.Accountants
{
    public interface IAccountantService
    {
        public void AddAccountant(string userId);

        public bool IsUserAccountant(string userId);

        public int GetIdByUser(string userId);
    }
}
