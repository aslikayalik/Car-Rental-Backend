using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
            private IRentalDal _rentalDal;


            public RentalManager(IRentalDal rentalDal)
            {
                _rentalDal = rentalDal;
            }

            public IResult Add(Rental rentalDal)
            {
              
                _rentalDal.Add(rentalDal);
                return new SuccessResult(Messages.RentaledMessage);
            }
          
            public IResult Delete(Rental rental)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.DeletedMessage);
            }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdatedMessage);
        }




        public IDataResult<List<Rental>> GetAll() 
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            }

           
        public IDataResult<List<RentalDetailDto>> Get(int rentalId)
            {
            return new SuccessDataResult<List<RentalDetailDto>>((_rentalDal.GetRentalDetails(_rentalDal.GetAll(c => c.RentalId == rentalId))), Messages.ListedMessage);
        }

    

      
       
    }
}
