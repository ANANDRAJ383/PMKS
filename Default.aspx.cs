using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using esms_client;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    clsDataAccess cls = new clsDataAccess();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImportCSV(object sender, EventArgs e)
    {
        string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
        FileUpload1.SaveAs(csvPath);

        //Create a DataTable.
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("SLNO", typeof(string)),
        new DataColumn("MobileNo", typeof(string)),
        new DataColumn("DNO", typeof(string))
          });

        //Read the contents of CSV file.
        string csvData = File.ReadAllText(csvPath);

        //Execute a loop over the rows.
        foreach (string row in csvData.Split('\n'))
        {
            if (!string.IsNullOrEmpty(row))
            {
                dt.Rows.Add();
                int i = 0;

                //Execute a loop over the columns.
                foreach (string cell in row.Split(','))
                {
                    dt.Rows[dt.Rows.Count - 1][i] = cell;
                    i++;
                }
            }
        }
        //Bind the DataTable.
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            SMSHttpPostClient1 otpmsg = new SMSHttpPostClient1();
            foreach (GridViewRow dr in GridView1.Rows)
            {
                string mobileNos = dr.Cells[1].Text;
                string dno = dr.Cells[2].Text;
                string SMS = "कृषि विभाग बिहार द्वारा सूचित किया जाता है कि आपका आवेदन बीज के लिए स्वीकृत किया गया है | डिमांड न० " + dno.Replace("\r","") + " Regards BRBN{#var#}|  - Bihar Government";
                otpmsg.sendUnicodeSMS("BIHAREDISTRICT-agro", "dbt@1256#", "BRGOVT", mobileNos, SMS, "35fc8f80-e0bc-469e-9a93-646d7d453552", "1307161182073909271");
            }
            //ScriptManager.RegisterStartupScript(Page, GetType(), "msg", "alert('SMS Send successfuly.!!!!!!!!!');", true);
            Response.Write("<script language='javascript'>window.alert('SMS Send successfuly................!!!!!!!');';</script>");
        }
        catch(Exception ex) { }
        finally { }

    }
}