using DataAccesLayer.Abstract;
using DataAccesLayer.GenericRepository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework {
    public class EFBookTable : GenericRepository<BookTableModel>, IBookTableDal {
    }
}
