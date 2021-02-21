using FluentValidation;
using Shop.Product.Application.Services.Manager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Product.Application.Services.Manager.Validations
{
    public class BaseCommandValidator : AbstractValidator<BaseCommand>
    {
        public BaseCommandValidator()
        {
            RuleFor(item => item.ProductId).NotEmpty().WithMessage("No productId found");
        }
    }
}
