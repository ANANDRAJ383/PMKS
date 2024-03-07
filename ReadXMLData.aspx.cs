using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class ReadXMLData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadXmlData();
    }

    private void LoadXmlData()
    {
        //XmlDocument xmlDoc = new XmlDocument();
        //xmlDoc.Load(Server.MapPath("https://dlrs.bihar.gov.in/GetMasters/api/DistrictInformation/get_detail_MaujaLGD?mlgd=244266&key=47914097-154D-4421-BE6B-5FD7328356D8"));

        string url = "https://dlrs.bihar.gov.in/GetMasters/api/DistrictInformation/get_detail_MaujaLGD?mlgd=244266&key=47914097-154D-4421-BE6B-5FD7328356D8"; // Replace with your XML URL

        try
        {
            // Create an XmlDocument instance
            XmlDocument xmlDoc = new XmlDocument();

            // Load XML data from the specified URL
            xmlDoc.Load(url);

            // Process the XML data as needed
            XmlNodeList nodes = xmlDoc.SelectNodes("//your/xpath/expression");
            foreach (XmlNode node in nodes)
            {
                // Access node properties and perform operations
                Console.WriteLine(node.InnerText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}