using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstarct
{
    public interface ICarService
    {
        //CRUD operations
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailsDto>> GetCarDetail(int carId);

        IResult AddTransactionalTest(Car car);
    }
}
