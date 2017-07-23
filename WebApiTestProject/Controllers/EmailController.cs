using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiTestProject.Models;

namespace WebApiTestProject.Controllers
{
    public class EmailController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> SendEmailNotification(EmailInput data)
        {
            ResponseBase updateResponse = new ResponseBase();
            var updateRequest = new RequestBase<EmailInput>(data);
            try
            {
                EmailHelper mailHelper = new EmailHelper(EmailHelper.EMAIL_SENDER, EmailHelper.EMAIL_CREDENTIALS, EmailHelper.SMTP_CLIENT);
                var emailBody = String.Format("Hello World Email to You");
                if (mailHelper.SendEMail(data.EmailId, EmailHelper.EMAIL_SUBJECT, "Hello World Email to You"))
                {
                    //   
                }
            }
            catch (Exception ex)
            { }
            return Ok(updateResponse);
        }       
    }
}
