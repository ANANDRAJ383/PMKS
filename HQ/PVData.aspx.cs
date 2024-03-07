using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class DAO_PVData : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public DAO_PVData()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserRole"]) == "" || Convert.ToString(Session["UserRole"]) == null)
        {
            Response.Redirect("../LoginForm.aspx");
        }

        if (!IsPostBack)
        {
            BindDist(); BindBlock(); BindPanchayat();
        }
    }


    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex; BindData();
    }

    #region Function&Method
    void BindDist()
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_getDistrict", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlDist.DataTextField = "DistName";
            ddlDist.DataValueField = "DistCode";
            ddlDist.DataSource = dt;
            ddlDist.DataBind();
            ddlDist.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch
        {
        }
    }

    void BindBlock()
    {
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_GetBlock", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@DistCode", ddlDist.SelectedValue);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlBlock.DataTextField = "BlockName";
            ddlBlock.DataValueField = "BlockCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }
    }

    void BindPanchayat()
    {


        SqlDataAdapter da = new SqlDataAdapter("SP_GetPanchayat", con);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@BlockCode", ddlBlock.SelectedValue);
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
            SqlDataAdapter da = new SqlDataAdapter("SP_Get_SocialAuditAll_PMKISANDataADM", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@DistCode", ddlDist.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@BlockCode", ddlBlock.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@PanchayatCode", ddlPanchayat.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@RegId", txtRegId.Text);
            da.SelectCommand.Parameters.AddWithValue("@PhyVerifReason", ddlType.SelectedValue);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
            }
            else
            {
                //gvdata.Visible = false;
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
                        cmd.CommandText = @"update SocialAuditAll_PMKISAN set ADM_Status=@ADM_Status,PhyVerifDate=@PhyVerifDate , ADMActiondate=GETDATE() , ADMActionName=@ADM_ActionName,ADMRemarks=@ADMRemark where  RegistrationNo=@RegistrationNo ";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@ADM_ActionName", Convert.ToString(Session["UserID"]));
                        cmd.Parameters.AddWithValue("@RegistrationNo", lblRegistrationID.Text.Trim());
                        cmd.Parameters.AddWithValue("@ADM_Status", ddlStatus.SelectedValue);
                        cmd.Parameters.AddWithValue("@PhyVerifDate", txtPhyVerifDate.Text.Trim());
                        cmd.Parameters.AddWithValue("@ADMRemark", txtRemarks.Text.Trim());
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
        BindPanchayat();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        //string PMKRegId = gvdata.DataKeys[rowIndex].Values[1].ToString();
        string PhyVerifDate = gvdata.DataKeys[rowIndex].Values[1].ToString();
        WinOpen("Done.aspx?RegId=" + RegId.Trim() + "&PhyVerifDate=" + PhyVerifDate.Trim());
    }
    public void WinOpen(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=1100,height=900,align=center,toolbar=0,addressbar =0, scrollbars=yes');", msg);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "strScript", strScript, true);
        }
        catch (Exception ex) { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

        /* Verifies that the control is rendered */

    }
    void DownloadData()
    {
        try
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}",DateTime.Now.ToString("dd MMMM yyyy") + "_Report.xls"));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //DataTable dt = new DataTable();
            //BindData();
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
        catch (Exception)
        { }
    }

    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBlock();
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        DownloadData();
    }
}