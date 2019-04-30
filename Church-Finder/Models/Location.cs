using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Church_Finder.Models
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Religion")]
        public string Religion { get; set; }
        [BsonElement("Sect")]
        public string Sect { get; set; }
        [BsonElement("Members")]
        [BsonRepresentation(BsonType.Int32)]
        public int Members { get; set; }
        [BsonElement("FoundedDT")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime FoundedDate { get; set; }
        [BsonElement("NumServices")]
        [BsonRepresentation(BsonType.Int32)]
        public int NumServices { get; set; }

        // Address fields
        [BsonElement("Address1")]
        public string Address1 { get; set; }
        [BsonElement("Address2")]
        public string Address2 { get; set; }
        [BsonElement("City")]
        public string City { get; set; }
        [BsonElement("StateProvince")]
        public string StateProvince { get; set; }
        [BsonElement("Zip")]
        public string Zip { get; set; }

        // Services available
        [BsonElement("Missions")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Missions { get; set; }

        [BsonElement("CommunityGroups")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool CommunityGroups { get; set; }

        [BsonElement("MarriageCounseling")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool MarriageCounseling { get; set; }

        [BsonElement("Childcare")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool ChildCare { get; set; }

        [BsonElement("YouthMinistry")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool YouthMinistry { get; set; }

        [BsonElement("YoungAdultMinistry")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool YoungAdultMinistry { get; set; }

        [BsonElement("OnlineService")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool OnlineService { get; set; }
    }
}
