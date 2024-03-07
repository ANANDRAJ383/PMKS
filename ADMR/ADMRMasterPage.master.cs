using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ADMR_COMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserRole"]) == "" || Convert.ToString(Session["UserRole"]) == null)
        {
            Response.Redirect("../LoginForm.aspx");
        }
        else
        {
            lblName.Text = Session["UserRole"].ToString() + ' ' + Session["UserName"].ToString();
        }

    }
    protected void lblLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        FormsAuthentication.RedirectToLoginPage();
        Response.Redirect("../LoginForm.aspx");
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        FormsAuthentication.RedirectToLoginPage();
        Response.Redirect("../LoginForm.aspx");
    }
}
