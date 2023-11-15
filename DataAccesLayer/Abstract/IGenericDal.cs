using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract {
    public interface IGenericDal <T> where T : class {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        Task<T> getByIDAsync(int id);
        List<T> GetAll();
        
    }
}
