using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class Product
    {
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;
        #region Fields
        private string _productName;
        private string _productDescription;
        private int _productId;

        #endregion
        #region Constructors
        public Product()
        {
            Console.WriteLine("Product instance created");
            MinimumPrice = .96m;
            
            //ProductVendor = new Vendor();
        }

        public Product(int productId, string productName, string productDescription) : this()
        {
            _productId = productId;
            _productName = productName;
            _productDescription = productDescription;

            if (ProductName.StartsWith("Bulk"))
            {
                MinimumPrice = 9.99m;

            }

            Console.WriteLine($"Product instance has a name: {ProductName}");
        }
        #endregion
        #region Properties
        public string ProductName
        {
            get
            {
                var formattedValue = _productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product name cannot be more than 20 characters";
                }

                else
                {
                    _productName = value; 
                }
            }
        }

        public string ProductDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; }
        }

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        private DateTime? _availabilityDate;

        public DateTime? AvailabilityDate
        {
            get { return _availabilityDate; }
            set { _availabilityDate = value; }
        }


        private Vendor _productVendor;

        public Vendor ProductVendor
        {
            get
            {
                if (_productVendor == null)
                {
                    _productVendor = new Vendor();
                }
                return _productVendor;
            }
            set { _productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", _productName, "sales@acme.com");
            var result = LoggingService.LogAction("Saying Hello");

            return $"Hello {ProductName} ({ProductId}): {ProductDescription} Available on: {AvailabilityDate?.ToShortDateString()}";
        }
    }
}
