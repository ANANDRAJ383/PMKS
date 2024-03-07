﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HQ_Done : System.Web.UI.Page
{string PhyVerifDate = "";
    string RegId = "";
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public HQ_Done()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBox2.Checked = true;

        if (Request.QueryString["RegId"] != null && Request.QueryString["RegId"] != string.Empty)
        {
            RegId = Request.QueryString["RegId"].ToString();
		//BindDate();
        }
        if (Convert.ToString(Session["UserRole"]) == "" || Convert.ToString(Session["UserRole"]) == null)
        {
            Response.Redirect("../LoginForm.aspx");
        }

        if (!IsPostBack)
        {

        }

    }

	void BindDate()
    {
        DataTable dtt = objcls.GetDataTable("Select * from SocialAuditAll_PMKISAN where RegistrationNo='" + RegId+ "'");
        if (dtt.Rows.Count > 0)
        {
            txtPhyVerifDate.Text = dtt.Rows[0]["PhyVerifDate"].ToString().Trim();// PhyVerifDate.ToString();
        }
    }
    protected void bnSave_Click(object sender, EventArgs e)
    {
        if (txtRemarks.Text == "")
        {
            lblMsg.Text = "Please fill remark !!!!!";
            txtRemarks.Focus();
            return;
        }
        if (ddlStatus.SelectedValue == "0")
        {
            lblMsg.Text = "Please Select Status !!!!!";
            ddlStatus.Focus();
            return;
        }
        /*if (ddlStatus.SelectedValue == "1")
        {
            if (txtPhyVerifDate.Text == "")
            {
                lblMsg.Text = "Please select Date ......";
                return;
            }
        }
        if (ddlStatus.SelectedValue == "2")
        {
            txtPhyVerifDate.Text = "";
        }*/

        cmd.Parameters.Clear();
        con.Open();
        cmd.CommandText = @"update SocialAuditAll_PMKISAN set ADM_Status=@ADM_Status,PhyVerifDate=@PhyVerifDate , ADMActiondate=GETDATE() , ADMActionName=@ADM_ActionName,ADMRemarks=@ADMRemark where  RegistrationNo=@RegistrationNo ";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@ADM_ActionName", Convert.ToString(Session["UserID"]));
        cmd.Parameters.AddWithValue("@RegistrationNo", RegId);
        cmd.Parameters.AddWithValue("@ADM_Status", ddlStatus.SelectedValue);
        if (ddlStatus.SelectedValue == "0")
        {
            lblMsg.Text = "Please Select Status !!!!!";
            ddlStatus.Focus();
            return;
        }
        if (ddlStatus.SelectedValue == "1")
        {
            if (txtPhyVerifDate.Text == "")
            {
                lblMsg.Text = "Please select Date ......";
                txtPhyVerifDate.Focus();
                return;
            }
        }
        if (ddlStatus.SelectedValue == "2")
        {
            txtPhyVerifDate.Text = "";
        }
        cmd.Parameters.AddWithValue("@PhyVerifDate", txtPhyVerifDate.Text.Trim());
        cmd.Parameters.AddWithValue("@ADMRemark", txtRemarks.Text.Trim());
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {

            cmd.Dispose();
            lblMsg.Text = "Record Verified Successfully";
            txtPhyVerifDate.Text = "";
            txtRemarks.Text = "";
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}