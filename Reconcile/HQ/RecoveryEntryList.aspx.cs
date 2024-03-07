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

public partial class ADM_ReconcileList : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    clsDataAccessNewPMK clsNew = new clsDataAccessNewPMK();
    public ADM_ReconcileList()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Userrole"]) != "HQ")
        {
            Response.Redirect("~/PMKISANAdmin/Login.aspx", true);
        }
        if (!IsPostBack)
        {
            BindDistrict();BindBlock();BindPanchayat(); BindVillage();
        }

    }
    void BindReport()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_Get_tbl_GoI_ReturnData_RecoveryEntryList");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode,VillageCode";
            objcls.storeProcedure.FieldValue = new object[] {ddlDistrict.SelectedValue,ddlBlock.SelectedValue,ddlPanchayat.SelectedValue,ddlVillage.SelectedValue };
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
                gvdata.Visible = false;
		System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Data Not Available.!');", true);
            }

        }
        catch (Exception ee)
        { lblMsg.Text = ee.Message; }
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

    void BindBlock()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] { ddlDistrict.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            ddlBlock.DataTextField = "BlockName";
            ddlBlock.DataValueField = "BlockCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--All--", "0"));
            
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
        ddlPanchayat.Items.Insert(0, new ListItem("--All--", "0"));
    }
    void BindVillage()
    {
        string query = "select VillageCodeLG,VILLNAME+' ('+VillageCodeLG+')' VILLNAME from Village where PanchayatCode='" + ddlPanchayat.SelectedValue + "'";
        DataTable dt = clsNew.GetDataTable(query);        
        ddlVillage.DataTextField = "VILLNAME";
        ddlVillage.DataValueField = "VillageCodeLG";
        ddlVillage.DataSource = dt;
        ddlVillage.DataBind();
        ddlVillage.Items.Insert(0, new ListItem("--All--", "0"));
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
    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindReport();
    }

    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat(); gvdata.Visible = false;ddlPanchayat.SelectedValue = "0";
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBlock(); gvdata.Visible = false;
    }

    protected void ddlPanchayat_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVillage(); gvdata.Visible = false; ddlVillage.SelectedValue = "0";
    }
}