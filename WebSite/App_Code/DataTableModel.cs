using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Stock
{
    public int StockID{ get; set; }
    public int SellerID{ get; set; }
    public int ModelID{ get; set; }
    public int Quantity{ get; set; }
}
public class Model
{
    public int ModelID{ get; set; }
    public int BrandID{ get; set; }
    public string ModelName{ get; set; }
    public string Color{ get; set; }
    public string Picture{ get; set; }
    public string Info{ get; set; }
}
public class Brand
{
    public int BrandID{ get; set; }
    public string BrandName{ get; set; }
    public string ProductAddress{ get; set; }
}
public class SellerUser
{
    public int UserID{ get; set; }
    public int SellerID{ get; set; }
    public string UserName{ get; set; }
    public string UserPassWordHash{ get; set; }
    public string Email{ get; set; }
    public string Phone{ get; set; }
    public string PassWordSalt{ get; set; }
}
public class SellerInfo
{
    public int SellerID{ get; set; }
    public string Phone{ get; set; }
    public string Name{ get; set; }
    public string Provience{ get; set; }
    public string City{ get; set; }
    public string Address{ get; set; }
    public string Level{ get; set; }
    public int ParentSellerID{ get; set; }
}
public class Admin
{
    public int UserID{ get; set; }
    public string UserName{ get; set; }
    public string UserPassWordHash{ get; set; }
    public string PassWordSalt{ get; set; }
}
public class SellerOpreateLog
{
    public int ID { get; set; }
    public int SellerID { get; set; }
    public int UserID { get; set; }
    public int Quantity { get; set; }
    public int Object { get; set; }
    public int ModelID { get; set; }
    public string Opreate { get; set; }  
}