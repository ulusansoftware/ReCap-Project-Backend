using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyCarDbContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                var result = from car in context.Cars
                    join color in context.Colors on car.ColorId equals color.ColorId
                    join brand in context.Brands on car.BrandId equals brand.BrandId
                    join carImage in context.CarImages on car.CarId equals carImage.CarId
                    select new CarDetailsDto()
                    {
                        CarId = car.CarId,
                        ImagePath = carImage.ImagePath,
                        Description = car.Description,
                        BrandId = brand.BrandId,
                        BrandName = brand.BrandName,
                        CarImageDate = carImage.Date,
                        ColorId = color.ColorId,
                        ColorName = color.ColorName,
                        DailyPrice = car.DailyPrice,
                        CarName = car.Description,
                        ModelYear = car.ModelYear

                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}