using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete {
    public class CartModel {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserUUID { get; set; }
        [Required]
        public List<String> FoodList { get; set; }

        public CartModel(string UserUUID, List<String> FoodList)
        {
            this.FoodList = FoodList;
            this.UserUUID = UserUUID;
        }
        
    }
}
