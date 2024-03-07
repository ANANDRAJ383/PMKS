<%@ Page Title="" Language="C#" MasterPageFile="~/Reconcile/MainSite.master" AutoEventWireup="true" CodeFile="RefundDetailForm.aspx.cs" Inherits="RefundDetailForm" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="commonboxwithshadow cscbox">
	<h1 class="headingtext">रिफंड विवरण भरें</h1>
	<div class="buttonarea">
		<a href="RefundCategory.aspx" class="custombtn">Back</a>
	</div>
		<div id="divSrch" runat="server">
	<div id="ContentPlaceHolder1_divradiobutton">
		<div class="row justify-content-center">
			<div class="col-12 col-sm-9 col-md-9">
				<div class="alignitemscenter">
					<div class="alignitemscenterinner">
						<div class="globalradio">
							
							<label>Search By :</label>
							<table id="ContentPlaceHolder1_rdbAction">
	<tr>
		<td>
            <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem Selected="True" Value="M">पंजीकृत मोबाइल नंबर</asp:ListItem>
                        <asp:ListItem Value="R">पंजीकरण संख्या</asp:ListItem>
						<asp:ListItem Value="B">पीएम किसान पंजीकरण संख्या (उदाहरण- BR111111111)</asp:ListItem>
                    </asp:RadioButtonList>
               
        </td>
	</tr>
</table>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="row">
			<div class="col-12 col-sm-3 col-md-3">
				<div class="form-group">
					<label class="control-label mb-2" >Enter Value : </label>
                    <asp:TextBox ID="txtMobRegNo" runat="server" CssClass="form-control" ></asp:TextBox>
				</div>
                <div><asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="17px"></asp:Label></div>
			</div>
			<div class="col-12 col-sm-9 col-md-9">
				<div class="row">				
				
					<div class="col-12 col-sm-4 col-md-4" id="divotp" runat="server" visible="false">
						<label>Enter OTP :</label>
						<span id="ContentPlaceHolder1_Label4" class="control-label"></span>						
                         <asp:TextBox ID="txtotp" runat="server" CssClass="form-control"  Placeholder="Enter OTP" autocomplete="off" ></asp:TextBox>
					</div>
					<div class="col-12 col-sm-3 col-md-3">
						<label>&nbsp;</label>			
                        <asp:Button ID="btnGetData" runat="server" Text="Get OTP"  CssClass="custombtn" OnClick="btnGetData_Click"/>
					</div>
                    <div class="col-12 col-sm-4 col-md-4" id="divRwotp" runat="server" visible="false">
                        <asp:Button ID="btnResendOTP" runat="server" Text="Re Send OTP" CssClass="btn btn-success" OnClick="btnGetData_Click" Visible="false" />
                    </div>
				</div>
			</div>
		</div>
	</div>
	</div>

	<div id="divData" runat="server" visible="false" >       
			<div class="table-responsive-sm">
                <table id="ContentPlaceHolder1_Table3" class="table customtable farmerapplication">
                    <tbody>
                        <tr id="ContentPlaceHolder1_tr1">
                            <th colspan="2">
                                <span id="ContentPlaceHolder1_Label1">अयोग्य / अनिच्छुक किसान </span>
                            </th>
                        </tr>
                        <tr id="ContentPlaceHolder1_trFarmerName">
                            <td colspan="2">
                                <span id="ContentPlaceHolder1_lblFarmerName"></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label id="Label2">किसान का नाम : </label>
                                <asp:Label ID="lblName" runat="server" class="aspNetDisabled" Text="AJIT KUMAR YADAV"></asp:Label>

                            </td>
                            <td>
                                <label id="lblRegDate">पंजीकरण संख्या: </label>
                                <asp:Label ID="lblRegistrationId" runat="server" class="aspNetDisabled" Text="BR214729763" ForeColor="Red"
                                    Font-Bold="True" Font-Size="12pt"></asp:Label>
                            </td>
                        </tr>
                        <tr id="ContentPlaceHolder1_trState">
                            <td>
                                <label id="lblState">पिता/पति का नाम : </label>
                                <asp:Label ID="lblFName" class="aspNetDisabled" runat="server" Text="BIHAR" ></asp:Label>
                                
                            </td>
                            <td>
                                <label id="lblDistric">ज़िला : </label>
                                <asp:Label ID="lblDist" runat="server" class="aspNetDisabled" Text="BANKA"></asp:Label>
                            </td>
                        </tr>
                        <tr id="ContentPlaceHolder1_trblock">
                            <td>
                                <label id="lblBlockN">प्रखंड : </label>
                                 <asp:Label ID="lblBlock"  runat="server" Text="BARAHAT" class="aspNetDisabled"></asp:Label>
                            </td>
                            <td>
                                <label id="lblPan">पंचायत : </label>
                                <asp:Label ID="lblPanchayat"  runat="server" Text="Tappadih" class="aspNetDisabled"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label id="lblVill">गाँव : </label>
                                <asp:Label ID="lblVillage"  runat="server" Text="InActive" class="aspNetDisabled"></asp:Label>
                            </td>
                            <td>
                                <div id="ContentPlaceHolder1_divActiveStatus" >
                                    <label id="lblReason" class="control-label required">अयोग्य के कारण : </label>
                                     <asp:Label ID="lblR"  runat="server" Text="Beneficiary is Inactive due to Income tax payee." class="aspNetDisabled"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr id="ContentPlaceHolder1_tr3">
                            <td>
                                <label id="lblPFSStatus">कुल प्राप्त किस्तें : </label>
                                <asp:Label ID="lblTotalGetPay"  runat="server" Text="5" class="aspNetDisabled" Font-Size="12pt"></asp:Label>
                            </td>
                            <td>
                                <label id="lblAadharStatus">कुल प्राप्त राशि : </label>
                                 <asp:Label ID="lblTotalAmount"  runat="server" Text="10000" class="aspNetDisabled" Font-Size="12pt"></asp:Label>
                            </td>
                        </tr>
                        <tr id="ContentPlaceHolder1_tr5" runat="server" visible="false">
                            <td>
                                <label >कुल बकाया किस्तें : </label>
                                <asp:Label ID="lblTotalGetPending"  runat="server" Text="0" class="aspNetDisabled" Font-Size="12pt"></asp:Label>
                            </td>
                            <td>
                                <label >कुल बकाया राशि : </label>
                                 <asp:Label ID="lblTotalPendingAmount"  runat="server" Text="0" class="aspNetDisabled" Font-Size="12pt"></asp:Label>
                            </td>
                        </tr>
                        <tr id="ContentPlaceHolder_treturn">
                            <td>
                                <label>मोबाइल नंबर : </label>
                                <asp:Label ID="lblMobileNo"  runat="server"  class="aspNetDisabled" ForeColor="Red" Font-Bold="True" Font-Size="12pt"></asp:Label>
                            </td>
                            <td>
                                <label id="">पीएम किसान पंजीकरण संख्या : </label>
                                  <asp:Label ID="lblPMKNo"  runat="server" class="aspNetDisabled" ForeColor="Red" Font-Bold="True" Font-Size="12pt"></asp:Label>
                            </td>
                        </tr>
                    </tbody>

                </table>

			</div>
	
    
	
        <div class="row" >
			<div class="col-12 col-sm-3 col-md-3">
				<div class="form-group">
					<label class="control-label mb-2" >वापसी का खाता <span class="mandatory">*</span></label>         

                     <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-select" >
                            <asp:ListItem Value="">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">भारत कोष</asp:ListItem>
                        <asp:ListItem Value="2">राज्य कोष खाता संख्या (40903138323, IFSC: SBIN0006379)</asp:ListItem>                       
                            <asp:ListItem Value="3">प्रसानिक मद-खाता संख्या (38269533475, IFSC: SBIN0006379)</asp:ListItem>
                    <asp:ListItem Text="अन्य कारणों से अयोग्य घोषित किसान खाता संख्या (40903140467, IFSC: SBIN0006379)" Value="4"></asp:ListItem>                   
                        </asp:DropDownList>
				</div>         
			</div>
							
			<div class="col-12 col-sm-3 col-md-3" >
						<div class="form-group">
					<label class="control-label mb-2" >वापसी का तरीका <span class="mandatory">*</span>  </label>               
                     <asp:DropDownList ID="ddlPayType" runat="server" CssClass="form-select" >
                            <asp:ListItem Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">अनलाइन</asp:ListItem>
                        <asp:ListItem Value="2">चेक</asp:ListItem>                       
                    <asp:ListItem Text="कैश" Value="3"></asp:ListItem> 
                          <asp:ListItem Text="यू पी आई(UPI)" Value="4"></asp:ListItem>
                        </asp:DropDownList>
				</div>
					</div>


            <div class="col-12 col-sm-3 col-md-3">
                <div class="form-group">
                    <label class="control-label mb-2">वापसी का किस्त <span class="mandatory">*</span> </label>
                    <asp:DropDownList ID="ddlInstallments" runat="server" CssClass="form-select" 
                        OnSelectedIndexChanged="ddlInstallments_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
					</div>

            <div class="col-12 col-sm-3 col-md-3">
				<div class="form-group">
					<label class="control-label mb-2" >वापसी राशि  <span class="mandatory">*</span></label>
                    <asp:TextBox ID="txtReturnAmount" runat="server" CssClass="Disabled form-control" value="0"  ReadOnly="true" ></asp:TextBox>
				</div>
                
			</div>

			<div class="col-12 col-sm-3 col-md-3">
				<div class="form-group">
					<label class="control-label mb-2" >ट्रांजेक्शन नंबर/यूपीआई नंबर/यूटीआर नंबर  <span class="mandatory">*</span></label>
                    <asp:TextBox ID="txtUTRNo" runat="server" CssClass="form-control" placeholder="ट्रांजेक्शन नंबर/यूपीआई नंबर/यूटीआर नंबर दर्ज करें !" ></asp:TextBox>      
                   
				</div>                 
			</div>
            <div class="col-12 col-sm-3 col-md-3">
				<div class="form-group">
                    <label class="control-label mb-2" >ट्रांजेक्शन दिनांक <span class="mandatory">*</span></label>     
                     <asp:TextBox ID="txtUTRDate" runat="server" CssClass="form-control"  ></asp:TextBox>                     
                    <rjs:PopCalendar ID="PopCalendar1" runat="server" 
                    Control="txtUTRDate" Format="dd mmm yyyy" To-Date="08-21-2023" />
				</div>     
                 
			</div>

             <div class="col-12 col-sm-3 col-md-3">
				<div class="form-group">
					<label class="control-label mb-2" >ट्रांजेक्शन रसीद अपलोड करें <span class="mandatory">*</span> </label>
                    <asp:FileUpload ID="fuDOC" runat="server" CssClass="form-control"/>
				</div>
			</div>

            <div class="col-12 col-sm-3 col-md-3 ">
                <label class="form-check-label" >
               क्या आपका बैंक खाता लिन मार्क है ? 
          </label>
				<div class="globalradio">          
                    <asp:RadioButtonList ID="rbtnLeanMark" runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem  Value="Y">हाँ </asp:ListItem>
                        <asp:ListItem Selected="True" Value="N">नहीं </asp:ListItem>
                    </asp:RadioButtonList>
  
</div>
			</div>

            </div>


        <div class="row">
            <div class="card w-75 mb-3">
  <div class="card-body">
    <h5 class="card-title">दिशा-निर्देश</h5>
      <ol class="list-group list-group-numbered">
  <li class="list-group-item">किसान आवेदन में अपना नाम रसीद पर पंजीकरण संख्या , रसीद पर किसान का हस्ताक्षर/अंगूठा का निशान के बिना रसीद मान्य नहीं होगा।</li>

  <li class="list-group-item">मै प्रमाणित करता/करती हूँ कि मेरे द्वारा दिया गया उपर्युक्त विवरण सही है| विवरण गलत होने की स्थिति में मेरे ऊपर दंडात्मक कार्रवाई की जा सकती है| </li>
</ol>
  
   
  </div>
</div>
        </div>

            <%--<div class="row">
                		<div class="col-12 col-sm-10 col-md-10 globalradio">
						<div class="form-group">
							<table >
		<tr>
			<td>
                <label class="form-check-label" for="flexCheckDefault">
        <b>क्या आपका राशि बैंक (SLBC) द्वारा काटा गया है ?</b> 
       </label>
                <asp:RadioButtonList ID="rbtnRefundSLBC" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtnRefundSLBC_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem  Value="Y">हाँ </asp:ListItem>
                        <asp:ListItem Selected="True" Value="N">नहीं </asp:ListItem>
                    </asp:RadioButtonList>
               
                </td>
		</tr>
	</table>
						</div>
					</div>

       </div>--%>
               

                <%--<div class="row" runat="server" id="divSlbc" visible="false">
                    <div class="col-12 col-sm-4 col-md-4">
				<div class="form-group">
					<label class="control-label mb-2" >राशि कटौती बैंक </label>               
                     <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select" >
                            <asp:ListItem Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">भारत कोष</asp:ListItem>
                        <asp:ListItem Value="2">राज्य कोष खाता संख्या (40903138323, IFSC: SBIN0006379)</asp:ListItem>                       
                            <asp:ListItem Value="3">प्रसानिक मद-खाता संख्या (38269533475, IFSC: SBIN0006379)</asp:ListItem>
                    <asp:ListItem Text="अन्य कारणों से अयोग्य घोषित किसान खाता संख्या (40903140467, IFSC: SBIN0006379)" Value="4"></asp:ListItem>                   
                        </asp:DropDownList>
				</div>
			</div>
							
			
            <div class="col-12 col-sm-4 col-md-4">
                <div class="form-group">
                    <label class="control-label mb-2">IFSC Code दर्ज करें  </label>
                      <asp:TextBox ID="TxtIfsc" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
					</div>

                    <div class="col-12 col-sm-4 col-md-4" >
						<div class="form-group">
					<label class="control-label mb-2" >खाता संख्या  </label>               
                      <asp:TextBox ID="txtAc" runat="server" CssClass="form-control"  ></asp:TextBox>
				</div>
					</div>

                       <div class="col-12 col-sm-4 col-md-4" >
						<div class="form-group">
					<label class="control-label mb-2" >राशि  </label>               
                      <asp:TextBox ID="txtSlbcAmount" runat="server" CssClass="form-control"  ></asp:TextBox>
				</div>
					</div>

            <div class="col-12 col-sm-4 col-md-4">
				<div class="form-group">
					<label class="control-label mb-2" >राशि कटने का तारीख  </label>                     								
                  <input   Class="form-control" autocomplete="off" type="date" id="txtDateSlbc"/>
				</div>
			</div>

            <div class="col-12 col-sm-4 col-md-4">
				<div class="form-group">
					<label class="control-label mb-2" >राशि कटने का साक्ष्य अपलोड करें  </label>
                    <asp:FileUpload ID="FileUploadslbc" runat="server" CssClass="form-control"/>
				</div>
			</div>

                </div>--%>


         
        <div class="row">
                        <div class="col-lg-4 col-sm-12 col-md-4"></div>
            <div class="col-lg-4 col-sm-12 col-md-4">						
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  CssClass="custombtn" OnClientClick="return Validate()"/>
					</div>

                 <div class="col-lg-4 col-sm-12 col-md-4"></div>
            </div>

            </div> <!--=======End DivData ===========-->
           <div class="col-lg-12">
    <asp:Repeater ID="RepeaterData" runat="server" Visible="false">  
        <ItemTemplate> 
            <div class="card card-raised mb-4">
                <div class="card-header bg-transparent px-4">
                    <div class="d-flex justify-content-between align-items-center">
                        <div class="me-4">
                            <h2 class="card-title mb-0"><b>TransactionNo : <%#Eval("TransactionNo")%> </b></h2>
                           <%-- <div class="card-subtitle">Details and history</div>--%>
                        </div>                                
                    </div>
                </div>                       
         
                <table class="m-3">  
    
    <tr>  
        <td>Farmer_Name</td>  
        <td><%#Eval("Farmer_Name")%></td>  
    </tr>  
    <tr>  
        <td>Registration_Id</td>  
        <td><%#Eval("Registration_Id")%></td>  
    </tr>  
    <tr>  
        <td>Reg_No</td>  
        <td><%#Eval("Reg_No")%></td>  
    </tr>  
    <tr>  
        <td>MobileNo</td>  
        <td><%#Eval("MobileNo")%></td>  
    </tr>  
    <tr>  
        <td>Amount</td>  
        <td><%#Eval("Amount")%></td>  
    </tr> 
     <tr>  
        <td>NoOfInstallments</td>  
        <td><%#Eval("NoOfInstallments")%></td>  
    </tr> 
                    <tr>  
        <td>PaymentReturnMode</td>  
        <td><%#Eval("PaymentReturnMode")%></td>  
    </tr> 
     <tr>  
        <td>PaymentReturnAC</td>  
        <td><%#Eval("PaymentReturnAC")%></td>  
    </tr> 
     <tr>  
        <td>TransactionDate</td>  
        <td><%#Eval("TransactionDate")%></td>  
    </tr> 
    <%--<tr>  
        <td>Document</td>  
        <td>
            <a href="<%#Eval("DocPath")%>" target="_blank" style="color:blue">दस्तावेज देखें </a>   </td>
        </tr>--%>
</table>
            </div>                          
        </ItemTemplate>  
    </asp:Repeater> 
</div>
        </div>

    

        
<script type="text/javascript">   
    $(function () {
        var dtToday = new Date();

        var month = dtToday.getMonth() + 1;
        var day = dtToday.getDate();
        var year = dtToday.getFullYear();
        if (month < 10)
            month = '0' + month.toString();
        if (day < 10)
            day = '0' + day.toString();

        var minDate = year + '-' + month + '-' + day;

        // or instead:
        // var maxDate = dtToday.toISOString().substr(0, 10);

        //alert(maxDate);
       
       // $('#txtDate').attr('max', minDate);
        $('[id*=txtDate]').attr('max', minDate);
    });
 </script>

        <script type="text/javascript">
            function Validate() {

                var ddlPaymentType = document.getElementById("<%=ddlPaymentType.ClientID %>");                   
                var ddlPayType = document.getElementById("<%=ddlPayType.ClientID %>"); 
                var ddlInstallments = document.getElementById("<%=ddlInstallments.ClientID %>");
                var UTR = document.getElementById("<%=txtUTRNo.ClientID %>");
                var Date = document.getElementById("<%=txtUTRDate.ClientID %>");
               
                if (ddlPaymentType.value == "") {               
                    alert("कृपया वापसी का खाता चयन का करें !");
                    return false;
                }
                else if (ddlPayType.value == "") {
                    alert("कृपया वापसी का तरीका का चयन करें !");
                    return false;
                }
                else if (ddlInstallments.value == "") {               
                    alert("कृपया वापसी का किस्त का चयन करें !");
                    return false;
                }
                else if (ddlInstallments.value == "") {               
                    alert("कृपया वापसी का किस्त का चयन करें !");
                    seterror("ddlInstallments","aa");
                    return false;
                }
                else if (Date.value== "") {               
                    alert("ट्रांजेक्शन दिनांक दर्ज करें !");                   
                    return false;
                }               
                return true;
            }
        </script>

  <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
</asp:Content>

