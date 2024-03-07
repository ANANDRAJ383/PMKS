<%@ Page Title="" Language="C#" MasterPageFile="~/Public/PublicMasterPage.master" AutoEventWireup="true" CodeFile="PMKisanAppStatus.aspx.cs" Inherits="Public_PMKisanAppStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 22px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">PM KISAN 
        <asp:Label ID="lblRegId" runat="server"></asp:Label></div><br />

     <table class="table-bordered  table table-striped ">

        <tr >
           
            <td >
                  <center>
                      <asp:Image ID="imgbiharlogo" runat="server" ImageUrl="~/Images/biharlogo.png" />
                      <br /><br />
                <asp:Label ID="lbldisplay" runat="server" Text="कृषि विभाग, बिहार सरकार" Font-Size="XX-Large" Font-Bold="True" Font-Underline="False"></asp:Label>
                       </center>
            </td>
        </tr>
        </table>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
    <%--<table class="table-bordered  table table-striped " style="width: 100%;"> 
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
            <td><span>किसान प्रकार | Farmer type :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblFarmerType" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td><span>आधार नंबर | Aadhaar Number :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblAadhaar" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>किसान प्रकार | Farmer type :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="Label2" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
           
            
             <td><span>जिला | District :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblDist" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>प्रखंड | Block :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblBlock" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
           
            
             <td><span>पंचायत | Panchayat :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblPanchayat" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>गांव | Village :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblVillage" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td>स्थिति | Status :-</td>
            <td colspan="3" style="color: #FF0000; font-size: large">
                <asp:Label ID="lblStatus" Font-Italic="True" runat="server" Font-Bold="True"></asp:Label><br />
                
            </td>
        </tr>
        
    </table>--%>



                                </ContentTemplate>
                        </asp:UpdatePanel>
   
         <div >
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

