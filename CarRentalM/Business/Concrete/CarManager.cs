using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{

    public class CarManager : ICarService
    {
        ICarDal _carDal;


        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }

      [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult("Araba"+Messages.AddedMessage);

        }

        public IResult Update(Car car)
        {

            _carDal.Update(car);
            return new SuccessResult(Messages.UpdatedMessage);
        }

    
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedMessage);
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().ToList(),Messages.ListedMessage);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>((_carDal.GetCarDetails(_carDal.GetAll(c => c.BrandId == BrandId))),Messages.ListedMessage);
        }



  

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>((_carDal.GetCarDetails(_carDal.GetAll(c => c.ColorId == ColorId))), Messages.ListedMessage);
        }

        public IDataResult<List<CarDetailDto>> Get(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>((_carDal.GetCarDetails(_carDal.GetAll(c => c.Id == id))), Messages.ListedMessage);
        }

     
    }



        
    
}
