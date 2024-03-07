using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DBT_RecoveryRpt : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindReport();
        }
    }
    void BindReport()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetRecovery_List_PMKS");
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
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
            //gvdata.HeaderRow.Cells[6].Style["background-color"] = "#FFBE33";
            //gvdata.HeaderRow.Cells[7].Style["background-color"] = "#FFBE33";
            //gvdata.HeaderRow.Cells[8].Style["background-color"] = "#FFBE33";
            //gvdata.HeaderRow.Cells[9].Style["background-color"] = "#FFBE33";
            //gvdata.HeaderRow.Cells[10].Style["background-color"] = "#FFBE33";
            //foreach (GridViewRow row in gvdata.Rows)
            //{
            //    foreach (TableCell cell in row.Cells)
            //    {
            //        gvdata.Columns[0].ItemStyle.BackColor = Color.Goldenrod;
            //        gvdata.Columns[1].ItemStyle.BackColor = Color.Aqua;
            //        gvdata.Columns[2].ItemStyle.BackColor = Color.DarkOrange;
            //        gvdata.Columns[3].ItemStyle.BackColor = Color.Coral;
            //        gvdata.Columns[4].ItemStyle.BackColor = Color.Goldenrod;
            //        gvdata.Columns[5].ItemStyle.BackColor = Color.Aqua;
            //        gvdata.Columns[6].ItemStyle.BackColor = Color.DarkOrange;
            //        gvdata.Columns[7].ItemStyle.BackColor = Color.Coral;
            //        gvdata.Columns[8].ItemStyle.BackColor = Color.Goldenrod;
            //        gvdata.Columns[9].ItemStyle.BackColor = Color.Aqua;
            //        gvdata.Columns[10].ItemStyle.BackColor = Color.Goldenrod;

            //    }
            //}
        }
        catch (Exception ee)
        { }
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