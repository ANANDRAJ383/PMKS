using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PMKisanPaymentDoneDataList : System.Web.UI.Page
{
    clsDataAccessPMKisanNew objcls = new clsDataAccessPMKisanNew();
    protected void Page_Load(object sender, EventArgs e)
    {  
        if(!IsPostBack)
        {
            BindDistrict();BindBlock();BindVillage();
        }

    }
    #region Function&Method

    void BindDistrict()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetDistrict");
            DataTable dt = objcls.storeProcedure.getData();
            ddlDistrict.DataTextField = "DistName";
            ddlDistrict.DataValueField = "lgd_district_code";
            ddlDistrict.DataSource = dt;
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));
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
            objcls.storeProcedure.FieldValue = new object[] { ddlDistrict.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            ddlBlock.DataTextField = "BlockName";
            ddlBlock.DataValueField = "Block_LGCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch
        {
        }
    }

    void BindVillage()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetVillage");
        objcls.storeProcedure.FieldName = "BlockCodeLg";
        objcls.storeProcedure.FieldValue = new object[] { ddlBlock.SelectedValue };
        DataTable dt = objcls.storeProcedure.getData();
        ddlVillage.DataTextField = "VILLNAME";
        ddlVillage.DataValueField = "VillageCodeLG";
        ddlVillage.DataSource = dt;
        ddlVillage.DataBind();
        ddlVillage.Items.Insert(0, new ListItem("--Select--", "0"));
    }


    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetDataFarmers");
            objcls.storeProcedure.FieldName = "DisName,DistCode,BlockCode,VillageCode";
            objcls.storeProcedure.FieldValue = new object[] { ddlDistrict.SelectedItem.Text,ddlDistrict.SelectedValue, ddlBlock.SelectedValue, ddlVillage.SelectedValue };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }

        }
        catch (Exception ee)
        { }
    }

    #endregion

    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindVillage();
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBlock();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex;
        BindData();
    }
}