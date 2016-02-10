using Acme.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages the vendors from whom we purchase our inventory.
    /// </summary>
    public class Vendor 
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public enum IncludeAddress { Yes, No };
        public enum SendCopy { Yes, No };

        public OperationResult PlaceOrder(Product product, int quantity, DateTimeOffset? deliveryBy = null, string instructions = "standard delivery")
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliveryBy <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(deliveryBy));

            var success = false;
            var orderText =
                $"Order from Acme, Inc{System.Environment.NewLine}Product: {product.ProductCode}{System.Environment.NewLine}Quantity: {quantity}";

            if (deliveryBy.HasValue)
                orderText += $"{Environment.NewLine}Deliver By: {deliveryBy.Value.ToString("d")}";

            if (!string.IsNullOrWhiteSpace(instructions))
                orderText += $"{Environment.NewLine}Instructions: {instructions}";

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, Email);

            if (confirmation.StartsWith("Message sent: "))
            {
                success = true;
            }
            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }
        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="quantity">Quantity of the product to order</param>
        /// <param name="includeAddress">True to include shipping address</param>
        /// <param name="sendCopy">True to send a copy of the email to the current current user</param>
        /// <returns>Success flag and order text</returns>
        public OperationResult PlaceOrder(Product product, int quantity, bool includeAddress, bool sendCopy)
        {
            var orderText = "Test";
            if (includeAddress) orderText += $" with Address";
            if (sendCopy) orderText += $" with Copy";

            var operationResult = new OperationResult(true, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="quantity">Quantity of the product to order</param>
        /// <param name="includeAddress">True to include shipping address</param>
        /// <param name="sendCopy">True to send a copy of the email to the current current user</param>
        /// <returns>Success flag and order text</returns>
        public OperationResult PlaceOrder(Product product, int quantity, IncludeAddress includeAddress, SendCopy sendCopy)
        {
            var orderText = "Test";
            if (includeAddress == IncludeAddress.Yes) orderText += $" with Address";
            if (sendCopy == SendCopy.Yes) orderText += $" with Copy";

            var operationResult = new OperationResult(true, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject, message, this.Email);
            return confirmation;
        }

        public override string ToString()
        {
            string vendorInfo = "Vendor: " + CompanyName;
            string result;
            result = vendorInfo?.ToLower();
            result = vendorInfo?.ToUpper();
            result = vendorInfo?.Replace("Vendor", "Supplier");

            var length = vendorInfo?.Length;
            var index = vendorInfo?.IndexOf(":");
            var begins = vendorInfo?.StartsWith("Vendor");

            return vendorInfo;
        }
    }
}
