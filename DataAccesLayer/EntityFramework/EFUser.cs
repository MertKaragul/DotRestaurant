using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.GenericRepository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework {
    public class EFUser : GenericRepository<UserModel>, IUserDal {
        public async Task<UserModel?> findByEmail(string Email)
        {
            using var c = new Context();
            return await c.Set<UserModel>().FirstOrDefaultAsync(x => x.Email == Email);
        }
    }
}
