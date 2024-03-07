using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

public partial class DieselKharifPrint1920 : System.Web.UI.Page
{
    string applicationno = string.Empty;
    clsDataAccess clsdata = new clsDataAccess();
    //clsDataAccess clsdata = new clsDataAccess();
    string AppNo = "";
    SqlConnection con = new SqlConnection();
    DataTable dt = new DataTable();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter adp = new SqlDataAdapter();
    public DieselKharifPrint1920()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishDiesel"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        AppNo = Decrypt(HttpUtility.UrlDecode(Request.QueryString["ApplicationNo"]));
        applicationno = Decrypt(HttpUtility.UrlDecode(Request.QueryString["Appno"]));//Decrypt(HttpUtility.UrlDecode())
        if (!IsPostBack)
        {
            FillDetails();
        }

    }
    void FillDetails()
    {
        string query = "";
        try
        {
            query = @"SELECT * FROM Diesel_SubsidyApplyKharif202223  D INNER JOIN REGISTRATION R
                            ON D.REGISTRATION_ID=R.REGISTRATION_ID WHERE D.Application_ID='" + AppNo.ToString() + "'";

            cmd.Connection = con;
            cmd.CommandText = query;
            adp.SelectCommand = cmd;
            con.Open();
            adp.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                //----------------- GENERATE QR CODE-------------------------

                //pnlsearchdata.Visible = true;
                lblregistrationid.Text = dt.Rows[0]["Registration_ID"].ToString();
                string fname = dt.Rows[0]["Farmer_FName"].ToString();
                Session["FName"] = dt.Rows[0]["Farmer_FName"].ToString();
                string lastname = dt.Rows[0]["Farmer_LName"].ToString();
                lblfulname.Text = fname.ToString().Trim() + " " + lastname.ToString().Trim();
                lblfathername.Text = dt.Rows[0]["Father_Husband_Name"].ToString();
                lblfrmrdob.Text = dt.Rows[0]["DOB"].ToString();
                lblttlage.Text = dt.Rows[0]["TotalAge"].ToString();
                lbldistname.Text = dt.Rows[0]["DistrictName"].ToString();
                lblblockname.Text = dt.Rows[0]["BlockName"].ToString(); ;
                //=====================  Aadhaar Masking Here.. ================================
                var cardNumber = dt.Rows[0]["AadhaarNumber"].ToString();
                var firstDigits = cardNumber.Substring(0, 4);
                var lastDigits = cardNumber.Substring(cardNumber.Length - 4, 4);
                var requiredMask = new String('X', cardNumber.Length - firstDigits.Length - lastDigits.Length);
                var maskedString = string.Concat(firstDigits, requiredMask, lastDigits);
                var maskedCardNumberWithSpaces = Regex.Replace(maskedString, ".{4}", "$0 ");
                //===========================================================
                lblaadaar.Text = maskedCardNumberWithSpaces.ToString().Trim();
                lblmobile.Text = dt.Rows[0]["MobileNumber"].ToString();
                //lblapptype.Text = ddlapptype.SelectedItem.Text.Trim();
                lblgender.Text = dt.Rows[0]["Gender"].ToString();
                lblfrmsrtype.Text = dt.Rows[0]["Farmertype"].ToString();
                string query1 = "";

                lblApplicationID.Text = dt.Rows[0]["Application_ID"].ToString();
                lblFarmerType.Text = dt.Rows[0]["Farmertype"].ToString();
                //lblSeason.Text = "रबी";
                lblSubsidyAmnt.Text = dt.Rows[0]["Totalamount"].ToString();
                lblPetrolName.Text = dt.Rows[0]["PetrolPumpName"].ToString() + "- Receipt No: " + dt.Rows[0]["RasidNo"].ToString(); ;
                lblCropName.Text = dt.Rows[0]["Croptype"].ToString();
                lbltotalLand.Text = dt.Rows[0]["Totallandcultivation"].ToString();
                lblLand.Text = dt.Rows[0]["Totalland"].ToString();
                lblDate.Text = dt.Rows[0]["EntryDate"].ToString();
                lblDieselRate.Text = dt.Rows[0]["RateofDiesel"].ToString();

                //lblAppNo.Text = applicationno.ToString();
                string code = " ApplicationId: " + applicationno.ToString() + " / Registration id: " + dt.Rows[0]["Registration_ID"].ToString() + " / Farmer Name: " + lblfulname.Text;
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                imgBarCode.Height = 100;
                imgBarCode.Width = 100;
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] byteImage = ms.ToArray();
                        imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    }
                    plBarCode.Controls.Add(imgBarCode);
                }

                DataTable dtLtype = clsdata.GetDataTable("select top 1* from dbo.Diesel_SubsidyApplyKharif202223LandDetails where application_id='" + applicationno + "'");

                DataSet DT1 = new DataSet();
                if (dtLtype.Rows[0]["LandType"].ToString() == "1")
                {
                    // PnlPersonal.Visible = true;
                    pnl2.Visible = false;
                    pnl1.Visible = true;
                    query1 = "select * from dbo.Diesel_SubsidyApplyKharif202223LandDetails where application_id='" + applicationno + "' and khatano is not null ";
                    SqlDataAdapter da = new SqlDataAdapter(query1, con);
                    da.Fill(DT1);
                    if (DT1.Tables.Count > 0)
                    {
                        Gridview1.DataSource = DT1.Tables[0];
                        Gridview1.DataBind();
                    }
                }
                if (dtLtype.Rows[0]["LandType"].ToString() == "2")
                {
                    //PnlPersonal.Visible = false;
                    //Panel2.Visible = true;
                    pnl2.Visible = true;
                    pnl1.Visible = false;
                    query1 = "select * from dbo.Diesel_SubsidyApplyKharif202223LandDetails where application_id='" + applicationno + "' and khatano is  null ";
                    SqlDataAdapter da = new SqlDataAdapter(query1, con);
                    da.Fill(DT1);
                    if (DT1.Tables.Count > 0)
                    {
                        Gridview2.DataSource = DT1.Tables[0];
                        Gridview2.DataBind();
                    }
                }
                if (dtLtype.Rows[0]["LandType"].ToString() == "3")
                {
                    pnl2.Visible = true;
                    pnl1.Visible = true;
                    query1 = "select * from dbo.Diesel_SubsidyApplyKharif202223LandDetails where application_id='" + applicationno + "' and khatano is  null ; select * from dbo.Diesel_SubsidyApplyKharif202223LandDetails where application_id='" + applicationno + "' and khatano is not null ";
                    SqlDataAdapter da = new SqlDataAdapter(query1, con);
                    da.Fill(DT1);
                    if (DT1.Tables.Count > 0)
                    {
                        Gridview2.DataSource = DT1.Tables[0];
                        Gridview2.DataBind();

                        Gridview1.DataSource = DT1.Tables[1];
                        Gridview1.DataBind();
                    }
                }
            }
        }
        catch (Exception ex) { }
        finally { }
    }
    public static string Decrypt(string encryptText)
    {
        string encryptionkey = "SAUW193BX628TD57";
        byte[] keybytes = Encoding.ASCII.GetBytes(encryptionkey.Length.ToString());
        RijndaelManaged rijndaelCipher = new RijndaelManaged();
        byte[] encryptedData = Convert.FromBase64String(encryptText.Replace(" ", "+"));// Encoding.ASCII.GetBytes(encryptText.Replace(" ", "+")); // Convert.FromBase64String(encryptText.Replace(" ", "+"));
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
}