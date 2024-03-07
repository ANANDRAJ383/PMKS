<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApplicationStatusCheck.aspx.cs" Inherits="ApplicationStatusCheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="b-bg-image py-5" style="padding-bottom: 200px!important">
		<div class="container">
			<div class="row">
				<div class="col-lg-6 d-flex b-heading-sec">
					<div class="align-self-center pr-5 b-head-in">
						<h1 class="text-right mt-5 b-left-head">CHECK APPLICATION STATUS</h1>
					</div>
				</div>
				

				<div class="col-lg-6 b-login-sec">
					<div class="d-block px-5 pt-5 pb-4 border-bottom-0">
						<h2 class="b-login-head">Log In</h2>
					</div>

					<asp:Panel ID="pnlLogin" runat="server">
					<div class="form-group ">
							<label for="login-email-1" class="text-white">Search By:</label>
							<asp:DropDownList ID="ddlSearchBy" runat="server" class="form-control" OnSelectedIndexChanged="ddlSearchBy_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0" Selected="True" >--Select--</asp:ListItem>
                    <asp:ListItem Value="R">Registration Id</asp:ListItem>
                    <asp:ListItem Value="A">Aadhaar No</asp:ListItem>
                    <asp:ListItem Value="M">Mobile No</asp:ListItem>
                </asp:DropDownList>
						</div>
							<div class="form-group ">
								<%--<label for="login-email-1" class="text-white">User Id:</label>--%>
								<asp:Label ID="lblUser" runat="server" Text="Enter Registration Id" CssClass="text-white"></asp:Label>
								<%--<input type="text" id="text1" runat="server" class="form-control" placeholder="e-Mail ID" autofocus>--%>
								<asp:TextBox ID="txtUserId" runat="server" class="form-control"  AutoCompleteType="Disabled"></asp:TextBox>
							</div>
							


							<!-- <p class="text-right b-notreg ">Don't have an account? <a href="">Sign Up</a></p> -->
							<div class="text-center py-4">
								<asp:Button ID="btnSubmit" class="btn btn-primary b-btn" runat="server" Text="Log In" OnClick="btnSubmit_Click"></asp:Button>
							</div>
							</asp:Panel>
						<%--</form>--%>
					
					

				<asp:Panel ID="pnlOTP" runat="server" Visible="false">

					<div class="form-group ">
								<label for="login-email-1" class="text-white">Enter OTP:</label>
								<asp:TextBox ID="txtOTP" runat="server" class="form-control" placeholder="Enter OTP " ></asp:TextBox>
							</div>
					<div class="form-group ">
						<asp:Button ID="btnValidate" runat="server" Text="Validate & Login" class="btn btn-primary b-btn" OnClick="btnValidate_Click" />
						</div>
					<div class="form-group ">
						<asp:Label ID="lblMsg" runat="server" ForeColor="White" ></asp:Label>
					 </div>
				</asp:Panel>
					</div>
				</div>
			</div>
		</div>
</asp:Content>

