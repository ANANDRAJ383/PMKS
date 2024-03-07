using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CO_MutationDateVerification : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public CO_MutationDateVerification()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {if (Convert.ToString(Session["DistrictCode"]) == "" || Convert.ToString(Session["UserRole"]) != "CO")
        {
            Response.Redirect("../LoginForm.aspx");
        }
        
        if (!IsPostBack)
        {
             BindPanchayat(); //BindData();

        }
    }
    #region Function&Method
  
    void BindPanchayat()
    {
        //objcls.storeProcedure.NewStoreProcedure("SP_GetPanchayat");
        //objcls.storeProcedure.FieldName = "BlockCode";
        //objcls.storeProcedure.FieldValue = new object[] { ddlBlock.SelectedValue };
        //DataTable dt = objcls.storeProcedure.getData();

        SqlDataAdapter da = new SqlDataAdapter("SP_GetPanchayat", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@BlockCode", Session["BlockCode"].ToString());
        DataTable dt = new DataTable();
        da.Fill(dt);
        ddlPanchayat.DataTextField = "PanchayatName";
        ddlPanchayat.DataValueField = "PanchayatCode";
        ddlPanchayat.DataSource = dt;
        ddlPanchayat.DataBind();
        ddlPanchayat.Items.Insert(0, new ListItem("--All--", "0"));
    }
    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("Get_ReConList_ForMutationDateEntry_PMKISAN");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode,RegId,Type";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), Session["BlockCode"].ToString(), ddlPanchayat.SelectedValue, txtRegId.Text.Trim(), ddlType.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            if(dt.Rows.Count>0)
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
        catch(Exception ee)
        {
            lblMsg.Text = ee.Message;
        }
    }
  
    #endregion
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex;
    }
    
    protected void btnView_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnViewDetailBefore_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        string AppType = gvdata.DataKeys[rowIndex].Values[1].ToString();
        //WinOpen("V4_MutationDateBeforePMK.aspx?RegId=" + RegId.Trim() & "AppType=" + AppType);
        WinOpen("V4_MutationDateBeforePMK.aspx?RegId=" + RegId.Trim() + "&AppType=" + AppType.Trim());

    }
    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();

        WinOpen("PMKMutation.aspx?RegId=" + RegId.Trim());
    }
    public void WinOpen(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=1100,height=1100,align=center,toolbar=0,addressbar =0, scrollbars=yes');", msg);
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
  
}

