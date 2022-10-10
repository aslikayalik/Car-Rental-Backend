using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.DataAccess.EntityFramework;
using System.Linq.Expressions;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (CarContext context = new CarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public UserAndOperationDto GetUserAndClaim(string email)
        {
            using (CarContext context = new CarContext())
            {
                var result = from user in context.Users
                             join userOperationClaim in context.UserOperationClaims
                             on user.UserId equals userOperationClaim.UserId
                             join operationClaim in context.OperationClaims
                             on userOperationClaim.OperationClaimId equals operationClaim.Id
                             join customer in context.Customers
                             on user.UserId equals customer.UserId
                             where user.Email == email
                             select new UserAndOperationDto
                             {
                                 UserId = user.UserId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 ClaimName = operationClaim.Name,
                                 CompanyName = customer.CompanyName
                             };
                return result.FirstOrDefault();
            }

        }


    }
}
