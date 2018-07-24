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
    [EnableCors(origins:"*",headers: "*",methods: "*")]
    public class ProsuctsController : ApiController
    {
        // GET: api/Prosucts
        public HttpResponseMessage  Get()
        {
            Product[] ProductList = new Product[] { new Product { ProductName = "kola", Price = 30},new Product { ProductName="sprit",Price=40}};
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<Product[]>(ProductList, new JsonMediaTypeFormatter())
            };
        }

        // GET: api/Prosucts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Prosucts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Prosucts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prosucts/5
        public void Delete(int id)
        {
        }
    }
}
