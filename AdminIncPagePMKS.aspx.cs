using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Collections;
using System.Text;
using esms_client;
using System.Security.Cryptography;
using System.Configuration;
using System.Net;
namespace AgricultureDept
{
    public partial class AdminIncPage : System.Web.UI.Page
    {
        clsDataAccessPMKisanPMKISANDB cls = new clsDataAccessPMKisanPMKISANDB();
        string abc = System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString;

        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conPMKISANDB"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = cls.GetDataTable("SELECT name FROM sys.Tables order by name");

            if (dt.Rows.Count > 0)
            {
                grd1.DataSource = dt;
                grd1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string abc = txt1.Text.ToLower();
            if (abc.Contains("delete") || abc.Contains("update") || abc.Contains("alter") || abc.Contains("drop") || abc.Contains("truncate") || abc.Contains("create") || abc.Contains("insert"))
            {


            }
            else
            {
                string xxx = txt1.Text.Trim();
                DataTable dt = cls.GetDataTable(xxx);

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }
          

      

    
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassode.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Please Enter Correct Passcode ...');", true);
                Response.Write("<script>alert('Please Enter Correct Passcode ...'');</script>");
                return;
            }
            if (txtPassode.Text.Trim() == "Pmksnb@24")
            {
                pnl1.Visible = true;
               
            }
            else
            {
                pnl1.Visible = false;
                ScriptManager.RegisterStartupScript(Page, GetType(), "sskkk", "alert('Please Enter Correct Passcode ...');", true);
                Response.Write("<script>alert('Please Enter Correct Passcode ...'');</script>");
                return;
            }

        }
        protected void gvdata_PreRender(object sender, EventArgs e)
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
}
