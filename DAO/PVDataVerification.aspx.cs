using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DAO_DataListForVerification_Re_Recon : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public DAO_DataListForVerification_Re_Recon()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
     
        if (!IsPostBack)
        {
            BindBlock(); BindPanchayat(); 

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
            //objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
            //objcls.storeProcedure.FieldName = "DistCode";
            //objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]) };
            //DataTable dt = objcls.storeProcedure.getData();

            SqlDataAdapter da = new SqlDataAdapter("SP_GetBlock", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@DistCode", Convert.ToInt32(Session["DistrictCode"]));
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlBlock.DataTextField = "BlockNameHN";
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
        //objcls.storeProcedure.NewStoreProcedure("SP_GetPanchayat");
        //objcls.storeProcedure.FieldName = "BlockCode";
        //objcls.storeProcedure.FieldValue = new object[] { ddlBlock.SelectedValue };
        //DataTable dt = objcls.storeProcedure.getData();


        SqlDataAdapter da = new SqlDataAdapter("SP_GetPanchayat", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@BlockCode", ddlBlock.SelectedValue);
        DataTable dt = new DataTable();
        da.Fill(dt);
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



            objcls.storeProcedure.NewStoreProcedure("SP_Get_SocialAuditAll_PMKISANData");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode,RegId,PhyVerifReason";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), ddlBlock.SelectedValue, ddlPanchayat.SelectedValue, "", ddlType.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();

            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblMsg.Text = "Record Not available !!!!!";
            }
         
        }
        catch (Exception ee)
        { }
    }

    void Verify()
    {
        try
        {
            

        }
        catch (Exception xx)
        {
            lblMsg.Text = xx.Message;
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
    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        //string RegId = gvdata.DataKeys[gvdata.SelectedIndex].Values["Registration_ID"].ToString();
        if (RegId != "")
        {
            Response.Redirect("VerifyFarmerRecon.aspx?RegId=" + RegId);
        }


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

   
}

