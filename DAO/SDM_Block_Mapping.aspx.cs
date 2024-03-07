using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class DAO_SDM_Block_Mapping : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    public DAO_SDM_Block_Mapping()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSubDivision(); BindBlock(); BindGrid();
        }
    }


    void BindSubDivision()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetSubDivision");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]) };
            DataTable dt = objcls.storeProcedure.getData();
            ddlSubDivision.DataTextField = "SDMName_En";
            ddlSubDivision.DataValueField = "SDMCode";
            ddlSubDivision.DataSource = dt;
            ddlSubDivision.DataBind();
            ddlSubDivision.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch
        {
        }
    }
    void BindBlock()
    {
        try
        {

            string query = "";
            query = @"select BlockCode,BlockName from Blocks where BlockCode not in (select BlockCode from SubDivisionBlockMap ) and DistCode='" + Session["DistrictCode"].ToString() + "' order by BlockName";
            DataTable dt = new DataTable();
            SqlDataAdapter adpp = new SqlDataAdapter();
            cmd.Connection = con;
            cmd.CommandText = query;
            adpp.SelectCommand = cmd;
            adpp.Fill(dt);

            //objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
            //objcls.storeProcedure.FieldName = "DistCode";
            //objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]) };
            //DataTable dt = objcls.storeProcedure.getData();

            ddlBlock.DataTextField = "BlockName";
            ddlBlock.DataValueField = "BlockCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch
        {
        }
    }
protected void gvView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)gvView.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblID");
        con.Open();
        SqlCommand cmd = new SqlCommand("delete FROM [SubDivisionBlockMap] where BlockCode='" + Convert.ToInt32(gvView.DataKeys[e.RowIndex].Value.ToString()) + "'", con);
        cmd.ExecuteNonQuery();
        con.Close();
        BindGrid();
    }
 
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlSubDivision.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Select Sub Division..!');", true);
            return;
        }
        if (ddlBlock.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Please Select Block..!');", true);
            return;
        }
        con.Open();
        cmd.CommandText = @"insert into SubDivisionBlockMap(DistCode, DistName, SubDivisionCode, SubDivisionName, BlockCode, BlockName, ActionDate, ActionBy)
                            values(@DistCode, @DistName, @SubDivisionCode, @SubDivisionName, @BlockCode, @BlockName, @ActionDate, @ActionBy)";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@DistCode",Convert.ToInt32(Session["DistrictCode"]));
        cmd.Parameters.AddWithValue("@DistName", Session["DistrictName "].ToString());
        cmd.Parameters.AddWithValue("@SubDivisionCode", ddlSubDivision.SelectedValue);
        cmd.Parameters.AddWithValue("@SubDivisionName", ddlSubDivision.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@BlockCode", ddlBlock.SelectedValue);
        cmd.Parameters.AddWithValue("@BlockName", ddlBlock.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@ActionDate", DateTime.Now);
        cmd.Parameters.AddWithValue("@ActionBy", Session["UserID"].ToString());
        int i=cmd.ExecuteNonQuery();
        if (i > 0)
        {
            BindGrid();
            ddlSubDivision.SelectedValue = "0";
            ddlBlock.SelectedValue = "0";
            BindBlock();
        }
        con.Close();
    }
    void BindGrid()
    {
        try
        {
            string query = "";
            query = @"SELECT DistCode, DistName, SubDivisionCode, SubDivisionName, BlockCode, BlockName, ActionDate, ActionBy from SubDivisionBlockMap where DistCode='" + Session["DistrictCode"].ToString() + "'";
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
        catch(Exception ee)
        {

        }
    }

    protected void ddlSubDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBlock();
    }
}