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
    SqlCommand cmd = new SqlCommand();
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
        

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }

    protected void bnSave_Click(object sender, EventArgs e)
    {
        if (rb3.SelectedValue == "")
        {
            lblMsg.Text = "Please Select Application Status !!!!!";
            return;
        }
        if (ddlLandTransferDetail.SelectedValue == "0")
        {
            lblMsg.Text = "Please Select Land Transfer Detail !!!!!";
            return;
        }
        if(txiIdentityNo.Text=="")
        {
            lblMsg.Text = "Please fill any identity no !!!!!";
            return;
        }
        if(txtMutationDate.Text=="")
        {
            lblMsg.Text = "Please Select land Mutation Date !!!!!";
            return;
        }
        cmd.Parameters.Clear();
        con.Open();
        cmd.CommandText = @"update Registration_PMKISAN_New set LandMutationDate=@LandMutationDate,LandTranferDetail=@LandTranferDetail , IdentitiyNo=IdentitiyNo , IdentitiyType=@IdentitiyType,CO_ActionName=@CO_ActionName,CO_ActionDate=getdate(),CODocVerify=@CODocVerify,CODocRecent=@CODocRecent,COApprove=@COApprove,CO_Status=@CO_Status where  Registration_ID=@Registration_ID ";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@CO_ActionName", Convert.ToString(Session["UserID"]));
        cmd.Parameters.AddWithValue("@Registration_ID", RegId);
        cmd.Parameters.AddWithValue("@LandMutationDate", txtMutationDate.Text.Trim());
        cmd.Parameters.AddWithValue("@LandTranferDetail", ddlLandTransferDetail.SelectedValue);
        cmd.Parameters.AddWithValue("@IdentitiyNo", txiIdentityNo.Text.Trim());
        cmd.Parameters.AddWithValue("@IdentitiyType",ddlIdertity.SelectedValue);
        cmd.Parameters.AddWithValue("@CODocVerify", "YES");
        cmd.Parameters.AddWithValue("@CODocRecent", "YES");
        cmd.Parameters.AddWithValue("@COApprove", "YES");
        cmd.Parameters.AddWithValue("@CO_Status", rb3.SelectedValue);
        int i = cmd.ExecuteNonQuery();
        if (i > 0)
        {

            cmd.Dispose();
            lblMsg.Text = "Record Verified Successfully";
            txtMutationDate.Text = "";
            txiIdentityNo.Text = "";
            ddlLandTransferDetail.SelectedValue = "0";

        }
    }
}