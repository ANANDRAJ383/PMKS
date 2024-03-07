using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Collections;
using System.Text;
using esms_client;
using System.Security.Cryptography;

public partial class DAO_DAOPraliApproval : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    DataTable dt = new DataTable();
   // clsDataAccess clsData = new clsDataAccess();
   clsDataAccessPMKisan clsData = new clsDataAccessPMKisan();

    public DAO_DAOPraliApproval()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRecords();
        }
    }


    void BindRecords()
    {
        try
        {
            dt = clsData.GetDataTable("SELECT *,'~'+ParaliPath as doc  FROM PARALIDETAILS WHERE STATUS=1 AND DISTRICTCODE='" + Session["DistrictCode"].ToString().Trim() + "' and BAO_STATUS=1 and (DAO_STATUS is null or len(DAO_STATUS)=0) and DistrictCode='" + Session["DistrictCode"].ToString().Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                gdviewdrought.DataSource = dt;
                gdviewdrought.DataBind();
            }
            else
            {
                gdviewdrought.DataSource = null;
                gdviewdrought.DataBind();

            }
        }
        catch (Exception ex) { }
    }
    protected void DownloadFile(object sender, EventArgs e)
    {
        try
        {
            //Response.Clear();
            string filePath = Server.MapPath((sender as LinkButton).CommandArgument);
            string fileName = filePath.Replace(".jpg", "") + "StubbleBurn.jpg";
            Response.ContentType = ContentType;//"image/jpg";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(fileName));
            Response.WriteFile(filePath);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex) { }
    }
    protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        foreach (GridViewRow row in gdviewdrought.Rows)
        {
            if (chk.Checked)
            {
                btnremarks.Visible = true;
            }
        }
    }
    protected void btnremarks_Click(object sender, EventArgs e)
    {
        int k = 0;
        int i = 0;
        foreach (GridViewRow row in gdviewdrought.Rows)
        {
            CheckBox checkboxrows = (CheckBox)row.FindControl("chkSelect");
            DropDownList ddlstatusDAO = (DropDownList)row.FindControl("ddlApproved");
            TextBox txtCommentDAO = (TextBox)row.FindControl("txtCommentDAO");
            string RegID = (gdviewdrought.DataKeys[row.RowIndex].Values["Registrationno"].ToString());
            string query = "";

            if (checkboxrows.Checked)
            {
                query = @"update ParaliDetails
                            set DAO_STATUS=@DAO_STATUS,   Dao_Remarks=@Dao_Remarks, 
                            DAO_Actiondate=@DAO_Actiondate, DAO_ActionName=@DAO_ActionID 
                            where Registrationno=@Registrationno";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@DAO_STATUS", ddlstatusDAO.SelectedValue);
                // da.SelectCommand.Parameters.AddWithValue("@STATUS", 2);
                da.SelectCommand.Parameters.AddWithValue("@Dao_Remarks", txtCommentDAO.Text.Trim());
                da.SelectCommand.Parameters.AddWithValue("@DAO_Actiondate", DateTime.Now);
                da.SelectCommand.Parameters.AddWithValue("@DAO_ActionID", Session["UserID"].ToString());
                da.SelectCommand.Parameters.AddWithValue("@Registrationno", RegID);
                con.Open();
                int jj = da.SelectCommand.ExecuteNonQuery();
                con.Close();
                if (jj > 0)
                {
                    k = k + 1;
                }
            }

        }
        ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('TOTAL " + k + " APPLICATION IS VERIFIED...');", true);
        BindRecords();
    }

   
    protected void chknew_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        foreach (GridViewRow row in gdviewdrought.Rows)
        {
            if (chk.Checked)
            {
                btnremarks.Visible = true;
            }
        }
    }
}