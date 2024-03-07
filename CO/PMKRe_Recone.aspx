<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMKRe_Recone.aspx.cs" Inherits="CO_PMKNEW" %>
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
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">PM-KISAN आवेदन सत्यापन Mutation Date of Land (दाखिल - खारिज की तिथि 01/02/2019 के बाद (योजना की मार्गदर्शिका के अनुसार)) <asp:Label ID="lblRegId" runat="server" ></asp:Label></div><br />

    <table class="table-bordered  table table-striped " >
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="18pt" ForeColor="#6600FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>1. Select Land Transfer Detail</td>
             <td> 
                 <asp:DropDownList ID="ddlLandTransferDetail" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlLandTransferDetail_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0" Text="--Select--"></asp:ListItem>
                <asp:ListItem  Value="1" Text="Death of Husband"></asp:ListItem>
                <asp:ListItem  Value="2" Text="Death of Father"></asp:ListItem>
                     <asp:ListItem  Value="3" Text="Virasat"></asp:ListItem>
                     <asp:ListItem  Value="4" Text="Purchase of Land"></asp:ListItem>
                     <asp:ListItem  Value="5" Text="Gifted"></asp:ListItem>
            </asp:DropDownList>
             </td>
        </tr>
        <tr>
            <td>2. Mutation Date of Land (दाखिल - खारिज की तिथि 01/02/2019 के बाद)</td>
              <td> <asp:TextBox ID="txtMutationDate" runat="server" ></asp:TextBox>
               <rjs:PopCalendar ID="PopCalendar1" runat="server" AutoPostBack="True" 
                    Control="txtMutationDate" Format="dd mmm yyyy" To-Today="true"/> </td>
        </tr>
        <tr>
            <td>3. Identity of previous Owner <asp:DropDownList ID="ddlIdertity" runat="server" CssClass="form-select">
                <asp:ListItem  Value="1" Text="Aadhaar" Selected="True"></asp:ListItem>
                <asp:ListItem  Value="0" Text="PAN | EPIC No"></asp:ListItem>
            </asp:DropDownList></td>
              <td> <asp:TextBox ID="txiIdentityNo" runat="server" MaxLength="17" ></asp:TextBox></td>
        </tr>
        
       
        <tr>
            <td>4. जमीन दस्तावेज अद्यतन यानि वर्ष (2018-19-20-21-22) का हैं ?</td>
              <td> <asp:RadioButtonList ID="rb2" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
        
           <tr>
            <td>5. आवेदक किसान का जमीन दस्तावेज एवं जमीन विवरण सही है ?</td>
             <td> <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>6. आवेदन पर अनुमोदन दिया जा सकता है ?</td>
              <td> <asp:RadioButtonList ID="rb3" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>अनुमोदन नहीं देने का कारण</td>
            <td><asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>    </td>
        </tr>
        <tr>
            <td><asp:Button ID="bnSave" runat="server" Text="सत्यापित एवं सुरक्षित करें" class="btn btn-success" OnClick="bnSave_Click"  /> </td>
            <td><asp:Button ID="btnBack" runat="server" Text="Close"   class="btn-danger" OnClick="btnBack_Click" Height="40px"  Font-Size="16" /></td>
            
            
        </tr>
       
        
    </table>

    </form>
</body>
</html>
