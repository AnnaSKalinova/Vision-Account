namespace AccountingProgram.Data
{
    public class DataConstants
    {
        //Category
        public const int CategoryNameMaxLength = 30;

        //Customer
        public const string CustomerIdRegex = @"[0-9]{10}";
        public const int CustomerNameMaxLength = 30;
        public const int CustomerNameMinLength = 2;
        public const int ChainNameMaxLength = 30;
        public const int ChainNameMinLength = 2;
        public const int CustomerAddressMaxLength = 50;
        public const int CustomerAddressMinLength = 5;
        public const int ContactNameMaxLength = 50;
        public const int ContactNameMinLength = 2;
        public const string RouteRegex = @"[A-Z]{1}";

        //Customer Error Messages
        public const string ErrorIdFormat = "The Id must be in the following format: \"0123456789\".";
        public const string ErrorCustomerNameLength = "The Name of the Customer must be with a minimum length of {2} and a maximum length of {1}.";
        public const string ErrorChainNameLength = "The Chain Name must be with a minimum length of {2} and a maximum length of {1}.";
        public const string ErrorAddressLength = "The Address must be with a minimum length of {2} and a maximum length of {1}.";
        public const string ErrorContactNameLength = "The Name of the Contact must be with a minimum length of {2} and a maximum length of {1}.";
        public const string ErrorEmailFormat = "The Email must be in the following format: \"user@example.com\".";

        //Driver
        public const int DriverNameMaxLength = 50;
        public const int DriverNameMinLength = 5;

        //Driver Error Messages
        public const string ErrorDriverNameLength = "The Name of the Driver must be with a minimum length of {2} and a maximum length of {1}.";

        //Item
        public const int ItemNameMaxLength = 30;
        public const int ItemNameMinLength = 2;

        //Item Error Messages
        public const string ErrorItemNameLength = "The Name of the Item must be with a minimum length of {2} and a maximum length of {1}.";

        //Payment Term
        public const int PaymentTermCodeMaxLength = 7;
        public const int PaymentTermCodeMinLength = 2;

        //Payment Term Error Messages
        public const string ErrorPaymentTermCodeLength = "The Code of the Payment Term must be with a minimum length of {2} and a maximum length of {1}.";

        //Route
        public const string RouteCodeRegex = @"[A-Z]{1}";
        public const int RouteDescriptionMaxLength = 50;
        public const int RouteDescriptionMinLength = 2;

        //Route Error Messages
        public const string ErrorRouteCodeRegex = "The Route Code must be a single capital letter.";
        public const string ErrorRouteDescriptionLength = "The Description of the Route must be with a minimum length of {2} and a maximum length of {1}.";

        //VatGroup
        public const int DescriptionMaxLength = 30;
        public const int DescriptionMinLength = 2;

        // VatGroup Error Messages
        public const string ErrorDescriptionLength = "The VAT description must be with a minimum length of {2} and a maximum length of {1}.";

        //Vendor
        public const int VendorNameMaxLength = 30;
        public const int VendorAddressMaxLength = 50;
        public const int VendorEmailMaxLength = 20;
    }
}
