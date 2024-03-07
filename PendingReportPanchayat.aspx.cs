using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PendingReportPanchayat : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    public PendingReportPanchayat()
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
        string query = @"select dd.distcode,
dd.DistName , b.BlockName, d.PanchayatName ,
(select count(*) from Registration_PMKISAN pp where pp.PanchayatCode=d.PanchayatCode and AC_Status is null and datediff(day, EntryDate, getdate())<=120)'120Days',
(select count(*) from Registration_PMKISAN pp where pp.PanchayatCode=d.PanchayatCode and AC_Status is null and datediff(day, EntryDate, getdate())> 120 and datediff(day, EntryDate, getdate())<= 365)'365Days',
(select count(*) from Registration_PMKISAN pp where pp.PanchayatCode=d.PanchayatCode and AC_Status is null and datediff(day, EntryDate, getdate())> 365 and datediff(day, EntryDate, getdate())<= 730)'730Days',
(select count(*) from Registration_PMKISAN pp where pp.PanchayatCode=d.PanchayatCode and AC_Status is null and datediff(day, EntryDate, getdate())>730)'1065Days'
 from Panchayat  d inner join  Districts dd on dd.DistCode=d.DistrictCode  inner join Blocks b on b.DistCode=d.DistrictCode and b.BlockCode=d.BlockCode 
 where dd.DistCode=" + distcode + " order by  dd.DistName , b.BlockName";
        DataTable i = cls.GetDataTable(query);
        if (i.Rows.Count > 0)
        {
            grd1.DataSource = i;
            grd1.DataBind();
        }
    }
  
}