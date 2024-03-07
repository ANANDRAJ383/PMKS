<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppStatusMobile.aspx.cs" Inherits="AppStatusMobile" EnableEventValidation = "false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="vendor/bootstrap/css/bootstrap.min.css" />
    <!-- Custom styles for this template -->
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="~/css/base-responsive.css" />
    <link rel="stylesheet" href="../css/animate.min.css" />
    <link rel="stylesheet" href="../css/slicknav.min.css" />
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link href="../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="../css/entryform.css" />
</head>
<body>
    <form id="form1" runat="server">
       <div class="signup-form">
           
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Registration Detail of </div><br />
            <div class="row">

                 <center>
                      <asp:Image ID="imgbiharlogo" runat="server" ImageUrl="~/Images/biharlogo.png" />
                      <br /><br />
                <asp:Label ID="lbldisplay" runat="server" Text="कृषि विभाग, बिहार सरकार" Font-Size="XX-Large" Font-Bold="True" Font-Underline="False"></asp:Label>
                       </center>
            </div>
            

                <div class="form-group">
            <span>RegistrationId :-</span>          
           <asp:Label ID="lblRegistrationId" runat="server" Font-Bold="True" Font-Italic="True"  class="form-control"></asp:Label>
        </div>
                <div  class="form-group">
            <span>नाम | Name :-</span>          
           <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Italic="True"  class="form-control"></asp:Label>
        </div>
                <div class="form-group">
            <span>पिता/पति का नाम | Father/Husband Name :-</span>         
           <asp:Label ID="lblFName" runat="server" Font-Bold="True" Font-Italic="True"  class="form-control"></asp:Label>
        </div>
                <div class="form-group">
            <span>मोबाइल नंबर | Mobile Number :-</span>        
           <asp:Label ID="lblMobile" runat="server" Font-Bold="True" Font-Italic="True"  class="form-control"></asp:Label>
        </div>
                <div class="form-group">
            <span>लिंग | Gender :-</span>          
           <asp:Label ID="lblGender" runat="server" Font-Bold="True" Font-Italic="True" class="form-control"></asp:Label>
        </div>
                <div class="form-group">
            <span>जन्म की तारीख | Date of birth :-</span>         
           <asp:Label ID="lblDOB" runat="server" Font-Bold="True" Font-Italic="True" class="form-control"></asp:Label>
        </div>
                <div class="form-group">
            <span>किसान प्रकार | Farmer type :-</span>        
           <asp:Label ID="lblFarmerType" runat="server" Font-Bold="True" Font-Italic="True" class="form-control"></asp:Label>
        </div>
                <div class="form-group">
                    <span>आधार संख्या | Aadhaar :-</span>
                    <asp:Label ID="lblAadhaar" runat="server" Font-Bold="True" Font-Italic="True" class="form-control"></asp:Label>
                </div>
                <div class="form-group">
                    <span>जाति श्रेणी | Cast Category :-</span>
                    <asp:Label ID="lblCast" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
                </div>
                <div class="form-group">
                    <span>जिला | District :-</span>
                    <asp:Label ID="lblDist" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
                </div>
                <div class="form-group">
                    <span>प्रखंड |Block :-</span>
                    <asp:Label ID="lblBlock" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
                </div>
                <div class="form-group">
                    <span>पंचायत |Panchayat :-</span>
                    <asp:Label ID="lblPanchayat" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
                </div>
                <div class="form-group">
                    <span>गाँव |Village :-</span>
                    <asp:Label ID="lblVillage" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
                </div>
                <div class="form-group">
                    <span>आईएफएससी कोड |IFSC Code :-</span>
                    <asp:Label ID="lblIFSC" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
                </div>
                <div class="form-group">
                    <span>खाता संख्या |Account No :-</span>
                    <asp:Label ID="lblAC" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
                </div>
                <div class="form-group">
                    <span>स्थिति | Status :-</span>
                    <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label>
                </div>

            </div>
           </div>
    </form>
</body>
</html>
