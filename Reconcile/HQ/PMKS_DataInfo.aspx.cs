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
    clsDataAccessPMKisanPMKISANDB objcls2 = new clsDataAccessPMKisanPMKISANDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserRole"]) != "HQ" || Convert.ToString(Session["UserRole"]) == "")
        {
            Response.Redirect("../LoginForm.aspx");
        }
        if (!IsPostBack)
        {
            BindReport();
        }
    }
    void BindReport()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_Get_Data_Sent_Info_To_GoI");
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
                

                lblTotalBen.Text = "0";
                

                DataTable dt = (DataTable)ViewState["dtDist"];
                decimal totalT = 0;
               

                foreach (DataRow dr in dt.Rows)
                {
                    totalT = totalT + Convert.ToDecimal(dr["Total"].ToString());
                    

                }
                lblTotalBen.Text = totalT.ToString();
                

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