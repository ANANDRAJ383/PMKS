using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DashBoardRejectionData : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            VerificationData();
            //TotalApplied();
            //TotalApprovedFarmer();
            //TotalApproved();
        }
    }

    protected void VerificationData()
    {
        string totalfarmer = @"Select
(select COUNT(*) from[1stLevelRural])a,
(select COUNT(*) from[1StUrban])b,
(select COUNT(*) from[1stPFMSRejected] )c,
(select COUNT(*) from[1StIncomeTax] )d,
(select COUNT(*) from[1stAadharFailed] )e";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            lbl1.Text = dt.Rows[0]["a"].ToString() + " Farmers";
            Label1.Text = dt.Rows[0]["b"].ToString() + " Farmers";
            Label3.Text = dt.Rows[0]["c"].ToString() + " Farmers";
            Label2.Text = dt.Rows[0]["d"].ToString() + " Farmers";
            Label4.Text = dt.Rows[0]["e"].ToString() + " Farmers";
        }
    }
    protected void TotalApplied()
    {
        string totalfarmer = "select count(*) cnt from   Registration_PMKISAN ";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            lbl1.Text = dt.Rows[0]["cnt"].ToString() + " Farmers";
        }
    }
    protected void TotalApprovedFarmer()
    {
        string totalfarmer = "select count(*) cnt from   Registration_PMKISAN where xmlstatus=1 ";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            Label1.Text = dt.Rows[0]["cnt"].ToString() + " Farmers";
        }
    }
    protected void TotalApproved()
    {
        string totalfarmer = @"select (select count(*) from   Registration_PMKISAN where ADMR_Status=1 and XMLStatus is null) 
            +  (select count(*) from   Registration_PMKISAN where Re_ADMR_Status=1 and XMLStatus is null ) cnt ";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            Label2.Text = dt.Rows[0]["cnt"].ToString() + " Farmers";
        }
    }
}