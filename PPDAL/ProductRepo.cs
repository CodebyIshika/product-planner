using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDAL
{
    public class ProductRepo
    {
        public List<Product> GetProductRepo()
        {
            ADOCEntities adoc = new ADOCEntities();
            return adoc.Products.ToList();
        }

        public Product GetProductByIdRepo(int id)
        {
            ADOCEntities adoc = new ADOCEntities();
            return adoc.Products.FirstOrDefault(x => x.ProductID == id);
        }

        public bool AddProduct(Product product)
        {
            ADOCEntities adoc = new ADOCEntities();
            if (product != null)
            {
                adoc.Products.Add(product);
                adoc.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateProduct(Product product)
        {
            // get the existing object from context 
            ADOCEntities adoc = new ADOCEntities();

            Product productTOBeUpdated = adoc.Products.FirstOrDefault(x => x.ProductID == product.ProductID);

            if (productTOBeUpdated != null)
            {
                Mapper.Map(product, productTOBeUpdated);
                adoc.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteProductRepo(int ProductID)
        {
            ADOCEntities adoc = new ADOCEntities();

            var product = adoc.Products.Where(x => x.ProductID == ProductID).FirstOrDefault();
            if (product != null)
            {
                adoc.Products.Remove(product);
                adoc.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
