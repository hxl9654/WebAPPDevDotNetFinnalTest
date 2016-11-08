using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Stock
{
    public int StockID;
    public int SellerID;
    public int ModelID;
    public int Quantity;
}
public class Model
{
    public int ModelID;
    public int BrandID;
    public string ModelName;
    public string Color;
    public string Picture;
    public string Info;
}
public class Brand
{
    public int BrandID;
    public string BrandName;
    public string ProductAddress;
}
public class SellerUser
{
    public int UserID;
    public int SellerID;
    public string UserName;
    public string UserPassWordHash;
    public string Email;
    public string Phone;
    public string PassWordSalt;
}
public class SellerInfo
{
    public int SellerID;
    public string Phone;
    public string Name;
    public string Provience;
    public string City;
    public string Address;
    public string Level;
    public int ParentSellerID;
}
public class Admin
{
    public int UserID;
    public string UserName;
    public string UserPassWordHash;
    public string PassWordSalt;
}