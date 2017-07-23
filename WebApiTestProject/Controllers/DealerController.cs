using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using WebApiTestProject.Models;

namespace WebApiTestProject.Controllers
{
    public class DealerController : ApiController
    {
        static readonly IDealerRepository repository = new DealerRepository();
        public void PutDealer(int id, Dealer item)
        {
            item.Id = id;
            if (!repository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage GetStockSummary(int id)
        {
            var response = new HttpResponseMessage();
            List<Car> today = new List<Car>();
            List<Car> thisWeek = new List<Car>();
            List<Car> thisMonth = new List<Car>();

            response.Content = new StringContent("<html><body>  Today" + repository.GetDealerSummary(id) + "</body></html>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
    }
}
