using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class ApproveDieselApplication : System.Web.UI.Page
{
    clsDataAccessDiesel objcls = new clsDataAccessDiesel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Convert.ToString(Session["UserRole"])!="DAO" || Convert.ToString(Session["UserRole"]) == "")
        {
            Response.Redirect("../LoginForm.aspx");
        }
        lblDistrict.Text = Convert.ToString(Session["DistrictName "]);
        if (!IsPostBack)
        {
            BindBlock(); BindPanchayat(); 
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
            ddlBlock.DataTextField = "BlockName";
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
        ddlPanchayat.DataTextField = "PanchayatName";
        ddlPanchayat.DataValueField = "PanchayatCode";
        ddlPanchayat.DataSource = dt;
        ddlPanchayat.DataBind();
        ddlPanchayat.Items.Insert(0, new ListItem("--All--", "0"));


    }


    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetFarmerDataForDAO_Diesel");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), ddlBlock.SelectedValue, ddlPanchayat.SelectedValue};
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                btnApproved.Visible = true;
		//lnbDownloadExcel.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblMsg.Text = "Record Not available !!!!!";
                btnApproved.Visible = false;
		//lnbDownloadExcel.Visible = false;
            }

        }
        catch (Exception ee)
        { lblMsg.Text = ee.Message; }
    }

    void Verify()
    {
        lblMsg.Text = "";
        try
        {
            int set = 0;
            foreach (GridViewRow row in gvdata.Rows)
            {
                CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
                Label lnkregid = (Label)row.FindControl("lnkregid");
                LinkButton lnkAppId = (LinkButton)row.FindControl("lnkAppId");
                Label lblApprovedSubsidyAmount = (Label)row.FindControl("lblApprovedSubsidyAmount");
                DropDownList ddlApproved = (DropDownList)row.FindControl("ddlApproved");
                TextBox txtDAOApprovedAmount = (TextBox)row.FindControl("txtDAOApprovedAmount");
                TextBox txtCommentDAO = (TextBox)row.FindControl("txtCommentDAO");
                //string rid = lnkregid.Text;
               
                if (row.RowType == DataControlRowType.DataRow)
                {
                    lblMsg.Text = "";
                    if (chk.Checked == true)
                    {
                        
                        if (ddlApproved.SelectedValue == "1")
                        {
                            if (Convert.ToDecimal(txtDAOApprovedAmount.Text.Trim()) > Convert.ToDecimal(lblApprovedSubsidyAmount.Text))
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Kindly Enter less or equal Amount from AC approval Amount.');", true);
                                lblMsg.Text = "Kindly Enter less or equal Amount from AC approval Amount.";
                                return;
                            }
                            txtDAOApprovedAmount.Enabled = true;
                            if (string.IsNullOrEmpty(txtDAOApprovedAmount.Text.Trim()) || txtDAOApprovedAmount.Text == "0.00" || txtDAOApprovedAmount.Text == "0")//txtAmount
                            {
                                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please Enter Correct Approved amount....!!!!');", true);
                                return;
                            }
                        }
                        else if (ddlApproved.SelectedValue == "2")
                        {
                            txtDAOApprovedAmount.Text = "0.00";
                            
                            txtDAOApprovedAmount.Enabled = false;
                        }
                        if (string.IsNullOrEmpty(txtCommentDAO.Text)) 
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please Enter Remarks....!!!!');", true);
                            return;
                        }
                        objcls.storeProcedure.NewStoreProcedure("SP_UpdateFarmerData_DieselDAOLogin");
                        objcls.storeProcedure.AddWithValue("Application_ID", lnkAppId.Text);
                        objcls.storeProcedure.AddWithValue("DAO_Status", ddlApproved.SelectedValue);
                        objcls.storeProcedure.AddWithValue("DAO_ApprovedAmt", Convert.ToDecimal(txtDAOApprovedAmount.Text.Trim()));
                        objcls.storeProcedure.AddWithValue("DAO_Remarks", txtCommentDAO.Text.Trim());
                        objcls.storeProcedure.AddWithValue("DAO_ActionName", Convert.ToString(Session["UserID"]));;
                        if (objcls.storeProcedure.ExecuteNonQuery())
                        {
                            set++;
                        }

                    }
                    //if (chk.Checked == false)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Plese Select atleast one record.');", true);
                    //    lblMsg.Text = "Plese Select atleast one record.";
                    //    return;
                    //}
                }
            }
            if (set > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(" + set + "'+Data Verified Successfully');", true);
                lblMsg.Text = "Out of " + lblMsg.Text + "," + set + ",Record Verified Successfully";
                //BindData();
                gvdata.Visible = false; btnApproved.Visible = false;
            }

        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.Message;
        }
    }

    #endregion
    protected void QtyChanged(object sender, EventArgs e)
    { }
    protected void lnkregid_Click2(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            var regid = ((LinkButton)sender).CommandArgument;
            ViewState["Reg_ID"] = regid;
            WinOpen("PrintDieselApplication.aspx?RegId=" + regid);
        }
        catch (Exception ex) { }
    }
    public void WinOpen(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=1200,height=900,toolbar=0,addressbar =0, scrollbars=yes');", msg);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "strScript", strScript, true);
        }
        catch (Exception ex) { }
    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void lnbDownloadExcel_Click(object sender, EventArgs e)
    {
        if (gvdata.Rows.Count <= 0)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "abc", "alert('No Data To Export.');", true);
            return;
        }

        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DataReport.xls"));
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        gvdata.AllowPaging = false;
        DataTable dt = new DataTable();
        BindData();
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        foreach (GridViewRow row in gvdata.Rows)
        {
            foreach (TableCell cell in row.Cells)
            {
                cell.CssClass = "textmode";
            }
        }
        gvdata.RenderControl(htw);
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control) { }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        if (chkAll.Checked)
        {
            //btnApproved.Visible = true;
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

    protected void btnApproved_Click(object sender, EventArgs e)
    {
        Verify();
    }

    protected void ddlApproved_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvdata.Rows)
        {
            CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
            DropDownList ddlApproved = (DropDownList)row.FindControl("ddlApproved");
            TextBox txtDAOApprovedAmount = (TextBox)row.FindControl("txtDAOApprovedAmount");
            if (row.RowType == DataControlRowType.DataRow)
            {
                lblMsg.Text = "";
                if (chk.Checked == true)
                {
                    if (ddlApproved.SelectedValue == "2")
                    {
                        txtDAOApprovedAmount.Text = "0.00";
                        txtDAOApprovedAmount.Enabled = false;
                    }
                    else
                    {
                        txtDAOApprovedAmount.Enabled = true;
                    }
                }
                if (chk.Checked == false)
                {
                   // ddlApproved.SelectedValue = "1";
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Plese Select atleast one record.');", true);
                    lblMsg.Text = "Plese Select atleast one record.";
                    return;
                }
            }
            
        }
            
    }
}