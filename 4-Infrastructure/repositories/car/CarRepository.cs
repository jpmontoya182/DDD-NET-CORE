namespace Infrastructure.repositories.car
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Entities.car;
    using Domain.repositories.contracts.car;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Implementa la interfaz del dominio 
    /// La idea es, este conectado con una base de datos
    /// Tiene los metodos de persistencia
    /// </summary>
    public class CarRepository : ICarRepository
    {
        private CarContext _carContext;
        public CarRepository()
        {
            _carContext = new CarContext();

        }
        public void Create(Car carEntitie)
        {
            _carContext.Cars.Add(carEntitie);
            _carContext.SaveChanges();
        }
        public void Delete(int id)
        {
            _carContext.Cars.Remove(_carContext.Cars.Find(id));
            _carContext.SaveChanges();
        }
        public Car GetCar(int id)
        {
            return _carContext.Cars.Find(id);
        }
        public List<Car> GetCars()
        {
            IQueryable<Car> query =
            from Car in _carContext.Cars
            orderby Car.Name descending
            select Car;
            return query.ToList();
        }
        public string GetEngine()
        {
            return "V8";
        }
        public void Update(Car carEntitie)
        {
            var car = _carContext.Cars.Find(carEntitie.Id);
            car.Name = carEntitie.Name;
            car.Model = carEntitie.Model;
            car.Engine = carEntitie.Engine;
            _carContext.Cars.Update(car);
            _carContext.SaveChanges();
        }
    }
}
