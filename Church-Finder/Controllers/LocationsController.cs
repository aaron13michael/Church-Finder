using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Church_Finder.Models;
using Church_Finder.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Church_Finder.Controllers
{
    public class LocationsController : Controller
    {
        private readonly LocationService _service;

        public LocationsController(LocationService locationService)
        {
            _service = locationService;
        }

        // GET: Locations
        public async Task<IActionResult> Index(string LocationReligion, string searchString)
        {
            ViewBag.SearchHeader = string.IsNullOrEmpty(searchString) ? "Results" : $"Results for {searchString}";
            ViewBag.Religions = new SelectList(_service.getReligionsList());
            return View(await _service.GetSearchResults(LocationReligion, searchString));
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _service.GetAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Religion,Sect,Members,FoundedDate,NumServices,Address1,Address2,City,StateProvince,Zip,Image,Missions,CommunityGroups,MarriageCounseling,ChildCare,YouthMinistry,YoungAdultMinistry,OnlineService")] Location location, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                UploadImage(location, image);
            }
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(location);
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _service.GetAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Religion,Sect,Members,FoundedDate,NumServices,Address1,Address2,City,StateProvince,Zip,Missions,CommunityGroups,MarriageCounseling,ChildCare,YouthMinistry,YoungAdultMinistry,OnlineService")] Location location, IFormFile image)
        {
            if (id != location.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if(image != null && image.Length > 0)
                {
                    UploadImage(location, image);
                }
                try
                {
                    _service.Update(id, location);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.LocationExists(location.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _service.GetAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var location = await _service.GetAsync(id);
            _service.Remove(location);
            return RedirectToAction(nameof(Index));
        }

        private async void UploadImage(Location location, IFormFile image)
        {
            string uploadTo = Path.Combine(_service._imgUploads, "img");
            if (image.Length > 0)
            {
                var filename = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                Console.WriteLine(filename); //debug

                using (var filestream = new FileStream(Path.Combine(uploadTo, filename), FileMode.Create))
                {
                    await image.CopyToAsync(filestream);
                    location.Image = Path.Combine("img", filename);
                }
            }
        }
    }
}
