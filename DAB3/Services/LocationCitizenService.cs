using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace DAB3.Services
{
    class LocationCitizenService
    {
        private IMongoCollection<LocationCitizen> _locationcitizen;

        public LocationCitizenService()
        {
            var client = new MongoClient("mongodb://localhost27017");
            var database = client.GetDatabase("CovidDB");

            _locationcitizen = database.GetCollection<LocationCitizen>("LocationCitizen");
        }


        public List<LocationCitizen> Get() => _locationcitizen.Find(LocationCitizen => true).ToList();

        public LocationCitizen GetSSN(string ssN) => _locationcitizen.Find<LocationCitizen>(LocationCitizen => LocationCitizen.SSN == ssN).FirstOrDefault();

        public List<LocationCitizen> GetSocialNumber(string ssN) => _locationcitizen.Find<LocationCitizen>(LocationCitizen => LocationCitizen.SSN == ssN).ToList();

        public LocationCitizen GetAddress(string address) => _locationcitizen.Find<LocationCitizen>(LocationCitizen => LocationCitizen.Address == address).FirstOrDefault();

        public List<LocationCitizen> GetAddr(string address) => _locationcitizen.Find<LocationCitizen>(LocationCitizen => LocationCitizen.Address == address).ToList();

        public LocationCitizen GetCitizen(Citizen citizen) =>
           _locationcitizen.Find<LocationCitizen>(Locationcitizen => Locationcitizen.citizen == citizen).FirstOrDefault();

        public LocationCitizen GetLocation(Location location) =>
           _locationcitizen.Find<LocationCitizen>(Locationcitizen => Locationcitizen.location == location).FirstOrDefault();

        public LocationCitizen GetDate(string date) =>
           _locationcitizen.Find<LocationCitizen>(Locationcitizen => Locationcitizen.date == date).FirstOrDefault();


        //CRUD operations
        public LocationCitizen Create(LocationCitizen locationCitizen)
        {
            _locationcitizen.InsertOne(locationCitizen);
            return locationCitizen;
        }

        public void Update(String ssn, LocationCitizen locationCitizenIn) =>
            _locationcitizen.ReplaceOne(locationcitizen => locationcitizen.SSN == ssn, locationCitizenIn);

        public void Remove(LocationCitizen locationCitizenIn) =>
            _locationcitizen.DeleteOne(locationcitizen => locationcitizen.SSN == locationCitizenIn.SSN);

        public void Remove(string ssn) =>
           _locationcitizen.DeleteOne(locationcitizen => locationcitizen.SSN == ssn);



    }

    
}
