using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FreshData : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    public FreshData()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string query = "update PhysicalVerification_PMKISANFinal  set XMLCreationDate =getdate() where ActionDate is not null and	XMLCreationDate is null";
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
        string totalfarmer = " select  count(*) from PhysicalVerification_PMKISANFinal where ActionDate	is not null and	XMLCreationDate =getdate()";
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

            DataSet ds = CreateDynamicDataSetPFMSRejected();

            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    con.Open();
                    //foreach (DataRow dr in ds.Tables[0].Rows)
                    //{
                    //    SqlDataAdapter da = new SqlDataAdapter("insert into kkc (id) values ('" + dr["Identity_Proof_No"].ToString() + "')", cn);
                    //    da.SelectCommand.ExecuteNonQuery();
                    //}
                }
                catch
                {

                }
                finally
                {
                    //con.Close();
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
            SqlDataAdapter da = new SqlDataAdapter(@"select  Reg_No as Registration_Number, PhyVerifResponse as StatusOfBeneficiaryFound,	PhyVerifReason as IneligibilityReasonId, PhyVerifDate as DateOfIneligibilityOrDeath,	ActionDate as DateOfPhysicalVerification 	  from PhysicalVerification_PMKISANNew where ActionDate	is not null and	XMLCreationDate =getdate()", con);
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
}