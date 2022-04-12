namespace AccountingProgram.Services.Accountants
{
    public interface IAccountantService
    {
        int Create(
            string accountantName, 
            string phoneNumber, 
            string userId);

        public int GetIdByUser(string userId);

        public bool UserIsAlreadyAccountant(string userId);
    }
}
