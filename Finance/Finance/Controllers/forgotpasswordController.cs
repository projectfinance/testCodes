using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Finance.Models;

namespace Finance.Controllers
{
    public class forgotpasswordController : ApiController
    {
        static int otp; //static, because otp will be set in Post() and will be fetched in GetOtpSession()

        [HttpPost]
        public void Post([FromBody] PhoneNum ph)
        {
            try
            {
                int otpValue = new Random().Next(100000, 999999);
                otp = otpValue;
                var accountSid = "AC61e058d33da3516c9a3e62538516a21c";
                var authToken = "02d513f31c99240e8043e894fb794cce";
                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber("+91" + ph.phone);
                var from = new PhoneNumber("+12054092684"); //Twilio Phone number
                var message = MessageResource.Create(
                    to: to,
                    from: from,
                    body: "Finance Management System \n Your OTP for Password Reset is " + otpValue + ".");
            }

            catch
            {
                //In case Number is not verified or Internet is not working
            }

        }

        /*
        [Route("getotpsession")]
        public HttpResponseMessage GetOtpSession()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, otp.ToString());
            return response;
        }*/

        
        [Route("getotpsession")]
        public IHttpActionResult GetCountryById()
        {
            OTPClass otp_curr = new OTPClass();
            otp_curr.current_otp = otp.ToString();
            return Ok(otp_curr);
        }
    }
}
