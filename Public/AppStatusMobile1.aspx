﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Public/PublicMasterPage.master" AutoEventWireup="true" CodeFile="AppStatusMobile1.aspx.cs" Inherits="Public_AppStatusMobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 22px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">
        <asp:Label ID="lblRegId" runat="server"></asp:Label>


         
    </div><br />

  
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
            <td>स्थिति | Status :-</td>
            <td colspan="3" style="color: #FF0000; font-size: large">
                <asp:Label ID="lblStatus" Font-Italic="True" runat="server" Font-Bold="True"></asp:Label><br />
                
            </td>
        </tr>
        <tr>
            <td colspan="4"><center><asp:Label ID="lblDate" Font-Italic="True" runat="server" Font-Bold="True" Font-Size="18pt"></asp:Label></center></td>
        </tr>
    </table>
                                </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>
