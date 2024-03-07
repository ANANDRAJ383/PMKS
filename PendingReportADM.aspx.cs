using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PendingReportADM : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    public PendingReportADM()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //fillddl();
            fillGrid();
        }
    }
    protected void fillGrid()
    {
        string query = @" select DD.DISTCODE,
dd.DistName ,
(select count(*) from Registration_PMKISAN pp where pp.Distcode=dd.DistCode and AC_Status=1 and  DAO_Status=1 and ADMR_Status is null and datediff(day, DAO_ActionDate, getdate())<=120)'120Days',
(select count(*) from Registration_PMKISAN pp where pp.Distcode=dd.DistCode and  AC_Status=1 and  DAO_Status=1 and ADMR_Status is null and datediff(day, DAO_ActionDate, getdate())> 120 and datediff(day, DAO_ActionDate, getdate())<= 365)'365Days',
(select count(*) from Registration_PMKISAN pp where pp.Distcode=dd.DistCode and  AC_Status=1 and  DAO_Status=1 and ADMR_Status is null and datediff(day, DAO_ActionDate, getdate())> 365 and datediff(day, DAO_ActionDate, getdate())<= 730)'730Days',
(select count(*) from Registration_PMKISAN pp where pp.Distcode=dd.DistCode and  AC_Status=1 and  DAO_Status=1 and ADMR_Status is null and datediff(day, DAO_ActionDate, getdate())>730)'1065Days'
 from   Districts dd   
 order by dd.DistName  ";
        DataTable i = cls.GetDataTable(query);
        if (i.Rows.Count > 0)
        {
            grd1.DataSource = i;
            grd1.DataBind();
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
            Response.Redirect("PendingReportPanchayat.aspx?distcode=" + distcode);
        }
        catch (Exception ex) { }
    }

  
}