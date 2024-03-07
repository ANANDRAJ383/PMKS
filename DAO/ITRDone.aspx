<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ITRDone.aspx.cs" Inherits="DAO_ITRDone" %>
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
    <form id="form1" runat="server" >
        <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">पी० एम० किसान (अयोग्य आयकर (ITR) दाता किसान)<br />भुगतान वापस करने हेतु विपत्र </div><br />
         <table class="table-bordered  table table-striped " style="width: 100%;" id="tblData" runat="server" visible="false">
          <tr>
              <td>
                  Registration No.:
              </td>
              <td >
                  <asp:Label ID="lblregistration" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
          </tr>
          <tr>
              <td>Applicant Name:</td>
              <td >  <asp:Label ID="lblname" runat="server" Text=""></asp:Label></td>
               <td>Father/Husband Name:</td>
              <td> <asp:Label ID="lblfhname" runat="server" Text=""></asp:Label> </td>
          </tr>
          <tr>
              <td>Installment:</td>
              <td class="auto-style1">  <asp:Label ID="lblinstallment" runat="server" Text=""></asp:Label></td>
               <td>Amount</td>
              <td> <asp:Label ID="lblamount" runat="server" Text="" onkeypress="return Validate();"></asp:Label> </td>
          </tr>
      
       <tr>
            <td> Amount Return:            </td>
            <td > <asp:TextBox ID="txtamountreturn" runat="server"  onkeypress="return Validate();" MaxLength="8"></asp:TextBox>
            </td> 
            <td>
                 Transaction Date
            </td>
            <td>
                <asp:TextBox ID="txttransactiondate" runat="server" ReadOnly="true"></asp:TextBox>
                <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txttransactiondate"    To-Today="true" />
            </td>
        </tr>
        <tr>
            <td>
               Return Mode
            </td>
            <td >
                <asp:DropDownList ID="ddtransactionmode" runat="server" CssClass="form-select" Width="100px">
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Check</asp:ListItem>
                    <asp:ListItem>Online</asp:ListItem>
                </asp:DropDownList>

            </td>

        
            <td>
                UTR Number
            </td>
            <td>
                <asp:TextBox ID="txtutrno" runat="server" MaxLength="25"></asp:TextBox>
            </td>

        </tr>
       
            <tr>
                <td>भुगतान वापसी खाता</td>
                <td class="auto-style1">
                     <asp:RadioButtonList ID="ddlPaymentType" runat="server" >
                            <asp:ListItem Value="1">भारत कोष</asp:ListItem>
                        <asp:ListItem Value="2">राज्य कोष खाता संख्या (40903138323, IFSC: SBIN0006379)</asp:ListItem>
                        <asp:ListItem Text="SLBC/BANK द्वारा वसूली" Value="3"></asp:ListItem>
                            <asp:ListItem Value="4">प्रसानिक मद-खाता संख्या (38269533475, IFSC: SBIN0006379)</asp:ListItem>
                    <asp:ListItem Text="अन्य कारणों से अयोग्य घोषित किसान खाता संख्या (40903140467, IFSC: SBIN0006379)" Value="5"></asp:ListItem>
                   
                        </asp:RadioButtonList>
                </td>
            <td style="margin-top:20px" colspan="2">
                
                <center><asp:Button ID="btnSubmit" runat="server" Text="सत्यापित एवं सुरक्षित "  class="btn btn-success" OnClick="btnSubmit_Click"/></center>
            </td>
        </tr>
        </table>
        
        
    </form>
</body>
</html>
