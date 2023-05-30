using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class ProductValidator: AbstractValidator<ProductEntity>
    {
        public ProductValidator()
        {
            RuleFor(p => p.title).NotNull().NotEmpty().WithMessage("Enter Title Please");
            RuleFor(p => p.price).NotNull().NotEmpty().LessThanOrEqualTo(1000000).WithMessage("Enter Valid Data"); ;
            RuleFor(p => p.discountPercentage).NotNull().NotEmpty().LessThanOrEqualTo(100);
            RuleFor(p => p.rating).NotNull().LessThanOrEqualTo(10);
            RuleFor(p => p.stock).NotEmpty().LessThanOrEqualTo(100);
            RuleFor(p => p.brand).NotEmpty().MaximumLength(10);
            RuleFor(p=> p.category).NotEmpty().MaximumLength(100);
            RuleFor(p=> p.thumbnail).NotEmpty();
            RuleFor(p=> p.description).NotEmpty().MaximumLength(100);
        }
    }
}
