using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using QRCoder;


public partial class Public_PrintRegistration : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    clsDataAccess clsData = new clsDataAccess();
    //SqlConnection con = new SqlConnection("server=.;database=KrishiDept;trusted_connection=yes");
    SqlConnection con = new SqlConnection();
    DataTable dt = new DataTable();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter adp = new SqlDataAdapter();
    public Public_PrintRegistration()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetRegistrationMobile");
            objcls.storeProcedure.FieldName = "Registration_Id";
            objcls.storeProcedure.FieldValue = new object[] { Session["RegId"].ToString() };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                lblRegId.Text = dt.Rows[0]["Registration_Id"].ToString();
                lblName1.Text = dt.Rows[0]["Name"].ToString();
                lblName.Text = dt.Rows[0]["Name"].ToString();
                lblFName.Text = dt.Rows[0]["Father_Husband_Name"].ToString();
                lblDOB.Text = dt.Rows[0]["DOB"].ToString();
                lblGender.Text = dt.Rows[0]["Gender"].ToString();
                lblMobile.Text = dt.Rows[0]["MobileNumber"].ToString();
                lblFarmerType.Text = dt.Rows[0]["Farmertype"].ToString();
                lblDist.Text = dt.Rows[0]["DistName"].ToString();
                lblBlock.Text = dt.Rows[0]["BlockName"].ToString();
                lblPanchayat.Text = dt.Rows[0]["PanchayatName"].ToString();
                lblVillage.Text = dt.Rows[0]["VILLNAME"].ToString();
                lblAadhaar.Text = dt.Rows[0]["AadhaarNumber"].ToString();
                lblCast.Text = dt.Rows[0]["CastCateogary"].ToString();
                if (dt.Rows[0]["BlockReg"].ToString() == "1")
                {
                    //lblDate.Text = "दिनांक :-" + dt.Rows[0]["Bd"].ToString() + " से " + dt.Rows[0]["ed"].ToString();
                    lblStatus.Text = "पराली जलाने के कारण आपका पंजीकरण 3 वर्षों के लिए बंद कर दिया गया है । कृषि विभाग के किसी भी योजना का आप लाभ नहीं ले सकते । ";
                }
                if (dt.Rows[0]["BlockReg"].ToString() == "2")
                {
                    lblStatus.Text = "आपके पंजीकरण में मोबाईल नंबर में त्रुटि पाए जाने के कारण पंजीकरण बंद किया गया है | कृपया बदलाव के लिए क्लिक करें | ";
                }
                if (dt.Rows[0]["BlockReg"].ToString() == "3")
                {
                    lblStatus.Text = "जिला से प्राप्त रिपोर्ट के अनुसार आपको मृत कृषि की सूची में रखा गया है | यदि डाटा में अंतर पाया जाए तब जिला कृषि पदाधिकारी को आवेदन दें |";
                }
                if (dt.Rows[0]["BlockReg"].ToString() == "4")
                {
                    lblStatus.Text = "आपके पंजीकरण में आपकी उम्र 95 वर्ष से ज्यादा पाए जाने के कारण अस्थाई रूप से बाधित है | कृपया कृषि समन्वयक/प्रखण्ड कृषि पदाधिकारी/ जिला कृषि पदाधिकारी से संपर्क करें ताकि यह सुनिश्चित हो सके की कृषक जीवित है | ";
                }
                if (dt.Rows[0]["BlockReg"].ToString() == "5")
                {
                    lblStatus.Text = "आपके पंजीकरण में आपके द्वारा जेन्डर(लिंग) की घोषणा में त्रुटि पाए जाने के कारण  आपका पंजीकरण अस्थाई रूप से बाधित है | कृपया बदलाव के लिए क्लिक करें |  ";
                }

            }
        }
        catch (Exception ee)
        { }
    }



}
