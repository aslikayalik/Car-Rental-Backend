using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
         

        }

       
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);

            return new SuccessResult(Messages.AddedMessage);

        }

   
        public IResult Update(Customer customer)
        {

            _customerDal.Update(customer);

            return new SuccessResult(Messages.UpdatedMessage);


        }


        public IResult Delete(Customer customer)
        {

            _customerDal.Delete(customer);

            return new SuccessResult(Messages.DeletedMessage);

        }

      
        public IDataResult<List<Customer>> GetAll()
        {

            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.ListedMessage);
            
        }


        public IDataResult<Customer> GetUser(int userId)  
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(m => m.UserId == userId));
        }

        public IDataResult<List<CustomerDetailDto>> Get(int CustomerId)
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), Messages.ListedMessage);
        }
    }
}
