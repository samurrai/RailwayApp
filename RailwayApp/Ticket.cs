using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayApp
{
    public class Ticket : Entity
    {
        public City CityFrom { get; set; }
        public City CityTo { get; set; }
        public DateTime Date { get; set; }
    }
}
