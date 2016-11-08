﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DAL_SellerUser
{
    public SellerUser SelectOne(SellerUser sellerUser)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[SellerUser] WHERE UserID=@UserID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@UserID", sellerUser.UserID));

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        SellerUser SelectResult = new SellerUser();
        if (dataSet.Tables["SellerUser"].Rows.Count == 0)
            return null;
        SelectResult.UserID = Int32.Parse(dataSet.Tables["SellerUser"].Rows[0]["UserID"].ToString());
        SelectResult.SellerID = Int32.Parse(dataSet.Tables["SellerUser"].Rows[0]["SellerID"].ToString());
        SelectResult.Phone = dataSet.Tables["SellerUser"].Rows[0]["Phone"].ToString();
        SelectResult.Email = dataSet.Tables["SellerUser"].Rows[0]["Email"].ToString();
        SelectResult.UserName = dataSet.Tables["SellerUser"].Rows[0]["UserName"].ToString();
        SelectResult.UserPassWordHash = dataSet.Tables["SellerUser"].Rows[0]["UserPassWordHash"].ToString();
        return SelectResult;
    }
    public List<SellerUser> SelectAll(SellerUser sellerUser)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[SellerUser] WHERE SellerID=@SellerID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@SellerID", sellerUser.SellerID));

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        List<SellerUser> SelectResult = new List<SellerUser>();
        for (int i = 0; i < dataSet.Tables["SellerUser"].Rows.Count; i++)
        {
            SellerUser temp = new SellerUser();
            temp.UserID = Int32.Parse(dataSet.Tables["SellerUser"].Rows[i]["UserID"].ToString());
            temp.SellerID = Int32.Parse(dataSet.Tables["SellerUser"].Rows[i]["SellerID"].ToString());
            temp.Phone = dataSet.Tables["SellerUser"].Rows[i]["Phone"].ToString();
            temp.Email = dataSet.Tables["SellerUser"].Rows[i]["Email"].ToString();
            temp.UserName = dataSet.Tables["SellerUser"].Rows[i]["UserName"].ToString();
            temp.UserPassWordHash = dataSet.Tables["SellerUser"].Rows[i]["UserPassWordHash"].ToString();
            SelectResult.Add(temp);
        }
        return SelectResult;
    }
    public void Update(SellerUser sellerUser)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "UPDATE [dbo].[SellerUser] SET [Phone]=@Phone,[Email]=@Email,[UserName]=@UserName,[UserPassWordHash]=@UserPassWordHash WHERE [UserID]=@UserID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@UserID", sellerUser.UserID));
        SQLCommand.Parameters.Add(new SqlParameter("@Phone", sellerUser.Phone));
        SQLCommand.Parameters.Add(new SqlParameter("@Email", sellerUser.Email));
        SQLCommand.Parameters.Add(new SqlParameter("@UserName", sellerUser.UserName));
        SQLCommand.Parameters.Add(new SqlParameter("@UserPassWordHash", sellerUser.UserPassWordHash));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Insert(SellerUser sellerUser)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "INSERT INTO [dbo].[SellerUser] ([SellerID], [Phone], [Email], [UserName], [UserPassWordHash]) VALUES (@SellerID, @Phone, @Email, @UserName, @UserPassWordHash)";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@SellerID", sellerUser.SellerID));
        SQLCommand.Parameters.Add(new SqlParameter("@Phone", sellerUser.Phone));
        SQLCommand.Parameters.Add(new SqlParameter("@Email", sellerUser.Email));
        SQLCommand.Parameters.Add(new SqlParameter("@UserName", sellerUser.UserName));
        SQLCommand.Parameters.Add(new SqlParameter("@UserPassWordHash", sellerUser.UserPassWordHash));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Delete(SellerUser sellerUser)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "DELETE [dbo].[SellerUser] where [UserID] = @UserID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@UserID", sellerUser.UserID));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
}