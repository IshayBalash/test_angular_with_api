using BOL;
using DAL;
using System;
using System.Linq;

namespace BLL
{
    public static class BLL
    {
       public static Product[] GETAllProducts()
        {
            try
            {
                using(productEntities db=new productEntities())
                {
                    return db.ProductsTables.Select(a => new Product() { ProductName = a.ProductName, ProductPrice = a.ProductPrice }).ToArray();
                }
            }
            catch(Exception e)
            
            {
                return null;
            }
        }

        public static Product GetOneProduct(string productname)
        {
            try
            {
                using (productEntities db = new productEntities())
                {
                    ProductsTable Product = db.ProductsTables.FirstOrDefault(a => a.ProductName == productname);
                    if (Product == null)
                    {
                        return null;
                    }
                    else
                    {
                        return new Product { ProductName = Product.ProductName, ProductPrice = Product.ProductPrice };
                    }

                }
            }
            catch
            {
                return null;
            }
        }


        public static bool DeleteProduct(string productname)
        {
            try
            {
                using (productEntities db = new productEntities())
                {
                    ProductsTable Product = db.ProductsTables.FirstOrDefault(a => a.ProductName == productname);
                    if (Product == null)
                    {
                        return false;
                    }
                    db.ProductsTables.Remove(Product);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false ;
            }
        }



    }
}
