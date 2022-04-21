namespace AccountingProgram.Infrastructure
{
    using AccountingProgram.Data.Models;
    using AccountingProgram.Models.SalesInvoices;
    using AccountingProgram.Services.Customers.Models;
    using AccountingProgram.Services.Drivers.Models;
    using AccountingProgram.Services.Items.Models;
    using AccountingProgram.Services.Routes.Models;
    using AccountingProgram.Services.SalesInvoices.Models;

    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Driver, DriverServiceModel>();
            this.CreateMap<SalesInvoiceDetailsServiceModel, SalesInvoiceFormModel>();
            this.CreateMap<SalesInvoice, SalesInvoiceDetailsServiceModel>()
                .ForMember(si => si.UserId, cfg => cfg.MapFrom(si => si.AccountantId));
            this.CreateMap<Customer, CustomerServiceModel>()
                .ForMember(c => c.SalesInvoices, cfg => cfg.MapFrom(c => c.SalesInvoices));
            this.CreateMap<Customer, CustomerDetailsServiceModel>();
            this.CreateMap<Route, RouteServiceModel>();
            this.CreateMap<Route, RouteDetailsServiceModel>();
            this.CreateMap<Item, ItemServiceModel>()
                .ForMember(i => i.ItemCategory, cfg => cfg.MapFrom(i => i.ItemCategory.Name));
            this.CreateMap<Item, ItemDetailsServiceModel>()
                .ForMember(i => i.ItemCategory, cfg => cfg.MapFrom(i => i.ItemCategory.Name));
            this.CreateMap<ItemCategory, ItemCategoryServiceModel>();
            this.CreateMap<Route, RouteCustomerServiceModel>();
        }
    }
}
