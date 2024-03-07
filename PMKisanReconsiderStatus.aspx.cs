using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PMKisanReconsiderStatus : System.Web.UI.Page
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

            string query = @"SELECT * ,isnull(Re_CO_STATUS,0) b, isnull(Re_ADMR_STATUS,0)c FROM registration_pmkisan p inner join registration r on r.registration_id=p.registration_id
                                     WHERE p.Registration_id='" + TextBox1.Text.Trim() + "' and reconsider=1";
            DataTable dt = clsNew.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                pnlrecords.Visible = true; ;

                ViewState["dc"] = dt.Rows[0]["DistCode"].ToString();

                string DAOstatus = ""; string ADMstatus = ""; string XMLStatus = "";
                string ac = ""; string dao = ""; string adm = "";
                Label1.Text = dt.Rows[0]["ReconsiderID"].ToString();
                ac = dt.Rows[0]["ac_status"].ToString();
                dao = dt.Rows[0]["DAO_Status"].ToString();
                adm = dt.Rows[0]["ADMR_Status"].ToString();
                Label2.Text = dt.Rows[0]["ApplicantName"].ToString();
                DAOstatus = dt.Rows[0]["b"].ToString();
                ADMstatus = dt.Rows[0]["c"].ToString();
                XMLStatus = dt.Rows[0]["XMLStatus"].ToString();

                if (DAOstatus == "0" && ADMstatus == "0" && ac == "2")
                {
                    lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ",  आपका आवेदन जिला कृषि पदाधिकारी के पास लंबित है| ";
                }
                if (DAOstatus == "0" && ADMstatus == "0" && (dao == "2" || adm == "2"))
                {
                    lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ",  आपका आवेदन  ADM(Revenue) के पास लंबित है| ";
                }
                if (DAOstatus == "1" && ADMstatus == "0")
                {
                    lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ",  आपका आवेदन जिला कृषि पदाधिकारी से जिला स्तर ADM(Revenue) को अग्रसारित कर दिया गया है | ";
                }
                if (DAOstatus == "0" && ADMstatus == "1")
                {
                    lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन ADM(Revenue) स्तर से मुख्यालय स्तर को अग्रसारित कर दिया गया है |";
                }
                else if (DAOstatus == "2")
                {
                    lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन जिला कृषि पदाधिकारी स्तर से रद्द कर दिया गया हैं |Remark: " + dt.Rows[0]["Re_CO_Comment"].ToString();
                }
                else if (DAOstatus == "1" && ADMstatus == "0")
                {
                    lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन ADM(Revenue) स्तर पर लंबित है|";
                }
                else if (ADMstatus == "2")
                {
                    lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन ADM(Revenue) स्तर से रद्द कर दिया गया हैं |Remark: " + dt.Rows[0]["Re_ADMR_Comment"].ToString();
                }
                if (DAOstatus == "1" && ADMstatus == "1")
                {
                    lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन ADM(Revenue) स्तर से मुख्यालय स्तर को अग्रसारित कर दिया गया है |";

                }
                if ((DAOstatus == "1" || DAOstatus == "0") && ADMstatus == "1" && XMLStatus == "1")
                {
                    lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन मुख्यालय स्तर से भारत सरकार को दिनांक " + dt.Rows[0]["XMLDate"].ToString() + " को अग्रसारित कर दिया गया है |";
                }
                if (XMLStatus == "9")
                {
                    lbl.Text = dt.Rows[0]["ApplicantName"].ToString() + ", आपका आवेदन  कट-ऑफ दिनांक 01-फरवरी-2019 को 18 वर्ष से कम रहने के कारण आपका आवेदन  मुख्यालय स्तर से रद्द कर दिया गया है|";
                }
            }
            else
            {
                lbl.Text = "यह आवेदन संख्या से कोई पुनर्विचार आवेदन नहीं हुआ है , या आवेदन संख्या गलत है |";
            }

        }
        catch { }
    }
}