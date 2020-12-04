using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Finance.Models;

namespace Finance.Controllers
{
    public class productsController : ApiController
    {
        FinanceEntities db = new FinanceEntities();

        [Route("getproducts")]
        public HttpResponseMessage Get()
        {
            var prod = db.Products.ToList();
            if (prod.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, prod);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No Products found");
            }
        }
    }
}
