using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class CO_DownloadVerifiedData : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    int set = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["DistrictCode"]) == "" || Convert.ToString(Session["UserRole"]) != "DAO")
        {
            Response.Redirect("../LoginForm.aspx");
        }
        if (!IsPostBack)
        {
             BindBlock(); BindPanchayat();
        }

    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        DownloadData();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

        /* Verifies that the control is rendered */

    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat();
    }
    #region Function&Method
   
    void BindBlock()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
        objcls.storeProcedure.FieldName = "DistCode";
        objcls.storeProcedure.FieldValue = new object[] { Convert.ToString(Session["DistrictCode"]) };
        DataTable dt = objcls.storeProcedure.getData();
        ddlBlock.DataTextField = "BlockName";
        ddlBlock.DataValueField = "BlockCode";
        ddlBlock.DataSource = dt;
        ddlBlock.DataBind();
        ddlBlock.Items.Insert(0, new ListItem("--All--", "0"));
        if (Session["DistrictCode"].ToString() != "")
        {
            ddlBlock.SelectedValue = Session["BlockCode"].ToString();
            ddlBlock.Enabled = false;
        }
    }
    void BindPanchayat()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetPanchayat");
        objcls.storeProcedure.FieldName = "BlockCode";
        objcls.storeProcedure.FieldValue = new object[] { ddlBlock.SelectedValue };
        DataTable dt = objcls.storeProcedure.getData();
        ddlPanchayat.DataTextField = "PanchayatName";
        ddlPanchayat.DataValueField = "PanchayatCode";
        ddlPanchayat.DataSource = dt;
        ddlPanchayat.DataBind();
        ddlPanchayat.Items.Insert(0, new ListItem("--All--", "0"));
    }

    void DownloadData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetPMKS_Data");
            objcls.storeProcedure.FieldName = "DistCode,blockcode,PanchayatCode,Role,ApplicationType,Status";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToString(Session["DistrictCode"]), ddlBlock.SelectedValue.Trim().ToString(), ddlPanchayat.SelectedValue,2,ddlApplicationType.SelectedValue,ddlStatus.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            GridView grv = new GridView();
            grv.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                grv.DataBind();
                Response.Buffer = true;
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}","Accepted/Rejected_Data.xls"));
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
}