using Dog_WebApp.Abstactions;
using Dog_WebApp.Data;
using Dog_WebApp.Entities;
using Dog_WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dog_WebApp.Controllers
{
    public class DogsController : Controller
    {


        private readonly IDogService _dogService;
        public DogsController(IDogService dogService)
        {
            this._dogService = dogService;
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
                var created = _dogService.Create(bindingModel.Name, bindingModel.Age, bindingModel.Breed, bindingModel.Image);
                if (created)
                {
                    return this.RedirectToAction("Success");
                }
                
            }
            return this.View();
        }
    

        public IActionResult Edit(int id)
        {
            
            Dog item = _dogService.GetDogById(id);
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
        public IActionResult Edit(int id , DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _dogService.UpdateDog(id,bindingModel.Name, bindingModel.Age, bindingModel.Breed, bindingModel.Image);
                if (updated)
                {
                    return this.RedirectToAction("All");
                }
               
            }
            return this.View(bindingModel);
        }

        public IActionResult Details(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }
            DogDetailsViewModel dog = new DogDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Image = item.Image,
            };
            return View(dog);
        }
        public IActionResult Delete(int id)
        {
            Dog item = _dogService.GetDogById(id);
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
        public IActionResult Delete(int id,IFormCollection collection)
        {
            var deleted = _dogService.RemoveById(id);
            if (deleted)
            {
                return this.RedirectToAction("All", "Dogs");
            }
            else
            {
                return View();
            }
        }






        public IActionResult Success()
        {
            return this.View();
        }


        public IActionResult All(string searchStringBreed, string searchStringName)
        {
            List<DogAllViewModel> dogs = _dogService.GetDogs()
                .Select(dogFromDb => new DogAllViewModel
                {
                    Id = dogFromDb.Id,
                    Name = dogFromDb.Name,
                    Age = dogFromDb.Age,
                    Breed = dogFromDb.Breed,
                    Image = dogFromDb.Image
                }).ToList();

            return this.View(dogs);
        }

          

        public IActionResult Sort()
        {
            List<DogAllViewModel> dogs = _dogService.GetDogs().Select(dogFromDb => new DogAllViewModel
            {
                Id = dogFromDb.Id,
                Name = dogFromDb.Name,
                Age = dogFromDb.Age,
                Breed = dogFromDb.Breed,
                Image = dogFromDb.Image
            }).OrderBy(x=>x.Name).ToList();
            
            return View(dogs);
        }

    }
    
}
