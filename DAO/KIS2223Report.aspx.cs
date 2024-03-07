using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.IO;

public partial class DAO_KIS2223Report : System.Web.UI.Page
{
    string q = "";
       SqlConnection con = new SqlConnection();
    clsDataAccessDiesel objcls = new clsDataAccessDiesel();
    public DAO_KIS2223Report()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlItems.SelectedValue == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kindly select one value ...');", true);
            ddlItems.Focus();
        }
        if (ddlItems.SelectedValue == "1")
        {
             q = "select [Application_ID],[ApplicantName],[Father_Husband_Name],[Blockname],[panchayatname],[VillageName] from input2223_onlineapply where distcode ='" + Session["DistrictCode"] + "' and dao_status =1 and ADM_Status=1 ";
        }
        else if (ddlItems.SelectedValue == "2")
        {
            q = "select [Application_ID],[ApplicantName],[Father_Husband_Name],[Blockname],[panchayatname],[VillageName] from input2223_onlineapply where distcode ='" + Session["DistrictCode"] + "' and dao_status =1 and ADM_Status=2";
        }
        DataTable dt = objcls.GetDataTable(q);
        if (dt.Rows.Count > 0)
        {
            gdview1.DataSource = dt;
            gdview1.DataBind();
            ImageButton1.Visible = true;
        }
        else
        {
            gdview1.DataSource = null;
            gdview1.DataBind();
            ImageButton1.Visible = false;
        }
    }
    void Export1()
    {

        Response.ClearContent();
        Response.Buffer = true;
        string FileName = ddlItems.SelectedItem.Text + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gdview1.AllowPaging = false;
        //Change the Header Row back to white color
        gdview1.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Applying stlye to gridview header cells
        for (int i = 0; i < gdview1.HeaderRow.Cells.Count; i++)
        {
            gdview1.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
        }
        int j = 1;
        //This loop is used to apply stlye to cells based on particular row
        foreach (GridViewRow gvrow in gdview1.Rows)
        {
            gvrow.BackColor = System.Drawing.Color.White;
            if (j <= gdview1.Rows.Count)
            {
                if (j % 2 != 0)
                {
                    for (int k = 0; k < gvrow.Cells.Count; k++)
                    {
                        gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                    }
                }
            }
            j++;
        }
        gdview1.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void ddlItems_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Export1();
    }
}