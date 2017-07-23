using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTestProject.Models
{
    interface IDealerRepository
    {
        IEnumerable<Dealer> GetAll();
        Dealer Get(int id);
        Dealer Add(Dealer item);
        void Remove(int id);
        bool Update(Dealer item);
        string GetDealerSummary(int id);
    }
}
