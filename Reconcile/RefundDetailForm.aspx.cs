using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using esms_client;

public partial class RefundDetailForm : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    clsDataAccessNew clsNew = new clsDataAccessNew();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd2 = new SqlCommand();
    string Datefile = DateTime.UtcNow.AddHours(5).AddMinutes(30).AddMilliseconds(10).ToString("ddMMyyyy");
    public RefundDetailForm()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindPaymentRetrnData();
        }
    }


    #region Function&Metod
    
    void BindData()
    {
        try
        {
           // divData.Visible = true;
            string QUERY = "";
            if (rb1.SelectedValue == "M")
            {
                 QUERY = @"SELECT [DistrictName],DistCode,[SubDistrictName],[BlockName],[RevenueVillageName],[State_Ref_Number],[reg_no],[Farmer_Name],[Father_Name]
      ,[MobileNo],[AccountNo],[NoOfInstallments],(NoOfInstallments*2000) amt,case when  [Reason]='ITR' then 'IncomeTax Payee' else 'Other' end Reason,[Registration_Id],[PanchayatName],[DBT_AC],[IFSCCode],[Bank]
  FROM [tbl_GoI_ReturnData_For_Reconsile_130723] where  MobileNo= '" + txtMobRegNo.Text + "'";
            }
            if (rb1.SelectedValue == "R")
            {
                 QUERY = @"SELECT [DistrictName],DistCode,[SubDistrictName],[BlockName],[RevenueVillageName],[State_Ref_Number],[reg_no],[Farmer_Name],[Father_Name]
      ,[MobileNo],[AccountNo],[NoOfInstallments],(NoOfInstallments*2000) amt,case when  [Reason]='ITR' then 'IncomeTax Payee' else 'Other' end Reason,[Registration_Id],[PanchayatName],[DBT_AC],[IFSCCode],[Bank]
  FROM [tbl_GoI_ReturnData_For_Reconsile_130723] where  Registration_Id= '" + txtMobRegNo.Text + "'";
            }
            if (rb1.SelectedValue == "B")
            {
                 QUERY = @"SELECT [DistrictName],DistCode,[SubDistrictName],[BlockName],[RevenueVillageName],[State_Ref_Number],[reg_no],[Farmer_Name],[Father_Name]
      ,[MobileNo],[AccountNo],[NoOfInstallments],(NoOfInstallments*2000) amt,case when  [Reason]='ITR' then 'IncomeTax Payee' else 'Other' end Reason,[Registration_Id],[PanchayatName],[DBT_AC],[IFSCCode],[Bank]
  FROM [tbl_GoI_ReturnData_For_Reconsile_130723] where  reg_no= '" + txtMobRegNo.Text + "'";
            }
            DataTable dt = clsNew.GetDataTable(QUERY);
            if(dt.Rows.Count>0)
            {
                ViewState["DistCode"] = dt.Rows[0]["DistCode"].ToString();
                divSrch.Visible = false;
                divData.Visible = true;
                lblRegistrationId.Text = dt.Rows[0]["Registration_Id"].ToString();
                lblName.Text = dt.Rows[0]["Farmer_Name"].ToString();                
                lblFName.Text = dt.Rows[0]["Father_Name"].ToString();
                lblR.Text = dt.Rows[0]["Reason"].ToString();
                lblTotalGetPay.Text = dt.Rows[0]["NoOfInstallments"].ToString();
                lblTotalAmount.Text = dt.Rows[0]["amt"].ToString();             
                lblDist.Text = dt.Rows[0]["districtname"].ToString();
                lblBlock.Text = dt.Rows[0]["blockname"].ToString();
                lblPanchayat.Text = dt.Rows[0]["panchayatname"].ToString();
                lblVillage.Text = dt.Rows[0]["RevenueVillageName"].ToString();
                lblMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
                lblPMKNo.Text = dt.Rows[0]["reg_no"].ToString();
                
                
                //QUERY = @"SELECT SUM([NoOfInstallments]) aa  FROM [tbl_ReconcileDataFromFarmers] where  Reg_No= '" + lblPMKNo.Text + "'";
                //DataTable data = clsNew.GetDataTable(QUERY);
                int endp = 0;
                endp = Convert.ToInt32(dt.Rows[0]["NoOfInstallments"].ToString());
                //if (data.Rows[0]["aa"].ToString() == "")
                //{
                //    ContentPlaceHolder1_tr5.Visible = false;
                //    endp = Convert.ToInt32(dt.Rows[0]["NoOfInstallments"].ToString());
                //}
                //else
                //{
                //    ContentPlaceHolder1_tr5.Visible = true;
                //    int Ins = Convert.ToInt32(lblTotalGetPay.Text);
                //    int PIns = Convert.ToInt32(data.Rows[0]["aa"].ToString());
                //    int Fins = Ins - PIns;
                //    lblTotalGetPending.Text = Fins.ToString();
                //    lblTotalPendingAmount.Text = (Fins * 2000).ToString();
                //     endp = Convert.ToInt32(Fins.ToString());
                //}



                if (dt.Rows.Count > 0)
                {

                    for (int srtp = 1; srtp <= endp; srtp++)
                    {
                        ddlInstallments.Items.Add(srtp.ToString());

                    }
                    ddlInstallments.DataBind();
                    //ddlInstallments.Items.Insert(0, new ListItem("--Select--", "0"));

                }
                ddlInstallments.SelectedValue = dt.Rows[0]["NoOfInstallments"].ToString();
                ddlInstallments.Enabled = false;
                txtReturnAmount.Text = (Convert.ToInt32(ddlInstallments.SelectedValue.ToString()) * 2000).ToString();
            }



        }
        catch(Exception ex)
        {

        }
    }
    void cleardata()
    {
        txtUTRNo.Text = "";
        txtUTRDate.Text = "";
        ddlPayType.SelectedValue = "";

    }

    void BindPaymentRetrnData()
    {
        try
        {

            string QUERY = "";
            
                QUERY = @"select [Registration_Id], [Reg_No], [MobileNo], [NoOfInstallments]*2000 [Amount], [NoOfInstallments],[PaymentReturnMode], [Reason], [Farmer_Name],
                [PaymentReturnAC], [TransactionNo], [TransactionDate], [DocPath] from tbl_GoI_ReturnData_For_Reconsile_130723 where  reg_no= '" + lblPMKNo.Text + "'";
            
            DataTable dt = clsNew.GetDataTable(QUERY);
            if (dt.Rows.Count > 0)
            {
                RepeaterData.DataSource = dt;
                RepeaterData.DataBind();
                RepeaterData.Visible = true;
                btnSubmit.Enabled = false;
            }
            else
            {
                RepeaterData.Visible = false; btnSubmit.Enabled = true;
            }



        }
        catch (Exception ex)
        {

        }
    }
    public int GenerateRandomNo()
    {
        int _min = 1111;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
    }
    #endregion

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtMobRegNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('कृपया मोबाइल नंबर/पंजीकरण संख्या दर्ज करें !!!!!');", true);
                return;
            }
            else
            {
                string QUERY = "";
                if (rb1.SelectedValue == "M")
                {
                    QUERY = @"SELECT [MobileNo] FROM [tbl_GoI_ReturnData_For_Reconsile_130723] where  MobileNo= '" + txtMobRegNo.Text + "'";
                }
                if (rb1.SelectedValue == "R")
                {
                    QUERY = @"SELECT [MobileNo] FROM [tbl_GoI_ReturnData_For_Reconsile_130723] where  Registration_Id= '" + txtMobRegNo.Text + "'";
                }
                if (rb1.SelectedValue == "B")
                {
                    QUERY = @"SELECT [MobileNo] FROM [tbl_GoI_ReturnData_For_Reconsile_130723] where  reg_no= '" + txtMobRegNo.Text + "'";
                }
                DataTable dt = clsNew.GetDataTable(QUERY);
                if (dt.Rows.Count > 0)
                {
                    int OTPNew = GenerateRandomNo();
                    string Mobileno = dt.Rows[0]["MobileNo"].ToString().Trim();
                    SqlDataAdapter da1 = new SqlDataAdapter("insert into ValidateOTP_Recovery(RegistrationId, MobileNo,OTP) values (@RegistrationId,@MobileNo, @OTP) ", con);
                    da1.SelectCommand.Parameters.AddWithValue("@RegistrationId", txtMobRegNo.Text);
                    da1.SelectCommand.Parameters.AddWithValue("@reg_no", txtMobRegNo.Text);
                    da1.SelectCommand.Parameters.AddWithValue("@MobileNo", Mobileno.Trim());
                    da1.SelectCommand.Parameters.AddWithValue("@OTP", OTPNew.ToString());
                    int i = da1.SelectCommand.ExecuteNonQuery();
                    if (i > 0)
                    {
                        //SMSHttpPostClient1 otpmsg = new SMSHttpPostClient1();
                        //otpmsg.sendOTPMSG("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", Mobileno, "Your One Time Password is =" + OTPNew + "-Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182040506952");
                        ViewState["OTP"] = OTPNew;
                        lblMsg.Text = "Validate OTP ,4 Digit OTP send on Registrated Mobile No: " + "XXXXXX" + Mobileno.Substring(6, 4);
                        btnResendOTP.Visible = true;
                        divRwotp.Visible = true;
                    }
                }
                divotp.Visible = true;
                btnGetData.Text = "Get Data";
                if (txtotp.Text == ViewState["OTP"].ToString())
                {
                    BindData(); //BindPaymentRetrnData();

                }
                else
                {
                    divData.Visible = false;
                    divSrch.Visible = true;
                }
            }
        }
        catch (Exception ee)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('ee.Message');", true);
        }

    }

    protected void ddlInstallments_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    //protected void rbtnRefundSLBC_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (rbtnRefundSLBC.SelectedValue == "Y")
    //    {
    //        divSlbc.Visible = true;
    //    }
    //    else {
    //        divSlbc.Visible = false;
    //    }
    //}


    protected void btnSubmit_Click(object sender, EventArgs e)
    {try
        {
            //if (ddlPaymentType.SelectedValue == "0")
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('कृपया वापसी का खाता चयन का करें !');", true);
            //    return;
            //}

            //if (ddlPayType.SelectedValue == "0")
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('कृपया वापसी का तरीका का चयन करें !');", true);
            //    return;
            //}
            //if (ddlInstallments.SelectedValue == "0")
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('कृपया वापसी का किस्त का चयन करें !');", true);
            //    return;
            //}


            if (fuDOC.HasFile == false)
            {
                // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('वापस किये गए राशि का साक्ष अपलोड करे !!!!! ;", true);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('वापस किये गए राशि का साक्ष अपलोड करे !');", true);
                return;
            }
            //==================File Upload====================================
            string ReconcileDoc = objcls.UploadPDF(fuDOC, "/ReconcileDoc/" + Datefile + "/");
            ViewState["ReconcileDoc"] = ReconcileDoc;
            if (ReconcileDoc == "~" || ReconcileDoc == "Please Select Pdf File Only")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('कृपया केवल पीडीएफ फ़ाइल का चयन करें !!!!! ;", true);
                return;
            }
            if (ReconcileDoc == "File Size Large")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('फोटो का आकार 150KB से अधिक नहीं होना चाहिए !!!!! ;", true);
                return;
            }
            //=========================================================================

            con.Open();
            cmd2.Parameters.Clear();
            cmd2.CommandText = @"update tbl_GoI_ReturnData_For_Reconsile_130723 set PaymentReturnMode=@PaymentReturnMode, PaymentReturnAC=@PaymentReturnAC, TransactionNo=@TransactionNo, TransactionDate=@TransactionDate,DocPath=@DocPath,Updatedate=getdate(),IsLean=@IsLean where Registration_Id=@Registration_Id and Reg_No=@Reg_No and MobileNo=@MobileNo ";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con;
            cmd2.Parameters.AddWithValue("@Registration_Id", lblRegistrationId.Text);
            cmd2.Parameters.AddWithValue("@Reg_No", lblPMKNo.Text.Trim());
            cmd2.Parameters.AddWithValue("@MobileNo", lblMobileNo.Text.Trim());
            cmd2.Parameters.AddWithValue("@PaymentReturnAC", ddlPaymentType.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@PaymentReturnMode", ddlPayType.SelectedItem.Text);
            cmd2.Parameters.AddWithValue("@TransactionNo", txtUTRNo.Text.Trim());
            cmd2.Parameters.AddWithValue("@TransactionDate", txtUTRDate.Text.Trim());
            cmd2.Parameters.AddWithValue("@DocPath", ReconcileDoc);
            cmd2.Parameters.AddWithValue("@IsLean", rbtnLeanMark.SelectedValue);
            int ii = cmd2.ExecuteNonQuery();
            if (ii > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Success ;", true);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Success !');", true);
                BindPaymentRetrnData();
            }
        }
        catch(Exception ee)
        {

        }
    }


   
}