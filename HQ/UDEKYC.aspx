<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="UDEKYC.aspx.cs" Inherits="HQ_UDEKYC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    Select Table Name<asp:DropDownList ID="ddlTable" runat="server">
    </asp:DropDownList>
<asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button ID="Button1" Text="Upload" OnClick="Upload" runat="server" />  

    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="18px" 
        ForeColor="#0066FF" ></asp:Label>
</asp:Content>

