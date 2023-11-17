using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class BookTableManager : IBookTableService {

        IBookTableDal _IBookTableDal;

        public BookTableManager(IBookTableDal ıBookTableDal)
        {
            _IBookTableDal = ıBookTableDal;
        }

        public async Task<BookTableModel?> findByEmail(string email)
        {
            return await _IBookTableDal.findByEmail(email);
        }

        public void TAdd(BookTableModel t)
        {
            _IBookTableDal.Insert(t);
        }

        public void TDelete(BookTableModel t)
        {
            _IBookTableDal.Delete(t);
        }

        public List<BookTableModel> TGetAll()
        {
            return _IBookTableDal.GetAll();
        }

        public async Task<BookTableModel?> TgetById(int id) =>  await _IBookTableDal.getByIDAsync(id);

        public void TUpdate(BookTableModel t)
        {
            _IBookTableDal.Update(t);
        }
    }
}
