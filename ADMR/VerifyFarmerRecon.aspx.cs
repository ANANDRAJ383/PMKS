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
            int ADMR_Status = 0;
            if (rb1.SelectedItem.Text == "Yes")
            {
                ADMR_Status = 1;
            }
            else
            {
                ADMR_Status = 2;
            }
            if (rb2.SelectedItem.Text == "Yes")
            {
                ADMR_Status = 1;
            }
            else
            {
                ADMR_Status = 2;
            }
            if (rb3.SelectedItem.Text == "Yes")
            {
                ADMR_Status = 1;
            }
            else
            {
                ADMR_Status = 2;
            }
            if (rb4.SelectedItem.Text == "Yes")
            {
                ADMR_Status = 1;
            }
            else
            {
                ADMR_Status = 2;
            }
            objcls.storeProcedure.NewStoreProcedure("SP_VerifyADMR");
            objcls.storeProcedure.AddWithValue("ADMR_ActionName", Convert.ToString(Session["UserID"]));
            objcls.storeProcedure.AddWithValue("Registration_ID", RegId);
            objcls.storeProcedure.AddWithValue("ADMDocVerify", rb1.SelectedItem.Text);
            objcls.storeProcedure.AddWithValue("ADMDocRecent", rb2.SelectedItem.Text);
            objcls.storeProcedure.AddWithValue("ADMApprove", rb3.SelectedItem.Text);
            objcls.storeProcedure.AddWithValue("ADMDocInfo", rb4.SelectedItem.Text);
            objcls.storeProcedure.AddWithValue("ADMR_Status", ADMR_Status);
            if (objcls.storeProcedure.ExecuteNonQuery())
            {
                
            }

        }
        catch
        {

        }
    }
}