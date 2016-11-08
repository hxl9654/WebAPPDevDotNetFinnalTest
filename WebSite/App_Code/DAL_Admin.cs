using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class DAL_Admin
{
    public Admin Admin_Select(Admin AdminUser)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "SELECT UserPassWordHash FROM [dbo].[Admin] WHERE UserName=@AdminUserName";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@AdminUserName", AdminUser.UserName));

        DataSet dataSet = new DataSet();
        SqlDataAdapter SQLDataAdapter = new SqlDataAdapter(SQLCommand);

        SQLConnection.Open();
        SQLDataAdapter.Fill(dataSet);
        SQLConnection.Close();

        Admin SelectResult = new Admin();
        SelectResult.UserID = Int32.Parse(dataSet.Tables["Admin"].Rows[0]["UserID"].ToString());
        SelectResult.UserName = dataSet.Tables["Admin"].Rows[0]["UserName"].ToString();
        SelectResult.UserPassWordHash = dataSet.Tables["Admin"].Rows[0]["UserPassWordHash"].ToString();
        return SelectResult;
    }
    public void Admin_Update(Admin AdminUser)
    {
        string SQLServerConnectString = "Data Source=localhost;Initial Catalog=WebAPPDevDotNETFinnalTest;Integrated Security=True;Pooling=False";
        SqlConnection SQLConnection = new SqlConnection(SQLServerConnectString);
        string SQLCommandText = "UPDATE [dbo].[Admin] SET [UserPassWordHash]=@UserPassWordHash WHERE [UserName]=@UserName";
        SqlCommand SQLCommand = new SqlCommand(SQLCommandText, SQLConnection);
        SQLCommand.Parameters.Add(new SqlParameter("@AdminUserName", AdminUser.UserName));
        SQLCommand.Parameters.Add(new SqlParameter("@UserPassWordHash", AdminUser.UserPassWordHash));
        SQLConnection.Open();
        SQLCommand.ExecuteNonQuery();
        SQLConnection.Close();
    }
}