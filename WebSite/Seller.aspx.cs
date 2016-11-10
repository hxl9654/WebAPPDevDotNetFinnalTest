using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Seller : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null || Session["SellerID"] == null)
            Response.Redirect("Login.aspx");
        else LabelWelcome.Text="欢迎经销商 "+ Session["SellerName"] + " 的用户 "+ Session["UserName"] + " 登录本系统！";
        if (!IsPostBack)
        {
            DropDownListBrand.DataSource = (new BLL_Brand()).SelectAll();
            DropDownListBrand.DataValueField = "BrandID";
            DropDownListBrand.DataTextField = "BrandName";
            DropDownListBrand.DataBind();
            if (DropDownListBrand.Items.Count != 0)
            {
                DropDownListModelDataRefresh();
                if (DropDownListModel.Items.Count != 0)
                    LableStockDataRefresh();
            }
            DropDownListSunSeller.DataSource = (new BLL_SellerInfo()).SelectByParentSellerID(Int32.Parse(Session["SellerID"].ToString()));
            DropDownListSunSeller.DataValueField = "SellerID";
            DropDownListSunSeller.DataTextField = "Name";
            DropDownListSunSeller.DataBind();

            GridView1.DataSource = (new BLL_SellerOpreateLog()).SelectBySellerID(Int32.Parse(Session["SellerID"].ToString()));
            GridView1.DataBind();
        }
    }

    protected void ButtonOK_Click(object sender, EventArgs e)
    {
        if (RadioButtonListOption.SelectedValue == null)
            return;
        else if (RadioButtonListOption.SelectedValue.Equals("Init"))
        {
            if (Int32.Parse(TextBoxQuantity.Text) < 0)
            {
                LabelSign.Text = "数量错误";
                return;
            }
            else LabelSign.Text = "";
            Stock temp = (new BLL_Stock()).SelectOne(Int32.Parse(Session["SellerID"].ToString()), Int32.Parse(DropDownListModel.SelectedValue));
            if (temp == null)
                (new BLL_Stock()).New(Int32.Parse(DropDownListModel.SelectedValue), Int32.Parse(Session["SellerID"].ToString()), Int32.Parse(TextBoxQuantity.Text));
            else
                (new BLL_Stock()).Update(temp.StockID, Int32.Parse(DropDownListModel.SelectedValue), Int32.Parse(Session["SellerID"].ToString()), Int32.Parse(TextBoxQuantity.Text));
            (new BLL_SellerOpreateLog()).New(Int32.Parse(DropDownListModel.SelectedValue), Int32.Parse(Session["SellerID"].ToString()), Int32.Parse(Session["UserID"].ToString()), -1, Int32.Parse(TextBoxQuantity.Text), "设置库存");
            LableStockDataRefresh();
            GridView1.DataSource = (new BLL_SellerOpreateLog()).SelectBySellerID(Int32.Parse(Session["SellerID"].ToString()));
            GridView1.DataBind();
        }
        else if (RadioButtonListOption.SelectedValue.Equals("Sell"))
        {
            if (Int32.Parse(TextBoxQuantity.Text) < 0)
            {
                LabelSign.Text = "数量错误";
                return;
            }
            else LabelSign.Text = "";
            Stock myStock = (new BLL_Stock()).SelectOne(Int32.Parse(Session["SellerID"].ToString()), Int32.Parse(DropDownListModel.SelectedValue));
            Stock SonSellerStock = (new BLL_Stock()).SelectOne(Int32.Parse(DropDownListSunSeller.SelectedValue), Int32.Parse(DropDownListModel.SelectedValue));
            if (SonSellerStock == null)
            {
                (new BLL_Stock()).New(Int32.Parse(DropDownListModel.SelectedValue), Int32.Parse(DropDownListSunSeller.SelectedValue), 0);
                SonSellerStock = (new BLL_Stock()).SelectOne(Int32.Parse(DropDownListSunSeller.SelectedValue), Int32.Parse(DropDownListModel.SelectedValue));
            }
            (new BLL_Stock()).Update(myStock.StockID, Int32.Parse(DropDownListModel.SelectedValue), Int32.Parse(Session["SellerID"].ToString()), myStock.Quantity - Int32.Parse(TextBoxQuantity.Text));
            (new BLL_Stock()).Update(SonSellerStock.StockID, Int32.Parse(DropDownListModel.SelectedValue), Int32.Parse(DropDownListSunSeller.SelectedValue), SonSellerStock.Quantity + Int32.Parse(TextBoxQuantity.Text));
            (new BLL_SellerOpreateLog()).New(Int32.Parse(DropDownListModel.SelectedValue), Int32.Parse(Session["SellerID"].ToString()), Int32.Parse(Session["UserID"].ToString()), Int32.Parse(DropDownListSunSeller.SelectedValue), Int32.Parse(TextBoxQuantity.Text), "发货");
            LableStockDataRefresh();
            GridView1.DataSource = (new BLL_SellerOpreateLog()).SelectBySellerID(Int32.Parse(Session["SellerID"].ToString()));
            GridView1.DataBind();
        }
        else if (RadioButtonListOption.SelectedValue.Equals("Return"))
        {
            if (Int32.Parse(TextBoxQuantity.Text) < 0)
            {
                LabelSign.Text = "数量错误";
                return;
            }
            else LabelSign.Text = "";
            Stock myStock = (new BLL_Stock()).SelectOne(Int32.Parse(Session["SellerID"].ToString()), Int32.Parse(DropDownListModel.SelectedValue));
            int ParentSellerID = (new BLL_SellerInfo()).SelectOne(Int32.Parse(Session["SellerID"].ToString())).ParentSellerID;
            Stock ParentSellerStock = (new BLL_Stock()).SelectOne(ParentSellerID, Int32.Parse(DropDownListModel.SelectedValue));
            if (ParentSellerStock == null)
            {
                (new BLL_Stock()).New(Int32.Parse(DropDownListModel.SelectedValue), ParentSellerID, 0);
                ParentSellerStock = (new BLL_Stock()).SelectOne(ParentSellerID, Int32.Parse(DropDownListModel.SelectedValue));
            }
            (new BLL_Stock()).Update(myStock.StockID, Int32.Parse(DropDownListModel.SelectedValue), Int32.Parse(Session["SellerID"].ToString()), myStock.Quantity - Int32.Parse(TextBoxQuantity.Text));
            (new BLL_Stock()).Update(ParentSellerStock.StockID, Int32.Parse(DropDownListModel.SelectedValue), Int32.Parse(DropDownListSunSeller.SelectedValue), ParentSellerStock.Quantity + Int32.Parse(TextBoxQuantity.Text));
            (new BLL_SellerOpreateLog()).New(Int32.Parse(DropDownListModel.SelectedValue), Int32.Parse(Session["SellerID"].ToString()), Int32.Parse(Session["UserID"].ToString()), -1, Int32.Parse(TextBoxQuantity.Text), "退货");
            LableStockDataRefresh();
            GridView1.DataSource = (new BLL_SellerOpreateLog()).SelectBySellerID(Int32.Parse(Session["SellerID"].ToString()));
            GridView1.DataBind();
        }
    }

    protected void DropDownListBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownListModelDataRefresh();
        if (DropDownListModel.Items.Count != 0)
            LableStockDataRefresh();
    }

    protected void RadioButtonListOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonListOption.SelectedValue != null && RadioButtonListOption.SelectedValue.Equals("Sell"))
            DropDownListSunSeller.Enabled = true;
        else DropDownListSunSeller.Enabled = false;
    }
    protected void DropDownListModelDataRefresh()
    {
        DropDownListModel.DataSource = (new BLL_Model()).SelectByBrandID(Int32.Parse(DropDownListBrand.SelectedValue));
        DropDownListModel.DataTextField = "ModelName";
        DropDownListModel.DataValueField = "ModelID";
        DropDownListModel.DataBind();
    }
    protected void LableStockDataRefresh()
    {
        Stock temp = (new BLL_Stock()).SelectOne(Int32.Parse(Session["SellerID"].ToString()), Int32.Parse(DropDownListModel.SelectedValue));
        if (temp == null)
        {
            LabelStock.Text = "0";
            RadioButtonListOption.Items.FindByValue("Sell").Enabled = false;
            RadioButtonListOption.Items.FindByValue("Return").Enabled = false;
            RadioButtonListOption.SelectedValue = "Init";
        }
        else
        {
            LabelStock.Text = temp.Quantity.ToString();
            RadioButtonListOption.Items.FindByValue("Sell").Enabled = true;
            RadioButtonListOption.Items.FindByValue("Return").Enabled = true;
        }
    }
    protected void DropDownListModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        LableStockDataRefresh();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    }

    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        GridView1.DataSource = (new BLL_SellerOpreateLog()).SelectBySellerID(Int32.Parse(Session["SellerID"].ToString()));
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SellerUser temp1 = (new BLL_SellerUser()).SelectOne(Int32.Parse(e.Row.Cells[1].Text));
            if (temp1 != null)
                e.Row.Cells[1].Text = temp1.UserName;
            else e.Row.Cells[1].Text = "UserID:" + e.Row.Cells[1].Text;
            Model temp2 = (new BLL_Model()).SelectOne(Int32.Parse(e.Row.Cells[3].Text));
            if (temp2 != null)
                e.Row.Cells[3].Text = temp2.ModelName;
            else e.Row.Cells[3].Text = "ModelID:" + e.Row.Cells[3].Text;

            Brand temp4 = (new BLL_Brand()).SelectOne(temp2.BrandID);
            if (temp4 != null)
                e.Row.Cells[2].Text = temp4.BrandName;
            else e.Row.Cells[2].Text = "BrandID:" + temp2.BrandID;

            if (Int32.Parse(e.Row.Cells[6].Text) == -1)
                e.Row.Cells[6].Text = "-";
            else
            {
                SellerInfo temp3 = (new BLL_SellerInfo()).SelectOne(Int32.Parse(e.Row.Cells[6].Text));
                if (temp3 != null)
                    e.Row.Cells[6].Text = temp3.Name;
                else e.Row.Cells[6].Text = "SellerID:" + e.Row.Cells[6].Text;
            }
        }
    }

    protected void ButtonLogout_Click(object sender, EventArgs e)
    {
        Session["UserID"] = null;
        Session["SellerID"] = null;
        Session["UserName"] = null;
        Session["SellerName"] = null;
        Response.Redirect("Login.aspx");
    }
}