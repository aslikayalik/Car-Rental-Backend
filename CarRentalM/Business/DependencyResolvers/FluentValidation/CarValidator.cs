using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.FluentValidation
{

    public class CarValidator : AbstractValidator<Car>
    {
        
        public CarValidator()  
        {    
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
           
        }
        
    }
}
