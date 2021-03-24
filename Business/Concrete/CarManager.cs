using Business.Abstarct;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        //CONSTRUCTOR
        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
        }
        //ADD
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //business code
            IResult result = BusinessRules.Run(CheckIfProductNameExists(car.CarName),
                CheckIfProductCountOfBrandCorrectResult(car.BrandId));

            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        //DELETE
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, Messages.CarDeleted);
        }
        //UPDATE
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            var result = _carDal.GetAll(p => p.BrandId == car.BrandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            throw new NotImplementedException();
        }
        //GETALL
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }
        //GET CARS BY BRAND ID
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }
        //GET CARS BY COLOR ID
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }
        //GET CAR DETAILS
        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }
        //GET CARS DETAILS BY BRAND ID
        public IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(cardetail => cardetail.BrandId == brandId));
        }
        //GET CARS DETAILS BY COLOR ID
        public IDataResult<List<CarDetailsDto>> GetCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(cardetail => cardetail.ColorId == colorId));
        }
        //GET CARS BY DAILY PRICE
        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(car => car.DailyPrice >= min && car.DailyPrice <= max), Messages.CarListed);
        }
        //GET CAR DETAIL
        public IDataResult<List<CarDetailsDto>> GetCarDetail()
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }
        //CHECK IF PRODUCT COUNT OF BRAND CORRECT RESULT
        private IResult CheckIfProductCountOfBrandCorrectResult(int brandId)
        {
            //Select count (*) from products where category ıd= 1
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }

            return new SuccessResult();
        }
        // CHECK IF PRODUCT NAME EXISTS
        private IResult CheckIfProductNameExists(string carName)
        {
            //Select count (*) from products where category ıd= 1
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }

            return new SuccessResult();
        }
        //ADD TRANSACTIONAL TEST
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }
        // CHECK IF CAR NAME EXISTS
        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }
        // CHECK IF CAR COUNT OF BRAND CORRECT
        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }
        public IDataResult<List<CarDetailsDto>> GetCarDetail(int carId)
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(cardetail => cardetail.CarId == carId));
        }
    }
}
