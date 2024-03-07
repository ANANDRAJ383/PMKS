<%@ Page Title="" Language="C#" MasterPageFile="ADMRMasterPage.master" AutoEventWireup="true" CodeFile="VerifyFarmerNew.aspx.cs" Inherits="CO_VerifyFarmerNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <br />
<div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">PM-KISAN आवेदन सत्यापन <asp:Label ID="lblRegId" runat="server" ></asp:Label></div><br />

    <table class="table-bordered  table table-striped " style="width: 100%;" align="center">
        <tr>
            <td colspan="2">सत्यापन बिंदु</td>
        </tr>
        <tr>
            <td>1. आवेदक किसान का जमीन दस्तावेज एवं जमीन विवरण सही है ?</td>
             <td> <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem >Yes</asp:ListItem>
                        <asp:ListItem >No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>2. जमीन दस्तावेज अद्यतन यानि वर्ष (2018-19-20-21-22) का पुनः मिलान कर लिया गया हैं ?</td>
              <td> <asp:RadioButtonList ID="rb2" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem >Yes</asp:ListItem>
                        <asp:ListItem >No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>3. आवेदन पर अनुमोदन दिया जा सकता है ?</td>
              <td> <asp:RadioButtonList ID="rb3" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem >Yes</asp:ListItem>
                        <asp:ListItem >No</asp:ListItem>
                    </asp:RadioButtonList></td>
            
        </tr>
        <tr>
            <td>4. आवेदन पर अनुमोदन दिया जा सकता है ?</td>
              <td> <asp:RadioButtonList ID="rb4" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem >Yes</asp:ListItem>
                        <asp:ListItem >No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td  >
                        <asp:CheckBox ID="CheckBox2" runat="server" Enabled="false"/> &nbsp;&nbsp;
                  </td>
             <td>उपरोक्त जानकारी सही है एवं सत्यापन किया जा सकता है । </td>
        </tr>
        <tr>
            <td><asp:Button ID="bnSave" runat="server" Text="सत्यापित एवं सुरक्षित करें" class="btn btn-success" OnClick="bnSave_Click"  /> </td>
            <td><asp:Button ID="btnBack" runat="server" Text="Back"   class="btn-danger" OnClick="btnBack_Click" Height="40px"  Font-Size="16" /></td>
            
            
        </tr>
        
    </table>
</asp:Content>

