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
        if (Convert.ToString(Session["Userrole"]) != "DAO" )
        {
            Response.Redirect("~/PMKISANAdmin/Login.aspx", true);
        }
        if (!IsPostBack)
        {
            BindBlock(); BindPanchayat();
        }
    }
    void BindBlock()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]) };
            DataTable dt = objcls.storeProcedure.getData();
            ddlBlock.DataTextField = "BlockName";
            ddlBlock.DataValueField = "BlockCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--Select--", "0"));
            
        }
        catch
        {
        }
    }

    void BindPanchayat()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetPanchayat");
        objcls.storeProcedure.FieldName = "BlockCode";
        objcls.storeProcedure.FieldValue = new object[] { ddlBlock.SelectedValue };
        DataTable dt = objcls.storeProcedure.getData();
        ddlPanchayat.DataTextField = "PanchayatName";
        ddlPanchayat.DataValueField = "PanchayatCode";
        ddlPanchayat.DataSource = dt;
        ddlPanchayat.DataBind();
        ddlPanchayat.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    void LoadMapedData()
    {
        string query = @"select DistCode ,DistName , BlockCode , BlockName , PanchayatCode ,PanchayatName ,VillageCode , 
                        VillageName , AC_Name , MobileNo , NameInAadhaar ,stuff(AadhaarNo, len(AadhaarNo) - 7, 4, 'xxxx') AadhaarNo, 
                        EmailId , ActionDate , ActionBy from tbl_AC_Details where PanchayatCode='" + ddlPanchayat.SelectedValue + "'";
        DataTable dt = clsNew.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            gvdata.DataSource = dt;
            gvdata.DataBind();
            gvdata.Visible = true;
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('No Record ');", true);
            gvdata.Visible = false;
        }
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlBlock.SelectedValue == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Block !!!!!');", true);
                ddlBlock.Focus();
                return;
            }
            if (ddlPanchayat.SelectedValue == "")
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Panchayat !!!!!');", true);
                ddlPanchayat.Focus();
                return;
            }
            LoadMapedData();
        }
        catch (Exception ee)
        { lblMsg.Text = ee.Message; }
    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat(); gvdata.Visible = false; ddlPanchayat.SelectedValue = "0";
    }
    protected void gvdata_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;

        if ((gv.ShowHeader == true && gv.Rows.Count > 0) || (gv.ShowHeaderWhenEmpty == true))
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