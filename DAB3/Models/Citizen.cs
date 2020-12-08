using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB3
{
    class Citizen
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }

        [BsonElement("FirstName")] public string FirstName { get; set; }
        [BsonElement("LastName")] public string LastName { get; set; }
        [BsonElement("SSN")] public string SSN { get; set; }
        [BsonElement("Age")] public int Age { get; set; }
        [BsonElement("Sex")] public string Sex { get; set; }
        [BsonElement("MunicipalityId")] public int MunicipalityId { get; set; }
    }
}
