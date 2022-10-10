using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
   
        public List<RentalDetailDto> GetRentalDetails(List<Rental> rentals)     
        {
            using (CarContext context = new CarContext())
            {
                var result = from r in context.Rentals 
                             join c in context.Cars on r.CarId equals c.Id
                             join t in context.Customers on r.CustomerId equals t.CustomerId
                             select new RentalDetailDto
                             { 
                                 RentalId = r.RentalId,
                                 CarId = c.Id, 
                                 CustomerId = t.CustomerId, 
                                 RentDate = r.RentDate, 
                                 ReturnDate = r.ReturnDate 
                             };
                return result.ToList();

            }  
        }

      
    }
}
