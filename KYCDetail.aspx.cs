using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class AC_KYCDetail : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    int set = 0;
    string Pcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Pcode"] != null && Request.QueryString["Pcode"] != string.Empty)
        {
            Pcode = Request.QueryString["Pcode"].ToString();
        }
        //if (!IsPostBack)
        //{
        //   BindData();
        //}
        if (!this.IsPostBack)
        {
            BindHtmlTable();
        }   
    }
    protected void gvdata_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gvdata.PageIndex = e.NewPageIndex;
        //BindData();
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
                lblMsg.Text = dt.Rows.Count + ",Records";
                //gvdata.DataSource = dt;
                //gvdata.DataBind();
                //gvdata.Visible = true;
                //btnSave.Visible = true;
            }
            else
            {
                //gvdata.Visible = false;
                btnSave.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblMsg.Text = "Record Not available !!!!!";
            }

        }
        catch
        { }
    }

    void BindHtmlTable()
    {
        //Populating a DataTable from database.
        DataTable dt = this.BindData1();

        //Building an HTML string.
        StringBuilder html = new StringBuilder();

        //Table start.
        html.Append("<table border = '1'>");

        //Building the Header row.
        html.Append("<tr>");
        foreach (DataColumn column in dt.Columns)
        {
            
            html.Append("<th>");    
            html.Append(column.ColumnName);
            html.Append("</th>");
        }
        html.Append("</tr>");

        //Building the Data rows.
        foreach (DataRow row in dt.Rows)
        {
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<td>");
                html.Append(row[column.ColumnName]);
                html.Append("</td>");
            }
            html.Append("</tr>");
        }

        //Table end.
        html.Append("</table>");

        //Append the HTML string to Placeholder.
        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    }
    private DataTable BindData1()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetEKYCData");
        objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode";
        objcls.storeProcedure.FieldValue = new object[] { 0, 0, Pcode };
        DataTable dt = objcls.storeProcedure.getData();
        return dt;
    }

    void Verify()
    {
        //try
        //{
           
        //    foreach (GridViewRow row in gvdata.Rows)
        //    {
        //        CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
        //        Label lblRegistrationID = (Label)row.FindControl("lblRegistrationID");
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {
        //            if (chk.Checked == true)
        //            {
        //                objcls.storeProcedure.NewStoreProcedure("SP_UpdateEKYCRecord");
        //                objcls.storeProcedure.AddWithValue("UpdatedBy", Convert.ToString(Session["UserID"]));
        //                objcls.storeProcedure.AddWithValue("BiharRegNo", lblRegistrationID.Text.Trim());
        //                if (objcls.storeProcedure.ExecuteNonQuery())
        //                {
        //                    set++;
        //                }

        //            }

        //        }
        //    }
        //    if (set > 0)
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(" + set + "'+Data Verified Successfully');", true);
        //        lblMsg.Text = "Out of " + lblMsg.Text + "," + set + ",Record Verified Successfully";
        //        //BindData();
        //        gvdata.Visible = false;
        //        btnSave.Visible = false;
        //    }

        //}
        //catch
        //{

        //}
    }

    #endregion

    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData();
    }
   

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        //CheckBox chkAll = (CheckBox)sender;
        //if (chkAll.Checked)
        //{
        //    CheckBox chkDetails = null;

        //    foreach (GridViewRow gvr in gvdata.Rows)
        //    {
        //        chkDetails = (CheckBox)gvr.FindControl("chkDetails");
        //        chkDetails.Checked = true;
        //    }
        //}

        //else
        //{
        //    foreach (GridViewRow gvr in gvdata.Rows)
        //    {
        //        CheckBox chkDetails = (CheckBox)gvr.FindControl("chkDetails");
        //        chkDetails.Checked = false;
        //    }
        //}
    }

    protected void bnSave_Click(object sender, EventArgs e)
    {
        //Verify();
    }
}