using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DAO_Default : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    protected void Page_Load(object sender, EventArgs e)
    {
        //BindCount();
    }


    #region Function&Method
    void BindCount()
    {
        try
        {  //Recon
            objcls.storeProcedure.NewStoreProcedure("SP_GetDAO_Data_Count_Recon_PMKISAN");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]) };
            DataTable dtRecon = objcls.storeProcedure.getData();
            if (dtRecon.Rows.Count > 0)
            {
                lblTotalForVerify.Text= dtRecon.Rows[0]["TotalVerify"].ToString().Trim();
                lblTotalPending.Text = dtRecon.Rows[0]["pending"].ToString().Trim();
                lblTotalRejected.Text = dtRecon.Rows[0]["TRJCT"].ToString().Trim();
                lblTotalAccepted.Text = dtRecon.Rows[0]["TACPT"].ToString().Trim();
            }
            //Re-Recon
            objcls.storeProcedure.NewStoreProcedure("SP_GetDAO_Data_Count_Re_Recon_PMKISAN");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]) };
            DataTable dtReRecon = objcls.storeProcedure.getData();
            if (dtReRecon.Rows.Count > 0)
            {
                lblTotalForVerifyR.Text = dtReRecon.Rows[0]["TotalVerify"].ToString().Trim();
                lblTotalAcceptedR.Text = dtReRecon.Rows[0]["TACPT"].ToString().Trim();
                lblTotalRJCTR.Text = dtReRecon.Rows[0]["TRJCT"].ToString().Trim();
                lblTotalPendingR.Text = dtReRecon.Rows[0]["pending"].ToString().Trim();
            }
        }
        catch(Exception ee)
        {

        }
    }

    #endregion
}