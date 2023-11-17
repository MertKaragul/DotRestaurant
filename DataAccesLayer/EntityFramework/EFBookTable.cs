using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.GenericRepository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework {
    public class EFBookTable : GenericRepository<BookTableModel>, IBookTableDal {
        public async Task<BookTableModel> findByEmail(string email)
        {
            using var c = new Context();
            BookTableModel? bookTableModel = await c.Set<BookTableModel>().FindAsync(email);
            return bookTableModel;
        }
    }
}
