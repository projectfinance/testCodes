using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Finance.Models;

namespace Finance.Controllers
{
    public class purchaseController : ApiController
    {
        [HttpPost]
        [Route("purchaseproduct")]
        public void Post([FromBody] Purchase pur)
        {
            FinanceEntities db = new FinanceEntities();
            
            PurchaseDetail p = new PurchaseDetail();
            p.PurchaseID = 1;
            p.ProductID = pur.id;
            p.CardID = "EMI093443";
            p.PurchaseDate = DateTime.Now;
            p.CustomerID = 3;
            p.EmiScheme = pur.scheme;
            p.EmiPerMonth = pur.amount/pur.scheme;
            p.EmiPaid = 0;
            p.EmiLeft = pur.amount; 

            db.PurchaseDetails.Add(p);
            db.SaveChanges();
        }
    }
}
