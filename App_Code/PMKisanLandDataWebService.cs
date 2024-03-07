using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using esms_client;
using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for PMKisanLandDataWebService
/// </summary>
[WebService(Namespace = "https://dbtagriculture.bihar.gov.in/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class PMKisanLandDataWebService : System.Web.Services.WebService
{
    public PMKisanLandDataWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod(Description = "PMKISAN-Landetails-URBAN")]
    public FarmerLandDetails[] FarmerLandDetailsUrban(string DistCodeLG, string password)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString);
        List<FarmerLandDetails> FarmerLandDetails = new List<FarmerLandDetails>();
        try
        {
            if (password == "Kr!5h!2022")
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"select r.Registration_ID as Farmer_Registration_No, convert (VARCHAR(MAX) , hashbytes ('SHA2_256', CONVERT (VARCHAR (MAX), r.AadhaarNumber )),2) Farmer_Registration_No_HASH,
                a.ApplicantName as Farmer_Name, a.Father_Husband_Name Father_Name,'R' LandLocation, l.keshrano  AS LandID , l.Khatano  AS LandOwnerShipID,l.thanano as LandThanaNo ,
                '10' AS LandStateLGDCode, d.DistLGCode AS LandDistrictLGDCode, b.towncode as LandTownLGDCode ,b.WardCode AS LandWardLGDCode ,
                b.wardname AS LandWardName, 
                'N/A' as TypeOfMutation , 'N/A' as DateOfMutation,'DISMIL' LandAreaMeasurementUnit, L.rakwa  AS LandArea,'N/A' as LandTransferDoneBefore01022019, 'N/A' as LandOwnershipType
                from Registration_PMKISAN a inner join Registration_PMKIsan_LandDetails l
                on a.Registration_ID=l.RegistrationID 
                inner join Registration r on r.Registration_ID=a.Registration_ID 
                inner join Districts d on d.DistCode=L.Distcode 
                inner join URBAN_MASTER b on   r.VillageCode=b.WardCode  
                where XMLStatus=1 and d.DistLGCode=@DistCodeLG", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                da.SelectCommand.Parameters.AddWithValue("@DistCodeLG", DistCodeLG);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FarmerLandDetails Details = new FarmerLandDetails();
                        Details.Farmer_Registration_No_Bihar = dr["Farmer_Registration_No"].ToString();
                        Details.Farmer_Registration_No_Hash = dr["Farmer_Registration_No_HASH"].ToString();
                        Details.Farmer_Name = dr["Farmer_Name"].ToString();
                        Details.Father_Name = dr["Father_Name"].ToString();
                        Details.LandLocation = dr["LandLocation"].ToString();
                        Details.LandOwnerShipID = dr["LandOwnerShipID"].ToString();
                        Details.LandID = dr["LandID"].ToString();
                        Details.LandThanaNo = dr["LandThanaNo"].ToString();
                        Details.LandStateLGDCode = dr["LandStateLGDCode"].ToString();
                        Details.LandDistrictLGDCode = dr["LandDistrictLGDCode"].ToString();
                        Details.LandTownLGDCode = dr["LandTownLGDCode"].ToString();
                        Details.LandWardLGDCode = dr["LandWardLGDCode"].ToString();
                        Details.LandWardName = dr["LandWardName"].ToString();
                        Details.TypeOfMutation = dr["TypeOfMutation"].ToString();
                        Details.DateOfMutation = dr["DateOfMutation"].ToString();
                        Details.LandAreaMeasurementUnit = dr["LandAreaMeasurementUnit"].ToString();
                        Details.LandArea = dr["LandArea"].ToString();
                        Details.LandOwnerShipType = dr["LandOwnershipType"].ToString();
                        Details.LandTransferDoneBefore01022019 = dr["LandTransferDoneBefore01022019"].ToString();
                        FarmerLandDetails.Add(Details);
                    }
                }

            }


        }
        catch (Exception ex) { }
        finally { cn.Close(); }

        return FarmerLandDetails.ToArray();
    }

    [WebMethod(Description = "PMKISAN-Landetails-Rural")]
    public FarmerLandDetailsRural[] FarmerLandDetailsRural(string DistCodeLG, string password)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["KrishIII"].ConnectionString);
        List<FarmerLandDetailsRural> FarmerLandDetails = new List<FarmerLandDetailsRural>();
        try
        {
            if (password == "Kr!5h!2022")
            {
                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"select r.Registration_ID as Farmer_Registration_No, convert (VARCHAR(MAX) , hashbytes ('SHA2_256', CONVERT (VARCHAR (MAX), r.AadhaarNumber )),2) Farmer_Registration_No_HASH,
                a.ApplicantName as Farmer_Name, a.Father_Husband_Name Father_Name,'R' LandLocation, l.keshrano  AS LandID , l.Khatano  AS LandOwnerShipID,l.thanano as LandThanaNo,
                '10' AS LandStateLGDCode, d.DistLGCode AS LandDistrictLGDCode, a.BlockCode as LandSubDistrictLGDCode,B.Block_LGCode AS LandBlockLGDCode ,
                c.villagecode AS LandVillageLGDCode, c.villagename AS LandVillageName, 
                'N/A' as TypeOfMutation , 'N/A' as DateOfMutation,'DISMIL' LandAreaMeasurementUnit,L.rakwa  AS LandArea,'N/A' as LandTransferDoneBefore01022019, 'N/A' as LandOwnershipType
                from Registration_PMKISAN a inner join Registration_PMKIsan_LandDetails l
                on a.Registration_ID=l.RegistrationID 
                inner join Registration r on r.Registration_ID=a.Registration_ID 
                inner join Districts d on d.DistCode=L.Distcode 
                INNER JOIN Blocks B ON B.BlockCode=L.BlockCode
                inner join RURAL_MASTER c on cast(r.VillageCode as bigint)=c.VillageCode  
                where   XMLStatus=1 and d.DistLGCode=@DistCodeLG", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                da.SelectCommand.Parameters.AddWithValue("@DistCodeLG", DistCodeLG);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        FarmerLandDetailsRural Details = new FarmerLandDetailsRural();
                        Details.Farmer_Registration_No_Bihar = dr["Farmer_Registration_No"].ToString();
                        Details.Farmer_Registration_No_Hash = dr["Farmer_Registration_No_HASH"].ToString();
                        Details.Farmer_Name = dr["Farmer_Name"].ToString();
                        Details.Father_Name = dr["Father_Name"].ToString();
                        Details.LandLocation = dr["LandLocation"].ToString();
                        Details.LandOwnerShipID = dr["LandOwnerShipID"].ToString();
                        Details.LandID = dr["LandID"].ToString();
                        Details.LandThanaNo = dr["LandThanaNo"].ToString();
                        Details.LandStateLGDCode = dr["LandStateLGDCode"].ToString();
                        Details.LandDistrictLGDCode = dr["LandDistrictLGDCode"].ToString();
                        Details.LandSubDistrictLGDCode = dr["LandSubDistrictLGDCode"].ToString();
                        Details.LandBlockLGDCode = dr["LandBlockLGDCode"].ToString();
                        Details.LandVillageLGDCode  = dr["LandVillageLGDCode"].ToString();
                        Details.LandVillageName = dr["LandVillageName"].ToString();
                        Details.TypeOfMutation = dr["TypeOfMutation"].ToString();
                        Details.DateOfMutation = dr["DateOfMutation"].ToString();
                        Details.LandAreaMeasurementUnit = dr["LandAreaMeasurementUnit"].ToString();
                        Details.LandArea = dr["LandArea"].ToString();
                        Details.LandTransferDoneBefore01022019 = dr["LandTransferDoneBefore01022019"].ToString();
                        Details.LandOwnerShipType = dr["LandOwnershipType"].ToString();
                        FarmerLandDetails.Add(Details);
                    }
                }

            }


        }
        catch (Exception ex) { }
        finally { cn.Close(); }
        return FarmerLandDetails.ToArray();
    }
}

public class FarmerLandDetails
{
    private string _Farmer_Registration_No_Bihar = string.Empty;
    private string _Farmer_Registration_No_Hash = string.Empty;
    private string _Farmer_Name = string.Empty;
    private string _Father_Name = string.Empty;
    private string _LandLocation = string.Empty;
    private string _LandOwnerShipID = string.Empty;
    private string _LandID = string.Empty;
    private string _LandThanaNo = string.Empty;
    private string _LandStateLGDCode = string.Empty;
    private string _LandDistrictLGDCode = string.Empty;
    private string _LandTownLGDCode = string.Empty;
    private string _LandWardLGDCode = string.Empty;
    private string _LandWardName = string.Empty;
    private string _TypeOfMutation = string.Empty;
    private string _DateOfMutation = string.Empty;
    private string _LandAreaMeasurementUnit = string.Empty;
    private string _LandArea = string.Empty;
    private string _LandOwnerShipType = string.Empty;
    private string _LandTransferDoneBefore01022019 = string.Empty;

    public string Farmer_Registration_No_Bihar
    {
        get { return _Farmer_Registration_No_Bihar; }
        set { _Farmer_Registration_No_Bihar = value; }
    }
    public string Farmer_Registration_No_Hash
    {
        get { return _Farmer_Registration_No_Hash; }
        set { _Farmer_Registration_No_Hash = value; }
    }
    public string Farmer_Name
    {
        get { return _Farmer_Name; }
        set { _Farmer_Name = value; }
    }
    public string Father_Name
    {
        get { return _Father_Name; }
        set { _Father_Name = value; }
    }
    public string LandLocation
    {
        get { return _LandLocation; }
        set { _LandLocation = value; }
    }
    public string LandOwnerShipID
    {
        get { return _LandOwnerShipID; }
        set { _LandOwnerShipID = value; }
    }
    public string LandID
    {
        get { return _LandID; }
        set { _LandID = value; }
    }
    public string LandThanaNo
    {
        get { return _LandThanaNo; }
        set { _LandThanaNo = value; }
    }
    public string LandStateLGDCode
    {
        get { return _LandStateLGDCode; }
        set { _LandStateLGDCode = value; }
    }
    public string LandDistrictLGDCode
    {
        get { return _LandDistrictLGDCode; }
        set { _LandDistrictLGDCode = value; }
    }
    public string LandTownLGDCode
    {
        get { return _LandTownLGDCode; }
        set { _LandTownLGDCode = value; }
    }
    public string LandWardLGDCode
    {
        get { return _LandWardLGDCode; }
        set { _LandWardLGDCode = value; }
    }
    public string LandWardName
    {
        get { return _LandWardName; }
        set { _LandWardName = value; }
    }
    public string TypeOfMutation
    {
        get { return _TypeOfMutation; }
        set { _TypeOfMutation = value; }
    }
    public string DateOfMutation
    {
        get { return _DateOfMutation; }
        set { _DateOfMutation = value; }
    }
    public string LandAreaMeasurementUnit
    {
        get { return _LandAreaMeasurementUnit; }
        set { _LandAreaMeasurementUnit = value; }
    }
    public string LandArea
    {
        get { return _LandArea; }
        set { _LandArea = value; }
    }
    public string LandOwnerShipType
    {
        get { return _LandOwnerShipType; }
        set { _LandOwnerShipType = value; }
    }
    public string LandTransferDoneBefore01022019
    {
        get { return _LandTransferDoneBefore01022019; }
        set { _LandTransferDoneBefore01022019 = value; }
    }


}
public class FarmerLandDetailsRural
{
    private string _Farmer_Registration_No_Bihar = string.Empty;
    private string _Farmer_Registration_No_Hash = string.Empty;
    private string _Farmer_Name = string.Empty;
    private string _Father_Name = string.Empty;
    private string _LandLocation = string.Empty;
    private string _LandOwnerShipID = string.Empty;
    private string _LandID = string.Empty;
    private string _LandThanaNo = string.Empty;
    private string _LandStateLGDCode = string.Empty;
    private string _LandDistrictLGDCode = string.Empty;
    private string _LandSubDistrictLGDCode = string.Empty;
    private string _LandBlockLGDCode = string.Empty;
    private string _LandVillageLGDCode = string.Empty;
    private string _LandVillageName = string.Empty;
    private string _TypeOfMutation = string.Empty;
    private string _DateOfMutation = string.Empty;
    private string _LandAreaMeasurementUnit = string.Empty;
    private string _LandArea = string.Empty;
    private string _LandTransferDoneBefore01022019 = string.Empty;
    private string _LandOwnerShipType = string.Empty;

    public string Farmer_Registration_No_Bihar
    {
        get { return _Farmer_Registration_No_Bihar; }
        set { _Farmer_Registration_No_Bihar = value; }
    }
    public string Farmer_Registration_No_Hash
    {
        get { return _Farmer_Registration_No_Hash; }
        set { _Farmer_Registration_No_Hash = value; }
    }
    public string Farmer_Name
    {
        get { return _Farmer_Name; }
        set { _Farmer_Name = value; }
    }
    public string Father_Name
    {
        get { return _Father_Name; }
        set { _Father_Name = value; }
    }
    public string LandLocation
    {
        get { return _LandLocation; }
        set { _LandLocation = value; }
    }
    public string LandOwnerShipID
    {
        get { return _LandOwnerShipID; }
        set { _LandOwnerShipID = value; }
    }
    public string LandID
    {
        get { return _LandID; }
        set { _LandID = value; }
    }
    public string LandThanaNo
    {
        get { return _LandThanaNo; }
        set { _LandThanaNo = value; }
    }
    public string LandStateLGDCode
    {
        get { return _LandStateLGDCode; }
        set { _LandStateLGDCode = value; }
    }
    public string LandDistrictLGDCode
    {
        get { return _LandDistrictLGDCode; }
        set { _LandDistrictLGDCode = value; }
    }
    public string LandSubDistrictLGDCode
    {
        get { return _LandSubDistrictLGDCode; }
        set { _LandSubDistrictLGDCode = value; }
    }
    public string LandBlockLGDCode
    {
        get { return _LandBlockLGDCode; }
        set { _LandBlockLGDCode = value; }
    }
    public string LandVillageLGDCode
    {
        get { return _LandVillageLGDCode; }
        set { _LandVillageLGDCode = value; }
    }
    public string LandVillageName
    {
        get { return _LandVillageName; }
        set { _LandVillageName = value; }
    }
    public string TypeOfMutation
    {
        get { return _TypeOfMutation; }
        set { _TypeOfMutation = value; }
    }
    public string DateOfMutation
    {
        get { return _DateOfMutation; }
        set { _DateOfMutation = value; }
    }
    public string LandAreaMeasurementUnit
    {
        get { return _LandAreaMeasurementUnit; }
        set { _LandAreaMeasurementUnit = value; }
    }
    public string LandArea
    {
        get { return _LandArea; }
        set { _LandArea = value; }
    }
    
    public string LandTransferDoneBefore01022019
    {
        get { return _LandTransferDoneBefore01022019; }
        set { _LandTransferDoneBefore01022019 = value; }
    }
    public string LandOwnerShipType
    {
        get { return _LandOwnerShipType; }
        set { _LandOwnerShipType = value; }
    }

}
