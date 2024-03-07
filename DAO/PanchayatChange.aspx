<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="PanchayatChange.aspx.cs" Inherits="DAO_PanchayatChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">पंचायत का नाम/ग्राम का नाम बदलें<asp:Label ID="lblRType" runat="server" ></asp:Label></div>
    <br />
      <asp:Panel ID="pnlreg" runat="server" Font-Names="verdana" Font-Size="13px">
     <table width="100%" class="table-bordered  table table-striped ">
         <tr>
             <td>पंजीकरण संख्या(13 अंको का) </td>
             <td>
                 <asp:TextBox ID="txtreg" runat="server" MaxLength="13" class="form-control"></asp:TextBox> </td>
             <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnsearch" runat="server" Text="Search" class="btn btn-success" OnClick="btnsearch_Click" /></td>
         </tr>
        
     </table>
           <div><asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="17px"></asp:Label></div>
 </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Font-Names="verdana" Font-Size="13px" Visible="false">
        <div class="panel panel-success" >
        <div class="panel-heading" style="font-size:15px; font-weight:bold;">Personal Information</div>
     <table  width="100%" class="table-bordered  table table-striped ">
         <tr>
             <td>Name:</td>
             <td>
                  <b> <asp:Label runat="server" ID="lblname" Text=""></asp:Label></b>
             </td>
                <td>Father/Husband Name:</td>
             <td>
                <b> <asp:Label runat="server" ID="lblfthrname" Text=""></asp:Label></b>
             </td>
         </tr>
         <tr>
             <td>District:</td>
             <td>
                <b> <asp:Label runat="server" ID="lbldist" Text=""></asp:Label></b>
             </td>
                <td>Block:</td>
             <td>
                 <b><asp:Label runat="server" ID="lblblock" Text=""></asp:Label></b>
             </td>
         </tr>
         <tr>
             <td>Panchayat:</td>
             <td>
                <b> <asp:Label runat="server" ID="lblpanchayat" Text=""></asp:Label></b>
             </td>
                <td>Village:</td>
             <td>
                <b> <asp:Label runat="server" ID="lblvillage" Text=""></asp:Label></b>
             </td>
         </tr>
     </table>
            </div>
 </asp:Panel>
     <asp:Panel ID="Panel2" runat="server" Font-Names="verdana" Font-Size="13px" Visible="false">
         <div class="panel panel-success" >
        <div class="panel-heading" style="font-size:15px; font-weight:bold;">Change Information</div>
     <table  width="100%" class="table-bordered  table table-striped ">
         <tr>
             <td>Block:</td>
             <td>
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <ContentTemplate>
                 <asp:DropDownList ID="DropDownList1" CssClass="dropdown" runat="server" Width="180px" AutoPostBack="True" 
                     OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                 </ContentTemplate>
            </asp:UpdatePanel> 
                 
             </td>
                <td>Panchayat:</td>
             <td>
                 <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                <ContentTemplate>
                  <asp:DropDownList ID="DropDownList2" runat="server" Width="180px" CssClass="dropdown" 
                      AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                    </ContentTemplate>
            </asp:UpdatePanel> 
             </td>
          
             <td>Village:</td>
             <td>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                 <asp:DropDownList ID="DropDownList3" runat="server" Width="180px"></asp:DropDownList>
                    </ContentTemplate>
            </asp:UpdatePanel> 
             </td>
                 
         </tr>
         
         <tr>
             <td align="center" colspan="6">
                 <asp:Button ID="btnupdate" runat="server" Text="Submit" OnClick="btnupdate_Click" Font-Bold="True" Font-Names="Verdana" />
             </td>
         </tr>
     </table>
             </div>
 </asp:Panel>
</asp:Content>

