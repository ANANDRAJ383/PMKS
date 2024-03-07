<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true" CodeFile="SendSMS.aspx.cs" Inherits="SendSMS" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin: 0px auto; text-align: center;">
        <h2 style="text-align: center; margin-bottom: 20px;">
            Send SMS
        </h2>
        <table class="table-bordered table-responsive table table-striped " style="width: 100%">
     
     <tr>
     <td> Select District</td> <td><asp:DropDownList ID="DDLDistrict" runat="server" 
             AutoPostBack="true" onselectedindexchanged="DDLDistrict_SelectedIndexChanged">
         </asp:DropDownList>
          </td>
          <td> Select Block</td>

          <td>
         <asp:DropDownList ID="DDLBlock" runat="server" >
         </asp:DropDownList> </td>
         <td colspan="3"> Message Type
            <asp:RadioButtonList ID="rbMsgType" runat="server" RepeatDirection="Horizontal" Width="100%" >
                        <asp:ListItem Value="Hindi">Hindi</asp:ListItem>
                        <asp:ListItem Value="English">English</asp:ListItem>
                    </asp:RadioButtonList></td>
     </tr>
     
        <tr>
            <td><asp:RadioButtonList ID="rbType" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem Value="AC">For AC</asp:ListItem>
                        <asp:ListItem Value="DAO">For DAO</asp:ListItem>
                    </asp:RadioButtonList></td>
        <td colspan="2">Enter Test Moblie No </td>
            <td colspan="4">
                <asp:TextBox ID="txtTestNo" runat="server" Width="170px"></asp:TextBox></td>
        </tr>
            <tr>
                
                <td>
                    <asp:CheckBox ID="ChkBlk" runat="server" Text=" Text Message" 
                        oncheckedchanged="ChkBlk_CheckedChanged" AutoPostBack="true" />
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtblkmsg" runat="server" Height="102px" TextMode="MultiLine" style="resize:none" 
                        Width="300px"></asp:TextBox>
                      
                </td>
                
                 <td colspan="2">
                <asp:CheckBox ID="ChkAdss" runat="server" AutoPostBack="true" 
                    oncheckedchanged="ChkAdss_CheckedChanged" Text="Text Message DAO" />
            </td>
            
            </tr>
            
            <tr> <td colspan="3" align="center"> <asp:Label ID="lblmsg" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label></td></tr>
            
         
        </table>
    </div>
</asp:Content>
