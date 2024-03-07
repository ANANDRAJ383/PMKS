using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Dashboard : System.Web.UI.Page
{

    clsDataAccess cls = new clsDataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //VerificationData();
            //TotalApplied();
            //TotalApprovedFarmer();
            //TotalApproved();
        }
    }

    protected void VerificationData()
    {
        string totalfarmer = "select count(*) cnt from   PhysicalVerification_PMKISANFinal where ActionDate	is not null and	XMLCreationDate is null";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            Label3.Text = dt.Rows[0]["cnt"].ToString() + " Farmers";
        }
    }
    protected void TotalApplied()
    {
        string totalfarmer = "select count(*) from   Registration_PMKISAN ";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            lbl1.Text = dt.Rows[0]["cnt"].ToString() + " Farmers";  
        }
    }
    protected void TotalApprovedFarmer()
    {
        string totalfarmer = "select count(*) from   Registration_PMKISAN where xmlstatus=1 ";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            Label1.Text = dt.Rows[0]["cnt"].ToString() + " Farmers";
        }
    }
    protected void TotalApproved()
    {
        string totalfarmer = @"select (select count(*) from   Registration_PMKISAN where ADMR_Status=1 and XMLStatus is null) 
            +  (select count(*) from   Registration_PMKISAN where Re_ADMR_Status=1 and XMLStatus is null ) a ";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            Label2.Text = dt.Rows[0]["cnt"].ToString() + " Farmers";
        }
    }
}