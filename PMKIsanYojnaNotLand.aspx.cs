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
//using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml;
using ConnectPayment;
using System.Collections.Specialized;

public partial class PMKIsanYojna : System.Web.UI.Page
{
    //clsDataAccessPMKisan objCls = new clsDataAccessPMKisan();
    String path = "";
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    string Vleid = "";
    string csc = "";

    string IncId = "";
    string Aadharauth = "";
   
    public PMKIsanYojna()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Response.Write("VLEID:>>>>>>---->: "+ Request.Form["shj_vle_id"]);

        //ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Due to some technical work portal will be on hold..!!');window.location='https://dbtagriculture.bihar.gov.in';", true);
if(!IsPostBack)
        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopupnew();", true);
        // return;
         btnSendOtp.Visible = false;
        string timeIns = "09";
        string timelast = "17";
        string Instime = DateTime.Now.ToShortTimeString();
        DateTime myDate;
        //if (DateTime.TryParse(Instime, out myDate))
        //{
        //    string time = myDate.ToString("HH");
        //    if (Convert.ToInt16(time) >= Convert.ToInt16(timeIns) && Convert.ToInt16(time) <= Convert.ToInt16(timelast))
        //    {
        //        //ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('प्रिय किसान, 08 बजे से दोपहर 5:00 बजे तक PM Kisan आवेदन सत्यापन के लिये पंजीकरण एवं आवेदन बंद रहेगा | अन्य किसानो को भी सूचित करें|आदेशानुसार,कृषि विभाग!!');", true);
        //        // ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Due to some technical work portal will be on hold from 03:45 to 5:00 PM today only..!!');window.location='https://dbtagriculture.bihar.gov.in';", true);

        //    }
        //    else
        //    {
        //        ////ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('प्रिय किसान,पी० एम० किसान सम्मान निधि आवेदन  सुबह 9 बजे से   6 बजे तक होगी|  आदेशानुसार,कृषि विभाग!!'); window.location='https://dbtagriculture.bihar.gov.in';", true);
        //    }
        //}


        //string timeIns = "09";
        //  string timelast = "17";
        // string Instime = DateTime.Now.ToShortTimeString();
        // DateTime myDate;
        // if (DateTime.TryParse(Instime, out myDate))
        // {
        //    string time = myDate.ToString("HH");
        //   if (Convert.ToInt16(time) >= Convert.ToInt16(timeIns) && Convert.ToInt16(time) <= Convert.ToInt16(timelast))
        //    {
        //ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('प्रिय किसान, 08 बजे से दोपहर 5:00 बजे तक PM Kisan आवेदन सत्यापन के लिये पंजीकरण एवं आवेदन बंद रहेगा | अन्य किसानो को भी सूचित करें|आदेशानुसार,कृषि विभाग!!');", true);
        // ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Due to some technical work portal will be on hold from 03:45 to 5:00 PM today only..!!');window.location='https://dbtagriculture.bihar.gov.in';", true);

        // }
        //    else
        //  {
        //      ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('प्रिय किसान,कृषि इनपुट आवेदन सुबह 9 बजे से   6 बजे तक होगी|  आदेशानुसार,कृषि विभाग!!'); window.location='https://dbtagriculture.bihar.gov.in';", true);
        //  }
        // }

        //string timeIns = "15";
        //string timelast = "16";
        //string Instime = DateTime.Now.ToShortTimeString();

        //DateTime myDate;

        //if (DateTime.TryParse(Instime, out myDate))
        // {

        //  string time = myDate.ToString("HH");
        //  if (Convert.ToInt16(time) >= Convert.ToInt16(timeIns) && Convert.ToInt16(time) <= Convert.ToInt16(timelast))
        //  {
        //     ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('प्रिय किसान, 03 बजे से 5:00 बजे तक आवेदन बंद रहेगा | अन्य किसानो को भी सूचित करें|आदेशानुसार,कृषि विभाग!!');window.location='https://dbtagriculture.bihar.gov.in/HomePage.aspx';", true);
        //    return;
        // }
        //  }

        // Session["Connectdata"] = "500100100013";
        //result["User"]["csc_id"].Value;
        // string vleid = "1002011500000004";
        if (Request.Form["shj_vle_id"] != null || !string.IsNullOrEmpty(Request.Form["shj_vle_id"]))//(Request.Form["shj_vle_id"] != null || !string.IsNullOrEmpty(Request.Form["shj_vle_id"]))
        {
            //Vleid 
            Session["VID"] = Request.Form["shj_vle_id"];
            //IncId
            // Session["INC"] = Request.Form["shj_initn_id"];
            Vleid = Session["VID"].ToString();
            // IncId = Session["INC"].ToString();
            lblsessiondata.Text = "Welcome :<b> " + Vleid + "</b><br />"
                                + "SAHAJ Inc Id : " + IncId + "<br />";
            if (!string.IsNullOrEmpty(Vleid.ToString()))
            {
                //lblVle.Visible = true;
                //txtvleid.Text = Vleid;
                //txtvleid.Enabled = false;
                //txtvleid.Visible = true;
                lnkLogout.Text = "Logout";

            }
            else
            {
                lnkLogout.Text = "";
                //lblVle.Visible = false;
                // txtvleid.Text = "";
                //txtvleid.Enabled = false;
                // txtvleid.Visible = false;
                Response.Redirect("HomePage.aspx", false);
            }
        }
        if (!string.IsNullOrEmpty(Convert.ToString(Session["Connectdata"])))
        {
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(Session["Connectdata"].ToString().Trim());
            string StateCode = result["User"]["state_code"].Value;
            if (StateCode == "BR")
            {
                lblsessiondata.Text = "Welcome :<b> " + result["User"]["username"].Value + "</b><br />"
                                     + "CSC Id : " + result["User"]["csc_id"].Value + "<br />"
                                     + "Type : " + result["User"]["user_type"].Value + "<br />"
                  + "last_active : " + result["User"]["last_active"].Value + "<br />"
                                    ;
                Session["usernameCSC"] = result["User"]["csc_id"].Value;
                lblsessiondata.Visible = true;

                csc = Session["usernameCSC"].ToString();
                if (!string.IsNullOrEmpty(Session["usernameCSC"].ToString()))
                {
                    //lnkLogout.Text = "Logout";
                }
                else
                {
                    Response.Redirect("https://dbtagriculture.bihar.gov.in/pmkisan", false);
                }
            }
            else
            {
                Session["Connectdata"] = "";
                Response.Write("<script language='javascript'>window.alert('This is Bihar State Specific service only................!!!!!!!');window.location='HomePage.aspx';</script>");
                return;
            }
        }
        //if (DateTime.Now.ToString("dd-MM-yyyy") == "21-02-2019")
        //{

        //    var parameterDate = DateTime.ParseExact("02/21/2019", "MM/dd/yyyy", CultureInfo.InvariantCulture);
        //    var todaysDate = DateTime.Today;
        //    if (todaysDate <= parameterDate)
        //    {
        //        ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('प्रिय कृषक, सूचित किया जाता है कि विभागीय आदेशानुसार पंजीकरण एवं आवेदन(PM-KISaan) सुबह 10 बजे तक होगा| सुबह 10:00 से रात के 08:00 बजे तक विभागीय कार्य के लिये बंद रहेगा|) |आदेशानुसार,कृषि विभाग !');window.location='HomePage.aspx';", true);
        //        return;
        //    }
        //}

        //  string timeIns = "14";
        // string timelast = "16";
        //string Instime = DateTime.Now.ToShortTimeString();

        //       DateTime myDate;

        //      if (DateTime.TryParse(Instime, out myDate))
        //     {

        //     string time = myDate.ToString("HH");
        //    if (Convert.ToInt16(time) >= Convert.ToInt16(timeIns) && Convert.ToInt16(time) <= Convert.ToInt16(timelast))
        //  {
        //ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('प्रिय किसान,दोपहर 02 बजे से 4:00 बजे तक तकनिकी रखरखाव के लिये  पंजीकरण एवं आवेदन बंद रहेगा | अन्य किसानो को भी सूचित करें|आदेशानुसार,कृषि विभाग!!');window.location='https://dbtagriculture.bihar.gov.in/Home.aspx';", true);
        //return;
        //}
        //}

        if (!Page.IsPostBack)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["Connectdata"])))//Session["VID"]//&& string.IsNullOrEmpty(Convert.ToString(Session["VID"]))
            {
                //   this.ModalPopupExtender1.Show();
            }
            else if (string.IsNullOrEmpty(Convert.ToString(Session["VID"])))
            {
                //    this.ModalPopupExtender1.Show();
            }
            SetInitialRow();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {


        if (string.IsNullOrEmpty(TextBox1.Text))
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('कृपया सही पंजीकरण संख्या की प्रवष्टि करें !!!!!!!!!!! ');", true);
            return;
        }

        try
        {

            DataTable dtt = cls.GetDataTable("Select * from Registration_PMKISAN where Registration_ID='" + TextBox1.Text.Trim() + "'");

            if (dtt.Rows.Count > 0)
            {

                //if (dtt.Rows[0]["Status"].ToString() == "2")
                //{
                //    TextBox1.Text = "";
                //    // Response.Write("<script language='javascript'>window.alert('प्रिय किसान,आपका पंजीकरण बृहत किसान के लिये किया गया है इसलिए आप इस योजना के लिये योग्य नहीं है ..... !!!!!!!!!!');window.location='PMKisanYojan.aspx';</script>");
                //    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('प्रिय किसान, आवेदन में आपके द्वारा दिये गये कुल खेती योग्य आपके हिस्से का रकवा 2 हेक्टेयर/5 एकड़/495 डिसिमिल से ज्यादा है, इसलिए आप इस योजना के योग्य  नहीं है| आपका आवेदन रद्द कर दिया गया है |');", true);
                //    return;
                //}
                //else
                //{
                //TextBox1.Text = "";
                //  Response.Write("<script language='javascript'>window.alert('प्रिय किसान,आप व्यस्क किसान नहीं है| आपकी उम्र अभी " + dt.Rows[0]["fage"].ToString() + " साल है, इसलिए आप इस योजना के लिये योग्य नहीं है   ... !!!!!!!!!!');window.location='PMKisanYojan.aspx';</script>");
                //ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आप आवेदन कर चुके है .. ...  !!!!!!!!!!! ');", true);
                // Response.Redirect("PmkisanYojan.aspx");
                //return;
                //}
            }

            DataTable dt = cls.GetDataTable("Select *, DATEDIFF(YEAR,  convert(char(11), DOB,106), GETDATE())  fage from Registration where registration_id='" + TextBox1.Text.Trim() + "'");

            if (dt.Rows.Count > 0)
            {
                //if (Convert.ToInt16(dt.Rows[0]["fage"].ToString()) < 18)
                //{
                //    TextBox1.Text = "";
                //    //  Response.Write("<script language='javascript'>window.alert('प्रिय किसान,आप व्यस्क किसान नहीं है| आपकी उम्र अभी " + dt.Rows[0]["fage"].ToString() + " साल है, इसलिए आप इस योजना के लिये योग्य नहीं है   ... !!!!!!!!!!');window.location='PMKisanYojan.aspx';</script>");
                //    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आप व्यस्क किसान नहीं है| आपकी उम्र अभी " + dt.Rows[0]["fage"].ToString() + " साल है, इसलिए आप इस योजना के लिये योग्य नहीं है   ...  !!!!!!!!!!! ');", true);
                //    // Response.Redirect("PmkisanYojan.aspx");
                //    return;
                //}
                DateTime d = Convert.ToDateTime("01-Jan-2019");
                if (Convert.ToDateTime(dt.Rows[0]["DOB"]) > d)
                {
                    TextBox1.Text = "";
                    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आपकी जन्म तिथि " + "01-Jan-2019" + " के बाद है, इसलिए आप इस योजना के लिये योग्य नहीं है   ...  !!!!!!!!!!! ');", true);

                    return;
                }
                //if (dt.Rows[0]["Farmertype"].ToString() == "बृहत किसान")
                //{
                //    TextBox1.Text = "";
                //    // Response.Write("<script language='javascript'>window.alert('प्रिय किसान,आपका पंजीकरण बृहत किसान के लिये किया गया है इसलिए आप इस योजना के लिये योग्य नहीं है ..... !!!!!!!!!!');window.location='PMKisanYojan.aspx';</script>");
                //    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आपका पंजीकरण बृहत किसान के लिये किया गया है इसलिए आप इस योजना के लिये योग्य नहीं है ...  !!!!!!!!!!! ');", true);
                //    return;
                //}
                else
                {
                    pnlInc.Visible = false;
                    FillDetails(TextBox1.Text.Trim());
                    FillData();
                }

            }
            else
            {

                //Button1.Enabled = true;
                //TextBox2.Visible = false;
                //Button2.Visible = false;
                //LinkButton2.Visible = false;
                //Button3.Visible = false;
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आपका पंजीकरण सख्या गलत है ...  !!!!!!!!!!! ');", true);
                return;
            }


        }
        catch
        { }
        finally { con.Close(); }

    }
    protected void FillDetails(string appid)
    {
        try
        {
            
            string query = "";
            query = @"SELECT top 1   Registration.Registration_ID,   Registration.BankName, Registration.AccountNumber,Registration.IFSC_Code, Registration.Farmer_FName, Registration.Farmer_LName,
                Registration.Father_Husband_Name, Registration.DOB, Registration.Gender, Registration.CastCateogary, Registration.MobileNumber, Registration.Totalage, Registration.AadhaarNumber,
                Registration.Farmertype,Districts.DistName, Blocks.BlockName, Panchayat.PanchayatName, Registration.villagecode, case when Registration.villagecode='99' then Registration.VillNAme else   v.villname end villname, Registration.DistrictCode, datediff(year,convert(char(11), Registration.DOB,106), GETDATE())  fage ,
                Registration.BlockCode, Registration.PanchayatCode FROM  Registration inner join
                Districts ON Registration.DistrictCode = Districts.DistCode inner join
                Blocks ON Registration.BlockCode = Blocks.BlockCode inner join
                Panchayat ON Registration.PanchayatCode = Panchayat.PanchayatCode 
                left outer join village v on v.villcode=Registration.villagecode
                where Registration.Registration_ID='" + appid + "'";
            DataTable dt = new DataTable();// cls.GetDataTable(query);
            SqlDataAdapter chkadpp = new SqlDataAdapter();
            cmd.Connection = con;
            cmd.CommandText = query;
            chkadpp.SelectCommand = cmd;
            chkadpp.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                pnlBody.Visible = true;
                //Panel1.Visible = true;
                // Panel3.Visible = true;
                //Panel2.Visible = true;
                // PnlFinal.Visible = true;
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
                if (dt.Rows[0]["villagecode"].ToString() == "99")
                {
                    lblVill.Visible = false;
                    lblVill.Text = "";
                    DropDownList1.Visible = true;
                    fillVillgage(dt.Rows[0]["BlockCode"].ToString());
                }
                else
                {
                    lblVill.Visible = true;
                    DropDownList1.Visible = false;
                    lblVill.Text = dt.Rows[0]["villname"].ToString();
                }
                lblBank.Text = dt.Rows[0]["BankName"].ToString();
                lblAcIfc.Text = dt.Rows[0]["AccountNumber"].ToString();
                lblIFSCCode.Text = dt.Rows[0]["IFSC_Code"].ToString();


                ViewState["DistCode"] = dt.Rows[0]["DistrictCode"].ToString();
                ViewState["BlockCode"] = dt.Rows[0]["BlockCode"].ToString();
                ViewState["PanchayatCode"] = dt.Rows[0]["PanchayatCode"].ToString();
                ViewState["villagecode"] = dt.Rows[0]["villagecode"].ToString();
                //BindLandDistrict();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आपका पंजीकरण संख्या गलत है ... | !!!!!!!!!!! ');", true);
            }
        }
        catch (Exception ex)
        { }
        finally { }
    }
    protected void fillVillgage(string blockcode)
    {
        string query = "select VILLCODE, VILLNAME  from Village where BLOCKCODE ='" + blockcode + "'";
        DataTable dtVill = cls.GetDataTable(query);
        if (dtVill.Rows.Count > 0)
        {
            DropDownList1.DataSource = dtVill;
            DropDownList1.DataTextField = "VILLNAME";
            DropDownList1.DataValueField = "VILLCODE";

            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("--चयन करें--", "0"));
        }

    }

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dt.Columns.Add(new DataColumn("Column6", typeof(string)));
        dt.Columns.Add(new DataColumn("Column7", typeof(string)));
        dr = dt.NewRow();
        // dr["RowNumber"] = 1;
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
        dr["Column5"] = string.Empty;
        dr["Column6"] = string.Empty;
        dr["Column7"] = string.Empty;
        dt.Rows.Add(dr);
        //dr = dt.NewRow();

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        Gridview1.DataSource = dt;
        Gridview1.DataBind();
    }


    private void AddNewRowToGrid()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            lblCalculate.Visible = true;
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    DropDownList box5 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddldist");
                    DropDownList box6 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlBlock");
                    //extract the TextBox values
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt1");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt2");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt3");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt4");
                    TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt5");

                    if (string.IsNullOrEmpty(box1.Text))
                    {
                        lblCalculate.Text = "कृपया थाना नंबर की प्रविष्टि करें | ....";
                        box1.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(box2.Text))
                    {
                        lblCalculate.Text = "कृपया खाता नंबर की प्रविष्टि करें | ....";
                        box2.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(box3.Text))
                    {
                        lblCalculate.Text = "कृपया खेसरा नंबर की प्रविष्टि करें | ....";
                        box2.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(box4.Text))
                    {
                        lblCalculate.Text = "कृपया रकबा(डिसमिल में) का हिस्सा की प्रविष्टि करें | ....";
                        box2.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(box7.Text))
                    {
                        lblCalculate.Text = "कृपया रकबा(डिसमिल में)  की प्रविष्टि करें | ....";
                        box2.Focus();
                        return;
                    }
                    if (box5.SelectedValue == "0")
                    {
                        lblCalculate.Text = "कृपया जिला की प्रविष्टि करें | ....";
                        box3.Focus();
                        return;
                    }
                    if (box6.SelectedValue == "0")
                    {
                        lblCalculate.Text = "कृपया प्रखंड की प्रविष्टि करें | ....";
                        box3.Focus();
                        return;
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    lblCalculate.Text = "";
                    // drCurrentRow["RowNumber"] = i + 1;
                    drCurrentRow["Column1"] = box5.Text;
                    drCurrentRow["Column2"] = box6.Text;
                    drCurrentRow["Column3"] = box1.Text;
                    drCurrentRow["Column4"] = box2.Text;
                    drCurrentRow["Column5"] = box3.Text;
                    drCurrentRow["Column7"] = box4.Text;
                    drCurrentRow["Column6"] = box7.Text;

                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                Gridview1.DataSource = dtCurrentTable;
                Gridview1.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetPreviousData();
    }


    //===============================================

    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    DropDownList box5 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddldist");
                    DropDownList box6 = (DropDownList)Gridview1.Rows[rowIndex].Cells[2].FindControl("ddlBlock");
                    //extract the TextBox values
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt1");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt2");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt3");
                    TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt4");
                    TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt5");
                    box5.Text = dt.Rows[i]["Column1"].ToString();
                    box6.Text = dt.Rows[i]["Column2"].ToString();
                    box1.Text = dt.Rows[i]["Column3"].ToString();
                    box2.Text = dt.Rows[i]["Column4"].ToString();
                    box3.Text = dt.Rows[i]["Column5"].ToString();
                    box4.Text = dt.Rows[i]["Column7"].ToString();
                    box7.Text = dt.Rows[i]["Column6"].ToString();

                    rowIndex++;

                }
            }
            // ViewState["CurrentTable"] = dt;

        }
    }


    //===============================================
    protected void Gridview1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1S");
            if (lb != null)
            {
                if (dt.Rows.Count > 1)
                {
                    if (e.Row.RowIndex == dt.Rows.Count - 1)
                    {
                        lb.Visible = false;
                    }
                }
                else
                {
                    lb.Visible = false;
                }
            }
        }
    }


    protected void LinkButton1S_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        int rowID = gvRow.RowIndex + 1;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    //Remove the Selected Row data
                    dt.Rows.Remove(dt.Rows[rowID]);
                }
            }
            //Store the current data in ViewState for future reference
            ViewState["CurrentTable"] = dt;
            //Re bind the GridView for the updated data
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }

        //Set Previous Data on Postbacks
        SetPreviousData();
    }

    //=================Remove Row for family member ==================

    //================================================================

    // Verify OTP and Check Aadhaar ===================================
    protected void txtAadhaarR_OnTextChanged(object sender, EventArgs e)
    {
        try
        {



            string qry = "Select * from PMKisan_FamilyMemberDetailAadharInfo where AadhaarNo_FamilyMember='" + txtAadhaarR.Text.Trim() + "'";
            DataTable dtUID = new DataTable();
            SqlDataAdapter chkadpp = new SqlDataAdapter();
            cmd.Connection = con;
            cmd.CommandText = qry;
            chkadpp.SelectCommand = cmd;
            chkadpp.Fill(dtUID);

            if (dtUID.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आपके द्वारा दिया गया आधार पहले से लाभान्वित है। जिनका नाम  " + dtUID.Rows[0]["Name_FamilyMember"].ToString() + " है, इसलिए आप इस योजना के लिये योग्य नहीं है   ...  !!!!!!!!!!! ');", true);
                return;
            }

            else
            {
                string CheckDigit = VerhoeffCheckDigitLibrary.VerhoeffCheckDigit.CalculateCheckDigit(txtAadhaarR.Text.Substring(0, 11)).ToString();
                if (txtAadhaarR.Text.Substring(11, 1) != CheckDigit)
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('आपका आधार सख्या गलत है ...  !!!!!!!!!!!');", true);
                    txtAadhaarR.Focus();
                    return;
                }
                else
                {
                   // btnSendOtp.Visible = true;
                }

            }
        }
        catch
        {
        }
    }


    protected void btnSendOtp_Click(object sender, EventArgs e)
    {
        //if (txtNameR.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया नाम की प्रविष्टि करें |  !!!!!!!!!!!');", true);
        //    txtNameR.Focus();
        //    return;
        //}
        //if (txtDobR.Text == "")
        //{
        //    ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया जन्म की तारीख की प्रविष्टि करें | ...  !!!!!!!!!!!');", true);
        //    txtDobR.Focus();
        //    return;
        //}
        //AadhaAuth uidAut = new AadhaAuth();

        //string otpSent = uidAut.AadharAuthentication(txtAadhaarR.Text.Trim(), txtNameR.Text.Trim());
        //if (otpSent == "SUCCESS")
        //{
        //    colOTP.Visible = true;
        //    btnVerifyOtp.Visible = true;
        //}
        //else
        //{
        //    colOTP.Visible = false;
        //    btnVerifyOtp.Visible = false;
        //    ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Resend OTP ...  !!!!!!!!!!!');", true);
        //    return;
        //}


    }
    protected void btnVerifyOtp_Click(object sender, EventArgs e)
    {
        // string txtno = Session["txtno"].ToString();
        //DataTable dt = cls.GetDataTable("Select * from AadhaarAuth_CSM where txt='" + txtno + "'");
        //string tno = dt.Rows[0]["Name_FamilyMember"].ToString();
        //if (tno == txtno)
        //{
        //    btnVerifyOtp.Enabled = false;
        //    txtAadhaarR.Enabled = false;
        //}

        // con.Open();
        //var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.39.207:8080/authekycp25/api/authenticate");
        //httpWebRequest.ContentType = "application/json";
        //httpWebRequest.Method = "POST";
        //  ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        //string txn1 = "";//DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.ToString("MM") + DateTime.Now.Day.ToString("00") + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + GetUniqueKey(20).ToUpper();
        //clsDataAccess cls = new clsDataAccess();
        //SqlDataAdapter daNew = new SqlDataAdapter("select top 1 * from AadhaarAuth_CSM where AADHARNO = '" + txtAadhaarR.Text.Trim() + "' order by slno desc", con);
        //DataTable dt = new DataTable();// --cls.GetDataTable("select top 1 * from AadhaarAuth_CSM where AADHARNO= '" + txtAadhaarR.Text.Trim() + "' order by slno desc ");
        //daNew.Fill(dt);
        //if (dt.Rows.Count > 0)
        //{
        //    txn1 = dt.Rows[0]["txt"].ToString(); ;
        //}
        //string otp = txtUIDOTP.Text.Trim();
        //string SubAua = "PDAGB22450";
        //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //{
        //    string json = "";
        //    json = new JavaScriptSerializer().Serialize(new
        //    {
        //        uid = txtAadhaarR.Text.Trim(),
        //        uidType = "A",
        //        consent = "Y",
        //        subAuaCode = SubAua,
        //        txn = txn1,
        //        isPI = "n",
        //        isBio = "n",
        //        isOTP = "y",
        //        bioType = "n",
        //        name = "n",
        //        rdInfo = "n",
        //        rdData = "n",
        //        otpValue = otp
        //    });

        //    streamWriter.Write(json);
        //    streamWriter.Flush();
        //    streamWriter.Close();
        //}
        //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //{
        //    var result = streamReader.ReadToEnd();
        //    List<url_details2> obj = json_deserialized(result);
        //    string ret = obj[0].ret;
        //    string status = obj[0].status;
        //    string error = obj[0].err;

        //    if (status == "SUCCESS")
        //    {
        //        ViewState["AdharAuth"] = "SUCCESS";
        //        btnVerifyOtp.Text= "SUCCESS";
        //    }
        //    else
        //    {
        //        // lblAadhaarMsg.Text = "ERROR CODE: " + error + ".... Please Try Again...";
        //        ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('ERROR CODE: " + error + ".... Please Try Again.....  !!!!!!!!!!!');", true);
        //        // ddlRelation.Focus();
        //        return;

        //    }

        //}
    }

    protected void ButtonAddR_Click(object sender, EventArgs e)
    {
        if (ddlRelation.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया सदस्य का संबंध की प्रविष्टि करें | ...  !!!!!!!!!!!');", true);
            ddlRelation.Focus();
            return;
        }
        if (ddlRelativeLive.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया जीवित/मृत की प्रविष्टि करें | ...  !!!!!!!!!!!');", true);
            ddlRelativeLive.Focus();
            return;
        }
        if (ddlRelativeLive.SelectedValue == "1")
        {
            if (txtAadhaarR.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया आधार की प्रविष्टि करें | ...  !!!!!!!!!!!');", true);
                txtAadhaarR.Focus();
                return;
            }
        }
        if (txtNameR.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया नाम की प्रविष्टि करें |  !!!!!!!!!!!');", true);
            txtNameR.Focus();
            return;
        }
        if (ddlRelativeLive.SelectedValue == "1")
        {
            if (txtDobR.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया जन्म की तारीख की प्रविष्टि करें | ...  !!!!!!!!!!!');", true);
                txtDobR.Focus();
                return;
            }
        }
        try
        {
            cmd.Parameters.Clear();
            con.Open();
            cmd.CommandText = @"insert into PMKisan_FamilyMemberDetailAadharInfo 
                        (RegistrationID, Member, Live, AadhaarNo_FamilyMember, Name_FamilyMember, DOB_FamilyMember
                        )values (@RegistrationID, @Member, @Live, @AadhaarNo_FamilyMember, @Name_FamilyMember, @DOB_FamilyMember) ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@RegistrationID", lblregistrationid.Text);
            cmd.Parameters.AddWithValue("@Member", ddlRelation.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Live", ddlRelativeLive.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@AadhaarNo_FamilyMember", txtAadhaarR.Text.Trim());
            cmd.Parameters.AddWithValue("@Name_FamilyMember", txtNameR.Text.Trim());
            cmd.Parameters.AddWithValue("@DOB_FamilyMember", txtDobR.Text.Trim());
            cmd.ExecuteNonQuery();
            txtAadhaarR.Text = "";
            txtNameR.Text = "";
            txtDobR.Text = "";
            ddlRelativeLive.SelectedValue = "0";
            ddlRelation.SelectedValue = "0";
            btnVerifyOtp.Text = "verify";
            colOTP.Visible = false;
            btnVerifyOtp.Visible = false;
            FillData();
            con.Close();
        }
        catch (Exception ee)
        { }
    }
    void FillData()
    {
        try
        {
            string query = "";
            query = @"SELECT RegistrationID,Member,Live, AadhaarNo_FamilyMember, Name_FamilyMember, DOB_FamilyMember from PMKisan_FamilyMemberDetailAadharInfo where RegistrationID='" + lblregistrationid.Text + "'";
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
            }
        }
        catch (Exception ee)
        { }
    }


    //=================================================================

    protected void Gridview2_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlDist = (e.Row.FindControl("ddldist") as DropDownList);
            DataTable dt = cls.GetDataTable("select distcode, distname from districts order by distname");
            ddlDist.DataSource = dt;
            ddlDist.DataTextField = "distname";
            ddlDist.DataValueField = "distcode";
            ddlDist.DataBind();
            ddlDist.Items.Insert(0, new ListItem("--Select --", "0"));
        }
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        ddldist_SelectedIndexChanged(sender, e);

    }


    protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetPreviousData();
        foreach (GridViewRow gr in Gridview1.Rows)
        {
            DropDownList DropDownList2 = (gr.FindControl("ddlBlock") as DropDownList);
            DropDownList DropDownList1 = (gr.FindControl("ddlDist") as DropDownList);

            DataTable dt = cls.GetDataTable("select BlockCode, BlockName from Blocks where distcode='" + DropDownList1.SelectedValue + "' order by Blockname");
            DropDownList2.DataSource = dt;
            DropDownList2.DataTextField = "BlockName";
            DropDownList2.DataValueField = "BlockCode";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, new ListItem("--Select --", "0"));

        }
    }
    protected void QtyChanged(object sender, EventArgs e)
    {
        Button btn = Gridview1.FooterRow.FindControl("ButtonAdd") as Button;
        Decimal i = 0;
        decimal xxx = 0;
        try
        {
            foreach (GridViewRow gr in Gridview1.Rows)
            {

                TextBox txt1 = (TextBox)gr.FindControl("txt4");
                TextBox txt5 = (TextBox)gr.FindControl("txt5");

                if (Convert.ToDecimal(txt1.Text.Trim()) > Convert.ToDecimal(txt5.Text.Trim()))
                {
                    lblCalculate.Text = "आपके हिस्से का रकवा, कुल रकवा से ज्यादा नहीं हो सकता ....!!!";
                    lblCalculate.Visible = true;
                    txt1.Text = "";
                    return;
                }

                xxx = xxx + Convert.ToDecimal(txt1.Text.Trim());

                //if (txt1.Text.Trim().Substring(0, 1) == "0" || txt1.Text.Trim().Substring(0, 1) == "." || txt1.Text.Trim().Substring(0, 2) == "0.")
                //{
                //    lblCalculate.Text = "Please Enter Correct Land Details..!!!";
                //    lblCalculate.Visible = true;
                //    return;
                //}

                if (txt1.Text.Trim() == "")
                {
                    lblCalculate.Text = "Please Enter Rakba..!!!";
                    lblCalculate.Visible = true;
                    txt1.Text = "0";
                    return;
                }

                decimal totalLand = xxx;

                //if (totalLand > 500)
                //{
                //    lblCalculate.Text = "आप के द्वारा दिया गया कुल जमीन " + totalLand + " डिसमिल  है | आप ५०० डिसिमिल से ज्यादा प्रविष्टि नहीं कर सकते है !!!";
                //    lblCalculate.Visible = true;
                //    btn.Enabled = false;
                //    txt1.Text = "";
                //    txt1.Focus();
                //    return;
                //}

                //else
                //{

                //    btn.Enabled = true;
                //}
            }
            lblCalculate.Text = "आवेदक के कुल रकवे का हिस्सा :" + xxx.ToString();
            // txtTotal.Text = xxx.ToString();
            ViewState["Rakwa"] = xxx.ToString();

        }

        catch (Exception ex)
        { }
        finally { }
    }


    // protected void lnk_Click(object sender, EventArgs e)
    // {
    // this.mp1.Show();
    //  }

    protected void ddlKisanType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlKisanType.SelectedValue == "2")
        {
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("insert into Registration_GairRayiyat(registrationID, KisanType) values (@registrationID, @KisanType) ", con);
                da.SelectCommand.Parameters.AddWithValue("@registrationID", lblregistrationid.Text.Trim());
                da.SelectCommand.Parameters.AddWithValue("@KisanType", ddlKisanType.SelectedValue);
                da.SelectCommand.ExecuteNonQuery();
                ddlKisanType.SelectedValue = "0";
                //Response.Write("<script language='javascript'>window.alert('प्रिय किसान,आप गैर-रैयत/बटाईदार/जोतदार किसान है इसलिए आप इस योजना के लिये योग्य नहीं है|.. ...  !!!!!!!!!!');window.location='PMKisanYojan.aspx';</script>");
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आप गैर-रैयत/बटाईदार/जोतदार किसान है इसलिए आप इस योजना के लिये योग्य नहीं है|.. ...  !!!!!!!!!!! ');", true);
                return;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आप गैर-रैयत/बटाईदार/जोतदार किसान है इसलिए आप इस योजना के लिये योग्य नहीं है|.. ...  !!!!!!!!!!! ');", true);
                return;
            }
            finally { con.Close(); }
        }
        if (ddlKisanType.SelectedValue == "0")
        {
            ddlKisanType.SelectedValue = "0";
            //Response.Write("<script language='javascript'>window.alert('प्रिय किसान,कृपया किसान के प्रकार का चयन करें .. ... . ...  !!!!!!!!!!');window.location='PMKisanYojan.aspx';</script>");
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('कृपया किसान के प्रकार का चयन करें .. ...  !!!!!!!!!!! ');", true);

            return;
        }
    }

    // protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    // {
    //  this.mp1.Show();
    //  }

    protected string Validate()
    {
        string msg = "";
        foreach (GridViewRow grd in Gridview1.Rows)
        {


            DropDownList box5 = (DropDownList)grd.FindControl("ddldist");
            DropDownList box6 = (DropDownList)grd.FindControl("ddlBlock");
            TextBox box1 = (TextBox)grd.FindControl("txt1");
            TextBox box2 = (TextBox)grd.FindControl("txt2");
            TextBox box3 = (TextBox)grd.FindControl("txt3");
            TextBox box4 = (TextBox)grd.FindControl("txt4");
            TextBox box7 = (TextBox)grd.FindControl("txt5");

            if (string.IsNullOrEmpty(box1.Text))
            {
                lblCalculate.Text = "कृपया थाना नंबर की प्रविष्टि करें | ....";
                box1.Focus();
                msg = "कृपया थाना नंबर की प्रविष्टि करें | ....";
                //return;
            }
            if (string.IsNullOrEmpty(box2.Text))
            {
                lblCalculate.Text = "कृपया खाता नंबर की प्रविष्टि करें | ....";
                msg = "कृपया खाता नंबर की प्रविष्टि करें | ....";
                box2.Focus();
                //return;
            }
            if (string.IsNullOrEmpty(box3.Text))
            {
                lblCalculate.Text = "कृपया खेसरा नंबर की प्रविष्टि करें | ....";
                msg = "कृपया खेसरा नंबर की प्रविष्टि करें | ....";
                box2.Focus();
                // return;
            }
            if (string.IsNullOrEmpty(box4.Text))
            {
                lblCalculate.Text = "कृपया रकबा(डिसमिल में) का हिस्सा की प्रविष्टि करें | ....";
                msg = "कृपया रकबा(डिसमिल में) का हिस्सा की प्रविष्टि करें | ....";
                box2.Focus();
                // return;
            }
            if (string.IsNullOrEmpty(box7.Text))
            {
                lblCalculate.Text = "कृपया रकबा(डिसमिल में)  की प्रविष्टि करें | ....";
                msg = "कृपया रकबा(डिसमिल में)  की प्रविष्टि करें | ....";
                box2.Focus();
                // return;
            }
            if (box5.SelectedValue == "0")
            {
                lblCalculate.Text = "कृपया जिला की प्रविष्टि करें | ....";
                msg = "कृपया जिला की प्रविष्टि करें | ....";
                box3.Focus();
                // return;
            }
            if (box6.SelectedValue == "0")
            {
                lblCalculate.Text = "कृपया प्रखंड की प्रविष्टि करें | ....";
                msg = "कृपया प्रखंड की प्रविष्टि करें | ....";
                box3.Focus();
                // return;
            }

        }
        // msg = lblCalculate.Text;
        return msg;
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DataTable dtOTP = cls.GetDataTable("Select top 1 *, DATEDIFF(SECOND, ActionDate, GETDATE()) ss  from ValidateOTP_Master where RegistrationId='" + TextBox1.Text.Trim() + "' order by slno desc");
        if (dtOTP.Rows.Count > 0)
        {
            // ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('OTP is not verified..Please try again  ........');", true);
            // return;
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('OTP is not verified..Please try again  ........');", true);
            return;
        }
        //------------------------------Reponcse-------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------

        DataTable dtt = cls.GetDataTable("Select * from Registration_PMKISAN where Registration_ID='" + TextBox1.Text.Trim() + "'");

        if (dtt.Rows.Count > 0)
        {
            //if (dtt.Rows[0]["Status"].ToString() == "2")
            //{
            //    TextBox1.Text = "";
            //    // Response.Write("<script language='javascript'>window.alert('प्रिय किसान,आपका पंजीकरण बृहत किसान के लिये किया गया है इसलिए आप इस योजना के लिये योग्य नहीं है ..... !!!!!!!!!!');window.location='PMKisanYojan.aspx';</script>");
            //    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('प्रिय किसान, आवेदन में आपके द्वारा दिये गये कुल खेती योग्य आपके हिस्से का रकवा 2 हेक्टेयर/5 एकड़/495 डिसिमिल से ज्यादा है, इसलिए आप इस योजना के योग्य  नहीं है| आपका आवेदन रद्द कर दिया गया है |');", true);
            //    return;
            //}
            //else
            //{
            TextBox1.Text = "";
            //  Response.Write("<script language='javascript'>window.alert('प्रिय किसान,आप व्यस्क किसान नहीं है| आपकी उम्र अभी " + dt.Rows[0]["fage"].ToString() + " साल है, इसलिए आप इस योजना के लिये योग्य नहीं है   ... !!!!!!!!!!');window.location='PMKisanYojan.aspx';</script>");
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आप आवेदन कर चुके है .. ...  !!!!!!!!!!! ');", true);
            // Response.Redirect("PmkisanYojan.aspx");
            return;
            //}
        }
        if (ViewState["villagecode"].ToString() == "99")
        {
            if (DropDownList1.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('कृपया आप अपना गाँव का चयन करें  ........');", true);
                return;
            }
        }
        if (ddlKisanType.SelectedValue == "0")
        {
            ddlKisanType.SelectedValue = "0";
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('कृपया किसान के प्रकार का चयन करें .. ...  !!!!!!!!!!! ');", true);
            return;
        }
        if (!string.IsNullOrEmpty(Validate()))
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('" + Validate() + " ');", true);
            return;
        }

        if (CheckBox1.Checked == false)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया शपथ पत्र का चिन्हित करें....');", true);
            return;
        }
        if (CheckBox2.Checked == false)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया शपथ पत्र का चिन्हित करें......');", true);
            return;
        }
        if (CheckBox3.Checked == false)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('कृपया शपथ पत्र का चिन्हित करें......');", true);
            return;
        }
        if (string.IsNullOrEmpty(TextBox1.Text))
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please enter Registration ID....');", true);
            return;
        }

        //LAD CERTIFICATE UPLOAD HERE................

        if (!FileUpload1.HasFile)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('कृपया भूमि का दस्तावेज/स्वघोषित भूमि दस्तावेज उपलोड करें   ........');", true);

            return;
        }

        String upLPC = Path.GetExtension(FileUpload1.FileName);

        if (upLPC.ToLower() != ".pdf" || (upLPC.ToUpper() != ".PDF"))
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Select Photo in PDF Format ...!...!!');", true);
            return;
        }
        int filesizeIdentity = FileUpload1.PostedFile.ContentLength;
        if (filesizeIdentity > (51200 * 10))
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Photo Size 150KB Exceed  ......!!');", true);
            return;
        }

        // String LPCDocument = "F:\\AgricultureDept\\AgricultureDept\\LPCPMKIsaan\\" + lblregistrationid.Text.Trim() + upLPC;
        // FileUpload1.SaveAs(LPCDocument);
        String LPCDocument = "~/LPCPMKIsaan/" + lblregistrationid.Text.Trim() + upLPC;
        FileUpload1.SaveAs(Server.MapPath(LPCDocument));
        path = LPCDocument;

        con.Open();
        DataTable dt = new DataTable();
        SqlTransaction sqlTran = con.BeginTransaction();
        SqlDataAdapter adp = new SqlDataAdapter();

        try
        {
            cmd = con.CreateCommand();
            cmd.Transaction = sqlTran;

            cmd.CommandText = @"insert  into Registration_PMKISAN
                    (Registration_ID, BankName, IFSC_Code, AccountNumber, FamerType, LandType,TotalRakwa,Status, ApplicantName, Distcode, districtname, BlockCode, blockname, MOBILENO, AadharCard,  PanchayatCode, panchayatname, VillCode,VillageName,LandPath,Father_Husband_Name)
                    values (@Registration_ID, @BankName,  @IFSC_Code, @AccountNumber, @FamerType, @LandType,@TotalRakwa,@Status, @ApplicantName, @Distcode, @districtname, @BlockCode, @blockname, @MOBILENO, @AadharCard,  @PanchayatCode, @panchayatname,@VillCode, @VillageName,@LandPath,@Father_Husband_Name)  ";

            cmd.Parameters.AddWithValue("@Registration_ID", lblregistrationid.Text.Trim());
            cmd.Parameters.AddWithValue("@BankName", lblBank.Text.Trim());
            cmd.Parameters.AddWithValue("@IFSC_Code", lblIFSCCode.Text.Trim());
            cmd.Parameters.AddWithValue("@AccountNumber", lblAcIfc.Text.Trim());
            cmd.Parameters.AddWithValue("@FamerType", lblfrmsrtype.Text);
            cmd.Parameters.AddWithValue("@LandType", ddlKisanType.SelectedValue);

            if (Convert.ToString(ViewState["Rakwa"]) != null || Convert.ToString(ViewState["Rakwa"]) != "")
            {
                cmd.Parameters.AddWithValue("@TotalRakwa", Convert.ToDecimal(ViewState["Rakwa"].ToString()));
                if (Convert.ToDecimal(ViewState["Rakwa"].ToString()) > 495)
                {
                    cmd.Parameters.AddWithValue("@Status", 2);
                }
                else
                {

                    cmd.Parameters.AddWithValue("@Status", 1);
                }
            }

            cmd.Parameters.AddWithValue("@ApplicantName", lblfulname.Text.Trim());
            cmd.Parameters.AddWithValue("@Distcode", ViewState["DistCode"].ToString().Trim());
            cmd.Parameters.AddWithValue("@districtname", lbldistname.Text.Trim());
            cmd.Parameters.AddWithValue("@BlockCode", ViewState["BlockCode"].ToString().Trim());
            cmd.Parameters.AddWithValue("@blockname", lblblockname.Text.Trim());
            cmd.Parameters.AddWithValue("@MOBILENO", lblmobile.Text.Trim());
            cmd.Parameters.AddWithValue("@AadharCard", lblaadaar.Text.Trim());
            cmd.Parameters.AddWithValue("@PanchayatCode", ViewState["PanchayatCode"].ToString().Trim());
            cmd.Parameters.AddWithValue("@panchayatname", lblPanchayat.Text.Trim());
            cmd.Parameters.AddWithValue("@VillCode", string.IsNullOrEmpty(lblVill.Text.Trim()) ? DropDownList1.SelectedValue : ViewState["villagecode"].ToString());
            //(DropDownList1.SelectedValue != "0") ? DropDownList1.SelectedValue : ViewState["villagecode"].ToString().Trim()
            cmd.Parameters.AddWithValue("@VillageName", string.IsNullOrEmpty(lblVill.Text.Trim()) ? DropDownList1.SelectedItem.Text : lblVill.Text.Trim());
            cmd.Parameters.AddWithValue("@LandPath", path);
            cmd.Parameters.AddWithValue("@Father_Husband_Name", lblfathername.Text.Trim());

            int result = 0;

            result = cmd.ExecuteNonQuery();
            if (result > 0)
            {

                foreach (GridViewRow grd in Gridview1.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"insert into Registration_PMKIsan_LandDetails
                                (RegistrationID, DistCode, BlockCode, Khatano, keshrano, thanano, rakwa, FarmingRakwa
                                )values (@RegistrationID, @DistCode, @BlockCode, @Khatano, @keshrano, @thanano, @rakwa, @FarmingRakwa) ";
                    cmd.CommandType = CommandType.Text;

                    TextBox box3 = (TextBox)grd.FindControl("txt1");
                    TextBox box1 = (TextBox)grd.FindControl("txt2");
                    TextBox box2 = (TextBox)grd.FindControl("txt3");
                    TextBox box4 = (TextBox)grd.FindControl("txt4");
                    TextBox box5 = (TextBox)grd.FindControl("txt5");
                    DropDownList ddlDist = (DropDownList)grd.FindControl("ddldist");
                    DropDownList ddlBlock = (DropDownList)grd.FindControl("ddlBlock");

                    cmd.Parameters.AddWithValue("@RegistrationID", lblregistrationid.Text);
                    cmd.Parameters.AddWithValue("@DistCode", ddlDist.SelectedValue);
                    cmd.Parameters.AddWithValue("@BlockCode", ddlBlock.SelectedValue);
                    cmd.Parameters.AddWithValue("@Khatano", box1.Text.Trim());
                    cmd.Parameters.AddWithValue("@keshrano", box2.Text.Trim());
                    cmd.Parameters.AddWithValue("@thanano", box3.Text.Trim());
                    cmd.Parameters.AddWithValue("@rakwa", Convert.ToDecimal(box5.Text.Trim()));
                    cmd.Parameters.AddWithValue("@FarmingRakwa", Convert.ToDecimal(box4.Text.Trim()));
                    cmd.ExecuteNonQuery();

                }

                foreach (GridViewRow grd in gvView.Rows)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"insert into PMKisan_FamilyMemberDetail 
                                (Registration_ID, Relation,RelativeLive, AadhaarNo_FamilyMember, Name_FamilyMember, DOB_FamilyMember
                                )values (@RegistrationID, @Relation,@RelativeLive, @AadhaarNo_FamilyMember, @Name_FamilyMember, @DOB_FamilyMember) ";
                    cmd.CommandType = CommandType.Text;

                    Label lblMember = (Label)grd.FindControl("lblMember");
                    Label lblMemberStatus = (Label)grd.FindControl("lblMemberStatus");
                    Label lblAadhaarNo = (Label)grd.FindControl("lblAadhaarNo");
                    Label lblName = (Label)grd.FindControl("lblName");
                    Label lblDOB = (Label)grd.FindControl("lblDOB");

                    cmd.Parameters.AddWithValue("@RegistrationID", lblregistrationid.Text);
                    cmd.Parameters.AddWithValue("@Relation", lblMember.Text);
                    cmd.Parameters.AddWithValue("@RelativeLive", lblMemberStatus.Text);
                    cmd.Parameters.AddWithValue("@AadhaarNo_FamilyMember", lblAadhaarNo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name_FamilyMember", lblName.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB_FamilyMember", lblDOB.Text.Trim());

                    cmd.ExecuteNonQuery();

                }

            }
            Session["Reg_ID"] = lblregistrationid.Text.Trim();
            Session["Uname"] = lblfulname.Text.Trim();

            cmd.Parameters.Clear();
            sqlTran.Commit();
            //ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Records Inserted Successfully....');", true);
            SMSHttpPostClient sms = new SMSHttpPostClient();
            //if (Convert.ToDecimal(ViewState["Rakwa"].ToString()) > 495)
            //{
            //    // lblMsgnew.Text = "प्रिय किसान '" + lblfulname.Text.Trim() + "' आवेदन में आपके द्वारा दिये गये कुल खेती योग्य आपके हिस्से का रकवा 2 हेक्टेयर/5 एकड़/500 डिसिमिल से ज्यादा है, इसलिए आप इस योजना के योग्य  नहीं है  |. ...  !!!!!!!!!!! ";
            //    //lblMsgnew.text
            //    Button2.Visible = true;
            //    TextBox1.Text = "";
            //    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('प्रिय किसान, आवेदन में आपके द्वारा दिये गये कुल खेती योग्य आपके हिस्से का रकवा 2 हेक्टेयर/5 एकड़/494.82 डिसिमिल से ज्यादा है, इसलिए आप इस योजना के योग्य  नहीं है|');", true);
            //    ViewState["Rakwa"] = "";
            //    // ViewState["OTP"] = "";
            //    sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", lblmobile.Text, "प्रिय किसान '" + lblfulname.Text.Trim() + "' आवेदन में आपके द्वारा दिये गये कुल खेती योग्य आपके हिस्से का रकवा 2 हेक्टेयर/5 एकड़/494.82 डिसिमिल से ज्यादा है, इसलिए आप इस योजना के योग्य  नहीं है  |", "35fc8f80-e0bc-469e-9a93-646d7d453552");
            //}
            //else
            //{
            Button2.Visible = true;
            // lblMsgnew.Text = "प्रिय किसान '" + lblfulname.Text.Trim() + "' आपका आवेदन स्वीकृत कर कृषि समन्वयक को सत्यापन के लिये भेजा जा रहा है | आपका पंजीकरण संख्या हीं आवेदन सख्या है कृपया इसे सुरक्षित रखे  !!!!!!!";
            TextBox1.Text = "";
            ViewState["Rakwa"] = "";
            //ViewState["OTP"] = "";

            if (string.IsNullOrEmpty(Convert.ToString(Session["Connectdata"])) && string.IsNullOrEmpty(lblsessiondata.Text.ToString()))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('प्रिय किसान आपका आवेदन स्वीकृत कर कृषि समन्वयक को सत्यापन के लिये भेजा जा रहा है | आपका पंजीकरण संख्या हीं आवेदन सख्या है कृपया इसे सुरक्षित रखे !!!!!!!!!!! ');", true);
                sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", lblmobile.Text, "प्रिय किसान '" + lblfulname.Text.Trim() + "' आपका आवेदन स्वीकृत कर सत्यापन के लिये भेजा जा रहा है |", "35fc8f80-e0bc-469e-9a93-646d7d453552");
                //Response.Redirect("ViewAppDocumentDiesel.aspx?REGID=" + Session["Reg_ID"].ToString() + "&Username=" + Session["Uname"].ToString().Trim() + "&Appno=" + App_ID.ToString().Trim(), false);
                //}
            }
            else if ((lblsessiondata.Text.ToString().Length > 22))
            {
                Response.Redirect("https://retail.sahaj.co.in/web/guest/commonthirdpartyurl?actionType=payment_BIHAR_DBT&service_provider_id=BIHAR_DBT&sm_id=" + Session["VID"].ToString() + "&thirdParty_unique_id=" + lblregistrationid.Text.Trim() + "&txn_amount=11.80");
            }
            else
            {
                PaymentCsc();
            }
        }
        catch (Exception ec) { }
        finally { con.Close(); }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PMKisanYojna.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Print_PMKisan.aspx?RegId=" + lblregistrationid.Text + " ");
    }
    public List<url_details2> json_deserialized(string jasoncoe)
    {
        string json = "[" + jasoncoe + "]";

        List<url_details2> items = new List<url_details2>();
        items = JsonConvert.DeserializeObject<List<url_details2>>(json);

        return items;
    }
    public int GenerateRandomNo()
    {
        int _min = 1111;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
    }

    //string numbers = "1234567890";
    //string characters = numbers;
    //characters += numbers;
    //int length = 4;
    //string otp = string.Empty;
    //for (int i = 0; i < length; i++)
    //{
    //    string character = string.Empty;
    //    do
    //    {
    //        int index = new Random().Next(0, characters.Length);
    //        character = characters.ToCharArray()[index].ToString();
    //    } while (otp.IndexOf(character) != -1);
    //    otp += character;
    //}
    //return otp;

    // }
    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DataTable dt = cls.GetDataTable("Select top 1 *, DATEDIFF(SECOND, ActionDate, GETDATE()) ss  from ValidateOTP_Master where RegistrationId='" + TextBox1.Text.Trim() + "' order by slno desc");
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToInt16(dt.Rows[0]["ss"].ToString()) > 60)
            {

                ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('OTP has expired. Please Re-send OTP.. !!!!!!!!!!!!!');", true);
                return;
            }
            string OTP = dt.Rows[0]["OTP"].ToString();
            if (OTP == TextBox2.Text.Trim())
            {

                pnlPayment.Visible = false;
                pnl1.Visible = false;
                pnlSubmit.Visible = true;
                TextBox2.Enabled = false;
                // Button2.Enabled = false;
                LinkButton2.Enabled = false;
                Button3.Enabled = false;
                lblMsgnew.Text = "";

            }
            else
            {
                pnlPayment.Visible = false;
                pnl1.Visible = true;
                pnlSubmit.Visible = false;
                TextBox2.Text = "";
                TextBox2.Enabled = true;
                //  Button2.Enabled = true;
                LinkButton2.Enabled = true;
                Button3.Enabled = true;
                lblMsgnew.Text = "Please Enter 4 Digit correct OTP.";
            }
        }
        else
        {
            lblMsgnew.Text = "OTP not generated....!!!";
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        try
        {
            int OTPNew = GenerateRandomNo();
            string MobilenO = lblmobile.Text.Trim();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("insert into ValidateOTP_Master(RegistrationId, MobileNo,OTP) values (@RegistrationId,@MobileNo, @OTP) ", con);
            da.SelectCommand.Parameters.AddWithValue("@RegistrationId", TextBox1.Text.Trim());
            da.SelectCommand.Parameters.AddWithValue("@MobileNo", MobilenO.Trim());
            da.SelectCommand.Parameters.AddWithValue("@OTP", OTPNew.ToString());
            da.SelectCommand.ExecuteNonQuery();
            SMSHttpPostClient otpmsg = new SMSHttpPostClient();
            otpmsg.sendOTPMSG("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", MobilenO, "Your One Time Password is=" + OTPNew, "35fc8f80-e0bc-469e-9a93-646d7d453552");
            Label2.Text = "4 Digit OTP send on Registrated Mobile No: " + "XXXXXX" + MobilenO.Substring(6, 4);
            TextBox2.Visible = true;
            //Button2.Visible = true;
            LinkButton2.Visible = true;
            Button3.Visible = true;
            Button1.Enabled = false;
        }
        catch { }
        finally { con.Close(); }
        //DataTable dt = cls.GetDataTable("Select top 1 * from ValidateOTP_Master where RegistrationId='" + TextBox1.Text.Trim() + "' order bu slno desc");
        //if (dt.Rows.Count > 0)
        //{
        //    string OTP = dt.Rows[0]["OTP"].ToString();
        //    string MobileNo = dt.Rows[0]["MobileNo"].ToString();
        //    SMSHttpPostClient otpmsg = new SMSHttpPostClient();
        //    otpmsg.sendOTPMSG("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", MobileNo, "Your One Time Password is=" + OTP, "35fc8f80-e0bc-469e-9a93-646d7d453552");
        //    lblMsgnew.Text = "4 Digit OTP send on Registrated Mobile No: " + "XXXXXX" + MobileNo.Substring(6, 4);
        //}
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string query = "select * from PMKisan_FamilyMemberDetailAadharInfo where registrationid='"+ lblregistrationid.Text.Trim()  +"'";
        DataTable dtReg = cls.GetDataTable(query);
        if (dtReg.Rows.Count > 0)
        {
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('कृपया परिवार का विवरण प्रविष्टि करें ...  !!!!!!!!!!! ');", true);
            return;
        }

        if (gvView.Rows.Count > 0)
        {

        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('कृपया परिवार का विवरण प्रविष्टि करें ...  !!!!!!!!!!! ');", true);
            return;
        }

        //DataTable dtPmkisn = cls.GetDataTable("Select * from Registration_PMKISAN p inner join Registration r on p.Registration_ID = r.Registration_ID   where r.AadhaarNumber = '" + txtAadhaarR.Text.Trim() + "'");
        //if (dtPmkisn.Rows.Count > 0)
        //{
        //    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('आपके द्वारा दिया गया आधार पहले से पीएम किसान निधि मे आवेदन किया गया है। इसलिए आप इस योजना के लिये योग्य नहीं है   ...  !!!!!!!!!!! ');", true);
        //    return;
        //}

        if (ViewState["villagecode"].ToString() == "99")
        {
            if (DropDownList1.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('कृपया आप अपना गाँव का चयन करें  ........');", true);
                return;
            }
        }

        try
        {
            int OTPNew = GenerateRandomNo();
            string MobilenO = lblmobile.Text.Trim();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("insert into ValidateOTP_Master(RegistrationId, MobileNo,OTP) values (@RegistrationId,@MobileNo, @OTP) ", con);
            da.SelectCommand.Parameters.AddWithValue("@RegistrationId", TextBox1.Text.Trim());
            da.SelectCommand.Parameters.AddWithValue("@MobileNo", MobilenO.Trim());
            da.SelectCommand.Parameters.AddWithValue("@OTP", OTPNew.ToString());
            da.SelectCommand.ExecuteNonQuery();
            SMSHttpPostClient otpmsg = new SMSHttpPostClient();
            otpmsg.sendOTPMSG("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", MobilenO, "Your One Time Password is=" + OTPNew, "35fc8f80-e0bc-469e-9a93-646d7d453552");
            Label2.Text = "4 Digit OTP send on Registrated Mobile No: " + "XXXXXX" + MobilenO.Substring(6, 4);
            TextBox2.Visible = true;
            //Button2.Visible = true;
            LinkButton2.Visible = true;
            Button3.Visible = true;
            Button1.Enabled = false;
        }
        catch { }
        finally { con.Close(); }
    }

    protected void LNLcsc_Click(object sender, ImageClickEventArgs e)
    {
        //  ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('Page is under construction.........');", true);
        //  return;
        // state = ConfigurationManager.AppSettings["merchant"] + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0') + "login.aspx";
        string stateID = GetUniqueKey(18);
        Session["state"] = stateID;
        string url = ConfigurationManager.AppSettings["CONNECT_SERVER_URI"] + ConfigurationManager.AppSettings["AUTHORIZATION_ENDPOINT"] + "?state=" + stateID + "&response_type=code&client_id=" + ConfigurationManager.AppSettings["CLIENT_ID"] + "&redirect_uri=" + ConfigurationManager.AppSettings["CLIENT_CALLBACK_URI"];
        Response.Redirect(url, false);

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
    protected void lnkLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("PMKisanYojna.aspx");
    }

    protected void btnFirstProduct_Click(object sender, EventArgs e)
    {
        //-------------------------------- CSC Wallet------------------------------------------------------------------------
        //SqlConnection con = null;
        //con = BTSPL.DBConnccection.GetConnection();
        // PaymentCsc();
    }

    protected void PaymentCsc()
    {
        NameValueCollection nvc = Request.Form;
        try
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["Connectdata"])))
            {

                SqlCommand cmd = null;
                cmd = con.CreateCommand();
                SqlTransaction trans = null;

                BridgePGUtil objBridgePGUtil = new BridgePGUtil();
                string merchant_id = ConfigurationManager.AppSettings["MERCHANT_ID"];
                string productid = ConfigurationManager.AppSettings["product_id1"];
                string productname = ConfigurationManager.AppSettings["product_name1"];
                string csc_id = Convert.ToString(Session["usernameCSC"]);//"500100100013"; // Pass The CSCID from digital seva connect 
                                                                         //  string csc_id = "577298060018"; // Pass The CSCID from digital seva connect 
                string txn_amount = "11.80";   //  Change the Amount value According 

                string merchant_receipt_no = merchant_id + DateTime.Now.Year.ToString().PadLeft(4, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.Millisecond.ToString().PadLeft(4, '0');
                string return_url = ConfigurationManager.AppSettings["SUCCESS_URL"];
                string cancel_url = ConfigurationManager.AppSettings["FAILURE_URL"];
                string regNo = GetUniqueKey(10);

                //Insert------------
                if (con.State == ConnectionState.Open)
                {
                    con.Close();

                }

                con.Open();
                trans = con.BeginTransaction();
                cmd.Transaction = trans;
                DateTime tn = DateTime.Now;
                string Trans = tn.ToFileTime().ToString();
                cmd.CommandText = "Insert_Tnx_Request";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@merchant_id", SqlDbType.VarChar).Value = Convert.ToString(ConfigurationManager.AppSettings["MERCHANT_ID"]);
                cmd.Parameters.AddWithValue("@csc_id", SqlDbType.VarChar).Value = Convert.ToString(Session["usernameCSC"]);
                cmd.Parameters.AddWithValue("@merchant_txn", SqlDbType.VarChar).Value = merchant_receipt_no;
                cmd.Parameters.AddWithValue("@txn_status", SqlDbType.VarChar).Value = "N";
                cmd.Parameters.AddWithValue("@product_id", SqlDbType.VarChar).Value = productid;
                cmd.Parameters.AddWithValue("@txn_amount", SqlDbType.Money).Value = txn_amount;
                cmd.Parameters.AddWithValue("@amount_parameter", SqlDbType.VarChar).Value = "NA";
                cmd.Parameters.AddWithValue("@txn_mode", SqlDbType.VarChar).Value = "D";
                cmd.Parameters.AddWithValue("@txn_type", SqlDbType.VarChar).Value = "D";
                cmd.Parameters.AddWithValue("@merchant_receipt_no", SqlDbType.VarChar).Value = merchant_id;
                cmd.Parameters.AddWithValue("@csc_share_amount", SqlDbType.VarChar).Value = "NA";
                cmd.Parameters.AddWithValue("@pay_to_email", SqlDbType.VarChar).Value = "NA";
                cmd.Parameters.AddWithValue("@Currency", SqlDbType.VarChar).Value = "INR";
                cmd.Parameters.AddWithValue("@Discount", SqlDbType.Money).Value = "0";
                cmd.Parameters.AddWithValue("@param_1", SqlDbType.VarChar).Value = lblregistrationid.Text.Trim();
                cmd.Parameters.AddWithValue("@param_2", SqlDbType.VarChar).Value = lblmobile.Text.Trim();
                cmd.Parameters.AddWithValue("@param_3", SqlDbType.VarChar).Value = lblname.Text.Trim();
                cmd.Parameters.AddWithValue("@param_4", SqlDbType.VarChar).Value = "NA";
                cmd.Parameters.AddWithValue("@txn_status_message", SqlDbType.VarChar).Value = "N";
                cmd.Parameters.AddWithValue("@status_message", SqlDbType.VarChar).Value = "N";
                cmd.Parameters.AddWithValue("@service_id", SqlDbType.VarChar).Value = "N";

                cmd.ExecuteNonQuery();
                trans.Commit();
                //--------------------
                string message = objBridgePGUtil.CreatePGData(merchant_id, csc_id, txn_amount, merchant_receipt_no, merchant_receipt_no, return_url, cancel_url, productid, productname, lblregistrationid.Text.Trim(), lblmobile.Text.Trim(), lblname.Text.Trim(), "", "0");
                message = ConfigurationManager.AppSettings["MERCHANT_ID"] + "|" + message;
                Response.Clear();
                StringBuilder sb = new StringBuilder();
                sb.Append("<html>");
                sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
                sb.AppendFormat("<form name='form' action='{0}' method='post'>", objBridgePGUtil.CreateURLappendString());
                sb.AppendFormat("<input type='hidden' name='message' value='{0}'>", message);
                // Other params go here
                sb.Append("</form>");
                sb.Append("</body>");
                sb.Append("</html>");
                Response.Write(sb.ToString());
                Response.End();
            }
        }
        catch (Exception ex)
        {

        }
        finally { con.Close(); }
    }






    protected void ddlMaritalstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRelation.Items.Clear();
        if (ddlMaritalstatus.SelectedValue == "2")
        {
            ddlRelation.Items.Insert(0, new ListItem("--Select --", "0"));
            ddlRelation.Items.Insert(1, new ListItem("माता", "1"));
            ddlRelation.Items.Insert(2, new ListItem("पिता", "2"));
        }
        if (ddlMaritalstatus.SelectedValue == "1")
        {
            ddlRelation.Items.Insert(0, new ListItem("--Select --", "0"));
            ddlRelation.Items.Insert(0, new ListItem("माता", "1"));
            ddlRelation.Items.Insert(0, new ListItem("पिता", "2"));
            ddlRelation.Items.Insert(0, new ListItem("पति/पत्नी", "3"));
            ddlRelation.Items.Insert(0, new ListItem("वयस्क बच्चे", "4"));
        }
    }

    protected void ddlRelativeLive_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRelativeLive.SelectedValue == "2")
        {
            btnSendOtp.Enabled = false;
            ButtonAddR.Visible = true;
            txtAadhaarR.Enabled = false;
            txtDobR.Enabled = false;
        }
        else
        {
            txtAadhaarR.Enabled = true;
            txtDobR.Enabled = true;
            //btnSendOtp.Enabled = true ;
        }
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




