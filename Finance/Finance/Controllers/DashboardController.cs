using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Finance.Controllers
{
    public class DashboardController : ApiController
    {
        private FinanceEntities db = new FinanceEntities();

        [Route("EMICard")]
        public HttpResponseMessage GetEmiCard()
        {
            var card = (from user_ob in db.Users
                        join card_ob in db.CardDetails
                        on user_ob.CustomerID equals card_ob.CustomerID
                        select new
                        {
                            CustomerID = user_ob.CustomerID,
                            Username = user_ob.Username,
                            Password = user_ob.Password,
                            AccountNumber = user_ob.AccountNumber,
                            Firstname = user_ob.Firstname,
                            LastName = user_ob.LastName,
                            Phoneno = user_ob.Phoneno,
                            EmailID = user_ob.EmailID,
                            Address = user_ob.Address,
                            CardID = card_ob.CardID,
                            Validity = card_ob.Validity,
                            CardType = card_ob.CardType,
                            ActivationStatus = card_ob.ActivationStatus,
                            TotalCredit = card_ob.TotalCredit,
                            RemainingCredit = card_ob.RemainingCredit,
                            EMIPendingStatus = card_ob.EMIPendingStatus
                        }).ToList();


            if (card.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, card);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error 404! Not Found.");
            }
        }

        [Route("Purchase")]
        public HttpResponseMessage GetPurchase()
        {
            var purchase = (from purch_ob in db.PurchaseDetails
                            join prod_obj in db.Products
                            on purch_ob.ProductID equals prod_obj.ProductID
                            select new { purch_ob, prod_obj }).ToList();
            if (purchase.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, purchase);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error 404! Not Found.");
            }
        }

        [Route("Admin")]
        public HttpResponseMessage GetAdmin()
        {
            var admin = (from user_ob in db.Users
                         join bank_ob in db.BankDetails
                         on user_ob.AccountNumber equals bank_ob.AccountNumber
                         select new
                         {
                             CustomerID = user_ob.CustomerID,
                             Username = user_ob.Username,
                             Password = user_ob.Password,
                             AccountNumber = user_ob.AccountNumber,
                             Firstname = user_ob.Firstname,
                             LastName = user_ob.LastName,
                             Phoneno = user_ob.Phoneno,
                             EmailID = user_ob.EmailID,
                             Address = user_ob.Address,
                             BankName = bank_ob.BankName,
                             BankIFSC = bank_ob.BankIFSC
                         }).ToList();

            if (admin.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, admin);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Error 404! Not Found.");
            }
        }

        [Route("Activate")]
        [HttpPut]
        public IHttpActionResult Put(CardDetail cardDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                CardDetail c = new CardDetail();
                c = db.CardDetails.Find(cardDetail.CustomerID);
                if (c != null)
                {
                    c.ActivationStatus = cardDetail.ActivationStatus;
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(cardDetail);
        }
    }
}
