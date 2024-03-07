<%@ Page Title="" Language="C#" MasterPageFile="MasterPagePublic.master" AutoEventWireup="true" CodeFile="PMKisanReReconsiderStatus.aspx.cs" Inherits="ReReconsiderStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="panel-heading" style="font-family: Verdana; font-weight: bold; font-size: 18px; color: green;" align="center">Check Application Status for PM-KISAN(Re Reconsider)</div>
   
    <asp:Panel ID="Panel1" runat="server" GroupingText="" Font-Names="Verdana" Font-Size="12px">
       
          
       <table width="100%">
            <tr>
                <td align="right" >Enter Application Number:</td>
                <td align="left"><asp:TextBox ID="TextBox1" runat="server" MaxLength="13"  ></asp:TextBox> &nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="Search" Font-Bold="True" Font-Size="12px" Font-Names="Lucida Handwriting" Width="80px" OnClick="Button1_Click" /></td>
            </tr>
           
        </table>
              
    </asp:Panel>
    
    <asp:Panel ID="pnlrecords" GroupingText="" Visible="false" runat="server" Font-Names="Verdana" Font-Size="12px">
          <div class="panel panel-success">
            <div class="panel-heading" style="font-size:14px; font-family:Verdana; font-weight:bold;" >Searched Records</div>
            <div class="panel-body" style="font-size: 12px;">   
        <table width="100%">
            <tr>
                <td>Application ID:</td>
            
                  <td>
                      <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                </td>
                <td>Applicant Name:</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#0033CC"></asp:Label>
                </td>
            </tr>
           
            
            <tr>
                <td colspan="4">
                    <asp:Label ID="lbl" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="#006600"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
           
            
        </table>
                </div> </div> 
    </asp:Panel>
</asp:Content>

