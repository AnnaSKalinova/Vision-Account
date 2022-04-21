namespace AccountingProgram.Services.Accountants
{
    public interface IAccountantService
    {
        public bool IsUserAccountant(string userId);

        public void AddAccountant(string userId);

        public int GetIdByUser(string userId);
    }
}
