using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Church_Finder.Models
{
    public class LocationReligionViewModel
    {
        public List<Location> Locations { get; set; }
        public SelectList Religions { get; set; }
        public string LocationReligion { get; set;}
        public string SearchString { get; set; }

        [Display(Name= "Number of Members")]
        public string NoMembers { get; set; }

        public string Name { get; set; }

        public bool Missions { get; set; }

        [Display(Name="Child Care")]
        public bool ChildCare { get; set; }

        [Display(Name="Online Service")]
        public bool OnlineService { get; set; }

        [Display(Name="Community Groups", Description="Clubs, Small Groups, Weekly/Monthly gatherings, etc.")]
        public bool CommunityGroups { get; set; }

        [Display(Name="Youth Programs")]
        public bool YouthMinistry { get; set; }

        [Display(Name="Marriage Counseling")]
        public bool MarriageCounseling { get; set; }

        [Display(Name="Youth Adult Programs")]
        public bool YAMinistry { get; set; }

    }
}
