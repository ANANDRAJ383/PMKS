using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class DAO_PanchayatChange : System.Web.UI.Page
{
    clsDataAccessNew cls = new clsDataAccessNew();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    DataTable dt = new DataTable();
    public DAO_PanchayatChange()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserRole"]) == "" || Convert.ToString(Session["UserRole"]) == null || Convert.ToString(Session["UserRole"]) != "DAO")
        {
            Response.Redirect("../LoginForm.aspx");
        }
        if (!IsPostBack)
        {
            FillBlock();FillPanchayat();FillVillage();
            DropDownList1_SelectedIndexChanged(sender, e);
        }

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {try
        {
            dt = cls.GetDataTable(@"SELECT Registration_ID,Farmer_FName+' '+Farmer_LName AS NAME ,Father_Husband_Name,D.DistName,B.BLOCKNAME,P.PANCHAYATNAME,V.VILLNAME,R.DistrictCode,R.BLOCKCODE,R.PANCHAYATCODE,R.VillageCode,R.CHANGESTATUS,
            CASE WHEN R.VillageCode='99' THEN r.VillName ELSE 
            (SELECT V.VILLNAME  FROM Village V WHERE V.VILLCODE=R.VillageCode) END VILLNAME
            FROM Registration R
            INNER JOIN DISTRICTS D ON R.DistrictCode=D.DISTCODE INNER JOIN BLOCKS B ON R.BlockCode=B.BLOCKCODE
            INNER JOIN PANCHAYAT P ON R.PanchayatCode=P.PANCHAYATCODE LEFT OUTER JOIN VILLAGE V
            ON R.VillageCode=V.VILLCODE WHERE Registration_ID='" + txtreg.Text.Trim() + "' and  R.DistrictCode='" + Session["DistrictCode"].ToString().Trim() + "'");
            lblMsg.Text = dt.ToString();
            if (dt.Rows.Count > 0)
            {
                DataTable dts = cls.GetDataTable("SELECT REGISTRATIONID,CHANGESTATUS FROM CHANGEREQUEST WHERE REGISTRATIONID='" + txtreg.Text.Trim() + "' and CHANGESTATUS=1");
                if (dts.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Your record(s) have been update..');", true);
                    return;
                }

                DataTable dtss = cls.GetDataTable("SELECT CHANGESTATUS FROM REGISTRATION WHERE REGISTRATION_ID='" + txtreg.Text.Trim() + "' and CHANGESTATUS=1");
                if (dtss.Rows.Count > 0)
                {

                    ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Your record(s) have been update..');", true);
                    return;

                }
                Panel1.Visible = true;
                Panel2.Visible = true;
                lblname.Text = dt.Rows[0]["NAME"].ToString();
                lblfthrname.Text = dt.Rows[0]["Father_Husband_Name"].ToString();
                lbldist.Text = dt.Rows[0]["DistName"].ToString();
                lblblock.Text = dt.Rows[0]["BLOCKNAME"].ToString();
                lblpanchayat.Text = dt.Rows[0]["PANCHAYATNAME"].ToString();
                lblvillage.Text = dt.Rows[0]["VILLNAME"].ToString();
                ViewState["distcode"] = dt.Rows[0]["DistrictCode"].ToString();
                ViewState["blockcode"] = dt.Rows[0]["BLOCKCODE"].ToString();
                ViewState["panchayatcode"] = dt.Rows[0]["PANCHAYATCODE"].ToString();
                ViewState["VILLCODE"] = dt.Rows[0]["VillageCode"].ToString();
                FillBlock();
                DropDownList1_SelectedIndexChanged(sender, e);
                //  DropDownList2_SelectedIndexChanged(sender, e);
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = ee.Message;
        }
    }
    void FillBlock()
    {
        try
        {
            dt = cls.GetDataTable("SELECT BLOCKNAME,BLOCKCODE FROM BLOCKS WHERE distCODE='" + Session["DistrictCode"].ToString() + "'");
            if (dt.Rows.Count > 0)
            {
                DropDownList1.DataTextField = "BLOCKNAME";
                DropDownList1.DataValueField = "BLOCKCODE";
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
                // DropDownList1.Enabled = false;
            }
        }
        catch (Exception ex) { lblMsg.Text = ex.Message; }
    }
    void FillPanchayat()
    {
        try
        {
            dt = cls.GetDataTable("SELECT PANCHAYATNAME,PANCHAYATCODE FROM PANCHAYAT WHERE BLOCKCODE='" + DropDownList1.SelectedValue + "'");
            if (dt.Rows.Count > 0)
            {
                DropDownList2.DataTextField = "PANCHAYATNAME";
                DropDownList2.DataValueField = "PANCHAYATCODE";
                DropDownList2.DataSource = dt;
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        catch (Exception ex) { lblMsg.Text = ex.Message; }
    }
    void FillVillage()
    {
        try
        {
            dt = cls.GetDataTable("SELECT VILLNAME,VILLCODE FROM VILLAGE WHERE PANCHAYATCODE='" + DropDownList2.SelectedValue + "'");
            if (dt.Rows.Count > 0)
            {
                DropDownList3.DataTextField = "VILLNAME";
                DropDownList3.DataValueField = "VILLCODE";
                DropDownList3.DataSource = dt;
                DropDownList3.DataBind();
                DropDownList3.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        catch (Exception ex) { lblMsg.Text = ex.Message; }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPanchayat();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillVillage();
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            
	    DataTable dts = cls.GetDataTable("SELECT CHANGESTATUS FROM REGISTRATION WHERE REGISTRATION_ID='" + txtreg.Text.Trim() + "' and CHANGESTATUS=1");
            if (dts.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Your record(s) have been update..');", true);
                return;
            }
            
            string insertquery = @"update Registration set BlockCode='" + DropDownList1.SelectedValue + "', PanchayatCode = '" + DropDownList2.SelectedValue + "',  VillageCode = '" +DropDownList3.SelectedValue+ "', VillName = '" +DropDownList3.SelectedItem.Text+ "', CHANGESTATUS = 1, CHANGESTATUSDATE = getdate() where Registration_Id = '" + txtreg.Text.Trim() + "'";

            
            cmd.Connection = con;
            cmd.CommandText = insertquery;
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result > 0)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Panchayat Name/ Village Name Updated Successfully!!');", true);
                txtreg.Text = "";
                txtreg.Focus();
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
        }
        catch (Exception ex) { lblMsg.Text = ex.Message; }
    }
    #region
   
    #endregion
}