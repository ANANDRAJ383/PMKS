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

public partial class DBT_DistrictWiseEKYCData : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindReport();
        }
    }
    void BindReport()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetEKYReportPanchayatWise");
            objcls.storeProcedure.FieldName = "DistrictCode";
            objcls.storeProcedure.FieldValue = new object[] { Session["DistrictCode"] };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                gvdata.DataSource = dt;
                gvdata.DataBind();
            }
            
            
        }
        catch (Exception ee)
        { }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        DownloadData();
        //if (gvdata.Rows.Count <= 0)
        //{
        //    ScriptManager.RegisterStartupScript(Page, GetType(), "abc", "alert('No Data To Export.');", true);
        //    return;
        //}

        //Response.ClearContent();
        //Response.Buffer = true;
        //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}",  DateTime.Now.ToString("dd MMMM yyyy") + "_EKYCPanchayatWiseReport.xls"));
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        ////DataTable dt = new DataTable();
        ////BindData();
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter htw = new HtmlTextWriter(sw);
        ////foreach (GridViewRow row in gvdata.Rows)
        ////{
        ////    foreach (TableCell cell in row.Cells)
        ////    {
        ////        cell.CssClass = "textmode";
        ////    }
        ////}

        //    gvdata.RenderControl(htw);

        ////string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        ////Response.Write(style);
        //Response.Output.Write(sw.ToString());
        //Response.Flush();
        //Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

        /* Verifies that the control is rendered */

    }
    void DownloadData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetEKYReportPanchayatWise");
            objcls.storeProcedure.FieldName = "DistrictCode";
            objcls.storeProcedure.FieldValue = new object[] { Session["DistrictCode"] };
            DataTable dt = objcls.storeProcedure.getData();
            GridView grv = new GridView();
            grv.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                grv.DataBind();
                Response.Buffer = true;
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", DateTime.Now.ToString("dd MMMM yyyy") + "_EKYCPanchayatWiseReport.xls"));
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grv.RenderControl(htw);
                string style = @"<style> td { mso-number-format:\@;} </style>";
                Response.Write(style);
                Response.Write(sw.ToString());
                Response.End();
            }
            else
            {
                Utility.showMessage(this, "No data available");
                return;
            }
        }
        catch (Exception)
        { }
    }
}