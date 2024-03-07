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

public partial class ApplicationStatusCheck : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    public ApplicationStatusCheck()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlSearchBy.SelectedValue != "0" && txtUserId.Text.Trim() != "")
        {
            Login();
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please enter correct User Id and password...!');", true);
        }
    }

    protected void ddlSearchBy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlSearchBy.SelectedValue=="R")
        {
            lblUser.Text = "Enter Registration Id";

        }
        if (ddlSearchBy.SelectedValue == "A")
        {
            lblUser.Text = "Enter Aadhaar No";
        }
        if (ddlSearchBy.SelectedValue == "M")
        {
            lblUser.Text = "Enter Mobile No";
        }
    }
    void Login()
    {
        try
        {



            objcls.storeProcedure.NewStoreProcedure("SP_GetRegistrationMobile");
            objcls.storeProcedure.FieldName = "Registration_Id";
            objcls.storeProcedure.FieldValue = new object[] { txtUserId.Text.Trim() };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];                
                Session["MobileNo"] = dr["MobileNumber"] == DBNull.Value ? "NA" : Convert.ToString(dr["MobileNumber"]).Trim();

                FormsAuthentication.Initialize();
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUserId.Text.Trim(), DateTime.Now, DateTime.Now.AddMinutes(30), false, dt.Rows[0]["MobileNumber"].ToString().Trim(), FormsAuthentication.FormsCookiePath);

                // Encrypt the cookie using the machine key for secure transport
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash); // Hashed ticket

                // Set the cookie's expiration time to the tickets expiration time
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

                // Add the cookie to the list for outgoing response

                if (ddlSearchBy.SelectedValue.Trim() != "")
                {
                    int OTPNew = GenerateRandomNo();
                    string Mobileno = dt.Rows[0]["MobileNumber"].ToString().Trim();

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("insert into tbl_UserOtpInfo(UserId, OTP,IsLogin,MobileNo,ActionDate) values (@UserId,@OTP,@IsLogin,@MobileNo,@ActionDate) ", con);
                    da.SelectCommand.Parameters.AddWithValue("@UserId", txtUserId.Text.Trim());
                    da.SelectCommand.Parameters.AddWithValue("@IsLogin", "Y");
                    da.SelectCommand.Parameters.AddWithValue("@OTP", OTPNew.ToString());
                    da.SelectCommand.Parameters.AddWithValue("@MobileNo", Mobileno.Trim());
                    da.SelectCommand.Parameters.AddWithValue("@ActionDate", DateTime.Now);
                    int i = da.SelectCommand.ExecuteNonQuery();

                    if (i > 0)
                    {

                        //otpmsg.sendOTPMSG("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", Mobileno, "Your One Time Password is =" + OTPNew + "-Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182040506952");
                        ViewState["OTP"] = OTPNew;
                        lblMsg.Text = "Validate OTP ,4 Digit OTP send on Registrated Mobile No: " + "XXXXXX" + Mobileno.Substring(6, 4);
                        pnlLogin.Visible = false;
                        pnlOTP.Visible = true;
                       
                    }
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
            pnlLogin.Visible = false;
            pnlOTP.Visible = true;
        }
    }

    public int GenerateRandomNo()
    {
        int _min = 1111;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
    }



    protected void btnValidate_Click(object sender, EventArgs e)
    {
        if (ViewState["OTP"].ToString() == txtOTP.Text.Trim())
        {

            if (Session["MobileNo"].ToString().Trim() != "")
            {
                Response.Redirect("AppStatus.aspx",false);
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