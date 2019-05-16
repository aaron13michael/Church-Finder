using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Church_Finder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public async Task<LocationReligionViewModel> GetSearchResults(string religion, string searchString)
        {
            var builder = Builders<Location>.Filter;
            var filter = builder.Empty;
            if (!string.IsNullOrEmpty(searchString))
            {
                filter = builder.Where(l => l.Name.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(religion))
            {
                filter = filter & builder.Eq("Religion", religion);
            }
            var locationReligionVM = new LocationReligionViewModel
            {
                Religions = new SelectList(getReligionsList()),
                Locations = await _locations.Find(filter).ToListAsync()
            };
            return locationReligionVM;
        }

        public async Task<List<Location>> GetAsync()
        {
            return await _locations.Find(location => true).ToListAsync();
        }

        public async Task<Location> GetAsync(string id)
        {
            return await _locations.Find(location => location.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Location> CreateAsync(Location location)
        {
            await _locations.InsertOneAsync(location);
            return location;
        }

        public async void Update(string id, Location locationIn)
        {
            await _locations.ReplaceOneAsync(location => location.Id == id, locationIn);
        }

        public async void Remove(Location locationIn)
        {
            await _locations.DeleteOneAsync(location => location.Id == locationIn.Id);
        }

        public async void Remove(string id)
        {
            await _locations.DeleteOneAsync(location => location.Id == id);
        }
        public bool LocationExists(string id)
        {
            return _locations.CountDocuments(Location => Location.Id == id) > 0;
        }
        public List<string> getReligionsList()
        {
            var relQuery = from l in _locations.Find(l => true).ToEnumerable()
                           orderby l.Religion
                           select l.Religion;
            return relQuery.Distinct().ToList();
        }
    }
}
