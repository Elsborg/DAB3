using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;


namespace DAB3
{
    class LocationCitizen
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }

        [BsonElement("SSN")] public string SSN { get; set; }
        [BsonElement("Address")] public string Address { get; set; }
        [BsonElement("Citizen")] public Citizen citizen { get; set; }
        [BsonElement("Location")] public Location location { get; set; }
        [BsonElement("date")] public string date { get; set; }

    }
}
