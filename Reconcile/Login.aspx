<%@ Page Title="" Language="C#" MasterPageFile="~/Reconcile/MainSite.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>

		.reloadcaptcha
{
cursor: pointer;
height: 22px;
vertical-align: middle;
}
	</style>
	<script type="text/javascript">

        function generateCaptcha() {
            var randomColor = Math.floor(Math.random() * 16777215).toString(16);
            var alpha = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z');
            var i;
            for (i = 0; i < 4; i++) {
                var a = alpha[Math.floor(Math.random() * alpha.length)];
                var b = alpha[Math.floor(Math.random() * alpha.length)];
                var c = alpha[Math.floor(Math.random() * alpha.length)];
                var d = alpha[Math.floor(Math.random() * alpha.length)];
            }
            var code = a + '' + b + '' + '' + c + '' + d;
            //document.getElementById("mainCaptcha").style.background = '#' + randomColor;
            document.getElementById("mainCaptcha").value = code
        }
        function CheckValidCaptcha() {
            var string1 = removeSpaces(document.getElementById('mainCaptcha').value);
            var string2 = removeSpaces(document.getElementById('txtInput').value);
            if (string1 == string2) {
                //document.getElementById('success').innerHTML = "Form is validated Successfully";
                //alert("Form is validated Successfully");
                return true;
            }
            else {
                // document.getElementById('pLogin').innerHTML = "Please enter a valid captcha.";
                //alert("Please enter a valid captcha.");
                return false;

            }
        }
        function removeSpaces(string) {
            return string.split(' ').join('');
        }

        //alert("Please enter a valid captcha.");




    </script>    
	<script language="javascript" type="text/javascript">

        function validateForData() {
            if (CheckValidCaptcha() == false) {
                alert('Please enter Valid Captcha');
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <div class="container">


        <div class="row justify-content-center">

            <div  class="col-lg-12 col-sm-12 col-md-5 col-xl-5 login-wraper">
                <asp:Panel ID="pnlLogin" runat="server">
                <div class="form-group">
                     
                    <div class="form-group has-feedback">
                         <label for="input1" class="control-label required">User Id</label>
                        <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" style="border-radius: 0px;" placeholder="User Id"></asp:TextBox> 
                    </div>
                    <div class="form-group has-feedback">
                         <label for="input1" class="control-label required">Password</label>                                                                   
                         <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" style="border-radius: 0px;" placeholder="password" type="password"></asp:TextBox> 

                    </div>
                    <div id="ContentPlaceHolder1_UpdatePanel1">
	                            <label >Captcha:</label>
                                <input type="text" id="mainCaptcha" readonly="readonly" 
									style="font-size: 20px; 
								font-family: Comic Sans MS; border-radius: 10px; border-width: 1px; text-align: center; 
								padding: 2px; font-weight: bold; letter-spacing: 2px; color: Black; text-shadow: 1px 2px #eee; 
								" onload="generateCaptcha();"/>
							 <img src="images/refresh.png" id="refresh" 
								 style="text-align:center; padding:5px" alt="refresh captcha" width="50px" height="35px" 
								 value="Refresh" 
								 onclick="generateCaptcha();"/>

                        
</div>
                    <div class="form-group">
								<asp:TextBox ID="txtCaptcha" runat="server" class="form-control" placeholder="Enter above given code"
									AutoCompleteType="Disabled"></asp:TextBox>
								
							</div>

                    <div class="form-group">
                         <asp:Button ID="btnSubmit" runat="server" Text="Submit"  CssClass="custombtn" 
                             OnClick="btnSubmit_Click" OnClientClick="javascript:return validateForData();"/>
                    </div>

                </div>
                </asp:Panel>
                <asp:Panel ID="pnlOTP" runat="server" Visible="false">

					<div class="form-group ">
								<label >Enter OTP:</label>
								<asp:TextBox ID="txtOTP" runat="server" class="form-control" placeholder="Enter OTP " ></asp:TextBox>
							</div>
					<div class="form-group ">
						<asp:Button ID="btnValidate" runat="server" Text="Validate & Login" CssClass="custombtn" OnClick="btnValidate_Click"/>
						</div>
					<div class="form-group ">
						<asp:Label ID="lblMsg" runat="server" ></asp:Label>
					 </div>
				</asp:Panel>
            </div>

            
            
        </div>

         


        
    </div>
   <script>
       generateCaptcha();
   </script>
</asp:Content>

