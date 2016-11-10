using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DAL_SellerOpreateLog
{
    public List<SellerOpreateLog> SelectBySellerID(SellerOpreateLog sellerOpreateLog)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[SellerOpreateLog] where SellerID=@SellerID ORDER BY ID DESC";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@SellerID", sellerOpreateLog.SellerID));

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        List<SellerOpreateLog> SelectResult = new List<SellerOpreateLog>();
        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        {
            SellerOpreateLog temp = new SellerOpreateLog();
            temp.ID = Int32.Parse(dataSet.Tables[0].Rows[i]["ID"].ToString());
            temp.SellerID = Int32.Parse(dataSet.Tables[0].Rows[i]["SellerID"].ToString());
            temp.UserID = Int32.Parse(dataSet.Tables[0].Rows[i]["UserID"].ToString());
            temp.Quantity = Int32.Parse(dataSet.Tables[0].Rows[i]["Quantity"].ToString());
            temp.Object = Int32.Parse(dataSet.Tables[0].Rows[i]["Object"].ToString());
            temp.Opreate = dataSet.Tables[0].Rows[i]["Opreate"].ToString();
            temp.ModelID = Int32.Parse(dataSet.Tables[0].Rows[i]["ModelID"].ToString());
            SelectResult.Add(temp);
        }
        return SelectResult;
    }
    public List<SellerOpreateLog> SelectAll()
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[SellerOpreateLog]";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        List<SellerOpreateLog> SelectResult = new List<SellerOpreateLog>();
        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        {
            SellerOpreateLog temp = new SellerOpreateLog();
            temp.ID = Int32.Parse(dataSet.Tables[0].Rows[i]["ID"].ToString());
            temp.SellerID = Int32.Parse(dataSet.Tables[0].Rows[i]["SellerID"].ToString());
            temp.UserID = Int32.Parse(dataSet.Tables[0].Rows[i]["UserID"].ToString());
            temp.Quantity = Int32.Parse(dataSet.Tables[0].Rows[i]["Quantity"].ToString());
            temp.Object = Int32.Parse(dataSet.Tables[0].Rows[i]["Object"].ToString());
            temp.Opreate = dataSet.Tables[0].Rows[i]["Opreate"].ToString();
            temp.ModelID = Int32.Parse(dataSet.Tables[0].Rows[i]["ModelID"].ToString());
            SelectResult.Add(temp);
        }
        return SelectResult;
    }
    public void Insert(SellerOpreateLog sellerOpreateLog)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "INSERT INTO [dbo].[SellerOpreateLog] ([ModelID], [SellerID], [UserID], [Quantity], [Object], [Opreate]) VALUES (@ModelID, @SellerID, @UserID, @Quantity, @Object, @Opreate)";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@ModelID", sellerOpreateLog.ModelID));
        SQLCommand.Parameters.Add(new SqlParameter("@SellerID", sellerOpreateLog.SellerID));
        SQLCommand.Parameters.Add(new SqlParameter("@UserID", sellerOpreateLog.UserID));
        SQLCommand.Parameters.Add(new SqlParameter("@Quantity", sellerOpreateLog.Quantity));
        SQLCommand.Parameters.Add(new SqlParameter("@Object", sellerOpreateLog.Object));
        SQLCommand.Parameters.Add(new SqlParameter("@Opreate", sellerOpreateLog.Opreate));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
}