using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Messages
/// </summary>
public class Messages
{
    public static object ShowMessage(string intMsg)
    {
        object functionReturnValue = null;
        switch (intMsg)
        {
            case "1":
                functionReturnValue = "Data Saved Successfully";
                break;
            case "2":
                functionReturnValue = "Data Updated Successfully";
                break;
            case "3":
                functionReturnValue = "Data Deleted Successfully";
                break;
            case "4":
                functionReturnValue = "Error Occured";
                break;
            case "5":
                functionReturnValue = "Duplicate Record Found";
                break;
            case "6":
                functionReturnValue = "The Code already Exist";
                break;
            case "7":
                functionReturnValue = "password Change Successfully";
                break;
            case "8":
                functionReturnValue = "Forwarded Successfully";
                break;
            case "9":
                functionReturnValue = "Rejected Successfully";
                break;
            case "10":
                functionReturnValue = "Cancelled Successfully";
                break;
            case "11":
                functionReturnValue = "Due to data dependency record cannot be deleted";
                break;
            case "12":
                functionReturnValue = "Data Published Successfully";
                break;
            case "13":
                functionReturnValue = "Call Registered Successfully";
                break;
            case "14":
                functionReturnValue = "Your Password has been Reset and the updated Password sent to your MailId.";
                break;
            case "15":
                functionReturnValue = "User For NNO is not Configured";
                break;
            case "16":
                functionReturnValue = "User For SNA is not Configured";
                break;
            case "17":
                functionReturnValue = "User For DKM is not Configured";
                break;
            case "18":
                functionReturnValue = "User For Insurance Agency is not Configured";
                break;
            case "19":
                functionReturnValue = "Escalation Details is not Configured";
                break;
            case "20":
                functionReturnValue = "The selected user has already been tagged to locations.To add or remove the location,update the user record.";
                break;
            case "21":
                functionReturnValue = "Record Unlocked Successfully";
                break;
            case "22":
                functionReturnValue = "Your Account has been Locked";
                break;
            case "23":
                functionReturnValue = "Duplicate CIB License No. Found..";
                break;
            case "24":
                functionReturnValue = "License Approved..!!";
                break;
            case "25":
                functionReturnValue = "License Rejected..!!";
                break;
            case "26":
                functionReturnValue = "License Renewed..!!";
                break;
            case "27":
                functionReturnValue = "License Approved..!!";
                break;
            case "28":
                //Included By Bindeswari Sahoo on 17-Jun-2014
                functionReturnValue = "You can not enter record in back date of previous entry!";
                break;
            case "29":
                //Included By Bindeswari Sahoo on 17-Jun-2014
                functionReturnValue = "Progressive Value of Physical achievement and financial achievement must be greater than last date entry";
                break;
            case "30":
                //Included By Bindeswari Sahoo on 17-Jun-2014
                functionReturnValue = "Valid Upto should be grater than applied date";
                break;
            case "31":
                functionReturnValue = "License Is Inprogress..!!";
                break;
            default:
                //Commented by Manas Bej on 01-DEC-2012
                //functionReturnValue = "Nothing"; 
                /**********************************************************************/
                //Added By Manas Bej on 01-DEC-2012
                functionReturnValue = intMsg.ToString().Replace("'", "`");
                break;
        }
        return functionReturnValue;
    } 

}
