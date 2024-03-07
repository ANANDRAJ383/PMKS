using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public partial class ADM_DieselReport : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserRole"]) != "HQ" || Convert.ToString(Session["UserRole"]) == "")
        {
            Response.Redirect("../LoginForm.aspx");
        }

    }


    #region Function&Method
    void BindData()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_Get_PV_PMKisan");
        objcls.storeProcedure.FieldName = "RType";
        objcls.storeProcedure.FieldValue = new object[] { ddlReportType.SelectedValue};
        DataTable dt = objcls.storeProcedure.getData();
        lblRType.Text = "";
        lblRType.Text = ddlReportType.SelectedItem.Text ;
        if (dt.Rows.Count > 0)
        {
            ViewState["dtDist"] = dt;
            lblMsg.Text = dt.Rows.Count + ",Records";
            if (ddlReportType.SelectedValue == "1")
            {
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                GridPanOld.Visible = false;
                GridAnk.Visible = false;
                GridViewPDayspending.Visible = false;
            }

            if (ddlReportType.SelectedValue == "2" )
            {
                GridPanOld.DataSource = dt;
                GridPanOld.DataBind();
                GridPanOld.Visible = true;
                gvdata.Visible = false;
                GridAnk.Visible = false;
                GridViewPDayspending.Visible = false;
            }
            if (ddlReportType.SelectedValue == "3" )
            {
                GridAnk.DataSource = dt;
                GridAnk.DataBind();
                GridAnk.Visible = true;
                gvdata.Visible = false;
                GridPanOld.Visible = false;
                GridViewPDayspending.Visible = false;
            }
           
            btnExport.Visible = true;
        }
        else
        {
            gvdata.Visible = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
            lblMsg.Text = "Record Not available !!!!!";
            btnExport.Visible = false;
            GridPanOld.Visible = false;
            GridAnk.Visible = false;
        }
    }

    #endregion
    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalBen = (Label)e.Row.FindControl("lblTotalBen");
                Label lblVerified = (Label)e.Row.FindControl("lblVerified");
               

                lblTotalBen.Text = "0";
                lblVerified.Text = "0";
               

                DataTable dt = (DataTable)ViewState["dtDist"];
                decimal totalT = 0;
                decimal total = 0;
                

                foreach (DataRow dr in dt.Rows)
                {
                    totalT = totalT + Convert.ToDecimal(dr["Total"].ToString());
                    total = total + Convert.ToDecimal(dr["Verified"].ToString());
                    

                }
                lblTotalBen.Text = totalT.ToString();
                lblVerified.Text = total.ToString();
                
                

            }
        }
        catch (Exception ee)
        {


        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        //if (gvdata.Rows.Count <= 0)
        //{
        //    ScriptManager.RegisterStartupScript(Page, GetType(), "abc", "alert('No Data To Export.');", true);
        //    return;
        //}

        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", ddlReportType.SelectedItem.Text +"_"+DateTime.Now.ToString("dd MMMM yyyy")+ ".xls"));
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //DataTable dt = new DataTable();
        //BindData();
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //foreach (GridViewRow row in gvdata.Rows)
        //{
        //    foreach (TableCell cell in row.Cells)
        //    {
        //        cell.CssClass = "textmode";
        //    }
        //}
        if (ddlReportType.SelectedValue == "1")
        {
            gvdata.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "2")
        {
            GridPanOld.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "3" )
        {
            GridAnk.RenderControl(htw);
        }

        //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
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
    protected void GridPanOld_PreRender(object sender, EventArgs e)
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
    protected void GridAnk_PreRender(object sender, EventArgs e)
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
    public override void VerifyRenderingInServerForm(Control control)
    {

        /* Verifies that the control is rendered */

    }

    protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblRType.Text = " " + ddlReportType.SelectedItem.Text;
        gvdata.Visible = false;
        btnExport.Visible = false;
        GridPanOld.Visible = false;
        lblMsg.Text = "";
    }

    protected void ddlApplicationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblRType.Text = lblRType.Text;
        gvdata.Visible = false;
        btnExport.Visible = false;
        GridPanOld.Visible = false;
        lblMsg.Text = "";
    }
}