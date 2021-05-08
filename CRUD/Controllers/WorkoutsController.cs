using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    public class WorkoutsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public WorkoutsController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var allWorkouts = dbContext.Workouts.ToList();
            return View(allWorkouts);
        }


        [Route("details/{id:int}")]

        public IActionResult Details(int id)
        {
            var workoutByID = dbContext.Clients.FirstOrDefault(c => c.ID == id);
            return View(workoutByID);
        }

        
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            var workoutByID = dbContext.Workouts.FirstOrDefault(c => c.ID == id);
            return View(workoutByID);
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public IActionResult Update(Client client, int id)
        {
            var clientToUpdate = dbContext.Clients.FirstOrDefault(c => c.ID == id);
            clientToUpdate.firstName = client.firstName;
            clientToUpdate.lastName = client.lastName;
            clientToUpdate.phoneNumber = client.phoneNumber;
            clientToUpdate.email = client.email;
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var clientToDelete = dbContext.Clients.FirstOrDefault(c => c.ID == id);
            dbContext.Clients.Remove(clientToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}