<%@ Page Title="" Language="C#" MasterPageFile="COMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="reports_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style type="text/css">
        .style1
        {
            height: 73px;
        }
        .style4
        {
            height: 38px;
        }
        .style5
        {
            height: 48px;
        }
        .reloadcaptcha {cursor:pointer;height:22px;vertical-align:middle;}
    </style>
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
     <div runat="server" ID="ErrorDiv" visible="false" class="check"></div><br /><bt></bt>
    <div>
    <table runat="server" id="errorTable" class="msg-table"><tr><td style="padding:0px;" class='disp-error red-left'><asp:Literal runat="server" ID="displayEr" /></td><td style="padding:0px;" class='red-right'><a class='close-red'><img onclick="$('.msg-table').hide('slow');" src='../images/icon_close_red.gif' alt=''/></a></td></tr></table>
          
    <div>
        <table class="table-bordered  table table-striped " style="width: 100%;" id="page">
            <tr>
                <td colspan="4" >Change Your Password</td>
            </tr>

            <tr>
                <td align="right">Current Password</td>
                <td align="left" class="style4">&nbsp;<asp:TextBox ID="txt_curr_pwd" runat="server" Width="131px" CssClass="inp-form" TabIndex="1"
                    TextMode="Password" AutoCompleteType="Disabled" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_curr_pwd"
                        ValidationGroup="pwd" ErrorMessage="Enter Current Password"
                        SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
           
                <td align="right" class="style4">New Password</td>
                <td align="left" class="style4">&nbsp;<asp:TextBox ID="txt_pwd" runat="server" Width="131px" CssClass="inp-form"
                    TextMode="Password" AutoCompleteType="Disabled" TabIndex="2" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_pwd"
                        ValidationGroup="pwd" ErrorMessage="Enter Password" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
             </tr>
            <tr>
                <td align="right" class="style4">Confirm New Password</td>
                <td align="left" class="style4">&nbsp;<asp:TextBox ID="txt_re_pwd" runat="server" Width="131px" CssClass="inp-form"
                    TextMode="Password" AutoCompleteType="Disabled" TabIndex="3" onkeydown="javascript:return (event.keyCode!=13);"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_re_pwd"
                        ValidationGroup="pwd" ErrorMessage="Enter Confirm Password"
                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
                    <asp:HiddenField ID="hndpwd" runat="server" />
                </td>
            
                <td align="right" >Mobile Number</td>
                <td align="left" >&nbsp;<asp:TextBox ID="txtMobileNo" runat="server" Width="131px" CssClass="inp-form" MaxLength="10" onkeypress="return onlyNumbers();"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo"
                    ValidationGroup="pwd" ErrorMessage="Enter Mobile Number" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
          </tr>
            <tr>
                <td align="right" >Operator Name</td>
                <td align="left" >&nbsp;<asp:TextBox ID="txtOperatorName" runat="server" Width="131px" CssClass="inp-form"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMobileNo"
                    ValidationGroup="pwd" ErrorMessage="Enter Operator Name" SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
            
                
               
           
                <td align="right">
                    <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClientClick="return check();" Width="30%" OnClick="btn_submit_Click" CssClass="btn btn-success"/>&nbsp;
              
                </td>
                <td>  <asp:Button ID="btn_clear" runat="server" Text="Clear" Width="30%" OnClientClick="cleaar()" class="btn-danger" /></td>
            </tr>

        </table>
    
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            ValidationGroup="pwd" />
    
    <asp:Label ID="lbl_msg" runat="server" Font-Bold="True" Font-Names="Verdana" 
                    Font-Size="10pt" ForeColor="Red"></asp:Label>
    <br />
    <p style =" font-family :Verdana; font-size :10pt; text-align :left; width :80% " >
        <span style =" text-decoration: underline";>NOTE</span>: Passwords Length can be between 8- 12 characters.<br />
    Include atleast 1 Number, 1 Capital Letter, 1 Special Character from @ # $ & <br />
    New Password Should Not Be from your Earlier 3 Passwords!</p>
</div></div>
</asp:Content>