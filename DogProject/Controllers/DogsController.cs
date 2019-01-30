using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DogProject.Controllers
{
    public class DogsController : Controller
    {

        DogsService dogsService = new DogsService();
        [HttpGet]
        [Route("")] //makes this as as  the home page.
        public IActionResult Index()
        {
            var dogs = dogsService.GetAllDogs();
            ViewBag.Dogs = dogs;

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dog dog)
        {
            dogsService.Add(dog);
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public IActionResult Update()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dog = dogsService.GetDogById(id);
            ViewBag.Dog = dog;

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Dog dog)
        {
           dogsService.UpdateDog(dog);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            dogsService.DeleteDog(id);
            return RedirectToAction(nameof(Index));
        }

    }
}