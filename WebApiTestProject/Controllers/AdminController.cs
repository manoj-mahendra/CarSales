using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTestProject.Models;

namespace WebApiTestProject.Controllers
{
    public class AdminController : ApiController
    {
        static readonly IDealerRepository repository = new DealerRepository();
        public IEnumerable<Dealer> GetAllDealers()
        {
            return repository.GetAll();
        }
        public Dealer GetDealer(int id)
        {
            Dealer item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public HttpResponseMessage PostDealer(Dealer item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Dealer>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutDealer(int id, Dealer item)
        {
            item.Id = id;
            if (!repository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteDealer(int id)
        {
            repository.Remove(id);
        }
    }
}
