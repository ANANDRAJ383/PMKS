using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using esms_client;
using System;

public partial class DAO_RefundDetailForm : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    clsDataAccessNewPMK clsNew = new clsDataAccessNewPMK();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd2 = new SqlCommand();
    string Datefile = DateTime.UtcNow.AddHours(5).AddMinutes(30).AddMilliseconds(10).ToString("ddMMyyyy");
    public DAO_RefundDetailForm()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBankSLBC();
            //BindPaymentRetrnData();
        }
    }
    protected void btnGetData_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtMobRegNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('कृपया मोबाइल नंबर/पंजीकरण संख्या दर्ज करें !!!!!');", true);
                return;
            }
                BindData(); //BindPaymentRetrnData();


        }
        catch (Exception ee)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('ee.Message');", true);
        }

    }
    #region Function&Metod
    void BindBankSLBC()
    {
        string query = "select BankCode,BankName from BankMaster";
        DataTable dt = clsNew.GetDataTable(query);
        ddlPaymentTypeSLBC.DataTextField = "BankName";
        ddlPaymentTypeSLBC.DataValueField = "BankCode";
        ddlPaymentTypeSLBC.DataSource = dt;
        ddlPaymentTypeSLBC.DataBind();
        ddlPaymentTypeSLBC.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    void BindData()
    {
        try
        {
            // divData.Visible = true;
            string QUERY = "";
            if (rb1.SelectedValue == "M")
            {
                QUERY = @"SELECT [DistrictName],DistCode,[SubDistrictName],[BlockName],[RevenueVillageName],[State_Ref_Number],[reg_no],[Farmer_Name],[Father_Name]
      ,[MobileNo],[AccountNo],[NoOfInstallments],(NoOfInstallments*2000) amt,case when  [Reason]='ITR' then 'IncomeTax Payee' else 'Other' end Reason,[Registration_Id],[PanchayatName],[DBT_AC],[IFSCCode],[Bank],PaymentReturnAC,TransactionNo,TransactionDate,DocPath,PaymentReturnMode,IsLean ,UpdateRole
  FROM [tbl_GoI_ReturnData_For_Reconsile_130723] where  MobileNo= '" + txtMobRegNo.Text + "'";
            }
            if (rb1.SelectedValue == "R")
            {
                QUERY = @"SELECT [DistrictName],DistCode,[SubDistrictName],[BlockName],[RevenueVillageName],[State_Ref_Number],[reg_no],[Farmer_Name],[Father_Name]
      ,[MobileNo],[AccountNo],[NoOfInstallments],(NoOfInstallments*2000) amt,case when  [Reason]='ITR' then 'IncomeTax Payee' else 'Other' end Reason,[Registration_Id],[PanchayatName],[DBT_AC],[IFSCCode],[Bank],PaymentReturnAC,TransactionNo,TransactionDate,DocPath,PaymentReturnMode,IsLean ,UpdateRole
  FROM [tbl_GoI_ReturnData_For_Reconsile_130723] where  Registration_Id= '" + txtMobRegNo.Text + "'";
            }
            if (rb1.SelectedValue == "B")
            {
                QUERY = @"SELECT [DistrictName],DistCode,[SubDistrictName],[BlockName],[RevenueVillageName],[State_Ref_Number],[reg_no],[Farmer_Name],[Father_Name]
      ,[MobileNo],[AccountNo],[NoOfInstallments],(NoOfInstallments*2000) amt,case when  [Reason]='ITR' then 'IncomeTax Payee' else 'Other' end Reason,[Registration_Id],[PanchayatName],[DBT_AC],[IFSCCode],[Bank],PaymentReturnAC,TransactionNo,TransactionDate,DocPath,PaymentReturnMode,IsLean ,UpdateRole
  FROM [tbl_GoI_ReturnData_For_Reconsile_130723] where  reg_no= '" + txtMobRegNo.Text + "'";
            }
            DataTable dt = clsNew.GetDataTable(QUERY);
            if (dt.Rows.Count > 0)
            { if (dt.Rows[0]["DocPath"].ToString() != "")
                {
                    ViewState["TransactionNo"] = dt.Rows[0]["TransactionNo"].ToString();
                    divEntry.Visible = false;
                   // divT.Visible = false;
                    divM.Visible = false;
                    divI.Visible = false;
                    divBut.Visible = false;
                    BindPaymentRetrnData();
                }
                else
                {
                    divEntry.Visible = true;
                    //divT.Visible = true;
                    divM.Visible = true;
                    divI.Visible = true;
                    divBut.Visible = true; dvR.Visible = true;
                }
                ViewState["DistCode"] = dt.Rows[0]["DistCode"].ToString();
                //divSrch.Visible = false;
                divData.Visible = true; dvR.Visible = true; divM.Visible = true;
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
                    ddlInstallments.Items.Insert(0, new ListItem("--Select--", "0"));

                }
                ddlInstallments.SelectedValue = dt.Rows[0]["NoOfInstallments"].ToString();
                ddlInstallments.Enabled = false;
                txtReturnAmount.Text = (Convert.ToInt32(ddlInstallments.SelectedValue.ToString()) * 2000).ToString();
            }



        }
        catch (Exception ex)
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

    #endregion
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
           


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
            //=========================================================================
            if (rbtnRefundSLBC.SelectedValue == "Y")
            {
                //==================File Upload SLBC====================================
                string SLBCReconcileDoc = objcls.UploadPDF(FileUploadslbc, "/SLBCReconcileDoc/" + Datefile + "/");
                ViewState["SLBCReconcileDoc"] = SLBCReconcileDoc;
                if (SLBCReconcileDoc == "~" || SLBCReconcileDoc == "Please Select Pdf File Only")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('कृपया केवल पीडीएफ फ़ाइल का चयन करें !!!!! ;", true);
                    return;
                }
                if (SLBCReconcileDoc == "File Size Large")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('फोटो का आकार 150KB से अधिक नहीं होना चाहिए !!!!! ;", true);
                    return;
                }
                //=========================================================================
                con.Open();
                cmd2.Parameters.Clear();
                cmd2.CommandText = @"update tbl_GoI_ReturnData_For_Reconsile_130723 set PaymentReturnMode=@PaymentReturnMode, PaymentReturnAC=@PaymentReturnAC, TransactionNo=@TransactionNo, TransactionDate=@TransactionDate,DocPath=@DocPath,Updatedate=getdate(),IsLean=@IsLean,UpdateRole=@UpdateRole,ActiveMobileNo=@ActiveMobileNo,PaymentReturnACSLBC=@PaymentReturnAC,SLBCAmount=@SLBCAmount,SLBCtAc=@SLBCtAc, SLBCIfsc=@SLBCIfsc, SLBCDate=@SLBCDate,DocPathSLBC=@DocPathSLBC where Registration_Id=@Registration_Id and Reg_No=@Reg_No and MobileNo=@MobileNo ";
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
                cmd2.Parameters.AddWithValue("@UpdateRole", "HQ");
                cmd2.Parameters.AddWithValue("@ActiveMobileNo", txtActiveMobileNo.Text);
                cmd2.Parameters.AddWithValue("@PaymentReturnACSLBC", ddlPaymentTypeSLBC.SelectedItem.Text);
                cmd2.Parameters.AddWithValue("@SLBCAmount", txtSLBCAmount.Text.Trim());
                cmd2.Parameters.AddWithValue("@SLBCtAc", txtSLBCtAc.Text.Trim());
                cmd2.Parameters.AddWithValue("@SLBCIfsc", txtSLBCIfsc.Text.Trim());
                cmd2.Parameters.AddWithValue("@DocPathSLBC", SLBCReconcileDoc);
                cmd2.Parameters.AddWithValue("@SLBCDate", txtDateSLBC.Text);
            }
            if (rbtnRefundSLBC.SelectedValue == "N")
            {
                con.Open();
                cmd2.Parameters.Clear();
                cmd2.CommandText = @"update tbl_GoI_ReturnData_For_Reconsile_130723 set PaymentReturnMode=@PaymentReturnMode1, PaymentReturnAC=@PaymentReturnAC1, TransactionNo=@TransactionNo1, TransactionDate=@TransactionDate1,DocPath=@DocPath1,Updatedate=getdate(),IsLean=@IsLean1,ActiveMobileNo=@ActiveMobileNo1,UpdateRole=@UpdateRole where Registration_Id=@Registration_Id1 and Reg_No=@Reg_No1 and MobileNo=@MobileNo1 ";
                cmd2.CommandType = CommandType.Text;
                cmd2.Connection = con;
                cmd2.Parameters.AddWithValue("@Registration_Id1", lblRegistrationId.Text);
                cmd2.Parameters.AddWithValue("@Reg_No1", lblPMKNo.Text.Trim());
                cmd2.Parameters.AddWithValue("@MobileNo1", lblMobileNo.Text.Trim());
                cmd2.Parameters.AddWithValue("@PaymentReturnAC1", ddlPaymentType.SelectedItem.Text);
                cmd2.Parameters.AddWithValue("@PaymentReturnMode1", ddlPayType.SelectedItem.Text);
                cmd2.Parameters.AddWithValue("@TransactionNo1", txtUTRNo.Text.Trim());
                cmd2.Parameters.AddWithValue("@TransactionDate1", txtUTRDate.Text.Trim());
                cmd2.Parameters.AddWithValue("@DocPath1", ReconcileDoc);
                cmd2.Parameters.AddWithValue("@IsLean1", rbtnLeanMark.SelectedValue);
                cmd2.Parameters.AddWithValue("@ActiveMobileNo1", txtActiveMobileNo.Text);
                cmd2.Parameters.AddWithValue("@UpdateRole", "HQ");
            }
            int ii = cmd2.ExecuteNonQuery();
            if (ii > 0)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Success !');", true);
                BindPaymentRetrnData();
            }
        }

        catch (Exception ee)
        {

        }
    }
    protected void rbtnRefundSLBC_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnRefundSLBC.SelectedValue == "Y")
        {
            divSlbc.Visible = true;
        }
        else
        {
            divSlbc.Visible = false;
        }
    }
}