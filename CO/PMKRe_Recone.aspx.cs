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
    void checkAadhaar()
    {
        DataTable dtA = objcls.GetDataTable("select count(*) from Registration_PMKISAN_New p inner join Registration r on r.Registration_ID = p.Registration_ID where r.AadhaarNumber = '" + txiIdentityNo.Text.Trim() + "'");
        if (dtA.Rows.Count > 0)
        {
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('योजना की मार्गदर्शिका के अनुसार किसान योजना के पात्र नहीं है |  ........');", true);
            lblMsg.Text = "योजना की मार्गदर्शिका के अनुसार किसान योजना के पात्र नहीं है |........";
            return;
        }
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
        if (rb3.SelectedValue == "1")
        {

            if (ddlLandTransferDetail.SelectedValue == "0")
            {
                lblMsg.Text = "Please Select Land Transfer Detail !!!!!";
                return;
            }
            if (txiIdentityNo.Text == "")
            {
                lblMsg.Text = "Please fill Aadhaar no !!!!!";
                return;
            }
            if (txiIdentityNo.Text != "")
            {
                checkAadhaar();
            }
            if (txtMutationDate.Text == "")
            {
                lblMsg.Text = "Please Select land Mutation Date !!!!!";
                return;
            }
        }
        cmd.Parameters.Clear();
        con.Open();
        cmd.CommandText = @"update Registration_PMKISAN_New set LandMutationDate=@LandMutationDate,LandTranferDetail=@LandTranferDetail , IdentitiyNo=IdentitiyNo , IdentitiyType=@IdentitiyType,CO_ActionName=@CO_ActionName,CO_ActionDate=getdate(),CODocVerify=@CODocVerify,CODocRecent=@CODocRecent,COApprove=@COApprove,CO_Status=@CO_Status,CO_Remarks=@CO_Remarks where  Registration_ID=@Registration_ID and ApplicationType=@ApplicationType";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        cmd.Parameters.AddWithValue("@CO_ActionName", Convert.ToString(Session["UserID"]));
        cmd.Parameters.AddWithValue("@Registration_ID", RegId);
        cmd.Parameters.AddWithValue("@ApplicationType", "NEW");
        cmd.Parameters.AddWithValue("@LandMutationDate", txtMutationDate.Text.Trim());
        cmd.Parameters.AddWithValue("@LandTranferDetail", ddlLandTransferDetail.SelectedValue);
        cmd.Parameters.AddWithValue("@IdentitiyNo", txiIdentityNo.Text.Trim());
        cmd.Parameters.AddWithValue("@IdentitiyType",ddlIdertity.SelectedValue);
        cmd.Parameters.AddWithValue("@CODocVerify", "YES");
        cmd.Parameters.AddWithValue("@CODocRecent", "YES");
        cmd.Parameters.AddWithValue("@COApprove", "YES");
        cmd.Parameters.AddWithValue("@CO_Status", rb3.SelectedValue);
        cmd.Parameters.AddWithValue("@CO_Remarks", txtRemarks.Text);
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

    protected void ddlLandTransferDetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLandTransferDetail.SelectedValue == "3" || ddlLandTransferDetail.SelectedValue == "4" || ddlLandTransferDetail.SelectedValue == "5")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "kk", "alert('केंद्र स्तर से स्पष्ट निर्णय प्राप्त नहीं होने के कारण अभी इस आवेदन पर निर्णय नहीं लिया जा सकता है एवं आवेदन मुख्यालय स्तर पर नहीं भेजा जा सकता है ।........');", true);
            lblMsg.Text = "केंद्र स्तर से स्पष्ट निर्णय प्राप्त नहीं होने के कारण अभी इस आवेदन पर निर्णय नहीं लिया जा सकता है एवं आवेदन मुख्यालय स्तर पर नहीं भेजा जा सकता है |........";
            return;
        }
    }
}