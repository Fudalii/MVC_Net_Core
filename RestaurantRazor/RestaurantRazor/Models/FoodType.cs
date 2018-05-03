using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRazor.Models
{
    public class FoodType
    {
        public int Id { get; set; }
        [Display(Name="Typ Jedzonka")]
        public string Name { get; set; }
    }

    public class FoodTypeValidation : AbstractValidator<FoodType>
    {
        public FoodTypeValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name)
                .NotNull()
                .WithName("Typ Jedzonka")
                .Length(3, 50)
                .WithMessage("Mój komunikat");
            RuleFor(x => x.Name).NotNull();

        }
    }
}
