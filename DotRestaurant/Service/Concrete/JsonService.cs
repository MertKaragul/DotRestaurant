using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DotRestaurant.Service.Concrete {
    public class JsonService<T> where T: class {
        public String toJson(T value)
        {
            return JsonSerializer.Serialize(value);
        }

        public T? fromJson(String json) => JsonSerializer.Deserialize<T>(json);
    }
}
