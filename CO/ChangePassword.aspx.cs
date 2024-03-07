using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class reports_ChangePassword : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Userrole"]) != "CO") { Response.Redirect("~/pmkisanadmin/LoginForm.aspx", true); }
        errorTable.Visible = false;
        try
        {

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["a"] == "op")
                {
                    errorTable.Visible = true;
                    displayEr.Text = "Enter Current Password!";
                }
                else if (Request.QueryString["a"] == "np")
                {
                    errorTable.Visible = true;
                    displayEr.Text = "Enter New Password!";
                }
                else if (Request.QueryString["a"] == "cp")
                {
                    errorTable.Visible = true;
                    displayEr.Text = "Enter Confirm Password!";
                }
                else if (Request.QueryString["a"] == "m")
                {
                    errorTable.Visible = true;
                    displayEr.Text = "Password and Confirm Password do not match.";
                }
                else if (Request.QueryString["a"] == "c")
                {
                    errorTable.Visible = true;
                    displayEr.Text = "Invalid Captcha!";
                }
                else if (Request.QueryString["a"] == "in")
                {
                    errorTable.Visible = true;
                    displayEr.Text = "Password and Confirm Special Characters which are not allowed.";
                }
                else if (Request.QueryString["a"] == "ino")
                {
                    errorTable.Visible = true;
                    displayEr.Text = "Old Password is Incorrect!";
                }
                else if (Request.QueryString["a"] == "sop")
                {
                    errorTable.Visible = true;
                    displayEr.Text = "Old Password cannot be same as the earlier 3 passwords!";
                }
                else if (Request.QueryString["a"] == "err")
                {
                    errorTable.Visible = true;
                    displayEr.Text = "Sorry there was some error processing your request!";
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/pmkisanadmin/LoginForm.aspx", false);
        }
        
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
       
        try
        {
            // ------------------- Ip address find code ------------------------
            string ipaddress;
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            Session["ipaddress"] = ipaddress;
            // -----------------------------------------------------------------

            Encryptor enc = new Encryptor(Encryptor.PrivateKey);
            string sL_Current_Password = txt_curr_pwd.Text.Trim(), sL_New_Password = txt_pwd.Text.Trim(), sL_Confirm_Password = txt_re_pwd.Text.Trim();
            string EncPassword = enc.Encrypt(txt_re_pwd.Text.Trim());
            if (string.IsNullOrEmpty(sL_Current_Password))
            {
                Response.Redirect("ChangePassword.aspx?a=op", false);
            }
            else if (string.IsNullOrEmpty(sL_New_Password))
            {
                Response.Redirect("ChangePassword.aspx?a=np", false);
            }
            else if (string.IsNullOrEmpty(sL_Confirm_Password))
            {
                Response.Redirect("ChangePassword.aspx?a=cp", false);
            }
            else if (sL_Confirm_Password != sL_New_Password)
            {
                Response.Redirect("ChangePassword.aspx?a=m", false);
            }
          

            else
            {
                string ColumnName = "password,EncPasswordNew,ChangeDateNew,ChangeIP,OptName,Old_Password,PasswordChangeDone,Mobileno";
                object[] FieldValue = { sL_New_Password, EncPassword,DateTime.Now, ipaddress, txtOperatorName.Text.Trim(), txt_curr_pwd.Text.Trim(),"Y",txtMobileNo.Text.Trim() };
                string TblName = "loginmaster";
                string Condition = "Userrole,block_id,UserID";
                object[] ConditionValue = { Session["UserRole"], Session["BlockCode"], Session["UserID"] };
                if (objcls.Update(TblName, ColumnName, FieldValue, Condition, ConditionValue))
                {
                    errorTable.Visible = true;
                    displayEr.Text = "Password Changed Successfully.Please login with new Password";
                }
                txt_curr_pwd.Text = "";
                txt_pwd.Text = "";
                txt_re_pwd.Text = "";

            }
           
        }
        catch
        {
            Response.Redirect("~/LoginForm.aspx", false);
        }
      
    }
   
}