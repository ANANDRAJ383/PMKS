﻿using System;
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
    {lblDate.Text = DateTime.Now.ToString();
        if (Convert.ToString(Session["Userrole"]) != "HQ")
        {
            Response.Redirect("~/PMKISANAdmin/Login.aspx", true);
        }
        if (!IsPostBack)
        {
            
        }

    }
    #region function&Method
    

  

    void BindData()
    {
        try
        { 

            objcls.storeProcedure.NewStoreProcedure("SP_Get_DayWiseRecoverEntryReportForReconcile");
            objcls.storeProcedure.FieldName = "FromDate,ToDate";
            objcls.storeProcedure.FieldValue = new object[] {txtDate.Text, txtToDate .Text};
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                //lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data Not Available.!!!!!');", true);
            }
        }
        catch (Exception ee)
        {
		lblMsg.Text = ee.Message;
        }
    }
    #endregion
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex; BindData();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select From Date !!!!!');", true);
            txtDate.Focus();
            return;
        }
        if (txtToDate.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select To Date !!!!!');", true);
            txtToDate.Focus();
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



    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvdata.Visible = false;

    }
}