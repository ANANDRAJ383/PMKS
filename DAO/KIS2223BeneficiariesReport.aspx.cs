using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class DAO_KIS2223BeneficiariesReport : System.Web.UI.Page
{
    string q = "";
    SqlConnection con = new SqlConnection();
    clsDataAccessDiesel objcls = new clsDataAccessDiesel();
    public DAO_KIS2223BeneficiariesReport()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindBlock();

        }
    }
    void BindBlock()
    {
        try
        {
            q = "select distinct blockcode,blockname from input2223_onlineapply where distcode='"+ Convert.ToInt32(Session["DistrictCode"]) + "'";
            DataTable dt = objcls.GetDataTable(q);
            if(dt.Rows.Count>0)
            {
                ddlblock.Items.Clear();
                ddlblock.DataSource = dt;
                ddlblock.DataTextField = "blockname";
                ddlblock.DataValueField = "blockcode";
                ddlblock.DataBind();
                ddlblock.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        catch(DataException ex)
        {
        }
    }
    void BindPanchayat()
    {
        try
        {
            q = "select distinct panchayatcode,panchayatname from input2223_onlineapply where blockcode='" + ddlblock.SelectedValue +"'";
            DataTable dt = objcls.GetDataTable(q);
            if (dt.Rows.Count > 0)
            {
                ddlpanchayat.Items.Clear();
                ddlpanchayat.DataSource = dt;
                ddlpanchayat.DataTextField = "panchayatname";
                ddlpanchayat.DataValueField = "panchayatcode";
                ddlpanchayat.DataBind();
                ddlpanchayat.Items.Insert(0, new ListItem("--All--", "0"));
            }
        }
        catch (DataException ex)
        {
        }
    }
    void BindGrid()
    {
        try
        {
            q = @"select application_id,ApplicantName,Father_Husband_Name,Blockname,panchayatname,VillageName,ADM_ApprovedAmnt
               from input2223_onlineapply where blockcode='" + ddlblock.SelectedValue + "' and panchayatcode='" + ddlpanchayat.SelectedValue + "' and sendtobank=1 and DAO_Status=1 and ADM_Status=1";
            DataTable dt = objcls.GetDataTable(q);
            if (dt.Rows.Count > 0)
            {
                ImageButton1.Visible = true;
                gvdata.DataSource = dt;
                gvdata.DataBind();
            }
            else
            {
                ImageButton1.Visible = false;
                gvdata.DataSource = null;
                gvdata.DataBind();
            }
        }
        catch (Exception ex) { }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (ddlblock.SelectedValue == "0")
            {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kindly select Block Name..');", true);
            ddlblock.Focus();
            }
        if (ddlpanchayat.SelectedValue == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kindly select Panchayat Name..');", true);
            ddlpanchayat.Focus();
        }
        BindGrid();
    }
    protected void ddlblock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat();
    }

    void Export1()
    {

        Response.ClearContent();
        Response.Buffer = true;
        string FileName = "KIS2223"+ddlblock.SelectedItem.Text + DateTime.Now + ".xls";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        gvdata.AllowPaging = false;
        //Change the Header Row back to white color
        gvdata.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Applying stlye to gridview header cells
        for (int i = 0; i < gvdata.HeaderRow.Cells.Count; i++)
        {
            gvdata.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
        }
        int j = 1;
        //This loop is used to apply stlye to cells based on particular row
        foreach (GridViewRow gvrow in gvdata.Rows)
        {
            gvrow.BackColor = System.Drawing.Color.White;
            if (j <= gvdata.Rows.Count)
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
        gvdata.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Export1();
    } 
}