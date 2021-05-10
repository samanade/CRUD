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
    [Route("workouts")]
    public class WorkoutsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public WorkoutsController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }

        //Create

        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("create/{clientid:int}")]
        public IActionResult CreateWorkout(int workoutID)
        {
            var workout = dbContext.Workouts.FirstOrDefault(c => c.ID == workoutID);
            ViewBag.WorkoutTitle = workout.workoutTitle;
            ViewBag.WorkoutID = workout.ID;
            return View();
        }

        [Route("save")]
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

            return RedirectToAction("Details", new { id = workoutToCreate.ID }) ;

        }

        public IActionResult Index()
        {
            var allWorkouts = dbContext.Workouts.ToList();
            return View(allWorkouts);
        }


        [Route("details/{id:int}")]

        public IActionResult Details(int id)
        {
            var workoutByID = dbContext.Workouts.FirstOrDefault(c => c.ID == id);
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
        public IActionResult Update(Workout workout, int id)
        {
            var workoutToUpdate = dbContext.Workouts.FirstOrDefault(c => c.ID == id);
            workoutToUpdate.workoutTitle = workout.workoutTitle;
            workoutToUpdate.workoutDate = workout.workoutDate;
            workoutToUpdate.workoutThumbnail = workout.workoutThumbnail;
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var workoutToDelete = dbContext.Workouts.FirstOrDefault(c => c.ID == id);
            dbContext.Workouts.Remove(workoutToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}