using esms_client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NODAL_SendToBankDiesel2223 : System.Web.UI.Page
{
    clsDataAccessDiesel objcls = new clsDataAccessDiesel();
    clsDataAccess_Diesel cls = new clsDataAccess_Diesel();
    SqlConnection con = new SqlConnection();
    public NODAL_SendToBankDiesel2223()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishiDBConnectionString"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Date();
            ddlDate_SelectedIndexChanged(sender, e);
        }
    }
    protected void Date()
    {
        DataTable dt = cls.GetDataTable("SELECT Distinct CONVERT(CHAR(11), LOTDATE, 103) date, LotNoID from [DieselKharif2223SendtoBankMaster] where GenerateCSV is null");
        if (dt.Rows.Count > 0)
        {
            ddlDate.ClearSelection();
            ddlDate.DataSource = dt;
            ddlDate.DataTextField = "date";
            ddlDate.DataValueField = "LotNoID";
            ddlDate.DataBind();

            ddlDate.Items.Insert(0, new ListItem("Select", "0"));
        }
        else
        {
            ddlDate.ClearSelection();
            ddlDate.Items.Insert(0, new ListItem("Not Available", "0"));

        }
    }
    protected void lotno()
    {
       
        
        DataTable dt = cls.GetDataTable("SELECT Distinct Lotno from [DieselKharif2223SendtoBankMaster] where GenerateCSV is null and LotNoID=  '" + ddlDate.SelectedValue + "'");
        if (dt.Rows.Count > 0)
        {
            ddlLot.ClearSelection();
            ddlLot.DataSource = dt;
            ddlLot.DataTextField = "Lotno";
            ddlLot.DataValueField = "Lotno";
            ddlLot.DataBind();
            ddlLot.Items.Insert(0, new ListItem("Select", "0"));
        }
        else
        {
            ddlLot.ClearSelection();
            ddlLot.Items.Insert(0, new ListItem("Not Available", "0"));
        }
    }
    protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        lotno();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        if (ddlSeasonID.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Slect Season..!');", true);
            ddlSeasonID.Focus();
            return;
        }
        if (ddlDate.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Slect Date....!');", true);
            ddlDate.Focus();
            return;
        }
        if (ddlLot.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Slect Lot No...!');", true);
            ddlLot.Focus();
            return;
        }
        string query = @"select  * from [DieselKharif2223SendtoBankMaster] where  Lotno=" + ddlLot.SelectedValue + " and  LotNoID='" + ddlDate.SelectedValue + "'  and  GenerateCSV is null order by DAO_ApprovedAmt desc";
        DataTable dt = cls.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            grdChecke.DataSource = dt;
            grdChecke.DataBind();
            Button4.Visible = true;
        }
        else
        {

        }

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        
        string query = @"select top 1 * from DieselSubKhrf2223_Generated  where  Lotno=" + ddlLot.SelectedValue + " and  LotNoID='" + ddlDate.SelectedValue + "'";
        DataTable dt = cls.GetDataTable(query);
        
        if (dt.Rows.Count > 0)
        {
            ViewState["TotalBen"] = dt.Rows[0]["TotalBan"].ToString();
            ViewState["TotalAmt"] = dt.Rows[0]["DAO_ApprovedAmt"].ToString();
            string OTP = dt.Rows[0]["OTP"].ToString();
            string MobileNo = "8544588470";
            SMSHttpPostClient otpmsg = new SMSHttpPostClient();
            otpmsg.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", MobileNo, "Your One Time Password is=" + OTP + "-Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182040506952");
            Label2.Text = "4 Digit OTP send on Registrated Mobile No: " + "XXXXXX" + MobileNo.Substring(6, 4);
            //pnl1.Visible = true;
            TextBox2.Text = "";
            TextBox2.Visible = true;
            LinkButton2.Visible = true;
            Button3.Visible = true;
        }
        else
        {
            TextBox2.Text = "";
            TextBox2.Visible = false;
            LinkButton2.Visible = false;
            Button3.Visible = false;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TextBox2.Text.Trim()))
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Enter Correct OTP....!');", true);
            TextBox2.Focus();
            return;
        }
        
        string query = @"select top 1 * from DieselSubKhrf2223_Generated where  Lotno=" + ddlLot.SelectedValue + " and  LotNoID='" + ddlDate.SelectedValue + "' ";
        DataTable dt = cls.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            string OTP = dt.Rows[0]["OTP"].ToString();
            if (OTP == TextBox2.Text.Trim())
            {
                con.Open();
                //pnl1.Visible = true;
                TextBox2.Enabled = false;
                LinkButton2.Enabled = false;


                objcls.storeProcedure.NewStoreProcedure("SP_UpdateCSV");
                objcls.storeProcedure.AddWithValue("Lotno", ddlLot.SelectedValue);
                objcls.storeProcedure.AddWithValue("LotNoID", ddlDate.SelectedValue);
                if(objcls.storeProcedure.ExecuteNonQuery())
                {
                    DownloaCSV();
                }

                //SqlDataAdapter da = new SqlDataAdapter("update [DieselKharif2223SendtoBankMaster] set GenerateCSV=1, GenerateDate=getdate(), GenerateBy='" + Session["UserName"].ToString() + "' where  Lotno=" + ddlLot.SelectedValue + " and  LotNoID='" + ddlDate.SelectedValue + "' and GenerateCSV is null", con);
                //int i = da.SelectCommand.ExecuteNonQuery();

                //if (i > 0)
                //{
                //    DownloaCSV();
                //}
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Try Again....!');", true);
                }
                con.Close();
            }
            else
            {
                //pnl1.Visible = true;
                TextBox2.Text = "";
                TextBox2.Enabled = true;
                LinkButton2.Enabled = true;
                Button3.Enabled = true;
            }
        }
        else
        {
            Label2.Text = "OTP not generated....!!!";
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string query = @"select top 1 * from DieselSubKhrf2223_Generated where  Lotno=" + ddlLot.SelectedValue + " and  LotNoID='" + ddlDate.SelectedValue + "'";
        DataTable dt = cls.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            string OTP = dt.Rows[0]["OTP"].ToString();
            string MobileNo = "8544588470";
            //SMSHttpPostClient otpmsg = new SMSHttpPostClient();
            //otpmsg.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", MobileNo, "Your One Time Password is=" + OTP + "-Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182040506952");
            SMSHttpPostClient otpmsg = new SMSHttpPostClient();
            otpmsg.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", MobileNo, "Your One Time Password is=" + OTP + "-Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182040506952");
            Label2.Text = "4 Digit OTP send on Registrated Mobile No: " + "XXXXXX" + MobileNo.Substring(6, 4);
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void DownloaCSV()
    {
        string fileName = "DSLKHARIF";
        //DSLKHARIF13082022173401
        string filenameN = fileName + DateTime.Now+ ".csv";
        objcls.storeProcedure.NewStoreProcedure("SP_InsertFileNameDiesel");
        objcls.storeProcedure.AddWithValue("FileName", filenameN);
        objcls.storeProcedure.AddWithValue("TotalBen", ViewState["TotalBen"].ToString());
        objcls.storeProcedure.AddWithValue("Amount", Convert.ToDecimal(ViewState["TotalAmt"]));
        objcls.storeProcedure.ExecuteNonQuery();
        
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename=" + fileName + DateTime.Now+ ".csv"));
        //Response.AddHeader("content-disposition", "attachment;filename='"+fileName+DateTime.Now.ToString("dd MMMM yyyy")'".csv");
        Response.Charset = "";
        Response.ContentType = "application/text";

        StringBuilder sb = new StringBuilder();
        for (int k = 0; k < grdChecke.Columns.Count; k++)
        {
            //add separator
            sb.Append(grdChecke.Columns[k].HeaderText + ',');
        }
        //append new line
        sb.Append("\r\n");
        for (int i = 0; i < grdChecke.Rows.Count; i++)
        {
            for (int k = 0; k < grdChecke.Columns.Count; k++)
            {
                //add separator
                sb.Append(grdChecke.Rows[i].Cells[k].Text + ',');
            }
            //append new line
            sb.Append("\r\n");
        }
        Response.Output.Write(sb.ToString());
        string path = Server.MapPath("~/HDFCBank/");
        string datetime = DateTime.Now.ToString("ddMMyyyyHHmm");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        File.WriteAllText(Path.Combine(path, fileName + datetime + "" + ddlLot.SelectedValue + ".csv"), sb.ToString());
        Response.Flush();
        Response.End();

    }

    protected void ddlSeasonID_SelectedIndexChanged(object sender, EventArgs e)
    {
        Date();
        ddlDate_SelectedIndexChanged(sender, e);
    }
}