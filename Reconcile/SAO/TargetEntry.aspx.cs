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

public partial class Reconcile_DAO_TargetEntry : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    clsDataAccessNew cls = new clsDataAccessNew();
    clsDataAccessNewPMK clsNew = new clsDataAccessNewPMK();
    public Reconcile_DAO_TargetEntry()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Userrole"]) != "SAO")
        {
            Response.Redirect("~/PMKISANAdmin/Login.aspx", true);
        }
        if (!IsPostBack)
        {
             BindSubDivison(); BindBlock(); 
        }

    }

    #region function&Method
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

    void BindBlock()
    {
        try
        {

            string query = "";
            query = @"select BlockCode,BlockName from SubDivisionBlockMap where SubDivisionCode='" + ddlSubDivison.SelectedValue + "' order by BlockName";
            DataTable dt = cls.GetDataTable(query);
            ddlBlock.DataTextField = "BlockName";
            ddlBlock.DataValueField = "BlockCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    void BindData()
    {
        try
        {
            string query = ""; string query2 = "";
            
            if (ddlEntryFor.SelectedValue == "eKYC")
            {
                query = @"select count(*) as Pending from tbl_NewData_eKYC_230923 where DBT_BlockCode='" + ddlBlock.SelectedValue + "'";
                query2 = @"select Pending,LastWeekWorkDone,CurrentWeekWorkDone from tbl_PMKTargetEntry where BlockCode='" + ddlBlock.SelectedValue + "' and SubDivisonCode='" + ddlSubDivison.SelectedValue + "' and EntryFor='" + ddlEntryFor.SelectedValue + "'";
                DataTable dteKYC = clsNew.GetDataTable(query);
                DataTable dteKYC2 = clsNew.GetDataTable(query2);
                if (dteKYC.Rows.Count>0)
                {

                    lblPending.Text = dteKYC2.Rows[0]["Pending"].ToString();
                    txtPendingCurrentWeek.Text = dteKYC2.Rows[0]["CurrentWeekWorkDone"].ToString();
                    txtPendingLastWeek.Text = dteKYC2.Rows[0]["LastWeekWorkDone"].ToString();
                }
            }
            if (ddlEntryFor.SelectedValue == "NPCI")
            {
                query = @"select count(*) as Pending from tbl_NPCI_NewData_240923 where DBT_BlockCode='" + ddlBlock.SelectedValue + "'";
                query2 = @"select Pending,LastWeekWorkDone,CurrentWeekWorkDone from tbl_PMKTargetEntry where BlockCode='" + ddlBlock.SelectedValue + "' and SubDivisonCode='" + ddlSubDivison.SelectedValue + "' and EntryFor='" + ddlEntryFor.SelectedValue + "'";
                DataTable dtNPCI = clsNew.GetDataTable(query);
                DataTable dtNPCI2 = clsNew.GetDataTable(query2);
                if (dtNPCI.Rows.Count > 0)
                {
                    lblPending.Text = dtNPCI2.Rows[0]["Pending"].ToString();
                    txtPendingCurrentWeek.Text = dtNPCI2.Rows[0]["CurrentWeekWorkDone"].ToString();
                    txtPendingLastWeek.Text = dtNPCI2.Rows[0]["LastWeekWorkDone"].ToString();
                }
            }
            if (ddlEntryFor.SelectedValue == "Recovery")
            {
                query = @"select count(*) as Pending from tbl_GoI_ReturnData_For_Reconsile_130723 where BlockCode='" + ddlBlock.SelectedValue + "'";
                query2 = @"select Pending,LastWeekWorkDone,CurrentWeekWorkDone from tbl_PMKTargetEntry where BlockCode='" + ddlBlock.SelectedValue + "' and SubDivisonCode='" + ddlSubDivison.SelectedValue + "' and EntryFor='" + ddlEntryFor.SelectedValue + "'";
                DataTable dtRecovery = clsNew.GetDataTable(query);
                DataTable dtRecovery2 = clsNew.GetDataTable(query2);
                if (dtRecovery.Rows.Count > 0)
                {
                    lblPending.Text = dtRecovery2.Rows[0]["Pending"].ToString();
                   txtPendingCurrentWeek.Text = dtRecovery2.Rows[0]["CurrentWeekWorkDone"].ToString();
                    txtPendingLastWeek.Text = dtRecovery2.Rows[0]["LastWeekWorkDone"].ToString();
                }
            }
            if (ddlEntryFor.SelectedValue == "PV")
            {
                query = @"select count(*) as Pending from Registration_PMKISAN_New where Registration_Id not in (select RegistrationNo from SocialAuditAll_PMKISAN) and XMLStatus=1 and BlockCode='" + ddlBlock.SelectedValue + "'";
                query2 = @"select Pending,LastWeekWorkDone,CurrentWeekWorkDone from tbl_PMKTargetEntry where BlockCode='" + ddlBlock.SelectedValue + "' and SubDivisonCode='" + ddlSubDivison.SelectedValue + "' and EntryFor='" + ddlEntryFor.SelectedValue + "'";
                DataTable dtPV = cls.GetDataTable(query);
                DataTable dtPV2 = clsNew.GetDataTable(query2);
                if (dtPV.Rows.Count > 0)
                {

                    lblPending.Text = dtPV2.Rows[0]["Pending"].ToString();
                    txtPendingCurrentWeek.Text = dtPV2.Rows[0]["CurrentWeekWorkDone"].ToString();
                    txtPendingLastWeek.Text = dtPV2.Rows[0]["LastWeekWorkDone"].ToString();
                }
            }
           
        }
        catch(Exception ee)
        {

        }
    }
    #endregion

    protected void ddlSubDivison_SelectedIndexChanged(object sender, EventArgs e)
    {txtPendingCurrentWeek.Text = "";
        BindBlock();
    }

    protected void ddlEntryFor_SelectedIndexChanged(object sender, EventArgs e)
    {txtPendingCurrentWeek.Text = "";
        BindData();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            
            if (ddlSubDivison.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Subdivison !!!!!');", true);
                ddlSubDivison.Focus();
                return;
            }
            if (ddlBlock.SelectedValue == "0")
            {
               ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Block !!!!!');", true);
                ddlBlock.Focus();
               return;
            }
            if (ddlEntryFor.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select EntryFor !!!!!');", true);
                ddlEntryFor.Focus();
                return;
            }
            //if (txtPendingLastWeek.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter Last Week work !!!!!');", true);
            //    txtPendingLastWeek.Focus();
            //    return;
            //}
            if (txtPendingCurrentWeek.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter Current Week work !!!!!');", true);
                txtPendingCurrentWeek.Focus();
                return;
            }
            int tv = Convert.ToInt32(txtPendingLastWeek.Text);
            int pv = Convert.ToInt32(lblPending.Text);
            int cv = Convert.ToInt32(txtPendingCurrentWeek.Text);
            
            if (tv > pv)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter less or target work then no of pending farmers.');", true);
                return;
            }
	     if (tv == pv)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Target work Completed.');", true);
                return;
            }
            if (cv > pv)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter less then no of pending farmers.');", true);
                return;
            }
            
            else
            {
                    //txtPendingLastWeek.ReadOnly = true;
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"update tbl_PMKTargetEntry set CurrentWeekWorkDone=@CurrentWeekWorkDone, EntryBy=@EntryBy,EntryDate=getdate() where BlockCode='" + ddlBlock.SelectedValue + "' and SubDivisonCode='" + ddlSubDivison.SelectedValue + "' and EntryFor='" + ddlEntryFor.SelectedValue + "' ";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@CurrentWeekWorkDone", txtPendingCurrentWeek.Text.Trim());
                    cmd.Parameters.AddWithValue("@EntryBy", Session["UserID"].ToString());
                    int ii = cmd.ExecuteNonQuery();
                    if (ii > 0)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Data Saved Successfully !');", true);
			txtPendingCurrentWeek.Text = "";
                        txtPendingLastWeek.Text = "0";
                        lblPending.Text = "";
                        ddlEntryFor.SelectedValue = "0";
                        ddlBlock.SelectedValue = "0";
                        ddlSubDivison.SelectedValue = "0";
                    }
                

            }
        }
        catch(Exception ee)
        { lblMsg.Text = ee.Message;}
    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEntryFor.SelectedValue = "0";lblPending.Text="0";
    }
    protected void txtPendingLastWeek_TextChanged(object sender, EventArgs e)
    {
    }

    protected void txtPendingCurrentWeek_TextChanged(object sender, EventArgs e)
    {
        //if (Convert.ToInt32(txtPendingLastWeek.Text) > Convert.ToInt32(lblPending.Text))
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter less farmers then pending farmers.');", true);
        //}
    }
}