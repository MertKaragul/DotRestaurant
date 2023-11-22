using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete {
    public class FoodModel {
        [Key]
        public int FoodID { get; set; }
        [Required]
        public string FoodName { get; set; }
        [Required]
        public string FoodIngredients { get; set; }
        [Required]
        public bool FoodStatus { get; set; }
        [Required]
        public string FoodImage { get; set; }
        [Required]
        public long FoodPrice { get; set; }
        public int Stock { get; set; } = 1;
        [Required]
        public bool FoodDiscountStatus { get; set; }
        [Required]
        public long FoodDiscountPrice { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
