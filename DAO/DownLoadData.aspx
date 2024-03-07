<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="DownloadData.aspx.cs" Inherits="DAO_DownloadData" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #1C6794; padding: 5px; margin-top: 5px; width: 100%;" align="center">Download Diesel Subsidy Data 2022-23 of District :- <asp:Label ID="lblDistrict" runat="server"></asp:Label></div><br />

        <div class="row">
             <div class="input-group mb-3 col-lg-6">
             <asp:Button ID="btnAcptData" runat="server" Text="Approved Data" CssClass="btn btn-success" OnClick="btnAcptData_Click"   />
             </div>

             <div class="input-group mb-3 col-lg-6">
            <asp:Button ID="btnRjctData" runat="server" Text="Reject Data" CssClass="btn btn-success" OnClick="btnRjctData_Click" />
             </div>
        </div>
</asp:Content>

