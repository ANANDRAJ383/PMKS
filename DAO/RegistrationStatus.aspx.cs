using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HQ_RegistrationStatus : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        string RegId = txtUserId.Text;
        if (RegId != "")
        {
            Response.Redirect("AppStatus.aspx?RegId=" + RegId);
        }
    }
    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSearchBy.SelectedValue == "R")
        {
            lblUser.Text = "Enter Registration Id";
        }
        if (ddlSearchBy.SelectedValue == "A")
        {
            lblUser.Text = "Enter Aadhaar No";
        }
        if (ddlSearchBy.SelectedValue == "M")
        {
            lblUser.Text = "Enter Mobile No";
        }
    }
}