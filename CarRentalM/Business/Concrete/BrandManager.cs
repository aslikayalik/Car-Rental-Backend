using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.Utilities.Results;
using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
   public class BrandManager : IBrandService 
    {
        IBrandDal _brandDal;   

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal; 

        }
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.GetCarsByBrandId")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult("Brand"+Messages.AddedMessage);
        }

        [CacheRemoveAspect("IBrandService.GetCarsByBrandId")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult("Brand"+Messages.DeletedMessage);
        }

        [CacheRemoveAspect("IBrandService.GetCarsByBrandId")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult("Brand" + Messages.UpdatedMessage);
        }

        [CacheRemoveAspect("IBrandService.GetCarsByBrandId")]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.ListedMessage);
        }

      

    }
}
