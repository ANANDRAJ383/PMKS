using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class ADMR_LandDetail : System.Web.UI.Page
{

    string RegId = "";
      clsDataAccessDiesel objcls = new clsDataAccessDiesel();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public ADMR_LandDetail()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
      {
        RegId = Request.QueryString["RegId"].ToString();
        lblRegId.Text = "Registration Id :-" + RegId;
        bindlanddata();
    }

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }


    void bindlanddata()
    {
        DataTable dt = new DataTable();
        dt = objcls.GetDataTable(@"select slno,RegistrationID,Khatano,keshrano,thanano,FarmingRakwa,Affectedrakwa,case when affectedtype=1 then N'सिंचित' else N'असिंचित' end as  affectedtype ,
        case when CropType = 1 then N'शाश्वत फसल/गन्ना' when croptype = 2 THEN N'गेंहूँ' when croptype = 3 THEN N'रबी दलहन' when CropType = 4 THEN N'रबी तेलहन'
        when croptype = 5 THEN N'अन्य फसल' when CropType = 4 THEN N'सब्जी' END as croptype
        from Input2223_landdetails  where RegistrationID='" + RegId + "'");
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    protected void btnTakeAction_Click(object sender, EventArgs e)
    {
        Button lnkRegistraionID = (Button)GridView1.FindControl("btnTakeAction");
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = GridView1.DataKeys[rowIndex].Values[0].ToString();
        string Slno = GridView1.DataKeys[rowIndex].Values[1].ToString();
        Button btndetails = sender as Button;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        if (RegId != "")
        {
            pnl1.Visible = true;
            lbl1.Text = RegId;
            Label1.Text = Slno;
            lblAffectedLand.Text = gvrow.Cells[7].Text;
            ddlLandType.SelectedItem.Text = gvrow.Cells[9].Text;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        try
        {
            decimal affectedLand = Convert.ToDecimal(lblAffectedLand.Text.Trim());
            if (Convert.ToDecimal(txtapprovedLand.Text.Trim()) > affectedLand)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please enter correct Land..!!!!!');", true);
                return;
            }

            //SqlDataAdapter da1 = new SqlDataAdapter(@"update  Input2223_landdetails set DAOChangeLandType=@DAOChangeLandType,  DAOChangeSubsidyArea=@DAOChangeSubsidyArea,  DAOAmount=@DAOAmount, DAOEntryDate=GETDATE()  where SLNO='" + Label1.Text + "'", con);
            //da1.SelectCommand.Parameters.AddWithValue("@DAOChangeLandType", ddl);
            //da1.SelectCommand.Parameters.AddWithValue("@DAOChangeSubsidyArea",);
            //da1.SelectCommand.Parameters.AddWithValue("@DAOAmount",);
            //int i = da1.SelectCommand.ExecuteNonQuery();
            //if (i > 0)
            //{
            //    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Land is approved..!!!!!');", true);
            //}
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
}