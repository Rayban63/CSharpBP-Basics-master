using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in Inventory 
    /// </summary>
    public class Product
    {
        #region Constructor
        public Product()
        {
            Console.WriteLine("Product instance is created");
            //this.ProductVendor = new Vendor();//When the instance is allways needded this code needs to be active
        }
        public Product(int productId, string productName, string productDescription ) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductDescription = productDescription;

            Console.WriteLine("Product instance has a name: " + ProductName);

        }
        #endregion

        #region Properties

        
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        private string productDescription;

        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get
            {
                //when a instance is not allways needded instantiate the instanstance only when its needded (lazy loading)
                if (productVendor == null) 
                {
                    productVendor = new Vendor();

                }
                return productVendor;
            }
            set { ProductVendor = value; }
        }

        #endregion

        #region Methodes
        /// <summary>
        /// Basic Methode to test the class
        /// </summary>
        /// <returns></returns>
        public string SayHello()
        {
            //when a instance is only needded once, instantiate the instanstance here
            var vendor = new Vendor();
            vendor.SendWelcomeEmail("Message from Acme.com");
            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", this.ProductName, "Sales@abc.com");

            var result = LogAction("Saying Hello");
            return "Hello " + ProductName +
                 " (" + ProductId + "): " + ProductDescription;
               
        }
        #endregion


    }
}
