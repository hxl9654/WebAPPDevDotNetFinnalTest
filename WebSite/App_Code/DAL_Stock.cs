using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DAL_Stock
{
    public Stock SelectOne(Stock stock)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[Stock] WHERE StockID=@StockID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@StockID", stock.StockID));

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        Stock SelectResult = new Stock();
        SelectResult.StockID = Int32.Parse(dataSet.Tables["Stock"].Rows[0]["StockID"].ToString());
        SelectResult.ModelID = Int32.Parse(dataSet.Tables["Stock"].Rows[0]["ModelID"].ToString());
        SelectResult.SellerID = Int32.Parse(dataSet.Tables["Stock"].Rows[0]["SellerID"].ToString());
        SelectResult.Quantity = Int32.Parse(dataSet.Tables["Stock"].Rows[0]["Quantity"].ToString());
        return SelectResult;
    }
    public List<Stock> SelectAll()
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[Stock]";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        List<Stock> SelectResult = new List<Stock>();
        for (int i = 0; i < dataSet.Tables["Stock"].Rows.Count; i++)
        {
            Stock temp = new Stock();
            temp.StockID = Int32.Parse(dataSet.Tables["Stock"].Rows[i]["StockID"].ToString());
            temp.ModelID = Int32.Parse(dataSet.Tables["Stock"].Rows[i]["ModelID"].ToString());
            temp.SellerID = Int32.Parse(dataSet.Tables["Stock"].Rows[i]["SellerID"].ToString());
            temp.Quantity = Int32.Parse(dataSet.Tables["Stock"].Rows[i]["Quantity"].ToString());
            SelectResult.Add(temp);
        }
        return SelectResult;
    }
    public void Update(Stock stock)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "UPDATE [dbo].[Stock] SET [Quantity]=@Quantity WHERE [StockID]=@StockID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@StockID", stock.StockID));
        SQLCommand.Parameters.Add(new SqlParameter("@Quantity", stock.Quantity));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Insert(Stock stock)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "INSERT INTO [dbo].[Stock] ([SellerID], [ModelID], [Quantity]) VALUES (@SellerID, @ModelID, @Quantity)";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@SellerID", stock.SellerID));
        SQLCommand.Parameters.Add(new SqlParameter("@ModelID", stock.ModelID));
        SQLCommand.Parameters.Add(new SqlParameter("@Quantity", stock.Quantity));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Delete(Stock stock)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "DELETE [dbo].[Stock] where [StockID] = @StockID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@StockID", stock.StockID));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
}