using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CAPTCHAPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CAPTCHA captha = new CAPTCHA();
        Session["CAPTCHA"] = captha.CreatRandomString(4);
        Response.ClearContent();
        Response.ContentType = "image/Jpeg";
        Response.BinaryWrite(captha.CreatCAPTCHAImage(Session["CAPTCHA"].ToString()).ToArray());
    }
}