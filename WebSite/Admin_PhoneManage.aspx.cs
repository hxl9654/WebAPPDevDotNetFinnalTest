using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_PhoneManage : System.Web.UI.Page
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
        GridView1.DataSource = (new BLL_Brand()).SelectAll();
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        (new BLL_Brand()).Delete(Int32.Parse((GridView1.Rows[e.RowIndex].FindControl("LabelBrandID") as Label).Text));
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
        Brand brand = new Brand();
        brand.BrandID = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("LabelBrandID") as Label).Text);
        brand.BrandName = (GridView1.Rows[e.RowIndex].FindControl("TextBoxBrandName") as TextBox).Text;
        brand.ProductAddress = (GridView1.Rows[e.RowIndex].FindControl("TextBoxProductAddress") as TextBox).Text;
        (new BLL_Brand()).Update(brand.BrandID, brand.BrandName, brand.ProductAddress);

        GridView1.EditIndex = -1;
        GridView1_FetchData();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Brand temp = (new BLL_Brand()).SelectOne(Int32.Parse((GridView1.SelectedRow.FindControl("LabelBrandID") as Label).Text));
        ChoosedBrandID = temp.BrandID;
        GridView2.Caption = "品牌 " + temp.BrandName + " 的型号";
        GridView2.ShowFooter = false;
        GridView2.EditIndex = -1;
        ButtonInsert2.Visible = true;
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
            Brand brand = new Brand();
            brand.BrandName = (GridView1.FooterRow.FindControl("TextBoxBrandName") as TextBox).Text;
            brand.ProductAddress = (GridView1.FooterRow.FindControl("TextBoxProductAddress") as TextBox).Text;
            (new BLL_Brand()).New(brand.BrandName, brand.ProductAddress);

            GridView1.EditIndex = -1;
            GridView1_FetchData();
        }
        else if (e.CommandName.Equals("EmptyAdd"))
        {
            GridViewRow row = (GridViewRow)(e.CommandSource as Button).NamingContainer;
            Brand brand = new Brand();
            brand.BrandName = (row.FindControl("TextBoxBrandName") as TextBox).Text;
            brand.ProductAddress = (row.FindControl("TextBoxProductAddress") as TextBox).Text;
            (new BLL_Brand()).New(brand.BrandName, brand.ProductAddress);

            GridView1.EditIndex = -1;
            GridView1_FetchData();
            ButtonInsert.Visible = true;
        }
        else if (e.CommandName.Equals("EmptyCancel"))
        {
            GridViewRow row = (GridViewRow)(e.CommandSource as Button).NamingContainer;
            (row.FindControl("TextBoxBrandName") as TextBox).Text = "";
            (row.FindControl("TextBoxProductAddress") as TextBox).Text = "";
        }
    }

    protected void ButtonInsert_Click(object sender, EventArgs e)
    {
        GridView1.ShowFooter = true;
        GridView1_FetchData();
        ButtonInsert.Visible = false;
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            ButtonInsert.Visible = false;
    }
    static int ChoosedBrandID = -1;
    private void GridView2_FetchData()
    {
        GridView2.DataSource = (new BLL_Model()).SelectByBrandID(ChoosedBrandID);
        GridView2.DataBind();
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        (new BLL_Model()).Delete(Int32.Parse((GridView2.Rows[e.RowIndex].FindControl("LabelModelID") as Label).Text));
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
    }

    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        GridView2_FetchData();
    }

    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Model model = new Model();
        model.ModelID = Convert.ToInt32((GridView2.Rows[e.RowIndex].FindControl("LabelModelID") as Label).Text);
        model.BrandID = ChoosedBrandID;
        model.ModelName = (GridView2.Rows[e.RowIndex].FindControl("TextBoxModelName") as TextBox).Text;
        model.Info = (GridView2.Rows[e.RowIndex].FindControl("TextBoxInfo") as TextBox).Text;
        model.Color = (GridView2.Rows[e.RowIndex].FindControl("TextBoxColor") as TextBox).Text;
        model.Picture = (GridView2.Rows[e.RowIndex].FindControl("TextBoxPicture") as TextBox).Text;
        (new BLL_Model()).Update(model.ModelID, model.BrandID, model.Color, model.Info, model.ModelName, model.Picture);

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
            Model model = new Model();
            model.BrandID = ChoosedBrandID;
            model.ModelName = (GridView2.FooterRow.FindControl("TextBoxModelName") as TextBox).Text;
            model.Info = (GridView2.FooterRow.FindControl("TextBoxInfo") as TextBox).Text;
            model.Color = (GridView2.FooterRow.FindControl("TextBoxColor") as TextBox).Text;
            model.Picture = (GridView2.FooterRow.FindControl("TextBoxPicture") as TextBox).Text;
            (new BLL_Model()).New(model.BrandID, model.Color, model.Info, model.ModelName, model.Picture);

            GridView2.EditIndex = -1;
            GridView2_FetchData();
        }
        else if (e.CommandName.Equals("EmptyAdd"))
        {
            GridViewRow row = (GridViewRow)(e.CommandSource as Button).NamingContainer;
            Model model = new Model();
            model.BrandID = ChoosedBrandID;
            model.ModelName = (row.FindControl("TextBoxModelName") as TextBox).Text;
            model.Info = (row.FindControl("TextBoxInfo") as TextBox).Text;
            model.Color = (row.FindControl("TextBoxColor") as TextBox).Text;
            model.Picture = (row.FindControl("TextBoxPicture") as TextBox).Text;
            (new BLL_Model()).New(model.BrandID, model.Color, model.Info, model.ModelName, model.Picture);

            GridView2.EditIndex = -1;
            GridView2_FetchData();
            ButtonInsert2.Visible = true;
        }
        else if (e.CommandName.Equals("EmptyCancel"))
        {
            GridViewRow row = (GridViewRow)(e.CommandSource as Button).NamingContainer;
            (row.FindControl("TextBoxModelName") as TextBox).Text = "";
            (row.FindControl("TextBoxInfo") as TextBox).Text = "";
            (row.FindControl("TextBoxColor") as TextBox).Text = "";
            (row.FindControl("TextBoxPicture") as TextBox).Text = "";
        }
    }

    protected void ButtonInsert2_Click(object sender, EventArgs e)
    {
        GridView2.ShowFooter = true;
        GridView2_FetchData();
        ButtonInsert2.Visible = false;
    }

    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            ButtonInsert2.Visible = false;
    }
    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        Session["AdminID"] = null;
        Session["AdminName"] = null;
        Response.Redirect("Login.aspx");
    }

    protected void ButtonChangePage_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin_SellerManage.aspx");
    }
}