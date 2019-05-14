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

        [StringLength(60, MinimumLength =3)]
        [BsonRequired]
        [BsonElement("Name")]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [BsonRequired]
        [BsonElement("Religion")]
        public string Religion { get; set; }

        [StringLength(60, MinimumLength =3)]
        [BsonRequired]
        [BsonElement("Sect")]
        public string Sect { get; set; }

        [BsonElement("Members")]
        [Range(0, int.MaxValue)]
        [BsonRequired]
        [BsonRepresentation(BsonType.Int32)]
        public int Members { get; set; }

        [BsonElement("FoundedDate")]
        [BsonRepresentation(BsonType.DateTime)]
        [DataType(DataType.Date)]
        public DateTime FoundedDate { get; set; }

        [BsonElement("NumServices")]
        [Range(0, 24)]
        [BsonRepresentation(BsonType.Int32)]
        [BsonDefaultValue(1)]
        public int NumServices { get; set; }


        // Address fields
        [BsonElement("Address1")]
        [BsonRequired]
        public string Address1 { get; set; }

        [BsonElement("Address2")]
        public string Address2 { get; set; }

        [BsonElement("City")]
        [BsonRequired]
        public string City { get; set; }

        [BsonElement("StateProvince")]
        [BsonRequired]
        public string StateProvince { get; set; }

        [BsonElement("Zip")]
        [BsonRequired]
        public string Zip { get; set; }

        // Services available
        [BsonElement("Missions")]
        [BsonRepresentation(BsonType.Boolean)]
        [BsonDefaultValue(false)]
        public bool Missions { get; set; }

        [BsonElement("CommunityGroups")]
        [BsonRepresentation(BsonType.Boolean)]
        [BsonDefaultValue(false)]
        public bool CommunityGroups { get; set; }

        [BsonElement("MarriageCounseling")]
        [BsonRepresentation(BsonType.Boolean)]
        [BsonDefaultValue(false)]
        public bool MarriageCounseling { get; set; }

        [BsonElement("ChildCare")]
        [BsonRepresentation(BsonType.Boolean)]
        [BsonDefaultValue(false)]
        public bool ChildCare { get; set; }

        [BsonElement("YouthMinistry")]
        [BsonRepresentation(BsonType.Boolean)]
        [BsonDefaultValue(false)]
        public bool YouthMinistry { get; set; }

        [BsonElement("YoungAdultMinistry")]
        [BsonRepresentation(BsonType.Boolean)]
        [BsonDefaultValue(false)]
        public bool YoungAdultMinistry { get; set; }

        [BsonElement("OnlineService")]
        [BsonRepresentation(BsonType.Boolean)]
        [BsonDefaultValue(false)]
        public bool OnlineService { get; set; }
    }
}
