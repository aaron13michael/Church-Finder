using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Church_Finder.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Religion { get; set; }
        public string Sect { get; set; }
        public int Members { get; set; }
    }
}
