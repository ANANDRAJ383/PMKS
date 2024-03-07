using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class ADM_ReconcileList : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    clsDataAccessNewPMK clsNew = new clsDataAccessNewPMK();
    public ADM_ReconcileList()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["Userrole"]) != "DAO")
        {
            Response.Redirect("~/PMKISANAdmin/Login.aspx", true);
        }
        if (!IsPostBack)
        {
            BindDistrict();BindBlock();BindPanchayat(); 
        }

    }
    void BindReport()
    {
        try
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SP_Get_SocialAuditAll_PMKISANData", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@DistCode", Convert.ToInt32(Session["DistrictCode"]));
            da.SelectCommand.Parameters.AddWithValue("@BlockCode", ddlBlock.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@PanchayatCode", ddlPanchayat.SelectedValue);
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
                gvdata.Visible = false;
		        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Data Not Available.!');", true);
            }

        }
        catch (Exception ee)
        { lblMsg.Text = ee.Message; }
    }

    void BindDistrict()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetDistrict");
            DataTable dt = objcls.storeProcedure.getData();
            ddlDistrict.DataTextField = "DistName";
            ddlDistrict.DataValueField = "DistCode";
            ddlDistrict.DataSource = dt;
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("--All--", "0"));
            if( Session["DistrictCode"].ToString()!="")
            {
                ddlDistrict.SelectedValue =Session["DistrictCode"].ToString();
                ddlDistrict.Enabled = false;
            }
        }
        catch
        {
        }
    }

    void BindBlock()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]) };
            DataTable dt = objcls.storeProcedure.getData();
            ddlBlock.DataTextField = "BlockName";
            ddlBlock.DataValueField = "BlockCode";
            ddlBlock.DataSource = dt;
            ddlBlock.DataBind();
            ddlBlock.Items.Insert(0, new ListItem("--All--", "0"));
            if (Session["BlockCode"].ToString() != "")
            {
                ddlBlock.SelectedValue = Session["BlockCode"].ToString();
                ddlBlock.Enabled = false;
            }
        }
        catch
        {
        }
    }

    void BindPanchayat()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetPanchayat");
        objcls.storeProcedure.FieldName = "BlockCode";
        objcls.storeProcedure.FieldValue = new object[] { ddlBlock.SelectedValue };
        DataTable dt = objcls.storeProcedure.getData();
        ddlPanchayat.DataTextField = "PanchayatName";
        ddlPanchayat.DataValueField = "PanchayatCode";
        ddlPanchayat.DataSource = dt;
        ddlPanchayat.DataBind();
        ddlPanchayat.Items.Insert(0, new ListItem("--All--", "0"));
    }
    protected void btnViewDetail_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "Please fill remark !!!!!";
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        //string RegId = gvdata.DataKeys[gvdata.SelectedIndex].Values["Registration_ID"].ToString(); //?RegId=" + RegId
        if (RegId != "")
        {
            Verify();
            //Response.Redirect("PVDatatest.aspx?RegId=" + RegId);
        }
    }
    protected void gvdata_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;

        if ((gv.ShowHeader == true && gv.Rows.Count > 0)
            || (gv.ShowHeaderWhenEmpty == true))
        {
            //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
            gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        if (gv.ShowFooter == true && gv.Rows.Count > 0)
        {
            //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
            gv.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if(ddlType.SelectedValue=="0")
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select type ..!');", true);
            return;
        }
        BindReport(); 
    }

    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat(); gvdata.Visible = false;ddlPanchayat.SelectedValue = "0";
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBlock(); gvdata.Visible = false;
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
        catch (Exception ee)
        {
            lblMsg.Text = ee.Message;
        }
    }


    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvdata.Visible = false;
    }
}