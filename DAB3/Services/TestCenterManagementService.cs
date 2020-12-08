using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace DAB3.Services
{
    class TestCenterManagementService
    {
        private IMongoCollection<TestCenterManagement> _testcentermanagement;

        public TestCenterManagementService()
        {
            var client = new MongoClient("mongodb://localhost:27017"); 
            var database = client.GetDatabase("CovidDB");

            _testcentermanagement = database.GetCollection<TestCenterManagement>("TestCenterManagement");
        }

        public List<TestCenterManagement> Get() => _testcentermanagement.Find(TestCentermanagement => true).ToList();

        public TestCenterManagement GetPhoneNumber(int phoneNumber) => _testcentermanagement.Find<TestCenterManagement>(testCenterManagement => testCenterManagement.PhoneNumber == phoneNumber).FirstOrDefault();

        public TestCenterManagement Get(string email) => _testcentermanagement.Find(testcentermanagement => testcentermanagement.Email == email).FirstOrDefault();

        public TestCenterManagement GetTestCenterId(int testCenterId) => _testcentermanagement.Find(testcentermanagement => testcentermanagement.TestCenterId == testCenterId).FirstOrDefault();


        //CRUD operations
        public TestCenterManagement Create(TestCenterManagement testCenterManagement)
        {
            _testcentermanagement.InsertOne(testCenterManagement);
            return testCenterManagement;
        }

        public void Update(int phoneNumber, TestCenterManagement testCenterManagementIn) => _testcentermanagement.ReplaceOne(testcentermanagement => testcentermanagement.PhoneNumber == phoneNumber, testCenterManagementIn);

        public void Remove(TestCenterManagement testCenterManagementIn) => _testcentermanagement.DeleteOne(testcentermanagement => testcentermanagement.PhoneNumber == testCenterManagementIn.PhoneNumber);

        public void Remove(int phoneNumber) => _testcentermanagement.DeleteOne(testcentermanagement => testcentermanagement.PhoneNumber == phoneNumber);

        
       


    }
}
