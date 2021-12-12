using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TermProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Data;
using System;
using System.Threading.Tasks;

namespace MovieList.Controllers
{
    public class RideController : Controller
    {
        private RideContext context { get; set; }

        public RideController(RideContext ctx)
        {
            context = ctx;
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            //var rides = context.Rides.OrderBy(r => r.Name).ToList();
            var rides = from r in context.Rides.Include(r => r.Difficulty).OrderBy(r => r.DifficultyId) select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                rides = rides.Where(s => s.Name.Contains(searchString) || s.Description.Contains(searchString));
            }
            

            switch (sortOrder)
            {
                case "name_desc":
                    rides = rides.OrderByDescending(d => d.Name);
                    break;
                default:
                    rides = rides.OrderBy(d => d.Name);
                    break;
            }

            int pageSize = 3;

            return View(await PaginatedList<Ride>.CreateAsync(rides.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ride = await context.Rides
        //        .Include(r => r.Difficulty);
        //    if (ride == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ride);
        //}

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Difficulties = context.Difficulties.OrderBy(r => r.DifficultyId).ToList();
            ViewBag.Bikes = context.Bikes.OrderBy(b => b.BikeId).ToList();
            return View("Edit", new Ride());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Difficulties = context.Difficulties.OrderBy(r => r.DifficultyId).ToList();
            ViewBag.Bikes = context.Bikes.OrderBy(b => b.BikeId).ToList();
            var ride = context.Rides.Find(id);
            return View(ride);
        }

        [HttpPost]
        public IActionResult Edit(Ride ride)
        {
            if (ModelState.IsValid)
            {
                if (ride.RideId == 0)
                    context.Rides.Add(ride);
                else
                    context.Rides.Update(ride);
                context.SaveChanges();
                return RedirectToAction("Index", "Ride");
            }
            else
            {
                ViewBag.Action = (ride.RideId == 0) ? "Add" : "Edit";
                ViewBag.Difficulties = context.Difficulties.OrderBy(r => r.DifficultyId).ToList();
                ViewBag.Bikes = context.Bikes.OrderBy(b => b.BikeId).ToList();
                return View(ride);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ride = context.Rides.Find(id);
            return View(ride);
        }

        [HttpPost]
        public IActionResult Delete(Ride ride)
        {
            context.Rides.Remove(ride);
            context.SaveChanges();
            return RedirectToAction("Index", "Ride");
        }
    }
}