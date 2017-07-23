using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTestProject.Models
{
    public class Dealer
    {
        public int Id { get; set; }
        //mandatory
        public string Name { get; set; }

        //mandatory
        public string Email { get; set; }

        public string Address { get; set; }

    }
}