using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StopPayment : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccess cls = new clsDataAccess();
    public StopPayment()
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
if(ddlLot.SelectedValue =="0")
{
ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please Select Lot no.');", true);
return;
}
        string totalfarmer = " select count(*) cnt from CreateXML where lotno=" + ddlLot.SelectedValue + "";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Total No of Stop Payment " + dt.Rows[0]["cnt"].ToString() + "....!!!!!!!!!!!');", true);
        }

    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
if(ddlLot.SelectedValue =="0")
{
ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please Select Lot no.');", true);
return;
}

        string qq= "select * from PMKISAN_StopData where LotNo="+ ddlLot.SelectedValue  +"";
        DataTable dtt = cls.GetDataTable(qq);
        if (dtt.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Msg", "alert('You are all readeay Generated.......... ');", true);
            return;
        }
        else
        {

        }

        try
        {
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

                string FileName = "" + DateTime.Now.ToString("ddMMyyyyHHmm") + ddlLot.SelectedValue + "FarmerStopPayment.xml";
                string query = "insert into [PMKISAN_StopData] (ActionDate, XMLSheet, LotNo) values (@ActionDate, @XMLSheet, @LotNo)";
                SqlDataAdapter dan = new SqlDataAdapter(query, con);
                dan.SelectCommand.Parameters.AddWithValue("@ActionDate", DateTime.Now);
                dan.SelectCommand.Parameters.AddWithValue("@XMLSheet", FileName);
                dan.SelectCommand.Parameters.AddWithValue("@LotNo", ddlLot.SelectedValue );
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
            SqlDataAdapter da = new SqlDataAdapter(@"select [Registration_Number], [DateofIneligibility], [ReasonId] from  CreateXML where lotno=" + ddlLot.SelectedValue + "", con);
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
        string query = "select  [ActionDate], [XMLSheet] from PMKISAN_StopData order by slno ";
        con.Open();
        DataTable dt = cls.GetDataTable(query);

        if (dt.Rows.Count > 0)
        {
            grd1.DataSource = dt;
            grd1.DataBind();
        }


    }
    protected void lnkregid_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string appid = grd1.DataKeys[gvr.RowIndex].Values["XMLSheet"].ToString();
            string FileName = "\\PMKISANAdmin\\" + appid;
            string attachment = "attachment;filename=" + FileName + "";
            Response.ClearContent();
            Response.ContentType = "application/xml";
            Response.AddHeader("content-disposition", attachment);
            Response.End();

        }
        catch (Exception ex) { }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string totalfarmer = "select * from CreateXML where Registration_Number='" + txt1.Text.Trim()+ "'";
        DataTable dt = cls.GetDataTable(totalfarmer);
        if (dt.Rows.Count > 0)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('ID IS DEACTIVED..!!!!!!!!!!!');", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('NOT EXISTS..!!!!!!!!!!!');", true);
        }
    }
}