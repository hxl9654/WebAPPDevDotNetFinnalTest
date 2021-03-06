﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DAL_Admin
{
    public Admin SelectOne(Admin admin)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[Admin] WHERE UserName=@UserName";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@UserName", admin.UserName));

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        Admin SelectResult = new Admin();
        if (dataSet.Tables[0].Rows.Count == 0)
            return null; 
        SelectResult.UserID = Int32.Parse(dataSet.Tables[0].Rows[0]["UserID"].ToString());
        SelectResult.UserName = dataSet.Tables[0].Rows[0]["UserName"].ToString();
        SelectResult.UserPassWordHash = dataSet.Tables[0].Rows[0]["UserPassWordHash"].ToString();
        SelectResult.PassWordSalt = dataSet.Tables[0].Rows[0]["PassWordSalt"].ToString();
        return SelectResult;
    }
    public List<Admin> SelectAll()
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[Admin]";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        List<Admin> SelectResult = new List<Admin>();
        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        {
            Admin temp = new Admin();
            temp.UserID = Int32.Parse(dataSet.Tables[0].Rows[i]["UserID"].ToString());
            temp.UserName = dataSet.Tables[0].Rows[i]["UserName"].ToString();
            temp.UserPassWordHash = dataSet.Tables[0].Rows[i]["UserPassWordHash"].ToString();
            SelectResult.Add(temp);
        }
        return SelectResult;
    }
    public void Update(Admin admin)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "UPDATE [dbo].[Admin] SET [UserName]=@UserName,[UserPassWordHash]=@UserPassWordHash WHERE [UserID]=@UserID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@AdminID", admin.UserID));
        SQLCommand.Parameters.Add(new SqlParameter("@adminName", admin.UserName));
        SQLCommand.Parameters.Add(new SqlParameter("@UserPassWordHash", admin.UserPassWordHash));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Insert(Admin admin)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "INSERT INTO [dbo].[Admin] ([UserName], [UserPassWordHash], [PassWordSalt]) VALUES (@UserName, @UserPassWordHash, @PassWordSalt)";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@UserName", admin.UserName));
        SQLCommand.Parameters.Add(new SqlParameter("@UserPassWordHash", admin.UserPassWordHash));
        SQLCommand.Parameters.Add(new SqlParameter("@UserPassWordHash", admin.PassWordSalt));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Delete(Admin admin)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "DELETE [dbo].[Admin] where [UserID] = @UserID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@UserID", admin.UserID));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
}