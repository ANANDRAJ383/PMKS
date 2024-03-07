<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="IlligableReturn.aspx.cs" Inherits="DAO_ITR_Return" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script language="JavaScript" type="text/javascript">
          function onlyNumbers(evt) {
              var e = event || evt;
              var charCode = e.which || e.keyCode;
              if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                  alert('Enter Numbers Only');
                  return false;
              }
              return true;
          } 
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">पी० एम० किसान (अयोग्य दाता किसान)<br />भुगतान वापस करने हेतु विपत्र </div><br />
   
   
     
      <table class="table-bordered  table table-striped " style="width: 100%;">
          <tr>
              <td>Enter Registration Id(DBT)</td>
              <td>    <asp:textbox runat="server" ID="txtreg" MaxLength="13" class="form-control" onkeypress="return Validate();"></asp:textbox>  </td>
               <td>Enter Registration Id(PMKS)</td>
              <td>    <asp:textbox runat="server" ID="txtregpmks" MaxLength="20" class="form-control"></asp:textbox>  </td>
               <td >
                  <center>
                  <asp:Button ID="btnvalidate" runat="server" Text="View" class="btn btn-success" OnClick="btnvalidate_Click"/>
                      </center>
              </td>
          </tr>
          </table>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div class="panel panel-success" align="center">
     <div class="panel-heading" style="font-size:12px; font-weight:bold;">Personal Information </div>
         </div>
      <table class="table-bordered  table table-striped " style="width: 100%;">
          <tr>
              <td>
                  Registration No.:
              </td>
              <td colspan="3">
                  <asp:Label ID="lblregistration" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
          </tr>
          <tr>
              <td>Applicant Name:</td>
              <td>  <asp:Label ID="lblname" runat="server" Text=""></asp:Label></td>
               <td>Father/Husband Name:</td>
              <td> <asp:Label ID="lblfhname" runat="server" Text=""></asp:Label> </td>
          </tr>
          <tr>
              <td>Installment:</td>
              <td>  <asp:Label ID="lblinstallment" runat="server" Text=""></asp:Label></td>
               <td>Amount</td>
              <td> <asp:Label ID="lblamount" runat="server" Text="" onkeypress="return Validate();"></asp:Label> </td>
          </tr>
      
       <tr>
            <td> Amount Return:            </td>
            <td> <asp:TextBox ID="txtamountreturn" runat="server"  onkeypress="return Validate();" MaxLength="8"></asp:TextBox>
            </td> 
            <td>
                 Transaction Date
            </td>
            <td>
                <asp:TextBox ID="txttransactiondate" runat="server" ReadOnly="true"></asp:TextBox>
                <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txttransactiondate"   To-Today="true" />
            </td>
        </tr>
        <tr>
            <td>
               Return Mode
            </td>
            <td>
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
            <td>
                Upload Receipt
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td colspan="2">** Upload file PDF/pdf only</td>
        </tr>
            <tr>
                <td>भुगतान वापसी खाता</td>
                <td>
                     <asp:RadioButtonList ID="ddlPaymentType" runat="server" >
                            <asp:ListItem Value="1">भारत कोष</asp:ListItem>
                        <asp:ListItem Value="2">राज्य कोष खाता संख्या (40903138323, IFSC: SBIN0006379)</asp:ListItem>
                        <asp:ListItem Text="SLBC/BANK द्वारा वसूली" Value="3"></asp:ListItem>
                            <asp:ListItem Value="4">प्रसानिक मद-खाता संख्या (38269533475, IFSC: SBIN0006379)</asp:ListItem>
                    <asp:ListItem Text="अन्य कारणों से अयोग्य घोषित किसान खाता संख्या (40903140467, IFSC: SBIN0006379)" Value="5"></asp:ListItem>
                   
                        </asp:RadioButtonList>
                </td>
            <td>
                <center><asp:Button ID="btnSubmit" runat="server" Text="Submit"  class="btn btn-success" OnClick="btnSubmit_Click"/></center>
            </td>
        </tr>
        </table>
    </asp:Panel>
</asp:Content>

