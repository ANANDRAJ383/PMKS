using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NODAL_FTODieselSubsidt2223 : System.Web.UI.Page
{
    clsDataAccess_Diesel cls = new clsDataAccess_Diesel();
    string date = "";
    string lotno = "";
    SqlConnection con = new SqlConnection();
    SqlConnection conpun = new SqlConnection();
    public NODAL_FTODieselSubsidt2223()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishiDBConnectionString"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            date = Request.QueryString["Date"].ToString();
            lotno = Request.QueryString["LotNo"].ToString();
            fillData(date, lotno);
        }
    }
    protected void fillData(string dateParameter, string LotNo)
    {
        try
        {
            string QUERY = @"select count(*) aa , sum(DAO_ApprovedAmt) amt FROM  [DieselKharif2223SendtoBankMaster] where  Lotno=" + LotNo + " and  LotNoID= '" + dateParameter + "' ";
            DataTable dtGenerateFTO = cls.GetDataTable(QUERY);
            if (dtGenerateFTO.Rows.Count > 0)
            {
                decimal abc = 0;
                lblTotalBen.Text = dtGenerateFTO.Rows[0]["aa"].ToString();
                lblRealesAmount.Text = dtGenerateFTO.Rows[0]["amt"].ToString();
                lblAmount.Text = dtGenerateFTO.Rows[0]["amt"].ToString();
                lblDate.Text = dateParameter;
                //lblmsg.InnerText = words(Convert.ToDecimal(lblRealesAmount.Text.Trim()), false);
                lblmsg.InnerText = Class1.ToWords(Convert.ToDecimal(lblRealesAmount.Text.Trim())).ToString(); //words(Convert.ToDecimal(lblRealesAmount.Text.Trim()), false);
                DataTable dt = cls.GetDataTable("select * from [DieselSubKhrf2223_Generated] where  LotNoID='" + dateParameter + "' and Lotno=" + LotNo + " ");// baba table banayin  rauaaa
                if (dt.Rows.Count > 0)
                {
                    lblFtoNo.Text = dt.Rows[0]["FTONo"].ToString();
                }
                else
                {
                    int kk = 0;
                    string query = "select count(*) aa from [DieselSubKhrf2223_Generated]";
                    DataTable dtFtoNo = cls.GetDataTable(query);
                    if (dtFtoNo.Rows.Count > 0)
                    {
                        kk = Convert.ToInt16(dtFtoNo.Rows[0]["aa"].ToString()) + 1;
                    }
                    else { kk = 1; }

                    lblFtoNo.Text = "DSLKH2223/" + DateTime.Now.ToString("yyyyMMdd") + "-" + kk;
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("insert into [DieselSubKhrf2223_Generated] (FTONo, TotalBan, DAO_ApprovedAmt, Lotno,DateTime,OTP,LotNoID) VALUES (@FTONo, @TotalBan, @DAO_ApprovedAmt, @Lotno, @DateTime,@OTP,@LotNoID)", con);
                    da.SelectCommand.Parameters.AddWithValue("@FTONo", lblFtoNo.Text);
                    da.SelectCommand.Parameters.AddWithValue("@TotalBan", lblTotalBen.Text);
                    da.SelectCommand.Parameters.AddWithValue("@DAO_ApprovedAmt", Convert.ToDecimal(lblAmount.Text));
                    da.SelectCommand.Parameters.AddWithValue("@Lotno", LotNo);
                    da.SelectCommand.Parameters.AddWithValue("@DateTime", DateTime.Now);
                    da.SelectCommand.Parameters.AddWithValue("@OTP", GenerateRandomNo());
                    da.SelectCommand.Parameters.AddWithValue("@LotNoID", DateTime.Now.ToString("ddMMyyyy"));
                    da.SelectCommand.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        catch (Exception ex)
        { }
        finally { }

    }
    public int GenerateRandomNo()
    {
        int _min = 1111;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
    }
}
