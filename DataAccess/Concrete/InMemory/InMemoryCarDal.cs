using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ Id =1,BrandId=1,ColorId=1,ModelYear= 1999,DailyPrice=18000,Description="Sıfır"},
                new Car{ Id =1,BrandId=1,ColorId=1,ModelYear= 1999,DailyPrice=500000,Description="2. El"},
                new Car{ Id =1,BrandId=1,ColorId=1,ModelYear= 1999,DailyPrice=70000,Description="2. El"},
                new Car{ Id =1,BrandId=1,ColorId=1,ModelYear= 1999,DailyPrice=250000,Description="Sıfır"},
                new Car{ Id =1,BrandId=1,ColorId=1,ModelYear= 1999,DailyPrice=10000,Description="Sıfır"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
