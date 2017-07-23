using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTestProject.Models
{
    interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car Get(int id);
        Car Add(Car item);
        void Remove(int carID);
        bool Update(Car item);
        IEnumerable<Car> GetCarsByDealer(int id);
    }
}
