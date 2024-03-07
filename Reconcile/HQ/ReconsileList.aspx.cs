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
            objcls.storeProcedure.NewStoreProcedure("SP_Get_ReconsileList");
            objcls.storeProcedure.FieldName = "DistCode,mode,Approved";
            objcls.storeProcedure.FieldValue = new object[] { ddlDistrict.SelectedValue, ddlPaymentMode.SelectedValue, ddlApproved.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }
	     else
            {
                gvdata.Visible = false; lblMsg.Text = "";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Data Not Available.!');", true);
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
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvdata.Visible = false;
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