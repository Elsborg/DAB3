using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB3
{
    class Location
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }

        [BsonElement("Address")] public string Address { get; set; }
        [BsonElement("MunicipalityId")] public int MunicipalityId { get; set; }

    }
}
