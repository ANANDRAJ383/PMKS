using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class SocialAuditData_Illigable : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public SocialAuditData_Illigable()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserRole"]) == "" || Convert.ToString(Session["UserRole"]) == null)
        {
            Response.Redirect("../LoginForm.aspx");
        }

        if (!Page.IsPostBack)
        {
            BindBlock();
            ddlBlock_SelectedIndexChanged(sender, e);
            BindPanchayat();
        }
    }


    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex; BindData();
    }

    #region Function&Method


   protected  void BindBlock()
    {
        try
        {
            
            SqlDataAdapter da = new SqlDataAdapter("Select * from blocks where distcode='"+ Session["DistrictCode"].ToString() +"'", con);
            da.SelectCommand.CommandType = CommandType.Text;
            //da.SelectCommand.Parameters.AddWithValue("@DistCode", Convert.ToInt32(Session["DistrictCode"]));
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlBlock.DataTextField = "BlockNameHN";
            ddlBlock.DataValueField = "BlockCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }
    }

  protected void BindPanchayat()
    {
         

        SqlDataAdapter da = new SqlDataAdapter("select * from panchayat where blockcode='"+ ddlBlock.SelectedValue +"'", con);
        da.SelectCommand.CommandType = CommandType.Text;
       // da.SelectCommand.Parameters.AddWithValue("@BlockCode", ddlBlock.SelectedValue);
        DataTable dt = new DataTable();
        da.Fill(dt);
        ddlPanchayat.DataTextField = "PanchayatNameHnd";
        ddlPanchayat.DataValueField = "PanchayatCode";
        ddlPanchayat.DataSource = dt;
        ddlPanchayat.DataBind();
        ddlPanchayat.Items.Insert(0, new ListItem("--All--", "0"));
    }


    void BindData()
    {
        try
        {

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_Get_SocialAuditAll_PMKISANData", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@DistCode", Convert.ToInt32(Session["DistrictCode"]));
            da.SelectCommand.Parameters.AddWithValue("@BlockCode", ddlBlock.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@PanchayatCode", ddlPanchayat.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@RegId", txtRegId.Text);
            da.SelectCommand.Parameters.AddWithValue("@PhyVerifReason", ddlType.SelectedValue);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //objcls.storeProcedure.NewStoreProcedure("SP_Get_SocialAuditAll_PMKISANData");
            //objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode,RegId,PhyVerifReason";
            //objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), ddlBlock.SelectedValue, ddlPanchayat.SelectedValue,txtRegId.Text,ddlType.SelectedValue };
            //DataTable dt = objcls.storeProcedure.getData();

            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                btnExport.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
                btnExport.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblMsg.Text = "Record Not available !!!!!";
            }
            con.Close();
        }
        catch (Exception ee)
        { }
    }

    void Verify()
    {
        
        try
        {
           
            foreach (GridViewRow row in gvdata.Rows)
            {
                CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
                Label lblRegistrationID = (Label)row.FindControl("lblRegistrationID");
                DropDownList ddlStatus=(DropDownList)row.FindControl("ddlStatus");
                TextBox txtPhyVerifDate = (TextBox)row.FindControl("txtPhyVerifDate");
                TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");
               
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chk.Checked == true)
                    {
                        if (txtRemarks.Text == "")
                        {
                            lblMsg.Text = "Please fill remark !!!!!";
                            txtRemarks.Focus();
                            return;
                        }
                        if (ddlStatus.SelectedValue == "0")
                        {
                            lblMsg.Text = "Please Select Status !!!!!";
                            ddlStatus.Focus();
                            return;
                        }

                        cmd.Parameters.Clear();
                        con.Open();  
                        cmd.CommandText = @"update SocialAuditAll_PMKISAN set DAO_Status=@DAO_Status,PhyVerifDate=@PhyVerifDate , DAOActiondate=GETDATE() , DAOActionName=@DAO_ActionName,DAORemarks=@DAORemark where  RegistrationNo=@RegistrationNo ";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@DAO_ActionName", Convert.ToString(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@RegistrationNo", lblRegistrationID.Text.Trim());
                        cmd.Parameters.AddWithValue("@DAO_Status", ddlStatus.SelectedValue);
                        cmd.Parameters.AddWithValue("@PhyVerifDate", txtPhyVerifDate.Text.Trim());
                        cmd.Parameters.AddWithValue("@DAORemark", txtRemarks.Text.Trim());                        
                        int i=cmd.ExecuteNonQuery();
                        if(i>0)
                        {
                            
                            cmd.Dispose();
                            lblMsg.Text = "Record Verified Successfully";
                            gvdata.Visible = false;
                        }
                    }
                    
                }
            }
            

        }
        catch (Exception ee)
        {

        }
    }

    #endregion
    protected void btnView_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
 
 //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Hellooooo....... !!!!!');", true);
       BindPanchayat();

    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnUp_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "Please fill remark !!!!!";
        // Response.Write("surendra kr jha");
        //int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        //string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        //string RegId = gvdata.DataKeys[gvdata.SelectedIndex].Values["Registration_ID"].ToString();
        //Verify();
        foreach (GridViewRow row in gvdata.Rows)
        {
            CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
            Label lblRegistrationID = (Label)row.FindControl("lblRegistrationID");
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            TextBox txtPhyVerifDate = (TextBox)row.FindControl("txtPhyVerifDate");
            TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");

            if (row.RowType == DataControlRowType.DataRow)
            {
                if (chk.Checked == true)
                {
                    if (txtRemarks.Text == "")
                    {
                        lblMsg.Text = "Please fill remark !!!!!";
                        txtRemarks.Focus();
                        return;
                    }
                    if (ddlStatus.SelectedValue == "0")
                    {
                        lblMsg.Text = "Please Select Status !!!!!";
                        ddlStatus.Focus();
                        return;
                    }

                    cmd.Parameters.Clear();
                    con.Open();
                    cmd.CommandText = @"update SocialAuditAll_PMKISAN set DAO_Status=@DAO_Status,PhyVerifDate=@PhyVerifDate , DAOActiondate=GETDATE() , DAOActionName=@DAO_ActionName,DAORemarks=@DAORemark where  RegistrationNo=@RegistrationNo ";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@DAO_ActionName", Convert.ToString(Session["UserID"]));
                    cmd.Parameters.AddWithValue("@RegistrationNo", lblRegistrationID.Text.Trim());
                    cmd.Parameters.AddWithValue("@DAO_Status", ddlStatus.SelectedValue);
                    cmd.Parameters.AddWithValue("@PhyVerifDate", txtPhyVerifDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@DAORemark", txtRemarks.Text.Trim());
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {

                        cmd.Dispose();
                        lblMsg.Text = "Record Verified Successfully";
                        gvdata.Visible = false;
                    }
                }

            }
        }
    }


    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "Please fill remark !!!!!";
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        //string RegId = gvdata.DataKeys[gvdata.SelectedIndex].Values["Registration_ID"].ToString(); //?RegId=" + RegId
        if (RegId != "")
        {
            Response.Redirect("PVDatatest.aspx?RegId=" + RegId);
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //if (gvdata.Rows.Count <= 0)
        //{
        //    ScriptManager.RegisterStartupScript(Page, GetType(), "abc", "alert('No Data To Export.');", true);
        //    return;
        //}

        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "PV_Data_" + DateTime.Now.ToString("dd MMMM yyyy") + "_DailyReport.xls"));
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //DataTable dt = new DataTable();
        BindData();
gvdata.AllowPaging = false;
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //foreach (GridViewRow row in gvdata.Rows)
        //{
        //    foreach (TableCell cell in row.Cells)
        //    {
        //        cell.CssClass = "textmode";
        //    }
        //}
        gvdata.RenderControl(htw);
        
        //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

        /* Verifies that the control is rendered */

    }
}