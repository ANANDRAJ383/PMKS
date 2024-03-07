<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MutationDateBeforePMK - Copy.aspx.cs" Inherits="CO_PMKNEW" %>
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
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">PM-KISAN आवेदन सत्यापन Mutation Date of Land (दाखिल - खारिज की तिथि 01/02/2019 से पहले (योजना की मार्गदर्शिका के अनुसार)) <asp:Label ID="lblRegId" runat="server" ></asp:Label></div><br />

    <table class="table-bordered  table table-striped " >
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="18pt" ForeColor="#6600FF"></asp:Label>
            </td>
        </tr>
      

        <tr>
            <td>1. Mutation Date of Land (दाखिल - खारिज की तिथि 01/02/2019 के बाद)</td>
              <td> <asp:TextBox ID="txtMutationDate" runat="server" ></asp:TextBox>
               <rjs:PopCalendar ID="PopCalendar1" runat="server" AutoPostBack="True" 
                    Control="txtMutationDate" Format="dd mmm yyyy" To-Date="02-01-2019" /> </td>
        </tr>
       
        
       
        <tr>
            <td>2. जमीन दस्तावेज अद्यतन यानि वर्ष (2018-19-20-21-22) का हैं ?</td>
              <td> <asp:RadioButtonList ID="rb2" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
        
           <tr>
            <td>3. आवेदक किसान का जमीन दस्तावेज एवं जमीन विवरण सही है ?</td>
             <td> <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>4. आवेदन पर अनुमोदन दिया जा सकता है ?</td>
              <td> <asp:RadioButtonList ID="rb3" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td><asp:Button ID="bnSave" runat="server" Text="सत्यापित एवं सुरक्षित करें" class="btn btn-success" OnClick="bnSave_Click"  /> </td>
            <td><asp:Button ID="btnBack" runat="server" Text="Close"   class="btn-danger" OnClick="btnBack_Click" Height="40px"  Font-Size="16" /></td>
            
            
        </tr>
       
        
    </table>

    </form>
</body>
</html>
