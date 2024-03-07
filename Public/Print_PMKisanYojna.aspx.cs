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
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Threading;
using System.Globalization;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using esms_client;

public partial class Print_PMKisan : System.Web.UI.Page
{
    string Appid = "";
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
  clsDataAccessNew clsNew = new clsDataAccessNew();
    public Print_PMKisan()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["RegId"].ToString() != "" || Request.QueryString["RegId"].ToString() != null)
        //{
        //    Appid = Request.QueryString["RegId"].ToString();
        //    txtRno.Text = Appid;
        //}
        
        if (!Page.IsPostBack)
        {
            
            pnlBody.Visible = false;
            
        }

    }
    protected void FillDetails()
    {
       // try
       // {
            DataTable dtt = clsNew.GetDataTable("Select *,  N'रैयत किसान'  fMTYPE from Registration_PMKISAN_New where Registration_ID='" + Session["RegId"].ToString() + "'");

            if (dtt.Rows.Count > 0)
            {
                string query = "";
                if (rbApp.SelectedValue == "N")
                {
                    query = @"SELECT top 1   Registration.Registration_ID,   Registration.BankName, Registration.AccountNumber,Registration.IFSC_Code, Registration.Farmer_FName, Registration.Farmer_LName,
                            Registration.Father_Husband_Name, Registration.DOB, Registration.Gender, Registration.CastCateogary, Registration.MobileNumber, Registration.Totalage, Registration.AadhaarNumber,
                            Registration.Farmertype,Districts.DistName, Blocks.BlockName, Panchayat.PanchayatName, Registration.villagecode, 
                            case when  rp.VillCode is null then (case when Registration.villagecode='99' then Registration.VillNAme else   v.villname end) else rp.VillageName end villname, 
                            Registration.DistrictCode, datediff(year,convert(char(11), Registration.DOB,106), GETDATE())  fage ,
                            Registration.BlockCode, Registration.PanchayatCode FROM  Registration inner join
                            Registration_PMKISAN_New rp on rp.Registration_ID=Registration.Registration_ID inner join
                            Districts ON Registration.DistrictCode = Districts.DistCode inner join
                            Blocks ON Registration.BlockCode = Blocks.BlockCode inner join
                            Panchayat ON Registration.PanchayatCode = Panchayat.PanchayatCode 
                            left outer join village v on v.villcode=Registration.villagecode
                            where Registration.Registration_ID='" + Session["RegId"].ToString() + "'  and rp.ApplicationType='NEW'";
                }
                if (rbApp.SelectedValue == "RE")
                {
                    query = @"SELECT top 1   Registration.Registration_ID,   Registration.BankName, Registration.AccountNumber,Registration.IFSC_Code, Registration.Farmer_FName, Registration.Farmer_LName,
                            Registration.Father_Husband_Name, Registration.DOB, Registration.Gender, Registration.CastCateogary, Registration.MobileNumber, Registration.Totalage, Registration.AadhaarNumber,
                            Registration.Farmertype,Districts.DistName, Blocks.BlockName, Panchayat.PanchayatName, Registration.villagecode, 
                            case when  rp.VillCode is null then (case when Registration.villagecode='99' then Registration.VillNAme else   v.villname end) else rp.VillageName end villname, 
                            Registration.DistrictCode, datediff(year,convert(char(11), Registration.DOB,106), GETDATE())  fage ,
                            Registration.BlockCode, Registration.PanchayatCode FROM  Registration inner join
                            Registration_PMKISAN_New rp on rp.Registration_ID=Registration.Registration_ID inner join
                            Districts ON Registration.DistrictCode = Districts.DistCode inner join
                            Blocks ON Registration.BlockCode = Blocks.BlockCode inner join
                            Panchayat ON Registration.PanchayatCode = Panchayat.PanchayatCode 
                            left outer join village v on v.villcode=Registration.villagecode
                            where Registration.Registration_ID='" + Session["RegId"].ToString() + "'  and rp.ApplicationType='RECON'";
                }
                if (rbApp.SelectedValue == "RERE")
                {
                    query = @"SELECT top 1   Registration.Registration_ID,   Registration.BankName, Registration.AccountNumber,Registration.IFSC_Code, Registration.Farmer_FName, Registration.Farmer_LName,
                            Registration.Father_Husband_Name, Registration.DOB, Registration.Gender, Registration.CastCateogary, Registration.MobileNumber, Registration.Totalage, Registration.AadhaarNumber,
                            Registration.Farmertype,Districts.DistName, Blocks.BlockName, Panchayat.PanchayatName, Registration.villagecode, 
                            case when  rp.VillCode is null then (case when Registration.villagecode='99' then Registration.VillNAme else   v.villname end) else rp.VillageName end villname, 
                            Registration.DistrictCode, datediff(year,convert(char(11), Registration.DOB,106), GETDATE())  fage ,
                            Registration.BlockCode, Registration.PanchayatCode FROM  Registration inner join
                            Registration_PMKISAN_New rp on rp.Registration_ID=Registration.Registration_ID inner join
                            Districts ON Registration.DistrictCode = Districts.DistCode inner join
                            Blocks ON Registration.BlockCode = Blocks.BlockCode inner join
                            Panchayat ON Registration.PanchayatCode = Panchayat.PanchayatCode 
                            left outer join village v on v.villcode=Registration.villagecode
                            where Registration.Registration_ID='" + Session["RegId"].ToString() + "'   and rp.ApplicationType='RE-RECON'";
                }

                



                
                DataTable dt = new DataTable();
                SqlDataAdapter chkadpp = new SqlDataAdapter();
                cmd.Connection = con;
                cmd.CommandText = query;
                chkadpp.SelectCommand = cmd;
                chkadpp.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    pnlBody.Visible = true;
                    lblregistrationid.Text = dt.Rows[0]["Registration_ID"].ToString();
                    string fname = dt.Rows[0]["Farmer_FName"].ToString();
                    Session["FName"] = dt.Rows[0]["Farmer_FName"].ToString();
                    string lastname = dt.Rows[0]["Farmer_LName"].ToString();
                    lblfulname.Text = fname.ToString().Trim() + " " + lastname.ToString().Trim();
                    lblfathername.Text = dt.Rows[0]["Father_Husband_Name"].ToString();
                    lblfrmrdob.Text = dt.Rows[0]["DOB"].ToString();
                    lblttlage.Text = dt.Rows[0]["fage"].ToString();
                    lbldistname.Text = dt.Rows[0]["DistName"].ToString();
                    lblblockname.Text = dt.Rows[0]["BlockName"].ToString();


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
                    ddlKisanType.Text = dtt.Rows[0]["fMTYPE"].ToString();
                    string QUERY = @"select  [RegistrationID],(SELECT A.Dist_Name  FROM DistMaster_land A WHERE A.Dist_Code= r.DistCode)  as Dist_Name ,
(SELECT C.Circle_Name  FROM CircleMaster_Land C WHERE C.Circle_Code=r.Circle AND C.Dist_Code= r.DistCode) as Circle_Name, h.Halka_Name,
 m.Mauja_Name, 
[VolumeNo], [PageNo], [khata_no], [KhesraNo], [LandAker], [LandDismil], [OwnerName], [EntryDate]
from dbo.Registration_PMKIsan_LandDetails_New r 
inner join Halka_land h on h.Halka_Code=r.Halka AND   h.Circle_Code=r.Circle AND H.Dist_Code= r.DistCode
inner join Mauja_land m on m.Mauja_Code=r.Mauja AND   M.Circle_Code=r.Circle AND M.Dist_Code= r.DistCode
where r.RegistrationID='" + Session["RegId"].ToString()+ "'";

                    DataTable dtLand = clsNew.GetDataTable(QUERY);
                    if (dtLand.Rows.Count > 0)
                    {
                        grdLand.DataSource = dtLand;
                        grdLand.DataBind();
                    }

                    string QUERYFamily = @"SELECT Registration_ID,Relation,RelativeLive, '********'+RIGHT(AadhaarNo_FamilyMember,4) AadhaarNo_FamilyMember, Name_FamilyMember, DOB_FamilyMember from PMKisan_FamilyMemberDetail where Registration_ID='"+Session["RegId"].ToString() +"'";

                    DataTable dtFamily = clsNew.GetDataTable(QUERYFamily);
                    if (dtFamily.Rows.Count > 0)
                    {
                        gvFamilyView.DataSource = dtFamily;
                        gvFamilyView.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आपने आवेदन नहीं किया है... | !!!!!!!!!!! ');", true);
                }
                // }

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आपका पंजीकरण संख्या गलत है ... | !!!!!!!!!!! ');", true);
            }
        //}
       // catch (Exception ex)
       // { }
       // finally { }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (rbApp.SelectedValue == "" )
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आवेदन का प्रकार चुने  ... | !!!!!!!!!!! ');", true);
            return;
        }
       else if (Session["RegId"].ToString() == "" || string.IsNullOrEmpty(Session["RegId"].ToString()))
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('कृपया सही पंजीकरण संख्या की प्रवष्टि करें !!!!!!!!!!! ');", true);
            return;
        }
        else
        {
            FillDetails();
        }
    }

   
}