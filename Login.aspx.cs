using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using esms_client;

public partial class Login : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    clsDataAccessNew clsNew = new clsDataAccessNew();
    SqlConnection con = new SqlConnection(); SqlConnection con2 = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public Login()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
        con2.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
           LoginData();

    }
    #region Function&Method

    void LoginData()
    {
        try
        {
            con.Open();

            string QUERY = @"select [userid], [EncPassword], [password],Division_Id DivCode,'' DivName, [dist_id],d.DistName,s.SDMName_En,l.SubDivison_Id , [block_id],b.BlockName, [panchayat_id],   
                            [userrole], [Email], [Name], [Mobileno],   
                            [AadhaarNo],NewRole 
                            from loginmaster l  
                            left outer join Districts d  on l.dist_id=d.DistCode 
                            left outer join SubDivisionMaster s on s.SDMCode=l.SubDivison_Id 
                            left outer join Blocks b on l.block_id=b.BlockCode
        where userid='" + txtUserId.Text.Trim() + "' and password='" + txtPassword.Text.Trim() + "'  ";

            DataTable dt = new DataTable();
            SqlDataAdapter chkadpp = new SqlDataAdapter();
            cmd.Connection = con;
            cmd.CommandText = QUERY;
            chkadpp.SelectCommand = cmd;
            chkadpp.Fill(dt);
            //Response.Write(Session["UserNewRole"].ToString());
            //DataTable dt = objcls.GetDataTable(QUERY);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                Session["UserID"] = dr["userid"] == DBNull.Value ? "NA" : Convert.ToString(dr["userid"]).Trim();
                Session["UserName"] = dr["Name"] == DBNull.Value ? "NA" : Convert.ToString(dr["Name"]).Trim();
                Session["MobileNo"] = dr["Mobileno"] == DBNull.Value ? "NA" : Convert.ToString(dr["Mobileno"]).Trim();
                Session["UserRole"] = dr["userrole"] == DBNull.Value ? "NA" : Convert.ToString(dr["userrole"]).Trim();
                Session["DivisonCode"] = dr["DivCode"] == DBNull.Value ? "NA" : Convert.ToString(dr["DivCode"]).Trim();
                Session["DivisionName "] = dr["DivName"] == DBNull.Value ? "NA" : Convert.ToString(dr["DivName"]).Trim();
                Session["DistrictCode"] = dr["dist_id"] == DBNull.Value ? "NA" : Convert.ToString(dr["dist_id"]).Trim();
                Session["DistrictName "] = dr["DistName"] == DBNull.Value ? "NA" : Convert.ToString(dr["DistName"]).Trim();
                Session["SubDivisionName"] = dr["SDMName_En"] == DBNull.Value ? "NA" : Convert.ToString(dr["SDMName_En"]).Trim();
                Session["SubDivisonCode"] = dr["SubDivison_Id"] == DBNull.Value ? "NA" : Convert.ToString(dr["SubDivison_Id"]).Trim();
                Session["BlockCode"] = dr["block_id"] == DBNull.Value ? "NA" : Convert.ToString(dr["block_id"]).Trim();
                Session["BlockName"] = dr["BlockName"] == DBNull.Value ? "NA" : Convert.ToString(dr["BlockName"]).Trim();
                Session["PanchayatCode"] = dr["panchayat_id"] == DBNull.Value ? "NA" : Convert.ToString(dr["panchayat_id"]).Trim();
                Session["EmailId"] = dr["Email"] == DBNull.Value ? "NA" : Convert.ToString(dr["Email"]).Trim();
                Session["UserNewRole"] = dr["NewRole"] == DBNull.Value ? "NA" : Convert.ToString(dr["NewRole"]).Trim();

                FormsAuthentication.Initialize();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUserId.Text.Trim(), DateTime.Now, DateTime.Now.AddMinutes(30), false, dt.Rows[0]["userrole"].ToString().Trim(), FormsAuthentication.FormsCookiePath);

                // Encrypt the cookie using the machine key for secure transport
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash); // Hashed ticket

                // Set the cookie's expiration time to the tickets expiration time
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

                // Add the cookie to the list for outgoing response
                Response.Cookies.Add(cookie);
                if (Session["UserNewRole"].ToString() != "ATM/BTM" && Session["UserRole"].ToString().Trim() != "JDA" && Session["UserRole"].ToString().Trim() != "SAO" && Session["UserRole"].ToString().Trim() != "HQ" && Session["UserRole"].ToString().Trim() != "DAO")
                {
                    int OTPNew = GenerateRandomNo();
                    string Mobileno = dt.Rows[0]["Mobileno"].ToString().Trim();
                    con2.Open();
                    SqlDataAdapter da = new SqlDataAdapter("insert into ValidateOTP_MasterRecovery(RegistrationId, MobileNo,OTP,ActionDate) values (@RegistrationId,@MobileNo, @OTP,getdate()) ", con2);
                    da.SelectCommand.Parameters.AddWithValue("@RegistrationId", txtUserId.Text.Trim());
                    da.SelectCommand.Parameters.AddWithValue("@MobileNo", Mobileno.Trim());
                    da.SelectCommand.Parameters.AddWithValue("@OTP", OTPNew.ToString());
                    int i = da.SelectCommand.ExecuteNonQuery();

                    if (i > 0)
                    {


                        //SMSHttpPostClient1 otpmsg = new SMSHttpPostClient1();
                        //otpmsg.sendOTPMSG("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", Mobileno, "Your One Time Password is =" + OTPNew + "-Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182040506952");

                        // otpmsg.sendOTPMSG("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", Mobileno, "Your One Time Password is =" + OTPNew + "-Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182040506952");
                        ViewState["OTP"] = OTPNew;
                        lblMsg.Text = "Validate OTP ,4 Digit OTP send on Registrated Mobile No: " + "XXXXXX" + Mobileno.Substring(6, 4);
                        pnlLogin.Visible = false;
                        pnlOTP.Visible = true;
                        //}
                    }
                }
                if (Session["UserRole"].ToString().Trim() == "HQ")
                {
                    Response.Redirect("Reconcile/HQ/Default.aspx");
                }
                if (Session["UserRole"].ToString().Trim() == "DAO")
                {
                    Response.Redirect("Reconcile/DAO/Default.aspx");
                }
                if (Session["UserRole"].ToString().Trim() == "AC" || Session["UserNewRole"].ToString()== "ATM/BTM")
                {
                    Response.Redirect("Reconcile/AC/Default.aspx");
                }
                if (Session["UserRole"].ToString().Trim() == "DSB")
                {
                    Response.Redirect("Reconcile/BAO/Default.aspx");
                }
                if (Session["UserRole"].ToString().Trim() == "SAO")
                {
                    Response.Redirect("Reconcile/SAO/Default.aspx");
                }
                if (Session["UserRole"].ToString().Trim() == "JDA")
                {
                    Response.Redirect("Reconcile/JDA/Default.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Invalid Input.');", true);

            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.Message;
            //pnlLogin.Visible = false;
            //pnlOTP.Visible = true;
        }
        finally
        {
            con.Close(); con2.Close();
            con.Dispose();
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

    protected void btnValidate_Click(object sender, EventArgs e)
    {
        if (ViewState["OTP"].ToString() == txtOTP.Text.Trim())
        {     
            if (Session["UserRole"].ToString().Trim() == "DAO")
            {
                Response.Redirect("DAO/Default.aspx");
            }
            if (Session["UserRole"].ToString().Trim() == "ADM")
            {
                Response.Redirect("ADMA/Default.aspx");
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Invalid Input.Please do again login !!!!!');", true);
            pnlOTP.Visible = false;
            pnlLogin.Visible = true;
        }
    }
}