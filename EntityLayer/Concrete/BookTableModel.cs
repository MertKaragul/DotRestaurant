using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete {
    public class BookTableModel {
        [Key]
        public int BookTableID { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Persons { get; set; }
        public DateTime Date { get; set; }
    }
}
