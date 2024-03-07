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
                gvdata.DataSource = dt;
                gvdata.DataBind();
            }
            //gvdata.HeaderRow.Cells[0].Style["background-color"] = "#FFBE33";
            //gvdata.HeaderRow.Cells[1].Style["background-color"] = "#FFBE33";
            //gvdata.HeaderRow.Cells[2].Style["background-color"] = "#FFBE33";
            //gvdata.HeaderRow.Cells[3].Style["background-color"] = "#FFBE33";
            //gvdata.HeaderRow.Cells[4].Style["background-color"] = "#FFBE33";
            //gvdata.HeaderRow.Cells[5].Style["background-color"] = "#FFBE33";
            //foreach (GridViewRow row in gvdata.Rows)
            //{
            //    foreach (TableCell cell in row.Cells)
            //    {
            //        gvdata.Columns[0].ItemStyle.BackColor = Color.Goldenrod;
            //        gvdata.Columns[1].ItemStyle.BackColor = Color.LightGreen;
            //        gvdata.Columns[2].ItemStyle.BackColor = Color.DarkOrange;
            //        gvdata.Columns[3].ItemStyle.BackColor = Color.Coral;
            //        gvdata.Columns[4].ItemStyle.BackColor = Color.LightSalmon;
            //        gvdata.Columns[5].ItemStyle.BackColor = Color.Goldenrod;
            //    }
            //}
        }
        catch(Exception ee)
        { }
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