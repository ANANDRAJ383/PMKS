using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class HQ_Diesel2324 : System.Web.UI.Page
{
   // clsDataAccess_Diesel cls = new clsDataAccess_Diesel();
clsDataAccessDiesel cls = new clsDataAccessDiesel();
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();

    }
    public override void VerifyRenderingInServerForm(Control control) { }
    void BindData()
    {
        string Query = @"select a.dist,a.BlockName, a.TotalApp,
a.Raiyat, a.GairRaiyat, a.Both,  (a.TotalApp-(a.Male+ a.Female ) +a.Male) Male, a.Female ,
 (a.TotalApp - (a.[2040]+a.[4160]+a.[60])) [1820], a.[2040], a.[4160], a.[60],a.ClaimedRakwa,a.SubsidyAmount
 from 
( select (SELECT D.DistName FROM DISTRICTS D WHERE D.DistCode=dd.DistCode) dist, dd.BlockName,                             
(select count(*) from  Diesel_Subsidy202324 a where a.BlockCode=dd.BlockCode) TotalApp,
( select count(*) from Diesel_Subsidy202324 a where a.BlockCode=dd.BlockCode   and  landtype=N'स्वयं')[Raiyat],
( select count(*) from Diesel_Subsidy202324 a where a.BlockCode=dd.BlockCode AND  landtype=N'बटाईदार'  )[GairRaiyat],
( select count(*) from Diesel_Subsidy202324 a where a.BlockCode=dd.BlockCode AND  landtype=N'स्वयं + बटाईदार'  )Both,
( select count(*) from Diesel_Subsidy202324 a where a.BlockCode=dd.BlockCode AND  gender=N'पुरुष'  )Male,
( select count(*) from Diesel_Subsidy202324 a where a.BlockCode=dd.BlockCode AND  gender=N'स्त्री'  ) Female,
( select count(*) from Diesel_Subsidy202324 a where a.BlockCode=dd.BlockCode AND datediff(year, DOB , getdate())>=20 and  datediff(year, DOB , getdate())< =40 )[2040],
( select count(*) from Diesel_Subsidy202324 a where a.BlockCode=dd.BlockCode AND  datediff(year, DOB , getdate())>40 and  datediff(year, DOB , getdate())< =60 )[4160],
( select count(*) from Diesel_Subsidy202324 a where a.BlockCode=dd.BlockCode AND  datediff(year, DOB , getdate())>60 )[60] ,
( select sum( cast(totallandcultivation as decimal(18,2))) from Diesel_Subsidy202324 a where a.BlockCode=dd.BlockCode )[ClaimedRakwa] ,
( select sum(cast(totalamount as decimal(18,2))) from Diesel_Subsidy202324 a where a.BlockCode=dd.BlockCode )[SubsidyAmount] 
from Blocks dd) a
order by	a.BlockName";
        DataTable dtCheck = cls.GetDataTable(Query);
        GridView grv = new GridView();
       
        if (dtCheck.Rows.Count > 0)
        {
            GridView2.DataSource = dtCheck;
            GridView2.DataBind();
        }
    }
    protected void dslbtn_Click(object sender, EventArgs e)
    {
        try
        {

            string Query = @"select ROW_NUMBER() OVER (  ORDER BY d.DistName) as Slno,d.DistName ,  
( select count(*) from Diesel_Subsidy202324 a where a.distcode=d.DistCode  )[TotalApp] ,
( select count(*) from Diesel_Subsidy202324 a where a.distcode=d.DistCode   and  landtype=N'स्वयं')[Raiyat],
( select count(*) from Diesel_Subsidy202324 a where a.distcode=d.DistCode AND  landtype=N'बटाईदार'  )[GairRaiyat],
( select count(*) from Diesel_Subsidy202324 a where a.distcode=d.DistCode AND  landtype=N'स्वयं + बटाईदार'  )Both,
( select count(*) from Diesel_Subsidy202324 a where a.distcode=d.DistCode AND  gender=N'पुरुष'  )Male,
( select count(*) from Diesel_Subsidy202324 a where a.distcode=d.DistCode AND  gender=N'स्त्री'  ) Female,
( select count(*) from Diesel_Subsidy202324 a where a.distcode=d.DistCode AND datediff(year, DOB , getdate())>=20 and  datediff(year, DOB , getdate())< =40 )[2040],
( select count(*) from Diesel_Subsidy202324 a where a.distcode=d.DistCode AND  datediff(year, DOB , getdate())>40 and  datediff(year, DOB , getdate())< =60 )[4160],
( select count(*) from Diesel_Subsidy202324 a where a.distcode=d.DistCode AND  datediff(year, DOB , getdate())>60 )[>60] ,
( select sum( cast(totallandcultivation as decimal(18,2))) from Diesel_Subsidy202324 a where a.distcode=d.DistCode  )[ClaimedRakwa] ,
( select sum(cast(totalamount as decimal(18,2))) from Diesel_Subsidy202324 a where a.distcode=d.DistCode  )[SubsidyAmount] 
from 
districts d
order by d.DistName";
            DataTable dtCheck = cls.GetDataTable(Query);
            GridView grv = new GridView();
            grv.DataSource = dtCheck;
            if (dtCheck.Rows.Count > 0)
            {
                grv.DataBind();

                Response.Buffer = true;
                Response.ClearContent();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", DateTime.Now.ToString())+"_Diesel_SubsidyKharif2023_24Report.xls");
                //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
 Response.ContentType = "application/ms-excel";
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
  protected void GridView_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;

        if ((gv.ShowHeader == true && gv.Rows.Count > 0)
            || (gv.ShowHeaderWhenEmpty == true))
        {
            //Force GridView to use <thead> instead of <tbody> - 11/03/2013 - MCR.
            gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        if (gv.ShowFooter == true && gv.Rows.Count > 0)
        {
            //Force GridView to use <tfoot> instead of <tbody> - 11/03/2013 - MCR.
            gv.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
}