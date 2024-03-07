using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HQ_ContactDetails : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindDistrict(); BindBlock(); BindPanchayat(); BindData();
    }

    void BindDistrict()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_getDistrict");
            DataTable dt = objcls.storeProcedure.getData();
            ddlDist.DataTextField = "DistName";
            ddlDist.DataValueField = "DistCode";
            ddlDist.DataSource = dt;
            ddlDist.DataBind();
            ddlDist.Items.Insert(0, new ListItem("--All--", "0"));
            if(Session["DistrictCode"].ToString() !="")
            {
                ddlDist.SelectedValue = Session["DistrictCode"].ToString();
                ddlDist.Enabled = true;
            }
        }
        catch
        {
        }
    }
    void BindBlock()
    {
        try
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
            objcls.storeProcedure.NewStoreProcedure("SP_GetMobileDetail_PMKisan");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode,role";
            objcls.storeProcedure.FieldValue = new object[] { ddlDist.SelectedValue, ddlBlock.SelectedValue, ddlPanchayat.SelectedValue, ddlRole.SelectedValue };
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
        { lblMsg.Text = ee.Message; }
    }
    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBlock();
    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }
}