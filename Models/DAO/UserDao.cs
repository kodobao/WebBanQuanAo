using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.EntityFramework;

namespace Models.DAO
{
    public class UserDao
    {
        private WebBanQuanAoDbContext db = null;

        public UserDao()
        {
            db = new WebBanQuanAoDbContext();
        }

        /// <summary>
        /// Đăng nhập 
        /// 1. Đăng nhập thành công
        /// 0. Tài khoản không tồn tại
        /// -1. Không được phép truy cập
        /// -2. Sai mật khẩu
        /// </summary>
        /// <param name="user"></param>
        /// <returns>int</returns>
        public int Login (string Username, string Password)
        {
            var us = db.QUANLies.SingleOrDefault(x => x.username == Username);
            if (us != null)
            {
                if (us.password == Password)
                {
                    if (us.Allower == 1)
                    {
                        return 1;  // Đăng nhập thành công
                    }
                    else
                        return -1;
                }
                else
                    return -2;
            }
            else
                return 0;
        }

        /// <summary>
        /// Hiện thị danh sách người quản trị (trừ người đang sử dụng)
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public List<QUANLY> GetAll (string admin)
        {
            var ls = db.QUANLies.Where(x => x.username != admin).ToList();
            return ls;
        }

        /// <summary>
        /// Tạo tài khoản Admin
        /// false . Tồn tại username or email
        /// true. Thêm thành công
        /// </summary>
        /// <param name="user"></param>
        /// <returns>bool</returns>
        public bool Insert (QUANLY user)
        {
            var us = db.QUANLies.SingleOrDefault(x => x.username == user.username || x.email == user.email);
            if (us != null)
                return false;
            else
            {
                db.QUANLies.Add(user);
                db.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Updae (QUANLY user)
        {
            try
            {
                var us = db.QUANLies.Find(user.username);
                us.fullname = user.fullname;
                us.phone = user.phone;
                us.password = user.password;
                us.email = user.email;
                us.Allower = user.Allower;

                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Xóa tài khoản
        /// 1. Xóa thành công
        /// -1. Không được phép xóa
        /// 0. Tài khoản không tồn tại
        /// -2. Lỡi không xác định
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Delete (QUANLY user)
        {
            try
            {
                

                var us = db.QUANLies.Find(user.username);
                if (us != null)
                {
                    if (us.IsAdmin == 1 && us.Allower == 1)
                    {
                        return -1;
                    }
                    else
                    {
                        db.QUANLies.Remove(us);
                        db.SaveChanges();

                        return 1;
                    }
                }
                return 0;
            }
            catch(Exception)
            {
                return -2;
            }
            


        }


    }
}
