using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public partial class ADM_PMKisanReport : System.Web.UI.Page
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    clsDataAccessNew clsNew = new clsDataAccessNew();
    protected void Page_Load(object sender, EventArgs e)
    {

        BindDataV4();
    }
    public override void VerifyRenderingInServerForm(Control control) { }
    void BindDataV4()
    {
        try
        {
            string QUERY = @"select Blockname,Blockcode,count(*) TotalFarmers from  Registration_PMKISAN_New 
                            where LandMutationDate is  null and CO_Status=1 and ADMR_Status=1 and XMLStatus is null
                            and Distcode='" + Session["DistrictCode"] .ToString()+ "'  group by Blockname,Blockcode order by Blockname";
            DataTable dt = clsNew.GetDataTable(QUERY);
            if (dt.Rows.Count>0)
            {
                GridV4.DataSource = dt;
                GridV4.DataBind();
                GridV4.Visible = true;

            }

            string QUERYv5 = @"select d.BlockName,l.BlockCode,count(*) TotalFarmers1 from  tbl_PMKisan_LandSeeding_No l
                                inner join Blocks d on d.BlockCode=l.BlockCode 
                                where  dataReturnDate is not null and XMLStatusNew is null and l.Distcode='" + Session["DistrictCode"].ToString() + "'  	group by d.BlockName,l.BlockCode   order by d.BlockName";
            DataTable dtv5 = clsNew.GetDataTable(QUERYv5);
            if (dtv5.Rows.Count > 0)
            {
                GridV5.DataSource = dtv5;
                GridV5.DataBind();
                GridV5.Visible = true;

            }

        }
        catch(Exception ex)
        {

        }
    }


    protected void GridV4_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "BlockCode")
        {
            string BlockCode = e.CommandArgument.ToString();
            ViewState["BlockCode"] = BlockCode;

            string QUERY = @"select Districtname,Blockname,Panchayatname,VillageName,Registration_ID,ApplicationType,ApplicantName,Father_Husband_Name
                            from Registration_PMKISAN_New where Distcode='" + Session["DistrictCode"].ToString() + "' and CO_Status=1 and ADMR_Status=1  and XMLStatus is null and BlockCode='" + BlockCode + "'";
            DataTable dt = clsNew.GetDataTable(QUERY);
            GridView grv = new GridView();
            grv.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                grv.DataBind();
                Response.Buffer = true;
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}",  "_V4PendingData.xls"));
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grv.RenderControl(htw);
                string style = @"<style> td { mso-number-format:\@;} </style>";
                Response.Write(style);
                Response.Write(sw.ToString());
                Response.End();
            }
        }
    }

    protected void GridV5_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "BlockCode")
            {
                string BlockCode = e.CommandArgument.ToString();
                ViewState["BlockCode"] = BlockCode;

                string QUERY = @"select Districtname,b.BlockName,Panchayatname,VillageName,Registration_ID,ApplicantName,Father_Husband_Name from  tbl_PMKisan_LandSeeding_No l
                            inner join Districts d on d.DistCode=l.Distcode
                            inner join Blocks b on b.BlockCode=l.BlockCode 
                            where  dataReturnDate is not null and XMLStatusNew is null and l.BlockCode='" + BlockCode + "'";
                DataTable dt = clsNew.GetDataTable(QUERY);
                GridView grv = new GridView();

                if (dt.Rows.Count > 0)
                {
                    grv.DataBind();
                    Response.Buffer = true;
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "V5_Pending.xls"));
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(sw);
                    grv.RenderControl(htw);
                    string style = @"<style> td { mso-number-format:\@;} </style>";
                    Response.Write(style);
                    Response.Write(sw.ToString());
                    Response.End();
                }
                else
                {
                    Utility.showMessage(this, "No data available");
                    return;
                }
            }
        }
        catch (Exception ee)
        {

        }
    }
}