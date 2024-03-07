using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class DAO_UpdateVillage : System.Web.UI.Page
{
    clsDataAccessPMKisanPMKISANDB objcls = new clsDataAccessPMKisanPMKISANDB();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public DAO_UpdateVillage()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBlock(); BindPanchayat();
        }
    }
    #region Function&Method


    void BindBlock()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
            objcls.storeProcedure.FieldName = "DistCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]) };
            DataTable dt = objcls.storeProcedure.getData();
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

    void BindPanchayat()
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetPanchayat");
        objcls.storeProcedure.FieldName = "BlockCode";
        objcls.storeProcedure.FieldValue = new object[] { ddlBlock.SelectedValue };
        DataTable dt = objcls.storeProcedure.getData();
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
            objcls.storeProcedure.NewStoreProcedure("SP_GetDatatbl_PMKisan_LandSeeding_No_ForVillageUpdate");
            objcls.storeProcedure.FieldName = "DistCode,BlockCode,PanchayatCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]), ddlBlock.SelectedValue, ddlPanchayat.SelectedValue};
            DataTable dt = objcls.storeProcedure.getData();
           
            if (dt.Rows.Count > 0)
            {
               
                lblMsg.Text = dt.Rows.Count + ",Records";
                gvdata.DataSource = dt;
                gvdata.DataBind();
                gvdata.Visible = true;
                btnSave.Visible = true;
            }
            else
            {
                gvdata.Visible = false;
                btnSave.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblMsg.Text = "Record Not available !!!!!";
            }

        }
        catch(Exception ee)
        { Response.Write(ee.Message); }
    }

    void Verify()
    {
        try
        {
            int set = 0;
            foreach (GridViewRow row in gvdata.Rows)
            {
                CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
                Label lblRegistrationID = (Label)row.FindControl("lblRegistrationID");
                Label lblPanchayatCode = (Label)row.FindControl("lblPanchayatCode");
                DropDownList ddlVillage = (DropDownList)row.FindControl("ddlVillage");
                //if(ddlVillage.SelectedValue=="0")
               // {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Village...');", true);
                   // lblMsg.Text = "Please select Village....";
                   // return;
                //}
                if (row.RowType == DataControlRowType.DataRow)
                {
                    if (chk.Checked == true)
                    {
                        cmd.Parameters.Clear();
                        con.Open();
                        cmd.CommandText = @"update Registration_PMKISAN_New set VillCode=@VillCode,VillageName=@VillageName,ActionDate=getdate() where  Registration_ID=@Registration_ID and PanchayatCode=@PanchayatCode";
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@VillCode", ddlVillage.SelectedValue);
                        cmd.Parameters.AddWithValue("@VillageName", ddlVillage.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Registration_ID", lblRegistrationID.Text);
                        cmd.Parameters.AddWithValue("@PanchayatCode", lblPanchayatCode.Text);
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            set++;
                        }

                    }
                }
            }
            if (set > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert(" + set + "'+Data Saved Successfully');", true);
                lblMsg.Text = "Out of " + lblMsg.Text + "," + set + ",Record Saved Successfully";
                //BindData();
                gvdata.Visible = false; btnSave.Visible = false;
            }

        }
        catch (Exception ee)
        {
            Response.Write(ee.Message);
        }
    }

    #endregion

    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        
        BindData();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        BindData();
    }
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
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select at least one record');", true);
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

    protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            DataRowView gData = (DataRowView)e.Row.DataItem;

            Label lblPanchayatCode = (Label)e.Row.FindControl("lblPanchayatCode");
            DropDownList ddlVillage = (DropDownList)e.Row.FindControl("ddlVillage");
            objcls.storeProcedure.NewStoreProcedure("SP_GetVillage");
            objcls.storeProcedure.FieldName = "DistCode,PanCode";
            objcls.storeProcedure.FieldValue = new object[] { Convert.ToInt32(Session["DistrictCode"]),lblPanchayatCode.Text };
            DataTable dtV = objcls.storeProcedure.getData();
            ddlVillage.DataTextField = "VILLNAME";
            ddlVillage.DataValueField = "VILLCODE";
            ddlVillage.DataSource = dtV;
            ddlVillage.DataBind();
            ddlVillage.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Verify();
    }
}