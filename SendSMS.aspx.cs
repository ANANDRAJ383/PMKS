using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class SendSMS : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    DataTable _dt = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDst(); BindBlk();
            
        }
    }

    //private void SendSMS(string _Mobileno, string _Msg)
    //{
   //     EleconSMSService.EleconSMSService sendSMS = new EleconSMSService.EleconSMSService();
   ////     sendSMS.Open();
   //     try
   //     {
   //         if (chkHnd.Checked == true)
   //         {
   //             sendSMS.SendSMSunicode(_Msg, _Mobileno, "67890","elabh");
   //         }
   //         else
   //         {
                
   //          lblmsg.Text=    sendSMS.SendSMS(_Msg, _Mobileno, "67890", "elabh");
   //         }
   //         lblmsg.Text = "Massage Succesfully Send..";
   //     }
   //     catch { }


       // sendSMS.Close();
   // }
    protected void btnAC_Click1(object sender, EventArgs e)
    {
        try
        {
         //   string mb = "";
         // //  mb = "9525701671";
         //   DataTable dt = cls.GetDataTable("select DistCode, ContactNo from dbo.BDOContactList where ( ISNULL ('" + DDLDistrict.SelectedValue + "','0')='0' or DistCode ='" + DDLDistrict.SelectedValue + "') and (ISNULL ('" + DDLBlock.SelectedValue + "','0')='0' or BlockCode ='" + DDLBlock.SelectedValue + "')");
         ////   SendSMS(mb, txtblkmsg.Text.Trim());
         //   foreach (DataRow dr in dt.Rows)
         //   {
         //       mb = "";
         //       mb = dr["ContactNo"].ToString().Trim();
         //       if (ChkBlk.Checked == true)
         //       {
         //           SendSMS(mb, txtblkmsg.Text.Trim());
         //       }

         //   }
        
           
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Msg", "alert('" + ex.Message + "');", true);
        }
    }

   
    protected void ChkBlk_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkBlk.Checked == true)
        {
            //chkHnd.Visible = true;
            txtblkmsg.Visible = true;
            txtblkmsg.Focus();
        }
        else
        {
            txtblkmsg.Visible = false;
            //chkHnd.Visible = false;
        }
    }
    protected void ChkAdss_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkAdss.Checked == true)
        {
            //chkHnd.Visible = true;
        }
        else
        {
            //chkHnd.Visible = false;
        }
    }

    private void BindDst()
    {
        
        objcls.storeProcedure.NewStoreProcedure("SP_GetDistrict");
        DataTable dt = objcls.storeProcedure.getData();
        DDLDistrict.DataValueField = "DistCode";
        DDLDistrict.DataTextField = "DistName";
        DDLDistrict.DataSource = dt;
        DDLDistrict.DataBind();
        DDLDistrict.Items.Insert(0, new ListItem("ALL District", "0"));

    }

    private void BindBlk()
    {
        
        objcls.storeProcedure.NewStoreProcedure("SP_GetBlock");
        objcls.storeProcedure.FieldName = "DistCode";
        objcls.storeProcedure.FieldValue = new object[] { DDLDistrict.SelectedValue };
        DataTable dt = objcls.storeProcedure.getData();
        DDLBlock.DataValueField = "BlockCode";
        DDLBlock.DataTextField = "BlockName";
        DDLBlock.DataSource = dt;
        DDLBlock.DataBind();
        DDLBlock.Items.Insert(0, new ListItem("ALL Block", "0"));

    }
    //protected void DDLDistrict_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindBlk();
    //}

    protected void DDLDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindBlk();
    }
}