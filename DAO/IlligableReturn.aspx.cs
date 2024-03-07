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

public partial class DAO_ITR_Return : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    string Datefile = DateTime.UtcNow.AddHours(5).AddMinutes(30).AddMilliseconds(10).ToString("ddMMyyyy");
    public DAO_ITR_Return()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnvalidate_Click(object sender, EventArgs e)
    {
        if (txtreg.Text.Trim() == "" || string.IsNullOrEmpty(txtreg.Text.Trim()))
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Kindly Enter DBT Registration No(13 digits)..... ');", true);
            return;
        }
        if (txtregpmks.Text.Trim() == "" || string.IsNullOrEmpty(txtregpmks.Text.Trim()))
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Kindly Enter PMKS Registration start with BR.....');", true);
            return;
        }
        
        //DataTable dtr = objcls.GetDataTable("select Farmer_FName+ +Farmer_LName as FarmerName,Registration_ID  from Registration where Registration_ID='" + txtreg.Text.Trim() + "'");
        DataTable dtp = objcls.GetDataTable("select isnull(Farmer_Name,'') as FarmerName,DBTRegistrationID as RegistrationId,Father_Name,2000*NoOfInstallments as Amount,NoOfInstallments ,reg_no from tbl_IneligibleData where reg_no='" + txtregpmks.Text.Trim() + "'");
        if ( dtp.Rows.Count > 0)
        {
            Panel1.Visible = true;
            lblregistration.Text = dtp.Rows[0]["RegistrationId"].ToString() + '/' + dtp.Rows[0]["reg_no"].ToString();
            lblname.Text = dtp.Rows[0]["FarmerName"].ToString();
            lblfhname.Text = dtp.Rows[0]["Father_Name"].ToString();
            lblinstallment.Text = dtp.Rows[0]["NoOfInstallments"].ToString();
            lblamount.Text = dtp.Rows[0]["Amount"].ToString();
        }
        else
        {
            Panel1.Visible = false;
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
            if (!FileUpload1.HasFile)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('कृपया जमा की गई राशी का पावती अपलोड करें |  ........');", true);
                return;
            }
            String upUTR = Path.GetExtension(FileUpload1.FileName);
            if (upUTR.ToLower() != ".pdf" || (upUTR.ToUpper() != ".PDF"))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Select Photo in PDF Format ...!...!!');", true);
                return;
            }
            int filesizeIdentity = FileUpload1.PostedFile.ContentLength;
            if (filesizeIdentity > (51200 * 3))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Photo Size 150KB Exceed  ......!!');", true);
                return;
            }
            //==================File Upload====================================
            string UTRDocument = objcls.UploadPDF(FileUpload1, "/PMKisanUTR/" + Session["DistrictName"] + "/" + Datefile + "/" + txtreg.Text.Trim());
            ViewState["UTRDocument"] = UTRDocument;
            if (UTRDocument == "~" || UTRDocument == "Please Select jpeg File Only")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  Picture ;", true);
                return;
            }
            if (UTRDocument == "File Size Large")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Photo Size 150KB Exceed ;", true);
                return;
            }
            //=========================================================================
            

            DataTable dtt = cls.GetDataTable("Select * from PMKisanRecoverd where RegistrationId='" + txtreg.Text.Trim() + "'");
            if (dtt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आप अनुदान राशी वापस  कर चुके है .. ...  !!!!!!!!!!! ');", true);
                return;
            }
            // get date :

            CultureInfo provider = CultureInfo.InvariantCulture;
            System.Globalization.DateTimeStyles style = DateTimeStyles.None;
            DateTime dtCurrent;
            dtCurrent = Convert.ToDateTime(txttransactiondate.Text.Trim());


            
            

            con.Open();

            string InsertQuery = @"insert into tbl_PMKisanRecoveryData(RegistrationId,DistCode,PMKRegId,AmountReturn,PaymentMode,TransactionNo,TranDate,TranSacAttachment,EnterBy,EnterDateTime,PaymentReturnAC)
                                 values (@RegistrationId,@DistCode,@PMKRegId,@AmountReturn,@PaymentMode,@TransactionNo,@TranDate,@TranSacAttachment,@EnterBy,@EnterDateTime,@PaymentReturnAC)";

            SqlDataAdapter da = new SqlDataAdapter(InsertQuery, con);
            da.SelectCommand.Parameters.AddWithValue("@RegistrationId", txtreg.Text.Trim());
            da.SelectCommand.Parameters.AddWithValue("@DistCode", Convert.ToInt32(Session["DistrictCode"]));
            da.SelectCommand.Parameters.AddWithValue("@PMKRegId", txtregpmks.Text.Trim());
            da.SelectCommand.Parameters.AddWithValue("@AmountReturn", txtamountreturn.Text.Trim());
            da.SelectCommand.Parameters.AddWithValue("@PaymentMode", ddtransactionmode.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@TransactionNo", txtutrno.Text.Trim());
            da.SelectCommand.Parameters.AddWithValue("@TranDate", dtCurrent);
            da.SelectCommand.Parameters.AddWithValue("@TranSacAttachment", UTRDocument);
            da.SelectCommand.Parameters.AddWithValue("@EnterBy", Session["UserID"].ToString().Trim());
            da.SelectCommand.Parameters.AddWithValue("@EnterDateTime", DateTime.Now);
            da.SelectCommand.Parameters.AddWithValue("@PaymentReturnAC", ddlPaymentType.SelectedValue);
            int i = da.SelectCommand.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('प्रिय किसान आपके PM KISAN RECOVERY Detail  रक्षित कर लिया गया है ...');", true);
                Panel1.Visible = false;
            }
        }
        catch (Exception ex) { }
        finally { con.Close(); }
    }
}