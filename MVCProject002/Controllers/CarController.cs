using Microsoft.AspNetCore.Mvc;
using MVCProject002.Data;
using MVCProject002.Models;

namespace MVCProject002.Controllers;

public class CarController : Controller
{
    private static readonly IDatabase<Car> _carDatabase = new CarDatabase();

    static CarController()
    {
        _carDatabase.Add(new Car() { Id = 1, Name = "Lanos", Color = "00FF00", Price = 99999 });
        _carDatabase.Add(new Car() { Id = 2, Name = "Lanos1", Color = "FFFF00", Price = 89999 });
        _carDatabase.Add(new Car() { Id = 3, Name = "Lanos2", Color = "00FFAA", Price = 99439 });
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

    public IActionResult DeleteCar(int id)
    {
        var car = _carDatabase.Get().First(x => x.Id == id);
        return View(car);
    }

    [HttpPost]
    public IActionResult AddCar(Car car)
    {
        _carDatabase.Add(car);

        return RedirectToAction(nameof(GetCars));
    }

    [HttpPost]
    public IActionResult DeleteCar(Car car)
    {
        _carDatabase.Remove(car);

        return RedirectToAction(nameof(GetCars));
    }

    public IActionResult EditCar(int id) => View(_carDatabase.Get().First(x => x.Id == id));

    [HttpPost]
    public IActionResult EditCar(Car car)
    {
        var oldCar = _carDatabase.Get().First(x => x.Id == car.Id);
        _carDatabase.Update(oldCar, car);

        return RedirectToAction(nameof(GetCars));
    }
}
