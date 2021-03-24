using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        //CONSTRUCTOR
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        //ADD
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new Result(true, Messages.RentalAdded);
        }
        //DELETE
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new Result(true, Messages.RentalDeleted);
        }
        //UPDATE
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new Result(true, Messages.RentalUpdated);
        }
        //GETALL
        public IDataResult<List<Rental>> GetAll()
        {
            return new DataResult<List<Rental>>(_rentalDal.GetAll(), true, Messages.RentalListed);
        }
        //GETBYID
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.RentalId == rentalId));
        }
        //GET RENTAL DETAILS DTO
        public IDataResult<List<RentalDetailsDto>> GetRentalDetailsDto()
        {
            return new SuccessDataResult<List<RentalDetailsDto>>(_rentalDal.GetRentalDetails());
        }
    }
}