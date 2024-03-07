using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class Reconcile_SAO_eKYCTarget : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    clsDataAccess cls = new clsDataAccess();
    clsDataAccessNew clsNew = new clsDataAccessNew();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Userrole"]) != "SAO")
        {
            Response.Redirect("~/PMKISANAdmin/Login.aspx", true);
        }
        if (!IsPostBack)
        {
            BindDistrict(); BindSubDivison();
        }
    }
    void BindDistrict()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetDistrict");
            DataTable dt = objcls.storeProcedure.getData();
            ddlDistrict.DataTextField = "DistName";
            ddlDistrict.DataValueField = "DistCode";
            ddlDistrict.DataSource = dt;
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("--All--", "0"));
            if (Session["DistrictCode"].ToString() != "")
            {
                ddlDistrict.SelectedValue = Session["DistrictCode"].ToString();
                ddlDistrict.Enabled = false;
            }
        }
        catch
        {
        }
    }

    void BindSubDivison()
    {
        try
        {
            string query = "select SDMCode,SDMName_En from [KrishiDept].[dbo].SubDivisionMaster where DistCode='" + Session["DistrictCode"].ToString() + "'";
            DataTable dt = clsNew.GetDataTable(query);
            ddlSubDivison.DataTextField = "SDMName_En";
            ddlSubDivison.DataValueField = "SDMCode";
            ddlSubDivison.DataSource = dt;
            ddlSubDivison.DataBind();
            ddlSubDivison.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch
        {
        }
    }
    void BindReport()
    {
        try
        {
            if (ddlSubDivison.SelectedValue == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Sub Divison.....!');", true);
                //lblMsg.Text = "Please Select Sub Divison.....";
                ddlSubDivison.Focus();
                return;
            }
            if (ddlEntryFor.SelectedValue == "0")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Entry For.....!');", true);
                //lblMsg.Text = "Please Select Entry For.....";
                ddlEntryFor.Focus();
                return;
            }
             
            objcls.storeProcedure.NewStoreProcedure("SP_Get_Target_EKYCReport");
            objcls.storeProcedure.FieldName = "DistCode,SubDivisonCode,Type";
            objcls.storeProcedure.FieldValue = new object[] { ddlDistrict.SelectedValue, ddlSubDivison.SelectedValue , ddlEntryFor.SelectedValue};
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                if (ddlEntryFor.SelectedValue == "eKYC")
                {
                    lblMsg.Text = dt.Rows.Count + ",Records";
                    gvdata.DataSource = dt;
                    gvdata.DataBind();
                    gvdata.Visible = true;
                    GridViewNPCI.Visible = false; GridViewRecovery.Visible = false; GridViewPV.Visible = false;

                }
                else if (ddlEntryFor.SelectedValue == "NPCI")
                {
                    lblMsg.Text = dt.Rows.Count + ",Records";
                    GridViewNPCI.DataSource = dt;
                    GridViewNPCI.DataBind();
                    GridViewNPCI.Visible = true; 
                    gvdata.Visible = false; GridViewRecovery.Visible = false; GridViewPV.Visible = false;
                }
                else if (ddlEntryFor.SelectedValue == "Recovery")
                {
                    lblMsg.Text = dt.Rows.Count + ",Records";
                    GridViewRecovery.DataSource = dt;
                    GridViewRecovery.DataBind();
                    GridViewRecovery.Visible = true;
                    GridViewNPCI.Visible = false; gvdata.Visible = false; GridViewPV.Visible = false;
                }
                else if (ddlEntryFor.SelectedValue == "PV")
                {
                    lblMsg.Text = dt.Rows.Count + ",Records";
                    GridViewPV.DataSource = dt;
                    GridViewPV.DataBind();
                    GridViewPV.Visible = true;
                    GridViewNPCI.Visible = false; gvdata.Visible = false; GridViewRecovery.Visible = false;
                }
            }
            else
            {ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Zero (0) pending Data available');", true);
                gvdata.Visible = false;
            }

        }
        catch (Exception ee)
        { lblMsg.Text = ee.Message; }
    }
    void SaveData()
    {
        try
        {
            
            foreach (GridViewRow row in gvdata.Rows)
            {
                CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
                Label lblBlock = (Label)row.FindControl("lblBlock");
                Label lblPending = (Label)row.FindControl("lblPending");
                Label lblDone = (Label)row.FindControl("lblDone");
                TextBox txtPendingLastWeek = (TextBox)row.FindControl("txtPendingLastWeek");
                TextBox txtPendingCurrentWeek = (TextBox)row.FindControl("txtPendingCurrentWeek");
                TextBox txtPendingLastWeekPer = (TextBox)row.FindControl("txtPendingLastWeekPer");
                TextBox txtPendingCurrentWeekPer = (TextBox)row.FindControl("txtPendingCurrentWeekPer");
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chk.Checked == true)
                    {
                        if (ddlSubDivison.SelectedValue == "0")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Sub Divison.....!');", true);
                            //lblMsg.Text = "Please Select Sub Divison.....";
                            ddlSubDivison.Focus();
                            return;
                        }
                        if (ddlEntryFor.SelectedValue == "0")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Entry For.....!');", true);
                            //lblMsg.Text = "Please Select Entry For.....";
                            ddlEntryFor.Focus();
                            return;
                        }
                        if (txtPendingLastWeek.Text == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill Work Done in last Week.....!');", true);
                            //lblMsg.Text = "Please fill Work Done in last Week.....";
                            txtPendingLastWeek.Focus();
                            return;
                        }
                        if (txtPendingCurrentWeek.Text == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill Work Done in Current Week.....!');", true);
                            //lblMsg.Text = "Please fill Work Done in Current Week.....";
                            txtPendingCurrentWeek.Focus();
                            return;
                        }
                        objcls.storeProcedure.NewStoreProcedure("SP_Insert_tbl_PMKTargetEntry");
                        objcls.storeProcedure.AddWithValue("DistName", ddlDistrict.SelectedItem.Text);
                        objcls.storeProcedure.AddWithValue("DistCode", ddlDistrict.SelectedValue);
                        objcls.storeProcedure.AddWithValue("SubDivisonCode", ddlSubDivison.SelectedValue);
                        objcls.storeProcedure.AddWithValue("SubDivisonName", ddlSubDivison.SelectedItem.Text);
                        objcls.storeProcedure.AddWithValue("EntryFor", ddlEntryFor.SelectedItem.Text);
                        objcls.storeProcedure.AddWithValue("BlockName", lblBlock.Text);
                        objcls.storeProcedure.AddWithValue("Pending", lblPending.Text);
                        objcls.storeProcedure.AddWithValue("WorkDoneTillDate", lblDone.Text);
                        objcls.storeProcedure.AddWithValue("LastWeekWorkDone", txtPendingLastWeek.Text);
                        objcls.storeProcedure.AddWithValue("CurrentWeekWorkDone", txtPendingCurrentWeek.Text);
                        objcls.storeProcedure.AddWithValue("LastWeekWorkDonePer", txtPendingLastWeekPer.Text);
                        objcls.storeProcedure.AddWithValue("CurrentWeekWorkDonePer", txtPendingCurrentWeekPer.Text);
                        objcls.storeProcedure.AddWithValue("EntryBy", Session["UserID"].ToString());
                        if (objcls.storeProcedure.ExecuteNonQuery())
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data Saved Successfully');", true);
                            lblMsg.Text = "Data Saved Successfully";
                        }
                        //BindReport();
                    }
                }
            }
           
        }
        catch(Exception ee)
        {lblMsg.Text = ee.Message;

        }
    }

    void RecoverySaveData()
    {
        try
        {

            foreach (GridViewRow row in gvdata.Rows)
            {
                CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
                Label lblBlock = (Label)row.FindControl("lblBlock");
                Label lblPending = (Label)row.FindControl("lblPending");
                Label lblDone = (Label)row.FindControl("lblDone");
                Label lblNoOfInstallments = (Label)row.FindControl("lblNoOfInstallments");
                Label lblAmount = (Label)row.FindControl("lblAmount");
                TextBox txtPendingLastWeek = (TextBox)row.FindControl("txtPendingLastWeek");
                TextBox txtPendingCurrentWeek = (TextBox)row.FindControl("txtPendingCurrentWeek");
                TextBox txtPendingLastWeekPer = (TextBox)row.FindControl("txtPendingLastWeekPer");
                TextBox txtPendingCurrentWeekPer = (TextBox)row.FindControl("txtPendingCurrentWeekPer");
                TextBox txtPendingLastWeekAmount = (TextBox)row.FindControl("txtPendingLastWeekAmount");
                TextBox txtPendingCurrentWeekAmount = (TextBox)row.FindControl("txtPendingCurrentWeekAmount");
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chk.Checked == true)
                    {
                        if (ddlSubDivison.SelectedValue == "0")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Sub Divison.....!');", true);
                            //lblMsg.Text = "Please Select Sub Divison.....";
                            ddlSubDivison.Focus();
                            return;
                        }
                        if (ddlEntryFor.SelectedValue == "0")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Entry For.....!');", true);
                            //lblMsg.Text = "Please Select Entry For.....";
                            ddlEntryFor.Focus();
                            return;
                        }
                        if (txtPendingLastWeek.Text == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill Work Done in last Week.....!');", true);
                            //lblMsg.Text = "Please fill Work Done in last Week.....";
                            txtPendingLastWeek.Focus();
                            return;
                        }
                        if (txtPendingCurrentWeek.Text == "")
                        {
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please fill Work Done in Current Week.....!');", true);
                            //lblMsg.Text = "Please fill Work Done in Current Week.....";
                            txtPendingCurrentWeek.Focus();
                            return;
                        }
                        objcls.storeProcedure.NewStoreProcedure("SP_Insert_tbl_PMKTargetEntryRecovery");
                        objcls.storeProcedure.AddWithValue("DistName", ddlDistrict.SelectedItem.Text);
                        objcls.storeProcedure.AddWithValue("DistCode", ddlDistrict.SelectedValue);
                        objcls.storeProcedure.AddWithValue("SubDivisonCode", ddlSubDivison.SelectedValue);
                        objcls.storeProcedure.AddWithValue("SubDivisonName", ddlSubDivison.SelectedItem.Text);
                        objcls.storeProcedure.AddWithValue("EntryFor", ddlEntryFor.SelectedItem.Text);
                        objcls.storeProcedure.AddWithValue("BlockName", lblBlock.Text);
                        objcls.storeProcedure.AddWithValue("Pending", lblPending.Text);
                        objcls.storeProcedure.AddWithValue("WorkDoneTillDate", lblDone.Text);
                       
                        objcls.storeProcedure.AddWithValue("LastWeekWorkDone", txtPendingLastWeek.Text);
                        objcls.storeProcedure.AddWithValue("CurrentWeekWorkDone", txtPendingCurrentWeek.Text);
                        objcls.storeProcedure.AddWithValue("LastWeekWorkDonePer", txtPendingLastWeekPer.Text);
                        objcls.storeProcedure.AddWithValue("CurrentWeekWorkDonePer", txtPendingCurrentWeekPer.Text);
                        objcls.storeProcedure.AddWithValue("EntryBy", Session["UserID"].ToString());
                        objcls.storeProcedure.AddWithValue("NoOfInstallments", lblNoOfInstallments.Text);
                        objcls.storeProcedure.AddWithValue("Amount", lblAmount.Text);
                        objcls.storeProcedure.AddWithValue("AmountLastWeek", txtPendingLastWeekAmount.Text);
                        objcls.storeProcedure.AddWithValue("AmountCurrentWeek", txtPendingCurrentWeekAmount.Text);
                        if (objcls.storeProcedure.ExecuteNonQuery())
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data Saved Successfully');", true);
                            lblMsg.Text = "Data Saved Successfully";
                        }
                        //BindReport();
                    }
                }
            }

        }
        catch (Exception ee)
        {
lblMsg.Text = ee.Message;
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
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {if (ddlEntryFor.SelectedValue != "Recovery")
        {
            SaveData();
        }
        if (ddlEntryFor.SelectedValue == "Recovery")
        {
            RecoverySaveData();
        }
    }
    protected void gvdata_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;

        if ((gv.ShowHeader == true && gv.Rows.Count > 0)
            || (gv.ShowHeaderWhenEmpty == true))
        {
            //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
            gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        if (gv.ShowFooter == true && gv.Rows.Count > 0)
        {
            //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
            gv.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubDivison();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (ddlSubDivison.SelectedValue == "0")
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Sub Divison.....!');", true);
            //lblMsg.Text = "Please Select Sub Divison.....";
            ddlSubDivison.Focus();
            return;
        }
        if (ddlEntryFor.SelectedValue == "0")
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Entry For.....!');", true);
            //lblMsg.Text = "Please Select Entry For.....";
            ddlEntryFor.Focus();
            return;
        }
        BindReport();
    }

   
}