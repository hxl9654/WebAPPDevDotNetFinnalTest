using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BLL_SellerInfo
{
    public void New(string Name, string Provience, string City, string Address, string Phone, int ParentSellerID, string Level)
    {
        SellerInfo sellerInfo = new SellerInfo();
        sellerInfo.Name = Name;
        sellerInfo.Provience = Provience;
        sellerInfo.City = City;
        sellerInfo.Address = Address;
        sellerInfo.Phone = Phone;
        sellerInfo.ParentSellerID = ParentSellerID;
        sellerInfo.Level = Level;
        DAL_SellerInfo SellerInfoDAL = new DAL_SellerInfo();
        SellerInfoDAL.Insert(sellerInfo);
    }
    public SellerInfo SelectOne(int SellerID)
    {
        SellerInfo sellerInfo = new SellerInfo();
        sellerInfo.SellerID = SellerID;
        DAL_SellerInfo SellerInfoDAL = new DAL_SellerInfo();
        return SellerInfoDAL.SelectOne(sellerInfo);
    }
    public List<SellerInfo> SelectByParentSellerID(int ParentSellerID)
    {
        SellerInfo sellerInfo = new SellerInfo();
        sellerInfo.ParentSellerID = ParentSellerID;
        DAL_SellerInfo SellerInfoDAL = new DAL_SellerInfo();
        return SellerInfoDAL.SelectByParentSellerID(sellerInfo);
    }
    public List<SellerInfo> SelectAll(bool root = false)
    {
        DAL_SellerInfo SellerInfoDAL = new DAL_SellerInfo();
        return SellerInfoDAL.SelectAll(root);
    }
    public void Delete(int SellerID)
    {
        SellerInfo sellerInfo = new SellerInfo();
        sellerInfo.SellerID = SellerID;
        DAL_SellerInfo SellerInfoDAL = new DAL_SellerInfo();
        SellerInfoDAL.Delete(sellerInfo);
    }
    public void Update(int SellerID, string Name, string Provience, string City, string Address, string Phone, int ParentSellerID, string Level)
    {
        SellerInfo sellerInfo = new SellerInfo();
        sellerInfo.SellerID = SellerID;
        sellerInfo.Name = Name;
        sellerInfo.Provience = Provience;
        sellerInfo.City = City;
        sellerInfo.Address = Address;
        sellerInfo.Phone = Phone;
        sellerInfo.ParentSellerID = ParentSellerID;
        sellerInfo.Level = Level;
        DAL_SellerInfo SellerInfoDAL = new DAL_SellerInfo();
        SellerInfoDAL.Update(sellerInfo);
    }
}