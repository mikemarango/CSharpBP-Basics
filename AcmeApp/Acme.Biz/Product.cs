using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class Product
    {
        public Product()
        {
            Console.WriteLine("Product instance created");
        }

        public Product(int productId, string productName, string productDescription) : this()
        {
            _productId = productId;
            _productName = productName;
            _productDescription = productDescription;
            
            Console.WriteLine($"Product instance has a name: {ProductName}");
        }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        private string _productDescription;
        public string ProductDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; }
        }

        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public string SayHello()
        {
            return $"Hello {ProductName} ({ProductId}): {ProductDescription}";
        }
    }
}
