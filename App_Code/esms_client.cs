using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Security.Cryptography; 
using System.Security.Cryptography.X509Certificates;
namespace TestSMS
{
    class esms_client
    {
        public String sendSingleSMS(String username, String password, String senderid, String mobileNo, String message, String secureKey)
        {
            //Latest Generated Secure Key
            Stream dataStream;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;

            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";

            request.Method = "POST";

            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username, senderid, message, secureKey);
            String smsservicetype = "singlemsg"; //For single message.

            String query = "username=" + HttpUtility.UrlEncode(username) +
                "&password=" + HttpUtility.UrlEncode(encryptedPassword) +

                "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +

                "&content=" + HttpUtility.UrlEncode(message) +

                "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +

                "&senderid=" + HttpUtility.UrlEncode(senderid) +
              "&key=" + HttpUtility.UrlEncode(NewsecureKey);
            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
        public String sendUnicodeSMS(String username, String password, String senderid, String mobileNos, String Unicodemessage, String secureKey)
        {
            Stream dataStream;
            HttpWebRequest request =
            (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            //((HttpWebRequest)request).UserAgent = ".NET FrameworkExample Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0(compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            String U_Convertedmessage = "";
            foreach (char c in Unicodemessage)
            {
                int j = (int)c;
                String sss = "&#" + j + ";";
                U_Convertedmessage = U_Convertedmessage + sss;
            }
            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username, senderid,
            U_Convertedmessage, secureKey);
            String smsservicetype = "unicodemsg"; // for unicode msg
            String query = "username=" + HttpUtility.UrlEncode(username) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype)
            +
            "&content=" + HttpUtility.UrlEncode(U_Convertedmessage) +
            "&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +
            "&senderid=" + HttpUtility.UrlEncode(senderid) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey);
            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
        public String sendOTPMSG(String username, String password, String senderid, String mobileNo, String message, String secureKey)
        {
            
                Stream dataStream;
                HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");

                request.ProtocolVersion = HttpVersion.Version10;
                request.KeepAlive = false;
                request.ServicePoint.ConnectionLimit = 1;
                //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
                ((HttpWebRequest)request).UserAgent = "Mozilla/4.0(compatible; MSIE 5.0; Windows 98; DigExt)";
                request.Method = "POST";
                String encryptedPassword = encryptedPasswod(password);
                String key = hashGenerator(username, senderid, message,
                secureKey);
                String smsservicetype = "otpmsg"; //For OTP message.
                String query = "username=" + HttpUtility.UrlEncode(username) +
                "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
                "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype)
                +
                "&content=" + HttpUtility.UrlEncode(message) +
                "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                "&senderid=" + HttpUtility.UrlEncode(senderid) +
                "&key=" + HttpUtility.UrlEncode(key);
                byte[] byteArray = Encoding.ASCII.GetBytes(query);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                String Status = ((HttpWebResponse)response).StatusDescription;
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                return responseFromServer;
         
           
        }
        protected String encryptedPasswod(String password)
        {

            byte[] encPwd = Encoding.UTF8.GetBytes(password);
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
            byte[] pp = sha1.ComputeHash(encPwd);
            // static string result = System.Text.Encoding.UTF8.GetString(pp);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in pp)
            {

                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();

        }
        protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
            byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
            byte[] sec_key = sha1.ComputeHash(genkey);

            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < sec_key.Length; i++)
            {
                sb1.Append(sec_key[i].ToString("x2"));
            }
            return sb1.ToString();
        }
        public String sendUnicodeSMSs(String username, String password, String senderid, String mobileNos, String Unicodemessage, String secureKey)
        {
          
                Stream dataStream;
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");

                request.ProtocolVersion = HttpVersion.Version10;
                request.KeepAlive = false;
                request.ServicePoint.ConnectionLimit = 1;

                //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
                ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";

                request.Method = "POST";

                System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                String U_Convertedmessage = "";

                foreach (char c in Unicodemessage)
                {
                    int j = (int)c;
                    String sss = "&#" + j + ";";
                    U_Convertedmessage = U_Convertedmessage + sss;
                }
                String encryptedPassword = encryptedPasswod(password);
                String NewsecureKey = hashGenerator(username, senderid, U_Convertedmessage, secureKey);


                String smsservicetype = "unicodemsg"; // for unicode msg
                String query = "username=" + HttpUtility.UrlEncode(username) +
                    "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
                    "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                    "&content=" + HttpUtility.UrlEncode(U_Convertedmessage) +
                    "&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +
                    "&senderid=" + HttpUtility.UrlEncode(senderid) +
                    "&key=" + HttpUtility.UrlEncode(NewsecureKey);


                byte[] byteArray = Encoding.ASCII.GetBytes(query);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                String Status = ((HttpWebResponse)response).StatusDescription;
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                return responseFromServer;
            
        }   
        class MyPolicy : ICertificatePolicy
        {
            public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
            {
                return true;
            }
        }
        public String sendBulkSMS(String username, String password, String senderid, String mobileNos, String Unicodemessage, String secureKey)
        {
            
            //Stream dataStream;
            //HttpWebRequest request =
            //(HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            //request.ProtocolVersion = HttpVersion.Version10;
            //request.KeepAlive = false;
            //request.ServicePoint.ConnectionLimit = 1;
            ////((HttpWebRequest)request).UserAgent = ".NET FrameworkExample Client";
            //((HttpWebRequest)request).UserAgent = "Mozilla/4.0(compatible; MSIE 5.0; Windows 98; DigExt)";
            //request.Method = "POST";
            //String encryptedPassword = encryptedPasswod(password);
            //String NewsecureKey = hashGenerator(username, senderid, message, secureKey);
            //Console.Write(NewsecureKey);
            //Console.Write(encryptedPassword);
            //String smsservicetype = "bulkmsg"; // for bulk msg
            //String query = "username=" + HttpUtility.UrlEncode(username) +
            //"&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            //"&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
            //"&content=" + HttpUtility.UrlEncode(message) +
            //"&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +
            //"&senderid=" + HttpUtility.UrlEncode(senderid) +
            //"&key=" + HttpUtility.UrlEncode(NewsecureKey);
            //Console.Write(query);
            //byte[] byteArray = Encoding.ASCII.GetBytes(query);
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = byteArray.Length;
            //dataStream = request.GetRequestStream();
            //dataStream.Write(byteArray, 0, byteArray.Length);
            //dataStream.Close();
            //WebResponse response = request.GetResponse();
            //String Status = ((HttpWebResponse)response).StatusDescription;
            //dataStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(dataStream);
            //String responseFromServer = reader.ReadToEnd();
            //reader.Close();
            //dataStream.Close();
            //response.Close();
            //return responseFromServer;  
            
            //COMMENTED ON 20-FEB-2018

                //Stream dataStream;
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
                //request.ProtocolVersion = HttpVersion.Version10;
                //request.KeepAlive = false;
                //request.ServicePoint.ConnectionLimit = 1;
                ////((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
                //((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
                //request.Method = "POST";
                //System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
                //String U_Convertedmessage = "";
                //foreach (char c in message)
                //{
                //    int j = (int)c;
                //    String sss = "&#" + j + ";";
                //    U_Convertedmessage = U_Convertedmessage + sss;
                //}
                //String encryptedPassword = encryptedPasswod(password);
                //String NewsecureKey = hashGenerator(username, senderid, U_Convertedmessage, secureKey);
                //String smsservicetype = "unicodemsg"; // for unicode msg
                //String query = "username=" + HttpUtility.UrlEncode(username) +
                //    "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
                //    "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                //    "&content=" + HttpUtility.UrlEncode(U_Convertedmessage) +
                //    "&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +
                //    "&senderid=" + HttpUtility.UrlEncode(senderid) +
                //    "&key=" + HttpUtility.UrlEncode(NewsecureKey);
                //byte[] byteArray = Encoding.ASCII.GetBytes(query);
                //request.ContentType = "application/x-www-form-urlencoded";
                //request.ContentLength = byteArray.Length;
                //dataStream = request.GetRequestStream();
                //dataStream.Write(byteArray, 0, byteArray.Length);
                //dataStream.Close();
                //WebResponse response = request.GetResponse();
                //String Status = ((HttpWebResponse)response).StatusDescription;
                //dataStream = response.GetResponseStream();
                //StreamReader reader = new StreamReader(dataStream);
                //String responseFromServer = reader.ReadToEnd();
                //reader.Close();
                //dataStream.Close();
                //response.Close();
                //return responseFromServer;

            // ADDED ON 20-FEB-2018
            Stream dataStream;
            HttpWebRequest request =
            (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            //((HttpWebRequest)request).UserAgent = ".NET FrameworkExample Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0(compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            String U_Convertedmessage = "";
            foreach (char c in Unicodemessage)
            {
                int j = (int)c;
                String sss = "&#" + j + ";";
                U_Convertedmessage = U_Convertedmessage + sss;
            }
            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username, senderid,
            U_Convertedmessage, secureKey);
            String smsservicetype = "unicodemsg"; // for unicode msg
            String query = "username=" + HttpUtility.UrlEncode(username) +
            "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype)
            +
            "&content=" + HttpUtility.UrlEncode(U_Convertedmessage) +
            "&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +
            "&senderid=" + HttpUtility.UrlEncode(senderid) +
            "&key=" + HttpUtility.UrlEncode(NewsecureKey);
            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
            
        }
    }
}
/*
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
namespace esms_client
{
  public class SMSHttpPostClient
    {
        // Method for sending single SMS.
        public String sendSingleSMS(String username, String password, String senderid, String mobileNo, String message, String secureKey)
        {
            //Latest Generated Secure Key
            Stream dataStream;

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");

            request.ProtocolVersion = HttpVersion.Version10;

            request.KeepAlive = false;

            request.ServicePoint.ConnectionLimit = 1;
           //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
           String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username, senderid, message, secureKey);

            String smsservicetype = "singlemsg"; //For single message.
           String query = "username=" + HttpUtility.UrlEncode(username) +"&password=" + HttpUtility.UrlEncode(encryptedPassword) +"&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +"&content=" + HttpUtility.UrlEncode(message) +"&mobileno=" + HttpUtility.UrlEncode(mobileNo) +"&senderid=" + HttpUtility.UrlEncode(senderid) +"&key=" + HttpUtility.UrlEncode(NewsecureKey);
            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
           return responseFromServer;
        }
        /// Method for sending bulk SMS.
        public String sendBulkSMS(String username, String password, String senderid, String mobileNos, String message,String secureKey)
       {

            Stream dataStream;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
           System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username, senderid, message, secureKey);
 
            Console.Write(NewsecureKey);
 
            Console.Write(encryptedPassword);
            String smsservicetype = "bulkmsg"; // for bulk msg
           String query = "username=" + HttpUtility.UrlEncode(username) +"&password=" + HttpUtility.UrlEncode(encryptedPassword) +"&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +"&content=" + HttpUtility.UrlEncode(message) +"&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +"&senderid=" + HttpUtility.UrlEncode(senderid) +"&key=" + HttpUtility.UrlEncode(NewsecureKey);
             Console.Write(query);
            byte[] byteArray = Encoding.ASCII.GetBytes(query);
           request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
 
        //method for Sending unicode message..
     public String sendUnicodeSMS(String username, String password, String senderid, String mobileNos, String Unicodemessage, String secureKey)
        {
           Stream dataStream;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
           ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
          request.Method = "POST";
           System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            String U_Convertedmessage = "";
            foreach (char c in Unicodemessage)
            {
                int j = (int)c;
               String sss = "&#" + j + ";";
                U_Convertedmessage = U_Convertedmessage + sss;
            }
            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username, senderid, U_Convertedmessage, secureKey);
            String smsservicetype = "unicodemsg"; // for unicode msg
           String query = "username=" + HttpUtility.UrlEncode(username) +"&password=" + HttpUtility.UrlEncode(encryptedPassword) +"&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +"&content=" + HttpUtility.UrlEncode(U_Convertedmessage) +"&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +"&senderid=" + HttpUtility.UrlEncode(senderid) +"&key=" + HttpUtility.UrlEncode(NewsecureKey);
             byte[] byteArray = Encoding.ASCII.GetBytes(query);
             request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
           dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
           reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
        // Method for sending OTP MSG.
        public String sendOTPMSG(String username, String password, String senderid, String mobileNo, String message, String secureKey)
        {
            Stream dataStream;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            String encryptedPassword = encryptedPasswod(password);
            String key = hashGenerator(username, senderid, message, secureKey);
            String smsservicetype = "otpmsg"; //For OTP message.
           String query = "username=" + HttpUtility.UrlEncode(username) +"&password=" + HttpUtility.UrlEncode(encryptedPassword) +"&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +"&content=" + HttpUtility.UrlEncode(message) +"&mobileno=" + HttpUtility.UrlEncode(mobileNo) +"&senderid=" + HttpUtility.UrlEncode(senderid) +"&key=" + HttpUtility.UrlEncode(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
           reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
        //method for Sending unicode message..
        public String sendUnicodeOTPSMS(String username, String password, String senderid, String mobileNos, String UnicodeOTPmsg, String secureKey)
        {
            Stream dataStream;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
           //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            String U_Convertedmessage = "";
            foreach (char c in UnicodeOTPmsg)
            {
                int j = (int)c;
               String sss = "&#" + j + ";";
                U_Convertedmessage = U_Convertedmessage + sss;
            }
            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username, senderid, U_Convertedmessage, secureKey);
            String smsservicetype = "unicodeotpmsg"; // for unicode msg
            String query = "username=" + HttpUtility.UrlEncode(username) +"&password=" + HttpUtility.UrlEncode(encryptedPassword) +"&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +"&content=" + HttpUtility.UrlEncode(U_Convertedmessage) +"&bulkmobno=" + HttpUtility.UrlEncode(mobileNos) +"&senderid=" + HttpUtility.UrlEncode(senderid) +"&key=" + HttpUtility.UrlEncode(NewsecureKey);
            byte[] byteArray = Encoding.ASCII.GetBytes(query);
           request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
           dataStream.Close();
            response.Close();
           return responseFromServer;
        }
        /// Method to get Encrypted the password
        protected String encryptedPasswod(String password)
       {
            byte[] encPwd = Encoding.UTF8.GetBytes(password);
           //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
            byte[] pp = sha1.ComputeHash(encPwd);
            // static string result = System.Text.Encoding.UTF8.GetString(pp);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in pp)
           {
               sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        /// <summary>
       /// Method to Generate hash code 
        /// </summary>
        /// <param name="secure_key">your last generated Secure_key
       protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
        {
            StringBuilder sb = new StringBuilder();
           sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
           byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
            byte[] sec_key = sha1.ComputeHash(genkey);
            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < sec_key.Length; i++)
            {
               sb1.Append(sec_key[i].ToString("x2"));
            }
            return sb1.ToString();
        }
    }

}

 class MyPolicy : ICertificatePolicy
        {
            public bool CheckValidationResult(ServicePoint srvPoint, X509Certificate certificate, WebRequest request, int certificateProblem)
            {
                return true;
            }
        }
                
*/