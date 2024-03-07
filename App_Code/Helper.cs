using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Helper
/// </summary>
public static class Helper
{
    //public Helper()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}
    public const string UI_Culture = "UI.CULTURE";
    public const string User_Id = "UserId";
    public const string Loc_Id="locId";
    public const string location="location";
    public const string LevelID="LevelID";
    public const string DeptId="DeptId";
    public const string Department="Department";   
    public const string Username="userName"; 
    public const string Full_Name="fullName";  
       
}
public class Billingual:Page 
{
    protected override void InitializeCulture()
    {
        if (Session[Helper.UI_Culture] == null)
        {
            string culture = Request.UserLanguages[0];
            if (culture.Contains('-'))
                culture = culture.Split('-')[0].ToLower() + "-" + culture.Split('-')[1].ToUpper();
            Session[Helper.UI_Culture] = culture;//CultureInfo.CurrentCulture.Name;
        }
        ///To Programatically change the UICulture 
        if (Session[Helper.UI_Culture] != null)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                System.Globalization.CultureInfo.CreateSpecificCulture(Session[Helper.UI_Culture].ToString());
        }
        

        base.InitializeCulture();
    }
}

