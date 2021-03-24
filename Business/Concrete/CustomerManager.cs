using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        //CONSTRUCTOR
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        //ADD
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new Result(true, Messages.CustomerAdded);
        }
        //DELETE
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new Result(true, Messages.CustomerDeleted);
        }
        //UPDATE
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new Result(true, Messages.CustomerUpdated);
        }
        //GETALL
        public IDataResult<List<Customer>> GetAll()
        {
            return new DataResult<List<Customer>>(_customerDal.GetAll(), true, Messages.CustomerListed);
        }
        //GETBYID
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CustomerId == id));
        }
        //GETCARDETAIL
        public IDataResult<List<CustomerDetailsDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailsDto>>(_customerDal.GetCustomerDetails(), Messages.CustomerListed);
        }
    }
}