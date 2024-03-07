using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ADMR_DataListForVerification_Recon_Old : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    DataTable dt = new DataTable();
    SqlTransaction transaction;
    SqlDataAdapter adp = new SqlDataAdapter();
    clsDataAccess clsdata = new clsDataAccess();
    DataSet ds = new DataSet();
    public ADMR_DataListForVerification_Recon_Old()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBox2.Checked = true;
        CheckBox2.ForeColor = System.Drawing.Color.Red;
        if (!IsPostBack)
        {
            BindBlock(); BindPanchayat(); //BindData();

        }
    }

    
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex;
    }

    #region Function&Method


    void BindBlock()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]) };
            DataTable dt = objcls.storeProcedure.getData();
            ddlBlock.DataTextField = "BlockName";
            ddlBlock.DataValueField = "BlockCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }
    }

    void BindPanchayat()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetPanchayat");
        objcls.storeProcedure.FieldName = "BlockCode";
        objcls.storeProcedure.FieldValue = new object[] { ddlBlock.SelectedValue };
        DataTable dt = objcls.storeProcedure.getData();
        ddlPanchayat.DataTextField = "PanchayatNameHnd";
        ddlPanchayat.DataValueField = "PanchayatCode";
        ddlPanchayat.DataSource = dt;
        ddlPanchayat.DataBind();
        ddlPanchayat.Items.Insert(0, new ListItem("--All--", "0"));
    }


    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("Get_ReConList_ForDAOVerify_PMKISANOld");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), ddlBlock.SelectedValue, ddlPanchayat.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            if(dt.Rows.Count>0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                tblBulk.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
                tblBulk.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblMsg.Text ="Record Not available !!!!!";
            }

        }
        catch
        { }
    }

    void Verify()
    {
        try
        {
            int set = 0;
            foreach (GridViewRow row in gvdata.Rows)
            {
                CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
                Label lblRegistrationID = (Label)row.FindControl("lblRegistrationID");
                string AppID = (gvdata.DataKeys[row.RowIndex].Values["Registration_ID"].ToString());
                DropDownList ddlstatusDAO = (DropDownList)row.FindControl("ddlApproved");
                DropDownList ddlApproved = (DropDownList)row.FindControl("ddlApproved");
                TextBox txtCommentDAO = (TextBox)row.FindControl("txtCommentDAO");
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chk.Checked == true)
                    {
                        if (chk.Checked == false)
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please check Decleration....!!');", true);
                            return;
                        }
                        if (string.IsNullOrEmpty(txtCommentDAO.Text.Trim()))
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Kindly enter reason for approval/rejection....!!');", true);
                            return;
                        }

                        string query = @"UPDATE dbo.Registration_PMKISAN
                                SET Re_ADMR_Status=@AC_Status, ADMR_Remarks=@AC_Remarks, ADMR_ActionDate=@AC_ActionDate, 
                                 ADMR_ActionName=@AC_ActionName
                                WHERE Registration_ID= @Registration_ID";
                        SqlDataAdapter da = new SqlDataAdapter(query, con);
                            da.SelectCommand.Parameters.AddWithValue("@AC_Status", ddlApproved.SelectedValue);
                            da.SelectCommand.Parameters.AddWithValue("@AC_Remarks", txtCommentDAO.Text.Trim());
                            da.SelectCommand.Parameters.AddWithValue("@AC_ActionDate", DateTime.Now);
                            da.SelectCommand.Parameters.AddWithValue("@AC_ActionName", Session["UserID"].ToString());
                            da.SelectCommand.Parameters.AddWithValue("@Registration_ID", AppID);
                        con.Open();
                        int i = Convert.ToInt16(da.SelectCommand.ExecuteNonQuery());
                        con.Close();
                        if (i > 0)
                        {
                            set++;

                        }
                        
                    }
                }
            }
            if (set > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(" + set + "'+Data Verified Successfully');", true);
                lblMsg.Text = "Out of " + lblMsg.Text + "," + set + ",Record Verified Successfully";
                //BindData();
                gvdata.Visible = false;
                tblBulk.Visible = false;
            }

        }
        catch
        {

        }
    }

    #endregion

        protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }
   

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        if (chkAll.Checked)
        {
            CheckBox chkDetails = null;

            foreach (GridViewRow gvr in gvdata.Rows)
            {
                chkDetails = (CheckBox)gvr.FindControl("chkDetails");
                chkDetails.Checked = true;
            }
        }

        else
        {
            foreach (GridViewRow gvr in gvdata.Rows)
            {
                CheckBox chkDetails = (CheckBox)gvr.FindControl("chkDetails");
                chkDetails.Checked = false;
            }
        }
    }

    protected void bnSave_Click(object sender, EventArgs e)
    {
        Verify();
    }
}

