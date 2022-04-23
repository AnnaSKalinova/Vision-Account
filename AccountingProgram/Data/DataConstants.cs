namespace AccountingProgram.Data
{
    public class DataConstants
    {
        public const int CountPerPage = 6;

        public class Accountant
        {
            public const int AccountantNameMaxLength = 50;
            public const int AccountantNameMinLength = 2;
            public const string PhoneNumberRegex = @"[0-9]{3}-[0-9]{4}";

            //Error Messages
            public const string ErrorAccountantNameLength = "The Name of the Accountant must be with a minimum length of {2} and a maximum length of {1}!";
            public const string ErrorPhoneNumberRegex = "The phone number must be in the following format: 000-0000!";
            public const string ErrorAccountantDoesNotExist = "This accountant does not exist!";
        }

        public class Category
        {
            public const int CategoryNameMaxLength = 30;

            //Error messages
            public const string ErrorCategoryDoesNotExist = "This category does not exist!";
        }

        public class Customer
        {
            public const string CustomerIdRegex = @"[0-9]{10}";
            public const int CustomerNameMaxLength = 50;
            public const int CustomerNameMinLength = 2;
            public const int ChainNameMaxLength = 30;
            public const int ChainNameMinLength = 2;
            public const int CustomerAddressMaxLength = 70;
            public const int CustomerAddressMinLength = 5;
            public const int ContactNameMaxLength = 50;
            public const int ContactNameMinLength = 2;
            public const string RouteRegex = @"[A-Z]{1}";
            public const string ChainNameAttribute = "Chain name";
            public const string ContactNameAttribute = "Contact name";
            public const string PaymentTermAttribute = "Payment term code";
            public const string CustomerNameAttribute = "Customer name";
            public const string AddedCustomerMessage = "You successfully added a new customer!";

            //Error Messages
            public const string ErrorIdFormat = "The Id must be in the following format: \"0123456789\"!";
            public const string ErrorCustomerNameLength = "The Name of the Customer must be with a minimum length of {2} and a maximum length of {1}!";
            public const string ErrorChainNameLength = "The Chain Name must be with a minimum length of {2} and a maximum length of {1}!";
            public const string ErrorAddressLength = "The Address must be with a minimum length of {2} and a maximum length of {1}!";
            public const string ErrorContactNameLength = "The Name of the Contact must be with a minimum length of {2} and a maximum length of {1}!";
            public const string ErrorEmailFormat = "The Email must be in the following format: \"user@example.com\"!";
            public const string ErrorValuePostingDate = "Posting Date must be a date in year 2022!";
            public const string ErrorCustomerDoesNotExist = "This customer does not exist!";
            public const string ErrorCustomerExists = "This customer already exists!";
            public const string ErrorPaymentTermRequired = "Payment term code is required!";

        }

        public class Driver
        {
            public const int DriverNameMaxLength = 50;
            public const int DriverNameMinLength = 2;
            public const string RoutesAttribute = "Route";
            public const string AddedDriverMessage = "You successfully added a new driver!";

            //Error Messages
            public const string ErrorDriverNameLength = "The Name of the Driver must be with a minimum length of {2} and a maximum length of {1}!";
            public const string ErrorDriverExists = "This Driver already exists!";
        }

        public class Item
        {
            public const int ItemNameMaxLength = 30;
            public const int ItemNameMinLength = 2;
            public const string ItemTypeAttribute = "Item type";
            public const string ItemCategoryAttribute = "Item category";
            public const string UnitPriceExclVatAttribute = "Unit price excl. VAT";
            public const string DecimalTypeAttribute = "decimal(18,4)";
            public const string VatGroupAttribute = "VAT group";
            public const string UnitPriceInclVatAttribute = "Unit price incl. VAT";
            public const string UnitCostAttribute = "Unit Cost";
            public const string ProfitAttribute = "Profit %";
            public const string ItemNameAttribute = "Item name";
            public const string AddedItemMessage = "You successfully added a new item!";
            public const int RangeMinValueInt = 0;
            public const int RangeMaxValueInt = 100;
            public const double RangeMinValueDecimal = 0.01;

            //Error Messages
            public const string ErrorItemNameLength = "The Name of the Item must be with a minimum length of {2} and a maximum length of {1}!";
            public const string ErrorItemDoesNotExist = "This Item does not exist!";
            public const string ErrorItemNameExist = "This Item already exists!";
            public const string ErrorVatGroupRequired = "VAT group is required!";
            public const string ErrorItemTypeRequired = "Item type is required!";
            public const string ErrorMeasureRequired = "Measure is required!";
            public const string ErrorItemCategoryRequired = "Item category is required!";
            public const string ErrorUnitPriceExclVatRequired = "Unit price is required!";
            public const string ErrorUnitCostRequired = "Unit cost is required!";
        }

        public class PaymentTerm
        {
            public const int PaymentTermCodeMaxLength = 7;
            public const int PaymentTermCodeMinLength = 2;

            //Error Messages
            public const string ErrorPaymentTermCodeLength = "The Code of the Payment Term must be with a minimum length of {2} and a maximum length of {1}!";
        }

        public class Route
        {
            public const string RouteCodeRegex = @"[A-Z]{1}";
            public const int RouteDescriptionMaxLength = 50;
            public const int RouteDescriptionMinLength = 2;
            public const string AddedRouteMessage = "You successfully added a new route!";

            //Error Messages
            public const string ErrorRouteCodeRegex = "The Route Code must be a single capital letter!";
            public const string ErrorRouteDescriptionLength = "The Description of the Route must be with a minimum length of {2} and a maximum length of {1}!";
            public const string ErrorRouteExists = "This Route already exists!";
        }

        public class VatGroup
        {
            public const int DescriptionMaxLength = 30;
            public const int DescriptionMinLength = 2;

            //Error Messages
            public const string ErrorDescriptionLength = "The VAT description must be with a minimum length of {2} and a maximum length of {1}!";
        }

        public class User
        {
            public const int UserFullNameMaxLength = 50;
            public const int UserFullNameMinLength = 2;
        }

        public class SalesInvoices
        {
            public const string PostingDateAttribute = "Posting date";
            public const string StartDateAttribute = "01.01.2022";
            public const string EndDateAttribute = "31.12.2022";
            public const string TotalPriceInclVatAttribute = "Total price incl. VAT";
            public const string TotalPriceExclVatAttribute = "Total price excl. VAT";
            public const string VatAttribute = "VAT";
            public const string DateFormat = "dd.MM.yyyy";
            public const string AddedSalesInvoiceMessage = "You created the sales invoice successfully. It is now waiting for approval!";

            //Error messages
            public const string ErrorCounRange = "The Count must be a positive number!";
        }
    }
}
