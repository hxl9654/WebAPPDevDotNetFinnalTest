using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_SellerManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] == null)
            Response.Redirect("Login.aspx");
        else LabelWelcome.Text = "欢迎管理员 " + Session["AdminName"] + " 登录本系统！";
        if (!IsPostBack)
        {
            GridView1_FetchData();
        }
    }
    private void GridView1_FetchData()
    {
        GridView1.DataSource = (new BLL_SellerInfo()).SelectAll();
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        (new BLL_SellerInfo()).Delete(Int32.Parse((GridView1.Rows[e.RowIndex].FindControl("LabelSellerID") as Label).Text));
        GridView1_FetchData();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    }

    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        GridView1_FetchData();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        GridView1_FetchData();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1_FetchData();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SellerInfo sellerInfo = new SellerInfo();
        sellerInfo.SellerID = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("LabelSellerID") as Label).Text);
        sellerInfo.Name = (GridView1.Rows[e.RowIndex].FindControl("TextBoxName") as TextBox).Text;
        sellerInfo.Provience = (GridView1.Rows[e.RowIndex].FindControl("TextBoxProvience") as TextBox).Text;
        sellerInfo.City = (GridView1.Rows[e.RowIndex].FindControl("TextBoxCity") as TextBox).Text;
        sellerInfo.Phone = (GridView1.Rows[e.RowIndex].FindControl("TextBoxPhone") as TextBox).Text;
        sellerInfo.Address = (GridView1.Rows[e.RowIndex].FindControl("TextBoxAddress") as TextBox).Text;
        sellerInfo.Level = (GridView1.Rows[e.RowIndex].FindControl("DropDownListLevel") as DropDownList).Text;
        sellerInfo.ParentSellerID = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("DropDownListParentSellerID") as DropDownList).Text);
        (new BLL_SellerInfo()).Update(sellerInfo.SellerID, sellerInfo.Name, sellerInfo.Provience, sellerInfo.City, sellerInfo.Address, sellerInfo.Phone, sellerInfo.ParentSellerID, sellerInfo.Level);

        GridView1.EditIndex = -1;
        GridView1_FetchData();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SellerInfo temp = (new BLL_SellerInfo()).SelectOne(Int32.Parse((GridView1.SelectedRow.FindControl("LabelSellerID") as Label).Text));
        ChoosedSellerID = temp.SellerID;
        GridView2.Caption = "经销商 " + temp.Name + " 的用户";
        GridView2.ShowFooter = false;
        GridView2.EditIndex = -1;
        ButtonInsert2.Visible = true;
        //ButtonInsert.Visible = true;
        GridView2_FetchData();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("InsertCancel"))
        {
            GridView1.ShowFooter = false;
            GridView1_FetchData();
            ButtonInsert.Visible = true;
        }
        else if (e.CommandName.Equals("Insert"))
        {
            SellerInfo sellerInfo = new SellerInfo();
            sellerInfo.Name = (GridView1.FooterRow.FindControl("TextBoxName") as TextBox).Text;
            sellerInfo.Provience = (GridView1.FooterRow.FindControl("TextBoxProvience") as TextBox).Text;
            sellerInfo.City = (GridView1.FooterRow.FindControl("TextBoxCity") as TextBox).Text;
            sellerInfo.Phone = (GridView1.FooterRow.FindControl("TextBoxPhone") as TextBox).Text;
            sellerInfo.Address = (GridView1.FooterRow.FindControl("TextBoxAddress") as TextBox).Text;
            sellerInfo.Level = (GridView1.FooterRow.FindControl("DropDownListLevel") as DropDownList).Text;
            sellerInfo.ParentSellerID = Convert.ToInt32((GridView1.FooterRow.FindControl("DropDownListParentSellerID") as DropDownList).Text);
            (new BLL_SellerInfo()).New(sellerInfo.Name, sellerInfo.Provience, sellerInfo.City, sellerInfo.Address, sellerInfo.Phone, sellerInfo.ParentSellerID, sellerInfo.Level);

            GridView1.EditIndex = -1;
            GridView1_FetchData();
        }
    }

    protected void ButtonInsert_Click(object sender, EventArgs e)
    {
        GridView1.ShowFooter = true;
        GridView1_FetchData();
        ButtonInsert.Visible = false;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex == GridView1.EditIndex && e.Row.RowIndex != -1)
        {
            (e.Row.FindControl("DropDownListLevel") as DropDownList).Text = (e.Row.FindControl("TextBoxLevel") as TextBox).Text;

            (e.Row.FindControl("DropDownListParentSellerID") as DropDownList).DataTextField = "Name";
            (e.Row.FindControl("DropDownListParentSellerID") as DropDownList).DataValueField = "SellerID";
            (e.Row.FindControl("DropDownListParentSellerID") as DropDownList).DataSource = (new BLL_SellerInfo()).SelectAll();
            (e.Row.FindControl("DropDownListParentSellerID") as DropDownList).DataBind();
            (e.Row.FindControl("DropDownListParentSellerID") as DropDownList).Text = (e.Row.FindControl("TextBoxParentSellerID") as TextBox).Text;
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            (e.Row.FindControl("DropDownListParentSellerID") as DropDownList).DataTextField = "Name";
            (e.Row.FindControl("DropDownListParentSellerID") as DropDownList).DataValueField = "SellerID";
            (e.Row.FindControl("DropDownListParentSellerID") as DropDownList).DataSource = (new BLL_SellerInfo()).SelectAll();
            (e.Row.FindControl("DropDownListParentSellerID") as DropDownList).DataBind();
        }
        if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == -1)
        {
            SellerInfo temp = (new BLL_SellerInfo()).SelectOne(Int32.Parse((e.Row.FindControl("LabelParentSellerID") as Label).Text));
            if (temp != null)
                (e.Row.FindControl("LabelParentSellerID") as Label).Text = temp.Name;
            else (e.Row.FindControl("LabelParentSellerID") as Label).Text = "SellerID:" + (e.Row.FindControl("LabelParentSellerID") as Label).Text;
        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            ButtonInsert.Visible = false;
    }
    static int ChoosedSellerID = -1;
    private void GridView2_FetchData()
    {
        GridView2.DataSource = (new BLL_SellerUser()).SelectBySellerID(ChoosedSellerID);
        GridView2.DataBind();
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        (new BLL_SellerUser()).Delete(Int32.Parse((GridView2.Rows[e.RowIndex].FindControl("LabelUserID") as Label).Text));
        GridView2_FetchData();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
    }

    protected void GridView2_PageIndexChanged(object sender, EventArgs e)
    {
        GridView2_FetchData();
    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        GridView2_FetchData();

        (GridView2.Rows[e.NewEditIndex].FindControl("ButtonUpdate") as Button).Attributes.Add("OnClick", "return  GetPassWordHash_ButtonUpdate()");
    }

    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        GridView2_FetchData();
    }

    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SellerUser selleruser = new SellerUser();
        selleruser.UserID = Convert.ToInt32((GridView2.Rows[e.RowIndex].FindControl("LabelUserID") as Label).Text);
        selleruser.SellerID = ChoosedSellerID;
        selleruser.UserName = (GridView2.Rows[e.RowIndex].FindControl("LabelUserName") as Label).Text;
        selleruser.UserPassWordHash = (GridView2.Rows[e.RowIndex].FindControl("TextBoxUserPassWordHash") as TextBox).Text;
        selleruser.Email = (GridView2.Rows[e.RowIndex].FindControl("TextBoxEmail") as TextBox).Text;
        selleruser.Phone = (GridView2.Rows[e.RowIndex].FindControl("TextBoxPhone") as TextBox).Text;
        (new BLL_SellerUser()).Update(selleruser.UserID, selleruser.SellerID, selleruser.UserName, selleruser.UserPassWordHash, selleruser.Email, selleruser.Phone);

        GridView2.EditIndex = -1;
        GridView2_FetchData();
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("InsertCancel"))
        {
            GridView2.ShowFooter = false;
            GridView2_FetchData();
            ButtonInsert2.Visible = true;
        }
        else if (e.CommandName.Equals("Insert"))
        {
            SellerUser selleruser = new SellerUser();
            selleruser.SellerID = ChoosedSellerID;
            selleruser.UserName = (GridView2.FooterRow.FindControl("TextBoxUserName_Footer") as TextBox).Text;
            selleruser.UserPassWordHash = (GridView2.FooterRow.FindControl("TextBoxUserPassWordHash_Footer") as TextBox).Text;
            selleruser.Email = (GridView2.FooterRow.FindControl("TextBoxEmail") as TextBox).Text;
            selleruser.Phone = (GridView2.FooterRow.FindControl("TextBoxPhone") as TextBox).Text;
            (new BLL_SellerUser()).New(selleruser.SellerID, selleruser.UserName, selleruser.UserPassWordHash, selleruser.Email, selleruser.Phone);

            GridView2.EditIndex = -1;
            GridView2_FetchData();
        }
        else if (e.CommandName.Equals("EmptyAdd"))
        {
            GridViewRow row = (GridViewRow)(e.CommandSource as Button).NamingContainer;
            SellerUser selleruser = new SellerUser();
            selleruser.SellerID = ChoosedSellerID;
            selleruser.UserName = (row.FindControl("TextBoxUserName_Empty") as TextBox).Text;
            selleruser.UserPassWordHash = (row.FindControl("TextBoxUserPassWordHash_Empty") as TextBox).Text;
            selleruser.Email = (row.FindControl("TextBoxEmail") as TextBox).Text;
            selleruser.Phone = (row.FindControl("TextBoxPhone") as TextBox).Text;
            (new BLL_SellerUser()).New(selleruser.SellerID, selleruser.UserName, selleruser.UserPassWordHash, selleruser.Email, selleruser.Phone);

            GridView2.EditIndex = -1;
            GridView2_FetchData();
            ButtonInsert2.Visible = true;
        }
        else if (e.CommandName.Equals("EmptyCancel"))
        {
            GridViewRow row = (GridViewRow)(e.CommandSource as Button).NamingContainer;
            (row.FindControl("TextBoxUserName_Empty") as TextBox).Text = "";
            (row.FindControl("TextBoxUserPassWordHash_Empty") as TextBox).Text = "";
            (row.FindControl("TextBoxEmail") as TextBox).Text = "";
            (row.FindControl("TextBoxPhone") as TextBox).Text = "";
        }
    }
    protected void ButtonInsert2_Click(object sender, EventArgs e)
    {
        GridView2.ShowFooter = true;
        GridView2_FetchData();
        ButtonInsert2.Visible = false;

        (GridView2.FooterRow.FindControl("ButtonInsert") as Button).Attributes.Add("OnClick", "return  GetPassWordHash_ButtonInsert()");
    }
    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
        {
            ButtonInsert2.Visible = false;
            (e.Row.FindControl("ButtonEmptyAdd") as Button).Attributes.Add("OnClick", "return  GetPassWordHash_EmptyRow()");
        }
    }

    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        Session["AdminID"] = null;
        Session["AdminName"] = null;
        Response.Redirect("Login.aspx");
    }

    protected void ButtonChangePage_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin_PhoneManage.aspx");
    }
}