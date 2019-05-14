using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Church_Finder.Models
{
    public class LocationReligionViewModel
    {
        public List<Location> Locations { get; set; }
        public SelectList Religions { get; set; }
        public string LocationReligion { get; set;}
        public string SearchString { get; set; }
    }
}
