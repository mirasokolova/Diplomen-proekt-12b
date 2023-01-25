using Dog_WebApp.Data;
using Dog_WebApp.Entities;
using Dog_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dog_WebApp.Controllers
{
    public class DogsController : Controller
    {


        private readonly ApplicationDbContext context;
        public DogsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Dog dogFromDb = new Dog
                {
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Image = bindingModel.Image,
                };
                context.Dogs.Add(dogFromDb);
                context.SaveChanges();

                return this.RedirectToAction("Success");
            }
            return this.View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            DogCreateViewModel dog = new DogCreateViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Image = item.Image,
            };
            return View(dog);
        }
        [HttpPost]
        public IActionResult Edit(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {


                Dog dog = new Dog
                {
                    Id = bindingModel.Id,
                    Name = bindingModel.Name,
                    Age = bindingModel.Age,
                    Breed = bindingModel.Breed,
                    Image = bindingModel.Image,
                };
                context.Dogs.Update(dog);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }
            return this.View(bindingModel);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }


            DogCreateViewModel dog = new DogCreateViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age,
                    Breed = item.Breed,
                    Image = item.Image,
                };
            
            return View(dog);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Dog item = context.Dogs.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            context.Dogs.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Dogs");
            
        }






        public IActionResult Success()
        {
                return this.View();
        }

            public IActionResult All()
            {
                List<DogAllViewModel> dogs = context.Dogs.Select(dogFromDb => new DogAllViewModel
                {
                    Id = dogFromDb.Id,
                    Name = dogFromDb.Name,
                    Age = dogFromDb.Age,
                    Breed = dogFromDb.Breed,
                    Image = dogFromDb.Image
                }).ToList();
                return View(dogs);
            }
    }
    
}
