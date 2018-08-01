using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebApplication1.Models;

using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;

namespace WebApplication1.Controllers
{
    //[EnableCors(origins:"*",headers: "*",methods: "*")]
    public class ProsuctsController : ApiController
    {
        // GET: api/Prosucts
        public HttpResponseMessage  Get()
        {
            Product[] ProductList = DAL.GetAllProducts();
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Product[]>(ProductList, new JsonMediaTypeFormatter())
            };
        }

        // GET: api/Prosucts/5
        public HttpResponseMessage Get(string productname)
        {
            Product P = DAL.GetSpeseficProduct(productname);
            if (P == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Product>(P, new JsonMediaTypeFormatter())
            };
        }

        // POST: api/Prosucts
        public HttpResponseMessage Post([FromBody]Product value)
        {
            bool InsertResult = false;
            if (ModelState.IsValid)
            {
                InsertResult=DAL.AddProduct(value);
            }
            HttpStatusCode ResponsCode = InsertResult ? HttpStatusCode.Created : HttpStatusCode.BadRequest;
            return new HttpResponseMessage(ResponsCode) { Content = new ObjectContent<bool>(InsertResult, new JsonMediaTypeFormatter()) };
        }

        // PUT: api/Prosucts/5
        public HttpResponseMessage Put(string productname, [FromBody]Product productparam)
        {
            bool updateResult = false;
            if (ModelState.IsValid)
            {
                updateResult=DAL.EditProduct(productname, productparam);
            }
            HttpStatusCode rsponseCode = (updateResult) ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return new HttpResponseMessage(rsponseCode) { Content = new ObjectContent<bool>(updateResult, new JsonMediaTypeFormatter()) };
        }

        // DELETE: api/Prosucts/5
        [HttpDelete]
        public HttpResponseMessage Delete(string productname)
        {
            bool Result = DAL.DeleteProduct(productname);
            HttpStatusCode responsCode = Result ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return new HttpResponseMessage(responsCode) { Content = new ObjectContent<bool>(Result, new JsonMediaTypeFormatter()) };
        }
    }
}
