using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ADM_Default : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindDashboard();
    }


    #region Function&Method
   void BindDashboard()
    {
        try
        {
           // string dd = DateTime.Now;
            objcls.storeProcedure.NewStoreProcedure("SP_get_Dashboard_Data_PMKS");
           // objcls.storeProcedure.FieldName = "ReportDate";
           // objcls.storeProcedure.FieldValue = new object[] { DateTime.Now.ToString() };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {  //===================================================================================
                lblTotalAC.Text = dt.Rows[0]["TotalFresh"].ToString().Trim();//(Convert.ToInt32(dt.Rows[0]["TotalFresh"])-(Convert.ToInt32(dt.Rows[0]["ACAccept"]) + Convert.ToInt32(dt.Rows[0]["ACReject"]) + Convert.ToInt32(dt.Rows[0]["ACPending"]))).ToString();//
                lblACAcpt.Text =  dt.Rows[0]["ACAccept"].ToString().Trim();
                lblACRjct.Text = dt.Rows[0]["ACReject"].ToString().Trim();
                lblACPending.Text = dt.Rows[0]["ACPending"].ToString().Trim();
                //========================================================================
                lblDAOReTotal.Text = dt.Rows[0]["TotalRecon"].ToString().Trim();//(Convert.ToInt32(dt.Rows[0]["TotalRecon"]) - (Convert.ToInt32(dt.Rows[0]["DAOAcceptRe"]) + Convert.ToInt32(dt.Rows[0]["DAORejectRe"]) + Convert.ToInt32(dt.Rows[0]["DAOPendingRe"]))).ToString();//
                lblDAOReAcpt.Text = dt.Rows[0]["DAOAcceptRe"].ToString().Trim();
                lblDAOReRjct.Text = dt.Rows[0]["DAORejectRe"].ToString().Trim();
                lblDAORePending.Text = dt.Rows[0]["DAOPendingRe"].ToString().Trim();

                lblDAOReReTotal.Text = dt.Rows[0]["TotalReRecon"].ToString().Trim();//(Convert.ToInt32(dt.Rows[0]["TotalReRecon"]) - (Convert.ToInt32(dt.Rows[0]["DAOAcceptReRe"]) + Convert.ToInt32(dt.Rows[0]["DAORejectReRe"]) + Convert.ToInt32(dt.Rows[0]["DAOPendingReRe"]))).ToString();//
                lblDAOReReAcpt.Text = dt.Rows[0]["DAOAcceptReRe"].ToString().Trim();
                lblDAOReReRjct.Text = dt.Rows[0]["DAORejectReRe"].ToString().Trim();
                lblDAOReRePending.Text = dt.Rows[0]["DAOPendingReRe"].ToString().Trim();
                //============================================================================
                lblADMRTotal.Text = dt.Rows[0]["TotalFresh"].ToString().Trim(); //(Convert.ToInt32(dt.Rows[0]["TotalFresh"]) - (Convert.ToInt32(dt.Rows[0]["ADMRAccept"]) + Convert.ToInt32(dt.Rows[0]["ADMRReject"]) + Convert.ToInt32(dt.Rows[0]["ADMRPending"]))).ToString();//dt.Rows[0]["TotalFresh"].ToString().Trim();
                lblADMRAcpt.Text = dt.Rows[0]["ADMRAccept"].ToString().Trim();
                lblADMRRjct.Text = dt.Rows[0]["ADMRReject"].ToString().Trim();
                lblADMRPending.Text = dt.Rows[0]["ADMRPending"].ToString().Trim();

                lblADMRReTotal.Text = dt.Rows[0]["TotalRecon"].ToString().Trim(); //(Convert.ToInt32(dt.Rows[0]["TotalRecon"]) - (Convert.ToInt32(dt.Rows[0]["ADMRAcceptRe"]) + Convert.ToInt32(dt.Rows[0]["ADMRRejectRe"]) + Convert.ToInt32(dt.Rows[0]["ADMRPendingRe"]))).ToString();//dt.Rows[0]["TotalFresh"].ToString().Trim();
                lblADMRReAcpt.Text = dt.Rows[0]["ADMRAcceptRe"].ToString().Trim();
                lblADMRReRjct.Text = dt.Rows[0]["ADMRRejectRe"].ToString().Trim();
                lblADMRRePending.Text = dt.Rows[0]["ADMRPendingRe"].ToString().Trim();

                lblADMRReReTotal.Text = dt.Rows[0]["TotalReRecon"].ToString().Trim(); //(Convert.ToInt32(dt.Rows[0]["TotalReRecon"]) - (Convert.ToInt32(dt.Rows[0]["ADMRAcceptReRe"]) + Convert.ToInt32(dt.Rows[0]["ADMRRejectReRe"]) + Convert.ToInt32(dt.Rows[0]["ADMRPendingReRe"]))).ToString();//dt.Rows[0]["TotalFresh"].ToString().Trim();
                lblADMRReReAcpt.Text = dt.Rows[0]["ADMRAcceptReRe"].ToString().Trim();
                lblADMRReReRjct.Text = dt.Rows[0]["ADMRRejectReRe"].ToString().Trim();
                lblADMRReRePending.Text = dt.Rows[0]["ADMRPendingReRe"].ToString().Trim();

                 //===============================CO=============================================
                lblCOTotal.Text = dt.Rows[0]["TotalFresh"].ToString().Trim(); //(Convert.ToInt32(dt.Rows[0]["TotalFresh"]) - (Convert.ToInt32(dt.Rows[0]["ADMRAccept"]) + Convert.ToInt32(dt.Rows[0]["ADMRReject"]) + Convert.ToInt32(dt.Rows[0]["ADMRPending"]))).ToString();//dt.Rows[0]["TotalFresh"].ToString().Trim();
                lblCOAcpt.Text = dt.Rows[0]["COAccept"].ToString().Trim();
                lblCORjct.Text = dt.Rows[0]["COReject"].ToString().Trim();
                lblCOPending.Text = dt.Rows[0]["COPending"].ToString().Trim();

                lblCOReTotal.Text = dt.Rows[0]["TotalRecon"].ToString().Trim(); //(Convert.ToInt32(dt.Rows[0]["TotalRecon"]) - (Convert.ToInt32(dt.Rows[0]["ADMRAcceptRe"]) + Convert.ToInt32(dt.Rows[0]["ADMRRejectRe"]) + Convert.ToInt32(dt.Rows[0]["ADMRPendingRe"]))).ToString();//dt.Rows[0]["TotalFresh"].ToString().Trim();
                lblCOReAcpt.Text = dt.Rows[0]["COAcceptRe"].ToString().Trim();
                lblCOReRjct.Text = dt.Rows[0]["CORejectRe"].ToString().Trim();
                lblCORePending.Text = dt.Rows[0]["COPendingRe"].ToString().Trim();

                lblCOReReTotal.Text = dt.Rows[0]["TotalReRecon"].ToString().Trim(); //(Convert.ToInt32(dt.Rows[0]["TotalReRecon"]) - (Convert.ToInt32(dt.Rows[0]["ADMRAcceptReRe"]) + Convert.ToInt32(dt.Rows[0]["ADMRRejectReRe"]) + Convert.ToInt32(dt.Rows[0]["ADMRPendingReRe"]))).ToString();//dt.Rows[0]["TotalFresh"].ToString().Trim();
                lblCOReReAcpt.Text = dt.Rows[0]["COAcceptReRe"].ToString().Trim();
                lblCOReReRjct.Text = dt.Rows[0]["CORejectReRe"].ToString().Trim();
                lblCOReRePending.Text = dt.Rows[0]["COPendingReRe"].ToString().Trim();
                lblv4pending.Text = dt.Rows[0]["V4_Pending"].ToString().Trim();
                lblV5pending.Text = dt.Rows[0]["V5_Pending"].ToString().Trim();

                //==========================================================================================================
            }
        }
        catch (Exception ee)
        {

        }
    }

    #endregion
}