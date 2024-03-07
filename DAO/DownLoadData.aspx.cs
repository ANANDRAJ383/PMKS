using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class DAO_DownloadData : System.Web.UI.Page
{
    clsDataAccess_Diesel cls = new clsDataAccess_Diesel();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public override void VerifyRenderingInServerForm(Control control) { }
    protected void btnAcptData_Click(object sender, EventArgs e)
    {
        try
        {

            string Query = "select d.ApplicantName,d.FatherName,d.districtname,d.blockname,d.panchayatname from Diesel_SubsidyApplyKharif202223 d where d.DAO_Status=1 and d.Distcode='" + Session["DistrictCode"] + "' and SeasonalCropID<>9";
            DataTable dtCheck = cls.GetDataTable(Query);
            GridView grv = new GridView();
            grv.DataSource = dtCheck;
            if (dtCheck.Rows.Count > 0)
            {
                grv.DataBind();

                Response.Buffer = true;
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Diesel_SubsidyKharif2022_23ApprovedData.xls"));
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
        catch (Exception ee)
        {

        }

    }

    protected void btnRjctData_Click(object sender, EventArgs e)
    {
        try
        {

            string Query = "select d.ApplicantName,d.FatherName,d.districtname,d.blockname,d.panchayatname from Diesel_SubsidyApplyKharif202223 d where d.DAO_Status=2 and d.Distcode='" + Session["DistrictCode"] + "'";
            DataTable dtCheck = cls.GetDataTable(Query);
            GridView grv = new GridView();
            grv.DataSource = dtCheck;
            if (dtCheck.Rows.Count > 0)
            {
                grv.DataBind();

                Response.Buffer = true;
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Diesel_SubsidyKharif2022_23RejectData.xls"));
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
        catch (Exception ee)
        {

        }
    }
}