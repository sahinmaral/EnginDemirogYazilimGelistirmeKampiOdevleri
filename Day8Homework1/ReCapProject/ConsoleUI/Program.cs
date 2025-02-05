﻿using Business.Concrete;

using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;

using System;

namespace ConsoleUI
{
    class Program
    {
        #region CRUD İşlemleri Testi İçin Metotlar
        public static void getColours()
        {
            Console.WriteLine("Colours");
            ColourManager colourManager = new ColourManager(new EfColourDal());
            foreach (var colour in colourManager.GetAll())
            {
                Console.WriteLine(colour.ColourId + "     " + colour.ColourName);
                Console.WriteLine("------------------------");
            }
        }

        public static void getCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("Cars");
            foreach (var car in carManager.GetCarDetailDto())
            {
                Console.WriteLine("Arabanın markası : {0}", car.BrandName);
                Console.WriteLine("Arabanın rengi : {0}", car.ColourName);
                Console.WriteLine("Arabanın günlük kira ücreti : {0}", car.DailyPrice);
                Console.WriteLine("Arabanın açıklaması : {0}", car.Description);
                Console.WriteLine("------------------------");
            }
        }

        public static void getBrands()
        {
            Console.WriteLine("Brands");
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandId + "     " + brand.BrandName);
                Console.WriteLine("------------------------");
            }
        }

        #endregion
        static void Main(string[] args)
        {

            getBrands();
            getCars();
            getColours();

            Car car1 = new Car
            {
                ColourId = 2,
                BrandId = 10,
                ModelYear = 2015,
                DailyPrice = 750,
                Description = "i5"
            };


            CarManager carManager = new CarManager(new EfCarDal());



            foreach (var car in carManager.GetCarsByColourId(2))
            {
                Console.WriteLine("Car Id : {0}", car.CarId);
                Console.WriteLine("Car Description : {0}", car.Description);
            }

            foreach (var car in carManager.GetCarsByBrandId(4))
            {
                Console.WriteLine("Car Id : {0}", car.CarId);
                Console.WriteLine("Car Description : {0}", car.Description);
            }


            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add(car1);

            getCars();


        }
    }
}
