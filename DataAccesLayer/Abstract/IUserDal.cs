using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract {
    public interface IUserDal : IGenericDal<UserModel>{
        public Task<UserModel?> findByEmail(string Email);
    }
}
