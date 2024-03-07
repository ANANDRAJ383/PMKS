using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class DAO_Familydetails2223 : System.Web.UI.Page
{
    string RegId = "";
    clsDataAccess_Diesel objcls = new clsDataAccess_Diesel();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public DAO_Familydetails2223()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        RegId = Request.QueryString["RegId"].ToString();
        lblRegId.Text = "Registration Id :-" + RegId;
        bindfamilydata(); 
    } 
    protected void btnBack_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }


    void bindfamilydata()
    {
        DataTable dt = new DataTable();
        
        dt = objcls.GetDataTable(@"select RegistrationID,Member,live,Name_FamilyMember from Input2223_FamilyMemberDetailAadharInfo  where RegistrationID='" + RegId + "'");
        if (dt.Rows.Count > 0)
        {

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}

//select RegistrationID, Member, live, Name_FamilyMember from Input2223_FamilyMemberDetailAadharInfo