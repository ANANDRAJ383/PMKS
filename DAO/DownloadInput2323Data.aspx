<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="DownloadInput2323Data.aspx.cs" Inherits="CSC_DownloadeKYCData" EnableEventValidation = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Download Accept/Reject(DAO) Data</div><br />
    <table class="table-bordered  table table-striped " style="width: 100%;">
        <tr>
            <td>Status :</td>
             <td><asp:DropDownList ID="ddlDist" runat="server" CssClass="form-select" >
                 <asp:ListItem Text="स्वीकृत" Value="1"></asp:ListItem> 
                                      <asp:ListItem Text="अस्वीकृत" Value="2"></asp:ListItem>
            </asp:DropDownList>
             
                      </td>
            <td><asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="btn btn-success" OnClick="btnDownload_Click"  /></td>
        </tr>
    </table>
    


<div class="form-row">
    </div>

       
</asp:Content>

