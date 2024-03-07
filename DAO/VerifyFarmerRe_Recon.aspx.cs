using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DAO_VerifyFarmerRe_Recon : System.Web.UI.Page
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
    void BindReson()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetReson");
            DataTable dt = objcls.storeProcedure.getData();
            ddlReason.DataTextField = "DropdownOption";
            ddlReason.DataValueField = "DropdownValue";
            ddlReason.DataSource = dt;
            ddlReason.DataBind();
            ddlReason.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlReason.Visible = true;
        }
        catch
        {
        }
    }

    #endregion

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("DataListForVerification_Re_Recon.aspx");
    }

    protected void bnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (CheckBox2.Checked != true)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please check this box');", true);
                CheckBox2.Focus();
                return;
            }
            int DAO_Status = 0;
            if (rb1.SelectedItem.Text == "Yes")
            {
                DAO_Status = 1;
            }
            else
            {
                DAO_Status = 2;
            }
            if (rb2.SelectedItem.Text == "Yes")
            {
                DAO_Status = 1;
            }
            else
            {
                DAO_Status = 2;
            }
            if (rb3.SelectedItem.Text == "Yes")
            {
                DAO_Status = 1;
            }
            else
            {
                DAO_Status = 2;
            }
            if (rb4.SelectedItem.Text == "Yes")
            {
                DAO_Status = 1;
            }
            else
            {
                DAO_Status = 2;
            }
            if (rb5.SelectedItem.Text == "Yes")
            {
                DAO_Status = 1;
            }
            else
            {
                DAO_Status = 2;
            }


            objcls.storeProcedure.NewStoreProcedure("SP_Verify_Data_DAO_Re_Recon_PMKISAN");
            objcls.storeProcedure.AddWithValue("DAO_ActionName", Convert.ToString(Session["UserID"]));
            objcls.storeProcedure.AddWithValue("Registration_ID", RegId.Trim());
            objcls.storeProcedure.AddWithValue("DAODocVerify", rb1.SelectedValue);
            objcls.storeProcedure.AddWithValue("DAOFamilyBenify", rb2.SelectedValue);
            objcls.storeProcedure.AddWithValue("DAOLandInfoVerify", rb3.SelectedValue);
            objcls.storeProcedure.AddWithValue("DAODocUpdated", rb4.SelectedValue);
            objcls.storeProcedure.AddWithValue("DAOAllInfoVerify", rb5.SelectedValue);
            objcls.storeProcedure.AddWithValue("DAO_Status", DAO_Status);
            objcls.storeProcedure.AddWithValue("DAORejectReason", ddlReason.SelectedValue);
	    objcls.storeProcedure.AddWithValue("ApplicationType", "RE-RECON");
            if (objcls.storeProcedure.ExecuteNonQuery())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data Verified Successfully');", true);
            }

        }
        catch
        {

        }
    }

    protected void rb5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rb5.SelectedValue == "No")
        {
            BindReson();
            ddlReason.Visible = true;
        }
        else
        {
            ddlReason.Visible = false;
        }
    }
}