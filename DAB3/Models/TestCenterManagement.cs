using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAB3
{
    class TestCenterManagement
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; }

        [BsonElement("Email")] public string Email { get; set; }
        [BsonElement("PhoneNumber")] public int PhoneNumber { get; set; }
        [BsonElement("TestCenterId")] public int TestCenterId { get; set; }
        [BsonElement("TestCenter")] public TestCenter testcenter { get; set; }

    }
}
