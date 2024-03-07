using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for Slideshow
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]

public class Slideshow : System.Web.Services.WebService {

public Slideshow () {

//Uncomment the following line if using designed components 
//InitializeComponent(); 
}

[System.Web.Services.WebMethod]
[System.Web.Script.Services.ScriptMethod]
public AjaxControlToolkit.Slide[] GetSlides()
{
string[] imagenames = System.IO.Directory.GetFiles(Server.MapPath("~/ImagesGal"));
AjaxControlToolkit.Slide[] photos = new AjaxControlToolkit.Slide[imagenames.Length];
for (int i = 0; i < imagenames.Length; i++)
{
string[] file = imagenames[i].Split('\\');
photos[i] = new AjaxControlToolkit.Slide("ImagesGal/" + file[file.Length - 1], file[file.Length - 1], "");
}
return photos;
}
}

