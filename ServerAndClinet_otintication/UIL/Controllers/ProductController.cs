using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BOL;
using BLL;
using System.Net.Http.Formatting;
using UIL.Filters;

namespace UIL.Controllers
{
    
    public class ProductController : ApiController
    {
        // GET: api/Product
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            Product[] ProductsArry = BLL.BLL.GETAllProducts();
            if(ProductsArry == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Product[]>(ProductsArry, new JsonMediaTypeFormatter())
            };
            
        }

        // GET: api/Product/5
        [BasicAuthFilter]  //פילטר של זיהוי
        [Authorize(Roles = "Client")]  //פילטר של הרשאו
        //[AllowAnonymous]
        public HttpResponseMessage Get(string productname)
        {
            Product SingleProduct = BLL.BLL.GetOneProduct(productname);
            if (SingleProduct == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Product>(SingleProduct, new JsonMediaTypeFormatter())
            };


        }

        // DELETE: api/Product/5
        [BasicAuthFilter]  //פילטר של זיהוי
        [Authorize(Roles = "Manager")]  //פילטר של הרשאו
        public HttpResponseMessage Delete(string productname)
        {
            bool result = BLL.BLL.DeleteProduct(productname);
            HttpStatusCode responsecode = result ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return new HttpResponseMessage(responsecode) { Content = new ObjectContent<bool>(result, new JsonMediaTypeFormatter()) };
        }
    }
}
