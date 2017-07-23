using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace WebApiTestProject.Models
{
    public class DealerRepository : IDealerRepository
    {
        private List<Dealer> dealer = new List<Dealer>();
        static readonly ICarRepository repository = new CarRepository();

        public DealerRepository()
        {
            Add(new Dealer { Id = 1, Name = "Dealer1", Email = "dealer1@test.com", Address = "Fitzroy, Melbourne, VIC" } );
            Add(new Dealer { Id = 2, Name = "Dealer2", Email = "dealer2@test.com", Address = "Toorak, Melbourne, VIC" } );
            Add(new Dealer { Id = 3, Name = "Dealer1", Email = "dealer1@test.com", Address = "Fitzroy, Melbourne, VIC" } );
        }
        public IEnumerable<Dealer> GetAll()
        {
            return dealer;
        }

        public Dealer Get(int id)
        {
            return dealer.Find(p => p.Id == id);
        }

        public Dealer Add(Dealer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            dealer.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            dealer.RemoveAll(p => p.Id == id);
        }

        public bool Update(Dealer item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = dealer.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            dealer.RemoveAt(index);
            dealer.Add(item);
            return true;
        }

        public string GetDealerSummary(int dealerID)
        {
            int delta = DayOfWeek.Monday - DateTime.Today.DayOfWeek;
            DateTime monday = DateTime.Today.AddDays(delta);

            StringBuilder summary = new StringBuilder();
            summary.Append(GetStockCreatedToday());
            summary.Append(GetStockCreatedThisWeek());
            summary.Append(GetStockCreatedThisMonth());

            summary.Append(GetStockCreatedToday());
            summary.Append(GetStockCreatedThisWeek());
            summary.Append(GetStockCreatedThisMonth());

            return summary.ToString();
        }

        private string GetStockCreatedToday()
        {
            var submitCount = from car in repository.GetAll()
                              where ((car.CreatedDate == DateTime.Today.Date) && (!car.ArchivedDate.HasValue))
                              select car;

            StringBuilder buildToday = new StringBuilder();
            buildToday.Append("----------------------Created Today--------------------------");
            buildToday.AppendLine();
            buildToday.Append("Year     || Make        || Model     || Badge    || EngineSize   || Transmission");
            foreach (Car car in submitCount.ToList())
            {
                buildToday.AppendLine();
                buildToday.AppendFormat("{0}    || {1}  || {2}  || {3}  || {4}  || {5}", car.Year, car.Make, car.Model, car.Badge, car.EngineSize, car.Transmission);
            }
            buildToday.AppendLine();
            buildToday.Append("-----------------------------------------------------");
            buildToday.AppendLine();
            return buildToday.ToString();
        }

        private string GetStockCreatedThisWeek()
        {
            DateTime currentDate = DateTime.Today;
            var thisWeekStart = currentDate.AddDays(-(int)currentDate.DayOfWeek);
            var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);

            var submitCount = from car in repository.GetAll()
                              where ((!car.ArchivedDate.HasValue) && (car.CreatedDate.Date >= thisWeekStart.Date && car.CreatedDate.Date <= thisWeekEnd.Date))
                              select car;

            StringBuilder buildWeek = new StringBuilder();
            buildWeek.Append("----------------------Created this Week--------------------------");
            buildWeek.AppendLine();
            buildWeek.Append("Year     || Make        || Model     || Badge    || EngineSize   || Transmission");
            foreach (Car car in submitCount.ToList())
            {
                buildWeek.AppendLine();
                buildWeek.AppendFormat("{0}    || {1}  || {2}  || {3}  || {4}  || {5}", car.Year, car.Make, car.Model, car.Badge, car.EngineSize, car.Transmission);
            }
            buildWeek.AppendLine();
            buildWeek.Append("-----------------------------------------------------");
            buildWeek.AppendLine();
            return buildWeek.ToString();
        }

        private string GetStockCreatedThisMonth()
        {
            DateTime currentDate = DateTime.Today;

            var thisMonthStart = currentDate.AddDays(1 - currentDate.Day);
            var thisMonthEnd = thisMonthStart.AddMonths(1).AddSeconds(-1);

            var submitCount = from car in repository.GetAll()
                              where ((!car.ArchivedDate.HasValue) && (car.CreatedDate.Date >= thisMonthStart.Date && car.CreatedDate <= thisMonthEnd.Date))
                              select car;

            StringBuilder buildWeek = new StringBuilder();
            buildWeek.Append("----------------------Created this Month--------------------------");
            buildWeek.AppendLine();
            buildWeek.Append("Year     || Make        || Model     || Badge    || EngineSize   || Transmission");
            foreach (Car car in submitCount.ToList())
            {
                buildWeek.AppendLine();
                buildWeek.AppendFormat("{0}    || {1}  || {2}  || {3}  || {4}  || {5}", car.Year, car.Make, car.Model, car.Badge, car.EngineSize, car.Transmission);
            }
            buildWeek.AppendLine();
            buildWeek.Append("-----------------------------------------------------");
            buildWeek.AppendLine();
            return buildWeek.ToString();
        }

        private string GetStockArchivedToday()
        {
            var submitCount = from car in repository.GetAll()
                              where ((car.ArchivedDate.HasValue) && (car.ArchivedDate.Value == DateTime.Today.Date))
                              select car;

            StringBuilder buildToday = new StringBuilder();
            buildToday.Append("----------------------Archived Today--------------------------");
            buildToday.AppendLine();
            buildToday.Append("Year     || Make        || Model     || Badge    || EngineSize   || Transmission");
            foreach (Car car in submitCount.ToList())
            {
                buildToday.AppendLine();
                buildToday.AppendFormat("{0}    || {1}  || {2}  || {3}  || {4}  || {5}", car.Year, car.Make, car.Model, car.Badge, car.EngineSize, car.Transmission);
            }
            buildToday.AppendLine();
            buildToday.Append("-----------------------------------------------------");
            buildToday.AppendLine();
            return buildToday.ToString();
        }

        private string GetStockArchivedThisWeek()
        {
            DateTime currentDate = DateTime.Today;
            var thisWeekStart = currentDate.AddDays(-(int)currentDate.DayOfWeek);
            var thisWeekEnd = thisWeekStart.AddDays(7).AddSeconds(-1);

            var submitCount = from car in repository.GetAll()
                              where ((car.ArchivedDate.HasValue) &&
                              (car.ArchivedDate.Value.Date >= thisWeekStart.Date && car.ArchivedDate.Value.Date <= thisWeekEnd.Date))
                              select car;

            StringBuilder buildWeek = new StringBuilder();
            buildWeek.Append("----------------------Archived this Week--------------------------");
            buildWeek.AppendLine();
            buildWeek.Append("Year     || Make        || Model     || Badge    || EngineSize   || Transmission");
            foreach (Car car in submitCount.ToList())
            {
                buildWeek.AppendLine();
                buildWeek.AppendFormat("{0}    || {1}  || {2}  || {3}  || {4}  || {5}", car.Year, car.Make, car.Model, car.Badge, car.EngineSize, car.Transmission);
            }
            buildWeek.AppendLine();
            buildWeek.Append("-----------------------------------------------------");
            buildWeek.AppendLine();
            return buildWeek.ToString();
        }

        private string GetStockArchivedThisMonth()
        {
            DateTime currentDate = DateTime.Today;

            var thisMonthStart = currentDate.AddDays(1 - currentDate.Day);
            var thisMonthEnd = thisMonthStart.AddMonths(1).AddSeconds(-1);

            var submitCount = from car in repository.GetAll()
                              where ((car.ArchivedDate.HasValue) &&
                              (car.ArchivedDate.Value.Date >= thisMonthStart.Date && car.ArchivedDate.Value.Date <= thisMonthEnd.Date))
                              select car;

            StringBuilder buildWeek = new StringBuilder();
            buildWeek.Append("---------------------- Archived this Month--------------------------");
            buildWeek.AppendLine();
            buildWeek.Append("Year     || Make        || Model     || Badge    || EngineSize   || Transmission");
            foreach (Car car in submitCount.ToList())
            {
                buildWeek.AppendLine();
                buildWeek.AppendFormat("{0}    || {1}  || {2}  || {3}  || {4}  || {5}", car.Year, car.Make, car.Model, car.Badge, car.EngineSize, car.Transmission);
            }
            buildWeek.AppendLine();
            buildWeek.Append("-----------------------------------------------------");
            buildWeek.AppendLine();
            return buildWeek.ToString();
        }
    }
}