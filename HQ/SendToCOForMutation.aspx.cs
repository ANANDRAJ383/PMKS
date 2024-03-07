using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class HQ_SendToCOForMutation : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public HQ_SendToCOForMutation()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        objcls.storeProcedure.NewStoreProcedure("SP_SentRegistrationToCOLogin");
        objcls.storeProcedure.AddWithValue("Registration_ID", txtRegId.Text);
        if (objcls.storeProcedure.ExecuteNonQuery())
        {
            lblMsg.Text = "Record Send to CO login Successfully";
            txtRegId.Text = "";
        }
        else
        {
            lblMsg.Text = "Record not Send to CO login, please contact to DBA....";
        }
       
    }
}