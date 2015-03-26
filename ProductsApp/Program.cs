using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp
{
    class Program
    {
        // Get an entire entity set.
        static void ListAllProducts(ProductsApp.ProductService.Container container)
        {
            foreach (var p in container.Products)
            {
                Console.WriteLine("{0} {1} {2}", p.Name, p.Price, p.Category);
            }
        }

        static void AddProduct(ProductsApp.ProductService.Container container, ProductService.Models.Product product)
        {
            container.AddToProducts(product);
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }


        static void Main(string[] args)
        {
            // TODO: Replace with your local URI.
            string serviceUri = "http://localhost:52962/";
            var container = new ProductsApp.ProductService.Container(new Uri(serviceUri));

            var product = new ProductService.Models.Product()
            {
                Name = "Yo-yo",
                Category = "Toys",
                Price = 4.95M
            };

            AddProduct(container, product);
            ListAllProducts(container);
        }
    }
}
