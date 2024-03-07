using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Collections;
using System.Text;
using esms_client;
using System.Security.Cryptography;
using System.Configuration;
using System.Net;
namespace AgricultureDept
{
    public partial class AdminIncPage : System.Web.UI.Page
    {
        clsDataAccess cls = new clsDataAccess();
        string abc = System.Configuration.ConfigurationManager.ConnectionStrings["KrishiDBConnectionString2"].ConnectionString;

        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KrishiDBConnectionString2"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = cls.GetDataTable("@select count(*) aa from [Registration_PMKISAN] p where p.ADMR_Status=1  and (p.XMLStatus is null or len(p.XMLStatus)=0) and p.Registration_ID not in (select RegistrationID from PMKISAN_SammanNidhi) AND (p.ErrorType is null)");
                if (dt.Rows.Count > 0)
                {
                    Label4.Text = "Total Fresh approve Applicant " + dt.Rows[0]["aa"].ToString();
                }
                else
                {
                    Label4.Text = "Total Fresh approve Applicant : 0";// +dt.Rows[0]["aa"].ToString();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = cls.GetDataTable("SELECT name FROM sys.Tables order by name");

            if (dt.Rows.Count > 0)
            {
                grd1.DataSource = dt;
                grd1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string abc = txt1.Text.ToLower();
            if (abc.Contains("delete") || abc.Contains("update") || abc.Contains("alter") || abc.Contains("drop") || abc.Contains("truncate") || abc.Contains("create") || abc.Contains("insert"))
            {


            }
            else
            {
                string xxx = txt1.Text.Trim();
                DataTable dt = cls.GetDataTable(xxx);

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtenc.Text))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Jha", "alert('Kindly Enter Value...!!!!');", true);
                txtenc.Focus();
                return;
            }
            lblResult.Text = Encrypt(txtenc.Text.Trim());
            //DataTable dt = cls.GetDataTable("SELECT * FROM Loginmaster WHERE USERROLE='DM'");

            //if (dt.Rows.Count > 0)
            //{
            //    try
            //    {
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            using (SqlConnection cn = new SqlConnection(abc))
            //            {
            //                cn.Open();
            //                string query = "update Loginmaster set encPassword='" + Encrypt(dr["Password"].ToString()) + "' where slno='" + dr["slno"].ToString() + "' ";
            //                SqlDataAdapter da = new SqlDataAdapter(query, cn);
            //                da.SelectCommand.ExecuteNonQuery();

            //            }
            //        }
            //    }
            //    catch { }
            //    finally {   }
            //}
        }

        public static string Encrypt(string inputText)
        {
            string encryptionkey = "SAUW193BX628TD57";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(inputText);
            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform encryptrans = rijndaelCipher.CreateEncryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream())
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, encryptrans, CryptoStreamMode.Write))
                    {
                        cryptstm.Write(plainText, 0, plainText.Length);
                        cryptstm.Close();
                        return Convert.ToBase64String(mstrm.ToArray());
                    }
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataTable dt = cls.GetDataTable(@"SELECT convert(char(11), b.ActionDate,106) Date, COUNT(*) [Total Benificiary], sum(cast(b.DAOApprovedAmount  as decimal(18,2))) [Total Amount]
 
                    FROM BDOApproval_Diesel b
                   -- inner join AgriCordinator_Diesel a on a.Application_ID= b.Application_ID 
                    WHERE SendtoBank =1
                    group by convert(char(11), b.ActionDate,106)
                    order by convert(char(11), b.ActionDate,106)
                    ");

            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }







        //protected void btnsend_Click(object sender, EventArgs e)
        //{
        //    int counter = 0;
        //    SMSHttpPostClient sms = new SMSHttpPostClient();

        //    if (string.IsNullOrEmpty(txtsmssukhad.Text))
        //    {
        //        ScriptManager.RegisterStartupScript(Page, GetType(), "Jha", "alert('Kindly Enter Message...!!!!');", true);
        //        txtsmssukhad.Focus();
        //        return;
        //    }
        //    try
        //    {
        //        cn.Open();
        //        string query = "SELECT top 1000 Mobileno FROM SukhadMobile where (flage is null or len(flage)=0) ";
        //        DataTable DT = cls.GetDataTable(query);

        //        lblcounter.Text = DT.Rows.Count.ToString();

        //        if (DT.Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in DT.Rows)
        //            {
        //                sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", dr["Mobileno"].ToString(), txtsmssukhad.Text.Trim(), "35fc8f80-e0bc-469e-9a93-646d7d453552");
        //                counter = counter + 1;


        //                SqlCommand cmd = new SqlCommand("update SukhadMobile set flage=1 where Mobileno='" + dr["Mobileno"].ToString() + "'");
        //                cmd.Connection = cn;
        //                cmd.ExecuteNonQuery();
        //            }
        //            lblcounter.Text = counter.ToString();
        //        }
        //    }
        //    catch (Exception ex) { }
        //    finally {

        //        cn.Close();
        //    }
        //}

        protected void Button5_Click(object sender, EventArgs e)
        {
            lblResult.Text = Decrypt(txtenc.Text.Trim());
        }
        public static string Decrypt(string encryptText)
        {
            string encryptionkey = "SAUW193BX628TD57";
            byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] encryptedData = Convert.FromBase64String(encryptText.Replace(' ', '+'));//Convert.FromBase64String(encryptText.Replace(" ", "+"));// Encoding.ASCII.GetBytes(encryptText.Replace(" ", "+")); // Convert.FromBase64String(encryptText.Replace(" ", "+"));


            PasswordDeriveBytes pwdbytes = new PasswordDeriveBytes(encryptionkey, keybytes);
            using (ICryptoTransform decryptrans = rijndaelCipher.CreateDecryptor(pwdbytes.GetBytes(32), pwdbytes.GetBytes(16)))
            {
                using (MemoryStream mstrm = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cryptstm = new CryptoStream(mstrm, decryptrans, CryptoStreamMode.Read))
                    {
                        byte[] plainText = new byte[encryptedData.Length];
                        int decryptedCount = cryptstm.Read(plainText, 0, plainText.Length);
                        return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                    }
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                string LandCerificate = "";
                int i = 0;
                cn.Open();
                DataTable dt = cls.GetDataTable("SELECT * from Diesel_SubsidyApplyRawi where len(LandCertificate)=0 and LandType in (N'बटाईदार', N'स्वयं + बटाईदार')");//, N'स्वयं + बटाईदार'
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        i = i + 1;
                        LandCerificate = "~/LandCertificate/" + dr["Application_ID"].ToString() + ".jpg";
                        FileUpload1.SaveAs(Server.MapPath(LandCerificate));
                        string update = "update Diesel_SubsidyApplyRawi set LandCertificate='" + LandCerificate + "' where Application_ID='" + dr["Application_ID"].ToString() + "'";
                        SqlDataAdapter da = new SqlDataAdapter(update, cn);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                    ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('Data Updated : " + i + "');", true);
                }
            }
            catch
            { }
            finally { cn.Close(); }
        }

        protected void btnXML_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = CreateDynamicDataSet();
                cn.Open();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("insert into kkc (id) values ('" + dr["Identity_Proof_No"].ToString() + "')", cn);
                        da.SelectCommand.ExecuteNonQuery();
                    }

                    SqlDataAdapter daa = new SqlDataAdapter("update PMKISAN_SammanNidhi set [status]=1 where  Identity_Proof_No in (select id from kkc)", cn);
                    daa.SelectCommand.ExecuteNonQuery();

                    SqlDataAdapter daDelete = new SqlDataAdapter("truncate table kkc", cn);
                    daDelete.SelectCommand.ExecuteNonQuery();


                    string FileName = "" + DateTime.Now.ToString("ddMMyyyyHHmm") + "Farmer.xml";
                    ds.WriteXml(Server.MapPath(FileName));
                    lblResult.Text = "XML File Generated...........";
                    StringWriter sw = new StringWriter();
                    ds.WriteXml(sw, XmlWriteMode.IgnoreSchema);
                    string s = sw.ToString();
                    string attachment = "attachment;filename=" + FileName + "";
                    Response.ClearContent();
                    Response.ContentType = "application/xml";
                    Response.AddHeader("content-disposition", attachment);
                    Response.Write(s);
                    //Response.Write("XML File Generated...........");
                    Response.End();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Msg", "alert('XML File Generated..........." + ds.Tables[0].Rows.Count + "..');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Msg", "alert('Data not exist.............');", true);
                }

                //}
            }
            catch
            {

            }
            finally
            {
                cn.Close();
            }
        }

        private DataSet CreateDynamicDataSet()
        {
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select TOP 20000 State_Ref_Number='NULL', StateCode, DistrictCode, Sub_District_Code, BlockCode, VillageCode, Farmer_Name, Gender, Farmer_Category, Identity_Proof_Type, Identity_Proof_No, IFSC_Code, Bank_Account_Number, MobileNo, CONVERT(CHAR(10),DOB,120) DOB, Father_Mother_Husband_Name, HomeAddress='', Ownership_Single_Joint='', Sr_No='', Survey_Khata_No='', Khasra_Drag_No='', Area='',  case when FarmerType is null  THEN 1 else FarmerType end as FarmerType from PMKISAN_SammanNidhi where status=9 and VillageCode is not null and Identity_Proof_No not in ('271700354096')", cn);
                ds.DataSetName = "DocumentElement";
                da.Fill(ds, "Farmer");
            }
            catch
            {

            }
            finally
            {
                cn.Close();
            }
            return ds;
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassode.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Please Enter Correct Passcode ...');", true);
                Response.Write("<script>alert('Please Enter Correct Passcode ...'');</script>");
                return;
            }
            if (txtPassode.Text.Trim() == "@#$kasd99")
            {
                pnl1.Visible = true;
                DataTable dt = cls.GetDataTable("@select count(*) aa from [Registration_PMKISAN] p where p.ADMR_Status=1  and (p.XMLStatus is null or len(p.XMLStatus)=0) and p.Registration_ID not in (select RegistrationID from PMKISAN_SammanNidhi) AND (p.ErrorType is null) ");
                if (dt.Rows.Count > 0)
                {
                    Label4.Text = "Total Fresh approve Applicant " + dt.Rows[0]["aa"].ToString();
                }
                else
                {
                    Label4.Text = "Total Fresh approve Applicant : 0";// +dt.Rows[0]["aa"].ToString();
                }
            }
            else
            {
                pnl1.Visible = false;
                ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Please Enter Correct Passcode ...');", true);
                Response.Write("<script>alert('Please Enter Correct Passcode ...'');</script>");
                return;
            }

        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SMSHttpPostClient sms = new SMSHttpPostClient();
                DataTable dt = cls.GetDataTable("select * from [PFMSRejectedPMKISAN250319]");
                if (dt.Rows.Count > 0)
                {
                    string smsText = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        // smsText = "प्रिय किसान, आपका निबंधन संख्या " + dr["RegistrationID"].ToString() + " है | सुखाड़ के कृषि इनपुट अनुदान योजना में दिनांक 12 एवं 27 फरवरी को आपके खाता संख्या " + dr["CreditAc"].ToString() + " में दोहरा भुगतान हो गया है| कृपया 27 फरवरी को दोहरा भुगतान की राशि को लौटाने हेतु अपने शाखा प्रबंधक अथवा कृषि समन्वयक से संपर्क करें | कृषि विभाग ";
                        smsText = "प्रिय किसान,PM-KISAN योजना में आपके द्वारा दिये गये आवेदन का PFMS में सत्यापन के दौरान त्रुटि के कारण वापस हो गया है,कृपया DBT पोर्टल पर उपलब्ध लिंक PM-Kisan त्रुटि संशोधन पर जाकर त्रुटि को जाँच कर अविलम्ब सुधार करें| कृषि विभाग ";
                        //sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", MobileNo, "कृषि विभाग, बिहार द्वारा आपका पंजीकरण फसल अवशेष जलाने के कारण तीन वर्षो के लिये बाधित कर दिया गया है, फसल अवशेष प्रबंधन के लिये https://youtu.be/Gcpn_33tG-A  लिंक को देखे|" + ",Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182073909271"); 
                        sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", dr["mobileno"].ToString(), smsText + ",Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182073909271"); 

                    }
                    ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Total SMS " + dt.Rows.Count.ToString() + " SEND...');", true);
                    lblResult.Text = "Total SMS..........." + dt.Rows.Count.ToString() + "";
                }

            }
            catch { }
            finally { }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            try
            {
                //cn.Open();
                //SMSHttpPostClient sms = new SMSHttpPostClient();
                //DataTable dt = cls.GetDataTable("select * from Doble_Payment");
                //if (dt.Rows.Count > 0)
                //{
                //    string smsText = "";
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        // smsText = "प्रिय किसान, आपका निबंधन संख्या " + dr["RegistrationID"].ToString() + " है | सुखाड़ के कृषि इनपुट अनुदान योजना में दिनांक 12 एवं 27 फरवरी को आपके खाता संख्या " + dr["CreditAc"].ToString() + " में दोहरा भुगतान हो गया है| कृपया 27 फरवरी को दोहरा भुगतान की राशि को लौटाने हेतु अपने शाखा प्रबंधक अथवा कृषि समन्वयक से संपर्क करें | कृषि विभाग ";
                //        smsText = "प्रिय किसान, आपका निबंधन संख्या " + dr["RegistrationID"].ToString() + " है | आपको पूर्व में सूचना दी गयी है | सुखाड़ अनुदान में प्राप्त अतिरिक्त राशि एक सप्ताह के अन्दर वापस करें | वापस नहीं होने तक आपको विभाग से अन्य सुविधा नहीं मिलेगी | कृषि विभाग ";
                //        sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", dr["MobileNo"].ToString(), smsText, "35fc8f80-e0bc-469e-9a93-646d7d453552");

                //    }
                //    ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Total SMS " + dt.Rows.Count.ToString() + " SEND...');", true);
                //    lblResult.Text = "Total SMS..........." + dt.Rows.Count.ToString() + "";


                cn.Open();
                SMSHttpPostClient sms = new SMSHttpPostClient();
                DataTable dt = cls.GetDataTable("select * from blockreg");
                if (dt.Rows.Count > 0)
                {
                    string smsText = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        // smsText = "प्रिय किसान, आपका निबंधन संख्या " + dr["RegistrationID"].ToString() + " है | सुखाड़ के कृषि इनपुट अनुदान योजना में दिनांक 12 एवं 27 फरवरी को आपके खाता संख्या " + dr["CreditAc"].ToString() + " में दोहरा भुगतान हो गया है| कृपया 27 फरवरी को दोहरा भुगतान की राशि को लौटाने हेतु अपने शाखा प्रबंधक अथवा कृषि समन्वयक से संपर्क करें | कृषि विभाग ";
                        smsText = "प्रिय किसान, आपके द्वारा कृषि इनपुट अनुदान(सुखाड़) योजना अंतर्गत अतिरिक्त भुगतान राशि विभाग को वापस नहीं की गयी है|इसलिये आप कृषि विभाग के किसी भी योजना का लाभ नहीं ले सकते है|अनुरोध है की जल्द से जल्द अतिरिक्त राशि विभाग को वापस करें| कृषि विभाग ";
                        //sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", MobileNo, "कृषि विभाग, बिहार द्वारा आपका पंजीकरण फसल अवशेष जलाने के कारण तीन वर्षो के लिये बाधित कर दिया गया है, फसल अवशेष प्रबंधन के लिये https://youtu.be/Gcpn_33tG-A  लिंक को देखे|" + ",Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182073909271"); 
                        sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", dr["mobileno"].ToString(), smsText + ",Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182073909271"); 

                    }
                    ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Total SMS " + dt.Rows.Count.ToString() + " SEND...');", true);
                    lblResult.Text = "Total SMS..........." + dt.Rows.Count.ToString() + "";
                }

            }
            catch { }
            finally { }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            //string smsText = "प्रिय किसान, आपका निबंधन संख्या 2212562125 है | सुखाड़ के कृषि इनपुट अनुदान योजना में दिनांक 12 एवं 27 फरवरी को आपके खाता संख्या 63256874555 में दोहरा भुगतान हो गया है| कृपया 27 फरवरी को दोहरा भुगतान की राशि को लौटाने हेतु अपने शाखा प्रबंधक अथवा कृषि समन्वयक से संपर्क करें | कृषि विभाग ";
            string smsText = "प्रिय किसान, आपको पूर्व में सूचना दी गयी है | सुखाड़ अनुदान में प्राप्त अतिरिक्त राशि एक सप्ताह के अन्दर वापस करें | वापस नहीं होने तक आपको विभाग से अन्य सुविधा नहीं मिलेगी | कृषि विभाग  ";
            SMSHttpPostClient sms = new SMSHttpPostClient();
            sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", "9852827828", smsText + ",Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182073909271"); 
            //sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", MobileNo, "कृषि विभाग, बिहार द्वारा आपका पंजीकरण फसल अवशेष जलाने के कारण तीन वर्षो के लिये बाधित कर दिया गया है, फसल अवशेष प्रबंधन के लिये https://youtu.be/Gcpn_33tG-A  लिंक को देखे|" + ",Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182073909271"); 
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("PM_KisanSer", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                int i = da.SelectCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    DataTable dt = cls.GetDataTable("select count(*) aa from PMKISAN_SammanNidhi where status=9 and CONVERT(char(11),SendDate,106)=CONVERT(char(11), GETDATE(),106)");
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Final PM KIsan Beneficiary " + dt.Rows[0]["aa"].ToString() + " ...');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Try Again......!!!!!!');", true);
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("UpdateXMLStatus", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                int i = da.SelectCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    DataTable dt = cls.GetDataTable("select count(*) aa from [Registration_PMKISAN] where XMLStatus=1 and CONVERT(char(11), XMLDate,106)=CONVERT(char(11), GETDATE(),106)");
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('XML file has been Generated " + dt.Rows[0]["aa"].ToString() + " ...');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Try Again......!!!!!!');", true);
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter("UpdatePMKisanStatus", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                int i = da.SelectCommand.ExecuteNonQuery();
                if (i > 0)
                {
                    DataTable dt = cls.GetDataTable("select count(*) aa from PMKISAN_SammanNidhi where status=1 and CONVERT(char(11), SendDate,106)='19 Mar 2019'"); //CONVERT(char(11), GETDATE(),106)
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Data Updated og PM KIsan Table " + dt.Rows[0]["aa"].ToString() + " ...');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Try Again......!!!!!!');", true);
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        protected void SendMail()
        {
            try
            {
                // Gmail Address from where you send the mail
                var fromAddress = "dbtcellagri@gmail.com";
                // any address where the email will be sending
                var toAddress = "krishnachaudhary99@gmail.com";
                //Password of your gmail address
                const string fromPassword = "Iamadmin@18";
                // Passing the values and make a email formate to display
                string subject = "Test Mail from DBT Agriculture";
                string body = "From:Krishna \n";
                body += "Email: " + "kkc" + "\n";
                body += "Subject: " + "xxx" + "\n";
                body += "Question: \n" + "xxxx" + "\n";
                // smtp settings
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 20000;
                }
                // Passing values to smtp object
                smtp.Send(fromAddress, toAddress, subject, body);

                ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('mail send......!!!!!!');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Try Again.Error: " + ex.Message + ".....!!!!!!');", true);
            }
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            SendMail();
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            //SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = cls.GetDataTable("select * from DryCropy_OnlineApplyMaster where Reconsider=" + ddlS.SelectedValue + " "); //CONVERT(char(11), GETDATE(),106)
            // da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int i = 0;
                cn.Open();
                foreach (DataRow dr in dt.Rows)
                {

                    ViewState["Reg_ID"] = dr["RegistrationID"].ToString();
                    string ID = ApplicationID();
                    SqlCommand cmd = new SqlCommand("update DryCropy_OnlineApplyMaster set ReconsiderID='" + ID + "' where ApplicationID='" + dr["ApplicationID"].ToString() + "'");
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                    i = i + 1;
                }

                cn.Close();
                ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Total Data Updated " + i + " ...');", true);
            }
        }
        private string GetUniqueKey()
        {
            int maxSize = 6;
            char[] chars = new char[62];
            string a;
            a = "1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            { result.Append(chars[b % (chars.Length - 1)]); }
            return result.ToString();
        }
        //--------------------------------- Generate Application-ID------------------------------
        string ApplicationID()
        {
            string UID = GetUniqueKey();
            string App_ID = string.Empty;
            App_ID = ddlS.SelectedValue + ViewState["Reg_ID"].ToString().Trim().Substring(0, 6) + UID + "DRC";
            Session["App_ID"] = App_ID;
            if (App_ID == "2301402842214DSL" || App_ID == "2301399108108DSL" || App_ID == "2321440199209DSL")
            {
                ApplicationID();
            }
            return App_ID;
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 19; i++)
            {
                DataTable dt = cls.GetDataTable("select top 10000 * from DroughtReturn where LotNo is null");
                if (dt.Rows.Count > 0)
                {
                    cn.Open();
                    foreach (DataRow dr in dt.Rows)
                    {
                        SqlCommand cmd = new SqlCommand("update DroughtReturn set LotNo='" + i + "' where Application_ID='" + dr["Application_ID"].ToString() + "'");
                        cmd.Connection = cn;
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                    ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Total Data Updated " + i + "  Lots...');", true);
                }
            }

        }
        protected void Button13_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 19; i++)
            {
                DataTable dt = cls.GetDataTable("select top 10000 * from DieselKharifReturn where LotNo is null");
                if (dt.Rows.Count > 0)
                {
                    cn.Open();
                    foreach (DataRow dr in dt.Rows)
                    {
                        SqlCommand cmd = new SqlCommand("update DieselKharifReturn set LotNo='" + i + "' where Application_ID='" + dr["Application_ID"].ToString() + "'");
                        cmd.Connection = cn;
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                    ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Total Data Updated " + i + "  Lots...');", true);
                }
            }

        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = CreateDynamicDataSetPFMSRejected();
                cn.Open();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("insert into kkc (id) values ('" + dr["Identity_Proof_No"].ToString() + "')", cn);
                        da.SelectCommand.ExecuteNonQuery();
                    }

                    SqlDataAdapter daa = new SqlDataAdapter("update PMKISAN_SammanNidhi set status=1 where  Identity_Proof_No in (select id from kkc)", cn);
                    daa.SelectCommand.ExecuteNonQuery();

                    SqlDataAdapter daDelete = new SqlDataAdapter("truncate table kkc", cn);
                    daDelete.SelectCommand.ExecuteNonQuery();


                    string FileName = "" + DateTime.Now.ToString("ddMMyyyyHHmm") + "ReturnFarmer.xml";
                    ds.WriteXml(Server.MapPath(FileName));
                    lblResult.Text = "XML File Generated...........";
                    StringWriter sw = new StringWriter();
                    ds.WriteXml(sw, XmlWriteMode.IgnoreSchema);
                    string s = sw.ToString();
                    string attachment = "attachment;filename=" + FileName + "";
                    Response.ClearContent();
                    Response.ContentType = "application/xml";
                    Response.AddHeader("content-disposition", attachment);
                    Response.Write(s);
                    //Response.Write("XML File Generated...........");
                    Response.End();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Msg", "alert('XML File Generated..........." + ds.Tables[0].Rows.Count + "..');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Msg", "alert('Data not exist.............');", true);
                }

                //}
            }
            catch
            {

            }
            finally
            {
                cn.Close();
            }
        }
        private DataSet CreateDynamicDataSetPFMSRejected()
        {
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                //select TOP 20000 State_Ref_Number='NULL', StateCode, DistrictCode, Sub_District_Code, BlockCode, VillageCode, Farmer_Name, Gender, Farmer_Category, Identity_Proof_Type, Identity_Proof_No, IFSC_Code, Bank_Account_Number, MobileNo, CONVERT(CHAR(10),DOB,120) DOB, Father_Mother_Husband_Name, HomeAddress='', Ownership_Single_Joint='', Sr_No='', Survey_Khata_No='', Khasra_Drag_No='', Area='',CASE WHEN  FarmerType IS NULL THEN 1 ELSE FarmerType END AS FarmerType from PMKISAN_SammanNidhi where status=9 and VillageCode is not null and Identity_Proof_No not in ('271700354096')
                SqlDataAdapter da = new SqlDataAdapter("select TOP 20000 State_Ref_Number='NULL', StateCode, DistrictCode, Sub_District_Code, BlockCode, VillageCode, Farmer_Name, Gender, Farmer_Category, Identity_Proof_Type, Identity_Proof_No, IFSC_Code, Bank_Account_Number, MobileNo, CONVERT(CHAR(10),DOB,120) DOB, Father_Mother_Husband_Name, HomeAddress='', Ownership_Single_Joint='', Sr_No='', Survey_Khata_No='', Khasra_Drag_No='', Area='',CASE WHEN  FarmerType IS NULL THEN 1 ELSE FarmerType END AS FarmerType from PMKISAN_SammanNidhi where status=9 and VillageCode is not null and Identity_Proof_No not in ('271700354096')", cn);
                ds.DataSetName = "DocumentElement";
                da.Fill(ds, "Farmer");
            }
            catch
            {

            }
            finally
            {
                cn.Close();
            }
            return ds;
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            int i = 0;
            DataTable dt = cls.GetDataTable(@"SELECT * FROM Diesel_SubsidyApplyKharif201920 WHERE Registration_ID in ( 
            select  Registration_ID from Diesel_SubsidyApplyKharif201920 where Croptype=N'धान'
            GROUP BY Registration_ID
            HAVING SUM(NoofApply ) >3)");
            if (dt.Rows.Count > 0)
            {
                cn.Open();
                int abc = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    i++;
                    DataTable dttt = cls.GetDataTable("SELECT * FROM Diesel_SubsidyApplyKharif201920 WHERE Registration_ID='" + dr["Registration_ID"].ToString() + "' order by slno asc");
                    if (dttt.Rows.Count > 0)
                    {
                        abc = abc + Convert.ToInt16(dttt.Rows[0]["NoofApply"].ToString());
                        if (abc > 3)
                        {
                            SqlCommand cmd = new SqlCommand("update Diesel_SubsidyApplyKharif201920 set AC_Status=9  where Application_ID='" + dr["Application_ID"].ToString() + "'");
                            cmd.Connection = cn;
                            cmd.ExecuteNonQuery();
                            abc = 0;
                        }
                        else
                        {
                        }

                    }

                }
                cn.Close();
                ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Total Data Updated " + i + "  Lots...');", true);
            }
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
           
            string query = "";
            ClassDrought clsDataaa = new ClassDrought();
            DataTable dtt = new DataTable();
            try
            {
                if (DropDownList1.SelectedValue == "1" && DropDownList2.SelectedValue == "1")
                {
                     query = @"select distName,
                                        isnull((select count(*) from  Registration a where a.DistrictCode=d.Distcode ),0) TotalReg,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode  ),0) TotalApp,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and SchemeType = '1' ),0) FloodApp,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and SchemeType = '2' ),0) DroughtApp,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and SchemeType = '3'  ),0) SiltApp,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and ac_status=1 ),0) ACAccept,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and ac_status=2  ),0) ACReject,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and ac_status is null  ),0) PendingAC,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and DAO_status=1  ),0) DAOAccept,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and DAO_status=2  ),0) DAOReject,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and isnull(DAO_status,0)=1 and ADM_Status=1 ),0) ADMAccept,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and isnull(DAO_status,0)=1 and ADM_Status=2  ),0) ADMReject ,
                                        isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and  sendtobank=1 and  ADM_Status=1 ),0) Sendtobank,
                                        isnull((select sum(a.ADM_ApprovedAmnt ) from  [OlaWrishti_OnlineApply] a where a.Distcode=d.Distcode and  sendtobank=1 and  ADM_Status=1  ),0) Amount 
                                        from districts d   order by distName";
                }
                else if (DropDownList1.SelectedValue =="2" && DropDownList2.SelectedValue=="1")
                {
                    query = @"select (SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistCode), dd.BlockName,                             
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and SchemeType = '1') TotalApp,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1 and SchemeType = '1'),0) ACAccept,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and  isnull(ac_status,0)=2 and SchemeType = '1'),0) ACReject,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1 and isnull(DAO_status,0)=1 and SchemeType = '1'),0) COAccept,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1 and isnull(DAO_status,0)=2 and SchemeType = '1'),0) COReject,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(DAO_status,0)=1 and ADM_Status=1 and SchemeType = '1'),0) ADMRAccept,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(DAO_status,0)=1 and ADM_Status=2 and SchemeType = '1'),0) ADMRReject 
                            from Blocks dd 
                            order by	(SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistCode) ,dd.BlockName";
                }
                else if (DropDownList1.SelectedValue == "2" && DropDownList2.SelectedValue == "2")
                {
                    query = @"select (SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistCode), dd.BlockName,                             
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and SchemeType = '2') TotalApp,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1 and SchemeType = '2'),0) ACAccept,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and  isnull(ac_status,0)=2 and SchemeType = '2'),0) ACReject,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1 and isnull(DAO_status,0)=1 and SchemeType = '2'),0) COAccept,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1 and isnull(DAO_status,0)=2 and SchemeType = '2'),0) COReject,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(DAO_status,0)=1 and ADM_Status=1 and SchemeType = '2'),0) ADMRAccept,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(DAO_status,0)=1 and ADM_Status=2 and SchemeType = '2'),0) ADMRReject 
                            from Blocks dd 
                            order by	(SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistCode) ,dd.BlockName";
                }
                else if (DropDownList1.SelectedValue == "2" && DropDownList2.SelectedValue == "3")
                {
                    query = @"select (SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistCode), dd.BlockName,                             
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and SchemeType = '3') TotalApp,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1 and SchemeType = '3'),0) ACAccept,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and  isnull(ac_status,0)=2 and SchemeType = '3'),0) ACReject,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1 and isnull(DAO_status,0)=1 and SchemeType = '3'),0) COAccept,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1 and isnull(DAO_status,0)=2 and SchemeType = '3'),0) COReject,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(DAO_status,0)=1 and ADM_Status=1 and SchemeType = '3'),0) ADMRAccept,
                            isnull((select count(*) from  [OlaWrishti_OnlineApply] a where a.BlockCode=dd.BlockCode and isnull(DAO_status,0)=1 and ADM_Status=2 and SchemeType = '3'),0) ADMRReject 
                            from Blocks dd 
                            order by	(SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistCode) ,dd.BlockName";
                }
                else if (DropDownList1.SelectedValue == "3" && DropDownList2.SelectedValue == "1")
                {
                    query = @"select (SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistrictCode),dd.[Block Name], dd.PanchayatName,                             
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.PanchayatCode=dd.PanchayatCode and SchemeType = '1' ) TotalApp,
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.PanchayatCode=dd.PanchayatCode and ac_status=1 and SchemeType = '1' ) ACAccept,
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.PanchayatCode=dd.PanchayatCode and ac_status=2 and SchemeType = '1') ACReject
                            from Panchayat dd 
                            order by	(SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistrictCode),dd.[Block Name] ,dd.PanchayatName";
                }
                else if (DropDownList1.SelectedValue == "3" && DropDownList2.SelectedValue == "2")
                {
                    query = @"select (SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistrictCode),dd.[Block Name], dd.PanchayatName,                             
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.PanchayatCode=dd.PanchayatCode and SchemeType = '2' ) TotalApp,
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.PanchayatCode=dd.PanchayatCode and ac_status=1 and SchemeType = '2' ) ACAccept,
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.PanchayatCode=dd.PanchayatCode and ac_status=2 and SchemeType = '2') ACReject
                            from Panchayat dd 
                            order by	(SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistrictCode),dd.[Block Name] ,dd.PanchayatName";
                }
                else if (DropDownList1.SelectedValue == "3" && DropDownList2.SelectedValue == "3")
                {
                    query = @"select (SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistrictCode),dd.[Block Name], dd.PanchayatName,                             
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.PanchayatCode=dd.PanchayatCode and SchemeType = '3' ) TotalApp,
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.PanchayatCode=dd.PanchayatCode and ac_status=1 and SchemeType = '3' ) ACAccept,
                            (select count(*) from  [OlaWrishti_OnlineApply] a where a.PanchayatCode=dd.PanchayatCode and ac_status=2 and SchemeType = '3') ACReject
                            from Panchayat dd 
                            order by	(SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistrictCode),dd.[Block Name] ,dd.PanchayatName";
                }
                dtt = clsDataaa.GetDataTable(query);
                if (dtt.Rows.Count > 0)
                {

                    GridView3.DataSource = dtt;
                    GridView3.DataBind();
                }
            }
            catch (Exception ex) { }
        }

        protected void btnreport_Click(object sender, EventArgs e)
        {
            clsDataAccess clsnew = new clsDataAccess();
            DataTable dtnew = new DataTable();
            ClassDrought clsDataaa = new ClassDrought();
            DataTable dtt = new DataTable();
            string query = "";
            if (ddlschemetype.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Msg", "alert('Kindly select scheme type');", true);
                return;
            }
            if (ddllevel.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Msg", "alert('Kindly select Criteria type');", true);
                return;
            }

            if (ddlschemetype.SelectedValue == "1" && ddllevel.SelectedValue == "1")
            {
                query = @"select d.DistName,
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[Total Application],
                (select sum(TotalAffectedRakwa) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[Total Claim Rakwa],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and AC_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[AC Accept],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ac_status in(9,2) and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[AC Reject],
                (select sum(ac_changerakwa) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and AC_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))ac_changerakwa,
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and DAO_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[DAO Accept],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and DAO_Status=2 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[DAO Reject],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ADM_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[ADM Accept],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ADM_Status=2 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[ADM Reject],
                (select SUM(ADM_ApprovedAmnt) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and ADM_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[Approved Amt],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ADM_Status=1  and sendtobank=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[Bank Sent],
                (select SUM(ADM_ApprovedAmnt) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and ADM_Status=1 and sendtobank=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[ADM Accept],
                (select COUNT(*) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021)) [Total Farmers],
                (select SUM(NewAmount) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[Bank amout],
                (select COUNT(*) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[Success Amount],
                (select COUNT(*) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=0 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[Failed amount],
                (select SUM(NewAmount) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[Success Amount],
                (select SUM(NewAmount) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=0 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))[Failed amount]
                from Districts  d 
                where (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021))>0
                order by d.DistName";
            }
            if (ddlschemetype.SelectedValue == "2" && ddllevel.SelectedValue == "1") // 5 Districts Data
            {
                query = @"select d.DistName,
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[Total Application],
                (select sum(TotalAffectedRakwa) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[Total Claim Rakwa],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and AC_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[AC Accept],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ac_status in(9,2) and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[AC Reject],
                (select sum(ac_changerakwa) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and AC_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))ac_changerakwa,
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and DAO_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[DAO Accept],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and DAO_Status=2 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[DAO Reject],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ADM_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[ADM Accept],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ADM_Status=2 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[ADM Reject],
                (select SUM(ADM_ApprovedAmnt) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and ADM_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[Approved Amt],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ADM_Status=1  and sendtobank=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[Bank Sent],
                (select SUM(ADM_ApprovedAmnt) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and ADM_Status=1 and sendtobank=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[ADM Accept],
                (select COUNT(*) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist)) [Total Farmers],
                (select SUM(NewAmount) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[Bank amout],
                (select COUNT(*) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[Success Amount],
                (select COUNT(*) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=0 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[Failed amount],
                (select SUM(NewAmount) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[Success Amount],
                (select SUM(NewAmount) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=0 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))[Failed amount]
                from Districts  d 
                where (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_5dist))>0
                order by d.DistName";
            }
            if (ddlschemetype.SelectedValue == "3" && ddllevel.SelectedValue == "1")
            {
                query = @"select  d.DistName,
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[Total Application],
                (select sum(TotalAffectedRakwa) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[Total Claim Rakwa],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and AC_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[AC Accept],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ac_status in(9,2) and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[AC Reject],
                (select sum(ac_changerakwa) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and AC_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))ac_changerakwa,
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and DAO_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[DAO Accept],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and DAO_Status=2 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[DAO Reject],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ADM_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[ADM Accept],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ADM_Status=2 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[ADM Reject],
                (select SUM(ADM_ApprovedAmnt) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and ADM_Status=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[Approved Amt],
                (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode  and ADM_Status=1  and sendtobank=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[Bank Sent],
                (select SUM(ADM_ApprovedAmnt) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and ADM_Status=1 and sendtobank=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[ADM Accept],
                (select COUNT(*) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian)) [Total Farmers],
                (select SUM(NewAmount) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[Bank amout],
                (select COUNT(*) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[Success Amount],
                (select COUNT(*) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=0 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[Failed amount],
                (select SUM(NewAmount) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=1 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[Success Amount],
                (select SUM(NewAmount) from pnbkharif2021 (nolock) a inner join  floodkharif_onlineapply f on a.[User Credit reference]=f.Application_ID where f.Distcode=d.DistCode and [Success/Failure]=0 and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))[Failed amount]
                from Districts  d 
                where (select count(1) from floodkharif_onlineapply (nolock) a where a.Distcode=d.DistCode and PanchayatCode in(select PanchayatCode from Flood_Panchayat_2021_REAgian))>0
                order by d.DistName";
            }
            if(ddlschemetype.SelectedValue == "4" && ddllevel.SelectedValue == "3")
            {
                query = @"select (SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistrictCode),dd.[Block Name], dd.PanchayatName,                             
                (select count(*) from  floodkharif_onlineapply a where a.PanchayatCode=dd.PanchayatCode ) TotalApp,
                (select sum(TotalAffectedRakwa) from  floodkharif_onlineapply a where a.PanchayatCode=dd.PanchayatCode ) TotalClaimRakwa,
                (select count(*) from  floodkharif_onlineapply a where a.PanchayatCode=dd.PanchayatCode and ac_status=1) ACAccept,
                (select sum(ac_changerakwa) from floodkharif_onlineapply a where a.PanchayatCode=dd.PanchayatCode  and AC_Status=1 ) ac_changerakwa,
                (select count(*) from  floodkharif_onlineapply a where a.PanchayatCode=dd.PanchayatCode and ac_status in(9,2)) ACReject
                from Panchayat dd where (select count(*) from  floodkharif_onlineapply a where a.PanchayatCode=dd.PanchayatCode ) >0
                order by	(SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistrictCode),dd.[Block Name] ,dd.PanchayatName";

            }

            //PMKISAN DATA
            if (ddlschemetype.SelectedValue == "4" && ddllevel.SelectedValue == "1")
            {
                query = @"select distName,
                isnull((select count(*) from  Registration_PMKISAN a where a.Distcode=d.Distcode ),0) TotalApp,
                isnull((select count(*) from  Registration_PMKISAN a where a.Distcode=d.Distcode and isnull(ac_status,0)=1),0) ACAccept,
                isnull((select count(*) from  Registration_PMKISAN a where a.Distcode=d.Distcode and isnull(ac_status,0)=2),0) ACReject,
                isnull((select count(*) from  Registration_PMKISAN a where a.Distcode=d.Distcode and isnull(ac_status,0)=1 and isnull(DAO_status,0)=1),0) COAccept,
                isnull((select count(*) from  Registration_PMKISAN a where a.Distcode=d.Distcode and isnull(ac_status,0)=1 and isnull(DAO_status,0)=2),0) COReject,
                isnull((select count(*) from  Registration_PMKISAN a where a.Distcode=d.Distcode and isnull(DAO_status,0)=1 and ADMR_Status=1),0) ADMRAccept,
                isnull((select count(*) from  Registration_PMKISAN a where a.Distcode=d.Distcode and isnull(DAO_status,0)=1 and ADMR_Status=2),0) ADMRReject,
                isnull((select count(*) from  Registration_PMKISAN a where a.Distcode=d.Distcode and XMLStatus=1 and reconsider is null),0) FileSend
                from districts d order by distName";
            }
            if (ddlschemetype.SelectedValue == "4" && ddllevel.SelectedValue == "2")
            {
                query = @"select (SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistCode), dd.BlockName,                             
                (select count(*) from  Registration_PMKISAN a where a.BlockCode=dd.BlockCode ) TotalApp,
                isnull((select count(*) from  Registration_PMKISAN a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1),0) ACAccept,
                isnull((select count(*) from  Registration_PMKISAN a where a.BlockCode=dd.BlockCode and  isnull(ac_status,0)=2),0) ACReject,
                isnull((select count(*) from  Registration_PMKISAN a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1 and isnull(DAO_status,0)=1),0) COAccept,
                isnull((select count(*) from  Registration_PMKISAN a where a.BlockCode=dd.BlockCode and isnull(ac_status,0)=1 and isnull(DAO_status,0)=2),0) COReject,
                isnull((select count(*) from  Registration_PMKISAN a where a.BlockCode=dd.BlockCode and isnull(DAO_status,0)=1 and ADMR_Status=1),0) ADMRAccept,
                isnull((select count(*) from  Registration_PMKISAN a where a.BlockCode=dd.BlockCode and isnull(DAO_status,0)=1 and ADMR_Status=2),0) ADMRReject                    
                from Blocks dd 
                order by	(SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistCode) ,dd.BlockName";
            }
            if (ddlschemetype.SelectedValue == "4" && ddllevel.SelectedValue == "3")
            {
                query = @"select (SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistrictCode),dd.[Block Name], dd.PanchayatName,                             
                (select count(*) from  Registration_PMKISAN a where a.PanchayatCode=dd.PanchayatCode ) TotalApp,
                (select count(*) from  Registration_PMKISAN a where a.PanchayatCode=dd.PanchayatCode and ac_status=1) ACAccept,
                (select count(*) from  Registration_PMKISAN a where a.PanchayatCode=dd.PanchayatCode and ac_status=2) ACReject
                from Panchayat dd 
                order by	(SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistrictCode),dd.[Block Name] ,dd.PanchayatName";
            }
            if (ddlschemetype.SelectedValue == "4" && ddlschemetype.SelectedValue == "5" && ddlschemetype.SelectedValue == "6")
            {
                dtnew = clsnew.GetDataTable(query);
            }
            else
            {
                dtt = clsDataaa.GetDataTable(query);
            }
            if (dtnew.Rows.Count > 0)
            {
                GridView4.DataSource = dtnew;
                GridView4.DataBind();
            }
            if (dtt.Rows.Count > 0)
            {
                GridView4.DataSource = dtt;
                GridView4.DataBind();
            }
        }       
    }
}
