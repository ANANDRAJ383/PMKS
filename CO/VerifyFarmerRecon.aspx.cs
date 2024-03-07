using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CO_VerifyFarmerRecon : System.Web.UI.Page
{
    string RegId = "";
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBox2.Checked = true;

        if (Request.QueryString["RegId"] != null && Request.QueryString["RegId"] != string.Empty)
        {
            RegId = Request.QueryString["RegId"].ToString();
            lblRegId.Text = "Registration Id :-"+RegId;
        }
    }
    #region function&Method


    #endregion

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("DataListForVerification_Recon.aspx");
    }

    protected void bnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int CO_Status = 0;
            if (rb1.SelectedItem.Text == "Yes")
            {
                CO_Status = 1;
            }
            else
            {
                CO_Status = 2;
            }
            if (rb2.SelectedItem.Text == "Yes")
            {
                CO_Status = 1;
            }
            else
            {
                CO_Status = 2;
            }
            if (rb3.SelectedItem.Text == "Yes")
            {
                CO_Status = 1;
            }
            else
            {
                CO_Status = 2;
            }
            objcls.storeProcedure.NewStoreProcedure("SP_VerifyAC_Data_FromCO");
            objcls.storeProcedure.AddWithValue("CO_ActionName", Convert.ToString(Session["UserID"]));
            objcls.storeProcedure.AddWithValue("Registration_ID", RegId);
            objcls.storeProcedure.AddWithValue("CODocVerify", rb1.SelectedItem.Text);
            objcls.storeProcedure.AddWithValue("CODocRecent", rb2.SelectedItem.Text);
            objcls.storeProcedure.AddWithValue("COApprove",rb3.SelectedItem.Text);
            objcls.storeProcedure.AddWithValue("CO_Status", CO_Status);
	    objcls.storeProcedure.AddWithValue("ApplicationType", "RECON");
            if (objcls.storeProcedure.ExecuteNonQuery())
            {
                
            }

        }
        catch
        {

        }
    }
}