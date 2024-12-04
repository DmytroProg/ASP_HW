using MVCProject002.Models;

namespace MVCProject002.Data;

public class CarDatabase : IDatabase<Car>
{
    private readonly List<Car> _cars;

    public CarDatabase()
    {
        _cars = new List<Car>();
    }


    public void Add(Car item)
    {
        _cars.Add(item);
    }

    public IEnumerable<Car> Get()
    {
        return _cars;
    }

    public void Remove(Car car)
    {
        _cars.RemoveAll(x => x.Id == car.Id);
    }

    public void Update(Car oldCar, Car newCar)
    {
        Car car = _cars.First(x => x.Id == oldCar.Id);

        car = newCar;
    }
}