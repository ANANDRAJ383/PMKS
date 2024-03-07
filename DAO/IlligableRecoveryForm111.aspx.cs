using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class IlligableRecoveryForm : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    string Datefile = DateTime.UtcNow.AddHours(5).AddMinutes(30).AddMilliseconds(10).ToString("ddMMyyyy");
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBox2.Checked = true;
        CheckBox2.ForeColor = System.Drawing.Color.Red;
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
            ddlBlock.DataTextField = "BlockName";
            ddlBlock.DataValueField = "BlockCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--Select--", "0"));
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
        ddlPanchayat.DataTextField = "PanchayatName";
        ddlPanchayat.DataValueField = "PanchayatCode";
        ddlPanchayat.DataSource = dt;
        ddlPanchayat.DataBind();
        ddlPanchayat.Items.Insert(0, new ListItem("--Select--", "0"));
    }


    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetFarmerData_IlligableRecovery");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), ddlBlock.SelectedValue, ddlPanchayat.SelectedValue};
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
        {lblMsg.Text = ee.Message; }
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
                Label lblreg_no = (Label)row.FindControl("lblreg_no");
                TextBox txtAmountReturn = (TextBox)row.FindControl("txtAmountReturn");
                DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
                TextBox txttransactiondate = (TextBox)row.FindControl("txttransactiondate");
                TextBox txtUTRNumber = (TextBox)row.FindControl("txtUTRNumber");
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chk.Checked == true)
                    {
                        objcls.storeProcedure.NewStoreProcedure("SP_UpdateIlligableRecovery");
                        
                        objcls.storeProcedure.AddWithValue("DBTRegistrationId", lblRegistrationID.Text.Trim());
                        objcls.storeProcedure.AddWithValue("reg_no", lblreg_no.Text.Trim());
                        objcls.storeProcedure.AddWithValue("AmountRetunn", txtAmountReturn.Text.Trim());
                        objcls.storeProcedure.AddWithValue("PaymentMode1", ddlStatus.SelectedValue);
                        objcls.storeProcedure.AddWithValue("TransactionNo", txtAmountReturn.Text.Trim());
                        objcls.storeProcedure.AddWithValue("TranDate", txttransactiondate.Text.Trim());
                        objcls.storeProcedure.AddWithValue("TranSacAttachment", ViewState["letter"]);
                        objcls.storeProcedure.AddWithValue("EnterBy", Convert.ToString(Session["UserID"]));
                        objcls.storeProcedure.AddWithValue("EnterDateTime", DateTime.Now);
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
        string letter = objcls.UploadPDF(flu, "/Documents/"  + Session["DistrictCode"] + "/" + Datefile + "/");
        ViewState["letter"] = letter;
        if (letter == "~" || letter == "Please Select jpeg File Only")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  Picture ;", true);
            return;
        }
        if (letter == "File Size Large")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  Less then 1 MB PDF ;", true);
            return;
        }
        
        else
        {
            Verify();
        }
    }
    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        //string RegId = gvdata.DataKeys[gvdata.SelectedIndex].Values["Registration_ID"].ToString();
        if (RegId != "")
        {
            Response.Redirect("VerifyFarmerNew.aspx?RegId=" + RegId);
        }
    }
}

