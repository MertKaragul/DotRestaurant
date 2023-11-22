using EntityLayer.Concrete;

namespace DotRestaurant.Models {
    public class MenuViewModel {
        public List<CategoryModel> categoryModels;
        public List<FoodModel> foodModels;

        public MenuViewModel(List<CategoryModel> categoryModels, List<FoodModel> foodModels)
        {
            this.categoryModels = categoryModels;
            this.foodModels = foodModels;
        }
    }
}
