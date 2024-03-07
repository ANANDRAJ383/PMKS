using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CO_COMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserRole"]) == "" || Convert.ToString(Session["UserRole"]) == null)
        {
            Response.Redirect("../LoginForm.aspx");
        }
        else
        {lblData.Text = "District :-" + Session["DistrictName "].ToString();
            lblName.Text = Session["UserName"].ToString();lblDate.Text = ">Date:-"+DateTime.Now.ToString();
        }

    }
    protected void lblLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();

 Session.Clear();
        Session.Abandon();
        Session.RemoveAll();


        FormsAuthentication.RedirectToLoginPage();
        Response.Redirect("../LoginForm.aspx");
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();

 Session.Clear();
        Session.Abandon();
        Session.RemoveAll();


        FormsAuthentication.RedirectToLoginPage();
        Response.Redirect("../LoginForm.aspx");
    }
}
