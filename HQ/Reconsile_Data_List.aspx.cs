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

public partial class DBT_DistrictWisePVData : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    protected void Page_Load(object sender, EventArgs e)
    { 
        if(!IsPostBack)
        {
            BindDistrict(); BindBank();
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
            objcls.storeProcedure.NewStoreProcedure("SP_Get_tbl_GoI_ReturnData_For_Reconsile_130723");
            objcls.storeProcedure.FieldName = "DistCode,Reason,PaymentMode,BankCode";
            objcls.storeProcedure.FieldValue = new object[] { ddlDistrict.SelectedValue,ddlReason.SelectedValue,ddlPaymentType.SelectedValue,ddlBank.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            if(dt.Rows.Count>0)
            {
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }
           
        }
        catch(Exception ee)
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
        catch (Exception ee)
        {
        }
    }
    void BindBank()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetBank");
            DataTable dt = objcls.storeProcedure.getData();
            ddlBank.DataTextField = "BankName";
            ddlBank.DataValueField = "BankCode";
            ddlBank.DataSource = dt;
            ddlBank.DataBind();
            ddlBank.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch(Exception ee)
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

    protected void lbkExport_Click(object sender, EventArgs e)
    {
        
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //PhysicalVerificationReport
        /* Verifies that the control is rendered */
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", DateTime.Now.ToString("dd MMMM yyyy") + "Recovery_Report.xls"));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //DataTable dt = new DataTable();
            //BindData();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            //lblMsg.RenderControl(htw);
            gvdata.RenderControl(htw);

            //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ee)
        {

        }
    }
}