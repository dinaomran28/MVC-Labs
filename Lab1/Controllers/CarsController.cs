using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public enum Status
    {
        table,
        list
    }
    public class CarsController : Controller
    {
        public IActionResult GetAll()
        {
            var cars = Car.GetCars();
            return View(cars);
        }
        public IActionResult GetDetail(string img, Status status)
        {
            var car = Car.GetCars().FirstOrDefault(c => c.Image == img);
            var data = new { car, status }; //Anonymous Object
            return View(data);
        }
    }
}
