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
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;

        #region Constructor
        public Product()
        {
            Console.WriteLine("Product instance is created");
            //this.ProductVendor = new Vendor();//When the instance is allways needded this code needs to be active
            this.MinimumPrice = .96m;
            this.Category = "Tools";
        }
        public Product(int productId, string productName, string productDescription ) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            if (ProductName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.91m;

            }

            Console.WriteLine("Product instance has a name: " + ProductName);

        }
        #endregion

        #region Properties

        private DateTime? availabilityDate;

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">percent used to mark up the cost</param>
        /// <returns></returns>
        public decimal CalculateSuggestedPrice(decimal markupPercent) =>
        this.Cost + (this.Cost * markupPercent / 100);

        public DateTime? AvailabilityDate

        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }
        public decimal Cost { get; set; }

        private string productName;

        public string ProductName
        {
            get
            {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length <3)
                {
                    ValidationMessage = "Product name must be at least 3 characters";
                    Console.WriteLine(ValidationMessage);
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product name cannot be more than 20 characters";
                    Console.WriteLine(ValidationMessage);
                }
                else
                {
                    productName = value;
                }
               
            }
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
        internal  string Category { get; set; }
        public int SequenceNumber { get; set; } = 1;
        public string ProductCode => this.Category + "-" + this.SequenceNumber;


        public string ValidationMessage { get; private set; }

        #endregion

        #region Methodes
        /// <summary>
        /// Basic Methode to test the class
        /// </summary>
        /// <returns></returns>
        public string SayHello()
        {
            //when a instance is only needded once, instantiate the instanstance in the methode
            var vendor = new Vendor();
            vendor.SendWelcomeEmail("Message from Acme.com");
            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", this.ProductName, "Sales@abc.com");

            var result = LogAction("The result is logged");
            return "Hello " + ProductName +
                 " (" + ProductId + "): " + ProductDescription +
                 ", Available on: " + AvailabilityDate?.ToShortDateString();

               
        }       
        public override string ToString() =>
        this.ProductName + "(Product Id: " + this.ProductId + ")";
        #endregion



    }
}
