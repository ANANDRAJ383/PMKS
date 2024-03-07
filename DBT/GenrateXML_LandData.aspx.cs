using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class DBT_GenrateXML_LandData : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString);
    SqlConnection con = new SqlConnection(); SqlConnection con1 = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    public DBT_GenrateXML_LandData()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;

        con1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData(); BindDataLand();
        }
    }

    void BindData()
    {
        try
        {
            //DataTable dtp = objcls.GetDataTable("select count(*) as T from [KrishiDept].[dbo].Registration_PMKISAN_New where ADMR_Status=1  and  landmutationdate is not null and XMLStatus is null and Registration_ID not in (select RegistrationID from PMKISAN.[dbo].tbl_PMKISAN_SammanNidhi) ");
            DataTable dtp = objcls.GetDataTable("select count(*) as T  from SocialAuditAll_PMKISAN  where ADM_Status = 1 and Sendstatus is null ");
            if (dtp.Rows.Count > 0)
            { lblTotal.Text = dtp.Rows[0]["T"].ToString() ;
            }
        }
        catch
        {
        }
    }
    void BindDataLand()
    {
        try
        {
            DataTable dtp = objcls.GetDataTable("select count(*) as T from [KrishiDept].[dbo].Registration_PMKISAN_New where ADMR_Status=1  and  landmutationdate is not null and XMLStatus=1 and Registration_ID not in (select RegistrationID from PMKISAN.[dbo].tbl_PMKISAN_SammanNidhi) ");
          
            if (dtp.Rows.Count > 0)
            {
                lblTotalLand.Text = dtp.Rows[0]["T"].ToString();
            }
        }
        catch
        {
        }
    }
    protected void btnGenrateXML_LandData_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet ds = CreateDynamicDataSetPFMSRejected();

            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    cn.Open();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("insert into tbl_Land (id) values ('" + dr["Registration_Number"].ToString() + "')", con);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
                catch
                {

                }
                finally
                {
                    cn.Close();
                }

                string FileName = "" + DateTime.Now.ToString("ddMMyyyyHHmm") + "DeathFarmers.xml";
                ds.WriteXml(Server.MapPath(FileName));
                lblTotal.Text = "XML File Generated...........";
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
            cn.Close();
        }
    }

    protected void btnGenrateXMLLand_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet ds = CreateDynamicDataSetPMKSLandData();

            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    con.Open();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        SqlDataAdapter da = new SqlDataAdapter("insert into tbl_Land (id) values ('" + dr["Registration_Number"].ToString() + "')", con);
                        da.SelectCommand.ExecuteNonQuery();
                    }
                }
                catch
                {

                }
                finally
                {
                    con.Close();
                }

                string FileName = "" + DateTime.Now.ToString("ddMMyyyyHHmm") + "FarmerLandData.xml";
                ds.WriteXml(Server.MapPath(FileName));
                lblTotal.Text = "XML File Generated...........";
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


        catch(Exception ee)
        {
lblTotalLand.Text = ee.Message;
        }
        finally
        {
            cn.Close();
        }
    }

    private DataSet CreateDynamicDataSetPFMSRejected()
    {
        DataSet ds = new DataSet();
        try
        {
          //  cn.Open();
            SqlDataAdapter da = new SqlDataAdapter(@"select TOP 20000 PMK_NO as Registration_Number,Convert(varchar,PhyVerifDate,103) as DateofDeath from SocialAuditAll_PMKISAN  where ADM_Status=1 and PMK_NO  is not null and Sendstatus is null", cn);
            ds.DataSetName = "DocumentElement";
            da.Fill(ds, "Farmer");
        }
        catch(Exception ee)
        {lblTotalLand.Text = ee.Message;
        }
        finally
        {
            cn.Close();
        }
        return ds;
    }

    private DataSet CreateDynamicDataSetPMKSLandData()
    {
        DataSet ds = new DataSet();
        try
        {
            //DataTable dt = objcls.GetDataTable("exec SP_LandDataforPMKS_PreviousData");

              con.Open();
            SqlDataAdapter da = new SqlDataAdapter(@"exec SP_LandDataforPMKS_PreviousData", con);


            //if (dt.Rows.Count > 0)
            //{
            //    ds.DataSetName = "DocumentElement";
            //}
            ds.DataSetName = "DocumentElement";
            da.Fill(ds, "FarmerLandDetails");

        }
        catch(Exception ee)
        {lblTotalLand.Text = ee.Message;
        }
        finally
        {
            con.Close();
        }
        return ds;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //string q= "update SocialAuditAll_PMKISAN set Sendstatus=1, senddate=getdate() where PMK_NO in(select id from kkc)";
    }

    protected void btnUpdateLand_Click(object sender, EventArgs e)
    {
        //SqlDataAdapter da = new SqlDataAdapter("insert into tbl_Land (id) values ('" + dr["Registration_Number"].ToString() + "')", con);
    }
}