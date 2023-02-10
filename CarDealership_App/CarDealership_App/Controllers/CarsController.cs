using CarDealership_App.Data;
using CarDealership_App.Entities;
using CarDealership_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership_App.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext context;
        public CarsController(ApplicationDbContext context)
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
        public IActionResult Create(CarsCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Car carFromDb = new Car
                {
                    Id = bindingModel.Id,
                    RegNumber = bindingModel.RegNumber,
                    Manifactured = bindingModel.Manifactured,
                    Model = bindingModel.Model,
                    Picture = bindingModel.Picture,
                    YearOfManifacture = bindingModel.YearOfManifacture,
                    Price = bindingModel.Price,

                };
                context.Cars.Add(carFromDb);
                context.SaveChanges();

                return this.RedirectToAction("Success");
            }
            return this.View();
        }



        public IActionResult All(string searchStringModel, string searchStringRegNumber)
        {
            List<CarsAllViewModel> cars = context.Cars.Select(carFromDb => new CarsAllViewModel
            {
                Id = carFromDb.Id,
                RegNumber = carFromDb.RegNumber,
                Manifactured = carFromDb.Manifactured,
                Model = carFromDb.Model,
                Picture = carFromDb.Picture,
                YearOfManifacture = carFromDb.YearOfManifacture,
                Price = carFromDb.Price,
            }).ToList();
            if (!String.IsNullOrEmpty(searchStringModel) && !String.IsNullOrEmpty(searchStringRegNumber))
            {
                cars = cars.Where(x => x.Model.Contains(searchStringModel) && x.RegNumber.Contains(searchStringRegNumber)).ToList();

            }
            else if (!String.IsNullOrEmpty(searchStringModel))
            {
                cars = cars.Where(x => x.Model.Contains(searchStringModel)).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringRegNumber))
            {
                cars = cars.Where(x => x.RegNumber.Contains(searchStringRegNumber)).ToList();
            }
            return View(cars);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Car item = context.Cars.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            CarsCreateViewModel car = new CarsCreateViewModel()
            {
                Id=item.Id,
                RegNumber = item.RegNumber,
                Manifactured = item.Manifactured,
                Model = item.Model,
                Picture = item.Picture,
                YearOfManifacture = item.YearOfManifacture,
                Price = item.Price,
            };
            return View(car);
        }
        [HttpPost]
        public IActionResult Edit(CarsCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {


                Car car = new Car
                {
                    Id = bindingModel.Id,
                    RegNumber = bindingModel.RegNumber,
                    Manifactured = bindingModel.Manifactured,
                    Model = bindingModel.Model,
                    Picture = bindingModel.Picture,
                    YearOfManifacture = bindingModel.YearOfManifacture,
                    Price = bindingModel.Price,
                };
                context.Cars.Update(car);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }
            return this.View(bindingModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Car item = context.Cars.Find(id);
            if (item == null)
            {
                return NotFound();
            }


            CarsDetailsViewModel car = new CarsDetailsViewModel()
            {
                Id = item.Id,
                RegNumber = item.RegNumber,
                Manifactured = item.Manifactured,
                Model = item.Model,
                Picture = item.Picture,
                YearOfManifacture = item.YearOfManifacture,
                Price = item.Price,
            };

            return View(car);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Car item = context.Cars.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            context.Cars.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All", "Cars");

        }
        public IActionResult Success()
        {
            return this.View();
        }

        public IActionResult Sort()
        {
            List<CarsAllViewModel> cars = context.Cars.Select(carFromDb => new CarsAllViewModel
            {
                Id = carFromDb.Id,
                RegNumber = carFromDb.RegNumber,
                Manifactured = carFromDb.Manifactured,
                Model = carFromDb.Model,
                Picture = carFromDb.Picture,
                YearOfManifacture = carFromDb.YearOfManifacture,
                Price = carFromDb.Price,
            }).OrderBy(x => x.Price).ToList();

            return View(cars);
        }
    }
}
