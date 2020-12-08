using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace DAB3.Services
{
    class MunicipalityService
    {
        private IMongoCollection<Municipality> _municipality;

        public MunicipalityService()
        {
            var client = new MongoClient("mongodb://localhost:27017"); // Indsæt navn her
            var database = client.GetDatabase("CovidDB");

            _municipality = database.GetCollection<Municipality>("Municipality");
        }

        public List<Municipality> Get() => _municipality.Find(Municipality => true).ToList();

        public Municipality Get(int municipalityId) => _municipality.Find<Municipality>(municipality => municipality.MunicipalityId == municipalityId).FirstOrDefault();

        public List<Municipality> GetName(string name) => _municipality.Find(municipality => municipality.Name == name).ToList();

        public List<Municipality> GetPopulation(int population) => _municipality.Find(municipality => municipality.Population == population).ToList();

        public Municipality GetCountry(string countryName) => _municipality.Find(municipality => municipality.CountryName == countryName).FirstOrDefault();

        public Municipality Create(Municipality municipality)
        {
            _municipality.InsertOne(municipality);
            return municipality;
        }

        public void Update(int municipalityId, Municipality municipalityIn) => _municipality.ReplaceOne(municipality => municipality.MunicipalityId == municipalityId, municipalityIn);

        public void Remove(Municipality municipalityIn) => _municipality.DeleteOne(municipality => municipality.MunicipalityId == municipalityIn.MunicipalityId);

        public void Remove(int municipalityId) => _municipality.DeleteOne(municipality => municipality.MunicipalityId == municipalityId);






    }
}
