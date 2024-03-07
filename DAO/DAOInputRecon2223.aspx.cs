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
using esms_client;

public partial class DAO_DAOInputRecon2223 : System.Web.UI.Page
{
    SMSHttpPostClient sms = new SMSHttpPostClient();
    SqlConnection con = new SqlConnection();
    clsDataAccessDiesel objcls = new clsDataAccessDiesel();
    public DAO_DAOInputRecon2223()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserRole"]) != "DAO" || Convert.ToString(Session["UserRole"]) == "")
        {
            Response.Redirect("../LoginForm.aspx");
        }
        lblDistrict.Text = Convert.ToString(Session["DistrictName"]);
        if (!IsPostBack)
        {

            BindBlock();
            BindPanchayat();
            DaoUpate();
            DaoUpateACRejected();
            ExcuteFuncation();

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
    void BindGridview()
    {
        string Panchayat = "";
        try
        {
            if (ddlPanchayat.SelectedValue == "0")
            {
                Panchayat = "";
            }
            else
            {
                Panchayat = "and a.PanchayatCode='" + ddlPanchayat.SelectedValue + "'";
            }
            DataTable dtgdview = new DataTable();
            string query = @"SELECT Distinct a.Registration_ID,aa.Application_ID,a.ApplicantName,a.Father_Husband_Name,a.MobileNo,a.Blockname,a.panchayatname,a.VillageName,a.TotalLand,a.TotalAffectedRakwa,a.TotalSubsidy,a.ac_changerakwa,a.ac_changeamount,a.AC_Remarks,aa.LandPath, CASE WHEN a.FarmerType=1 THEN N'स्वयं' WHEN a.FarmerType=2 THEN N'बटैदार' ELSE N'स्वयं+बटैदार' END AS FARMERTYPE
            FROM Input2223_OnlineApply a inner join Input2223Reconsider_OnlineApply aa on aa.registration_id=a.registration_id
            inner join Input2223_LandDetails b on b.[Application_ID]=a.[Application_ID]
            where   ISNULL(aa.DAO_Status,0)=0 and  aa.Distcode='" + Session["DistrictCode"].ToString() + "'and a.BlockCode='" + ddlBlock.SelectedValue + "' " + Panchayat + " ";
            dtgdview = objcls.GetDataTable(query);
            if (dtgdview.Rows.Count > 0)
            {
                lblMsg.Text = dtgdview.Rows.Count + ",Records";
                gvdata.DataSource = dtgdview;
                gvdata.DataBind();
                btnApproved.Visible = false;
            }
            else
            {
                lblMsg.Text = "0,Records";
                gvdata.DataSource = null;
                gvdata.DataBind();
                btnApproved.Visible = false;
            }
        }
        catch (Exception ex) { }
    }
 
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (ddlBlock.SelectedValue == "0")
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('Kindly Select Block....');", true);
            return;

        }
        BindGridview();
    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindPanchayat();
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        if (chkAll.Checked)
        {
            //btnApproved.Visible = true;
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

    protected void btnApproved_Click(object sender, EventArgs e)
    {
        int k = 0;
        int i = 0;
        string mobileno = "";
        string query = ""; string appid = "";
        lblMsg.Text = "";
        try
        {
            int set = 0;
            foreach (GridViewRow row in gvdata.Rows)
            {
                CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
                Label lnkregid = (Label)row.FindControl("lnkregid");
                LinkButton lnkAppId = (LinkButton)row.FindControl("lnkAppId");
                Label lblApprovedSubsidyAmount = (Label)row.FindControl("lblApprovedSubsidyAmount");
                DropDownList ddlApproved = (DropDownList)row.FindControl("ddlApproved");
                DropDownList ddlreject = (DropDownList)row.FindControl("DropDownList1");
                TextBox txtDAOApprovedAmount = (TextBox)row.FindControl("txtDAOApprovedAmount");
                TextBox txtCommentDAO = (TextBox)row.FindControl("txtCommentDAO");
                //string rid = lnkregid.Text;

                if (row.RowType == DataControlRowType.DataRow)
                {
                    lblMsg.Text = "";
                    if (chk.Checked == true)
                    {
                        appid = (gvdata.DataKeys[row.RowIndex].Values["Application_ID"].ToString());
                        if (ddlApproved.SelectedValue == "1")
                        {
                            if (Convert.ToDecimal(txtDAOApprovedAmount.Text.Trim()) > Convert.ToDecimal(lblApprovedSubsidyAmount.Text))
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Kindly Enter less or equal Amount from AC approval Amount.');", true);
                                lblMsg.Text = "Kindly Enter less or equal Amount from AC approval Amount.";
                                return;
                            }
                            txtDAOApprovedAmount.Enabled = true;
                            if (string.IsNullOrEmpty(txtDAOApprovedAmount.Text.Trim()) || txtDAOApprovedAmount.Text == "0.00" || txtDAOApprovedAmount.Text == "0")//txtAmount
                            {
                                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please Enter Correct Approved amount....!!!!');", true);
                                return;
                            }

                        }
                        else if (ddlApproved.SelectedValue == "2")
                        {
                            txtDAOApprovedAmount.Text = "0.00";
                            txtDAOApprovedAmount.Enabled = false;
                            ddlreject.Enabled = true;
                        }
                        else
                        { ddlreject.Enabled = false; }
                        if (string.IsNullOrEmpty(txtCommentDAO.Text))
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please Enter Remarks....!!!!');", true);
                            return;
                        }
                        con.Open();
                        query = @"update dbo.Input2223_OnlineApply
                        set DAO_STATUS=@DAO_STATUS, DAO_ApprovedAmt=@DAO_ApprovedAmt, DAO_Remarks=@DAO_Remark, 
                        DAO_Actiondate=@DAO_Actiondate, DAO_ActionName=@DAO_ActionID,DAORejectcause=@DAORejectcause
                        where Application_ID =@ApplicationID";

                        SqlDataAdapter da = new SqlDataAdapter(query, con);
                        da.SelectCommand.Parameters.AddWithValue("@DAO_STATUS", ddlApproved.SelectedValue);
                        da.SelectCommand.Parameters.AddWithValue("@DAORejectcause", ddlreject.SelectedValue);
                        da.SelectCommand.Parameters.AddWithValue("@DAO_ApprovedAmt", ddlApproved.SelectedValue == "1" ? Convert.ToDecimal(txtDAOApprovedAmount.Text.Trim()) : 0);
                        da.SelectCommand.Parameters.AddWithValue("@DAO_Remark", txtCommentDAO.Text.Trim());
                        da.SelectCommand.Parameters.AddWithValue("@DAO_Actiondate", DateTime.Now);
                        da.SelectCommand.Parameters.AddWithValue("@DAO_ActionID", Session["UserID"].ToString()); ;
                        da.SelectCommand.Parameters.AddWithValue("@ApplicationID", appid);
                        int jj = da.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        if (jj > 0)
                        {
                            lblMsg.Visible = true;
                            k = k + 1;
                        }

                        if (ddlApproved.SelectedValue == "1")
                        {
                            lblMsg.Visible = true;
                            //sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", MobileNo, "कृषि विभाग, बिहार द्वारा आपका पंजीकरण फसल अवशेष जलाने के कारण तीन वर्षो के लिये बाधित कर दिया गया है, फसल अवशेष प्रबंधन के लिये https://youtu.be/Gcpn_33tG-A  लिंक को देखे|" + ",Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182073909271"); 
                            sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", mobileno, "'कृषि विभाग,बिहार सरकार द्वारा सूचित किया जाता है कि कृषि इनपुट अनुदान 2022-23 अंतर्गत आपका आवेदन स्वीकृत कर आगे की कारवाई हेतु अग्रसारित कर दिया गया है|'" + "-Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182073909271");
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            sms.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", mobileno, "'कृषि विभाग,बिहार सरकार द्वारा सूचित किया जाता है कि कृषि इनपुट अनुदान 2022-23 अंतर्गत आपका आवेदन आधारहीन होने के कारण रद्द कर दिया गया है| कृषि विभाग, बिहार सरकार " + "-Bihar Government", "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182073909271");
                        }
                        if (k > 0)
                        {
                            lblMsg.Visible = true;
                            ScriptManager.RegisterStartupScript(Page, GetType(), "showalert", "alert(" + k + "'+Data Verified Successfully');", true);
                            lblMsg.Text = "Out of " + lblMsg.Text + "," + k + ",Record Verified Successfully";

                        }

                    }
                }
            }
            BindGridview();
        }
        catch (Exception ex) { }
    }
    protected void ddlApproved_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvdata.Rows)
        {
            DropDownList ddlreject = (DropDownList)row.FindControl("DropDownList1");
            CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
            DropDownList ddlApproved = (DropDownList)row.FindControl("ddlApproved");
            TextBox txtDAOApprovedAmount = (TextBox)row.FindControl("txtDAOApprovedAmount");
            if (row.RowType == DataControlRowType.DataRow)
            {
                lblMsg.Text = "";
                if (chk.Checked == true)
                {
                    if (ddlApproved.SelectedValue == "2")
                    {
                        txtDAOApprovedAmount.Text = "0.00";
                        txtDAOApprovedAmount.Enabled = false; ddlreject.Enabled = true;
                    }
                    else
                    {
                        txtDAOApprovedAmount.Enabled = true; ddlreject.Enabled = false;
                    }
                }
                //if (chk.Checked == false)
                //{
                //    // ddlApproved.SelectedValue = "1";
                //    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Plese Select atleast one record.');", true);
                //    lblMsg.Text = "Plese Select atleast one record.";
                //    return;
                //}
            }
        }
    }
    public void WinOpen1(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=1100,height=750,toolbar=0,addressbar =0, scrollbars=yes');", msg);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "strScript", strScript, true);
        }
        catch (Exception ex) { }
    }
    //protected void imgbtnpreview_Click(object sender, ImageClickEventArgs e)
    //{
    //    string Appid = "";
    //    string query = "";
    //    foreach (GridViewRow row in gvdata.Rows)
    //    {
    //         Appid = (gvdata.DataKeys[row.RowIndex].Values["Application_ID"].ToString());
    //    }
    //    query = "select LandPath from Input2223_OnlineApply where Registration_id='" + Appid + "' order by slno desc";

    //    string Filepath = "";
    //    DataTable dtDownload = objcls.GetDataTable(query);
    //    if (dtDownload.Rows.Count > 0)
    //    {
    //        Filepath = dtDownload.Rows[0]["LandPath"].ToString();
    //    }
    //    WinOpen1(Filepath.Replace("~/", ""));
    //}
    //protected void DownloadFile(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string filePath = (sender as LinkButton).CommandArgument;
    //        Response.ContentType = ContentType;
    //        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
    //        Response.WriteFile(filePath);
    //        Response.End();
    //    }
    //    catch (Exception ex) { }
    //}

    protected void lnkRead_Click1(object sender, EventArgs e)
    {
        string Appid = "";
        string query = "";
        foreach (GridViewRow row in gvdata.Rows)
        {
            CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
            if (chk.Checked == true)
            {
                Appid = (gvdata.DataKeys[row.RowIndex].Values["Registration_ID"].ToString());
            }
        }
        query = "select LandPath from Input2223Reconsider_OnlineApply where Registration_id='" + Appid + "' order by slno desc";

        string Filepath = "";
        DataTable dtDownload = objcls.GetDataTable(query);
        if (dtDownload.Rows.Count > 0)
        {
            //Filepath = dtDownload.Rows[0]["LandPath"].ToString();
        }
        WinOpen1("https://dbtagriculture.bihar.gov.in/InputSubsidy2223/InputSubsidyReConsider2223/" + Appid + ".pdf");
    }
    protected void btnLandDetail_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        if (RegId != "")
        {
            WinOpen("LandDetailInputRe23.aspx?RegId=" + RegId);
        }
    }
    protected void btnfamilydetails_Click(object sender, EventArgs e)
    {
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = gvdata.DataKeys[rowIndex].Values[0].ToString();
        if (RegId != "")
        {
            WinOpen("Familydetails2223.aspx?RegId=" + RegId);
        }

    }
    public void WinOpen(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=900,height=200,align=center,toolbar=0,addressbar =0, scrollbars=yes');", msg);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "strScript", strScript, true);
        }
        catch (Exception ex) { }
    }
    //    void bindlanddata()
    //    {
    //        DataTable dt = new DataTable();
    //        string Appid = "";
    //        foreach (GridViewRow row in gvdata.Rows)
    //        {
    //            CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
    //            if (chk.Checked == true)
    //            {
    //                Appid = (gvdata.DataKeys[row.RowIndex].Values["Registration_ID"].ToString());
    //            }
    //        }
    //        dt=objcls.GetDataTable(@"select RegistrationID,Khatano,keshrano,thanano,FarmingRakwa,Affectedrakwa,
    //case when CropType = 1 then N'शाश्वत फसल/गन्ना' when croptype = 2 THEN N'गेंहूँ' when croptype = 3 THEN N'रबी दलहन' when CropType = 4 THEN N'रबी तेलहन'
    //when croptype = 5 THEN N'अन्य फसल' when CropType = 4 THEN N'सब्जी' END as croptype
    // from Input2223_landdetails  where RegistrationID='"+Appid+"'");
    //        if (dt.Rows.Count > 0)
    //        {

    //            GridView1.DataSource = dt;
    //            GridView1.DataBind(); this.ModalPopupExtender1.Show();
    //        }
    //    }



    protected void lnkAppId_Click(object sender, EventArgs e)
    {
        string RegId = "";
        foreach (GridViewRow row in gvdata.Rows)
        {
            CheckBox chk = (row.Cells[0].FindControl("chkDetails") as CheckBox);
            if (chk.Checked == true)
            {
                RegId = (gvdata.DataKeys[row.RowIndex].Values["Registration_ID"].ToString());
                // RegId = gvdata.DataKeys[rowIndex].Values["Registration_ID"].ToString();// gvdata.DataKeys[rowIndex].Values[0].ToString();
                if (RegId != "")
                {
                    WinOpen("Print_Input202223Recon.aspx?RegId=" + RegId);
                }
            }
        }

        //if (RegId != "")
        //{
        //    WinOpen("Print2223.aspx?RegId=" + RegId);
        //}
    }

    // Method for auto calculation 03-05-2023
    //----------------------1st---------------------
    protected void ExcuteFuncation()
    {
        try
        {
            con.Open();
            string query = @"select *  FROM   [dbo].[Input2223Reconsider_OnlineApply] A INNER JOIN (SELECT  RegistrationID, SUM ([DAOChangeSubsidyArea]) BB, SUM([DAOAmount]) CC FROM [dbo].Input2223_LandDetails
            WHERE [DAOChangeSubsidyArea] IS NOT NULL GROUP BY RegistrationID) B ON A.REGISTRATION_ID=B.RegistrationID  WHERE B.CC<2500 and B.CC<>0 and   A.DAO_ApprovedAmt  is null AND Distcode='" + Session["DistrictCode"].ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                decimal XYZ;
                foreach (DataRow dr in dt.Rows)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("select * from Input2223_LandDetails where RegistrationID='" + dr["Registration_id"].ToString() + "' and [DAOChangeSubsidyArea]<>0 ", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    SqlDataAdapter da2 = new SqlDataAdapter("select  SUM([daoAmount]) aa, SUM ([daoChangeSubsidyArea]) BB from Input2223_LandDetails where RegistrationID='" + dr["Registration_ID"].ToString() + "' and [DAOChangeSubsidyArea]<>0", con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    decimal sumAmount = Convert.ToDecimal(dt2.Rows[0]["aa"].ToString());
                    decimal sumArea = Convert.ToDecimal(dt2.Rows[0]["BB"].ToString());

                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow dr2 in dt1.Rows)
                        {
                            if (dr2["CropType"].ToString() == "1")
                            {
                                XYZ = 2500;
                                update(dr2["RegistrationID"].ToString(), XYZ, sumArea);
                                continue;
                            }
                            else if (dt1.Rows[0]["acchangeLandType"].ToString() == "1")
                            {
                                if (Convert.ToInt16(dt1.Rows[0]["CropType"].ToString()) != 1)
                                {
                                    XYZ = 2000;
                                    if (sumAmount < 2000)
                                        update(dr2["RegistrationID"].ToString(), XYZ, sumArea);
                                    else
                                        update(dr2["RegistrationID"].ToString(), sumAmount, sumArea);
                                    continue;
                                }
                            }
                            else if (dt1.Rows[0]["acchangeLandType"].ToString() == "2")
                            {
                                XYZ = 1000;
                                if (sumAmount < 1000)
                                    update(dr2["RegistrationID"].ToString(), XYZ, sumArea);
                                else
                                    update(dr2["RegistrationID"].ToString(), sumAmount, sumArea);
                                continue;
                            }
                        }

                    }
                }

            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    //-------------------------------2nd---------------------------------------
    protected void update(string appid, decimal amount, decimal area)
    {

 
        try
        {
            SqlDataAdapter da1 = new SqlDataAdapter("update Input2223Reconsider_OnlineApply set DAO_Status =1, DAO_ActionDate=getdate(), DAO_ApprovedAmt='" + amount + "' where Registration_ID='" + appid + "' AND Distcode='" + Session["DistrictCode"].ToString() + "'", con);
            da1.SelectCommand.ExecuteNonQuery();


        }
        catch (Exception ex)
        {

        }
        finally
        {
            //con.Close();
        }
    }
    //-------------------------------------------------------------------------3rd---
    protected void DaoUpate()
    {
        con.Open();
        try
        {
            SqlDataAdapter da1 = new SqlDataAdapter(@"UPDATE A SET A.DAO_Status =1,
			a.DAO_ActionDate=getdate(),
            A.DAO_ApprovedAmt=B.CC --select *
            FROM 
            [dbo].[Input2223Reconsider_OnlineApply] A INNER JOIN 
            (SELECT  RegistrationID, SUM ([daoChangeSubsidyArea]) BB, SUM([daoAmount]) CC FROM [dbo].Input2223_LandDetails
            WHERE [daoChangeSubsidyArea] IS NOT NULL 
            GROUP BY RegistrationID) B ON A.Registration_ID=B.RegistrationID WHERE B.CC>2500 and   A.DAO_Status is null and A.DAO_ApprovedAmt is  null AND Distcode='" + Session["DistrictCode"].ToString() + "'", con);
            da1.SelectCommand.ExecuteNonQuery();


        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    //-----------------------------4th---
    protected void DaoUpateACRejected()
    {
        con.Open();
        try
        {
            SqlDataAdapter da1 = new SqlDataAdapter(@"UPDATE A  set A.DAO_Status=2 --select *
            FROM [dbo].[Input2223Reconsider_OnlineApply] A INNER JOIN (SELECT  RegistrationID, SUM ([DAOChangeSubsidyArea]) BB, SUM([DAOAmount]) CC FROM [dbo].Input2223_LandDetails
            WHERE [DAOChangeSubsidyArea] IS NOT NULL GROUP BY RegistrationID) B ON A.Registration_ID=B.RegistrationID WHERE B.bb=0 and   A.DAO_Status is null and A.DAO_ApprovedAmt is  null  and (A.DAO_Status is null or A.DAO_Status=1) AND Distcode='" + Session["DistrictCode"].ToString() + "'", con);
            da1.SelectCommand.ExecuteNonQuery();


        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }

    protected void btnShow0_Click(object sender, EventArgs e)
    {
        DaoUpate();
        DaoUpateACRejected();
        ExcuteFuncation();
 //BindGridview();
    }
}



