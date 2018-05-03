using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRazor.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imege { get; set; }
        public string Spicyness { get; set; }
        public enum ESpicy { Mild=0, Moderate=1, Hight=2 }

        public double Price { get; set; }

        public int CategoryTypeId { get; set; }
        public virtual CategoryType CategoryType { get; set; }

        public int FoodTypeId { get; set; }
        public virtual FoodType FoodType { get; set; }


    }
}
