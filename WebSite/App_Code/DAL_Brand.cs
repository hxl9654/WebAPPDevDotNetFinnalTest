using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DAL_Brand
{
    public Brand SelectOne(Brand brand)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[Brand] WHERE BrandID=@BrandID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@BrandID", brand.BrandID));

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        Brand SelectResult = new Brand();
        if (dataSet.Tables["Brand"].Rows.Count == 0)
            return null;
        SelectResult.BrandID = Int32.Parse(dataSet.Tables["Brand"].Rows[0]["BrandID"].ToString());
        SelectResult.BrandName = dataSet.Tables["Brand"].Rows[0]["BrandName"].ToString();
        SelectResult.ProductAddress = dataSet.Tables["Brand"].Rows[0]["ProductAddress"].ToString();
        return SelectResult;
    }
    public List<Brand> SelectAll()
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT * FROM [dbo].[Brand]";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        List<Brand> SelectResult = new List<Brand>();
        for (int i = 0; i < dataSet.Tables["Brand"].Rows.Count; i++)
        {
            Brand temp = new Brand();
            temp.BrandID = Int32.Parse(dataSet.Tables["Brand"].Rows[i]["BrandID"].ToString());
            temp.BrandName = dataSet.Tables["Brand"].Rows[i]["BrandName"].ToString();
            temp.ProductAddress = dataSet.Tables["Brand"].Rows[i]["ProductAddress"].ToString();
            SelectResult.Add(temp);
        }
        return SelectResult;
    }
    public void Update(Brand brand)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "UPDATE [dbo].[Brand] SET [BrandName]=@BrandName,[ProductAddress]=@ProductAddress WHERE [BrandID]=@BrandID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@BrandID", brand.BrandID));
        SQLCommand.Parameters.Add(new SqlParameter("@BrandName", brand.BrandName));
        SQLCommand.Parameters.Add(new SqlParameter("@ProductAddress", brand.ProductAddress));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Insert(Brand brand)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "INSERT INTO [dbo].[Brand] ([BrandID], [BrandName], [ProductAddress]) VALUES (@BrandID, @BrandName, @ProductAddress)";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@BrandID", brand.BrandID));
        SQLCommand.Parameters.Add(new SqlParameter("@BrandName", brand.BrandName));
        SQLCommand.Parameters.Add(new SqlParameter("@ProductAddress", brand.ProductAddress));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
    public void Delete(Brand brand)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "DELETE [dbo].[Brand] where [BrandID] = @BrandID";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@BrandID", brand.BrandID));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
}