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
    [Route("clients")]
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


        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("createclient")]
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

            return RedirectToAction("Details", new { id = clientToCreate.ID });

        }
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            var clientByID = dbContext.Clients.FirstOrDefault(c => c.ID == id);
            return View(clientByID);
        }

        [Route("edit/{id:int}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var clientByID = dbContext.Clients.FirstOrDefault(c => c.ID == id);
            return View(clientByID);
        }

        [Route("editclient")]
        [HttpPost]
        public IActionResult Edit(Client client)
        {
            var clientToUpdate = dbContext.Clients.FirstOrDefault(c => c.ID == client.ID);
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
