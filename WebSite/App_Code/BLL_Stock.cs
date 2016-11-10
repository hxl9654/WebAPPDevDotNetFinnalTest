using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class BLL_Stock
{
    public void New(int ModelID, int SellerID, int Quantity)
    {
        Stock stock = new Stock();
        stock.ModelID = ModelID;
        stock.SellerID = SellerID;
        stock.Quantity = Quantity;
        DAL_Stock StockDAL = new DAL_Stock();
        StockDAL.Insert(stock);
    }
    public Stock SelectOne(int SellerID, int ModelID)
    {
        Stock stock = new Stock();
        stock.SellerID = SellerID;
        stock.ModelID = ModelID;
        DAL_Stock StockDAL = new DAL_Stock();
        return StockDAL.SelectOne(stock);
    }
    public Stock SelectOne(int StockID)
    {
        Stock stock = new Stock();
        stock.StockID = StockID;
        DAL_Stock StockDAL = new DAL_Stock();
        return StockDAL.SelectOne(stock, 1);
    }
    public List<Stock> SelectBySellerID(int SellerID)
    {
        Stock stock = new Stock();
        stock.SellerID = SellerID;
        DAL_Stock StockDAL = new DAL_Stock();
        return StockDAL.SelectBySellerID(stock);
    }
    public void Delete(int StockID)
    {
        Stock stock = new Stock();
        stock.StockID = StockID;
        DAL_Stock StockDAL = new DAL_Stock();
        StockDAL.Delete(stock);
    }
    public void Update(int StockID, int ModelID, int SellerID, int Quantity)
    {
        Stock stock = new Stock();
        stock.StockID = StockID;
        stock.ModelID = ModelID;
        stock.SellerID = SellerID;
        stock.Quantity = Quantity;
        DAL_Stock StockDAL = new DAL_Stock();
        StockDAL.Update(stock);
    }
}