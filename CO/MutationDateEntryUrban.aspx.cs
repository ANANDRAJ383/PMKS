using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CO_MutationDateVerification : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    protected void Page_Load(object sender, EventArgs e)
    {if (Convert.ToString(Session["DistrictCode"]) == "" || Convert.ToString(Session["UserRole"]) != "CO")
        {
            Response.Redirect("../LoginForm.aspx");
        }
        CheckBox2.Checked = true;
        CheckBox2.ForeColor = System.Drawing.Color.Red;
        if (!IsPostBack)
        {
            BindBlock(); BindPanchayat(); //BindData();

        }
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
            if (Session["BlockCode"].ToString() != "")
            {
                ddlBlock.SelectedValue = Session["BlockCode"].ToString();
                ddlBlock.Enabled = false;
            }
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
            objcls.storeProcedure.NewStoreProcedure("SP_Get_MutationDateEntry_tbl_PMKisan_LandSeeding_No_PMKISAN");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode,RegId,RegType";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), ddlBlock.SelectedValue, ddlPanchayat.SelectedValue, txtRegId.Text.Trim(),"UrbanData" };
            DataTable dt = objcls.storeProcedure.getData();
            if(dt.Rows.Count>0)
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
        catch(Exception ee)
        {
            lblMsg.Text = ee.Message;
        }
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
                TextBox txtMutationDate = (TextBox)row.FindControl("txtMutationDate");
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chk.Checked == true)
                    {   if (txtMutationDate.Text == "")
                        {
                            lblMsg.Text = "Please fill Mutation Date.....";
                            txtMutationDate.Focus();
                            return;
                        }

                        objcls.storeProcedure.NewStoreProcedure("SP_updateMoutationDate_FromCO_PMKISAN");
                        objcls.storeProcedure.AddWithValue("CO_ActionName", Convert.ToString(Session["UserID"]));
                        objcls.storeProcedure.AddWithValue("Registration_ID", lblRegistrationID.Text.Trim());
                        objcls.storeProcedure.AddWithValue("LandMutationDate", txtMutationDate.Text.Trim());
                        if (objcls.storeProcedure.ExecuteNonQuery())
                        {
                            set++;
                        }

                    }
                }
            }
            if (set > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(" + set + "'+Data Updated Successfully');", true);
                lblMsg.Text = "Out of " + lblMsg.Text + "," + set + ",Record Updated Successfully";
                //BindData();
                gvdata.Visible = false;
                tblBulk.Visible = false;
            }

        }
        catch (Exception xx)
        {
            lblMsg.Text = xx.Message;
        }
    }
    #endregion
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex;
    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }
    //protected void btnViewDetail_Click(object sender, EventArgs e)
    //{
    //    int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
    //    string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
    //    //string RegId = gvdata.DataKeys[gvdata.SelectedIndex].Values["Registration_ID"].ToString();
    //    if (RegId != "")
    //    {
    //        Response.Redirect("VerifyFarmerRecon.aspx?RegId=" + RegId);
    //    }


    //}


    protected void btnViewDetailBefore_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        WinOpen("MutationDateBeforePMK.aspx?RegId=" + RegId.Trim());
    }
    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        WinOpen("PMKRecon.aspx?RegId=" + RegId.Trim());
    }
    public void WinOpen(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=900,height500,align=center,toolbar=0,addressbar =0, scrollbars=yes');", msg);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "strScript", strScript, true);
        }
        catch (Exception ex) { }
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

