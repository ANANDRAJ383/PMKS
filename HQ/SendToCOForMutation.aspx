<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="SendToCOForMutation.aspx.cs" Inherits="HQ_SendToCOForMutation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Registration send back to CO Login for land mutation date entry</div><br />

    <table class="table-bordered  table table-striped " style="width: 100%;">
        <tr>
            <td>
                Enter Registration Id 
            </td>
            <td><asp:TextBox ID="txtRegId" runat="server" class="form-control" placeholder="Registration Id" ></asp:TextBox></td>
            <td><asp:Button ID="btnView" class="btn btn-primary b-btn" runat="server" Text="Send" OnClick="btnView_Click"  /></td>
        </tr>
        <tr >
            <td colspan="3"><asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="18pt" ForeColor="#6600FF"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

