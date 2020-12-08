using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace DAB3.Services
{
    class TestCenterService
    {
        private IMongoCollection<TestCenter> _testcenter;

        public TestCenterService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("CovidDB");

            _testcenter = database.GetCollection<TestCenter>("TestCenter");
        }

        public List<TestCenter> Get() =>
            _testcenter.Find(TestCenter => true).ToList();

        public TestCenter Get(int testCenterId) =>
            _testcenter.Find<TestCenter>(testCenter => testCenter.TestCenterId == testCenterId).FirstOrDefault();

        public List<TestCenter> GetOpenHours(string hours) =>
            _testcenter.Find(testcenter => testcenter.OpenHours == hours).ToList();

        public TestCenter GetMunicipalityId(int municipalityId) =>
            _testcenter.Find(testcenter => testcenter.MunicipalityId == municipalityId).FirstOrDefault();

        public TestCenter GetRandomTestCenter(int counter) =>
            _testcenter.Find(TestCenter => true).Limit(-1).Skip(counter).FirstOrDefault();

        public TestCenter Create(TestCenter testCenter)
        {
            _testcenter.InsertOne(testCenter);
            return testCenter;
        }

        public void Update(int testCenterId, TestCenter testCenterIn) =>
            _testcenter.ReplaceOne(testcenter => testcenter.TestCenterId == testCenterId, testCenterIn);

        public void Remove(TestCenter testCenterId) =>
            _testcenter.DeleteOne(testcenter => testcenter.TestCenterId == testCenterId.TestCenterId);

        public void Remove(int testCenterId) =>
            _testcenter.DeleteOne(testcenter => testcenter.TestCenterId == testCenterId);
    }
}
