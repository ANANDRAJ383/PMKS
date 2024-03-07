using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class CSC_DownloadeKYCData : System.Web.UI.Page
{
    clsDataAccessDiesel objcls = new clsDataAccessDiesel();
    int set = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserRole"]) != "DAO" || Convert.ToString(Session["UserRole"]) == "")
        {
            Response.Redirect("../LoginForm.aspx");
        }
        if (!IsPostBack)
        {
          
        }
    }


    #region Function&Method
   
   
    void DownloadData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetInput2323RejectData_DAO");
            objcls.storeProcedure.FieldName = "DistCode,Status";
            objcls.storeProcedure.FieldValue = new object[] { Session["DistrictCode"].ToString(),ddlDist.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            GridView grv = new GridView();
            grv.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                grv.DataBind();
                Response.Buffer = true;
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}",  "_KIS2223Data.xls"));
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

    #endregion

    #region Events
    public override void VerifyRenderingInServerForm(Control control)
    {

        /* Verifies that the control is rendered */

    }

    

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        DownloadData();
    }

    #endregion
}