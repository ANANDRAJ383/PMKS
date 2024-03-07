﻿using System;
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

public partial class Print_PMKisan : System.Web.UI.Page
{
    string Appid = "";
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    public Print_PMKisan()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

        Appid = Request.QueryString["RegId"].ToString();
        if (!Page.IsPostBack)
        {
            pnlBody.Visible = false;
            FillDetails(Appid);
        }

    }
    protected void FillDetails(string appid)
    {
        try
        {
            DataTable dtt = cls.GetDataTable("Select *,  N'रैयत किसान'  fMTYPE from Registration_PMKISAN where Registration_ID='" + Appid + "'");

            if (dtt.Rows.Count > 0)
            {
                string query = "";
                if (dtt.Rows[0]["MobileNo"].ToString()=="1")
                {
                    query = @"SELECT top 1   Registration.Registration_ID,   Registration.BankName, Registration.AccountNumber,Registration.IFSC_Code, Registration.Farmer_FName, Registration.Farmer_LName,
                            Registration.Father_Husband_Name, Registration.DOB, Registration.Gender, Registration.CastCateogary, Registration.MobileNumber, Registration.Totalage, Registration.AadhaarNumber,
                            Registration.Farmertype,Districts.DistName, Blocks.BlockName, Panchayat.PanchayatName, Registration.villagecode, 
                            case when  rp.VillCode is null then (case when Registration.villagecode='99' then Registration.VillNAme else   v.villname end) else rp.VillageName end villname, 
                            Registration.DistrictCode, datediff(year,convert(char(11), Registration.DOB,106), GETDATE())  fage ,
                            Registration.BlockCode, Registration.PanchayatCode FROM  Registration inner join
                            Registration_PMKISAN rp on rp.Registration_ID=Registration.Registration_ID inner join
                            Districts ON Registration.DistrictCode = Districts.DistCode inner join
                            Blocks ON Registration.BlockCode = Blocks.BlockCode inner join
                            Panchayat ON Registration.PanchayatCode = Panchayat.PanchayatCode 
                            left outer join village v on v.villcode=Registration.villagecode
                            where Registration.Registration_ID='" + appid + "' and Reconsider = 1  and ADMR_Status = 2 and Re_Reconsider is null";

                }
                else
                {
                    query = @"SELECT top 1   Registration.Registration_ID,   Registration.BankName, Registration.AccountNumber,Registration.IFSC_Code, Registration.Farmer_FName, Registration.Farmer_LName,
                            Registration.Father_Husband_Name, Registration.DOB, Registration.Gender, Registration.CastCateogary, Registration.MobileNumber, Registration.Totalage, Registration.AadhaarNumber,
                            Registration.Farmertype,Districts.DistName, Blocks.BlockName, Panchayat.PanchayatName, Registration.villagecode, 
                            case when  rp.VillCode is null then (case when Registration.villagecode='99' then Registration.VillNAme else   v.villname end) else rp.VillageName end villname, 
                            Registration.DistrictCode, datediff(year,convert(char(11), Registration.DOB,106), GETDATE())  fage ,
                            Registration.BlockCode, Registration.PanchayatCode FROM  Registration inner join
                            Registration_PMKISAN rp on rp.Registration_ID=Registration.Registration_ID inner join
                            Districts ON Registration.DistrictCode = Districts.DistCode inner join
                            Blocks ON Registration.BlockCode = Blocks.BlockCode inner join
                            Panchayat ON Registration.PanchayatCode = Panchayat.PanchayatCode 
                            left outer join village v on v.villcode=Registration.villagecode
                            where Registration.Registration_ID='" + appid + "'";
                }

                pnlBody.Visible = true;
               
                
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
                    string QUERY = @"select [Slno], [RegistrationID], dl.Dist_Name, c.Circle_Name, h.Halka_Name, m.Mauja_Name, [VolumeNo], [PageNo], [khata_no], [KhesraNo], [LandAker], [LandDismil], [OwnerName], [EntryDate]
                                        from dbo.Registration_PMKIsan_LandDetails r 
                                        inner join DistMaster_land dl on dl.Dist_Code=r.DistCode
                                        inner join CircleMaster_Land c on c.Circle_Code=r.Circle
                                        inner join Halka_land h on h.Halka_Code=r.Halka
                                        inner join Mauja_land m on m.Mauja_Code=r.Mauja
                                        where r.RegistrationID='" + Appid + "'";

                    DataTable dtLand = cls.GetDataTable(QUERY);
                    if (dtLand.Rows.Count > 0)
                    {
                        grdLand.DataSource = dtLand;
                        grdLand.DataBind();
                    }

                    string QUERYFamily = @"SELECT RegistrationID,Member,Live, AadhaarNo_FamilyMember, Name_FamilyMember, DOB_FamilyMember from PMKisan_FamilyMemberDetailAadharInfo where RegistrationID='" + Appid + "'";

                    DataTable dtFamily = cls.GetDataTable(QUERYFamily);
                    if (dtFamily.Rows.Count > 0)
                    {
                        gvFamilyView.DataSource = dtLand;
                        gvFamilyView.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आपका पंजीकरण संख्या गलत है ... | !!!!!!!!!!! ');", true);
                }
                // }

            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आपने आवेदन नहीं किया है  ... | !!!!!!!!!!! ');", true);
            }
        }
        catch (Exception ex)
        { }
        finally { }
    }
}