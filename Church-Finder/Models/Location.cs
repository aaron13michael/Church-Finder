using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Church_Finder.Models
{
    public partial class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [StringLength(60, MinimumLength = 3), BsonRequired]
        [BsonElement("Name")]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3), BsonRequired]
        [BsonElement("Religion")]
        public string Religion { get; set; }

        [StringLength(60, MinimumLength =3), BsonRequired]
        [BsonElement("Sect")]
        public string Sect { get; set; }

        [Range(0, int.MaxValue), BsonRequired, BsonRepresentation(BsonType.Int32)]
        [BsonElement("Members")]
        public int Members { get; set; }

        [DataType(DataType.Date), BsonRepresentation(BsonType.DateTime)]
        [BsonElement("FoundedDate")]
        [DisplayName("Founded Date")]
        public DateTime FoundedDate { get; set; }

        [Range(0, 24), BsonRepresentation(BsonType.Int32), BsonDefaultValue(1)]
        [BsonElement("NumServices")]
        [DisplayName("Number of Services")]
        public int NumServices { get; set; }

        [DataType(DataType.ImageUrl)]
        [BsonElement("Image")]
        public string Image { get; set; } = "img\\logo.png";


        // Address fields
        [BsonElement("Address1"), DisplayName("Address Line 1"), BsonRequired]
        public string Address1 { get; set; }

        [BsonElement("Address2"), DisplayName("Address line 2")]
        public string Address2 { get; set; }

        [BsonElement("City"), DisplayName("City"), BsonRequired]
        public string City { get; set; }

        [BsonElement("StateProvince"), DisplayName("State/Province"), BsonRequired]
        public string StateProvince { get; set; }


        [BsonElement("Zip"), BsonRequired]
        public string Zip { get; set; }

        //Coordinates
        [BsonElement("Coordinates")]
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Coordinates { get; set; }

        // Services available
        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("Missions")]
        public bool Missions { get; set; } = false;

        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("CommunityGroups"), DisplayName("Community Groups")]
        public bool CommunityGroups { get; set; }

        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("MarriageCounseling"), DisplayName("Marriage Counseling")]
        public bool MarriageCounseling { get; set; }

        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("ChildCare"), DisplayName("Child Care")]
        public bool ChildCare { get; set; }

        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("YouthMinistry"), DisplayName("Youth Ministry")]
        public bool YouthMinistry { get; set; }

        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("YoungAdultMinistry"), DisplayName("Young Adult Ministry")]
        public bool YoungAdultMinistry { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        [BsonElement("OnlineService"), DisplayName("Online Service")]
        [BsonDefaultValue(false)]
        public bool OnlineService { get; set; }
    }
}
