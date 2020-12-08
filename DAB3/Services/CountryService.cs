using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;


namespace DAB3.Services
{
    class CountryService
    {
        private IMongoCollection<Country> _country;

        public CountryService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("CovidDB");

            _country = database.GetCollection<Country>("Country");
        }


        public List<Country> Get() => _country.Find(Country => true).ToList();

        public Country Get(string countryName) => _country.Find<Country>(country => country.CountryName == countryName).FirstOrDefault();

        public List<Country> GetCountryId(string countryId) => _country.Find(country => country.CountryId == countryId).ToList();

        public Country Create(Country country)
        {
            _country.InsertOne(country);
            return country;
        }

        public void Update(String countryName, Country CountryIn) => _country.ReplaceOne(country => country.CountryName == countryName, CountryIn);

        public void Remove(Country countryIn) => _country.DeleteOne(country => country.CountryName == countryIn.CountryName);

        public void Remove(string countryName) => _country.DeleteOne(country => country.CountryName == countryName);

    }
}
