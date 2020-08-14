using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.Dao
{
    public class UserDao
    {
        LuxuryStoreDbContext db = null;
        public UserDao()
        {
            db = new LuxuryStoreDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.userName == userName);
        }
        public bool Login(string UserName, string passWord)
        {
            var result = db.Users.Count(x => x.userName == UserName && x.password == passWord);
            //var result = db.Users.Count(x => x.userName == UserName && x.password == passWord);
            if( result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
