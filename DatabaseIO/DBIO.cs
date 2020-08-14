using DatabaseLuxuryStore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{
    public class DBIO
    {
        MyDB mydb = new MyDB();

        //public User GetObject_User(string uid, string pwd)
        //{
        //không sử dụng parameters

        //string SQL = "SELECT * FROM User WHERE userName= '"+uid+"' AND password= '"+pwd+"' ";
        //return mydb.Database.SqlQuery<User>(SQL).FirstOrDefault();

        //có sử dụng parameters

        //return mydb.Database.SqlQuery<User>(
        //    "SELECT * FROM User WHERE userName=@U AND password=@P",
        //    new SqlParameter("@U",uid),
        //    new SqlParameter("@P",pwd)
        //    ).FirstOrDefault();

        //        mydb.Users.Where(c => c.userName == uid && c.password == pwd).FirstOrDefault();
        //    }
        //    public void AddObject_User(string uid, string pwd, string name, string address, string email, string Phone)
        //    {
        //        mydb.Database.ExecuteSqlCommand(
        //            "INSERT INTO User(userNam, password, Name, Address, Email, Phone) VALUES(@U,@P,@N,@A, @E, @PH)",
        //            new SqlParameter("@U", uid),
        //            new SqlParameter("@P", pwd),
        //            new SqlParameter("@N", name),
        //            new SqlParameter("@A", address),
        //            new SqlParameter("@E", email),
        //            new SqlParameter("@PH", Phone)
        //            );
        //    }
        public long Isert(User entity)
        {
            mydb.Users.Add(entity);
            mydb.SaveChanges();
            return entity.ID;
        }
        public long Update(User entity)
        {
            mydb.Users.Add(entity);
            mydb.SaveChanges();
            return entity.ID;
        }
        public long Delete(User entity)
        {
            mydb.Users.Remove(entity);
            mydb.SaveChanges();
            return entity.ID;
        }

        public User GetById(string userid)
        {
            return mydb.Users.SingleOrDefault(x => x.userName == userid);
        }
        public bool Login(string username, string pwd)
        {
            var result = mydb.Users.Count(x => x.userName == username && x.password == pwd);
            if (result > 0)
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
