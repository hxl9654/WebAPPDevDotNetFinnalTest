﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DAL_Model
{
    public Model SelectOne(Model model)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[Model] WHERE ModelID=@ModelID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@ModelID", model.ModelID));

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        Model SelectResult = new Model();
        if (dataSet.Tables[0].Rows.Count == 0)
            return null;
        SelectResult.ModelID = Int32.Parse(dataSet.Tables[0].Rows[0]["ModelID"].ToString());
        SelectResult.BrandID = Int32.Parse(dataSet.Tables[0].Rows[0]["BrandID"].ToString());
        SelectResult.ModelName = dataSet.Tables[0].Rows[0]["ModelName"].ToString();
        SelectResult.Picture = dataSet.Tables[0].Rows[0]["Picture"].ToString();
        SelectResult.Color = dataSet.Tables[0].Rows[0]["Color"].ToString();
        SelectResult.Info = dataSet.Tables[0].Rows[0]["Info"].ToString();
        return SelectResult;
    }
    public List<Model> SelectByBrandID(Model model)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[Model] WHERE BrandID=@BrandID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@BrandID", model.BrandID));

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        List<Model> SelectResult = new List<Model>();
        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        {
            Model temp = new Model();
            temp.ModelID = Int32.Parse(dataSet.Tables[0].Rows[i]["ModelID"].ToString());
            temp.BrandID = Int32.Parse(dataSet.Tables[0].Rows[i]["BrandID"].ToString());
            temp.ModelName = dataSet.Tables[0].Rows[i]["ModelName"].ToString();
            temp.Picture = dataSet.Tables[0].Rows[i]["Picture"].ToString();
            temp.Color = dataSet.Tables[0].Rows[i]["Color"].ToString();
            temp.Info = dataSet.Tables[0].Rows[i]["Info"].ToString();
            SelectResult.Add(temp);
        }
        return SelectResult;
    }
    public List<Model> SelectAll()
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[Model]";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        List<Model> SelectResult = new List<Model>();
        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        {
            Model temp = new Model();
            temp.ModelID = Int32.Parse(dataSet.Tables[0].Rows[i]["ModelID"].ToString());
            temp.BrandID = Int32.Parse(dataSet.Tables[0].Rows[i]["BrandID"].ToString());
            temp.ModelName = dataSet.Tables[0].Rows[i]["ModelName"].ToString();
            temp.Picture = dataSet.Tables[0].Rows[i]["Picture"].ToString();
            temp.Color = dataSet.Tables[0].Rows[i]["Color"].ToString();
            temp.Info = dataSet.Tables[0].Rows[i]["Info"].ToString();
            SelectResult.Add(temp);
        }
        return SelectResult;
    }
    public void Update(Model model)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "UPDATE [dbo].[Model] SET [ModelName]=@ModelName,[Picture]=@Picture,[Color]=@Color,[Info]=@Info WHERE [ModelID]=@ModelID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@ModelID", model.ModelID));
        SQLCommand.Parameters.Add(new SqlParameter("@Info", model.Info));
        SQLCommand.Parameters.Add(new SqlParameter("@ModelName", model.ModelName));
        SQLCommand.Parameters.Add(new SqlParameter("@Color", model.Color));
        SQLCommand.Parameters.Add(new SqlParameter("@Picture", model.Picture));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Insert(Model model)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "INSERT INTO [dbo].[Model] ([BrandID], [Info], [ModelName], [Color], [Picture]) VALUES (@BrandID, @Info, @ModelName, @Color, @Picture)";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@BrandID", model.BrandID));
        SQLCommand.Parameters.Add(new SqlParameter("@Info", model.Info));
        SQLCommand.Parameters.Add(new SqlParameter("@ModelName", model.ModelName));
        SQLCommand.Parameters.Add(new SqlParameter("@Color", model.Color));
        SQLCommand.Parameters.Add(new SqlParameter("@Picture", model.Picture));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Delete(Model model)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "DELETE [dbo].[Model] where [ModelID] = @ModelID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@ModelID", model.ModelID));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
}