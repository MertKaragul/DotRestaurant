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
    public class EFCart : GenericRepository<CartModel>, ICartDal {
        public async Task<CartModel?> findByUserUUID(string uuid)
        {
            using var c = new Context();
            return await c.Set<CartModel>().FirstOrDefaultAsync(x => x.UserUUID == uuid);
        }
    }
}
