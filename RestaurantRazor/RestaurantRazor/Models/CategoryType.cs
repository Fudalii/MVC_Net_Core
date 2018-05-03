using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRazor.Models
{
    public class CategoryType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }

    public class CategoryTypeValidation : AbstractValidator<CategoryType>
    {
        public CategoryTypeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name)
                .NotNull()
                .WithName("Nazwa")
                .Length(3, 50)
                .WithMessage("Mój komunikat");
            RuleFor(x => x.DisplayOrder).NotNull();
           
        }
    }



}
