using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class LandDetailInputRe23 : System.Web.UI.Page
{

    string RegId = "";
    clsDataAccess_Diesel objcls = new clsDataAccess_Diesel();
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    public LandDetailInputRe23()
    {
        con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["KrishII"].ConnectionString;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RegId = Request.QueryString["RegId"].ToString();
            lblRegId.Text = "Registration Id :-" + RegId;
            bindlanddata();
        }

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }


    void bindlanddata()
    {
        DataTable dt = new DataTable();
        dt = objcls.GetDataTable(@"select slno,RegistrationID,Khatano,keshrano,thanano,FarmingRakwa,Affectedrakwa,case when affectedtype=1 then N'सिंचित' else N'असिंचित' end as  affectedtype ,
      case when DAOChangeLandType is null then 'Pending' else 'Verified' end as  DAOChangeLandType ,
        case when CropType = 1 then N'शाश्वत फसल/गन्ना' when croptype = 2 THEN N'गेंहूँ' when croptype = 3 THEN N'रबी दलहन' when CropType = 4 THEN N'रबी तेलहन'
        when croptype = 5 THEN N'अन्य फसल' when CropType = 4 THEN N'सब्जी' END as croptype
        from Input2223_landdetails  where RegistrationID='" + RegId + "'");
        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
    protected void btnTakeAction_Click(object sender, EventArgs e)
    {
        Button lnkRegistraionID = (Button)GridView1.FindControl("btnTakeAction");
        int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
        string RegId = GridView1.DataKeys[rowIndex].Values[0].ToString();
        string Slno = GridView1.DataKeys[rowIndex].Values[1].ToString();
        Button btndetails = sender as Button;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        if (RegId != "")
        {
            pnl1.Visible = true;
            lbl1.Text = RegId;
            Label1.Text = Slno;
            lblAffectedLand.Text = gvrow.Cells[7].Text;
            lbl2.Text = gvrow.Cells[9].Text;
            lbl3.Text = gvrow.Cells[8].Text;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        //try
        //{
           if (ddlLandType.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please Select Land Type..!!!!!');", true);
                return;
            }
            if (string.IsNullOrEmpty(txtapprovedLand.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please enter affected rakwa..!!!!!');", true);
                return;
            }
           if (string.IsNullOrEmpty(txtRemarks.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please enter Remarks..!!!!!');", true);
                return;
            }
            decimal affectedLand = Convert.ToDecimal(lblAffectedLand.Text.Trim());
            if (Convert.ToDecimal(txtapprovedLand.Text.Trim()) > affectedLand)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Please enter correct Land..!!!!!');", true);
                return;
            }
            int croptype = 0;
            if (lbl3.Text.Trim() == "शाश्वत फसल/गन्ना")
            {
                croptype = 1;
            }
            else
            {
                croptype = 2;
            }
            if (lbl2.Text == "असिंचित")
            {
                if (ddlLandType.SelectedValue == "1")
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('You can't change irrigation type..!!!!!');", true);
                    return;
                }
            }

            int abc = Convert.ToInt16(ddlLandType.SelectedValue);
            string Amount = Subsidyamnt(abc, croptype, txtapprovedLand.Text.Trim());
            SqlDataAdapter da1 = new SqlDataAdapter(@"update Input2223_LandDetails set DAOChangeLandType=@DAOChangeLandType,  DAOChangeSubsidyArea=@DAOChangeSubsidyArea,  DAOAmount=@DAOAmount, DAOEntryDate=GETDATE(), DAORemarks=@DAORemarks  where SLNO='" + Label1.Text + "'", con);
            da1.SelectCommand.Parameters.AddWithValue("@DAOChangeLandType", Convert.ToInt16(ddlLandType.SelectedValue));
            da1.SelectCommand.Parameters.AddWithValue("@DAOChangeSubsidyArea", Convert.ToDecimal(txtapprovedLand.Text.Trim())); 
            da1.SelectCommand.Parameters.AddWithValue("@DAOAmount", Convert.ToDecimal(Amount));
            da1.SelectCommand.Parameters.AddWithValue("@DAORemarks", txtRemarks.Text.Trim());
            int i = da1.SelectCommand.ExecuteNonQuery();
            if (i > 0)
            {
               //GridView1_RowDataBound(sender, e);
                ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('Land is approved..!!!!!');", true);
            }
        //}
        //catch (Exception ex)
        //{

       // }
       // finally
       // {
            con.Close();
       // }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Checking the RowType of the Row  
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //If Salary is less than 10000 than set the Cell BackColor to Red and ForeColor to White  
            if (e.Row.Cells[11].Text.Trim() == "Verified")
            {
                e.Row.BackColor = Color.Yellow;
                e.Row.Enabled = false;
                // e.Row.Cells[1].ForeColor = Color.White;
            }
        }
    }
    protected string Subsidyamnt(int LandType, int CropType, string EffectedLand)
    {
        string totalamnt = "";
        string CalcultatedAmount = "";
        {
            string abc = "0";
            abc = "1";
            // Saswat Fasal
            string ssAmount = "91.09";//91.09
            //For all Fasal 
            string allAmount = "68.82";
            string RainallAmount = "34.41";
            double Subsidyamnt = 0;
            var totalland = double.Parse(EffectedLand);
            if (totalland > 494.00)
            {
                totalland = 494.20;
            }
            int noofWatring = Convert.ToInt16(abc);
            {
                if (LandType == 1)
                {
                    if (CropType == 1 || CropType == 9)
                    {
                        Subsidyamnt = (totalland * double.Parse(ssAmount)) * noofWatring;
                    }
                    else
                    {
                        Subsidyamnt = (totalland * double.Parse(allAmount)) * noofWatring;
                    }
                }
                else
                {
                    if (CropType == 1 || CropType == 9)
                    {
                        Subsidyamnt = (totalland * double.Parse(ssAmount)) * noofWatring;
                    }
                    else
                    {
                        Subsidyamnt = (totalland * double.Parse(RainallAmount)) * noofWatring;
                    }
                }
            }
            totalamnt = Subsidyamnt.ToString();
            double amount = double.Parse(totalamnt);
            if (amount < 1000.00)
            {
                CalcultatedAmount = totalamnt; //1000.00;
            }
            else
            {
                CalcultatedAmount = totalamnt;
            }

        }
        return CalcultatedAmount;
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {

   Response.Redirect("https://dbtagriculture.bihar.gov.in/regfarmer/pmkisanadmin/DAO/LandDetailInputRe23.aspx?RegId=" + lbl1.Text);
    }
}