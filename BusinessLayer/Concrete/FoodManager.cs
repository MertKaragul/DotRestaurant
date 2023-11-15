using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class FoodManager : IFoodService {

        IFoodDal _IFoodDal;

        public FoodManager(IFoodDal ıFoodDal)
        {
            _IFoodDal = ıFoodDal;
        }

        public void TAdd(FoodModel t)
        {
            _IFoodDal.Insert(t);
        }

        public void TDelete(FoodModel t)
        {
            _IFoodDal.Delete(t);
        }

        public List<FoodModel> TGetAll()
        {
            return _IFoodDal.GetAll();
        }

        public async Task<FoodModel?> TgetById(int id)
        {
            return await _IFoodDal.getByIDAsync(id); 
        }

        public void TUpdate(FoodModel t)
        {
            _IFoodDal.Update(t);
        }
    }
}
