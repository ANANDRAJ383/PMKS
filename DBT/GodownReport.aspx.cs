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

public partial class ADM_PMKisanReport : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    protected void Page_Load(object sender, EventArgs e)
    {

        
    }


    #region Function&Method
    void BindData()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetDallyReport");
        objcls.storeProcedure.FieldName = "ReportType,ApplicationType";
        objcls.storeProcedure.FieldValue = new object[] { ddlReportType .SelectedValue,ddlApplicationType.SelectedValue};
        DataTable dt = objcls.storeProcedure.getData();
        lblRType.Text = "";
        lblRType.Text = ddlReportType.SelectedItem.Text+" " + ddlApplicationType.SelectedItem.Text;
        if (dt.Rows.Count > 0)
        {
            lblMsg.Text = dt.Rows.Count + ",Records";
            if (ddlReportType.SelectedValue == "Dist" && ddlApplicationType.SelectedValue == "OLD")
            {
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                GridBlockOld.Visible = false;
                GridPanchOld.Visible = false;
                GridViewOldRe.Visible = false;
                GridViewReconNew.Visible = false;
                GridViewBlockReconNew.Visible = false;
                GridViewBlockReconOld.Visible = false;
            }

            if (ddlReportType.SelectedValue == "Block" && ddlApplicationType.SelectedValue == "OLD")
            {
                GridBlockOld.DataSource = dt;
                GridBlockOld.DataBind();
                GridBlockOld.Visible = true;
                gvdata.Visible = false;
                GridPanchOld.Visible = false;
                GridViewOldRe.Visible = false;
                GridViewReconNew.Visible = false;
                GridViewBlockReconNew.Visible = false;
                GridViewBlockReconOld.Visible = false;
            }
            if (ddlReportType.SelectedValue == "Panch" && ddlApplicationType.SelectedValue == "OLD")
            {
                GridPanchOld.DataSource = dt;
                GridPanchOld.DataBind();
                GridPanchOld.Visible = true;
                gvdata.Visible = false;
                GridBlockOld.Visible = false;
                GridViewOldRe.Visible = false;
                GridViewReconNew.Visible = false;
                GridViewBlockReconNew.Visible = false;
                GridViewBlockReconOld.Visible = false;
            }
            if (ddlReportType.SelectedValue == "Dist" && ddlApplicationType.SelectedValue == "NEW")
            {
                GridDistNew.DataSource = dt;
                GridDistNew.DataBind();
                GridDistNew.Visible = true;
                GridBlockOld.Visible = false;
                GridPanchOld.Visible = false;
                GridBlockNew.Visible = false;
                GridPanNew.Visible = false;
                GridViewOldRe.Visible = false;
                GridViewReconNew.Visible = false;
                GridViewBlockReconNew.Visible = false;
                GridViewBlockReconOld.Visible = false;
            }

            if (ddlReportType.SelectedValue == "Block" && ddlApplicationType.SelectedValue == "NEW")
            {
                GridBlockNew.DataSource = dt;
                GridBlockNew.DataBind();
                GridBlockNew.Visible = true;
                GridDistNew.Visible = false;
                GridPanchOld.Visible = false;
                GridPanNew.Visible = false;
                GridViewOldRe.Visible = false;
                GridViewReconNew.Visible = false;
                GridViewBlockReconNew.Visible = false;
                GridViewBlockReconOld.Visible = false;
            }
            if (ddlReportType.SelectedValue == "Panch" && ddlApplicationType.SelectedValue == "NEW")
            {
                GridPanNew.DataSource = dt;
                GridPanNew.DataBind();
                GridPanNew.Visible = true;
                GridDistNew.Visible = false;
                GridBlockNew.Visible = false;
                GridViewOldRe.Visible = false;
                GridViewReconNew.Visible = false;
                GridViewBlockReconNew.Visible = false;
                GridViewBlockReconOld.Visible = false;
            }
            if (ddlReportType.SelectedValue == "Dist" && ddlApplicationType.SelectedValue == "ORE")
            {
                GridViewOldRe.DataSource = dt;
                GridViewOldRe.DataBind();
                GridViewOldRe.Visible = true;
                GridBlockOld.Visible = false;
                GridPanchOld.Visible = false;
                GridBlockNew.Visible = false;
                GridPanNew.Visible = false;
                GridViewReconNew.Visible = false;
                GridViewBlockReconNew.Visible = false;
                GridViewBlockReconOld.Visible = false;
            }
            if (ddlReportType.SelectedValue == "Dist" && ddlApplicationType.SelectedValue == "NRE")
            {
                GridViewReconNew.DataSource = dt;
                GridViewReconNew.DataBind();
                GridViewReconNew.Visible = true;
                GridBlockOld.Visible = false;
                GridPanchOld.Visible = false;
                GridBlockNew.Visible = false;
                GridPanNew.Visible = false;
                GridViewOldRe.Visible = false;
                GridViewBlockReconNew.Visible = false;
                GridViewBlockReconOld.Visible = false;
            }
            if (ddlReportType.SelectedValue == "Block" && ddlApplicationType.SelectedValue == "NRE")
            {
                GridViewBlockReconNew.DataSource = dt;
                GridViewBlockReconNew.DataBind();
                GridViewBlockReconNew.Visible = true;
                GridViewReconNew.Visible = false;
                GridBlockOld.Visible = false;
                GridPanchOld.Visible = false;
                GridBlockNew.Visible = false;
                GridPanNew.Visible = false;
                GridViewOldRe.Visible = false;
                GridViewBlockReconOld.Visible = false;
            }
            if (ddlReportType.SelectedValue == "Block" && ddlApplicationType.SelectedValue == "ORE")
            {
                btnExport.Visible = true;
                GridViewBlockReconOld.DataSource = dt;
                GridViewBlockReconOld.DataBind();
                GridViewBlockReconOld.Visible = true;
                GridViewReconNew.Visible = false;
                GridBlockOld.Visible = false;
                GridPanchOld.Visible = false;
                GridBlockNew.Visible = false;
                GridPanNew.Visible = false;
                GridViewOldRe.Visible = false;
                GridViewBlockReconNew.Visible = false;
            }
        }
        else
        {
            gvdata.Visible = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
            lblMsg.Text = "Record Not available !!!!!";
            btnExport.Visible = false;
            GridBlockOld.Visible = false;
            GridPanchOld.Visible = false;
            GridPanNew.Visible = false;
            GridDistNew.Visible = false;
            GridBlockNew.Visible = false;
            GridViewReconNew.Visible = false;
            GridViewOldRe.Visible = false;
            GridViewBlockReconNew.Visible = false;
        }
    }

    #endregion

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
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", ddlReportType.SelectedItem.Text + ddlApplicationType.SelectedItem.Text+"_"+DateTime.Now.ToString("dd MMMM yyyy")+ "_DaileyReport.xls"));
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
        if (ddlReportType.SelectedValue == "Dist" && ddlApplicationType.SelectedValue == "OLD")
        {
            gvdata.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "Block" && ddlApplicationType.SelectedValue == "OLD")
        {
            GridBlockOld.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "Panch" && ddlApplicationType.SelectedValue == "OLD")
        {
            GridPanchOld.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "Dist" && ddlApplicationType.SelectedValue == "NEW")
        {
            GridDistNew.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "Block" && ddlApplicationType.SelectedValue == "NEW")
        {
            GridBlockNew.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "Panch" && ddlApplicationType.SelectedValue == "NEW")
        {
            GridPanNew.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "Dist" && ddlApplicationType.SelectedValue == "ORE")
        {
            GridViewOldRe.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "Dist" && ddlApplicationType.SelectedValue == "NRE")
        {
            GridViewReconNew.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "Block" && ddlApplicationType.SelectedValue == "NRE")
        {
            GridViewBlockReconNew.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "Block" && ddlApplicationType.SelectedValue == "ORE")
        {
            GridViewBlockReconOld.RenderControl(htw);
        }
        //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
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
        GridBlockOld.Visible = false;
        GridPanchOld.Visible = false;
        GridPanNew.Visible = false;
        GridDistNew.Visible = false;
        GridBlockNew.Visible = false;
        GridViewReconNew.Visible = false;
        GridViewOldRe.Visible = false;
        GridViewBlockReconNew.Visible = false;
        GridViewBlockReconOld.Visible = false;
        lblMsg.Text = "";
    }

    protected void ddlApplicationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblRType.Text = lblRType.Text+" " + ddlApplicationType.SelectedItem.Text;
        gvdata.Visible = false;
        btnExport.Visible = false;
        GridBlockOld.Visible = false;
        GridPanchOld.Visible = false;
        GridPanNew.Visible = false;
        GridDistNew.Visible = false;
        GridBlockNew.Visible = false;
        GridViewReconNew.Visible = false;
        GridViewOldRe.Visible = false;
        GridViewBlockReconNew.Visible = false;
        GridViewBlockReconOld.Visible = false;
        lblMsg.Text = "";
    }
}