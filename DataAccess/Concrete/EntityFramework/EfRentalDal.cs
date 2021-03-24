using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyCarDbContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                //tr_//Rentals tablosunda (re) deki CarId ile CarId i cre deki BrandId ile br deki BrandId i  cr deki ColorId ile ColorId re deki CustomerId ile CustomerId cu daki UserId ile User (Id eşitse) select et (döndür)
                var result = from re in context.Rentals
                             join ca in context.Cars on re.CarId equals ca.CarId
                             join cu in context.Customers on re.CustomerId equals cu.CustomerId
                             join us in context.Users on cu.CustomerId equals us.UserId
                             join br in context.Brands on ca.BrandId equals br.BrandId
                             select new RentalDetailsDto
                             {
                                 RentalId = re.RentalId,
                                 CarId = ca.CarId,
                                 CarName = ca.Description,
                                 BrandName = br.BrandName,
                                 CompanyName = cu.CompanyName,
                                 UserName = us.FirstName + " " + us.LastName,
                                 RentalDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,

                             };

                return result.ToList();
            }
        }

    }
}