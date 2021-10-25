using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TermProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Controllers
{
    public class RideController : Controller
    {
        private RideContext context { get; set; }

        public RideController(RideContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            //var rides = context.Rides.OrderBy(r => r.Name).ToList();
            var rides = context.Rides.Include(r => r.Difficulty).OrderBy(r => r.DifficultyId).ToList();
            return View(rides);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Difficulties = context.Difficulties.OrderBy(r => r.DifficultyId).ToList();
            return View("Edit", new Ride());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Difficulties = context.Difficulties.OrderBy(r => r.DifficultyId).ToList();
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