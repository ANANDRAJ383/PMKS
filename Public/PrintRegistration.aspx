<%@ Page Title="" Language="C#" MasterPageFile="PublicMasterPage.master" AutoEventWireup="true" CodeFile="PrintRegistration.aspx.cs" Inherits="Public_PrintRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <script type="text/javascript">
    function printpage() {
        window.print();
    }
</script>
<script type="text/javascript">
    function Close() {
        window.close();
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlverdetails" runat="server" Width="100%" ScrollBars="Auto" Font-Names="Comic Sans MS" Font-Size="14px" >
     <table class="table-bordered  table table-striped " width="100%"> 
       <tr>
           <td colspan="2">
     <asp:Image ID="imgbiharlogo" runat="server" ImageUrl="~/Images/biharlogo.png" />
              
 </td>
       <td>
            <asp:Label ID="lbldisplay" runat="server" Text="कृषि विभाग, बिहार सरकार"   Font-Size="XX-Large"   Font-Bold="True" Font-Underline="False" ></asp:Label>
       </td> 
       </tr>
         <tr>
             <td colspan="3">
        <center>
            <asp:Label ID="Label2" runat="server" Text="पंजीकरण पावती"  Font-Size="Large"   Font-Bold="True" Font-Underline="True" ></asp:Label>
            </center> 
             </td>
         </tr>
       
 
 
 <tr>
            <td colspan="3"  align="justify" ><font style="font-family: verdana; font-size: large; text-align:justify;" >   प्रिय किसान <asp:Label ID="lblName1" runat="server" Text=""></asp:Label> आपका पंजीकरण स्वीकार कर लिया गया है | आपका पंजीकरण संख्या है-<br />
                <asp:Label ID="lblRegId" runat="server" Font-Bold="true" Text=""></asp:Label>  ,  कृपया इसे सुरक्षित रखे |यह पंजीकरण संख्या अनुदान प्राप्ति के लिये अनिवार्य है |                  
            </font>
            
        <asp:Button ID="Button1" runat="server" Text="Print" Font-Names="Verdana" 
          Font-Bold="true" Width="100px"  OnClientClick="javascript:printpage();" />

        </td>
        </tr>
        
     </table>
   

</asp:Panel>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
    <table class="table-bordered  table table-striped " style="width: 100%;"> 
        <tr>
            <td><span>नाम | Name :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>पिता/पति का नाम | Father/Husband Name :-</span></td>
            <td style="color: #FF0000; font-size: large"><asp:Label ID="lblFName" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
       <tr>
            <td><span>मोबाइल नंबर | Mobile Number :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblMobile" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>लिंग | Gender :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblGender" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td><span>जन्म की तारीख | Date of birth :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblDOB" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>किसान प्रकार | Farmer type :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblFarmerType" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td><span>आधार संख्या | Aadhaar :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblAadhaar" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>जाति श्रेणी | Cast Category:-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblCast" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td><span>जिला | District :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblDist" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>प्रखंड |Block:-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblBlock" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
         <tr>
            <td><span>पंचायत |Panchayat :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblPanchayat" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>गाँव |Village:-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblVillage" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td>स्थिति | Status :-</td>
            <td colspan="3" style="color: #FF0000; font-size: large">
                <asp:Label ID="lblStatus" Font-Italic="True" runat="server" Font-Bold="True"></asp:Label><br />
                
            </td>
        </tr>
         <tr>
             <td colspan="4">**<span class="auto-style1"><strong>प्रिय किसान, पंजीकरण के 24 घंटे के उपरांत ही अनुदान आवेदन करें | </strong></span>  </td>
         </tr>
        <tr>
            <td align="center" colspan="4">
                <font style="font-family: 'courier New', Courier, monospace; font-size: x-large; font-weight: bold">&nbsp;डी.बी.टी.हेल्पलाइन नंबर: 0612-2233555 / 1800-180-1551</font></td>
        </tr>
       
    </table>
                                </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>

