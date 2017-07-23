using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiTestProject.Models;

namespace WebApiTestProject.Controllers
{
 
    public class CarController : ApiController
    {
        static readonly ICarRepository repository = new CarRepository();

        //public IEnumerable<Car> GetAllCars()
        //{
        //    return repository.GetAll();
        //}
 
        //public Car GetCar(int id)
        //{
        //    Car item = repository.Get(id);
        //    if (item == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    return item;
        //}

        public IEnumerable<Car> GetAllCars(int id)
        {
            return repository.GetCarsByDealer(id);
        }
  
        public HttpResponseMessage PostCar(Car item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Car>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutCar(Car item)
        {
           // car.Id = id;
            if (!repository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteCar(int Id)
        {
            repository.Remove(Id);
        }

        [HttpPost]
        [ResponseType(typeof(IEnumerable<Car>))]
        public async Task<IHttpActionResult> SearchAsync([FromUri] CarSearchOption searchOptions)
        {
            if(searchOptions == null)
            {
                return BadRequest("Invalid search options");
            }
            List<Car> resultList = new List<Car>();

            foreach(Car car in repository.GetAll())
            {
                if (!(string.IsNullOrEmpty(searchOptions.Name)) && (car.Dealer.Name.IndexOf(searchOptions.Name, StringComparison.OrdinalIgnoreCase)) >= 0
                    || (!( string.IsNullOrEmpty(searchOptions.Year)) && (car.Year.ToString() == searchOptions.Year.ToString()))
                    || (!(string.IsNullOrEmpty(searchOptions.Make)) && (car.Make.IndexOf(searchOptions.Make, StringComparison.OrdinalIgnoreCase) >= 0))
                    || (!(string.IsNullOrEmpty(searchOptions.Model)) && (car.Model.IndexOf(searchOptions.Model, StringComparison.OrdinalIgnoreCase) >= 0))
                    || (!(string.IsNullOrEmpty(searchOptions.Transmission)) && (car.Transmission.IndexOf(searchOptions.Transmission, StringComparison.OrdinalIgnoreCase) >= 0))
                    || (!(string.IsNullOrEmpty(searchOptions.EngineSize)) && (car.EngineSize.IndexOf(searchOptions.EngineSize, StringComparison.OrdinalIgnoreCase) >= 0))
                    || (!(string.IsNullOrEmpty(searchOptions.Badge)) && (car.Badge.IndexOf(searchOptions.Badge, StringComparison.OrdinalIgnoreCase) >= 0))
                    )
                {
                   resultList.Add(car);
                }
            }

            var searchResult = await Task.Run(() => resultList.ToList());
            return Ok(searchResult);
        }
    }
}
