using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Demo : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    string Datefile = DateTime.UtcNow.AddHours(5).AddMinutes(30).AddMilliseconds(10).ToString("ddMMyyyy");
    protected void Page_Load(object sender, EventArgs e)
    {
        BindDist(); BindData();
    }
    void BindDist()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetDistrict");
            DataTable dt = objcls.storeProcedure.getData();
            ddlDistrict.DataTextField = "DistName";
            ddlDistrict.DataValueField = "DistCode";
            ddlDistrict.DataSource = dt;
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch(Exception ee)
        { }
    }
    #region Function&Method


    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetLetterData");
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                gvData.DataSource = dt;
                gvData.DataBind();
            }
        }
        catch (Exception ee)
        { }
    }

    #endregion
    protected void Button1_Click(object sender, EventArgs e)
    {
        // string path = "";
        try
        {
            if (string.IsNullOrEmpty(txtLtrNo.Text.Trim()))
            {
                Response.Write("<script>alert('Enter Letter Number!');</script>");
                return;
            }
            if (string.IsNullOrEmpty(txtLtrDate.Text.Trim()))
            {
                Response.Write("<script>alert('Enter Letter Date!');</script>");
                return;
            }

            if (!FileUpload1.HasFile)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "JJ", "alert('Kindly Upload Letter');", true);
                return;
            }
            string upLPCDoc = "";

            upLPCDoc = objcls.UploadPDF(FileUpload1, "/Documents/" + "Letter_" + DropDownList1.SelectedItem.Text + "/" + Datefile);
            if (upLPCDoc == "~" || upLPCDoc == "Please Select Pdf File Only")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  Document in PDF Format ;", true);
                return;
            }
            if (upLPCDoc == "File Size Large")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  Less then 200 LB PDF ;", true);
                return;
            }

            objcls.storeProcedure.NewStoreProcedure("SP_InsertDAtaForLetter");
            objcls.storeProcedure.AddWithValue("Letterno", txtLtrNo.Text);
            objcls.storeProcedure.AddWithValue("LetterDate", txtLtrDate.Text.Trim());
            objcls.storeProcedure.AddWithValue("Uploadfor", DropDownList1.SelectedItem.Text);
            objcls.storeProcedure.AddWithValue("UploadLetter", upLPCDoc);
            if (objcls.storeProcedure.ExecuteNonQuery())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Letter Uploaded Successfully') ;", true);
                BindData();
            }
        }
        catch (Exception ee)
        {

        }
    }
}