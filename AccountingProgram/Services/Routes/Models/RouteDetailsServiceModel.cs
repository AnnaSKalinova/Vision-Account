namespace AccountingProgram.Services.Routes.Models
{
    using System.Collections.Generic;

    using AccountingProgram.Services.Customers.Models;
    
    public class RouteDetailsServiceModel
    {
        public int Id { get; init; }

        public char Code { get; init; }

        public string Description { get; init; }

        public ICollection<CustomerServiceModel> Customers { get; init; }
    }
}
