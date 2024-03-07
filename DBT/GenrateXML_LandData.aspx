<%@ Page Title="" Language="C#" MasterPageFile="DBTMasterPage.master" AutoEventWireup="true" CodeFile="GenrateXML_LandData.aspx.cs" Inherits="DBT_GenrateXML_LandData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Generate XML </div>
    <br/><br/>
    <table class="table-bordered  table table-striped ">

        <tr>
            <td>
                Total Count:-
            </td>
            <td>
                 <asp:Label ID="lblTotal" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
            <td>

                <asp:Button ID="btnGenrateXML_LandData" runat="server" Text="Genrate XML (Death)" CssClass="btn btn-success" OnClick="btnGenrateXML_LandData_Click" /> 
            </td>
            
            <td> <asp:Button ID="btnUpdate" runat="server" Text="Update Status (Death)" CssClass="btn btn-success" OnClick="btnUpdate_Click"  /></td>
        </tr>
     <tr>
            <td>
                Total Count:-
            </td>
            <td>
                 <asp:Label ID="lblTotalLand" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </td>
            <td>

                <asp:Button ID="btnGenrateXMLLand" runat="server" Text="Genrate XML (Land)" CssClass="btn btn-success" OnClick="btnGenrateXMLLand_Click" /> 
            </td>
            
            <td> <asp:Button ID="btnUpdateLand" runat="server" Text="Update Status (Land)" CssClass="btn btn-success" OnClick="btnUpdateLand_Click"  /></td>
        </tr>
    </table>
</asp:Content>

