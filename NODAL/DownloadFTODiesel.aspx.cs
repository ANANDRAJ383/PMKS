using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Threading;
using System.Globalization;
using QRCoder;
using esms_client;
using System.Web.Services;
using System.Web.UI.HtmlControls;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Drawing;
using System.Xml;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using Ionic.Zlib;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.InteropServices;
using Ionic.Zip;
using System.Linq;
using System;

public partial class NODAL_DownloadFTODiesel : System.Web.UI.Page
{
    clsDataAccess_Diesel cls = new clsDataAccess_Diesel();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            fillGrid();
        }
    }
    protected void fillGrid()
    {
        DataTable dt = cls.GetDataTable("select LotNo, LotNoID as LotID,CONVERT(char(11), LotDate,106)  Date, COUNT(*) aa, SUM(DAO_ApprovedAmt) amt, 'Send to Bank' as aaSEND  from DieselKharif2223SendtoBankMaster where LotDate is not null group by LotNo, LotNoID, CONVERT(char(11), LotDate,106) order by  CONVERT(char(11), LotDate,106)  ");
        if (dt.Rows.Count > 0)
        {
            Gridview2.DataSource = dt;
            Gridview2.DataBind();
        }
        else
        {
            Gridview2.DataSource = "";
            Gridview2.EmptyDataText = "Not data Available..!!!!!!";
            Gridview2.DataBind();
        }


    }
    public void WinOpen(string msg)
    {
        try
        {
            string strScript = string.Format("window.open('" + msg + "','name','type=resizable=yes,Width=1100,height=750,toolbar=0,addressbar =0, scrollbars=yes');", msg);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "strScript", strScript, true);
        }
        catch (Exception ex) { }
    }

    protected void txtDetails_Click(object sender, EventArgs e)
    {
        try
        {
            //foreach (GridViewRow row in Gridview2.Rows)
            //{
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Label lnkLotID = (Label)row.FindControl("lnkLotID");

            string appid = Gridview2.DataKeys[gvr.RowIndex].Values["LotID"].ToString();
            string LotNo = Gridview2.DataKeys[gvr.RowIndex].Values["LotNo"].ToString();
            WinOpen("FTODieselSubsidt2223.aspx?Date=" + appid.ToString() + "&LotNo=" + LotNo.ToString());
            //}
            
        }
        catch (Exception ex) { }
    }
}