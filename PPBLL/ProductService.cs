using PPDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPBLL
{
    public class ProductService
    {
        public List<Product> GetProduct()
        {
            List<Product> product = new List<Product>();
            ProductRepo productRepo = new ProductRepo();
            product = productRepo.GetProductRepo();

            return product;
        }

        public Product GetProductInfo(int id)
        {
            ProductRepo productRepo = new ProductRepo();
            return productRepo.GetProductByIdRepo(id);
        }

        public bool AddProduct(Product product)
        {
            ProductRepo productRepo = new ProductRepo();

            if (ValidateInputs(product))
                return productRepo.AddProduct(product);

            return false;
            
        }

        public bool UpdateProduct(Product product)
        {
            ProductRepo productRepo = new ProductRepo();

            if (ValidateInputs(product))
                return productRepo.AddProduct(product);

            return false;

        }

        public bool DeleteProduct(int ProductID)
        {
            ProductRepo productRepo = new ProductRepo();

            return productRepo.DeleteProductRepo(ProductID);
        }

        public bool ValidateInputs(Product product)
        {
            // Performing validations
            bool isValid = !string.IsNullOrEmpty(product.ProductName) ||
                           !string.IsNullOrEmpty(product.Description) ||
                           (product.Price != null && product.Price > 0) ||
                           (product.Quantity != null && product.Quantity > 0) ||
                           !string.IsNullOrEmpty(product.Category) ||
                           !string.IsNullOrEmpty(product.Supplier);

            return isValid;
        }
    }
}
