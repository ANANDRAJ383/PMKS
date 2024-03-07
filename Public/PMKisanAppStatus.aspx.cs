using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using esms_client;

public partial class Public_PMKisanAppStatus : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["RegId"]) == "")
        {
            Response.Redirect("../LoginForm.aspx");
        }
        lblRegId.Text = "Application Status of Registration Id :-" + Session["RegId"].ToString();
        if (!IsPostBack)
        {
            BindData();
        }
    }
    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetApplicationStatus_Old");
            objcls.storeProcedure.FieldName = "Registration_Id";
            objcls.storeProcedure.FieldValue = new object[] { Session["RegId"].ToString() };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                //lblName.Text = dt.Rows[0]["ApplicantName"].ToString();
                //lblFName.Text = dt.Rows[0]["Father_Husband_Name"].ToString();
                //lblMobile.Text = dt.Rows[0]["MobileNumber"].ToString();
                //lblFarmerType.Text = dt.Rows[0]["Farmertype"].ToString();
                //lblStatus.Text= dt.Rows[0]["C_Status"].ToString();
                //lblDist.Text = dt.Rows[0]["districtname"].ToString();
                //lblBlock.Text = dt.Rows[0]["blockname"].ToString();
                //lblPanchayat.Text = dt.Rows[0]["panchayatname"].ToString();
                //lblVillage.Text = dt.Rows[0]["VillageName"].ToString();
                //lblAadhaar.Text = dt.Rows[0]["AadharCard"].ToString();

            }
        }
        catch (Exception ee)
        { }
    }

}