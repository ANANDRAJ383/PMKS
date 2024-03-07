<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="RegistrationStatus.aspx.cs" Inherits="HQ_RegistrationStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><br />
    <div style="font-family: Cambria; font-size: 22px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Check Registration Status
        </div>
   <div class="form-group ">
							<label for="login-email-1" >Search By:</label>
							<asp:DropDownList ID="ddlSearchBy" runat="server" class="form-control" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0" Selected="True" >--Select--</asp:ListItem>
                    <asp:ListItem Value="R">Registration Id</asp:ListItem>
                    <asp:ListItem Value="A">Aadhaar No</asp:ListItem>
                    <asp:ListItem Value="M">Mobile No</asp:ListItem>
                </asp:DropDownList>
						</div>
    <div class="form-group ">
								
								<asp:Label ID="lblUser" runat="server" Text="Enter Registration Id" ></asp:Label>							
								<asp:TextBox ID="txtUserId" runat="server" class="form-control"  AutoCompleteType="Disabled"></asp:TextBox>
							</div>
    <div class="form-group ">
								<asp:Button ID="btnView" class="btn btn-primary b-btn" runat="server" Text="View" OnClick="btnView_Click" ></asp:Button>
							</div>
</asp:Content>

