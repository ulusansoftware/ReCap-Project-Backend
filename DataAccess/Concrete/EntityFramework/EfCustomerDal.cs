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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, MyCarDbContext>, ICustomerDal
    {
        public List<CustomerDetailsDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (MyCarDbContext context = new MyCarDbContext())
            {
                var result = from user in context.Users
                    join customer in context.Customers
                        on user.UserId equals customer.UserId
                    select new CustomerDetailsDto
                    {
                        CompanyName = customer.CompanyName,
                        CustomerName = $"{user.FirstName} {user.LastName}"
                    };
                return result.ToList();
            }

        }
    }
}