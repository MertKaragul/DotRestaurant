using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class CartManager : ICartService {
        ICartDal _ICartDal;

        public CartManager(ICartDal ıCartDal)
        {
            _ICartDal = ıCartDal;
        }

        public void TAdd(CartModel t)
        {
            _ICartDal.Insert(t);
        }

        public void TDelete(CartModel t)
        {
            _ICartDal.Delete(t);
        }

        public List<CartModel> TGetAll()
        {
            return _ICartDal.GetAll();  
        }

        public async Task<CartModel?> TgetById(int id) => await _ICartDal.getByIDAsync(id);

        public void TUpdate(CartModel t)
        {
            _ICartDal.Update(t);
        }
    }
}
