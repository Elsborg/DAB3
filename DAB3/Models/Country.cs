using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB3
{
    class Country
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }

        [BsonElement("CountryName")] public string CountryName { get; set; }
        [BsonElement("CountryId")] public string CountryId { get; set; }
        
    }
}
