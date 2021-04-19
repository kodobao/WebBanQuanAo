using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanQuanAo.Common
{
    [Serializable]  // Đối tượng được tuần tự hóa khi dk gán session
    public class UserLogin
    {
        public int UserID { get; set; }
        public string UserName { get; set; }

    }
}