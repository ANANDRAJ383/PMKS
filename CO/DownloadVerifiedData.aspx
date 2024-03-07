<%@ Page Title="" Language="C#" MasterPageFile="COMasterPage.master" AutoEventWireup="true" CodeFile="DownloadVerifiedData.aspx.cs" Inherits="CO_DownloadVerifiedData" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Download PMkisan New | Recon | Re-recon Data</div><br />
    <table class="table-bordered  table table-striped " style="width: 100%;">
        <tr>
          
             <td>Block</td>
            <td> 
                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
            </asp:DropDownList> 
            </td>
             <td>Panchayat</td>
             <td>
                 <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select">
            </asp:DropDownList>
             </td>
            <td>Application Type</td>
            <td>

            <asp:DropDownList ID="ddlApplicationType" runat="server" CssClass="form-select" Width="100px">
                    <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                    <asp:ListItem Value="NEW" >NEW</asp:ListItem>
                    <asp:ListItem Value="RECON">RECON</asp:ListItem>
                <asp:ListItem Value="RE-RECON">RE-RECON</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>Status</td>
            <td>
            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select" Width="100px">
                    <asp:ListItem Value="0" >--Select--</asp:ListItem>
                    <asp:ListItem Value="1" >Accept</asp:ListItem>
                    <asp:ListItem Value="2" >Reject</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="btn btn-success" OnClick="btnDownload_Click"  /></td>
        </tr>
    </table>
</asp:Content>

