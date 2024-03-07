using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for PMKisanWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class PMKisanWebService : System.Web.Services.WebService
{
    clsDataAccess cls = new clsDataAccess();

    public PMKisanWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataTable GetStatusData(string SqlQuery, string Id)
    {
        try
        {
            DataTable dt = new DataTable("Details"); ;
            if (Id == "STSPMKISAN")
            {
                dt = cls.GetDataTable(SqlQuery);
            }
            dt.TableName = "Table";
            return dt;
        }
        catch (Exception ex)
        {
            throw null;
        }
    }

   

}
