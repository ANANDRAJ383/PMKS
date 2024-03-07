using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class CheckApplicationStatus : System.Web.UI.Page
{
    //clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    public CheckApplicationStatus()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGet_Click(object sender, EventArgs e)
    {
        if (txtRegId.Text.ToString() == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Registration Id !!!!!');", true);
            return;
        }
        
            BindData();
        
    }


    #region Function&Method
    void BindData1()
    {
        try
        {

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_GetApplicationStatus_Old",con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Registration_ID",txtRegId.Text.Trim());
            DataTable dt = new DataTable();
            da.Fill(dt);
         
            if (dt.Rows.Count > 0)
            {
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }
            else
            { 
		dt.Clear();
		dt.Dispose();
                DataTable dtnull = new DataTable();
                gvdata.DataSource = dtnull;
                gvdata.DataBind();
                gvdata.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
            }
        }
        catch (Exception ee)
        {
        }
    }

    void BindData()
    {
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_GetApplicationStatus_PM", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Registration_ID", txtRegId.Text.Trim());
            da.SelectCommand.Parameters.AddWithValue("@ApplicationType", ddlApplicationType.SelectedValue.Trim());
            DataTable dt = new DataTable();
            da.Fill(dt);
// ,Blockname,Panchayatname,VillageName,

            if (dt.Rows.Count > 0)
            {
                lblRegistrationId.Text = dt.Rows[0]["Registration_Id"].ToString();
		lblAadhaar.Text = dt.Rows[0]["AadharCard"].ToString();
                lblName.Text = dt.Rows[0]["ApplicantName"].ToString();
                lblFName.Text = dt.Rows[0]["Father_Husband_Name"].ToString();
                lblApplicationType.Text = dt.Rows[0]["atype"].ToString();
                lblMobile.Text = dt.Rows[0]["MOBILENO"].ToString();
                lblFarmerType.Text = dt.Rows[0]["Farmertype"].ToString();
                lblDist.Text = dt.Rows[0]["districtname"].ToString();
                lblBlock.Text = dt.Rows[0]["blockname"].ToString();
                lblPanchayat.Text = dt.Rows[0]["panchayatname"].ToString();
                lblVillage.Text = dt.Rows[0]["VillageName"].ToString();
                
               // lblCast.Text = dt.Rows[0]["CastCateogary"].ToString();
                lblIFSC.Text = dt.Rows[0]["IFSC_Code"].ToString();
                lblAC.Text = dt.Rows[0]["AccountNumber"].ToString();
                lblStatus.Text = dt.Rows[0]["C_Status"].ToString();

                lblACStaus.Text= dt.Rows[0]["AC_Status"].ToString();
                lblACDate.Text = dt.Rows[0]["AC_ActionDate"].ToString();

                lblCOStaus.Text = dt.Rows[0]["CO_Status"].ToString();
                lblCODate.Text = dt.Rows[0]["CO_ActionDate"].ToString();

                lblDAOStaus.Text = dt.Rows[0]["DAO_Status"].ToString();
                lblDAODate.Text = dt.Rows[0]["DAO_ActionDate"].ToString();

                lblADMRStaus.Text = dt.Rows[0]["ADMR_Status"].ToString();
                lblADMRDate.Text = dt.Rows[0]["ADMR_ActionDate"].ToString();

                

            }
        }
        catch (Exception ee)
        { }
    }
    #endregion
}