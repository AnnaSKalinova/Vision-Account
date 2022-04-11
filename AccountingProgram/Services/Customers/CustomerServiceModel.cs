namespace AccountingProgram.Services.Customers
{
    public class CustomerServiceModel
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public char Route { get; init; }

        public int PaymentTerm { get; init; }

        public int SalesInvoices { get; init; }
    }
}
