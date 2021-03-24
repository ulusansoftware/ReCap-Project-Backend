

using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        //CONSTRUCTOR
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        //ADD
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new Result(true, Messages.BrandAdded);
        }
        //DELETE
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true, Messages.BrandDeleted);
        }
        //UPDATE
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true, Messages.BrandUpdated);
        }
        //GETALL
        public IDataResult<List<Brand>> GetAll()
        {
            return new DataResult<List<Brand>>(_brandDal.GetAll(),true, Messages.ColorListed);
        }

    }
}