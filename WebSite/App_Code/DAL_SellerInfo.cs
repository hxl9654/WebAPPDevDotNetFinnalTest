using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DAL_SellerInfo
{
    public SellerInfo SelectOne(SellerInfo sellerInfo)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[SellerInfo] WHERE SellerID=@SellerID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@SellerID", sellerInfo.SellerID));

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        SellerInfo SelectResult = new SellerInfo();
        if (dataSet.Tables[0].Rows.Count == 0)
            return null;
        SelectResult.SellerID = Int32.Parse(dataSet.Tables[0].Rows[0]["SellerID"].ToString());
        SelectResult.ParentSellerID = Int32.Parse(dataSet.Tables[0].Rows[0]["ParentSellerID"].ToString());
        SelectResult.Level = dataSet.Tables[0].Rows[0]["Level"].ToString();
        SelectResult.Phone = dataSet.Tables[0].Rows[0]["Phone"].ToString();
        SelectResult.Name = dataSet.Tables[0].Rows[0]["Name"].ToString();
        SelectResult.Provience = dataSet.Tables[0].Rows[0]["Provience"].ToString();
        SelectResult.City = dataSet.Tables[0].Rows[0]["City"].ToString();
        SelectResult.Address = dataSet.Tables[0].Rows[0]["Address"].ToString();
        return SelectResult;
    }
    public List<SellerInfo> SelectByParentSellerID(SellerInfo sellerInfo)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[SellerInfo] WHERE ParentSellerID=@ParentSellerID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@ParentSellerID", sellerInfo.ParentSellerID));

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        List<SellerInfo> SelectResult = new List<SellerInfo>();
        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        {
            SellerInfo temp = new SellerInfo();
            temp.SellerID = Int32.Parse(dataSet.Tables[0].Rows[i]["SellerID"].ToString());
            temp.ParentSellerID = Int32.Parse(dataSet.Tables[0].Rows[i]["ParentSellerID"].ToString());
            temp.Level = dataSet.Tables[0].Rows[i]["Level"].ToString();
            temp.Phone = dataSet.Tables[0].Rows[i]["Phone"].ToString();
            temp.Name = dataSet.Tables[0].Rows[i]["Name"].ToString();
            temp.Provience = dataSet.Tables[0].Rows[i]["Provience"].ToString();
            temp.City = dataSet.Tables[0].Rows[i]["City"].ToString();
            temp.Address = dataSet.Tables[0].Rows[i]["Address"].ToString();
            SelectResult.Add(temp);
        }
        return SelectResult;
    }
    public List<SellerInfo> SelectAll(bool root = false)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[SellerInfo]";
        if(!root)
            SQLCommandText += "where SellerID != 0";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        List<SellerInfo> SelectResult = new List<SellerInfo>();
        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        {
            SellerInfo temp = new SellerInfo();
            temp.SellerID = Int32.Parse(dataSet.Tables[0].Rows[i]["SellerID"].ToString());
            temp.ParentSellerID = Int32.Parse(dataSet.Tables[0].Rows[i]["ParentSellerID"].ToString());
            temp.Level = dataSet.Tables[0].Rows[i]["Level"].ToString();
            temp.Phone = dataSet.Tables[0].Rows[i]["Phone"].ToString();
            temp.Name = dataSet.Tables[0].Rows[i]["Name"].ToString();
            temp.Provience = dataSet.Tables[0].Rows[i]["Provience"].ToString();
            temp.City = dataSet.Tables[0].Rows[i]["City"].ToString();
            temp.Address = dataSet.Tables[0].Rows[i]["Address"].ToString();
            SelectResult.Add(temp);
        }
        return SelectResult;
    }
    public void Update(SellerInfo sellerInfo)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "UPDATE [dbo].[SellerInfo] SET [Phone]=@Phone,[Provience]=@Provience,[City]=@City,[Address]=@Address,[Name]=@Name,[Level]=@Level,[ParentSellerID]=@ParentSellerID WHERE [SellerID]=@SellerID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@SellerID", sellerInfo.SellerID));
        SQLCommand.Parameters.Add(new SqlParameter("@Phone", sellerInfo.Phone));
        SQLCommand.Parameters.Add(new SqlParameter("@Provience", sellerInfo.Provience));
        SQLCommand.Parameters.Add(new SqlParameter("@City", sellerInfo.City));
        SQLCommand.Parameters.Add(new SqlParameter("@Address", sellerInfo.Address));
        SQLCommand.Parameters.Add(new SqlParameter("@Name", sellerInfo.Name));
        SQLCommand.Parameters.Add(new SqlParameter("@Level", sellerInfo.Level));
        SQLCommand.Parameters.Add(new SqlParameter("@ParentSellerID", sellerInfo.ParentSellerID));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Insert(SellerInfo sellerInfo)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "INSERT INTO [dbo].[SellerInfo] ([Phone], [Provience], [City], [Address], [Name], [Level], [ParentSellerID]) VALUES (@Phone, @Provience, @City, @Address, @Name, @Level, @ParentSellerID)";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@Phone", sellerInfo.Phone));
        SQLCommand.Parameters.Add(new SqlParameter("@Provience", sellerInfo.Provience));
        SQLCommand.Parameters.Add(new SqlParameter("@City", sellerInfo.City));
        SQLCommand.Parameters.Add(new SqlParameter("@Address", sellerInfo.Address));
        SQLCommand.Parameters.Add(new SqlParameter("@Name", sellerInfo.Name));
        SQLCommand.Parameters.Add(new SqlParameter("@Level", sellerInfo.Level));
        SQLCommand.Parameters.Add(new SqlParameter("@ParentSellerID", sellerInfo.ParentSellerID));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Delete(SellerInfo sellerInfo)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "DELETE [dbo].[SellerInfo] where [SellerID] = @SellerID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@SellerID", sellerInfo.SellerID));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
}