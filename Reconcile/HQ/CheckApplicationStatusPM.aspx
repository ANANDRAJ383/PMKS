<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="CheckApplicationStatusPM.aspx.cs" Inherits="CheckApplicationStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Application Status </div><br />
    <table class="table-bordered  table table-striped ">

        <tr >
           
            <td >
                  <center>
                      <asp:Image ID="imgbiharlogo" runat="server" ImageUrl="~/Images/biharlogo.png" />
                      <br /><br />
                <asp:Label ID="lbldisplay" runat="server" Text="कृषि विभाग, बिहार सरकार" Font-Size="XX-Large" Font-Bold="True" Font-Underline="False"></asp:Label>
                      <br />
                      <asp:Label ID="Label4" runat="server" Text="प्रधानमंत्री किसान सम्मान निधि योजना"  Font-Size="Large"   Font-Bold="True" Font-Underline="True" ></asp:Label>
                       </center>
            </td>
        </tr>
        </table>
<table class="table-bordered  table table-striped ">

        <tr>
            

                   <td>Enter Registeration Id </td>

                <td>
                    <asp:TextBox ID="txtRegId" runat="server" MaxLength="13" class="form-control" placeholder="Enter Registeration Id"></asp:TextBox>

                </td>
            <td>Application Type</td>
            <td> <asp:DropDownList ID="ddlApplicationType" runat="server" CssClass="form-select"
                  AutoPostBack="True" ValidationGroup="s" >
                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                 <asp:ListItem Value="New" >New</asp:ListItem>             
                <asp:ListItem Value="Recon" >Recon</asp:ListItem>
                <asp:ListItem Value="Re-Recon" >Re-Recon</asp:ListItem>
            </asp:DropDownList></td>
                <td >&nbsp;&nbsp;
                    <asp:Button ID="btnGet" runat="server" Text="Search" class="btn btn-success" OnClick="btnGet_Click" />
                </td>
        </tr>
    </table>
     <div >


         <br />
    <asp:Panel ID="Panel1" runat="server" GroupingText="किसान का विवरण">
    <table class="table-bordered  table table-striped " style="width: 100%;"> 
        <tr>
            <td><span>पंजीकरण  | Registration Id :-</span></td>
            <td style="color: #FF0000; font-size: large" >
                <asp:Label ID="lblRegistrationId" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>पंजीकरण  | Application Type :-</span></td>
            <td style="color: #FF0000; font-size: large" >
                <asp:Label ID="lblApplicationType" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
        </tr>
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
            <td><span>आईएफएससी कोड |IFSC Code :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblIFSC" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>खाता संख्या |Account No:-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblAC" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td>स्थिति | Status :-</td>
            <td colspan="3" style="color: #FF0000; font-size: large">
                <asp:Label ID="lblStatus" Font-Italic="True" runat="server" Font-Bold="True"></asp:Label><br />
                
            </td>
        </tr>
        
    </table>
        </asp:Panel>
         <asp:Panel ID="PnlACDetail" runat="server" GroupingText="एरिया कोडिनेटर का विवरण">
             <table class="table-bordered  table table-striped " style="width: 100%;"> 
        <tr>
            <td><span>स्थिति  | Status :-</span></td>
            <td style="color: #FF0000; font-size: large" >
                <asp:Label ID="lblACStaus" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>दिनांक  | Date :-</span></td>
            <td style="color: #FF0000; font-size: large" >
                <asp:Label ID="lblACDate" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
        </tr>
        
                 </table>

         </asp:Panel>
          
         <asp:Panel ID="pnlCO" runat="server" GroupingText="अंचल अधिकारी का विवरण">
             <table class="table-bordered  table table-striped " style="width: 100%;"> 
        <tr>
            <td><span>स्थिति  | Status :-</span></td>
            <td style="color: #FF0000; font-size: large" >
                <asp:Label ID="lblCOStaus" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>दिनांक  | Date :-</span></td>
            <td style="color: #FF0000; font-size: large" >
                <asp:Label ID="lblCODate" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
        </tr>
        
                 </table>

         </asp:Panel>

         <asp:Panel ID="pnlDAO" runat="server" GroupingText="जिला कृषि पदाधिकारी का विवरण">
             <table class="table-bordered  table table-striped " style="width: 100%;"> 
        <tr>
            <td><span>स्थिति  | Status :-</span></td>
            <td style="color: #FF0000; font-size: large" >
                <asp:Label ID="lblDAOStaus" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>दिनांक  | Date :-</span></td>
            <td style="color: #FF0000; font-size: large" >
                <asp:Label ID="lblDAODate" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
        </tr>
        
                 </table>

         </asp:Panel>

         <asp:Panel ID="pnlADMR" runat="server" GroupingText="ADM(Revenue) का विवरण">
             <table class="table-bordered  table table-striped " style="width: 100%;"> 
        <tr>
            <td><span>स्थिति  | Status :-</span></td>
            <td style="color: #FF0000; font-size: large" >
                <asp:Label ID="lblADMRStaus" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>दिनांक  | Date :-</span></td>
            <td style="color: #FF0000; font-size: large" >
                <asp:Label ID="lblADMRDate" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
        </tr>
        
                 </table>

         </asp:Panel>

        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                AllowPaging="false" PageSize="10" CssClass="table table-bordered  table-striped" AutoGenerateColumns="false" 
             Font-Size="16px" >
            <Columns>
             
                 <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Application Type" >
           
            <ItemTemplate>
                <asp:Label ID="lblatype" runat="server" Text='<%# Bind("atype") %>' Font-Bold="True" Font-Size="11" ForeColor="red"></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
                <asp:TemplateField HeaderText="Applicant Name" >
           
            <ItemTemplate>
                <asp:Label ID="lblMsg" runat="server" Text='<%# Bind("ApplicantName") %>' Font-Bold="True" Font-Size="11" ForeColor="red"></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
 <asp:TemplateField HeaderText="Status" >
           
            <ItemTemplate>
                <asp:Label ID="lblMsg" runat="server" Text='<%# Bind("C_Status") %>' Font-Bold="True" Font-Size="11" ForeColor="red"></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
            </Columns>
            <RowStyle />
        </asp:GridView>
        </div>

   
</asp:Content>

