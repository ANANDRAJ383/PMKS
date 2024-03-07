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
//using esms_client;
using QRCoder;
using System.Text.RegularExpressions;
using esms_client;

public partial class Print_Input202223Application : System.Web.UI.Page
{
    string Appid = "";
    SqlConnection con = new SqlConnection();
    SqlConnection conReg = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    public Print_Input202223Application()
    {
       // con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIIFlood"].ConnectionString;
        conReg.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIIReg"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Appid = Request.QueryString["RegId"].ToString();
        if (!Page.IsPostBack)
        {
            pnlBody.Visible = false;
FillData(Appid);
            FillDetails(Appid);
            
        }
    }
    protected void FillDetails(string appid)
    {
        try
        {
            pnlBody.Visible = true;
            string query = "";
            query = @"SELECT top 1   Registration.Registration_ID,   Registration.BankName, Registration.AccountNumber,Registration.IFSC_Code, Registration.Farmer_FName, Registration.Farmer_LName, rp.EntryDate, 
                        Registration.Father_Husband_Name, Registration.DOB, Registration.Gender, Registration.CastCateogary, Registration.MobileNumber, Registration.Totalage, Registration.AadhaarNumber,
                        Registration.Farmertype,Districts.DistName, Blocks.BlockName, Panchayat.PanchayatName, Registration.villagecode, 
                        case when  rp.VillCode is null then (case when Registration.villagecode='99' then Registration.VillNAme else   v.villname end) else rp.VillageName end villname, rp.TotalLand,rp.Application_ID,rp.TotalAffectedRakwa,rp.TotalSubsidy,
                        Registration.DistrictCode, datediff(year,convert(char(11), Registration.DOB,106), GETDATE())  fage ,
                        Registration.BlockCode, Registration.PanchayatCode FROM  [CLOUD009\AGRICULTUREDB].[KrishiDept].[dbo].Registration inner join
                        Input2223_OnlineApply rp on rp.Registration_ID=Registration.Registration_ID inner join
                        Districts ON Registration.DistrictCode = Districts.DistCode inner join
                        Blocks ON Registration.BlockCode = Blocks.BlockCode inner join
                        Panchayat ON Registration.PanchayatCode = Panchayat.PanchayatCode 
                        left outer join village v on v.villcode=Registration.villagecode
                        where Registration.Registration_ID='" + appid + "'";
            DataTable dt = new DataTable();// cls.GetDataTable(query);
            SqlDataAdapter chkadpp = new SqlDataAdapter();
            cmd.Connection = con;//con
            cmd.CommandText = query;
            chkadpp.SelectCommand = cmd;
            chkadpp.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                pnlBody.Visible = true;
                //Panel1.Visible = true;
                // Panel3.Visible = true;[CLOUD009\AGRICULTUREDB].[KrishiDept].[dbo].
                //Panel2.Visible = true;
                // PnlFinal.Visible = true;
                lblregistrationid.Text = dt.Rows[0]["Registration_ID"].ToString();
                lblApp.Text = dt.Rows[0]["Application_ID"].ToString();
                lblDicimil.Text = dt.Rows[0]["TotalAffectedRakwa"].ToString();
                lblAmount.Text = dt.Rows[0]["TotalSubsidy"].ToString();
                string fname = dt.Rows[0]["Farmer_FName"].ToString();
                Session["FName"] = dt.Rows[0]["Farmer_FName"].ToString();
                string lastname = dt.Rows[0]["Farmer_LName"].ToString();
                lblfulname.Text = fname.ToString().Trim() + " " + lastname.ToString().Trim();
                lblfathername.Text = dt.Rows[0]["Father_Husband_Name"].ToString();
                lblfrmrdob.Text = dt.Rows[0]["DOB"].ToString();
                lblttlage.Text = dt.Rows[0]["fage"].ToString();
                lbldistname.Text = dt.Rows[0]["DistName"].ToString();
                lblblockname.Text = dt.Rows[0]["BlockName"].ToString();
                lblDate.Text = dt.Rows[0]["EntryDate"].ToString();

                ddlKisanType.Text = dt.Rows[0]["TotalLand"].ToString() + " डिसमिल ";
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
                lblPanchayat.Text = dt.Rows[0]["PanchayatName"].ToString();
                lblVill.Text = dt.Rows[0]["villname"].ToString();
                lblBank.Text = dt.Rows[0]["BankName"].ToString();
                lblAcIfc.Text = dt.Rows[0]["AccountNumber"].ToString();
                lblIFSCCode.Text = dt.Rows[0]["IFSC_Code"].ToString();


                string QUERY = @"select  case when KisanType=1 then N'स्वयं' else N'वास्तविक खेतिहर' END KisanType,
                case when LandType=1 then N'सिंचित' else N'वर्षा आश्रित/असिंचित' END LandType,  
                case when CropType=1 then N'शाश्वत फसल गन्ना' when CropType=2 then N'गेंहूँ' when CropType=3 then N'रबी दलहन' when CropType=4 then N'रबी तेलहन' when CropType=5 then N'अन्य फसल' when CropType=6 then N'सब्जी' END CropType,                                              
                N'वर्षापात/ओलावृष्टि/आंधी तूफान' AS AffectedType, Khatano, keshrano, thanano, FarmingRakwa,Affectedrakwa, AnudanAmount, FName, SName, EntryDate from dbo.Input2223_LandDetails r where RegistrationID='" + appid + "'";

                DataTable dtLand = cls.GetDataTable(QUERY);
                if (dtLand.Rows.Count > 0)
                {
                    grd1.DataSource = dtLand;
                    grd1.DataBind();
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आपका पंजीकरण संख्या गलत है ... | !!!!!!!!!!! ');", true);
            }
            // }

            // }


        }
        catch (Exception ex)
        { }
        finally { }
    }
    void FillData(string appid)
    {
        try
        {
            string query = "";
            query = @"SELECT RegistrationID,Member,Live,  substring(AadhaarNo_FamilyMember,1,4)+ ' XXXX ' +substring(AadhaarNo_FamilyMember,9,12)  AS Addhar, Name_FamilyMember, DOB_FamilyMember from Input2223_FamilyMemberDetailAadharInfo where RegistrationID='" + appid + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter chkadpp = new SqlDataAdapter();
            cmd.Connection = con;
            cmd.CommandText = query;
            chkadpp.SelectCommand = cmd;
            chkadpp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvView.DataSource = dt;
                gvView.DataBind();
                gvView.Visible = true;
            }
            else
            {
                gvView.Visible = false;
            }
        }
        catch (Exception ee)
        { }
    }
 public void WinOpen1(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=1100,height=750,toolbar=0,addressbar =0, scrollbars=yes');", msg);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "strScript", strScript, true);
        }
        catch (Exception ex) { }
    }
 protected void imgbtnpreview_Click(object sender, ImageClickEventArgs e)
    {
        
        string query = "";

        query = "select LandPath from Input2223_OnlineApply where Registration_id='" + Appid + "' order by slno desc";

        string Filepath = "";
        DataTable dtDownload = cls.GetDataTable(query);
        if (dtDownload.Rows.Count > 0)
        {
            Filepath = dtDownload.Rows[0]["LandPath"].ToString();
        }
        WinOpen1(Filepath.Replace("~/", ""));
    }
}