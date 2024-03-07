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
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindReport();
        }
    }
    void BindReport()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetPV_Report");
            objcls.storeProcedure.FieldName = "Type";
            objcls.storeProcedure.FieldValue = new object[] { 1 };
            DataTable dt = objcls.storeProcedure.getData();
            if(dt.Rows.Count>0)
            {
                ViewState["dtDist"] = dt;
                gvdata.DataSource = dt;
                gvdata.DataBind();
            }
            
        }
        catch(Exception ee)
        { }
    }

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalBen = (Label)e.Row.FindControl("lblTotalBen");
                Label lblIneligible = (Label)e.Row.FindControl("lblIneligible");
                Label lblEligible = (Label)e.Row.FindControl("lblEligible");
                Label lblDeath = (Label)e.Row.FindControl("lblDeath");
                Label lblDeathDAO = (Label)e.Row.FindControl("lblDeathDAO");
                Label lblIneligibleDAO = (Label)e.Row.FindControl("lblIneligibleDAO");
                Label lblDAO_Status = (Label)e.Row.FindControl("lblDAO_Status");

                lblTotalBen.Text = "0";
                lblIneligible.Text = "0";
                lblEligible.Text = "0";
                lblDeath.Text = "0";
                lblDeathDAO.Text = "0";
                lblIneligibleDAO.Text = "0";
                lblDAO_Status.Text = "0";

                DataTable dt = (DataTable)ViewState["dtDist"];
                decimal totalT = 0;
                decimal total = 0;
                decimal total6 = 0;
                decimal total7 = 0;
                decimal total8 = 0;
                decimal total9 = 0;
                decimal total10 = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    totalT = totalT + Convert.ToDecimal(dr["Total"].ToString());
                    total = total + Convert.ToDecimal(dr["Ineligible"].ToString());
                    total6 = total6 + Convert.ToDecimal(dr["Eligible"].ToString());
                    total7 = total7 + Convert.ToDecimal(dr["Death"].ToString());
                    total8 = total8 + Convert.ToDecimal(dr["DeathDAO"].ToString());
                    total9 = total9 + Convert.ToDecimal(dr["IneligibleDAO"].ToString());
                    total10 = total10 + Convert.ToDecimal(dr["DAO_Status"].ToString());

                }
                lblTotalBen.Text = totalT.ToString();
                lblIneligible.Text = total.ToString();
                lblEligible.Text = total6.ToString();
                lblDeath.Text = total7.ToString();
                lblDeathDAO.Text = total8.ToString();
                lblIneligibleDAO.Text = total9.ToString();
                lblDAO_Status.Text = total10.ToString();

            }
        }
        catch (Exception ee)
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
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", DateTime.Now.ToString("dd MMMM yyyy") + "DistrictWisePVData_Report.xls"));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //DataTable dt = new DataTable();
            //BindData();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            lblMsg.RenderControl(htw);
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