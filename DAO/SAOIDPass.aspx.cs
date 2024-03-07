using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using esms_client;
using System.Text;

public partial class DAO_PanchayatEnrtyPage : System.Web.UI.Page
{
    string q = "";
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SMSHttpPostClient sms = new SMSHttpPostClient();
    public DAO_PanchayatEnrtyPage()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           BindGrid();

        }
    }
    //void BindBlock()
    //{
    //    try
    //    {
    //       // q = "select  block_id, BlockName from loginmaster l inner join Blocks b on l.block_id = b.blockcode where dist_id = '" + Convert.ToInt32(Session["DistrictCode"]) + "' and NewRole = 'atm/btm'";
    //      q = "select distinct blockcode,blockname from blocks where distcode='" + Convert.ToInt32(Session["DistrictCode"]) + "'";
    //        DataTable dt = objcls.GetDataTable(q);
    //        if (dt.Rows.Count > 0)
    //        {
    //            ddlblock.Items.Clear();
    //            ddlblock.DataSource = dt;
    //            ddlblock.DataTextField = "blockname";
    //            ddlblock.DataValueField = "blockcode";
    //            ddlblock.DataBind();
    //            ddlblock.Items.Insert(0, new ListItem("--Select--", "0"));
    //        }
    //    }
    //    catch (DataException ex)
    //    {
    //    }
    //}
    //void BindPanchayat()
    //{
    //    try
    //    {
    //        q = "select distinct panchayatcode,panchayatname from panchayat where blockcode='" + ddlblock.SelectedValue + "'";
    //        DataTable dt = objcls.GetDataTable(q);
    //        if (dt.Rows.Count > 0)
    //        {
    //            ddlpanchayat.Items.Clear();
    //            ddlpanchayat.DataSource = dt;
    //            ddlpanchayat.DataTextField = "panchayatname";
    //            ddlpanchayat.DataValueField = "panchayatcode";
    //            ddlpanchayat.DataBind();
    //            ddlpanchayat.Items.Insert(0, new ListItem("--All--", "0"));
    //        }
    //    }
    //    catch (DataException ex)
    //    {
    //    }
    //}
    //protected void ddlblock_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindPanchayat();
    //}
    //protected void btnShow_Click(object sender, EventArgs e)
    //{
    //    DataTable dt = new DataTable();
    //    if (ddlblock.SelectedValue == "0")
    //    {
    //        ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Select block name..!');", true);
    //        return;
    //    }
    //    if (ddlpanchayat.SelectedValue == "0")
    //    {
    //        ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Select panchayat name..!');", true);
    //        return;
    //    }
    //    string check = "select name,Mobileno,userid,NE from loginmaster where NewRole = 'ATM/BTM'";
    //    dt = objcls.GetDataTable(check);
    //    if (dt.Rows.Count > 0)
    //    {
    //        if (dt.Rows[0]["NE"].ToString() == "Y")
    //        {
    //            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Select panchayat name..!');", true);
    //            return;
    //        }
    //    }
    //    dt.Dispose();

    //    string q = "select p.panchayatname,l.* from loginmaster l inner join [panchayat ] p on l.panchayat_id=p.panchayatcode where panchayat_id='" + ddlpanchayat.SelectedValue+ "' and newrole='ATM/BTM'";
    //     dt = objcls.GetDataTable(q);
    //    if (dt.Rows.Count > 0)
    //    {
    //        pnldata.Visible = true;
    //        lblname.Text = dt.Rows[0]["userid"].ToString();
    //        lblpanname.Text= dt.Rows[0]["panchayatname"].ToString();

    //    }
    //    }

    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    DataTable dt = new DataTable();
    //    string check = "select name,Mobileno,userid,NE from loginmaster where NewRole = 'ATM/BTM' and userid='"+lblname.Text.Trim()+"' and NE='Y'";
    //    dt = objcls.GetDataTable(check);
    //    if (dt.Rows.Count > 0)
    //    {
    //         ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('You have already alloted the panchayat, select another from list..!');", true);
    //            return;
            
    //    }
    //    if (ddlblock.SelectedValue == "0")
    //    {
    //        ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Select Sub Division..!');", true);
    //        return;
    //    }
    //    if (ddlpanchayat.SelectedValue == "0")
    //    {
    //        ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Select Block..!');", true);
    //        return;
    //    }
    //    if (TextBox1.Text == "")
    //    {
    //        ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Enter Name..!');", true);
    //        return;
    //    }
    //    if (TextBox2.Text == "")
    //    {
    //        ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Enter MobileNo..!');", true);
    //        return;
    //    }
    //    Label1.Text = GetRandomPassword(7);
    //    //con.Open();
    //    //cmd.CommandText = @"update loginmaster set name='"+TextBox1.Text.Trim()+"',mobileno='"+TextBox2.Text.Trim()+"' ";
    //    //cmd.CommandType = CommandType.Text;
    //    //cmd.Connection = con;
    //    con.Open();
    // string query = @"update loginmaster set name = @name, Mobileno=@Mobileno ,password=@password    where userid =@userid";

    //    SqlDataAdapter da = new SqlDataAdapter(query, con);
        
    //    da.SelectCommand.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
    //    da.SelectCommand.Parameters.AddWithValue("@Mobileno", TextBox2.Text.Trim());
    //    da.SelectCommand.Parameters.AddWithValue("@password", Label1.Text.Trim());
    //    da.SelectCommand.Parameters.AddWithValue("@userid", lblname.Text.Trim()); 
    //    int jj = da.SelectCommand.ExecuteNonQuery();
       
    //    if (jj > 0)
    //    {           
    //        string queryupdt = @"update loginmaster set NE ='Y'     where userid ='"+ lblname.Text.Trim() + "'";
    //        SqlDataAdapter daupdt = new SqlDataAdapter(queryupdt, con);
    //        int i= daupdt.SelectCommand.ExecuteNonQuery();
    //        if (i > 0)
    //        {
    //            string queryfetch = @"select password from loginmaster where userid='" + lblname.Text.Trim() + "'";
    //            DataTable dtfetch = objcls.GetDataTable(queryfetch);
    //            if (dtfetch.Rows.Count > 0)
    //            {
    //                string UserID = lblname.Text.Trim();
    //                string paswoord = dtfetch.Rows[0]["password"].ToString();
    //                sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", TextBox2.Text.Trim(), "'कृषि विभाग बिहार सरकार द्वारा सूचित किया जाता है कि डीजल अनुदान के जांच हेतु {#var#}आपका यूजर आईडी  '" + UserID + "' और पासवर्ड '"+ paswoord  + "' है|'" + "-Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182073909271");
    //            }
    //            con.Close();
    //            BindGrid();
    //        }
    //    }
               
    //    }
    //public static string GetRandomPassword(int length)
    //{
    //    const string chars = "123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

    //    StringBuilder sb = new StringBuilder();
    //    Random rnd = new Random();

    //    for (int i = 0; i < length; i++)
    //    {
    //        int index = rnd.Next(chars.Length);
    //        sb.Append(chars[index]);
    //    }

    //    return sb.ToString();
    //}

    void BindGrid()
    {
        try
        {
            string query = "";
            query = @"select d.DistName, a.SDMName_En ,name ,Mobileno, userid, password  from SubDivisionMaster  a inner join loginmaster l 
                       on l.SubDivison_Id=a.SDMCode inner join Districts d on d.DistCode=a.DistCode  and d.DistCode=l.dist_id and l.userrole='SAO'
                       where l.dist_id='" + Convert.ToInt32(Session["DistrictCode"]) + "'"; 
            DataTable dt = new DataTable();
            SqlDataAdapter chkadpp = new SqlDataAdapter();
            cmd.Connection = con;
            cmd.CommandText = query;
            chkadpp.SelectCommand = cmd;
            chkadpp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                pnlgdview.Visible = true;
                gvView.DataSource = dt;
                gvView.DataBind();
                gvView.Visible = true;
            }
            else
            {
                gvView.Visible = false;
            }
        }
        catch (Exception ee)
        {

        }
    }

}