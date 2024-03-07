using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using VerhoeffCheckDigitLibrary;

public partial class DAO_RefundDetailForm : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    clsDataAccess cls = new clsDataAccess();
    clsDataAccessNew clsNew = new clsDataAccessNew();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    string Datefile = DateTime.UtcNow.AddHours(5).AddMinutes(30).AddMilliseconds(10).ToString("ddMMyyyy");
    public DAO_RefundDetailForm()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Userrole"]) != "AC" || Convert.ToString(Session["UserNewRole"]) != "ATM/BTM")
        {
            Response.Redirect("~/PMKISANAdmin/Login.aspx", true);
        }
        if (!IsPostBack)
        {
            LoadMapedData();
            LoadData();
            BindVillage();
        }
    }
    void LoadData()
    {
        
        string query1 = "select count(*) D from tbl_AC_Details where ActionBy='" + Session["UserID"].ToString() + "'";
        DataTable dtD = clsNew.GetDataTable(query1);
        if (dtD.Rows.Count > 0)
        {
            return;
        }
        else
        {
            string query = "select Name,MobileNo,email,AadhaarNo from loginmaster l where userid='" + Session["UserID"].ToString() + "'";
            DataTable dt = cls.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["Name"].ToString().Trim();
                txtNameInAadhaar.Text = dt.Rows[0]["Name"].ToString().Trim();
                txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString().Trim();
                txtEmail.Text = dt.Rows[0]["email"].ToString().Trim();
            }
        }
    }
    void LoadMapedData()
    {
        string query = "select DistCode ,DistName , BlockCode , BlockName , PanchayatCode ,PanchayatName ,VillageCode , VillageName , AC_Name , MobileNo , NameInAadhaar ,stuff(AadhaarNo, len(AadhaarNo) - 7, 4, 'xxxx') AadhaarNo, EmailId , ActionDate , ActionBy from tbl_AC_Details where ActionBy='" + Session["UserID"].ToString() + "'";
        DataTable dt = clsNew.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            gvdata.DataSource = dt;
            gvdata.DataBind();
            gvdata.Visible = true;
        }
    }
    void BindVillage()
    {
        string query = "select VillageCodeLG,VILLNAME+'('+VillageCodeLG+')' VILLNAME from Village where PanchayatCode='" + Session["PanchayatCode"].ToString() + "'";
        DataTable dt = clsNew.GetDataTable(query);
        chkVillage.DataTextField = "VILLNAME";
        chkVillage.DataValueField = "VillageCodeLG";
        chkVillage.DataSource = dt;
        chkVillage.DataBind();
        //chkVillage.Items.Insert(0, new ListItem("--All--", "0"));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtNameInAadhaar.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Name In Aadhaar !!!!!');", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter Name In Aadhaar !!!!!');", true);
                txtNameInAadhaar.Focus();
                return;
            }
            if (txtAadhaarNo.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Aadhaar Number !!!!!');", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter Aadhaar Number !!!!!');", true);
                txtAadhaarNo.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Email Id !!!!!');", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter Email Id !!!!!');", true);
                txtEmail.Focus();
                return;
            }
            if (chkVillage.SelectedValue == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Village !!!!!');", true);
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select Village !!!!!');", true);
                chkVillage.Focus();
                return;
            }
            if (txtAadhaarNo.Text.Trim() != "")
            {
                if ((txtAadhaarNo.Text.Trim().Length < 12 || txtAadhaarNo.Text.Trim().Length > 12))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('कृपया 12 अंको का सही आधार नंबर लिखे !!!!!');", true);
                    //ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया 12 अंको का सही आधार नंबर लिखे !!!!!');", true);
                    txtAadhaarNo.Text = "";
                    txtAadhaarNo.Focus();
                    lblMsg.Text = "कृपया 12 अंको का सही आधार नंबर लिखे !!!!!";
                    return;

                }
                else
                {
                    string CheckDigit = VerhoeffCheckDigit.CalculateCheckDigit(txtAadhaarNo.Text.Substring(0, 11)).ToString();
                    if (txtAadhaarNo.Text.Substring(11, 1) != CheckDigit)
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('कृपया सही आधार संख्या दर्ज करें!!!!!');", true);
                        //ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया सही आधार संख्या दर्ज करें!!!!!');", true);
                        lblMsg.Text = "कृपया सही आधार संख्या दर्ज करें.....";
                        txtAadhaarNo.Focus();
                        return; 
                    }
                }
            }
            int st = 0;
            foreach (ListItem cBox in chkVillage.Items)
            {
                
                if (cBox.Selected)
                {
                    con.Open();
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"insert into tbl_AC_Details (DistCode ,DistName , BlockCode , BlockName , PanchayatCode ,
                    PanchayatName ,VillageCode , VillageName , AC_Name , MobileNo , NameInAadhaar ,AadhaarNo, EmailId , ActionDate , ActionBy )
                    values(@DistCode ,@DistName ,@BlockCode ,@BlockName ,@PanchayatCode ,@PanchayatName ,@VillageCode ,@VillageName ,@AC_Name 
                     ,@MobileNo ,@NameInAadhaar,@AadhaarNo ,@EmailId ,getdate(),@ActionBy )";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@DistCode", Session["DistrictCode"].ToString());
                    cmd.Parameters.AddWithValue("@DistName", Session["DistrictName "].ToString());
                    cmd.Parameters.AddWithValue("@BlockCode", Session["BlockCode"].ToString());
                    cmd.Parameters.AddWithValue("@BlockName", Session["BlockName"].ToString());
                    cmd.Parameters.AddWithValue("@PanchayatCode", Session["PanchayatCode"].ToString());
                    cmd.Parameters.AddWithValue("@PanchayatName", Session["UserID"].ToString());
                    cmd.Parameters.AddWithValue("@VillageCode", cBox.Value);
                    cmd.Parameters.AddWithValue("@VillageName", cBox.Text);
                    cmd.Parameters.AddWithValue("@AC_Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@NameInAadhaar", txtNameInAadhaar.Text.Trim());
                    cmd.Parameters.AddWithValue("@AadhaarNo", txtAadhaarNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@EmailId", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@ActionBy", Session["UserID"].ToString());
                    int ii = cmd.ExecuteNonQuery();
                    if (ii > 0)
                    {
                        st++; con.Close();
                    }
                }                

            }
            if (st > 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Data Saved Successfully !');", true);
                txtName.Text = "";
                txtMobileNo.Text = "0";
                txtEmail.Text = "";
                txtAadhaarNo.Text = "";
                txtNameInAadhaar.Text = "";
                con.Close(); LoadMapedData();
            }
        }
        catch (Exception ee)
        { lblMsg.Text = ee.Message; }
    }
    protected void gvdata_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;

        if ((gv.ShowHeader == true && gv.Rows.Count > 0)
            || (gv.ShowHeaderWhenEmpty == true))
        {
            //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
            gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        if (gv.ShowFooter == true && gv.Rows.Count > 0)
        {
            //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
            gv.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
}