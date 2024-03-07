using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class ADMR_LandDetail : System.Web.UI.Page
{
    
    string RegId = "";
    clsDataAccess_Diesel objcls = new clsDataAccess_Diesel();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public ADMR_LandDetail()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        RegId = Request.QueryString["RegId"].ToString();
        lblRegId.Text = "Registration Id :-" + RegId;
        bindlanddata();

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }

    
    void bindlanddata()
    {
        DataTable dt = new DataTable();
        //string Appid = "";
        //foreach (GridViewRow row in gvdata.Rows)
        //{
        //    CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
        //    if (chk.Checked == true)
        //    {
        //        Appid = (gvdata.DataKeys[row.RowIndex].Values["Registration_ID"].ToString());
        //    }
        //}
        dt = objcls.GetDataTable(@"select RegistrationID,Khatano,keshrano,thanano,FarmingRakwa,Affectedrakwa,
case when CropType = 1 then N'शाश्वत फसल/गन्ना' when croptype = 2 THEN N'गेंहूँ' when croptype = 3 THEN N'रबी दलहन' when CropType = 4 THEN N'रबी तेलहन'
when croptype = 5 THEN N'अन्य फसल' when CropType = 4 THEN N'सब्जी' END as croptype
 from Input2223_landdetails  where RegistrationID='" + RegId + "'");
        if (dt.Rows.Count > 0)
        {

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}