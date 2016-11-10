using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

public class BLL_Admin
{
    public Admin Login(string UserName, string PasswordHashWithTimeStampFromClient, long TimeStamp)
    {
        Admin admin = new Admin();
        admin.UserName = UserName;
        DAL_Admin AdminDAL = new DAL_Admin();
        admin = AdminDAL.SelectOne(admin);
        //判断用户是否存在
        if (admin == null)
            return null;
        //判断时间戳是否过期
        if (DateTime.Now.CompareTo(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(TimeStamp).AddMinutes(5).ToLocalTime()) > 0)
            return null;
        //计算正确的密码HASH
        string PassWordHash = admin.UserPassWordHash + ":" + TimeStamp.ToString();
        byte[] PassWordHashByteArray = System.Text.Encoding.Default.GetBytes(PassWordHash);
        string PasswordHashWithTimeStampFromServer = BitConverter.ToString(SHA256.Create().ComputeHash(PassWordHashByteArray)).Replace("-", "").ToUpper();
        //检验计算出的HASH与浏览器提交的HASH是否一致
        if (!PasswordHashWithTimeStampFromServer.Equals(PasswordHashWithTimeStampFromClient))
            return null;

        //所有检查通过，允许登录
        return admin;
    }
    public bool ChangePassword(string UserName, string PasswordHashWithTimeStampFromClient, long TimeStamp, string NewPassWordHash)
    {
        Admin admin = Login(UserName, PasswordHashWithTimeStampFromClient, TimeStamp);
        if (admin != null)
        {
            admin.PassWordSalt = UserName + "dcLDJf8f8iHlS6LExCAj";
            admin.UserPassWordHash = NewPassWordHash;
            DAL_Admin AdminDAL = new DAL_Admin();
            AdminDAL.Update(admin);
            return true;
        }
        else return false;
    }
}