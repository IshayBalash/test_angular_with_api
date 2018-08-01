using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Net.Http.Formatting;
using System.Web.Http.ModelBinding;

namespace WebApplication1
{
    public static class DAL
    {
        public static Product[] GetAllProducts()
        {
            using(test_productEntities db = new  test_productEntities())
            {
                return db.ProductsTables.Select(a => new Product() { ProductName = a.ProductName, Price = a.ProductPrice }).ToArray();

            }
        }
        public static Product GetSpeseficProduct(string productParam)
        {
            using(test_productEntities db=new test_productEntities())
            {
                ProductsTable ProductChose = db.ProductsTables.FirstOrDefault(a => a.ProductName == productParam);
                if (ProductChose == null)
                {
                    return null;
                }
                return new Product { ProductName = ProductChose.ProductName,Price = ProductChose.ProductPrice };
            }
        }

        public static bool DeleteProduct (string productParam)
        {
            using (test_productEntities db = new test_productEntities())
            {
                ProductsTable ProductChose = db.ProductsTables.FirstOrDefault(a => a.ProductName == productParam);
                if (ProductChose == null)
                {
                    return false;
                }
                db.ProductsTables.Remove(ProductChose);
                db.SaveChanges();
                return true;
            }
        }
        public static bool AddProduct(Product Productparam)
        {
            try
            {
                using (test_productEntities db = new test_productEntities())
                {
                    ProductsTable NewProduct = new ProductsTable
                    {
                        ProductName = Productparam.ProductName,
                        ProductPrice = Productparam.Price,
                       
                    };
                    db.ProductsTables.Add(NewProduct);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }



        public static bool EditProduct(string productname,Product Productparam)
        {
            try
            {
                using (test_productEntities db = new test_productEntities())
                {
                    ProductsTable SelectedProuduct = db.ProductsTables.FirstOrDefault(a =>  a.ProductName == Productparam.ProductName);
                    if (SelectedProuduct == null)
                    {
                        return false;
                    }
                    SelectedProuduct.ProductPrice = Productparam.Price;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        
    }
    }
}