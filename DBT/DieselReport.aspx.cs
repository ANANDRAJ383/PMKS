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
    clsDataAccessDiesel objcls = new clsDataAccessDiesel();
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
        objcls.storeProcedure.NewStoreProcedure("SP_GetDieselReport");
        objcls.storeProcedure.FieldName = "RType";
        objcls.storeProcedure.FieldValue = new object[] { ddlReportType.SelectedValue};
        DataTable dt = objcls.storeProcedure.getData();
        lblRType.Text = "";
        lblRType.Text = ddlReportType.SelectedItem.Text ;
        if (dt.Rows.Count > 0)
        {
            lblMsg.Text = dt.Rows.Count + ",Records";
            if (ddlReportType.SelectedValue == "1")
            {
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                GridBlockOld.Visible = false;
                GridPanchOld.Visible = false;
            }

            if (ddlReportType.SelectedValue == "2" )
            {
                GridBlockOld.DataSource = dt;
                GridBlockOld.DataBind();
                GridBlockOld.Visible = true;
                gvdata.Visible = false;
                GridPanchOld.Visible = false;
            }
            if (ddlReportType.SelectedValue == "3" )
            {
                GridPanchOld.DataSource = dt;
                GridPanchOld.DataBind();
                GridPanchOld.Visible = true;
                gvdata.Visible = false;
                GridBlockOld.Visible = false;
            }
            btnExport.Visible = true;
        }
        else
        {
            gvdata.Visible = false;
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
            lblMsg.Text = "Record Not available !!!!!";
            btnExport.Visible = false;
            GridBlockOld.Visible = false;
            GridPanchOld.Visible = false;
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
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", ddlReportType.SelectedItem.Text +"_"+DateTime.Now.ToString("dd MMMM yyyy")+ "_DieselDaileyReport.xls"));
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
            GridBlockOld.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "3" )
        {
            GridPanchOld.RenderControl(htw);
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
        lblMsg.Text = "";
    }

    protected void ddlApplicationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblRType.Text = lblRType.Text;
        gvdata.Visible = false;
        btnExport.Visible = false;
        GridBlockOld.Visible = false;
        GridPanchOld.Visible = false;
        lblMsg.Text = "";
    }
}