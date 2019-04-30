using System.Collections.Generic;
using System.Threading.Tasks;
using Church_Finder.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Church_Finder.Services
{
    public class LocationService
    {
        private readonly IMongoCollection<Location> _locations;

        public LocationService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ChurchFinderDB"));
            var database = client.GetDatabase("ChurchFinderDB");
            _locations = database.GetCollection<Location>("Locations");
        }

        public async Task<List<Location>> GetAsync()
        {
            return await _locations.Find(location => true).ToListAsync();
        }

        public async Task<Location> GetAsync(string id)
        {
            return await _locations.Find(location => location.Id == id).FirstOrDefaultAsync();
        }

        public Location Create(Location location)
        {
            _locations.InsertOne(location);
            return location;
        }

        public void Update(string id, Location locationIn)
        {
            _locations.ReplaceOne(location => location.Id == id, locationIn);
        }

        public void Remove(Location locationIn)
        {
            _locations.DeleteOne(location => location.Id == locationIn.Id);
        }

        public void Remove(string id)
        {
            _locations.DeleteOne(location => location.Id == id);
        }
    }
}
