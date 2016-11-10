using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

public class BLL_SellerUser
{
    public void New(int SellerID, string UserName, string UserPassWordHash, string Email, string Phone, string PassWordSalt = null)
    {
        if (PassWordSalt == null)
            PassWordSalt = UserName + "dcLDJf8f8iHlS6LExCAj";
        SellerUser sellseruser = new SellerUser();
        sellseruser.SellerID = SellerID;
        sellseruser.UserName = UserName;
        sellseruser.UserPassWordHash = UserPassWordHash;
        sellseruser.Email = Email;
        sellseruser.Phone = Phone;
        sellseruser.PassWordSalt = PassWordSalt;
        DAL_SellerUser SellerUserDAL = new DAL_SellerUser();
        SellerUserDAL.Insert(sellseruser);
    }
    public SellerUser Login(string UserName, string PasswordHashWithTimeStampFromClient, long TimeStamp)
    {
        SellerUser sellerUser = new SellerUser();
        sellerUser.UserName = UserName;
        DAL_SellerUser SellerUserDAL = new DAL_SellerUser();
        sellerUser = SellerUserDAL.SelectOne(sellerUser, 1);
        //判断用户是否存在
        if (sellerUser == null)
            return null;
        //判断时间戳是否过期
        if (DateTime.Now.CompareTo(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(TimeStamp).AddMinutes(5).ToLocalTime()) > 0)
            return null;
        //计算正确的密码HASH
        string PassWordHash = sellerUser.UserPassWordHash + ":" + TimeStamp.ToString();
        byte[] PassWordHashByteArray = System.Text.Encoding.Default.GetBytes(PassWordHash);
        string PasswordHashWithTimeStampFromServer = BitConverter.ToString(SHA256.Create().ComputeHash(PassWordHashByteArray)).Replace("-", "").ToUpper();
        //检验计算出的HASH与浏览器提交的HASH是否一致
        if (!PasswordHashWithTimeStampFromServer.Equals(PasswordHashWithTimeStampFromClient))
            return null;

        //所有检查通过，允许登录
        return sellerUser;
    }
    public SellerUser SelectOne(int UserID)
    {
        SellerUser sellseruser = new SellerUser();
        sellseruser.UserID = UserID;
        DAL_SellerUser SellerUserDAL = new DAL_SellerUser();
        return SellerUserDAL.SelectOne(sellseruser);
    }
    public List<SellerUser> SelectBySellerID(int SellerID)
    {
        SellerUser sellseruser = new SellerUser();
        sellseruser.SellerID = SellerID;
        DAL_SellerUser SellerUserDAL = new DAL_SellerUser();
        return SellerUserDAL.SelectAll(sellseruser);
    }
    public void Delete(int UserID)
    {
        SellerUser sellseruser = new SellerUser();
        sellseruser.UserID = UserID;
        DAL_SellerUser SellerUserDAL = new DAL_SellerUser();
        SellerUserDAL.Delete(sellseruser);
    }
    public void Update(int UserID, int SellerID, string UserName, string UserPassWordHash, string Email, string Phone, string PassWordSalt = null)
    {
        if (PassWordSalt == null)
            PassWordSalt = UserName + "dcLDJf8f8iHlS6LExCAj";
        SellerUser sellseruser = new SellerUser();
        sellseruser.UserID = UserID;
        sellseruser.SellerID = SellerID;
        sellseruser.UserName = UserName;
        sellseruser.UserPassWordHash = UserPassWordHash;
        sellseruser.Email = Email;
        sellseruser.Phone = Phone;
        sellseruser.PassWordSalt = PassWordSalt;
        DAL_SellerUser SellerUserDAL = new DAL_SellerUser();
        SellerUserDAL.Update(sellseruser);
    }
}