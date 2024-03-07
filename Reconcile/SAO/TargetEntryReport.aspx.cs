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

public partial class Reconcile_DAO_TargetEntryReport :  System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    clsDataAccess cls = new clsDataAccess();
    clsDataAccessNew clsNew = new clsDataAccessNew();
    public Reconcile_DAO_TargetEntryReport()
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
            DataTable dt = clsNew.GetDataTable(query);
            ddlBlock.DataTextField = "BlockName";
            ddlBlock.DataValueField = "BlockCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    void BindData()
    {
        try
        {

            objcls.storeProcedure.NewStoreProcedure("SP_GetTargetEntryReport");
            objcls.storeProcedure.FieldName = "SubDivisonCode,BlockCode,EntryFor";
            objcls.storeProcedure.FieldValue = new object[] { ddlSubDivison.SelectedValue, ddlBlock.SelectedValue, ddlEntryFor.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
            }
        }
        catch (Exception ee)
        {

        }
    }
    #endregion

    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (ddlSubDivison.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Subdivison !!!!!');", true);
            ddlSubDivison.Focus();
            return;
        }
        //if (ddlBlock.SelectedValue == "0")
        //{
           // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Block !!!!!');", true);
           // ddlBlock.Focus();
           // return;
       // }
        if (ddlEntryFor.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select EntryFor !!!!!');", true);
            ddlEntryFor.Focus();
            return;
        }
        BindData();
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

    protected void ddlSubDivison_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBlock();
    }
}