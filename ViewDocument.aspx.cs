using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewDocument : System.Web.UI.Page
{
    clsDataAccessNew clsNew = new clsDataAccessNew();
    string Rid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
         Rid = Request.QueryString["Rid"].ToString();
        BindDoc();
    }

   void BindDoc()
    {
        try
        {
            string query = "select Registration_ID,LandPath from Registration_PMKISAN  where Registration_ID='" + Rid + "'";
            DataTable dt = clsNew.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                string doc = dt.Rows[0]["LandPath"].ToString();
                string FilePath = Server.MapPath(doc);
                WebClient User = new WebClient();
                Byte[] FileBuffer = User.DownloadData(FilePath);
                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }
            }
        }
        catch
        { }
    }
}