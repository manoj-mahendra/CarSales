using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace WebApiTestProject.Models
{
    public class CarRepository : ICarRepository
    {
        private List<Car> cars = new List<Car>();
        DealerRepository dealerRepository = new DealerRepository();
        public CarRepository()
        {
            Add(new Car { Id = 1,
                           Year=2006, 
                           Make="Chevrolet", 
                           Model="Chevrolet Imapla", 
                           Badge="ChevvyBadge", 
                           EngineSize="TestChevvyEng", 
                           Transmission="Petrol", 
                           CreatedDate=DateTime.Parse("06/21/2017"),
                           ArchivedDate=null,
                           Dealer = new Dealer { Id = 1, Name = "Dealer1", Email = "dealer1@test.com", Address = "Fitzroy, Melbourne, VIC" }
                        });
            Add(new Car
            {
                Id = 2,
                Year = 2007,
                Make = "Toyota",
                Model = "Toyota Corolla",
                Badge = "ToyotaBadge",
                EngineSize = "TestToyotaEng",
                Transmission = "Petrol",
                CreatedDate = DateTime.Parse("05/17/2017"),
                ArchivedDate = null,
                Dealer = new Dealer { Id = 2, Name = "Dealer1", Email = "dealer1@test.com", Address = "Fitzroy, Melbourne, VIC" }
            });
            Add(new Car {
                Id = 3,
                           Year = 2008, 
                           Make = "BMW", 
                           Model = "BMW i3", 
                           Badge = "BMWBadge", 
                           EngineSize = "TestBMWEng", 
                           Transmission = "Diesel",
                           CreatedDate = DateTime.Today.Date,
                           ArchivedDate = null,
                           Dealer = new Dealer { Id = 2, Name = "Dealer1", Email = "dealer1@test.com", Address = "Fitzroy, Melbourne, VIC" } 
            });
        }

        public IEnumerable<Car> GetAll()
        {
            return cars;
        }

        public Car Get(int id)
        {
            return cars.Find(p => p.Id == id);
        }

        public Car Add(Car item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if(item.Dealer == null)
            {
                throw new ArgumentNullException("Dealer information missing");
            }

            if (!(dealerRepository.GetAll().ToList().Exists(dealer => dealer.Email == item.Dealer.Email)))
            {
                throw new ArgumentNullException("Dealer do not exists");
            }
            //item.CreatedDate = DateTime.Today.Date;
            cars.Add(item);
            return item;
        }

        public void Remove(int carID)
        {
            cars.RemoveAll(p => p.Id == carID);
        }

        public bool Update(Car item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (item.Dealer == null)
            {
                throw new ArgumentNullException("Dealer information missing");
            }

            if (!(dealerRepository.GetAll().ToList().Exists(dealer => dealer.Email == item.Dealer.Email)))
            {
                throw new ArgumentNullException("Dealer do not exists");
            }

            int index = cars.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            cars.RemoveAt(index);
            cars.Add(item);
            return true;
        }

        public IEnumerable<Car> GetCarsByDealer(int id)
        {
            List<Car> listCarByDealer = new List<Car>();
            foreach (Car car in GetAll())
            {
                if (car.Dealer.Id == id)
                {
                    listCarByDealer.Add(car);
                }
            }
            return listCarByDealer;
        }
    }
}