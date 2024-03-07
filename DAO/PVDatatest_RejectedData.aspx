<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="PVDatatest_RejectedData.aspx.cs" Inherits="DAO_PVData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">शत प्रतिशत भौतीक सत्यापन (अपात्र/Death) से प्राप्त लाभुकों का विवरण (Rejected by Headquarters) </div><br />
    
     <table class="table-bordered  table table-striped " style="width: 100%;" align="center">
        <tr>
            <td colspan="2"><asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label></td>
        </tr>
        <tr>
            <td>1. Date of Death/Ineligible</td>
             <td> <asp:TextBox ID="txtPhyVerifDate" runat="server" Text='<%#Eval("PhyVerifDate") %>'></asp:TextBox>
                         <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtPhyVerifDate" Format="dd mmm yyyy" To-Today="true" /></td>
        </tr>
        <tr>
            <td>2. Back To AC</td>
              <td> <asp:DropDownList ID="ddlStatus" runat="server"  CssClass="form-select">
                                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                <asp:ListItem Value="3">Back To AC</asp:ListItem>
                            </asp:DropDownList></td>
        </tr>
     
          
        <tr>
            <td>3. Remarks</td>
            <td><asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td  >
                        <asp:CheckBox ID="CheckBox2" runat="server" /> &nbsp;&nbsp;
                  </td>
             <td>उपरोक्त जानकारी सही है एवं सत्यापन किया जा सकता है । </td>
        </tr>
        <tr>
            <td><asp:Button ID="bnSave" runat="server" Text="सत्यापित एवं सुरक्षित करें"   class="btn btn-success" OnClick="bnSave_Click"  /> </td>
            <td><asp:Button ID="Button1" runat="server" Text="Back"   class="btn-danger" OnClick="btnBack_Click" Height="40px"  Font-Size="16" /></td>
        </tr>
        
    </table>
  
     
    
</asp:Content>

