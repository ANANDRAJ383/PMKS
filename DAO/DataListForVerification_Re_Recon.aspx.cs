using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DAO_DataListForVerification_Re_Recon : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBox2.Checked = true;
        if (!IsPostBack)
        {
            BindBlock(); BindPanchayat(); //BindData();

        }
    }

    
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex;
    }

    #region Function&Method


    void BindBlock()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]) };
            DataTable dt = objcls.storeProcedure.getData();
            ddlBlock.DataTextField = "BlockNameHN";
            ddlBlock.DataValueField = "BlockCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }
    }

    void BindPanchayat()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetPanchayat");
        objcls.storeProcedure.FieldName = "BlockCode";
        objcls.storeProcedure.FieldValue = new object[] { ddlBlock.SelectedValue };
        DataTable dt = objcls.storeProcedure.getData();
        ddlPanchayat.DataTextField = "PanchayatNameHnd";
        ddlPanchayat.DataValueField = "PanchayatCode";
        ddlPanchayat.DataSource = dt;
        ddlPanchayat.DataBind();
        ddlPanchayat.Items.Insert(0, new ListItem("--All--", "0"));
    }


    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("Get_ReConList_ForDAOVerify_PMKISAN");
          
	    objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode,flag,RegId";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), ddlBlock.SelectedValue, ddlPanchayat.SelectedValue, "Re-Recon",txtRegId.Text.Trim() };
            
            DataTable dt = objcls.storeProcedure.getData();
            //DateTime d = DateTime.Now;
            if (dt.Rows.Count>0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                tblBulk.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
                tblBulk.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblMsg.Text = "Record Not available !!!!!";
            }

        }
        catch
        { }
    }

    void Verify()
    {
        try
        {
            int set = 0;
            foreach (GridViewRow row in gvdata.Rows)
            {
                CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
                Label lblRegistrationID = (Label)row.FindControl("lblRegistrationID");
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chk.Checked == true)
                    {
                        objcls.storeProcedure.NewStoreProcedure("SP_Verify_Data_DAO_Re_Recon_PMKISAN");
                        objcls.storeProcedure.AddWithValue("DAO_ActionName", Convert.ToString(Session["UserID"]));
                        objcls.storeProcedure.AddWithValue("Registration_ID", lblRegistrationID.Text.Trim());
                        objcls.storeProcedure.AddWithValue("DAODocVerify", "YES");
                        objcls.storeProcedure.AddWithValue("DAOFamilyBenify", "YES");
                        objcls.storeProcedure.AddWithValue("DAOPersonalInfoVerify", "YES");
                        objcls.storeProcedure.AddWithValue("DAOFamilyInfoVerify", "YES");
                        objcls.storeProcedure.AddWithValue("DAOBankInfoVerify", "YES");
                        objcls.storeProcedure.AddWithValue("DAOLandInfoVerify", "YES");
                        objcls.storeProcedure.AddWithValue("DAORayatInfoVerify", "YES");
                        objcls.storeProcedure.AddWithValue("DAOTopolandInfoVerify", "YES");
                        objcls.storeProcedure.AddWithValue("DAOAllInfoVerify", "YES");
                        objcls.storeProcedure.AddWithValue("DAO_Status", rb1.SelectedValue);
			objcls.storeProcedure.AddWithValue("ApplicationType", "RE-RECON");
                        if (objcls.storeProcedure.ExecuteNonQuery())
                        {
                            set++;
                        }

                    }
                }
            }
            if (set > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(" + set + "'+Data Verified Successfully');", true);
                lblMsg.Text = "Out of " + lblMsg.Text + "," + set + ",Record Verified Successfully";
                //BindData();
                gvdata.Visible = false;
                tblBulk.Visible = false;
            }

        }
        catch
        {

        }
    }

    #endregion

        protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }
 protected void btnView_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        //string RegId = gvdata.DataKeys[gvdata.SelectedIndex].Values["Registration_ID"].ToString();
        if (RegId != "")
        {
            Response.Redirect("VerifyFarmerRe_Recon.aspx?RegId=" + RegId);
        }


    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        if (chkAll.Checked)
        {
            CheckBox chkDetails = null;

            foreach (GridViewRow gvr in gvdata.Rows)
            {
                chkDetails = (CheckBox)gvr.FindControl("chkDetails");
                chkDetails.Checked = true;
            }
        }

        else
        {
            foreach (GridViewRow gvr in gvdata.Rows)
            {
                CheckBox chkDetails = (CheckBox)gvr.FindControl("chkDetails");
                chkDetails.Checked = false;
                
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select at least one record');", true);
        }
    }

    protected void bnSave_Click(object sender, EventArgs e)
    {
        if (CheckBox2.Checked != true)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please check this box');", true);
            CheckBox2.Focus();
            return;
        }
        else
        {
            Verify();
        }
    }
}

