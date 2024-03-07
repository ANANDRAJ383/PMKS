<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Done.aspx.cs" Inherits="HQ_Done" %>
 <%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../vendor/bootstrap/css/bootstrap.min.css" />
    <!-- Custom styles for this template -->
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/base-responsive.css" />
    <link rel="stylesheet" href="../css/animate.min.css" />
    <link rel="stylesheet" href="../css/slicknav.min.css" />
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link href="../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="../css/entryform.css" />
    <style type="text/css">
        .auto-style1 {
            width: 579px;
        }
    </style>
</head>
<body style="background-color: #5ed07c;">
    <form id="form1" runat="server">
        <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">शत प्रतिशत भौतीक सत्यापन (अपात्र/Death) से प्राप्त लाभुकों का विवरण </div><br />
    
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
            <td>2. Accept/Reject</td>
              <td> <asp:DropDownList ID="ddlStatus" runat="server"  CssClass="form-select">
                                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Accept</asp:ListItem>
                                <asp:ListItem Value="2">Reject</asp:ListItem>
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
            <td><asp:Button ID="Button1" runat="server" Text="Close"   class="btn-danger" OnClick="btnBack_Click" Height="40px"  Font-Size="16" /></td>
        </tr>
        
    </table>
    </form>
</body>
</html>
