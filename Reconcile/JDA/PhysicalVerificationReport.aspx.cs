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

public partial class Reconcile_DAO_TargetEntryReport :  System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    clsDataAccess cls = new clsDataAccess();
    clsDataAccessNew clsNew = new clsDataAccessNew();
    public Reconcile_DAO_TargetEntryReport()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Userrole"]) != "JDA")
        {
            Response.Redirect("~/PMKISANAdmin/Login.aspx", true);
        }
        if (!IsPostBack)
        {
            BindDistrict();
        }

    }
    #region function&Method
    void BindDistrict()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_getDivision_District");
            objcls.storeProcedure.FieldName = "DivCode";
            objcls.storeProcedure.FieldValue = new object[] { Session["DivisonCode"].ToString() };
            DataTable dt = objcls.storeProcedure.getData();
            ddlDistrict.DataTextField = "DistName";
            ddlDistrict.DataValueField = "DistCode";
            ddlDistrict.DataSource = dt;
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.Message;
        }
    }

  

    void BindData()
    {
        try
        { 

            objcls.storeProcedure.NewStoreProcedure("SP_Get_PV_PMKisan");
            objcls.storeProcedure.FieldName = "Rtype,DistCode,SubDivisonCode,BlockCode";
            objcls.storeProcedure.FieldValue = new object[] {1, ddlDistrict.SelectedValue, 0, 0};
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                //lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data Not Available.!!!!!');", true);
            }
        }
        catch (Exception ee)
        {
		lblMsg.Text = ee.Message;
        }
    }
    #endregion

    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (ddlDistrict.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select District !!!!!');", true);
            ddlDistrict.Focus();
            return;
        }
       
        
        BindData();
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



    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvdata.Visible = false;

    }
}