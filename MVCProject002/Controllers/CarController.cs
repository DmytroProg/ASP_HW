using Microsoft.AspNetCore.Mvc;
using MVCProject002.Data;
using MVCProject002.Models;

namespace MVCProject002.Controllers;

public class CarController : Controller
{
    private static readonly IDatabase<Car> _carDatabase = new CarDatabase();

    static CarController()
    {
        _carDatabase.Add(new Car() { Name = "Lanos", Color = "00FF00", Price = 99999 });
        _carDatabase.Add(new Car() { Name = "Lanos1", Color = "FFFF00", Price = 89999 });
        _carDatabase.Add(new Car() { Name = "Lanos2", Color = "00FFAA", Price = 99439 });
    }

    [HttpGet]
    public IActionResult GetCars()
    {
        var cars = _carDatabase.Get();

        return View(cars);
    }

    public IActionResult AddCar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddCar(Car car)
    {
        _carDatabase.Add(car);

        return RedirectToAction(nameof(GetCars));
    }
}
