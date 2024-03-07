using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class CO_Default : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    protected void Page_Load(object sender, EventArgs e)
    { if (Convert.ToString(Session["Userrole"]) != "CO") { Response.Redirect("~/LoginForm.aspx", true); }
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_Get_PasswordChangeStatus");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,UserId";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), Convert.ToInt32(Session["BlockCode"]), Convert.ToString(Session["Userid"]) };
            DataTable dtNew = objcls.storeProcedure.getData();
            if (dtNew.Rows[0]["PasswordChangeDone"].ToString() == "Y")
            {
                //Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("ChangePassword.aspx");
            }
        }
        catch (Exception ee)
        {
            Response.Write(ee.Message);
        }
    }


    #region Function&Method
    void BindCount()
    {
        //try
        //{
        //    //New
        //    objcls.storeProcedure.NewStoreProcedure("SP_GetCO_Data_Count_New_PMKISAN");
        //    objcls.storeProcedure.FieldName = "DistCode,BlockCode";
        //    objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), Convert.ToInt32(Session["BlockCode"]) };
        //    DataTable dtNew = objcls.storeProcedure.getData();
        //    if (dtNew.Rows.Count > 0)
        //    {
        //        lblTotalForVerifyN.Text = dtNew.Rows[0]["TotalVerify"].ToString().Trim();
        //        lblTotalAcceptedN.Text = dtNew.Rows[0]["TACPT"].ToString().Trim();
        //        lblTotalRejectedN.Text = dtNew.Rows[0]["TRJCT"].ToString().Trim();
        //        lblTotalPendingN.Text = dtNew.Rows[0]["pending"].ToString().Trim();
        //    }
        //    //Recon
        //    objcls.storeProcedure.NewStoreProcedure("SP_GetCO_Data_Count_RECON_PMKISAN");
        //    objcls.storeProcedure.FieldName = "DistCode,BlockCode";
        //    objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), Convert.ToInt32(Session["BlockCode"]) };
        //    DataTable dtRecon = objcls.storeProcedure.getData();
        //    if (dtRecon.Rows.Count > 0)
        //    {
        //        lblTotalForVerify.Text = dtRecon.Rows[0]["TotalVerify"].ToString().Trim();
        //        lblTotalAccepted.Text = dtRecon.Rows[0]["TACPT"].ToString().Trim();
        //        lblTotalRejected.Text = dtRecon.Rows[0]["TRJCT"].ToString().Trim();
        //        lblTotalPending.Text = dtRecon.Rows[0]["pending"].ToString().Trim();
        //    }
        //    //Re-Recon
        //    objcls.storeProcedure.NewStoreProcedure("SP_GetCO_Data_Count_RE-RECON_PMKISAN");
        //    objcls.storeProcedure.FieldName = "DistCode,BlockCode";
        //    objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), Convert.ToInt32(Session["BlockCode"]) };
        //    DataTable dtReRecon = objcls.storeProcedure.getData();
        //    if (dtReRecon.Rows.Count > 0)
        //    {
        //        lblTotalForVerifyR.Text = dtReRecon.Rows[0]["TotalVerify"].ToString().Trim();
        //        lblTotalAcceptedR.Text = dtReRecon.Rows[0]["TACPT"].ToString().Trim();
        //        lblTotalRJCTR.Text = dtReRecon.Rows[0]["TRJCT"].ToString().Trim();
        //        lblTotalPendingR.Text = dtReRecon.Rows[0]["pending"].ToString().Trim();
        //    }
        //}
        //catch (Exception ee)
        //{

        //}
    }

    #endregion
}