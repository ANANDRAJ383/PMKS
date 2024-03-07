using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class LoginList : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        if (!IsPostBack)
        {
            BindDistrict();

        }
    }

    
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex;
        BindData();
    }

    #region Function&Method

    void BindDistrict()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetAudit_District_PMKS");
            DataTable dt = objcls.storeProcedure.getData();
            ddlDist.DataTextField = "DistName";
            ddlDist.DataValueField = "DistCode";
            ddlDist.DataSource = dt;
            ddlDist.DataBind();
            ddlDist.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }
    }
   


    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetAudit_DataList_PMKS");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] { ddlDist.SelectedValue };
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
        {lblMsg.Text = ee.Message; }
    }

 

    #endregion

 
    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        WinOpen("Print_PMKisanYojna.aspx?RegId=" + RegId.Trim());
    }
    public void WinOpen(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=1000,height=500,align=center,toolbar=0,addressbar =0, scrollbars=yes');", msg);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "strScript", strScript, true);
        }
        catch (Exception ex) { }
    }




}

