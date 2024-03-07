using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RejectedReportPanchayat : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    public RejectedReportPanchayat()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string distcode = Request.QueryString["distcode"].ToString();
            if (!Page.IsPostBack)
                fillGrid(distcode);
        }
    }
    protected void fillGrid(string distcode)
    {
        string query = @"select
dd.DistName , b.BlockName, d.PanchayatName ,
(select COUNT(*) from [1stLevelRural] a inner join Registration r on r.AadhaarNumber=a.id and r.PanchayatCode=d.PanchayatCode)'Rural',
(select COUNT(*) from [1StUrban] a inner join Registration r on r.AadhaarNumber=a.id and r.PanchayatCode=d.PanchayatCode)'Urban',
(select COUNT(*) from [1stPFMSRejected] a inner join Registration r on r.MobileNumber=a.id and r.PanchayatCode=d.PanchayatCode)'PFMS',
(select COUNT(*) from [1StIncomeTax] a inner join Registration r on r.MobileNumber=a.id and r.PanchayatCode=d.PanchayatCode)'Income',
(select COUNT(*) from [1stAadharFailed] a inner join Registration r on r.AadhaarNumber=a.id and r.PanchayatCode=d.PanchayatCode)'AadharFailed'
 from Panchayat  d inner join  Districts dd on dd.DistCode=d.DistrictCode  inner join Blocks b on b.DistCode=d.DistrictCode and b.BlockCode=d.BlockCode 
 where dd.DistCode= '"+ distcode + "' order by dd.DistName , b.BlockName";
        DataTable i = cls.GetDataTable(query);
        if (i.Rows.Count > 0)
        {
            grd1.DataSource = i;
            grd1.DataBind();
        }
    }
   
}