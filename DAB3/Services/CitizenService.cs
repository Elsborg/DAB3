using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace DAB3
{
    class CitizenService
    {
        private IMongoCollection<Citizen> _citizen;

        public CitizenService()
        {
            var client = new MongoClient("mongodb://localhost:27017"); 
            var database = client.GetDatabase("CovidDB");

            _citizen = database.GetCollection<Citizen>("Citizen");
        }

        public List<Citizen> Get() => _citizen.Find(Citizen => true).ToList();

        public Citizen Get(string ssn) => _citizen.Find<Citizen>(Citizen => Citizen.SSN == ssn).FirstOrDefault();

        public List<Citizen> GetFirstName(string firstname) => _citizen.Find(Citizen => Citizen.FirstName == firstname).ToList();

        public List<Citizen> GetLastName(string lastname) => _citizen.Find(Citizen => Citizen.LastName == lastname).ToList();

        public List<Citizen> GetSex(string sex) => _citizen.Find(Citizen => Citizen.Sex == sex).ToList();

        public List<Citizen> GetAge(int age) => _citizen.Find(Citizen => Citizen.Age == age).ToList();

        public Citizen GetRandomCitizen(int counter) => _citizen.Find(Citizen => true).Limit(-1).Skip(counter).FirstOrDefault();

        //CRUD operations
        public Citizen Create(Citizen citizen)
        {
            _citizen.InsertOne(citizen);
                return citizen;
        }

        public void Update(String ssn, Citizen citizenIn) => _citizen.ReplaceOne(citizen => citizen.SSN == ssn, citizenIn);

        public void Remove(Citizen citizenIn) => _citizen.DeleteOne(citizen => citizen.SSN == citizenIn.SSN);

        public void Remove(string ssn) => _citizen.DeleteOne(citizen => citizen.SSN == citizen.SSN);










    }
}
