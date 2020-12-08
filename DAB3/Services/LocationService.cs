using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace DAB3.Services
{
    class LocationService
    {
        private IMongoCollection<Location> _location;

        public LocationService()
        {
            var client = new MongoClient("mongodb://localhost27017");
            var database = client.GetDatabase("CovidDB");

            _location = database.GetCollection<Location>("Location");
        }

        public List<Location> Get() => _location.Find(Location => true).ToList();

        public Location GetAddress(string address) =>
            _location.Find<Location>(Location => Location.Address == address).FirstOrDefault();

        public Location GetRandomLocation(int counter) => _location.Find(Location => true).Limit(-1).Skip(counter).FirstOrDefault();

        //CRUD operations
        public Location Create(Location location)
        {
            _location.InsertOne(location);
            return location;
        }

        public void Update(String address, Location locationIn) => _location.ReplaceOne(location => location.Address == address, locationIn);

        public void Remove(Location locationIn) => _location.DeleteOne(location => location.Address == locationIn.Address);

        public void Remove(string address) => _location.DeleteOne(location => location.Address == address);
    }
}
