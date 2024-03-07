<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="LoginForm.aspx.cs" Inherits="LoginForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <!-- Background -->
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

	<div class="b-bg-image py-5" style="padding-bottom: 200px!important">
		<div class="container">
			<div class="row">
				<div class="col-lg-6 d-flex b-heading-sec">
					<div class="align-self-center pr-5 b-head-in">
						<h1 class="text-right mt-5 b-left-head">DBT | PM-KISAN SCHEME (Official Login )</h1>
					</div>
				</div>
				

				<div class="col-lg-6 b-login-sec">
					<div class="d-block px-5 pt-5 pb-4 border-bottom-0">
						<h2 class="b-login-head">Log In</h2>
					</div>

					<asp:Panel ID="pnlLogin" runat="server">
					<div class="form-group ">
							<label for="login-email-1" class="text-white">User Role:</label>
							<asp:DropDownList ID="ddlRole" runat="server" class="form-control">
								<asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                <asp:ListItem Value="AC" >AC</asp:ListItem>
                                <asp:ListItem Value="DSB" >BAO</asp:ListItem>
								<asp:ListItem Value="CO" >CO</asp:ListItem>
								<asp:ListItem Value="DAO" >DAO</asp:ListItem>
                                <asp:ListItem Value="ADM(Revenue)" >ADM(Revenue)</asp:ListItem>
  <asp:ListItem Value="ADM" >ADM(Disaster)</asp:ListItem>
                                <asp:ListItem Value="DBT-Nodal" >DBT-Nodal</asp:ListItem>
								<asp:ListItem Value="HQ" >Admin</asp:ListItem>
<asp:ListItem Value="DBTAdmin" >AdminDBT</asp:ListItem>
                                <asp:ListItem Value="CSC" >CSC</asp:ListItem>
                                <asp:ListItem Value="NPCI" >NPCI</asp:ListItem>
<asp:ListItem Value="DBT" >DBT</asp:ListItem>
							</asp:DropDownList>
							<div class="form-group ">
								<label for="login-email-1" class="text-white">User Id:</label>
								<%--<input type="text" id="text1" runat="server" class="form-control" placeholder="e-Mail ID" autofocus>--%>
								<asp:TextBox ID="txtUserId" runat="server" class="form-control" placeholder="User Id" AutoCompleteType="Disabled"></asp:TextBox>
							</div>
							<div class="form-group">
								<label for="login-pwd-1" class="text-white">Password:</label>
								<%--<input type="password" id="text2" runat="server" class="form-control" placeholder="Password">--%>
								<asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password" TextMode="Password" ></asp:TextBox>
							</div>
                        <asp:UpdatePanel ID="uppl" runat="server" UpdateMode="Always">
                            <ContentTemplate>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group">
							 <label for="login-pwd-1" class="text-white" style="margin-right: 20px;">Captcha:</label>
                                <input type="text" id="mainCaptcha" readonly="readonly" 
									style="font-size: 20px; 
								font-family: Comic Sans MS; border-radius: 10px; border-width: 1px; text-align: center; 
								padding: 2px; font-weight: bold; letter-spacing: 2px; color: Black; text-shadow: 1px 2px #eee; 
								" onload="generateCaptcha();"/>
							 <img src="images/refresh.png" id="refresh" 
								 style="text-align:center; padding:5px" alt="refresh captcha" width="50px" height="35px" 
								 value="Refresh" 
								 onclick="generateCaptcha();"/>
							<%--<img id="Captcha"  alt="Captcha" style="vertical-align: middle;" />&ensp;<img
                                onclick="rcaptcha();" id="reloadcaptcha" class="reloadcaptcha" src="images/refresh.png" 
                                alt="Refresh Captcha" />--%>
							 </div>
                            <div class="form-group">
								<%--<asp:TextBox ID="txtCaptcha" runat="server" class="form-control" placeholder="Enter above given code"
									AutoCompleteType="Disabled"></asp:TextBox>--%>
								  <input class="input100" type="text" id="txtInput"/>   
                                <%--<span class="label-input100">Captcha</span>--%>
							</div>
							<div class="form-group custom-control custom-checkbox">
								<input class="custom-control-input" id="login-rem-1" type="checkbox" name="remember"> 
								<label class="custom-control-label text-white" for="login-rem-1">Remember me</label>
							</div>


							<!-- <p class="text-right b-notreg ">Don't have an account? <a href="">Sign Up</a></p> -->
							<div class="text-center py-4">
								<asp:Button ID="btnSubmit" class="btn btn-primary b-btn" runat="server" Text="Log In" OnClick="btnSubmit_Click" OnClientClick="javascript:return validateForData();"></asp:Button>
							</div>
							</asp:Panel>
						<%--</form>--%>
					
					

				<asp:Panel ID="pnlOTP" runat="server" Visible="false">

					<div class="form-group ">
								<label for="login-email-1" class="text-white">Enter OTP:</label>
								<asp:TextBox ID="txtOTP" runat="server" class="form-control" placeholder="Enter OTP " ></asp:TextBox>
							</div>
					<div class="form-group ">
						<asp:Button ID="btnValidate" runat="server" Text="Validate & Login" class="btn btn-primary b-btn" OnClick="btnValidate_Click"/>
						</div>
					<div class="form-group ">
						<asp:Label ID="lblMsg" runat="server" ForeColor="White" ></asp:Label>
					 </div>
				</asp:Panel>
					</div>
				</div>
			</div>
		</div>
	<script>
        generateCaptcha();
    </script>


	<script>           function rcaptcha() { document.getElementById('Captcha').src = "captcha.ashx?id=" + Math.random(); } rcaptcha();</script>
<script language="javascript" type="text/javascript" src="JsPMKS/md5.js"></script>
<script>
    function check_pwd() {

        document.getElementById('ErrorDivHtml').style.display = 'none';
        document.getElementById('ErrorDivBad').innerHTML = '';
        var p1 = document.getElementById('txtPassword').value;
        if (p1 == '') {
            document.getElementById('ErrorDivHtml').style.display = '';
            document.getElementById('ErrorDivBad').innerHTML = 'Please Enter Password.';
            document.getElementById('txtPassword').focus();
            return false;
        }

        if (document.getElementById('txtCaptcha').value == "") {
            document.getElementById('ErrorDivHtml').style.display = '';
            document.getElementById('ErrorDivBad').innerHTML = 'Please Enter Captcha.';
            document.getElementById('txtCaptcha').focus();
            return false;
        }
        if (fn_cL_Pass(p1) == 1) {
            document.getElementById('txtPassword').value = '';
            document.getElementById('ErrorDivHtml').style.display = '';
            document.getElementById('ErrorDivBad').innerHTML = 'Special Characters Not Allowed. For list Contact Admin.';
            document.getElementById('txtPassword').focus();
            return false;
        }
        document.getElementById('txtPassword').value = hex_md5(document.getElementById('hf').value + hex_md5(p1));
        document.getElementById('hf').value = '';
        p1 = '';
    }
    function fn_cL_Pass(evt) { evt = (evt) ? evt : event; var chkString = new Array("!", "^", "*", "_", "-", "+", "=", "*", "-", "+", "<", ">", "?", "'", ";", ":", "~", "`", "|", "\\", "{", "}", "[", "]", "(", ")", ",", ".", "/"); var i, j = chkString.length; for (i = 0; i < j; i++) { if (String.fromCharCode(evt.charCode) == chkString[i]) { return false; } } }
</script>


</asp:Content>

