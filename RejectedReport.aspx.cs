﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RejectedReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    public RejectedReport()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillddl();
            fillGrid();
        }
    }
    protected void fillGrid()
    {
        string query = @"select distcode,distname,
(select COUNT(*) from [1stLevelRural] a inner join Registration r on r.AadhaarNumber=a.id and r.DistrictCode=d.distcode)'Rural',
(select COUNT(*) from [1StUrban] a inner join Registration r on r.AadhaarNumber=a.id and r.DistrictCode=d.distcode)'Urban',
(select COUNT(*) from [1stPFMSRejected] a inner join Registration r on r.MobileNumber=a.id and r.DistrictCode=d.distcode)'PFMS',
(select COUNT(*) from [1StIncomeTax] a inner join Registration r on r.MobileNumber=a.id and r.DistrictCode=d.distcode)'Income',
(select COUNT(*) from [1stAadharFailed] a inner join Registration r on r.AadhaarNumber=a.id and r.DistrictCode=d.distcode)'AadharFailed'
from Districts d order by DistName ";
        DataTable i = cls.GetDataTable(query);
        if (i.Rows.Count > 0)
        {
            grd1.DataSource = i;
            grd1.DataBind();
        }
    }
    protected void fillddl()
    {
        string query = "select distcode, distname from districts order by distname";
        DataTable dt = cls.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            ddldist.DataSource = dt;
            ddldist.DataTextField = "distname";
            ddldist.DataValueField = "distcode";
            ddldist.DataBind();
        }
    
    }
    //protected void lnkregid_Click(object sender, EventArgs e)
    //{

    //    ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('hellooo');", true);
    //    try
    //    {
    //        LinkButton btn = (LinkButton)sender;
    //        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
    //        string distcode = grd1.DataKeys[gvr.RowIndex].Values["distcode"].ToString();
    //        Response.Redirect("PendingReportPanchayat.aspx?distcode="+ distcode);
    //    }
    //    catch (Exception ex) { }
    //}

    protected void lnkregid_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string distcode = grd1.DataKeys[gvr.RowIndex].Values["distcode"].ToString();
            Response.Redirect("RejectedReportPanchayat.aspx?distcode=" + distcode);
        }
        catch (Exception ex) { }
    }

    protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("RejectedReportPanchayat.aspx?distcode=" + ddldist.SelectedValue);
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        Response.Redirect("RejectedReportPanchayat.aspx?distcode=" + ddldist.SelectedValue);
    }
}