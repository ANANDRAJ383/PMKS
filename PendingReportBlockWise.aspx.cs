using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PendingReportBlockWise : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    public PendingReportBlockWise()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        string distcode = Request.QueryString["distcode"].ToString();
        if (!Page.IsPostBack)
            fillGrid(distcode);
    }
    protected void fillGrid(string distcode)
    {
        string query = @"select d.distcode, d.DistName , b.BlockName, 
(select count(*) from Registration_PMKISAN pp where pp.BlockCode=b.BlockCode and AC_Status=1 and DAO_Status is null and datediff(day, AC_ActionDate, getdate())<=120)'120Days',
(select count(*) from Registration_PMKISAN pp where pp.BlockCode=b.BlockCode and AC_Status=1 and DAO_Status is null and datediff(day, AC_ActionDate, getdate())> 120 and datediff(day, EntryDate, getdate())<= 365)'365Days',
(select count(*) from Registration_PMKISAN pp where pp.BlockCode=b.BlockCode and AC_Status=1 and DAO_Status is null and datediff(day, AC_ActionDate, getdate())> 365 and datediff(day, EntryDate, getdate())<= 730)'730Days',
(select count(*) from Registration_PMKISAN pp where pp.BlockCode=b.BlockCode and AC_Status=1 and DAO_Status is null and datediff(day, AC_ActionDate, getdate())>730 )'1065Days'
 from   Blocks b inner join Districts d on b.DistCode=d.DistCode  
 where d.DistCode=" + distcode + " order by d.DistName , b.BlockName ";
        DataTable i = cls.GetDataTable(query);
        if (i.Rows.Count > 0)
        {
            grd1.DataSource = i;
            grd1.DataBind();
        }
    }
  
}