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
            if (product == null)
            throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));

            var succes = false;
            var orderText = "Order from Acme.com" + System.Environment.NewLine +
                "Product: " + product.ProductCode + System.Environment.NewLine +
                "Quantity: " + quantity;
           


            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent: "))
            {
                succes = true;

            }
            var operationResult = new OperationResult(succes, orderText);
            return operationResult;
        }
        #endregion
    }
}
