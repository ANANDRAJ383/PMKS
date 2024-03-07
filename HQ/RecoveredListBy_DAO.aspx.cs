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

public partial class HQ_RecoveredListBy_DAO : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    public HQ_RecoveredListBy_DAO()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDistrict();
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindReport();
    }
    void BindReport()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_Get_RecoveredListBy_DAO");
            objcls.storeProcedure.FieldName = "DistCode,mode";
            objcls.storeProcedure.FieldValue = new object[] { ddlDistrict.SelectedValue, ddlPaymentMode.SelectedValue};
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }

        }
        catch (Exception ee)
        { }
    }

    void BindDistrict()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetDistrict");
            DataTable dt = objcls.storeProcedure.getData();
            ddlDistrict.DataTextField = "DistName";
            ddlDistrict.DataValueField = "DistCode";
            ddlDistrict.DataSource = dt;
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }
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

    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        cmd.Parameters.Clear();
        con.Open();
        cmd.CommandText = @"update tbl_PMKisanRecoveryData set Approved=@Approved where  RegistrationId=@RegistrationId ";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@Approved", "Y");
        cmd.Parameters.AddWithValue("@RegistrationId", RegId);
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {

            cmd.Dispose();
            lblMsg.Text = "Record Matched";
           
        }
    }

    protected void btnBackDAO_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        cmd.Parameters.Clear();
        con.Open();
        cmd.CommandText = @"update tbl_PMKisanRecoveryData set Approved=@Approved where  RegistrationId=@RegistrationId ";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@Approved", "N");
        cmd.Parameters.AddWithValue("@RegistrationId", RegId);
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {

            cmd.Dispose();
            lblMsg.Text = "Record Not Matched";

        }
    }
}