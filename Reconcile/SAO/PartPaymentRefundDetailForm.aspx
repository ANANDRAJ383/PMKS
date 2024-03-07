<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="PartPaymentRefundDetailForm.aspx.cs" Inherits="DAO_RefundDetailForm" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin:30px 50px 10px 50px;">

         <div class="row">
                        <!-- Revenue breakdown chart example-->
                        <div class="col-lg-12 ">
                            <div class="card card-raised h-100">
                                <div class="card-header bg-transparent px-4">
                                    <div class="d-flex justify-content-between align-items-center">
                                        <div class="me-4">
                                            <h2 class="card-title mb-0"><b>रिफंड विवरण </b></h2>
                                        </div>
                                       
                                    </div>
                                </div>
                                                  
	                  <div class="m-5">
		<div class="row mb-3">
			<div class="col-lg-6 ">
                <label><b>Search By </b></label>
                <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal"  CssClass="form-check-label">
            <asp:ListItem Selected="True" Value="M"> &nbsp;पंजीकृत मोबाइल नंबर &nbsp;</asp:ListItem>
            <asp:ListItem Value="R">&nbsp;पंजीकरण संख्या &nbsp;</asp:ListItem>
			<asp:ListItem Value="B">&nbsp;पीएम किसान पंजीकरण संख्या (उदाहरण- BR111111111)</asp:ListItem>
        </asp:RadioButtonList>
                </div>
			<div class="col-lg-4">
			<div class="form-group">
				<label class="control-label" ><b>Enter Value </b> </label>
                <asp:TextBox ID="txtMobRegNo" runat="server" CssClass="form-control" ></asp:TextBox>
			</div>
            </div>
		<div class="col-lg-2">
				<div class="form-group">
					<br />		
                    <asp:Button ID="btnGetData" runat="server" Text="GetData"  CssClass="btn btn-raised-primary" OnClick="btnGetData_Click"/>
				<div><asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="17px"></asp:Label></div>
		</div>
	
</div>
			
		</div>
	

        <div id="divData" runat="server" visible="false"  >       
		
         <table id="ContentPlaceHolder1_Table3" class="table table-bordered table-hover">
                    <tbody>
                     <%--   <tr id="ContentPlaceHolder1_tr1">
                            <th colspan="2">
                                <span id="ContentPlaceHolder1_Label1">अयोग्य / अनिच्छुक किसान </span>
                            </th>
                        </tr>--%>
                       
                        <tr>
                            <td>
                                <label id="Label2"><b>किसान का नाम</b> : </label>
                                <asp:Label ID="lblName" runat="server" class="aspNetDisabled" Text="AJIT KUMAR YADAV"></asp:Label>

                            </td>
                            <td>
                                <label id="lblRegDate"><b>पंजीकरण संख्या</b>: </label>
                                <asp:Label ID="lblRegistrationId" runat="server" class="aspNetDisabled" Text="BR214729763" ForeColor="Red"
                                    Font-Bold="True" Font-Size="12pt"></asp:Label>
                            </td>
                        </tr>
                        <tr id="ContentPlaceHolder1_trState">
                            <td>
                                <label id="lblState"><b>पिता/पति का नाम </b>: </label>
                                <asp:Label ID="lblFName" class="aspNetDisabled" runat="server" Text="BIHAR" ></asp:Label>
                                
                            </td>
                            <td>
                                <label id="lblDistric"><b>ज़िला </b>: </label>
                                <asp:Label ID="lblDist" runat="server" class="aspNetDisabled" Text="BANKA"></asp:Label>
                            </td>
                        </tr>
                        <tr id="ContentPlaceHolder1_trblock">
                            <td>
                                <label id="lblBlockN"><b>प्रखंड </b>: </label>
                                 <asp:Label ID="lblBlock"  runat="server" Text="BARAHAT" class="aspNetDisabled"></asp:Label>
                            </td>
                            <td>
                                <label id="lblPan"><b>पंचायत</b> : </label>
                                <asp:Label ID="lblPanchayat"  runat="server" Text="Tappadih" class="aspNetDisabled"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label id="lblVill"><b>गाँव </b>: </label>
                                <asp:Label ID="lblVillage"  runat="server" Text="InActive" class="aspNetDisabled"></asp:Label>
                            </td>
                            <td>
                                <div id="ContentPlaceHolder1_divActiveStatus" >
                                    <label id="lblReason" class="control-label required"><b>अयोग्य के कारण </b>: </label>
                                     <asp:Label ID="lblR"  runat="server" Text="Beneficiary is Inactive due to Income tax payee." class="aspNetDisabled"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr id="ContentPlaceHolder1_tr3">
                            <td>
                                <label id="lblPFSStatus"><b>कुल प्राप्त किस्तें </b>: </label>
                                <asp:Label ID="lblTotalGetPay"  runat="server" Text="5" class="aspNetDisabled" Font-Size="12pt"></asp:Label>
                            </td>
                            <td>
                                <label id="lblAadharStatus"><b>कुल प्राप्त राशि</b> : </label>
                                 <asp:Label ID="lblTotalAmount"  runat="server" Text="10000" class="aspNetDisabled" Font-Size="12pt"></asp:Label>
                            </td>
                        </tr>
                        <tr id="ContentPlaceHolder1_tr5" runat="server" visible="false">
                            <td>
                                <label ><b>कुल बकाया किस्तें </b>: </label>
                                <asp:Label ID="lblTotalGetPending"  runat="server" Text="0" class="aspNetDisabled" Font-Size="12pt"></asp:Label>
                            </td>
                            <td>
                                <label ><b>कुल बकाया राशि </b>: </label>
                                 <asp:Label ID="lblTotalPendingAmount"  runat="server" Text="0" class="aspNetDisabled" Font-Size="12pt"></asp:Label>
                            </td>
                        </tr>
                        <tr id="ContentPlaceHolder_treturn">
                            <td>
                                <label><b>मोबाइल नंबर </b>: </label>
                                <asp:Label ID="lblMobileNo"  runat="server"  class="aspNetDisabled" ForeColor="Red" Font-Bold="True" Font-Size="12pt"></asp:Label>
                            </td>
                            <td>
                                <label id=""><b>पीएम किसान पंजीकरण संख्या</b> : </label>
                                  <asp:Label ID="lblPMKNo"  runat="server" class="aspNetDisabled" ForeColor="Red" Font-Bold="True" Font-Size="12pt"></asp:Label>
                            </td>
                        </tr>
                    </tbody>

                </table>
            </div>
        <div class="row mt-3" id="divEntry" runat="server" visible="false">
			<div class="col-12 col-sm-3 col-md-3 mb-3">
				<div class="form-group">
					<label class="control-label" ><b>वापसी का खाता</b> <span class="mandatory">*</span></label>         

                     <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-select" >
                            <asp:ListItem Value="">-- Select --</asp:ListItem>
                            <asp:ListItem Value="Bharat Kosh">भारत कोष</asp:ListItem>
                        <asp:ListItem Value="Rajy Kosh">कृषि निदेशक खाता संख्या (40903138323, IFSC: SBIN0006379)</asp:ListItem>                       
                            <asp:ListItem Value="Prashanik Madh">प्रसानिक मद-खाता संख्या (38269533475, IFSC: SBIN0006379)</asp:ListItem>
                    <asp:ListItem Text="अन्य कारणों से अयोग्य घोषित किसान खाता संख्या (40903140467, IFSC: SBIN0006379)" Value="Other"></asp:ListItem>                   
                        </asp:DropDownList>
				</div>         
			</div>
							
			<div class="col-12 col-sm-3 col-md-3  mb-3" >
						<div class="form-group">
					<label class="control-label" ><b>वापसी का तरीका</b> <span class="mandatory">*</span>  </label>               
                     <asp:DropDownList ID="ddlPayType" runat="server" CssClass="form-select" >
                            <asp:ListItem Value="0">-- Select --</asp:ListItem>
                            <asp:ListItem Value="Online">अनलाइन</asp:ListItem>
                        <asp:ListItem Value="Cheque">चेक</asp:ListItem>                       
                    <asp:ListItem Text="कैश" Value="Cash"></asp:ListItem>
                         <asp:ListItem Text="यू पी आई(UPI)" Value="UPI"></asp:ListItem>
                        </asp:DropDownList>
				</div>
					</div>

            <div class="col-12 col-sm-3 col-md-3  mb-3">
                <div class="form-group">
                    <label class="control-label"><b>वापसी का किस्त </b><span class="mandatory">*</span> </label>
                    <asp:DropDownList ID="ddlInstallments" runat="server" CssClass="form-select" 
                        OnSelectedIndexChanged="ddlInstallments_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
					</div>

            <div class="col-12 col-sm-3 col-md-3  mb-3">
				<div class="form-group">
					<label class="control-label" ><b>वापसी राशि </b> <span class="mandatory">*</span></label>
                    <asp:TextBox ID="txtReturnAmount" runat="server" CssClass="Disabled form-control" value="0"  ReadOnly="true" ></asp:TextBox>
				</div>
                
			</div>

			<div class="col-12 col-sm-3 col-md-3  mb-3">
				<div class="form-group">
					<label class="control-label" ><b>ट्रांजेक्शन/यूपीआई/यूटीआर नंबर  </b><span class="mandatory">*</span></label>
                    <asp:TextBox ID="txtUTRNo" runat="server" CssClass="form-control" placeholder="ट्रांजेक्शन नंबर/यूपीआई नंबर/यूटीआर नंबर दर्ज करें !" ></asp:TextBox>      
                   
				</div>                 
			</div>

            <div class="col-12 col-sm-3 col-md-3  mb-3">
                <label class="control-label" ><b>ट्रांजेक्शन दिनांक </b><span class="mandatory">*</span></label>   
				<div class="input-group">                      
                     <asp:TextBox ID="txtUTRDate" runat="server" CssClass="form-control"  ></asp:TextBox>  
                    <span class="input-group-text" id="basic-addon2"> <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtUTRDate" Format="dd mmm yyyy" To-Today="true" /></span>
                   
				</div>     
                 
			</div>

             <div class="col-12 col-sm-3 col-md-3  mb-3">
				<div class="form-group">
					<label class="control-label" ><b>ट्रांजेक्शन रसीद अपलोड करें (PDF Only)</b><span class="mandatory">*</span> </label>
                    <asp:FileUpload ID="fuDOC" runat="server" CssClass="form-control"/>
				</div>
			</div>

            <div class="col-12 col-sm-3 col-md-3 ">
                <label class="form-check-label" >
              <b> क्या आपका बैंक खाता लिन मार्क है ? </b>
          </label>
				<div class="globalradio">          
                    <asp:RadioButtonList ID="rbtnLeanMark" runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem  Value="Y">&nbsp;हाँ &nbsp;</asp:ListItem>
                        <asp:ListItem Selected="True" Value="N">&nbsp;नहीं </asp:ListItem>
                    </asp:RadioButtonList>
  
          </div>
			</div>
            <div class="row" id="divM" runat="server" visible="false">
	<div class="col-12 ">
				<div class="form-group">
					<label class="control-label mb-2" >सक्रिय मोबाइल नंबर<span class="mandatory">*</span></label>
                    <asp:TextBox ID="txtActiveMobileNo" runat="server" CssClass="form-control" placeholder="सक्रिय मोबाइल नंबर दर्ज करें !" MaxLength="10" onkeypress=" return onlyNumbers();"></asp:TextBox>      
                   
				</div>
			</div>
            </div>

            <div class="row"  id="dvR" runat="server" visible="false">
                		<div class="col-12 col-sm-10 col-md-10 globalradio">
						<div class="form-group">
							<table >
		<tr>
			<td>
                <label class="form-check-label" for="flexCheckDefault" >
        <b>क्या आपका राशि बैंक (SLBC) द्वारा काटा गया है ?</b> 
       </label>
                <asp:RadioButtonList ID="rbtnRefundSLBC" runat="server"  RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtnRefundSLBC_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem  Value="Y">हाँ </asp:ListItem>
                        <asp:ListItem Selected="True" Value="N">नहीं </asp:ListItem>
                    </asp:RadioButtonList>
               
                </td>
		</tr>
	</table>
						</div>
					</div>

       </div>
               

                <div class="row" runat="server" id="divSlbc" visible="false">
                    <div class="col-12 col-sm-4 col-md-4">
				<div class="form-group">
					<label class="control-label mb-2" >राशि कटौती बैंक </label>               
                     <asp:DropDownList ID="ddlPaymentTypeSLBC" runat="server" CssClass="form-select" >                    
                        </asp:DropDownList>
				</div>
			</div>
							
			
            <div class="col-12 col-sm-4 col-md-4">
                <div class="form-group">
                    <label class="control-label mb-2">IFSC Code दर्ज करें  </label>
                      <asp:TextBox ID="txtSLBCIfsc" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
                </div>
					</div>

                    <div class="col-12 col-sm-4 col-md-4" >
						<div class="form-group">
					<label class="control-label mb-2" >खाता संख्या  </label>               
                      <asp:TextBox ID="txtSLBCtAc" runat="server" CssClass="form-control"  MaxLength="20"></asp:TextBox>
				</div>
					</div>

                       <div class="col-12 col-sm-4 col-md-4" >
						<div class="form-group">
					<label class="control-label mb-2" >राशि  </label>               
                      <asp:TextBox ID="txtSLBCAmount" runat="server" CssClass="form-control" MaxLength="5" ></asp:TextBox>
				</div>
					</div>

            <div class="col-12 col-sm-4 col-md-4">
				<div class="form-group">
					<label class="control-label mb-2" >राशि कटने का तारीख  </label>
                    <div class="input-group">                      
                     <asp:TextBox ID="txtDateSLBC" runat="server" CssClass="form-control"  ></asp:TextBox>  
                    <span class="input-group-text" id="basic-addon3"> <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="txtDateSLBC" Format="dd mmm yyyy" To-Today="true" /></span>
                   
				</div> 
			</div>
                </div>
            <div class="col-12 col-sm-4 col-md-4">
				<div class="form-group">
					<label class="control-label mb-2" >राशि कटने का साक्ष्य अपलोड करें  </label>
                    <asp:FileUpload ID="FileUploadslbc" runat="server" CssClass="form-control"/>
				</div>
			</div>

                </div>
        <div class="row" id="divI" runat="server" visible="false">
            <div">
  <div class="card-body">
    <h5 class="card-title">दिशा-निर्देश</h5>
      <ol class="list-group list-group-numbered">
  <li class="list-group-item">
       किसान आवेदन में अपना नाम रसीद पर पंजीकरण संख्या , रसीद पर किसान का हस्ताक्षर/अंगूठा का निशान के बिना रसीद मान्य नहीं होगा।</li>

  <li class="list-group-item"> <asp:CheckBox ID="CheckBox2" runat="server" />  मै प्रमाणित करता/करती हूँ कि मेरे द्वारा दिया गया उपर्युक्त विवरण सही है| विवरण गलत होने की स्थिति में मेरे ऊपर दंडात्मक कार्रवाई की जा सकती है| </li>
</ol>
  
   
  </div>
</div>
        </div>
         
        <div class="row" id="divBut" runat="server" visible="false" style="margin-top:10px">
                        <div class="col-lg-4 col-sm-12 col-md-4"></div>
            <div class="col-lg-4 col-sm-12 col-md-4">						
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"  CssClass="btn btn-raised-primary" OnClientClick="return Validate()"/>
					</div>

                 <div class="col-lg-4 col-sm-12 col-md-4"></div>
            </div>
</div>
                                     </div>
                                        </div>
                                    </div> 
              <div style="margin:30px 0px 10px 0px;">
                   <div class="row">
                       <div class="col-lg-12 ">
                            <div class="card card-raised h-100">
                                <div class="card-header bg-transparent px-4">
                                    <div class="d-flex justify-content-between align-items-center">
                                        <div class="me-4">
                                            <h2 class="card-title mb-0"><b>Recovery Details </b></h2>
                                        </div>
                                       
                                    </div>
                                </div>
                        
                            
                            <asp:Repeater ID="RepeaterData" runat="server" Visible="false">
                                <ItemTemplate>
                                    <table class="m-3 table table-bordered table-hover">

                                        <tr>
                                            <td>Farmer Name</td>
                                            <td><%#Eval("Farmer_Name")%></td>

                                            <td>RegistrationId (DBT)</td>
                                            <td><strong><%#Eval("Registration_Id")%></strong></td>
                                        </tr>
                                        <tr>
                                            <td>RegistrationId (PMKS)</td>
                                            <td><strong><%#Eval("Reg_No")%></strong></td>

                                            <td>Mobile No</td>
                                            <td><%#Eval("MobileNo")%></td>
                                        </tr>
                                        <tr>
                                            <td>Amount</td>
                                            <td><%#Eval("Amount")%></td>

                                            <td>No Of Installments</td>
                                            <td><%#Eval("NoOfInstallments")%></td>
                                        </tr>
                                        <tr>
                                            <td>Payment Return Mode</td>
                                            <td><%#Eval("PaymentReturnMode")%></td>

                                            <td>Payment Return AC</td>
                                            <td><%#Eval("PaymentReturnAC")%></td>
                                            
                                        </tr>
                                        <tr>
                                            <td>TransactionDate</td>
                                            <td><%#Eval("TransactionDate","{0: dd/MM/yyyy}" )%></td>
                                        </tr>
                                        <%--<tr>  
        <td>Document</td>  
        <td>
            <a href="<%#Eval("DocPath")%>" target="_blank" style="color:blue">दस्तावेज देखें </a>   </td>
        </tr>--%>
                                    </table>

                                </ItemTemplate>
                            </asp:Repeater>
                        

			         </div></div>
             </div></div> </div></div>
    

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
                else if (UTR.value == "") {
                    if (PayType.value == "3") {
                        if (Date.value == "") {
                            alert("ट्रांजेक्शन दिनांक दर्ज करें !");
                            return false;
                        }
                    }
                    else {
                        alert("ट्रांजेक्शन नंबर/यूपीआई नंबर/यूटीआर नंबर दर्ज करें !");
                        return false;
                    }

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

