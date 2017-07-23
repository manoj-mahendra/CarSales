using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTestProject.Models
{
    public class CarSearchOption
    {
        public string Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Badge { get; set; }
        public string Transmission { get; set; }
        public string EngineSize { get; set; }
        //public OrderByOptions OrderBy { get; set; }
        //public List<int> Cars { get; set; }
       // public List<int> Dealers { get; set; }
    }
}