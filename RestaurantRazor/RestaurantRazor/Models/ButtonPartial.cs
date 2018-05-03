using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRazor.Models
{
    public class ButtonPartial
    {
        public string URL { get; set; }
        public string Icon { get; set; }
        public string ButtonType { get; set; }

        public int? Id { get; set; } // dla parametrów linku Action Parameters


        public string ActionParameters
        {
            get {
                if(Id!=0 && Id != null)
                {
                    return Id.ToString();
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
