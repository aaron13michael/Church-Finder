using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Church_Finder.Models
{
    public class Location
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
        public DateTime FoundedDate { get; set; }

        [Range(0, 24), BsonRepresentation(BsonType.Int32), BsonDefaultValue(1)]
        [BsonElement("NumServices")]
        public int NumServices { get; set; }


        // Address fields
        [BsonElement("Address1"), BsonRequired]
        public string Address1 { get; set; }

        [BsonElement("Address2"), BsonRequired]
        public string Address2 { get; set; }

        [BsonElement("City"), BsonRequired]
        public string City { get; set; }

        [BsonElement("StateProvince"), BsonRequired]
        public string StateProvince { get; set; }

        [BsonElement("Zip"), BsonRequired]
        public string Zip { get; set; }

        // Services available
        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("Missions")]
        public bool Missions { get; set; }

        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("CommunityGroups")]
        public bool CommunityGroups { get; set; }

        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("MarriageCounseling")]
        public bool MarriageCounseling { get; set; }

        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("ChildCare")]
        public bool ChildCare { get; set; }

        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("YouthMinistry")]
        public bool YouthMinistry { get; set; }

        [BsonRepresentation(BsonType.Boolean), BsonDefaultValue(false)]
        [BsonElement("YoungAdultMinistry")]
        public bool YoungAdultMinistry { get; set; }

        [BsonElement("OnlineService")]
        [BsonRepresentation(BsonType.Boolean)]
        [BsonDefaultValue(false)]
        public bool OnlineService { get; set; }
    }
}
