using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete {
    public class FoodModel {
        [Key]
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string FoodIngredients { get; set; }
        public bool FoodStatus { get; set; }
        public string FoodImage { get; set; }
        public bool FoodDiscount { get; set; }
        public long FoodPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public long FoodDiscountPrice { get; set; }

    }
}
