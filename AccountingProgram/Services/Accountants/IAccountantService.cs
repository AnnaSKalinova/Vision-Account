namespace AccountingProgram.Services.Accountants
{
    public interface IAccountantService
    {
        public bool IsAccountant(string userId);

        public int GetIdByUser(string userId);
    }
}
