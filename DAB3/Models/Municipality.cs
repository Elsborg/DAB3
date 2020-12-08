using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB3
{
    class Municipality
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }

        [BsonElement("MunicipalityId")] public int MunicipalityId { get; set; }
        [BsonElement("Name")] public string Name { get; set; }
        [BsonElement("CountryName")] public string CountryName { get; set; }
        [BsonElement("Population")] public float Population { get; set; }
    }
}
