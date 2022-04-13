﻿namespace AccountingProgram.Services.Customers
{
    using System.Collections.Generic;

    using AccountingProgram.Models.Customers;
    using AccountingProgram.Services.Customers.Models;

    public interface ICustomerService
    {
        CustomerQueryServiceModel All(
            string chain, 
            string searchTerm, 
            CustomerSorting sorting,
            int currentPage = 1,
            int salesInvoicesPerPage = int.MaxValue);

        IEnumerable<string> AllCustomersChains();

        IEnumerable<CustomerServiceModel> AllCustomers();

        IEnumerable<RouteCustomerServiceModel> GetRoutes();

        CustomerDetailsServiceModel Details(int id);

        bool CustomerExists(int id);

        int Create(
            string name, 
            string chainName, 
            string address, 
            string contactName, 
            string email, 
            int paymentTerm, 
            int routeId);
    }
}
