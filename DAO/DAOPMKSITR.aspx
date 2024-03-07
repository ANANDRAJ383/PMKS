<%@ Page Title="" Language="C#" MasterPageFile="~/DAOMasterPage.master" AutoEventWireup="true" CodeBehind="DAOPMKSITR.aspx.cs" Inherits="AgricultureDept.DAOPMKSITR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <SCRIPT language=Javascript>

         function isNumberKey(evt) {
             var charCode = (evt.which) ? evt.which : evt.keyCode;
             if (charCode != 46 && charCode > 31
               && (charCode < 48 || charCode > 57))
                 return false;

             return true;
         }
    </SCRIPT>

     <style type="text/css"> 
        .smallSize
        {
            font-size: small;
        }
         le
        {
            border-collapse: collapse;
        }

        table, td, th
        {
            border: 1px solid black;
        }

        td
        {
            height: 20px;
        }
         </style>

     <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }
    </style>
      <style type="text/css">
        .modalBackground {
            background-color: Yellow;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup {
            background-color: #ffffdd;
            border-width: 3px;
            border-style: solid;
            border-color: Gray;
            padding: 5px;
            width: 350px;
            height: 300px;
        }

        .modalBackground1 {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
            /*background-color: Black;
        filter: alpha(opacity=60);
        opacity: 0.6;*/
        }

        .modalPopup1 {
            background-color: #FFFFFF;
            width: 100%;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }

            .modalPopup1 .header {
                background-color: #2FBDF1;
                height: 50px;
                color: White;
                line-height: 50px;
                text-align: center;
                font-weight: bold;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

            .modalPopup1 .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup1 .footer {
                padding: 6px;
            }

            .modalPopup1 .yes, .modalPopup .no {
                height: 23px;
                color: White;
                line-height: 50px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                border-radius: 4px;
            }

            .modalPopup1 .yes {
                background-color: #2FBDF1;
                border: 1px solid #0DA9D0;
            }

            .modalPopup1 .no {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

        </style>
    <style type="text/css">
body
{
    margin: 0;
    padding: 0;
    height: 100%;
}
.modal
{
    display: none;
    position: absolute;
    top: 0px;
    left: 0px;
    background-color: black;
    z-index: 100;
    opacity: 0.8;
    filter: alpha(opacity=60);
    -moz-opacity: 0.8;
    min-height: 100%;
}
#divImage
{
    display: none;
    z-index: 1000;
    position: fixed;
    top: 0;
    left: 0;
    background-color: White;
    height: 550px;
    width: 600px;
    padding: 3px;
    border: solid 1px black;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-success" align="center">
     <div class="panel-heading" style="font-size:18px; font-weight:bold;">पी० एम० किसान (अयोग्य आयकर दाता किसान)<br />भुगतान वापस करने हेतु विपत्र </div>
         </div>
      <table width="100%" class="table-bordered" style="font-family: verdana, Geneva, Tahoma, sans-serif">
          <tr>
              <td>Enter Registration(DBT)</td>
              <td>    <asp:textbox runat="server" ID="txtreg" MaxLength="13" class="form-control"></asp:textbox>  </td>
               <td>Enter Registration(PMKS)</td>
              <td>    <asp:textbox runat="server" ID="txtregpmks" MaxLength="20" class="form-control"></asp:textbox>  </td>
          </tr>
          <tr>
              <td colspan="4">
                  <center>
                  <asp:Button ID="btnvalidate" runat="server" Text="Validate" class="btn btn-success" OnClick="btnvalidate_Click"/>
                      </center>
              </td>
          </tr>
      </table>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div class="panel panel-success" align="center">
     <div class="panel-heading" style="font-size:12px; font-weight:bold;">Personal Information </div>
         </div>
      <table width="100%" class="table-bordered" style="font-family: verdana, Geneva, Tahoma, sans-serif">
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
              <td> <asp:Label ID="lblamount" runat="server" Text=""></asp:Label> </td>
          </tr>
      </table>
        <table width="100%" class="table-bordered" style="font-family: verdana, Geneva, Tahoma, sans-serif">
       <tr>
            <td> Amount Return:            </td>
            <td> <asp:TextBox ID="txtamountreturn" runat="server" onkeypress="return isNumberKey(event)" MaxLength="8"></asp:TextBox>
            </td> 
            <td>
                 Transaction Date
            </td>
            <td>
                <asp:TextBox ID="txttransactiondate" runat="server"></asp:TextBox>
                 <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttransactiondate"  Format="yyyy-MM-dd" PopupPosition="BottomRight"     ></asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>
               Return Mode
            </td>
            <td>
                <asp:DropDownList ID="ddtransactionmode" runat="server">
                    <asp:ListItem>Cash</asp:ListItem>
                    <asp:ListItem>Check</asp:ListItem>
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
            <td colspan="4">
                <center><asp:Button ID="btnSubmit" runat="server" Text="Submit"  class="btn btn-success" OnClick="btnSubmit_Click"/></center>
            </td>
        </tr>
        </table>
    </asp:Panel>
</asp:Content>
