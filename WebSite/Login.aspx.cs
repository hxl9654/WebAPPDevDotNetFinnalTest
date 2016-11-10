using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] != null)
            Response.Redirect("Admin_SellerManage.aspx");
        if (Session["UserID"] != null&&Session["SellerID"] != null)
            Response.Redirect("Seller.aspx");
        if(!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null)
            {
                TextBoxUserName.Text = Request.Cookies["UserName"].Value;
                CheckBoxRememberUserName.Checked = true;
            }                
        }
    }

    protected void ButtonAdminLogin_Click(object sender, EventArgs e)
    {
        if(CheckBoxRememberUserName.Checked)
        {
            Response.Cookies["UserName"].Value = TextBoxUserName.Text;
            Response.Cookies["UserName"].Expires = DateTime.Now.AddYears(1);
        }
        else Response.Cookies["UserName"].Expires = DateTime.Now.AddYears(-1);
        if (TextBoxUserName.Text != null && TextBoxPassWord.Text != null && HiddenFieldTimeStamp.Value != null)
        {
            Admin admin = (new BLL_Admin()).Login(TextBoxUserName.Text, TextBoxPassWord.Text, Int64.Parse(HiddenFieldTimeStamp.Value));
            if (admin != null)
            {
                Session["AdminID"] = admin.UserID;
                Session["AdminName"] = admin.UserName;
                Session.Timeout = 10;
                Response.Redirect("Admin_SellerManage.aspx");
            }
            else LabelWrongPassWordSign.Text = "密码错误，请重新输入";
        }
    }

    protected void ButtonSellerLogin_Click(object sender, EventArgs e)
    {
        if (TextBoxUserName.Text != null && TextBoxPassWord.Text != null && HiddenFieldTimeStamp.Value != null)
        {
            SellerUser sellerUser = (new BLL_SellerUser()).Login(TextBoxUserName.Text, TextBoxPassWord.Text, Int64.Parse(HiddenFieldTimeStamp.Value));
            if (sellerUser != null)
            {
                Session["UserID"] = sellerUser.UserID;
                Session["SellerID"] = sellerUser.SellerID;
                Session["UserName"] = sellerUser.UserName;
                Session["SellerName"]= (new BLL_SellerInfo()).SelectOne(sellerUser.SellerID).Name;
                Session.Timeout = 10;
                Response.Redirect("Seller.aspx");
            }
            else LabelWrongPassWordSign.Text = "密码错误，请重新输入";
        }
    }
}
