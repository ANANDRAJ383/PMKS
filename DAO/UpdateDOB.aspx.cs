using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DAO_UpdateDOB : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public DAO_UpdateDOB()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    void BindData()
    {
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_GetRegistrationMobile", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Registration_ID", txtRegId.Text.Trim());
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                tblData.Visible = true;
                lblName.Text = dt.Rows[0]["Name"].ToString();
                lblFName.Text = dt.Rows[0]["Father_Husband_Name"].ToString();
                lblDOB.Text = dt.Rows[0]["DOB1"].ToString();
                lblGender.Text = dt.Rows[0]["Gender"].ToString();
                lblMobile.Text = dt.Rows[0]["MobileNumber"].ToString();
                lblFarmerType.Text = dt.Rows[0]["Farmertype"].ToString();
                txtDOB.Text= dt.Rows[0]["DOB1"].ToString();
            }
        }
        catch (Exception ee)
        { }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            cmd.CommandText = @"update Registration set Updated_DOB=@Updated_DOB , DOB_UpdateDate=GETDATE() , DOB_UpdateBy=@DOB_UpdateBy where  Registration_ID=@Registration_ID ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("Updated_DOB", txtDOB.Text.Trim());
            cmd.Parameters.AddWithValue("DOB_UpdateBy", Convert.ToString(Session["UserID"]));
            cmd.Parameters.AddWithValue("Registration_ID", txtRegId.Text.Trim());            
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                lblMsg.Text = "DOB Updated Successfully";
                tblData.Visible = false;
            }
        }
        catch(Exception ee)
        { }
    }
}