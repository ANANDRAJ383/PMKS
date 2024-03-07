using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class NODAL_GenerateBill : System.Web.UI.Page
{
    
    clsDataAccessDiesel objcls = new clsDataAccessDiesel();
    clsDataAccess_Diesel cls = new clsDataAccess_Diesel();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDist(); 
        }
    }

    #region Function&Method


    void BindDist()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
            DataTable dt = objcls.storeProcedure.getData();
            ddlDist.DataTextField = "DistName";
            ddlDist.DataValueField = "DistCode";
            ddlDist.DataSource = dt;
            ddlDist.DataBind();
            ddlDist.Items.Insert(0, new ListItem("--All--", "0"));
        }
        catch
        {
        }
    }

    


    void BindData()
    {
        try
        {

            //----------------------------Table Original

            DataTable dtOr = new DataTable();
            // dtOr.Columns.Add("slno", typeof(int));
            dtOr.Columns.Add("UserNumber", typeof(string));
            dtOr.Columns.Add("UserName", typeof(string));
            dtOr.Columns.Add("UserReference", typeof(string));
            dtOr.Columns.Add("SettlementDate", typeof(string));
            dtOr.Columns.Add("Users_Bank_Account_Number", typeof(string));
            dtOr.Columns.Add("Destinationbankinn", typeof(string));
            dtOr.Columns.Add("AadhaarNumber", typeof(string));
            dtOr.Columns.Add("Application_ID", typeof(string));
            dtOr.Columns.Add("DAO_Approvedamt", typeof(string));
            dtOr.Columns.Add("MobileNumber", typeof(string));

            DataRow drOr = null;
            drOr = dtOr.NewRow();


            DataTable dt = cls.GetDataTable("exec SP_GetDieselDataForSendToBank '" + ddlDist.SelectedValue + "'");


            if (dt.Rows.Count > 0)
            {

                decimal abc = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    abc = abc + Convert.ToDecimal(dr["DAO_ApprovedAmt"].ToString());
                }

                lblMsg.Text = "Total Farmers :-" + dt.Rows.Count + ",Amount :-" + abc.ToString();
                gdviewbank.DataSource = dt;
                gdviewbank.DataBind();
                gdviewbank.Visible = true;
                btnSelectData.Visible = true;
            }
            else
            {
                gdviewbank.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Record Not available !!!!!');", true);
                lblDataMsg.Text = "Record Not available !!!!!";
                btnSelectData.Visible = false;
                btnexport.Visible = false;
            }

        }
        catch (Exception ee)
        { lblMsg.Text = ee.Message; }
    }

  

    #endregion

    protected void btnShow_Click(object sender, EventArgs e)
    {
        BindData(); btnSelectData.Visible = true;
    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        if (chkAll.Checked)
        {
           
            CheckBox chkDetails = null;

            foreach (GridViewRow gvr in gdviewbank.Rows)
            {
                chkDetails = (CheckBox)gvr.FindControl("chkDetails");
                chkDetails.Checked = true;
            }
        }

        else
        {

            foreach (GridViewRow gvr in gdviewbank.Rows)
            {
                CheckBox chkDetails = (CheckBox)gvr.FindControl("chkDetails");
                chkDetails.Checked = false;

            }
            //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select at least one record');", true);
        }
    }


    public static DataTable GetDataTable(GridView grd)
    {
        
        using (DataTable dtChecked = new DataTable())
        {
            //DataTable dtChecked = new DataTable();
            dtChecked.Columns.Add("slno", typeof(int));
            dtChecked.Columns.Add("UserNumber", typeof(string));
            dtChecked.Columns.Add("UserName", typeof(string));
            dtChecked.Columns.Add("UserReference", typeof(string));
            dtChecked.Columns.Add("SettlementDate", typeof(string));
            dtChecked.Columns.Add("Users_Bank_Account_Number", typeof(string));
            dtChecked.Columns.Add("Destinationbankinn", typeof(string));
            dtChecked.Columns.Add("Registration_ID", typeof(string));
            dtChecked.Columns.Add("Application_ID", typeof(string));
            dtChecked.Columns.Add("Fullname", typeof(string));
            dtChecked.Columns.Add("MobileNumber", typeof(string));
            dtChecked.Columns.Add("AadhaarNumber", typeof(string));
            dtChecked.Columns.Add("DistName", typeof(string));
            dtChecked.Columns.Add("BlockName", typeof(string));
            dtChecked.Columns.Add("SubsidyAmount", typeof(string));
            dtChecked.Columns.Add("BankName", typeof(string));
            dtChecked.Columns.Add("IFSC_Code", typeof(string));
            dtChecked.Columns.Add("AccountNumber", typeof(string));
            dtChecked.Columns.Add("DAO_Approvedamt", typeof(string));
            DataRow dr;
            int kk = 0;
            string str = string.Empty;
            string strname = string.Empty;
            foreach (GridViewRow gvrow in grd.Rows)
            {
                kk = kk + 1;
                CheckBox chk = (CheckBox)gvrow.FindControl("chkDetails");
                if (chk != null & chk.Checked)
                {
                    dr = dtChecked.NewRow();
                    dr["slno"] = kk;
                    dr["UserNumber"] = gvrow.Cells[2].Text;
                    dr["UserName"] = gvrow.Cells[3].Text;
                    dr["UserReference"] = gvrow.Cells[4].Text;
                    dr["SettlementDate"] = gvrow.Cells[5].Text;
                    dr["Users_Bank_Account_Number"] = gvrow.Cells[6].Text;
                    dr["Destinationbankinn"] = gvrow.Cells[7].Text;
                    dr["AadhaarNumber"] = gvrow.Cells[8].Text;
                    dr["Application_ID"] = grd.DataKeys[gvrow.RowIndex].Values["Application_ID"].ToString();
                    dr["DAO_Approvedamt"] = gvrow.Cells[10].Text;
                    dr["MobileNumber"] = gvrow.Cells[11].Text;
                    //dr["BankName"] = gvrow.Cells[9].Text;
                    //dr["IFSC_Code"] = gvrow.Cells[10].Text;
                    //dr["AccountNumber"] = gvrow.Cells[7].Text;
                    dtChecked.Rows.Add(dr);
                }
            }
            return dtChecked;
        }
    }

    protected void btnSelectData_Click(object sender, EventArgs e)
    {
        CheckBox chkDetails = null;
        foreach (GridViewRow gvr in gdviewbank.Rows)
        {
            chkDetails = (CheckBox)gvr.FindControl("chkDetails");
            chkDetails.Checked = true;
        } 
            grdChecke.DataSource = GetDataTable(gdviewbank);
            grdChecke.DataBind();
            grdChecke.Visible=true;
            pnlCSV.Visible = true;
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        string str = string.Empty;
        string LontnoId = DateTime.Now.ToString("ddMMyyyy");
        try
        {
            int lotid = 0;
            string datatable = "select top 1 isnull(LotNo,0) LotNo from [DieselKharif2223SendtoBankMaster] where LotNoID='" + LontnoId + "' order by slno desc";
            DataTable dtLotno = objcls.GetDataTable(datatable);
            if (dtLotno.Rows.Count > 0)
            {
                lotid = Convert.ToInt16(dtLotno.Rows[0]["LotNo"].ToString()) + 1;
            }
            else
            {
                lotid = 1;
            }
            int c = 0;
            foreach (GridViewRow gvrow in gdviewbank.Rows)
            {
                try
                {

                    CheckBox chk = (CheckBox)gvrow.FindControl("chkDetails");
                    if (chk != null & chk.Checked)
                    {
                        string appid = gdviewbank.DataKeys[gvrow.RowIndex].Values["Application_ID"].ToString();
                        try
                        {

                            DataTable dt = cls.GetDataTable("exec SP_InsertData_Diesel '" + gvrow.Cells[2].Text+ "','" + gvrow.Cells[3].Text + "','" + gvrow.Cells[4].Text + "','" + gvrow.Cells[6].Text + "','" + gvrow.Cells[8].Text + "','" + appid + "','" + gvrow.Cells[10].Text + "','" + gvrow.Cells[11].Text + "','" + lotid + "','" + LontnoId + "'");

                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["R"].ToString() == "Success")
                                {
                                    c++;
                                }
                            }
                           
                        }
                        catch (Exception ee) { }
                        
                    }
                }
                catch (Exception ex) { }
                
            }

            DataTable dtU = cls.GetDataTable("exec SP_UpdateDiesel_SubsidyApplyKharif202223'" + lotid + "','" + LontnoId + "'");
            if (dtU.Rows.Count > 0)
            {
                if (dtU.Rows[0]["R"].ToString() == "Success")
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert(Total +'"+c+"' +'Data Inserted & Updated  Successfully ...  ');", true);
                    lblMsg.Text = "Total :-" + c +"   Data Inserted &Updated  Successfully... ";
                    BindData();
                    gdviewbank.Visible = false;
                    grdChecke.Visible = false;
                    grdChecke.DataSource = null;
                }
            }
        }
        catch (Exception ex) { }

    }
    }