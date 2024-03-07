using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using esms_client;

public partial class CheckApplicationStatus : System.Web.UI.Page
{
    //clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    clsDataAccessNew clsNew = new clsDataAccessNew();
    SqlConnection con = new SqlConnection();
    public CheckApplicationStatus()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        if (txtRegId.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Registration Id !!!!!');", true);
            return;
        }
        else
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_GetApplicationStatus_Old", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Registration_ID", txtRegId.Text.Trim());
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int OTPNew = GenerateRandomNo();
                string Mobileno = dt.Rows[0]["Mobileno"].ToString().Trim();
                SqlDataAdapter da1 = new SqlDataAdapter("insert into ValidateOTP_MasterNew(RegistrationId, MobileNo,OTP) values (@RegistrationId,@MobileNo, @OTP) ", con);
                da1.SelectCommand.Parameters.AddWithValue("@RegistrationId", txtRegId.Text.Trim());
                da1.SelectCommand.Parameters.AddWithValue("@MobileNo", Mobileno.Trim());
                da1.SelectCommand.Parameters.AddWithValue("@OTP", OTPNew.ToString());
                int i = da1.SelectCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    SMSHttpPostClient1 otpmsg = new SMSHttpPostClient1();
                    otpmsg.sendOTPMSG("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", Mobileno, "Your One Time Password is =" + OTPNew + "-Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182040506952");
                    ViewState["OTP"] = OTPNew;
                    lblMsg.Text = "Validate OTP ,4 Digit OTP send on Registrated Mobile No: " + "XXXXXX" + Mobileno.Substring(6, 4);
                    trMsg.Visible = true;
                    btnResendOTP.Visible = true;
                    trOTP.Visible = true;
                    btnGet.Visible = false;
                }
            }
            

        }
        
            
        
    }


    #region Function&Method
    void BindData()
    {
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_GetApplicationStatus_Old",con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Registration_ID",txtRegId.Text.Trim());
            da.SelectCommand.Parameters.AddWithValue("@ApplicationType", "");
            DataTable dt = new DataTable();
            da.Fill(dt);
         
            if (dt.Rows.Count > 0)
            {   
                    lbl1.Text = ""; lbl2.Text = ""; lbl3.Text = ""; lbl4.Text = ""; lbl5.Text = ""; lbl6.Text = ""; lbl7.Text = ""; lbl8.Text = ""; lbl9.Text = ""; tblRemarks.Visible = false;
                    tblCORemarks.Visible = false; Label1.Text = ""; Label2.Text = ""; Label3.Text = "";
                    if (dt.Rows[0]["AC_Status"].ToString() == "2" && (dt.Rows[0]["CO_Status"].ToString() == "" || Convert.ToString(dt.Rows[0]["CO_Status"]) == "") && dt.Rows[0]["ACDocVerify"].ToString() != "")
                    {
                        tblRemarks.Visible = true;
                        if (dt.Rows[0]["ACDocVerify"].ToString() == "NO")
                        {
                            lbl1.Text = "त्रुटि पाया गया |"; td1.Visible = true;
                        }
                        else
                        {
                            td1.Visible = false;
                        }
                        if (dt.Rows[0]["ACFamilyBenify"].ToString() == "NO")
                        {
                            lbl2.Text = "त्रुटि पाया गया |"; td2.Visible = true;
                        }
                        else
                        {
                            td2.Visible = false;
                        }
                        if (dt.Rows[0]["ACPersonalInfoVerify"].ToString() == "NO")
                        {
                            lbl3.Text = "त्रुटि पाया गया |"; td3.Visible = true;
                        }
                        else
                        {
                            td3.Visible = false;
                        }
                        if (dt.Rows[0]["ACFamilyInfoVerify"].ToString() == "NO")
                        {
                            lbl4.Text = "त्रुटि पाया गया |"; td4.Visible = true;
                        }
                        else
                        {
                            td4.Visible = false;
                        }
                        if (dt.Rows[0]["ACBankInfoVerify"].ToString() == "NO")
                        {
                            lbl5.Text = "त्रुटि पाया गया |"; td5.Visible = true;
                        }
                        else
                        {
                            td5.Visible = false;
                        }
                        if (dt.Rows[0]["ACLandInfoVerify"].ToString() == "NO")
                        {
                            lbl6.Text = "त्रुटि पाया गया |"; td6.Visible = true;
                        }
                        else
                        {
                            td6.Visible = false;
                        }
                        if (dt.Rows[0]["ACRayatInfoVerify"].ToString() == "NO")
                        {
                            lbl7.Text = "त्रुटि पाया गया |"; td7.Visible = true;
                        }
                        else
                        {
                            td7.Visible = false;
                        }
                        if (dt.Rows[0]["ACTopolandInfoVerify"].ToString() == "NO")
                        {
                            lbl8.Text = "त्रुटि पाया गया |"; td8.Visible = true;
                        }
                        else
                        {
                            td8.Visible = false;
                        }
                        if (dt.Rows[0]["ACAllInfoVerify"].ToString() == "NO")
                        {
                            lbl9.Text = "त्रुटि पाया गया |"; td9.Visible = true;
                        }
                        else
                        {
                            td9.Visible = false;
                        }
                    }
                    if (dt.Rows[0]["CO_Status"].ToString() == "2" && dt.Rows[0]["ACDocVerify"].ToString() != "")
                    {
                        tblCORemarks.Visible = true; Tr1.Visible = false; Tr2.Visible = false; Tr3.Visible = false;
                        if (dt.Rows[0]["CODocVerify"].ToString() == "NO")
                        {
                            Label1.Text = "त्रुटि पाया गया |"; Tr1.Visible = true;
                        }
                        else
                        {
                            Tr1.Visible = false;
                        }
                        if (dt.Rows[0]["CODocRecent"].ToString() == "NO")
                        {
                            Label2.Text = "त्रुटि पाया गया |"; Tr2.Visible = true;
                        }
                        else
                        {
                            Tr2.Visible = false;
                        }
                        if (dt.Rows[0]["COApprove"].ToString().Trim() == "NO")
                        {
                            Label3.Text = "त्रुटि पाया गया |"; Tr3.Visible = true;
                        }
                        else
                        {
                            Tr3.Visible = false;
                        }
                    string QUERY = @"select  RegistrationID, d.DistName,b.BlockName,khata_no Khatano, KhesraNo keshrano, 
                                thanano, LandDismil rakwa, FarmingRakwa, EntryDate,OwnerName from Registration_PMKIsan_LandDetails_New l
                                inner join Districts d on l.DistrictCode=d.DistCode
                                inner join Blocks b on b.BlockCode=l.BlockCode
                    where RegistrationID='" + txtRegId.Text.Trim() + "'";

                    DataTable dtLand = clsNew.GetDataTable(QUERY);
                    if (dtLand.Rows.Count > 0)
                    {
                        grdLand.DataSource = dtLand;
                        grdLand.DataBind();
                        idland.Visible = true;
                    }
                }
                    gvdata.DataSource = dt;
                    gvdata.DataBind();
                    gvdata.Visible = true;
                
            }
            else
            { 
		        dt.Clear();
		        dt.Dispose();
                DataTable dtnull = new DataTable();
                gvdata.DataSource = dtnull;
                gvdata.DataBind();
                gvdata.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
            }
        }
        catch (Exception ee)
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

    protected void txtRegId_TextChanged(object sender, EventArgs e)
    {
        btnGet.Visible = true;
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ViewState["OTP"]) == Convert.ToInt32(txtOTP.Text.Trim()))
        {
            btnGet.Visible = false;
            btnResendOTP.Visible = false;
            trOTP.Visible = false;
	    trMsg.Visible = false;
            BindData();
        }
    }
}