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
namespace AgricultureDept
{
    public partial class DAOPMKSITR : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        clsDataAccess cls = new clsDataAccess();
        public DAOPMKSITR()
        {
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishiDBConnectionString2"].ConnectionString;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Dist_ID"] == null || Session["Dist_ID"] == "")
            {
                Response.Redirect("Homepage.aspx", false);
            }

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
            //DataTable dtr = cls.GetDataTable("select isnull(CONCAT(Farmer_FName,' ',Farmer_LName),'') as FarmerName,Registration_ID  from Registration where Registration_ID='" + txtreg.Text.Trim() + "'");
            DataTable dtr = cls.GetDataTable("select Farmer_FName+ +Farmer_LName as FarmerName,Registration_ID  from Registration where Registration_ID='" + txtreg.Text.Trim() + "'");
            DataTable dtp = cls.GetDataTable("select isnull(Farmer_Name,'') as FarmerName,Father_Name,Amount,NoOfInstallments ,reg_no from PMK_ITRecovOct2020 where reg_no='" + txtregpmks.Text.Trim() + "'");
            if (dtr.Rows.Count > 0 && dtp.Rows.Count > 0)
            {
                Panel1.Visible = true;
                lblregistration.Text = dtr.Rows[0]["Registration_ID"].ToString() + '/' + dtp.Rows[0]["reg_no"].ToString();
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
                String UTRDocument = "~/PMKisanUTR/" + txtreg.Text.Trim() + upUTR;
                FileUpload1.SaveAs(Server.MapPath(UTRDocument));
                string path = UTRDocument;
              
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
                   

                //CultureInfo provider = CultureInfo.InvariantCulture;
                //System.Globalization.DateTimeStyles style = DateTimeStyles.None;
                //DateTime dtCurrent;
                //string d = txttransactiondate.Text.Trim();
                //DateTime.TryParseExact(d, "dd-MM-yyyy", provider, style, out dtCurrent);
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
                
                con.Open();

                string InsertQuery = @"insert into PMKisanRecoverd(RegistrationId,PMKRegId,AmountRetunn,PaymentMode,TransactionNo,TranDate,TranSacAttachment,EnterBy,EnterDateTime)
                                 values (@RegistrationId,@PMKRegId,@AmountRetunn,@PaymentMode,@TransactionNo,@TranDate,@TranSacAttachment,@EnterBy,@EnterDateTime)";

                SqlDataAdapter da = new SqlDataAdapter(InsertQuery, con);
                da.SelectCommand.Parameters.AddWithValue("@RegistrationId", txtreg.Text.Trim());
                da.SelectCommand.Parameters.AddWithValue("@PMKRegId", txtregpmks.Text.Trim());
                da.SelectCommand.Parameters.AddWithValue("@AmountRetunn", txtamountreturn.Text.Trim());
                da.SelectCommand.Parameters.AddWithValue("@PaymentMode", ddtransactionmode.SelectedValue);
                da.SelectCommand.Parameters.AddWithValue("@TransactionNo", txtutrno.Text.Trim());
                da.SelectCommand.Parameters.AddWithValue("@TranDate", dtCurrent);
                da.SelectCommand.Parameters.AddWithValue("@TranSacAttachment", path);
                da.SelectCommand.Parameters.AddWithValue("@EnterBy", Session["Uname"].ToString().Trim());
                da.SelectCommand.Parameters.AddWithValue("@EnterDateTime", DateTime.Now);
                int i = da.SelectCommand.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('प्रिय किसान आपके PM KISAN RECOVERY Detail  रक्षित कर लिया गया है ...');", true);
                }
            }
            catch (Exception ex) { }
            finally { con.Close(); }
        }
    }
}