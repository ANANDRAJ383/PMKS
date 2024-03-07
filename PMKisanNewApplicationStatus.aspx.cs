﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PMKisanNewApplicationStatus : System.Web.UI.Page
{
   clsDataAccessNew clsNew = new clsDataAccessNew();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        lbl.Text = "";
        try
        {
            
            {
                string query = @"SELECT *,r.AccountNumber as acno,r.IFSC_Code as ifsc,r.VillageCode as villcode,isnull(p.Status,0) FMStatus,  isnull(AC_STATUS,0) a, isnull(DAO_STATUS,0) b, isnull(ADMR_STATUS,0) c, isnull(xmlstatus, 0) d, isnull(p.villcode,0) villcodeKK, r.VillageCode  ,  ADMR_ActionDate+2 as ADMR_ActionDate, XMLDate FROM registration_pmkisan p inner join registration r on r.registration_id=p.registration_id WHERE p.Registration_id='" + TextBox1.Text.Trim() + "'";
                DataTable dt = clsNew.GetDataTable(query);
                if (dt.Rows.Count > 0)
                {
                    pnlrecords.Visible = true; ;
                    //lbl.Text = dt.Rows[0]["FarmerName"].ToString();
                    ViewState["dc"] = dt.Rows[0]["DistCode"].ToString();
                    // Label5.Text = dt.Rows[0]["BDO_ApprovedAmt"].ToString();
                    string ACstatus = ""; string DAOstatus = ""; string ADMstatus = ""; string XMLStatus = "";
                    string aa = dt.Rows[0]["d"].ToString();
                    string StatuspM = dt.Rows[0]["FMStatus"].ToString();
                    ACstatus = dt.Rows[0]["a"].ToString();
                    DAOstatus = dt.Rows[0]["b"].ToString();
                    ADMstatus = dt.Rows[0]["c"].ToString();
                    XMLStatus = dt.Rows[0]["XMLStatus"].ToString();

                    if (string.IsNullOrEmpty(ACstatus) || ACstatus == "0")
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", अभी आपका आवेदन पंचायत स्तर पर सत्यापन के लिये दिनांक:-" + dt.Rows[0]["Entrydate"].ToString().Trim() + "  से लंबित है |";
                    }
                    else if (ACstatus == "1" && DAOstatus == "0" && ADMstatus == "0")
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन सक्षम प्राधिकार द्वारा पंचायत स्तर से (अंचल अधिकारी) को सत्यापन के लिये अग्रसारित कर दिया गया है |";
                    }
                    else if (ACstatus == "2")
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + " आपका आवेदन सक्षम प्राधिकार द्वारा पंचायत स्तर से रद्द कर दिया गया हैं |Remark: " + dt.Rows[0]["AC_Remarks"].ToString();
                    }

                    if (ACstatus == "1" && DAOstatus == "1" && ADMstatus == "0")
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ",  आपका आवेदन अंचल अधिकारी स्तर से जिला स्तर ADM(Revenue) को सत्यापन के लिये अग्रसारित कर दिया गया है | ";
                    }
                    else if (DAOstatus == "2")
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन अंचल अधिकारी स्तर से रद्द कर दिया गया हैं |Remark: " + dt.Rows[0]["DAO_Remarks"].ToString();
                    }
                    else if (DAOstatus == "1" && ADMstatus == "0")
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन ADM(Revenue) स्तर पर सत्यापन के लिये दिनांक:-" + dt.Rows[0]["dao_actiondate"] + "  से लंबित है|";
                    }
                    else if (ADMstatus == "2")
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन ADM(Revenue) स्तर से रद्द कर दिया गया हैं|Remark: " + dt.Rows[0]["ADMR_Remarks"].ToString();
                    }
                    if (ACstatus == "1" && DAOstatus == "1" && ADMstatus == "1" && aa == "0")
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन ADM(Revenue) स्तर से मुख्यालय स्तर को सत्यापन के लिये अग्रसारित कर दिया गया है |";

                    }
                    if (ACstatus == "1" && DAOstatus == "1" && ADMstatus == "1" && aa == "1")
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन मुख्यालय स्तर से भारत सरकार को दिनांक " + dt.Rows[0]["XMLDate"].ToString() + " को अग्रसारित कर दिया गया है| आगे की स्थिति जानने के लिये कृपया https://pmkisan.gov.in/BeneficiaryStatus.aspx लिंक देखें";
                    }

                    if (dt.Rows[0]["villcode"].ToString() == "99")
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन में गाँव का नाम सही नहीं रहने के कारण भारत सरकार को नहीं भेजा जा सकता है | कृपया इसे जल्द सुधार करे | सुधार करने हेतु विभाग के DBT PORTAL पर लिंक विवरण संशोधन उपलब्ध है | ";
                        return;
                    }

                    if (dt.Rows[0]["acno"].ToString().Length < 8)
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका बैंक खाता संख्या गलत पाया गया | कृपया इसे जल्द सुधार करे | सुधार करने हेतु विभाग के DBT PORTAL पर लिंक विवरण संशोधन उपलब्ध है | ";
                        return;
                    }
                    if (dt.Rows[0]["ifsc"].ToString().Length < 11)
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ",  आपका बैंक IFSC संख्या गलत पाया गया | कृपया इसे जल्द सुधार करे | सुधार करने हेतु विभाग के DBT PORTAL पर लिंक विवरण संशोधन उपलब्ध है | ";
                        return;
                    }
                    if (XMLStatus == "9")
                    {
                        lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन  कट-ऑफ दिनांक 01-फरवरी-2019 को 18 वर्ष से कम रहने के कारण आपका आवेदन  मुख्यालय स्तर से रद्द कर दिया गया है|";
                    }
                }
                else
                {
                    lbl.Text = "यह आवेदन संख्या से कोई आवेदन नहीं हुआ है या आवेदन संख्या गलत है |";
                }
            }
        }
        catch { }
    }
}