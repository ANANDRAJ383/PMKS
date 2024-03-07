using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using QRCoder;
using System.Text.RegularExpressions;
using esms_client;
using BridgePG;
using System.Collections.Specialized;
using System.Globalization;

public partial class DAO_ITRDone : System.Web.UI.Page
{
    string RegId = "";string PMKRegId = "";
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    string Datefile = DateTime.UtcNow.AddHours(5).AddMinutes(30).AddMilliseconds(10).ToString("ddMMyyyy");
    public DAO_ITRDone()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["RegId"] != null && Request.QueryString["RegId"] != string.Empty)
        {
            RegId = Request.QueryString["RegId"].ToString(); PMKRegId = Request.QueryString["PMKRegId"].ToString(); BindData();
            //lblRegId.Text = "Registration Id :-" + RegId;
        }
    }
    void BindData()
    {
        try
        {
            DataTable dtp = objcls.GetDataTable("select isnull(Farmer_Name,'') as FarmerName,DBTRegistrationID as RegistrationId,Father_Name,2000*NoOfInstallments as Amount,NoOfInstallments ,reg_no from tbl_IneligibleData where reg_no='" + PMKRegId + "'");
            if (dtp.Rows.Count > 0)
            {
                tblData.Visible = true;
                lblregistration.Text = dtp.Rows[0]["RegistrationId"].ToString() + '/' + dtp.Rows[0]["reg_no"].ToString();
                lblname.Text = dtp.Rows[0]["FarmerName"].ToString();
                lblfhname.Text = dtp.Rows[0]["Father_Name"].ToString();
                lblinstallment.Text = dtp.Rows[0]["NoOfInstallments"].ToString();
                lblamount.Text = dtp.Rows[0]["Amount"].ToString();
            }
        }
        catch (Exception ee)
        {
        }
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtamountreturn.Text.Trim() == "" || string.IsNullOrEmpty(txtamountreturn.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Kindly Enter returned amount... ');", true);
                return;
            }
            if (txtutrno.Text.Trim() == "" || string.IsNullOrEmpty(txtutrno.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Kindly Enter UTR no....');", true);
                return;
            }
            if (ddtransactionmode.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('Please Select payment mode........');", true);
                return;
            }
            if (ddlPaymentType.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('Please Select payment Account........');", true);
                return;
            }

            DataTable dtt = objcls.GetDataTable("Select * from tbl_PMKisanRecoveryData where RegistrationId='" + RegId.Trim() + "'");
            if (dtt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आप अनुदान राशी वापस कर चुके है .. ...  !!!!!!!!!!! ');", true);
                return;
            }
            // get date :

            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime dtCurrent;
            dtCurrent = Convert.ToDateTime(txttransactiondate.Text.Trim());
            con.Open();

            string InsertQuery = @"insert into tbl_PMKisanRecoveryData(RegistrationId,DistCode,PMKRegId,AmountReturn,PaymentMode,TransactionNo,TranDate,EnterBy,EnterDateTime,PaymentReturnAC)
                                 values (@RegistrationId,@DistCode,@PMKRegId,@AmountReturn,@PaymentMode,@TransactionNo,@TranDate,@EnterBy,@EnterDateTime,@PaymentReturnAC)";

            SqlDataAdapter da = new SqlDataAdapter(InsertQuery, con);
            da.SelectCommand.Parameters.AddWithValue("@RegistrationId", RegId);
            da.SelectCommand.Parameters.AddWithValue("@DistCode", Convert.ToInt32(Session["DistrictCode"]));
            da.SelectCommand.Parameters.AddWithValue("@PMKRegId", PMKRegId);
            da.SelectCommand.Parameters.AddWithValue("@AmountReturn", txtamountreturn.Text.Trim());
            da.SelectCommand.Parameters.AddWithValue("@PaymentMode", ddtransactionmode.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@TransactionNo", txtutrno.Text.Trim());
            da.SelectCommand.Parameters.AddWithValue("@TranDate", dtCurrent);
            da.SelectCommand.Parameters.AddWithValue("@EnterBy", Session["UserID"].ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@EnterDateTime", DateTime.Now);
            da.SelectCommand.Parameters.AddWithValue("@PaymentReturnAC", ddlPaymentType.SelectedValue);
            int i = da.SelectCommand.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('प्रिय किसान आपके PM KISAN RECOVERY Detail  रक्षित कर लिया गया है ...');", true);
                tblData.Visible = false;
            }
        }
        catch (Exception ex) { }
        finally { con.Close(); }
    }

}