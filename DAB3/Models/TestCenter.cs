using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB3
{
    class TestCenter
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }

        [BsonElement("TestCenterId")] public int TestCenterId { get; set; }
        [BsonElement("OpenHours")] public string OpenHours { get; set; }
        [BsonElement("MunicipalityId")] public int MunicipalityId { get; set; }
        
    }
}
