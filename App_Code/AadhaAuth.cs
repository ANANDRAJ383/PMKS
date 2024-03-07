using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Configuration;
//using Microsoft.SqlServer.Management.Smo;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Threading;
using System.Globalization;
using QRCoder;
using System.Drawing;
using System.IO;
using esms_client;
using System.Web.Services;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml;

public class AadhaAuth
{
    SqlConnection con = new SqlConnection();
    public AadhaAuth()
    {

        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }


    public string AadharAuthentication(string AdharNo, string ApplicantName)
    {
        string url = "http://192.168.39.207:8080/authekycp25/api/authenticate";  
        string error1 = "";
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        string Reuslt = "";

        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        string txn1 = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.ToString("MM") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + GetUniqueKey(20).ToUpper();
        string SubAua = "PDAGB22450";
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {

            string json = "";
            json = new JavaScriptSerializer().Serialize(new
            {
                uid = AdharNo.Trim(),
                uidType = "A",
                consent = "Y",
                subAuaCode = SubAua,
                txn = txn1,
                isPI = "y",
                isBio = "n",
                isOTP = "n",
                bioType = "n",
                name = ApplicantName.Trim(),
                rdInfo = "n",
                rdData = "n",
                otpValue = "n"
            });
            streamWriter.Write(json);
            streamWriter.Flush();
            streamWriter.Close();
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            List<url_details2> obj = json_deserialized(result);
            string ret = obj[0].ret;
            string status = obj[0].status;
            string error = obj[0].err;
            if (status == "SUCCESS")
            {
                string url1 = "http://192.168.39.207:8080/authekycp25/api/generateOTP"; // OTP


                var httpWebRequest1 = (HttpWebRequest)WebRequest.Create(url1);
                httpWebRequest1.ContentType = "application/json";
                httpWebRequest1.Method = "POST";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                string txnOTP1 = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.ToString("MM") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + GetUniqueKey(20).ToUpper();
                string SubAuaOTP = "PDAGB22450";
                using (var streamWriter1 = new StreamWriter(httpWebRequest1.GetRequestStream()))
                {
                    string jsona = "";

                    jsona = new JavaScriptSerializer().Serialize(new
                    {
                        uid = AdharNo.Trim(),
                        uidType = "A",
                        subAuaCode = SubAuaOTP,

                    });
                    streamWriter1.Write(jsona);
                    streamWriter1.Flush();
                    streamWriter1.Close();

                    var httpResponse1 = (HttpWebResponse)httpWebRequest1.GetResponse();
                    using (var streamReader1 = new StreamReader(httpResponse1.GetResponseStream()))
                    {
                        var result1 = streamReader1.ReadToEnd();
                        List<url_details2> obj1 = json_deserialized(result1);
                        string ret1 = obj1[0].ret;
                        string status1 = obj1[0].status;
                        error1 = obj1[0].err;
                        string otp1 = "";
                        string MobileNo1 = "";
                        string txnnew = "";
                        if (status1 == "SUCCESS")
                        {
                            try
                            {
                                txnnew = obj1[0].txn;
                                MobileNo1 = obj1[0].mobileNumber;
                                string query = "insert into AadhaarAuth_CSM (AADHARNO, txt) values (@AADHARNO, @txt)";
                                con.Open();
                                SqlDataAdapter da = new SqlDataAdapter(query, con);
                                da.SelectCommand.Parameters.AddWithValue("@AADHARNO", AdharNo);
                                da.SelectCommand.Parameters.AddWithValue("@txt", txnnew);
                                int i = da.SelectCommand.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    Reuslt = status1;
                                   // Session["txtno"] = txnnew;
                                }
                            }
                            catch { }
                            finally { con.Close(); }
                        }
                        else
                        {
                            Reuslt = error1;
                        }
                    }
                }
            }
            else
            {

                Reuslt = error1;
            }
            return Reuslt;
        }
    }
    public List<url_details2> json_deserialized(string jasoncoe)
    {
        string json = "[" + jasoncoe + "]";

        List<url_details2> items = new List<url_details2>();
        items = JsonConvert.DeserializeObject<List<url_details2>>(json);

        return items;
    }
    public static string GetUniqueKey(int maxSize)
    {
        char[] chars = new char[62];
        chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        byte[] data = new byte[1];
        RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
        crypto.GetNonZeroBytes(data);
        data = new byte[maxSize];
        crypto.GetNonZeroBytes(data);
        StringBuilder result = new StringBuilder(maxSize);
        foreach (byte b in data)
        {
            result.Append(chars[b % (chars.Length)]);
        }
        return result.ToString().ToUpper();
    }
}
public class url_details2
{
    public string ret { get; set; }
    public string status { get; set; }
    public string err { get; set; }
    public string txn { get; set; }
    public string responseCode { get; set; }
    public string mobileNumber { get; set; }

}