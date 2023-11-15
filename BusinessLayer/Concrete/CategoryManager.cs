using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class CategoryManager : ICategoryService {

        ICategoryDal _ICategoryDal;

        public CategoryManager(ICategoryDal ICategoryDal) {
            _ICategoryDal= ICategoryDal;
        }
        public void TAdd(CategoryModel t)
        {
            _ICategoryDal.Insert(t);
        }

        public void TDelete(CategoryModel t)
        {
            _ICategoryDal.Delete(t);
        }

        public List<CategoryModel> TGetAll()
        {
            return _ICategoryDal.GetAll();
        }

        public async Task<CategoryModel?> TgetById(int id)
        {
            return await _ICategoryDal.getByIDAsync(id);
        }

        public void TUpdate(CategoryModel t)
        {
            _ICategoryDal.Update(t);
        }
    }
}
