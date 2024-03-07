using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class NPCIDATA : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    int set = 0;
    string Pcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Pcode"] != null && Request.QueryString["Pcode"] != string.Empty)
        {
            Pcode = Request.QueryString["Pcode"].ToString();
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex;
        BindData();
    }

    #region Function&Method




    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetNPICData_Mobile");
            objcls.storeProcedure.FieldName = "PanchayatCode";
            objcls.storeProcedure.FieldValue = new object[] {Pcode };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = "Panchayat--" + dt.Rows[0]["PanchayatName"].ToString() + ',' + dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                //btnSave.Visible = true;
                btnExport.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
                //btnSave.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblMsg.Text = "Record Not available !!!!!";
                btnExport.Visible = false;
            }

        }
        catch
        { }
    }

  
    #endregion

   

  

    
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //if (gvdata.Rows.Count <= 0)
        //{
        //    ScriptManager.RegisterStartupScript(Page, GetType(), "abc", "alert('No Data To Export.');", true);
        //    return;
        //}

        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", lblMsg.Text+"NPCIData_" + DateTime.Now.ToString("dd MMMM yyyy") + ".xls"));
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
       
            gvdata.RenderControl(htw);
        
        
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
}