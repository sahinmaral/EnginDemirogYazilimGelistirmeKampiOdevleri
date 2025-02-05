﻿using System;
using System.Collections.Generic;
using System.Text;

using Business.Abstract;

using DataAccess.Abstract;

using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public List<CarDetails> GetAll()
        {
            return _carDal.GetAll();
        }
    }
}
