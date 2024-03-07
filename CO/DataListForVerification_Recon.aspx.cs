using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CO_DataListForVerification_Recon : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    clsDataAccessNew cls = new clsDataAccessNew();
SqlConnection con = new SqlConnection();
    public CO_DataListForVerification_Recon()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    { if (Convert.ToString(Session["Userrole"]) != "CO") { Response.Redirect("~/pmkisanadmin/LoginForm.aspx", true); }
        CheckBox2.Checked = true;
        CheckBox2.ForeColor = System.Drawing.Color.Red;
        if (!IsPostBack)
        {
            BindBlock(); BindPanchayat(); //BindData();

        }
    }

    
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex;BindData();
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
            if (Convert.ToString(Session["BlockCode"]) != "")
            {
                ddlBlock.SelectedValue= Session["BlockCode"].ToString();
                ddlBlock.Enabled = false;
            }
        }
        catch
        {
        }
    }

    void BindPanchayat()
    {
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("SP_GetPanchayat", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@BlockCode", ddlBlock.SelectedValue);
        DataTable dt = new DataTable();
        da.Fill(dt);


        //objcls.storeProcedure.NewStoreProcedure("SP_GetPanchayat");
        //objcls.storeProcedure.FieldName = "BlockCode";
        //objcls.storeProcedure.FieldValue = new object[] { ddlBlock.SelectedValue };
        //DataTable dt = objcls.storeProcedure.getData();

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
           

            DataTable dt = cls.GetDataTable("exec Get_ACVerifiedList_ForCOVerify '" + Convert.ToInt32(Session["DistrictCode"]) + "','" + ddlBlock.SelectedValue + "','" + ddlPanchayat.SelectedValue + "',Recon");
            
            if(dt.Rows.Count>0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
               // tblBulk.Visible = true;
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
                TextBox txtMutationDate = (TextBox)row.FindControl("txtMutationDate");
               
                if (row.RowType == DataControlRowType.DataRow)
                {
			 
                    if (chk.Checked == true)
                    {if (txtMutationDate.Text == "")
                {
                    lblMsg.Text = "Please Select Land Mutation Date .....";
                    txtMutationDate.Focus();
                    return;
                }
			if (txtMutationDate.Text != "")
                        {
                            var parameterDate = DateTime.ParseExact("02/02/2019", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            var todaysDate = Convert.ToDateTime(txtMutationDate.Text);

                            if (todaysDate >= parameterDate)
                            {
                                lblMsg.Text = "दाखिल - खारिज की तिथि 01/02/2019 से पहले (योजना की मार्गदर्शिका के अनुसार).....";
                                txtMutationDate.Focus();
                                return;
                            }
                        }
                        objcls.storeProcedure.NewStoreProcedure("SP_VerifyAC_Data_FromCO");
                        objcls.storeProcedure.AddWithValue("CO_ActionName", Convert.ToString(Session["UserID"]));
                        objcls.storeProcedure.AddWithValue("Registration_ID", lblRegistrationID.Text.Trim());
                        objcls.storeProcedure.AddWithValue("CODocVerify", "YES");
                        objcls.storeProcedure.AddWithValue("CODocRecent", "YES");
                        objcls.storeProcedure.AddWithValue("COApprove", "YES");
                        objcls.storeProcedure.AddWithValue("CO_Status", rb1.SelectedValue);
                        objcls.storeProcedure.AddWithValue("LandMutationDate", txtMutationDate.Text.Trim());
                        if (objcls.storeProcedure.ExecuteNonQuery())
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
    protected void btnViewDetailBefore_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        WinOpen("MutationDateBeforePMKRecone.aspx?RegId=" + RegId.Trim());
    }
    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        WinOpen("PMKRecon.aspx?RegId=" + RegId.Trim());
    }
    public void WinOpen(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=900,height500,align=center,toolbar=0,addressbar =0, scrollbars=yes');", msg);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "strScript", strScript, true);
        }
        catch (Exception ex) { }
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

