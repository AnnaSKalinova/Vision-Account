namespace AccountingProgram.Services.Customers.Models
{

    public class CustomerDetailsServiceModel: CustomerServiceModel
    {
        public string ChainName { get; init; }

        public string Address { get; init; }

        public string ContactName { get; init; }

        public string Email { get; init; }
    }
}
