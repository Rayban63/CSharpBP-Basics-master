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
        #region Properties
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }

        #endregion

        #region Methodes

        /// <summary> 
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ( "Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message, 
                                                        this.Email);
            return confirmation;
        }

        /// <summary>
        /// Send productorder to vendor
        /// </summary>
        /// <param name="product">product to order</param>
        /// <param name="quantity">quantity of the product to order</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity)
        {
            return PlaceOrder(product, quantity, null, null);
        }

        /// <summary>
        /// Send productorder to vendor
        /// </summary>
        /// <param name="product">product to order</param>
        /// <param name="quantity">quantity of the product to order</param>
        /// <param name="deliverBy">Requested delivery date</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity, DateTimeOffset? deliverBy)
        {
            return PlaceOrder(product, quantity, deliverBy, null);

        }

        /// <summary>
        /// Send productorder to vendor
        /// </summary>
        /// <param name="product">product to order</param>
        /// <param name="quantity">quantity of the product to order</param>
        /// <param name="deliverBy">Requested delivery date</param>
        /// <param name="instructions">Delivery instructions</param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quantity, DateTimeOffset? deliverBy, string instructions)
        {
                if (product == null)
                    throw new ArgumentNullException(nameof(product));
                if (quantity <= 0)
                    throw new ArgumentOutOfRangeException(nameof(quantity));
                if (deliverBy <= DateTimeOffset.Now)
                    throw new ArgumentOutOfRangeException(nameof(deliverBy));

                var succes = false;
                var orderText = "Order from Acme.com" + System.Environment.NewLine +
                    "Product: " + product.ProductCode + System.Environment.NewLine +
                    "Quantity: " + quantity;
                if (deliverBy.HasValue)
                {
                    orderText += System.Environment.NewLine +
                        "Deliver By: " + deliverBy.Value.ToString("d");
                }
                if (!string.IsNullOrWhiteSpace(instructions))
                {
                    orderText += System.Environment.NewLine +
                        "Instructions:" + instructions;

                }
                var emailService = new EmailService();
                var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

                if (confirmation.StartsWith("Message sent: "))
                {
                succes = true;

                }
                var operationResult = new OperationResult(succes, orderText);
                return operationResult;
        }
        /// <summary>
        /// send productOrder to vendor
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="quantity">quantity of the product to order</param>
        /// <param name="includeAddress">true to include schipping address</param>
        /// <param name="sentCopy">true to sent a copy to the customer</param>
        /// <returns>Succes Flag and order text</returns>
        public OperationResult PlaceOrder(Product product, int quantity, bool includeAddress, bool sentCopy)
        {
            var orderText = "Test";
            if (includeAddress) orderText += " With Address";
            if (sentCopy) orderText += " With Copy";
            var operationResult = new OperationResult(true, orderText);
            return operationResult;
        }
        
        #endregion
    }
}
