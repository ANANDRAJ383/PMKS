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
    {   try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetDallyReport");
            objcls.storeProcedure.FieldName = "ReportType,ApplicationType";
            objcls.storeProcedure.FieldValue = new object[] { ddlReportType.SelectedValue, ddlApplicationType.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            lblRType.Text = "";
            lblRType.Text = ddlReportType.SelectedItem.Text + " " + ddlApplicationType.SelectedItem.Text;
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                if (ddlReportType.SelectedValue == "Dist" && ddlApplicationType.SelectedValue == "V4")
                {
                    GridV4.DataSource = dt;
                    GridV4.DataBind();
                    GridV5.Visible = true;

                }

                if (ddlReportType.SelectedValue == "Block" && ddlApplicationType.SelectedValue == "V5")
                {
                    GridV5.DataSource = dt;
                    GridV5.DataBind();
                    GridV4.Visible = false;
                }
            }
        }
        catch(Exception ee)
        {
            Response.Write(ee.Message);
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
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", ddlReportType.SelectedItem.Text + ddlApplicationType.SelectedItem.Text+"_"+DateTime.Now.ToString("dd MMMM yyyy")+ ".xls"));
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
            GridV4.RenderControl(htw);
        }
        if (ddlReportType.SelectedValue == "Block" && ddlApplicationType.SelectedValue == "OLD")
        {
            GridV5.RenderControl(htw);
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
    {   lblRType.Text = " " + ddlReportType.SelectedItem.Text;
        //gvdata.Visible = false;
      //  btnExport.Visible = false;
        //GridBlockOld.Visible = false;
        //GridPanchOld.Visible = false;
       
        lblMsg.Text = "";
    }

    protected void ddlApplicationType_SelectedIndexChanged(object sender, EventArgs e)
    {   lblRType.Text = lblRType.Text+" " + ddlApplicationType.SelectedItem.Text;
        //gvdata.Visible = false;
       // btnExport.Visible = false;
        //GridBlockOld.Visible = false;
       // GridPanchOld.Visible = false;
        
        lblMsg.Text = "";
    }
}