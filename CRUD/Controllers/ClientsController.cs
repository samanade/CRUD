using CRUD.Data;
using CRUD.Models;
using CRUD.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ClientsController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var allClients = dbContext.Clients.ToList();
            return View(allClients);
        }


        [Route("details/{id:int}")]

        public IActionResult Details(int id)
        {
            var clientByID = dbContext.Clients.FirstOrDefault(c => c.ID == id);
            return View(clientByID);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Create workout section
        [Route("addWorkout/{clientid:int}")]
        public IActionResult CreateWorkout(int workoutID)
        {
            var workout = dbContext.Workouts.FirstOrDefault(c => c.ID == workoutID);
            ViewBag.WorkoutTitle = workout.workoutTitle;
            ViewBag.WorkoutID = workout.ID;
            return View();
        }

        [HttpPost]
        public IActionResult CreateWorkout(AddWorkoutBindingModel bindingModel)
        {
            var workoutToCreate = new Workout
            {
                workoutTitle = bindingModel.workoutTitle,
                workoutDate = bindingModel.workoutDate,
                workoutThumbnail = bindingModel.workoutThumbnail,
                Client = dbContext.Clients.FirstOrDefault(c => c.ID == bindingModel.ClientID)
            };

            dbContext.Workouts.Add(workoutToCreate);
            dbContext.SaveChanges();

            return RedirectToAction("Details");

        }

        [HttpPost]
        public IActionResult Create(AddClientBindingModel bindingModel)
        {
            var clientToCreate = new Client
            {
                firstName = bindingModel.firstName,
                lastName = bindingModel.lastName,
                phoneNumber = bindingModel.phoneNumber,
                email = bindingModel.email
            };

            dbContext.Clients.Add(clientToCreate);
            dbContext.SaveChanges();

            return RedirectToAction("Details");

        }
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            var clientByID = dbContext.Clients.FirstOrDefault(c => c.ID == id);
            return View(clientByID);
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
