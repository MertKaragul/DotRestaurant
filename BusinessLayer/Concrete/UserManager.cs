using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete {
    public class UserManager : IUserService {

        IUserDal _IUserDal;

        public UserManager(IUserDal ıUserDal)
        {
            _IUserDal = ıUserDal;
        }

        public void TAdd(UserModel t)
        {
            _IUserDal.Insert(t);
        }

        public void TDelete(UserModel t)
        {
            _IUserDal.Delete(t);
        }

        public List<UserModel> TGetAll()
        {
            return _IUserDal.GetAll();
        }

        public async Task<UserModel?> TgetById(int id)
        {
            return await _IUserDal.getByIDAsync(id);
        }

        public void TUpdate(UserModel t)
        {
            _IUserDal.Update(t);
        }
    }
}
