using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTestProject.Models
{
    public class Car
    {
        public int Id { get; set; }
        //mandatory
        public int Year { get; set; }

        //mandatory
        public string Make { get; set; }

        //mandatory
        public string Model { get; set; }

        public string Badge { get; set; }

        public string EngineSize { get; set; }

        //mandatory
        public string Transmission { get; set; }

        //mandatory
        public Dealer Dealer { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ArchivedDate { get; set; }
    }

}