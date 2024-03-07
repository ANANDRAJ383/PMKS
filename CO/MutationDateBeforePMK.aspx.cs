using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class CO_PMKNEW : System.Web.UI.Page
{
    string PhyVerifDate = "";
    string RegId = "";
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand(); SqlCommand cmd2 = new SqlCommand();
    string Datefile = DateTime.UtcNow.AddHours(5).AddMinutes(30).AddMilliseconds(10).ToString("ddMMyyyy");
    public CO_PMKNEW()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {if (Convert.ToString(Session["DistrictCode"]) == "" || Convert.ToString(Session["UserRole"]) != "CO")
        {
            Response.Redirect("../LoginForm.aspx");
        }
        RegId = Request.QueryString["RegId"].ToString();
        lblRegId.Text = "Registration Id :-" + RegId; //PhyVerifDate
        if(!IsPostBack)
        {
            BindLand();
        }

    }
    void BindLand()
    {
        try
        {btnUpdate.Visible = true;
            objcls.storeProcedure.NewStoreProcedure("SP_GetLandDetailPMKSRegistrationID");
            objcls.storeProcedure.FieldName = "RegistrationID";
            objcls.storeProcedure.FieldValue = new object[] { RegId };
            DataTable dt = objcls.storeProcedure.getData();
            if(dt.Rows.Count>0)
            {
                lblDistLand.Text = dt.Rows[0]["DistName"].ToString().Trim();
                lblCircle.Text = dt.Rows[0]["Circle_Name"].ToString().Trim();
                lblHalka.Text = dt.Rows[0]["Halka_Name"].ToString().Trim();
                lblMoja.Text = dt.Rows[0]["Mauja_Name"].ToString().Trim();
                lblVolumeNo.Text = dt.Rows[0]["VolumeNo"].ToString().Trim();
                lblPageNo.Text = dt.Rows[0]["PageNo"].ToString().Trim();
                txtKhataNo.Text = dt.Rows[0]["khata_no"].ToString().Trim();
                txtKheraNo.Text = dt.Rows[0]["KhesraNo"].ToString().Trim();
                txtLandAkers.Text = dt.Rows[0]["LandAker"].ToString().Trim();
                txtxLandDismil.Text = dt.Rows[0]["LandDismil"].ToString().Trim();
                if(txtKhataNo.Text=="0" || txtKhataNo.Text == "" || txtKheraNo.Text == "0" || txtKheraNo.Text == "")
                {
                    
                    bnSave.Visible = false;
                }
                else
                {
                    bnSave.Visible = true;
                    btnUpdate.Visible = false;
                }
            }

        }
        catch (Exception ee)
        {

        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }

    protected void bnSave_Click(object sender, EventArgs e)
    {
        if (rb3.SelectedValue == "1")
        {
            if (rb3.SelectedValue == "")
            {
                lblMsg.Text = "Please Select Application Status !!!!!";
                return;
            }
            
            if (txtKhataNo.Text == "0" || txtKheraNo.Text == "0")
            {
                lblMsg.Text = "Please fill खाता संख्या / खेसरा संख्या  । ";
                return;
            }
        }
        
        cmd.Parameters.Clear();
        con.Open();
        cmd.CommandText = @"update Registration_PMKISAN_New set CO_ActionName=@CO_ActionName,CO_ActionDate=getdate(),CODocVerify=@CODocVerify,CODocRecent=@CODocRecent,COApprove=@COApprove,CO_Status=@CO_Status,CO_Remarks=@CO_Remarks where  Registration_ID=@Registration_ID and ApplicationType=@ApplicationType";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@CO_ActionName", Convert.ToString(Session["UserID"]));
        cmd.Parameters.AddWithValue("@Registration_ID", RegId);
        //cmd.Parameters.AddWithValue("@LandMutationDate", txtMutationDate.Text.Trim());
        cmd.Parameters.AddWithValue("@CODocVerify", "YES");
        cmd.Parameters.AddWithValue("@CODocRecent", "YES");
        cmd.Parameters.AddWithValue("@COApprove", "YES");
        cmd.Parameters.AddWithValue("@CO_Status", rb3.SelectedValue);
        cmd.Parameters.AddWithValue("@CO_Remarks", txtRemarks.Text);
        cmd.Parameters.AddWithValue("@ApplicationType", "NEW");
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {

            cmd.Dispose();
            lblMsg.Text = "Record Verified Successfully";
            //txtMutationDate.Text = "";

        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        //==================File Upload====================================
        string LPCDocument = objcls.UploadPDF(fuDOC, "/LPCPMKIsaan_CoLogin/"+ Datefile + "/" + RegId + "/");
        ViewState["LPCDocument"] = LPCDocument;
        if (LPCDocument == "~" || LPCDocument == "Please Select jpeg File Only")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Select  LPC Document ;", true);
            return;
        }
        if (LPCDocument == "File Size Large")
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Photo Size 150KB Exceed ;", true);
            return;
        }
        //=========================================================================

        con.Open();
        cmd2.Parameters.Clear();
        cmd2.CommandText = @"update tbl_PMKIsan_LandDetails set  Circle=@Circle, Halka=@Halka, Mauja@Mauja, VolumeNo=@VolumeNo, PageNo=@PageNo, khata_no=@khata_no, KhesraNo=@KhesraNo, LandAker=@LandAker, LandDismil=@LandDismil, OwnerName=@OwnerName, EntryDate=getdate(),DocPath=@DocPath where RegistrationID=@RegistrationID";
        cmd2.CommandType = CommandType.Text;
        cmd2.Connection = con;
        cmd2.Parameters.AddWithValue("@RegistrationID", RegId);
        cmd2.Parameters.AddWithValue("@Circle", lblCircle.Text.Trim());
        cmd2.Parameters.AddWithValue("@Halka", lblHalka.Text.Trim());
        cmd2.Parameters.AddWithValue("@Mauja", lblMoja.Text.Trim());
        cmd2.Parameters.AddWithValue("@VolumeNo", lblVolumeNo.Text.Trim());
        cmd2.Parameters.AddWithValue("@PageNo", lblPageNo.Text.Trim());
        cmd2.Parameters.AddWithValue("@khata_no", txtKhataNo.Text);
        cmd2.Parameters.AddWithValue("@KhesraNo", txtKheraNo.Text.Trim());
        cmd2.Parameters.AddWithValue("@LandAker", txtLandAkers.Text.Trim());
        cmd2.Parameters.AddWithValue("@LandDismil", txtxLandDismil.Text.Trim());
        cmd2.Parameters.AddWithValue("@OwnerName", txtOwnerName.Text.Trim());
        cmd2.Parameters.AddWithValue("@DocPath", ViewState["LPCDocument"].ToString());
        int ii = cmd2.ExecuteNonQuery();
        if (ii > 0)
        {
            cmd2.Dispose();
            cmd.Parameters.Clear();
            //con.Open();
            cmd.CommandText = @"update Registration_PMKISAN_New set CO_ActionName=@CO_ActionName,CO_ActionDate=getdate(),CODocVerify=@CODocVerify,CODocRecent=@CODocRecent,COApprove=@COApprove,CO_Status=@CO_Status where  Registration_ID=@Registration_ID and ApplicationType=@ApplicationType";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@CO_ActionName", Convert.ToString(Session["UserID"]));
            cmd.Parameters.AddWithValue("@Registration_ID", RegId);
            //cmd.Parameters.AddWithValue("@LandMutationDate", txtMutationDate.Text.Trim());
            cmd.Parameters.AddWithValue("@CODocVerify", "YES");
            cmd.Parameters.AddWithValue("@CODocRecent", "YES");
            cmd.Parameters.AddWithValue("@COApprove", "YES");
            cmd.Parameters.AddWithValue("@CO_Status", rb3.SelectedValue);
            cmd.Parameters.AddWithValue("@ApplicationType", "NEW");
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i>0)
            {
                cmd2.Dispose();
                lblMsg.Text = "Record Verified Successfully";
                //txtMutationDate.Text = "";
            }

        }

    }
}