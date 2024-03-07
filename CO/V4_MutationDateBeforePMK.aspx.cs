using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class CO_PMKNEW : System.Web.UI.Page
{
    string PhyVerifDate = "";
    string RegId = "";string AppType;
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    clsDataAccessNew clsNew = new clsDataAccessNew();
    SqlConnection con = new SqlConnection();SqlConnection con2 = new SqlConnection();
    SqlCommand cmd = new SqlCommand(); SqlCommand cmd2 = new SqlCommand();
    string Datefile = DateTime.UtcNow.AddHours(5).AddMinutes(30).AddMilliseconds(10).ToString("ddMMyyyy");
    public CO_PMKNEW()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
	con2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        RegId = Request.QueryString["RegId"].ToString();
        lblRegId.Text = "Registration Id :-" + RegId; 
        AppType = Request.QueryString["AppType"];
        if (!IsPostBack)
        {
            BindLandDistrict();
        }

    }
    
    protected void btnBack_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }

    #region Land View
    protected void BindCircle(string distcode, DropDownList ddl)
    {
        try
        {
            string QUERY = @"SELECT Circle_Code, Circle_Name, c.Dist_Code FROM CircleMaster_Land as c INNER JOIN
                             DistMaster_land as d on d.Dist_Code = c.Dist_Code inner join Districts ON d.Dist_Code = Districts.DistCode_Land
                             where Districts.distcode = '" + distcode + "'";
            DataTable dt = clsNew.GetDataTable(QUERY);
            ddl.DataSource = dt;
            ddl.DataTextField = "Circle_Name";
            ddl.DataValueField = "Circle_Code";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("---चुनें---", "0"));
        }
        catch
        {
        }

    }

    protected void BindLandDistrict()
    {
        try
        {
            string query = "SELECT DistName,DistCode_Land,DistNameHN from Districts order by DistName";
            DataTable dt = clsNew.GetDataTable(query);
            ddlDistrictland.DataSource = dt;
            ddlDistrictland.DataTextField = "DistName";
            ddlDistrictland.DataValueField = "DistCode_Land";
            ddlDistrictland.DataBind();
            ddlDistrictland.Items.Insert(0, new ListItem("---चुनें---", "0"));
        }
        catch { }
    }
    protected void BindCircle(string distcode)
    {
        try
        {

            string QUERY = @"SELECT Circle_Code, Circle_Name, c.Dist_Code FROM CircleMaster_Land as c INNER JOIN
        DistMaster_land as d on d.Dist_Code = c.Dist_Code inner join Districts ON d.Dist_Code = Districts.DistCode_Land
        where d.Dist_Code = '" + distcode + "'";
            DataTable dt = clsNew.GetDataTable(QUERY);
            ddlCircle.DataSource = dt;
            ddlCircle.DataTextField = "Circle_Name";
            ddlCircle.DataValueField = "Circle_Code";
            ddlCircle.DataBind();
            ddlCircle.Items.Insert(0, new ListItem("---चुनें---", "0"));
        }
        catch { }
    }

    protected void ddlCircle_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHalka();
        BindMauja();
        txtVolume.Text = "";
        txtPageNo.Text = "";
    }
    protected void ddlDistrictland_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCircle(ddlDistrictland.SelectedValue.Trim());
        BindHalka();
        BindMauja();
        txtVolume.Text = "";
        txtPageNo.Text = "";
    }

    protected void BindHalka(DropDownList ddl, string Circle_Code)
    {
        try
        {
            string SQLQuery = string.Empty;
            SQLQuery = @"select   Halka_Code, Halka_Name from dbo.Halka_land where Dist_Code=@Dist_Code and Circle_Code=@Circle_Code";
            DataTable dt = clsNew.GetDataTable(SQLQuery, new SqlParameter[] { new SqlParameter("@Dist_Code", Convert.ToString(ViewState["landDistCode"])), new SqlParameter("@Circle_Code", Circle_Code) });
            ddl.DataSource = dt;
            ddl.DataTextField = "Halka_Name";
            ddl.DataValueField = "Halka_Code";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("---चुनें---", "0"));
        }
        catch
        { }
    }

    protected void BindHalka()
    {

        try
        {
            string SQLQuery = string.Empty;
            SQLQuery = @"select   Halka_Code, Halka_Name from dbo.Halka_land where Dist_Code=@Dist_Code and Circle_Code=@Circle_Code";
            DataTable dt = clsNew.GetDataTable(SQLQuery, new SqlParameter[] { new SqlParameter("@Dist_Code", ddlDistrictland.SelectedValue.Trim()), new SqlParameter("@Circle_Code", ddlCircle.SelectedValue.Trim()) });
            ddlHalka.DataSource = dt;
            ddlHalka.DataTextField = "Halka_Name";
            ddlHalka.DataValueField = "Halka_Code";
            ddlHalka.DataBind();
            ddlHalka.Items.Insert(0, new ListItem("---चुनें---", "0"));
        }
        catch
        { }
    }
    protected void BindMauja()
    {

        try
        {
            string sql = @" select  Mauja_Code, Mauja_Name from dbo.Mauja_land where Dist_Code=@Dist_Code and  Circle_Code=@Circle_Code and  Halka_Code=@Halka_Code";
            DataTable dt = clsNew.GetDataTable(sql, new SqlParameter[] { new SqlParameter("@Dist_Code", ddlDistrictland.SelectedValue.Trim()), new SqlParameter("@Circle_Code", ddlCircle.SelectedValue.Trim()), new SqlParameter("@Halka_Code", ddlHalka.SelectedValue.Trim()) });
            ddlMauja.DataSource = dt;
            ddlMauja.DataTextField = "Mauja_Name";
            ddlMauja.DataValueField = "Mauja_Code";
            ddlMauja.DataBind();
            ddlMauja.Items.Insert(0, new ListItem("---चुनें---", "0"));
        }
        catch
        { }
    }
    protected void ddlHalka_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindMauja();
        txtVolume.Text = "";
        txtPageNo.Text = "";


    }

    #endregion


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (rb3.SelectedValue == "")
        {
            lblMsg.Text = "Please Select Application Status !!!!!";
            return;
        }
        if (rb3.SelectedValue == "1")
        {
            
            if (txtMutationDate.Text == "")
            {
                lblMsg.Text = "Please Select land Mutation Date !!!!!";
                return;
            }
            if (txtKhataNo.Text == "" || txtKhataNo.Text == "0" || txtKheraNo.Text == "" || txtKheraNo.Text == "0" || txtxLandDismil.Text == "" || txtxLandDismil.Text == "0.0")
            {
                lblMsg.Text = "Please enter Khata / Khera / Area !!!!! ";
                return;
            }
        }
        else
        {
            if(txtRemarks.Text=="")
            {
                lblMsg.Text = "Please enter Remarks !!!!! ";
                txtRemarks.Focus();
                return;
            }
            
            cmd.Parameters.Clear();
            con.Open();
            cmd.CommandText = @"update Registration_PMKISAN_New set CO_ActionName=@CO_ActionName,CO_ActionDate=getdate(),CO_Status=@CO_Status where  Registration_ID=@Registration_ID and ApplicationType=@ApplicationType";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CO_ActionName", Convert.ToString(Session["UserID"]));
            cmd.Parameters.AddWithValue("@Registration_ID", RegId);
            cmd.Parameters.AddWithValue("@CO_Status", rb3.SelectedValue);
            cmd.Parameters.AddWithValue("@ApplicationType", AppType);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                lblMsg.Text = "Record Rejected Successfully";
                return;
            }
        }

        //==================File Upload====================================
        string LPCDocument = objcls.UploadPDF(fuDOC, "/LPCPMKIsaan_CoLogin/"+ Datefile + "/");
        ViewState["LPCDocument"] = LPCDocument;
        if (LPCDocument == "~" || LPCDocument == "Please Select jpeg File Only")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  LPC Document ;", true);
            return;
        }
        if (LPCDocument == "File Size Large")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Photo Size 150KB Exceed ;", true);
            return;
        }
        //=========================================================================

        con2.Open();
        cmd2.Parameters.Clear();
        cmd2.CommandText = @"update tbl_PMKisan_LandData_190723 set Circle=@Circle, Halka=@Halka, Mauja=@Mauja, VolumeNo=@VolumeNo, PageNo=@PageNo, khata_no=@khata_no,
                            KhesraNo=@KhesraNo, LandAker=@LandAker, LandDismil=@LandDismil, OwnerName=OwnerName, EntryDate=getdate(),
                            DocPath=@DocPath,DistrictCode=@DistrictCode,BlockCode=@BlockCode where RegistrationID=@RegistrationID)";
        cmd2.CommandType = CommandType.Text;
        cmd2.Connection = con2;
        cmd2.Parameters.AddWithValue("@RegistrationID", RegId);
        cmd2.Parameters.AddWithValue("@DistrictCode", Session["DistrictCode"].ToString());
        cmd2.Parameters.AddWithValue("@BlockCode", Session["BlockCode"].ToString());
        cmd2.Parameters.AddWithValue("@Circle", ddlCircle.SelectedValue.Trim());
        cmd2.Parameters.AddWithValue("@Halka", ddlHalka.SelectedValue.Trim());
        cmd2.Parameters.AddWithValue("@Mauja", ddlMauja.SelectedValue.Trim());
        cmd2.Parameters.AddWithValue("@VolumeNo", txtVolume.Text.Trim());
        cmd2.Parameters.AddWithValue("@PageNo", txtVolume.Text.Trim());
        cmd2.Parameters.AddWithValue("@khata_no", txtKhataNo.Text);
        cmd2.Parameters.AddWithValue("@KhesraNo", txtKheraNo.Text.Trim());
        cmd2.Parameters.AddWithValue("@LandAker", txtLandAkers.Text.Trim());
        cmd2.Parameters.AddWithValue("@LandDismil", txtxLandDismil.Text.Trim());
        cmd2.Parameters.AddWithValue("@OwnerName", txtOwnerName.Text.Trim());
        cmd2.Parameters.AddWithValue("@DocPath", ViewState["LPCDocument"].ToString());
        int ii = cmd2.ExecuteNonQuery();
        if (ii > 0)
        {
            cmd2.Dispose();
            cmd.Parameters.Clear();
	        con2.Close();
            con.Open();
            cmd.CommandText = @"update Registration_PMKISAN_New set LandMutationDate=@LandMutationDate,CO_ActionName=@CO_ActionName,CO_ActionDate=getdate(),CODocVerify=@CODocVerify,CODocRecent=@CODocRecent,COApprove=@COApprove,CO_Status=@CO_Status,LandZero=NULL where  Registration_ID=@Registration_ID and ApplicationType=@ApplicationType";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CO_ActionName", Convert.ToString(Session["UserID"]));
            cmd.Parameters.AddWithValue("@Registration_ID", RegId);
            cmd.Parameters.AddWithValue("@LandMutationDate", txtMutationDate.Text.Trim());
            cmd.Parameters.AddWithValue("@CODocVerify", "YES");
            cmd.Parameters.AddWithValue("@CODocRecent", "YES");
            cmd.Parameters.AddWithValue("@COApprove", "YES");
            cmd.Parameters.AddWithValue("@CO_Status", rb3.SelectedValue);
            cmd.Parameters.AddWithValue("@ApplicationType", AppType);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i>0)
            {
                cmd2.Dispose();
                lblMsg.Text = "Record Verified Successfully";
                txtMutationDate.Text = "";
            }

        }

    }
}