using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using esms_client;

public partial class UploadDBTPM : System.Web.UI.Page
{
   
    clsDataAccessPMKisan clsObj = new clsDataAccessPMKisan();
    string Datefile = DateTime.UtcNow.AddHours(5).AddMinutes(30).AddMilliseconds(10).ToString("ddMMyyyy");
    protected void Page_Load(object sender, EventArgs e)
    {
        Calendar1.StartDate = DateTime.Now.AddYears(-4);
        //Current date can be select but not future date.  
        Calendar1.EndDate = DateTime.Now;
        if(!IsPostBack)
        {
            BindData();
        }
    }

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

            upLPCDoc = clsObj.UploadPDF(FileUpload1, "/Documents/" + "Letter_" + DropDownList1.SelectedItem.Text + "/" + Datefile);
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

            clsObj.storeProcedure.NewStoreProcedure("SP_InsertDAtaForLetter");
            clsObj.storeProcedure.AddWithValue("Letterno", txtLtrNo.Text);
            clsObj.storeProcedure.AddWithValue("LetterDate", txtLtrDate.Text.Trim());
            clsObj.storeProcedure.AddWithValue("Uploadfor", DropDownList1.SelectedItem.Text);
            clsObj.storeProcedure.AddWithValue("UploadLetter", upLPCDoc);
            if (clsObj.storeProcedure.ExecuteNonQuery())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Letter Uploaded Successfully') ;", true);
                BindData();
            }
        }
        catch (Exception ee)
        {

        }
    }

    protected void btnLogIn_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtPassode.Text.Trim()))
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Please Enter Correct Passcode ...');", true);
            Response.Write("<script>alert('Please Enter Correct Passcode ...'');</script>");
            return;
        }
        if (txtPassode.Text.Trim() == "@#$updtltr22dbt22")
        {
            tbl.Visible = true;
            gvData.Visible = true;
          
        }
        else
        {
            tbl.Visible = false;
            gvData.Visible = false;
        }
    }

    #region Function&Method


    void BindData()
    {
        try
        {
            clsObj.storeProcedure.NewStoreProcedure("SP_GetLetterData");
            DataTable dt = clsObj.storeProcedure.getData();
            if(dt.Rows.Count>0)
            {
                gvData.DataSource = dt;
                gvData.DataBind();
            }
        }
        catch(Exception ee)
        { }
    }

    #endregion



}