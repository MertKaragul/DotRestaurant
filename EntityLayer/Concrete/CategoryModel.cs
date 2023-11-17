using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete {
    public class CategoryModel {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool DefaultCategory { get; set; } = false;
    }
}
