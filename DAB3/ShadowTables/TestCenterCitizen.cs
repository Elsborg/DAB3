using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB3
{
    class TestCenterCitizen
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }

        [BsonElement("SSN")] public string SSN { get; set; }
        [BsonElement("TestCenterId")] public int TestCenterId { get; set; }
        [BsonElement("Citizen")] public Citizen citizen { get; set; }
        [BsonElement("TestCenter")] public TestCenter testCenter { get; set; }
        [BsonElement("Result")] public bool Result { get; set; }
        [BsonElement("Status")] public string Status { get; set; }
        [BsonElement("Date")] public string Date { get; set; }
    }
}
