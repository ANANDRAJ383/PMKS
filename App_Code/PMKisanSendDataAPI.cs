using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

/// <summary>
/// Summary description for PMKisanSendDataAPI
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class PMKisanSendDataAPI : System.Web.Services.WebService
{
    clsDataAccessPMKisan objcls = new clsDataAccessPMKisan();
    public PMKisanSendDataAPI()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }


    [WebMethod(Description = "PMKISAN-RURAL-Data for Upload")]
    public Farmer[] FarmerRURALDataforUpload(string StateCode, string SendDate, string password)
    {
        objcls.storeProcedure.NewStoreProcedure("SP_GetRuralDataForUpload");
        objcls.storeProcedure.FieldName = "StateCode,SendDate";
        objcls.storeProcedure.FieldValue = new object[] { StateCode, SendDate };
        DataTable dt = objcls.storeProcedure.getData();
        List<Farmer> Farmer = new List<Farmer>();
        try
        {
            if (dt.Rows.Count > 0)
            {
                if (password == "PMKS2022")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Farmer d_r = new Farmer();
                        d_r.State_Ref_Number = dr["State_Ref_Number"].ToString();
                        d_r.StateCode = dr["StateCode"].ToString();
                        d_r.DistrictCode = dr["DistrictCode"].ToString();
                        d_r.Sub_District_Code = dr["Sub_District_Code"].ToString();
                        d_r.BlockCode = dr["BlockCode"].ToString();
                        d_r.VillageCode = dr["VillageCode"].ToString();
                        d_r.Farmer_Name = dr["Farmer_Name"].ToString();
                        d_r.Gender = dr["Gender"].ToString();
                        d_r.Farmer_Category = dr["Farmer_Category"].ToString();
                        d_r.Identity_Proof_Type = dr["Identity_Proof_Type"].ToString();
                        d_r.Identity_Proof_No = dr["Identity_Proof_No"].ToString();
                        d_r.IFSC_Code = dr["IFSC_Code"].ToString();
                        d_r.Bank_Account_Number = dr["Bank_Account_Number"].ToString();
                        d_r.MobileNo = dr["MobileNo"].ToString();
                        d_r.DOB = dr["DOB"].ToString();
                        d_r.Father_Mother_Husband_Name = dr["Father_Mother_Husband_Name"].ToString();
                        d_r.HomeAddress = dr["HomeAddress"].ToString();
                        d_r.Ownership_Single_Joint = dr["Ownership_Single_Joint"].ToString();
                        d_r.Sr_No = dr["Sr_No"].ToString();
                        d_r.Survey_Khata_No = dr["Survey_Khata_No"].ToString();
                        d_r.Khasra_Drag_No = dr["Khasra_Drag_No"].ToString();
                        d_r.Area = dr["Area"].ToString();
                        d_r.FarmerType = dr["FarmerType"].ToString();
                        Farmer.Add(d_r);

                    }
                }
            }
        }
        catch
        {

        }
        return Farmer.ToArray();



    }

    public class Farmer
    {
        private string _State_Ref_Number = string.Empty;
        public string State_Ref_Number
        {
            get { return _State_Ref_Number; }
            set { _State_Ref_Number = value; }
        }
        private string _StateCode = string.Empty;
        public string StateCode
        {
            get { return _StateCode; }
            set { _StateCode = value; }
        }
        private string _DistrictCode = string.Empty;
        public string DistrictCode
        {
            get { return _DistrictCode; }
            set { _DistrictCode = value; }
        }

        private string _Sub_District_Code = string.Empty;
        public string Sub_District_Code
        {
            get { return _Sub_District_Code; }
            set { _Sub_District_Code = value; }
        }
        private string _BlockCode = string.Empty;
        public string BlockCode
        {
            get { return _BlockCode; }
            set { _BlockCode = value; }
        }
        private string _VillageCode = string.Empty;
        public string VillageCode
        {
            get { return _VillageCode; }
            set { _VillageCode = value; }
        }
        private string _Farmer_Name = string.Empty;
        public string Farmer_Name
        {
            get { return _Farmer_Name; }
            set { _Farmer_Name = value; }
        }
        private string _Gender = string.Empty;
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        private string _Farmer_Category = string.Empty;
        public string Farmer_Category
        {
            get { return _Farmer_Category; }
            set { _Farmer_Category = value; }
        }
        private string _Identity_Proof_Type = string.Empty;
        public string Identity_Proof_Type
        {
            get { return _Identity_Proof_Type; }
            set { _Identity_Proof_Type = value; }
        }
        private string _Identity_Proof_No = string.Empty;
        public string Identity_Proof_No
        {
            get { return _Identity_Proof_No; }
            set { _Identity_Proof_No = value; }
        }
        private string _IFSC_Code = string.Empty;
        public string IFSC_Code
        {
            get { return _IFSC_Code; }
            set { _IFSC_Code = value; }
        }
        private string _Bank_Account_Number = string.Empty;
        public string Bank_Account_Number
        {
            get { return _Bank_Account_Number; }
            set { _Bank_Account_Number = value; }
        }
        private string _MobileNo = string.Empty;
        public string MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }

        private string _DOB = string.Empty;
        public string DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }
        private string _Father_Mother_Husband_Name = string.Empty;
        public string Father_Mother_Husband_Name
        {
            get { return _Father_Mother_Husband_Name; }
            set { _Father_Mother_Husband_Name = value; }
        }
        private string _HomeAddress = string.Empty;
        public string HomeAddress
        {
            get { return _HomeAddress; }
            set { _HomeAddress = value; }
        }
        private string _Ownership_Single_Joint = string.Empty;
        public string Ownership_Single_Joint
        {
            get { return _Ownership_Single_Joint; }
            set { _Ownership_Single_Joint = value; }
        }
        private string _Sr_No = string.Empty;
        public string Sr_No
        {
            get { return _Sr_No; }
            set { _Sr_No = value; }
        }
        private string _Survey_Khata_No = string.Empty;
        public string Survey_Khata_No
        {
            get { return _Survey_Khata_No; }
            set { _Survey_Khata_No = value; }
        }
        private string _Khasra_Drag_No = string.Empty;
        public string Khasra_Drag_No
        {
            get { return _Khasra_Drag_No; }
            set { _Khasra_Drag_No = value; }
        }
        private string _Area = string.Empty;
        public string Area
        {
            get { return _Area; }
            set { _Area = value; }
        }
        private string _FarmerType = string.Empty;
        public string FarmerType
        {
            get { return _FarmerType; }
            set { _FarmerType = value; }
        }
    }
}