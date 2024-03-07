<%@ Page Title="" Language="C#" MasterPageFile="DBTMasterPage.master" AutoEventWireup="true" CodeFile="Drought1819status.aspx.cs" Inherits="DBT_Drought1819status" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table class="table-bordered  table table-striped ">
         <tr>
            
                <td  >Enter Registration Number:</td>
                <td ><asp:TextBox ID="txtRegId" runat="server" MaxLength="13"></asp:TextBox></td>
                <td><asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn-danger" OnClick="btnShow_Click"  /></td>
            </tr>
         
        </table>
      <table class="table-bordered  table table-striped ">
            <tr>
                <td>Application ID:</td>
            
                  <td>
                      <asp:Label ID="lblAppId" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                </td>
                <td>Applicant Name:</td>
                <td>
                    <asp:Label ID="lblAppName" runat="server" Font-Bold="True" ForeColor="#0033CC"></asp:Label>
                </td>
            </tr>
           
            
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="#006600"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
           
            
        </table>
</asp:Content>

