using Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailsDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null);
    }
}
