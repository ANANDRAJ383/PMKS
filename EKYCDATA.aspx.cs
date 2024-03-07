using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class EKYCDATA : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    int set = 0;
    string Pcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Pcode"] != null && Request.QueryString["Pcode"] != string.Empty)
        {
            Pcode = Request.QueryString["Pcode"].ToString();
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdata.PageIndex = e.NewPageIndex;
        BindData();
    }

    #region Function&Method




    void BindData()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetEKYCData");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode";
            objcls.storeProcedure.FieldValue = new object[] { 0, 0, Pcode };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                //lblMsg.Text = "Panchayat--" + dt.Rows[0]["PanchayatName"].ToString() + ',' + dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                btnSave.Visible = true;
                btnExport.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
                btnSave.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblMsg.Text = "Record Not available !!!!!";
                btnExport.Visible = false;
            }

        }
        catch
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
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chk.Checked == true)
                    {
                        objcls.storeProcedure.NewStoreProcedure("SP_UpdateEKYCRecord");
                        objcls.storeProcedure.AddWithValue("UpdatedBy", Convert.ToString(Session["UserID"]));
                        objcls.storeProcedure.AddWithValue("BiharRegNo", lblRegistrationID.Text.Trim());
                        if (objcls.storeProcedure.ExecuteNonQuery())
                        {
                            set++;
                        }

                    }

                }
            }
            if (set > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(" + set + "'+Data Verified Successfully');", true);
                lblMsg.Text = "Out of " + lblMsg.Text + "," + set + ",Record Verified Successfully";
                //BindData();
                gvdata.Visible = false;
                btnSave.Visible = false;
            }

        }
        catch
        {

        }
    }

    #endregion

   

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        if (chkAll.Checked)
        {
            CheckBox chkDetails = null;

            foreach (GridViewRow gvr in gvdata.Rows)
            {
                chkDetails = (CheckBox)gvr.FindControl("chkDetails");
                chkDetails.Checked = true;
            }
        }

        else
        {
            foreach (GridViewRow gvr in gvdata.Rows)
            {
                CheckBox chkDetails = (CheckBox)gvr.FindControl("chkDetails");
                chkDetails.Checked = false;
            }
        }
    }

    protected void bnSave_Click(object sender, EventArgs e)
    {
        Verify();
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
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", lblMsg.Text+"EkycData_" + DateTime.Now.ToString("dd MMMM yyyy") + ".xls"));
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
    public override void VerifyRenderingInServerForm(Control control)
    {

        /* Verifies that the control is rendered */

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetEKYCData");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode,Name";
            objcls.storeProcedure.FieldValue = new object[] { 0, 0, Pcode,txtName.Text.Trim() };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                btnSave.Visible = true;
                btnExport.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
                btnSave.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblMsg.Text = "Record Not available !!!!!";
                btnExport.Visible = false;
            }

        }
        catch
        { }
    }
}