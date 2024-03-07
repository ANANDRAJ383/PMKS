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
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    int set = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserRole"]) != "DAO" || Convert.ToString(Session["UserRole"]) == "")
        {
            Response.Redirect("../LoginForm.aspx");
        }
        if (!IsPostBack)
        {
            BindDist(); BindBlock(); BindPanchayat();
        }
    }


    #region Function&Method
    void BindDist()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetDistrict");
        DataTable dt = objcls.storeProcedure.getData();
        ddlDist.DataTextField = "DistName";
        ddlDist.DataValueField = "DistCode";
        ddlDist.DataSource = dt;
        ddlDist.DataBind();
        ddlDist.Items.Insert(0, new ListItem("--Select--", "0"));
        if(Session["DistrictCode"].ToString()!="")
        {
            ddlDist.SelectedValue = Session["DistrictCode"].ToString();
            ddlDist.Enabled = false;
        }
    }
    void BindBlock()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
        objcls.storeProcedure.FieldName = "DistCode";
        objcls.storeProcedure.FieldValue = new object[] { ddlDist.SelectedValue };
        DataTable dt = objcls.storeProcedure.getData();
        ddlBlock.DataTextField = "BlockName";
        ddlBlock.DataValueField = "BlockCode";
        ddlBlock.DataSource = dt;
        ddlBlock.DataBind();
        ddlBlock.Items.Insert(0, new ListItem("--All--", "0"));
    }
    void BindPanchayat()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetPanchayat");
        objcls.storeProcedure.FieldName = "BlockCode";
        objcls.storeProcedure.FieldValue = new object[] { ddlBlock.SelectedValue};
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
            objcls.storeProcedure.NewStoreProcedure("SP_Download_AadhaarEditFailure_DataPMKisan");
            objcls.storeProcedure.FieldName = "DistCode,blockcode,panCode";
            objcls.storeProcedure.FieldValue = new object[] { ddlDist.SelectedValue, ddlBlock.SelectedValue.Trim().ToString(), ddlPanchayat.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            GridView grv = new GridView();
            grv.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                grv.DataBind();
                Response.Buffer = true;
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", ddlPanchayat.SelectedItem.Text + "_AadhaarEditFailureData.xls"));
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

    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBlock();
    }

    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat();
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        DownloadData();
    }

    #endregion
}