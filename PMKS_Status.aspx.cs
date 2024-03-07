using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PMKS_Status : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    clsDataAccessNew clsNew = new clsDataAccessNew();
    SqlConnection con = new SqlConnection();
    public PMKS_Status()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        lblDate.Text = DateTime.Now.ToString();
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        if (txtRegId.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Registration Id !!!!!');", true);
            return;
        }
        else
        {
            BindData();
        }
    }

    void BindData()
    {
        try
        {

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_GetApplicationStatus_Old", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Registration_ID", txtRegId.Text.Trim());
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                pnlData.Visible = true;
                lblName.Text = dt.Rows[0]["ApplicantName"].ToString();
                lblFName.Text = dt.Rows[0]["Father_Husband_Name"].ToString();
                lblDOB.Text = dt.Rows[0]["MOBILENO"].ToString();
                lblMobile.Text = dt.Rows[0]["MOBILENO"].ToString();
                lblDist.Text = dt.Rows[0]["districtname"].ToString();
                lblBlock.Text = dt.Rows[0]["blockname"].ToString();
                lblPanchayat.Text = dt.Rows[0]["PanchayatName"].ToString();
                lblVillage.Text = dt.Rows[0]["VillageName"].ToString();
            }
        }
        catch (Exception ee)
        {
        }
    }
}