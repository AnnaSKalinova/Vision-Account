namespace AccountingProgram.Services.Routes.Models
{
    using AccountingProgram.Services.Customers.Models;
    using System.Collections.Generic;

    public class RouteDetailsServiceModel
    {
        public int Id { get; init; }

        public char Code { get; init; }

        public ICollection<CustomerServiceModel> Customers { get; init; }

        public string Description { get; init; }
    }
}
