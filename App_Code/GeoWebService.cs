using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
/// <summary>
/// Summary description for GeoWebService
/// </summary>
[WebService(Namespace = "https://dbtagriculture.bihar.gov.in/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class GeoWebService : System.Web.Services.WebService
{

    public GeoWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod(Description = "Bihar RoR Data with geo refrences..")]
    public string GetPlotData(string villageCode)
    {
        // Implement your data access logic here
        // Replace with actual data retrieval based on villageCode and surveyNumber

        // Sample data for demonstration purposes
        string json = "";
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["KrishIIUpdate"].ConnectionString);
        List<PlotData> PlotData1 = new List<PlotData>();
        cn.Open();
        string q = @"select districtname, tehsilname, villagecode, kide, surveynumber, plotgeometry, 
            plotarea, plotareaunit, projectioncode, b.* from Bihar_Geo1 a inner join [dbo].[Bihar_Geo2]
            b on a.kide=b.khasrano and a.villagecode=b.village_LGD_Code where a.villagecode=" + villageCode + "";
        SqlDataAdapter daSms = new SqlDataAdapter(q, cn);
        DataTable dtSms = new DataTable();
        daSms.Fill(dtSms);
        if (dtSms.Rows.Count > 0)
        {
            foreach (DataRow dr in dtSms.Rows)
            {
                PlotData plotData = new PlotData()
                {
                    districtname = dr["districtname"].ToString(),
                    tehsilname = dr["tehsilname"].ToString(),
                    villagecode = dr["villagecode"].ToString(),
                    surveynumber = dr["surveynumber"].ToString(),
                    plotgeometry = dr["plotgeometry"].ToString(), // Replace with actual geometry data
                    plotarea = dr["plotarea"].ToString(), // Replace with actual area
                    plotareaunit = dr["plotareaunit"].ToString(),
                    projectioncode = dr["projectioncode"].ToString(),
                    owner = new List<OwnerData>()
        {
            new OwnerData()
            {

 uniquecode =dr["uniquecode"].ToString(), owner_Number = dr["owner_Number"].ToString(), land_Usage_type = dr["land_Usage_type"].ToString(), ownership_type = dr["ownership_type"].ToString(),
                owner_Name = dr["owner_Name"].ToString(), total_Area = dr["total_Area"].ToString(), indentifier_Name = dr["indentifier_Name"].ToString(),
                extend = dr["extend"].ToString(), village_LGD_Code = dr["village_LGD_Code"].ToString(), indentifier_type = dr["indentifier_type"].ToString(), area_unit  = dr["area_unit"].ToString(), 
                khasrano = dr["khasrano"].ToString(),
                // ... Fill in owner details based on your data
            }
        }
                };
                PlotData1.Add(plotData);
            }
        }
 
 json = Newtonsoft.Json.JsonConvert.SerializeObject(PlotData1);
 
        return json;
    }

}

public class PlotData
{
    public string districtname { get; set; }
    public string tehsilname { get; set; }
    public string villagecode { get; set; }
    public string surveynumber { get; set; }
    public string plotgeometry { get; set; }
    public string plotarea { get; set; }
    public string plotareaunit { get; set; }
    public string projectioncode { get; set; }
    public List<OwnerData> owner { get; set; }
}

public class OwnerData
{
    public string uniquecode { get; set; }
    public string owner_Number { get; set; }
    public string land_Usage_type { get; set; }
    public string ownership_type { get; set; }
    public string owner_Name { get; set; }
    public string total_Area { get; set; }
    public string indentifier_Name { get; set; }
    public string extend { get; set; }
    public string village_LGD_Code { get; set; }
    public string indentifier_type { get; set; }
    public string area_unit { get; set; }
    public string khasrano { get; set; }
}