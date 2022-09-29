using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            Test1();
        }
        private static void Test1()
        {
            /*User user = new User
            {
                FirstName = "Ahmet",
                LastName = "Kaçmaz",
                Email = "ahmetkacmaz@gmail.com",
                UserPassword = "012"
            };
            UserManager userManager = new UserManager(new EfUserDal());           
            var resultUser =  userManager.Add(user);
            Console.WriteLine(resultUser.Message);
            Customer customer = new Customer
            {
                CompanyName = "Kaçmaz Company",
                UserId = 1
            };
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());            
            var resultCustomer = customerManager.Add(customer);
            Console.WriteLine(resultCustomer.Message);*/
            Rental rental = new Rental
            {
                CarId = 2,
                CustomerId = 1,
                RentDate = new DateTime(2022, 08, 24),
                ReturnDate = new DateTime(2022, 10, 01)
            };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var resultRental=rentalManager.Add(rental);
            Console.WriteLine(resultRental.Message);
        }

        /* private static void CarTest()
         {
             CarManager carManager = new CarManager(new EfCarDal());
             var result = carManager.GetCarDetails();
             if (result.Success)
             {
                 foreach (var car in result.Data)
                 {
                     Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
                 }
                 Console.WriteLine(result.Message);
             }
             else
             {
                 Console.WriteLine(result.Message);
             }
         }*/
    }
}