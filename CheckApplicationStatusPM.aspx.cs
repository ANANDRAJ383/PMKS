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
    clsDataAccessNew clsNew = new clsDataAccessNew();
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
    void BindData()
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

                string QUERY = @"select  RegistrationID, d.DistName,b.BlockName,khata_no Khatano, KhesraNo keshrano, 
                                thanano, LandDismil rakwa, FarmingRakwa, EntryDate from Registration_PMKIsan_LandDetails_New l
                                inner join Districts d on l.DistrictCode=d.DistCode
                                inner join Blocks b on b.BlockCode=l.BlockCode
                    where RegistrationID='" + txtRegId.Text.Trim() + "'";

                DataTable dtLand = clsNew.GetDataTable(QUERY);
                if (dtLand.Rows.Count > 0)
                {
                    grdLand.DataSource = dtLand;
                    grdLand.DataBind();
                }
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

   
    #endregion
}