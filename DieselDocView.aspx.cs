using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DieselDocView : System.Web.UI.Page
{
    clsDataAccessDiesel objcls = new clsDataAccessDiesel();
    string Appid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Appid"].ToString() != "")
        {
            Appid = Request.QueryString["Appid"].ToString(); BindDoc();
        }

    }

    void BindDoc()
    {
        try
        {
            objcls.storeProcedure.NewStoreProcedure("SP_GetFarmerDieselReceipt");
            objcls.storeProcedure.FieldName = "Application_ID";
            objcls.storeProcedure.FieldValue = new object[] { Appid };
            DataTable dt = objcls.storeProcedure.getData();
            if (dt.Rows.Count > 0)
            {
                string doc = dt.Rows[0]["Imagepath"].ToString();
                pdfiframe.Attributes.Add("src", doc);
                // var img1 = System.IO.File.ReadAllBytes(doc);


                //string FilePath = Server.MapPath(doc);
                //WebClient User = new WebClient();
                //Byte[] FileBuffer = User.DownloadData(FilePath);
                //if (FileBuffer != null)
                //{
                //Response.ContentType = "image/jpg";
                // Response.AddHeader("content-length", FileBuffer.Length.ToString());
                //Response.BinaryWrite(FileBuffer);
                //}
            }
        }
        catch (Exception ee)
        { }
    }
}