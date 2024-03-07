using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DAO_SAOInfoEntry : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    public DAO_SAOInfoEntry()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindSubDivision(); BindGrid();
        }
    }
    void BindSubDivision()
    {
        try
        {
            string query = "";
            query = @"select SDMCode,SDMName_En from SubDivisionMaster where SDMCode not in (select SubDivisionCode from SAO_Info ) and DistCode='" + Session["DistrictCode"].ToString() + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter adpp = new SqlDataAdapter();
            cmd.Connection = con;
            cmd.CommandText = query;
            adpp.SelectCommand = cmd;
            adpp.Fill(dt);

            //objcls.storeProcedure.NewStoreProcedure("SP_GetSubDivision");
            //objcls.storeProcedure.FieldName = "DistCode";
            //objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]) };
            //DataTable dt = objcls.storeProcedure.getData();


            ddlSubDivision.DataTextField = "SDMName_En";
            ddlSubDivision.DataValueField = "SDMCode";
            ddlSubDivision.DataSource = dt;
            ddlSubDivision.DataBind();
            ddlSubDivision.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch(Exception ee)
        {
        }
    }
protected void gvView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)gvView.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        con.Open();
        SqlCommand cmd = new SqlCommand("delete FROM [SAO_Info] where subdivisioncode='" + Convert.ToInt32(gvView.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        BindGrid();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {try
        {
            if (ddlSubDivision.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Select Sub Division..!');", true);
                return;
            }
            if (txtName.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Enter Name..!');", true);
                return;
            }
            if (txtMobileNo.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Enter MobileNo..!');", true);
                return;
            }
            con.Open();
            cmd.CommandText = @"insert into SAO_Info(DistCode, SubDivisionCode, SubDivisionName, Name, MobileNo, ActionDate, ActionBy)
                            values(@DistCode, @SubDivisionCode, @SubDivisionName, @Name, @MobileNo, @ActionDate, @ActionBy)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@DistCode", Convert.ToInt32(Session["DistrictCode"]));
            
            cmd.Parameters.AddWithValue("@SubDivisionCode", ddlSubDivision.SelectedValue);
            cmd.Parameters.AddWithValue("@SubDivisionName", ddlSubDivision.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text.Trim());
            cmd.Parameters.AddWithValue("@ActionDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ActionBy", Session["UserID"].ToString());
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                BindGrid();
                ddlSubDivision.SelectedValue = "0";
            }
            con.Close();
        }
        catch(Exception ee)
        {

        }
    }

    void BindGrid()
    {
        try
        {
            string query = "";
            query = @"SELECT DistCode, SubDivisionCode, SubDivisionName, Name, MobileNo, ActionDate, ActionBy from SAO_Info where DistCode='" + Session["DistrictCode"].ToString() + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter chkadpp = new SqlDataAdapter();
            cmd.Connection = con;
            cmd.CommandText = query;
            chkadpp.SelectCommand = cmd;
            chkadpp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
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