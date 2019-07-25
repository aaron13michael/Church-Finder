using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Church_Finder.Models;
using GoogleMaps.LocationServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Church_Finder.Services
{
    public class LocationService
    {
        private readonly IMongoCollection<Location> _locations;
        public readonly string _imgUploads;

        public LocationService(IConfiguration config, IHostingEnvironment env)
        {
            var client = new MongoClient(config.GetConnectionString("ChurchFinderDB"));
            var database = client.GetDatabase("ChurchFinderDB");
            _locations = database.GetCollection<Location>("Locations");
            _imgUploads = env.WebRootPath;
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
            AddressData address = new AddressData
            {
                Address = location.Address1,
                City = location.City,
                State = location.StateProvince,
                Country = "United States",
                Zip = location.Zip
            };
            try
            {
                string apikey = System.Environment.GetEnvironmentVariable("GEO_API_KEY");
                var gls = new GoogleLocationService(apikey);
                MapPoint coordinates = gls.GetLatLongFromAddress(address);
                var geoJsonCoordinates = new GeoJson2DGeographicCoordinates(coordinates.Longitude, coordinates.Latitude);
                location.Coordinates = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(geoJsonCoordinates);
            }
            catch(System.Net.WebException ex)
            {
                Console.WriteLine("Error getting coordinates {0}", ex.Message);
            }
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
