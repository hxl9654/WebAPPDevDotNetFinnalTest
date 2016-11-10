using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BLL_SellerOpreateLog
{
    public void New(int ModelID, int SellerID, int UserID, int ObjectID, int Quantity, string Opreate)
    {
        SellerOpreateLog sellerOpreateLog = new SellerOpreateLog();
        sellerOpreateLog.ModelID = ModelID;
        sellerOpreateLog.SellerID = SellerID;
        sellerOpreateLog.UserID = UserID;
        sellerOpreateLog.Object = ObjectID;
        sellerOpreateLog.Quantity = Quantity;
        sellerOpreateLog.Opreate = Opreate;
        DAL_SellerOpreateLog SellerOpreateLogDAL = new DAL_SellerOpreateLog();
        SellerOpreateLogDAL.Insert(sellerOpreateLog);
    }
    public List<SellerOpreateLog> SelectBySellerID(int SellerID)
    {
        SellerOpreateLog sellerOpreateLog = new SellerOpreateLog();
        sellerOpreateLog.SellerID = SellerID;
        DAL_SellerOpreateLog SellerOpreateLogDAL = new DAL_SellerOpreateLog();
        return SellerOpreateLogDAL.SelectBySellerID(sellerOpreateLog);
    }
    public List<SellerOpreateLog> SelectAll()
    {
        DAL_SellerOpreateLog SellerOpreateLogDAL = new DAL_SellerOpreateLog();
        return SellerOpreateLogDAL.SelectAll();
    }
}