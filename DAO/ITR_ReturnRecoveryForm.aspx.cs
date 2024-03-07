using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DAO_ITR_ReturnRecoveryForm : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    string Datefile = DateTime.UtcNow.AddHours(5).AddMinutes(30).AddMilliseconds(10).ToString("ddMMyyyy");
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
            objcls.storeProcedure.NewStoreProcedure("SP_GetFarmerData_ITRRecovery");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode,RegistrationId";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), ddlBlock.SelectedValue, ddlPanchayat.SelectedValue,txtRegId.Text.Trim()};
            DataTable dt = objcls.storeProcedure.getData();
            if(dt.Rows.Count>0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
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
                RadioButtonList ddlPaymentType = (RadioButtonList)row.FindControl("ddlPaymentType");
                //DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
                TextBox txtTRNo = (TextBox)row.FindControl("txtTRNo");
                TextBox txtTRDate = (TextBox)row.FindControl("txtTRDate");
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chk.Checked == true)
                    {
                        if(ddlPaymentType.SelectedValue=="")
                        {
                            lblMsg.Text = "Please Select Payee Account.....";
                            return;
                        }
                       
                        objcls.storeProcedure.NewStoreProcedure("SP_UpdatePMKISANRecovery");
                        objcls.storeProcedure.AddWithValue("RegistrationId", lblRegistrationID.Text.Trim());
                        objcls.storeProcedure.AddWithValue("PMKRegId", lblreg_no.Text.Trim());
                        objcls.storeProcedure.AddWithValue("PaymentReturnAC", ddlPaymentType.SelectedValue);
                        objcls.storeProcedure.AddWithValue("EnterBy", Convert.ToString(Session["UserID"]));
                        objcls.storeProcedure.AddWithValue("TransactionNo", txtTRNo.Text.Trim());
                        objcls.storeProcedure.AddWithValue("TranDate", txtTRDate.Text.Trim());
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
            }

        }
        catch(Exception ee)
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
        Verify();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        //mp1.Show();
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        string PMKRegId = gvdata.DataKeys[rowIndex].Values[1].ToString();
        ////string RegId = gvdata.DataKeys[gvdata.SelectedIndex].Values["Registration_ID"].ToString();
        //if (RegId != "")
        //{
        //    Response.Redirect("VerifyFarmerNew.aspx?RegId=" + RegId);
        //}

        WinOpen("ITRDone.aspx?RegId=" + RegId.Trim() + "&PMKRegId=" + PMKRegId.Trim());
        //Response.Redirect("ITRDone.aspx?RegId=" + RegId.Trim() + "&PMKRegId=" + PMKRegId.Trim());
    }
    public void WinOpen(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=1100,height=900,align=center,toolbar=0,addressbar =0, scrollbars=yes');", msg);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "strScript", strScript, true);
        }
        catch (Exception ex) { }
    }
}

