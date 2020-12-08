using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace DAB3.Services
{
    class TestCenterCitizenService
    {
        private IMongoCollection<TestCenterCitizen> _testcentercitizen;

        public TestCenterCitizenService()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // Indsæt navn her
            var database = client.GetDatabase("CovidDB");

            _testcentercitizen = database.GetCollection<TestCenterCitizen>("TestCenterCitizen");
        }

        public List<TestCenterCitizen> Get() => _testcentercitizen.Find(TestCenterCitizen => true).ToList();

        public TestCenterCitizen GetSSN(string ssn) => _testcentercitizen.Find<TestCenterCitizen>(testCenterCitizen => testCenterCitizen.SSN == ssn).FirstOrDefault();

        public TestCenterCitizen GetOpenHours(int testCenterId) => _testcentercitizen.Find(testcentercitizen => testcentercitizen.TestCenterId == testCenterId).FirstOrDefault();

        public List<TestCenterCitizen> GetCitizen(Citizen citizen) => _testcentercitizen.Find(testcentercitizen => testcentercitizen.citizen == citizen).ToList();

        public List<TestCenterCitizen> GetTestCenter(TestCenter testcenter) => _testcentercitizen.Find(testcentercitizen => testcentercitizen.testCenter == testcenter).ToList();

        public TestCenterCitizen GetResult(bool result) => _testcentercitizen.Find(testcentercitizen => testcentercitizen.Result == result).FirstOrDefault();

        public TestCenterCitizen GetStatus(string status) => _testcentercitizen.Find(testcentercitizen => testcentercitizen.Status == status).FirstOrDefault();

        public TestCenterCitizen GetDate(string date) => _testcentercitizen.Find(testcentercitizen => testcentercitizen.Date == date).FirstOrDefault();


        public TestCenterCitizen Create(TestCenterCitizen testCenterCitizen)
        {
            _testcentercitizen.InsertOne(testCenterCitizen);
            return testCenterCitizen;
        }

        public void Update(string ssn, TestCenterCitizen testCenterCitizenIn) => _testcentercitizen.ReplaceOne(testcentercitizen => testcentercitizen.SSN == ssn, testCenterCitizenIn);

        public void Remove(TestCenterCitizen testCenterCitizenIn) => _testcentercitizen.DeleteOne(testcentercitizen => testcentercitizen.SSN == testCenterCitizenIn.SSN);

        public void Remove(string ssn) => _testcentercitizen.DeleteOne(testcentercitizen => testcentercitizen.SSN == ssn);


    }
}
