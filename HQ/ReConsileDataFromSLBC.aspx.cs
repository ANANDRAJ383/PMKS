using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HQ_ReConsileDataFromBank : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind_SLBC_UBGB_Recovery_List();
        if (!IsPostBack)
        {

            
        }
    }


    #region Function&Method
  
    void Bind_SLBC_UBGB_Recovery_List()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_Get_SLBC_UBGB_Recovery_List");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] { "" };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = "जिलावार एसएलबीसी डेटा सूची से कटौती की राशि दिनांक :-" + DateTime.Now;
                grdBankData.DataSource = dt;
                grdBankData.DataBind();
                grdBankData.Visible = true;
                btnExport.Visible = true;
                lnkBack.Visible = false;
            }
            else
            {
                grdBankData.Visible = false;
                btnExport.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
               // lblMsg.Text = "Record Not available !!!!!";
            }

        }
        catch (Exception ee)
        { lblMsg.Text = ee.Message; }
    }
    void BindData(string DistCode)
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_Get_SLBC_UBGB_Recovery_List");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] {DistCode };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                
                //lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                grdBankData.Visible = false;
                lnkBack.Visible = true;
            }
            else
            {
                gvdata.Visible = false; grdBankData.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblMsg.Text = DistCode;//"Record Not available !!!!!";
            }

        }
        catch (Exception ee)
        { lblMsg.Text = ee.Message; }
    }

    #endregion



    protected void grdBankData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Dist")
        {
            string DistCode = e.CommandArgument.ToString();
            ViewState["discode"] = DistCode;
            BindData(DistCode);
            grdBankData.Visible = false;
            gvdata.Visible = true;
            //grdpanchayat.Visible = false;
            lnkBack.Visible = true;
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int rowIndex = gvr.RowIndex;
            LinkButton lnkDistrict = (LinkButton)grdBankData.Rows[rowIndex].FindControl("lnkDistrict");
            ViewState["disheader"] = lnkDistrict.Text;
            lblMsg.Text = DistCode+ lnkDistrict.Text + "  का एसएलबीसी डेटा सूची से कटौती की राशि दिनांक :-" + DateTime.Now;
        }
    }
}