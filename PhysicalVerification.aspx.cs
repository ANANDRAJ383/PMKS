using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PhysicalVerification : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    public PhysicalVerification()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillGrid();
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string query = "update PhysicalVerification_PMKISANFinal  set XMLCreationDate =getdate() where ActionDate is not null and XMLCreationDate is null AND PhyVerifReason NOT IN (10)";
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        int i = da.SelectCommand.ExecuteNonQuery();
        if (i > 0)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Date is updated sucessfully.....!!!!!!!!!!!');", true);
        }
    }
    protected void btnCout_Click(object sender, EventArgs e)
    {
        string totalfarmer = " select  count(*) cnt from PhysicalVerification_PMKISANFinal where ActionDate	is not null and	XMLCreationDate=convert(date, getdate(),106) AND PhyVerifReason NOT IN (10)";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Total No of Physical Verification " + dt.Rows[0]["cnt"].ToString() + "....!!!!!!!!!!!');", true);
        }

    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        try
        {
  string totalfarmer = " select  *  from PMKISAN_VerificationData where  ActionDate =convert(date, getdate(),106)";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Yor are already generated XML...!!!!!!!!!!!');", true);
return;
        }

            DataSet ds = CreateDynamicDataSetPFMSRejected();

            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    con.Open();
                }
                catch
                {
                }
                finally
                {
                }

                string FileName = "" + DateTime.Now.ToString("ddMMyyyyHHmm") + "FarmerPhysicalVerification.xml";
                string query = "insert into PMKISAN_VerificationData (ActionDate, XMLSheet) values (@ActionDate, @XMLSheet)";
                SqlDataAdapter dan = new SqlDataAdapter(query, con);
                dan.SelectCommand.Parameters.AddWithValue("@ActionDate", DateTime.Now);
                dan.SelectCommand.Parameters.AddWithValue("@XMLSheet", FileName);
                dan.SelectCommand.ExecuteNonQuery();
                ds.WriteXml(Server.MapPath(FileName));
                //lblResult.Text = "XML File Generated...........";
                StringWriter sw = new StringWriter();
                ds.WriteXml(sw, XmlWriteMode.IgnoreSchema);
                string s = sw.ToString();
                string attachment = "attachment;filename=" + FileName + "";
                Response.ClearContent();
                Response.ContentType = "application/xml";
                Response.AddHeader("content-disposition", attachment);
                Response.Write(s);
                //Response.Write("XML File Generated...........");
                Response.End();
                ScriptManager.RegisterStartupScript(this, GetType(), "Msg", "alert('XML File Generated..........." + ds.Tables[0].Rows.Count + "..');", true);
            }
        }


        catch
        {

        }
        finally
        {
            con.Close();
        }

    }
    private DataSet CreateDynamicDataSetPFMSRejected()
    {
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(@"select  Reg_No as Registration_Number, PhyVerifResponse as StatusOfBeneficiaryFound, ltrim(rtrim(convert(char, ActionDate,103))) as DateOfPhysicalVerification ,CASE WHEN PhyVerifResponse ='Eligible' then '' else  ltrim(rtrim(convert(char(11), PhyVerifDate,103))) end as DateOfIneligibilityOrDeath, case when PhyVerifReason is null then  '' else PhyVerifReason end  as IneligibilityReasonId	  from PhysicalVerification_PMKISANFinal where ActionDate	is not null and	XMLCreationDate  =convert(date, getdate(),106) AND PhyVerifReason NOT IN (10)", con);
            // SqlDataAdapter da = new SqlDataAdapter("select  [Farmer_Registration_No], [StateCode], [DistrictCode], [Farmer_Name], [Identity_Proof_No] from  PMKISAN_AadharNameCorrection where status is null", cn);
            ds.DataSetName = "DocumentElement";
            da.Fill(ds, "Farmer");
        }
        catch
        {

        }
        finally
        {
            con.Close();
        }
        return ds;
    }

    protected void fillGrid()
    {
        string query = "select  ActionDate, XMLSheet from PMKISAN_VerificationData order by slno ";
        con.Open();
        DataTable dt = cls.GetDataTable(query);

        if (dt.Rows.Count > 0)
        {
            grd1.DataSource = dt;
            grd1.DataBind();
        }

    }
 public void WinOpen1(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=1100,height=750,toolbar=0,addressbar =0, scrollbars=yes');", msg);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "strScript", strScript, true);
        }
        catch (Exception ex) { }
    }
 protected void lnkregid_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string appid = grd1.DataKeys[gvr.RowIndex].Values["XMLSheet"].ToString();
            string Filepath = "http://164.100.130.206//PMadmin//"+ appid ;
               WinOpen1(Filepath);

        }
        catch (Exception ex) { }
    }
}