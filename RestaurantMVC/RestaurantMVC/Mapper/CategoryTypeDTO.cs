using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMVC.Mapper
{
    public class CategoryTypeDTO
    {
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage = "Podaj Name")]
        public string Name { get; set; }
        [Required (ErrorMessage = "Podaj Kolejność")]
        [Display(Name="Display Order")]
        public int DisplayOrder { get; set; }
    }
}
