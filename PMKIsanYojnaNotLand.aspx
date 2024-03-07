<%@ Page Title="" Language="C#" MasterPageFile="MasterPagePublic.master" AutoEventWireup="true" CodeFile="PMKIsanYojnaNotLand.aspx.cs" Inherits="PMKIsanYojna" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="sc1" runat="server" ></asp:ScriptManager>
       <%-- <style>
        .btn span.glyphicon {
            opacity: 0;
        }

        .btn.active span.glyphicon {
            opacity: 1;
        }

        .button {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 15px 32px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
        }

        .buttonSerch {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 10px 15px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 13px;
            font-weight: bold;
            margin: 4px 2px;
            cursor: pointer;
        }

        .button2 {
            background-color: #008CBA;
        }
        /* Blue */
        .button3 {
            background-color: #f44336;
        }
        /* Red */
        .button4 {
            background-color: #4CAF50;
            color: black;
        }
        /* Gray */
        .button5 {
            background-color: #555555;
        }
        /* Black */
    </style>--%>
    <script type="text/javascript">
        function ShowPopupnew() {
            //$("#exampleModalCenter .modal-title").html(title);
            //$("#exampleModalCenter .modal-body").html(body);
            $("#signout-modal").modal("show");
        }
    </script>
    <script type="text/javascript">
        function validate(evt) {

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31
            && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function valphone(e) {
            var allow = '1234567890.'
            var k;
            k = document.all ? parseInt(e.keyCode) : parseInt(e.which);
            return (allow.indexOf(String.fromCharCode(k)) != -1);
        }
    </script>

    <%--cellpadding="1" cellspacing="1"--%>

    <style type="text/css">
 .modal-content {
    position: relative;
    display: -ms-flexbox;
    display: flex;
    -ms-flex-direction: column;
    flex-direction: column; 
    max-width: 800px !important;
    pointer-events: auto;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid rgba(0,0,0,.2);
    border-radius: .3rem;
    outline: 0;
}
        }
    </style>
     <div class="panel panel-success">
        <div class="panel-heading" style="font-family: Verdana; font-weight: bold; font-size: 18px; color: green;" align="center"></div>
    </div>


    <center> 
    <table>

        <tr>
            <td >पंजीकरण संख्या:</td>
            <td><asp:TextBox ID="TextBox1" runat="server" MaxLength="13" class="form-control"></asp:TextBox>
             
            </td>
        
            <td align="left">&nbsp;&nbsp; <asp:Button ID="Button1" runat="server" Text="Search"  OnClick="Button1_Click" class="btn btn-success"  /></td>
          <%--  <td>
                <asp:TextBox ID="TextBox2" runat="server" MaxLength="4" class="form-control" Width="70px" Visible="false" ></asp:TextBox>
            </td>
            <td>

                <asp:Button ID="Button3" runat="server" Text="Validate & Apply" class="btn btn-success"  Visible="false" OnClick="Button3_Click"  />
            </td>--%>
            <td>


            </td>
        </tr>

        <tr>
            <td style="font-size:14px">&nbsp;</td>
            <td>&nbsp;</td>
        
            <td>
              
            </td>
            <td>
                &nbsp;</td>
            <td>

                &nbsp;</td>
            <td>


                &nbsp;</td>
        </tr>
    </table>
 <table>
              <tr>
            <td   >
               <asp:Label ID="lblMsgnew" runat="server" Text=" ** कृपया 13 अंको का किसान पंजीकरण संख्या बॉक्स में प्रविष्टि करें| " class="label label-danger"  ></asp:Label> </td>
            </tr>
        </table>
<table>
</table>
  <asp:Panel ID="pnlInc" runat="server">
        <div class="panel panel-success">
            <div class="panel-heading">प्रधानमंत्री किसान सम्मान आवेदन में त्रुटि सुधार के लिए दिशा-निर्देश एवं घोषणा :</div>
            <div class="panel-body" style="font-size: 15px;">
<table>
<tr>
<td>
    <br>
    <br></br>
    प्रधानमंत्री किसान सम्मान योजना अंतर्गत कृषि विभाग द्वारा केंद्र सरकार को भेजे गए कुछ सत्यापित आवेदनों में PFMS द्वारा राशि अंतरण के समय निम्न प्रकार की त्रुटियाँ पायी गई जिसके कारण राशि अंतरित नहीं हो पायी एवं आवेदन त्रुटि सुधार के लिए वापस भेज दी गयी है-<br>
    <br></br>
    • किसान का नाम “ENGLISH” में होना जरूरी है- जिन किसान का नाम आवेदन में “HINDI” में है, कृपया नाम संशोधित करें।
    <br>
    <br></br>
    • आवेदन में आवेदक का नाम और बैंक अकाउंट में आवेदक का नाम भिन्न होना- किसान को अपने बैंक शाखा जा कर बैंक में अपना नाम आधार और आवेदन में दिये गए नाम के अनुरूप करना होगा।<br>
    <br></br>
    • IFSC कोड लिखने में गलती।<br>
    <br></br>
    • बैंक अकाउंट नंबर लिखने में गलती।<br>
    <br />
    • (Joint Bank Account) जोइंट बैंक अकाउंट नंबर की प्रविष्टि नहीं करें ।<br />
    <br> 
    • गाँव के नाम में गलती।
    <br>
    <br> 
    उपर्युक्त सभी प्रकार की त्रुटियों में सुधार के लिए आधार सत्यापन जरूरी है। अतः मैं प्रधानमंत्री किसान सम्मान योजना आवेदन के त्रुटियों में आवश्यक सुधार करने के लिए आधार सत्यापन की अनुमति देता/देती हूँ।<br>
    <br> 
    ## आधार सत्यापन के लिए किसान अपने निकटतम CSC/वसुधा केंद्र/ सहज केंद्र से संपर्क करें। </br>
    </br>
    </br>
     
</br>

 </td>
</tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
</table>
</div>
</div>
    </asp:Panel>   


       
     </center> 
       <table   >
            <tr>
                <td align="left" >
 <asp:Label ID="lblVle" runat="server" Text="Enter your VLE ID:" Visible="false"></asp:Label></b>
                    <asp:Label ID="lblsessiondata" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                <td align="right" >
                    <asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click"></asp:LinkButton>
                </td>
            </tr>
        </table>           
    <asp:Panel ID="pnlBody" runat="server" Visible="false">
        <div class="panel panel-success">
            <div class="panel-heading"  style="color:red; font-size:15px; font-weight:bold;">किसान का विवरण</div>
            <div class="panel-body" >
                <center>
             <table id="tblsearchrecord"  width="80%"  class="table table-bordered"> <%--cellpadding="1" cellspacing="1"--%>

            <tr > 
                <td>
                    <asp:Label ID="lblregid" runat="server" Text="पंजीकरण संख्या :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblregistrationid" runat="server" Font-Bold="True"  ForeColor="Red" ></asp:Label>
                </td>
                <td >  <asp:Label ID="lblfrmrtype" runat="server" Text="कृषक श्रेणी :"></asp:Label></td>
                <td style="text-align: left">  <asp:Label ID="lblfrmsrtype" runat="server"  ForeColor="Red"></asp:Label></td>
            </tr>
            <tr >
                <td>
                    <asp:Label ID="lblname" runat="server" Text="किसान का नाम"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblfulname" runat="server" Font-Size="12px"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="lblfthrname" runat="server" Text="पिता का नाम :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblfathername" runat="server" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr >
                <td class="auto-style1">
                    <asp:Label ID="lbldob" runat="server" Text="जन्म तिथि :"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblfrmrdob" runat="server" Font-Size="12px"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="lblage" runat="server" Text="वर्तमान उम्र :"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="lblttlage" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr >
                <td>
                    <asp:Label ID="lbldist" runat="server" Text="जिला :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lbldistname" runat="server" Font-Size="12px"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="lblblk" runat="server" Text="प्रखण्ड. :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblblockname" runat="server" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr >
                <td>पंचायत का नाम:</td>
                <td>
                    <asp:Label ID="lblPanchayat" runat="server" Font-Size="12px"></asp:Label>
                </td>
                <td >गाँव का नाम :</td>
                <td>
                    <asp:Label ID="lblVill" runat="server" ></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-default dropdown-toggle" Visible="false">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lbladhr" runat="server" Text="आधार संख्या :"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="lblaadaar" runat="server" ></asp:Label>
                </td>
                <td >
                    <asp:Label ID="lblmbl" runat="server" Text="मोबाइल नंबर :"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="lblmobile" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr >
                <td>
                    <asp:Label ID="lblgnder" runat="server" Text="लिंग :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblgender" runat="server" ></asp:Label>
                </td>
                <td>
                  बैंक का नाम :
                </td>
                <td colspan="2">
                   <asp:Label ID="lblBank" runat="server" ></asp:Label>
                </td>
            </tr>
                 <tr>
                     <td>अकाउंट नंबर :</td>
                     <td>
                         <asp:Label ID="lblAcIfc" runat="server" ></asp:Label>
                     </td>
                     <td>IFSC कोड :</td>
                     <td colspan="2">
                         <asp:Label ID="lblIFSCCode" runat="server" ></asp:Label>
                     </td>
                 </tr>
               
        </table>
          </center>
            </div>
        </div>
        <%-- <asp:Panel ID="Panel1" runat="server" GroupingText="किसान का विवरण" Font-Names="Comic Sans MS"  Width="100%" Visible="false" >--%>

        <%-- </asp:Panel>--%>


        <div class="panel panel-success">
            <div class="panel-heading"  style="color:red; font-size:15px; font-weight:bold;">किसान का प्रकार एवं भूमि विवरण</div>
            <div class="panel-body" >
                <%-- <asp:Panel ID="Panel3" runat="server"  Visible="false"  GroupingText="किसान का प्रकार एवं भूमि विवरण" >--%>
                <center>   
                         <table>
            <tr>
                <td>पंचायत का प्रकार:&nbsp;&nbsp;&nbsp;&nbsp; </td>
             
                
                <td>
                   
                    <asp:DropDownList ID="ddlPanchayat" runat="server" Width="150px"  class="btn btn-default dropdown-toggle">
                      
                        <asp:ListItem Text="शहरी"  Value="U" Selected="True"></asp:ListItem>
                      <asp:ListItem Text="ग्रामीण"  Value="R" ></asp:ListItem>
                    </asp:DropDownList>
                           
                    
                </td>
                <td>किसान का प्रकार:&nbsp;&nbsp;&nbsp;&nbsp; </td>
             
                
                <td>
                    <%--<asp:UpdatePanel ID="upd11" runat="server" >
                        <ContentTemplate >--%>
                    <asp:DropDownList ID="ddlKisanType" runat="server" Width="200px"  class="btn btn-default dropdown-toggle">
                      
                        <asp:ListItem Text="रैयत किसान परिवार"  Value="1" Selected="True"></asp:ListItem>
                       <%-- <asp:ListItem Text="गैर-रैयत किसान"  Value="2"  ></asp:ListItem>--%>
                    </asp:DropDownList>
                           <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    
                </td>
                <td>किसान की वैवाहिक स्थिति:&nbsp;&nbsp;&nbsp;&nbsp; </td>
             
                
                <td>
                    <%--<asp:UpdatePanel ID="upd11" runat="server" >
                        <ContentTemplate >--%>
                    <asp:DropDownList ID="ddlMaritalstatus" runat="server" Width="150px"  class="btn btn-default dropdown-toggle" OnSelectedIndexChanged="ddlMaritalstatus_SelectedIndexChanged"
                       AutoPostBack="true" >
                        <asp:ListItem Text="-- चयन करें --"  Value="0"></asp:ListItem>
                        <asp:ListItem Text="विवाहित"  Value="1" ></asp:ListItem>
                        <asp:ListItem Text="अविवाहित"  Value="2"  ></asp:ListItem>
                    </asp:DropDownList>
                           <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    
                </td>
            </tr>
<%--<tr>
    <td colspan="2">   <asp:Label ID="Label1" runat="server" Text=" ** कृपया किसान के प्रकार के चयन में साबधानी बरतें| चयन के बाद बदलाब संभव नहीं है| " class="label label-danger" ></asp:Label> </td>
</tr>--%>
        </table>
              <br />
            
                <%--      <asp:UpdatePanel ID="upd1" runat="server">
            <ContentTemplate>--%>
                 
          <div class="panel panel-success">
          <div class="panel-heading" style="color:red; font-size:15px; font-weight:bold;">परिवार का विवरण</div>
           <div class="panel-body" style="font-size:12px;">

          
                <table class="table-bordered table-responsive table table-striped " style="width: 100%;" align="center">
                    <tr>
                        <td>सदस्य का संबंध <asp:DropDownList ID="ddlRelation" runat="server" width="130px" Font-Names="Verdana" Font-Size="14px" 
                                         class="btn btn-default dropdown-toggle" >
                                         <%--<asp:ListItem Value="0" Text="--Select--" Selected="True"></asp:ListItem> 
                                         <asp:ListItem Value="1" Text="पति/पत्नी" ></asp:ListItem>
                                             <asp:ListItem Value="2" Text="माता" ></asp:ListItem>
                                               <asp:ListItem Value="3" Text="पिता" ></asp:ListItem>
                                         <asp:ListItem Value="4" Text="वयस्क बच्चे" ></asp:ListItem>--%>
                                         </asp:DropDownList> </td>
                        
                        <td>जीवित/मृत <asp:DropDownList ID="ddlRelativeLive" runat="server" width="130px" Font-Names="Verdana" Font-Size="14px" 
                                         class="btn btn-default dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlRelativeLive_SelectedIndexChanged" >
                                         <asp:ListItem Value="0" Text="--Select--" Selected="True"></asp:ListItem> 
                                         <asp:ListItem Value="1" Text="जीवित" ></asp:ListItem>
                                             <asp:ListItem Value="2" Text="मृत" ></asp:ListItem>                                              
                                         </asp:DropDownList></td>
                        
                        <td>आधार नंबर <asp:TextBox ID="txtAadhaarR" OnTextChanged="txtAadhaarR_OnTextChanged" AutoPostBack="true" runat="server" Width="150px" 
                                        onkeypress="return validate(event)" class="form-control" MaxLength="12"></asp:TextBox></td>
                       
                        <td>नाम (आधार के अनुसार) <asp:TextBox ID="txtNameR"  runat="server"    class="form-control"  ></asp:TextBox></td>
                       
                        <td align="right">जन्म की तारीख (आधार के अनुसार) <asp:TextBox ID="txtDobR"  runat="server"   class="form-control"  MaxLength="10" ></asp:TextBox>
                                       <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtDobR"   To-Date="02-01-2001"/></td>
                        <td><asp:Button ID="btnSendOtp" runat="server" Text="Send OTP" OnClick="btnSendOtp_Click"  class="btn btn-success" Visible="false"  />
                            <asp:Label runat="server"  id="lblTxtNo" Visible="false"></asp:Label>
                        
                        </td>
                        
                    </tr>
                    <tr>
                        
                        <td id="colOTP" runat="server" visible="false">आधार नंबर सत्यापित करें <asp:TextBox ID="txtUIDOTP" runat="server" Width="150px" 
                                        onkeypress="return validate(event)" class="form-control" MaxLength="10"></asp:TextBox></td>
                        <td>
                                         <asp:Button ID="btnVerifyOtp" runat="server" Text="Verify" OnClick="btnVerifyOtp_Click"  class="btn btn-success" visible="false" />

                        </td>
                        <td></td>
                        <td></td>
                         <td></td>
                        <td colspan="2"> <asp:Button ID="ButtonAddR" runat="server" Text="Add New Member" OnClick="ButtonAddR_Click"  class="btn btn-success"  /></td>
                    </tr>
                </table>
                                         
                                    
                 <asp:Label runat="server" ID="lblMsg" Font-Bold="True" ForeColor="White" Font-Names="Verdana" Font-Size="14px" class="label label-success"></asp:Label>    
               
               <asp:GridView ID="gvView" AutoGenerateColumns="False" runat="server" class="table table-bordered">
        
        <Columns>
       
            <asp:TemplateField HeaderText="S.No.">
                <ItemTemplate>
                    <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>' />
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Registration ID">
                <ItemTemplate>               
                    <asp:Label ID="lblMemberRid" runat="server" Text='<%#Eval("RegistrationID")%>' />               
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Member Type">
                <ItemTemplate>               
                    <asp:Label ID="lblMember" runat="server" Text='<%#Eval("Member")%>' />               
                </ItemTemplate>
            </asp:TemplateField>
           
           <asp:TemplateField HeaderText="Member Status">
                <ItemTemplate>               
                    <asp:Label ID="lblMemberStatus" runat="server" Text='<%#Eval("Live")%>' />               
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Aadhaar No">
                <ItemTemplate>               
                    <asp:Label ID="lblAadhaarNo" runat="server" Text='<%#Eval("AadhaarNo_FamilyMember")%>' />               
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>               
                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name_FamilyMember")%>' />               
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="DOB">
                <ItemTemplate>               
                    <asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB_FamilyMember")%>' />               
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
           </div>

           </div>

                 

                  
                    
                    <div class="panel panel-success">
      <div class="panel-heading"  style="color:red; font-size:15px; font-weight:bold;">खेती करने योग्य भूमि का विवरण</div>
      <div class="panel-body"  >
                <%-- <asp:Panel ID="pnlfARMER" runat="server" GroupingText="खेती करने योग्य भूमि का विवरण" Font-Size="12px">--%>
            <center>
              <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="false"  HeaderStyle-Font-Size="14px" OnRowCreated="Gridview1_RowCreated"   ShowFooter="true" OnRowDataBound="Gridview2_RowDataBound"  class="table table-bordered">
                            <Columns>
                                <asp:TemplateField HeaderText="Sl. No." ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Names="Comic Sans MS" Font-Size="12px" ForeColor="Green" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="जिला का नाम ">
                                    <ItemTemplate>                                                             
                                        <asp:DropDownList ID="ddldist" runat="server" width="130px" Font-Names="Verdana" Font-Size="14px" AutoPostBack="true" OnSelectedIndexChanged="ddldist_SelectedIndexChanged" class="btn btn-default dropdown-toggle" > </asp:DropDownList>                                                                 
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="प्रखंड का नाम " >
                                    <ItemTemplate>                                                             
                                        <asp:DropDownList ID="ddlBlock" runat="server"  width="130px"  Font-Names="Verdana" Font-Size="14px" class="btn btn-default dropdown-toggle"> </asp:DropDownList>                                                                 
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="थाना नंबर" ItemStyle-Width="20px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt1" runat="server" Width="50px" onkeypress="return validate(event)" class="form-control" MaxLength="5"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="खाता नंबर ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt2"  runat="server"  Width="50px" onkeypress="return validate(event)" class="form-control"  MaxLength="5"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="खेसरा नंबर ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt3"  runat="server"  Width="50px" onkeypress="return validate(event)" class="form-control"  MaxLength="5"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="कुल रकवा (डिसिमिल में)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt5"  runat="server"  Width="70px" onkeypress="return ValidateAlpha(event);" class="form-control"  MaxLength="6"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="आवेदक का हिस्सा (डिसिमिल में)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt4"   runat="server" Width="70px" onkeypress="return ValidateAlpha(event);" OnTextChanged="QtyChanged" Text="0" AutoPostBack="true" class="form-control"  MaxLength="6"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Size="12px" HorizontalAlign="Center" VerticalAlign="Middle" Width="20%" />
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click"  class="btn btn-success"  />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1S" runat="server" OnClick="LinkButton1S_Click" class="label label-danger">Remove</asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <HeaderStyle Font-Size="12px" />
                                </asp:GridView>
               </center>
                     <br />
        <asp:Label ID="Label101" runat="server" Text=" **कुल रकवा  तथा आवेदक का हिस्सा  का रकवा 1 से 9 डिसिमिल भूमि है तो (1.0 से 9.0) की प्रविष्टि करें |" class="label label-danger" ></asp:Label>
                      <asp:Label runat="server" ID="lblCalculate" Font-Bold="True" ForeColor="White" Font-Names="Verdana" Font-Size="14px" class="label label-success"></asp:Label>    
          </div> 
          
          
    <br />
          </div>
      <%--  </asp:Panel>
                --%>
               <%-- </ContentTemplate>
                          </asp:UpdatePanel>--%>

                 
               <%-- <tr>
                    <td>कुल हिस्सा का रकवा : <asp:TextBox ID="txtTotal" runat="server"  Enabled="false" ></asp:TextBox> </td>
                </tr>--%>
               

                <%-- </asp:Panel>--%>
            </div>
        </div>

     

        <center>
        <table width="100%">
            <tr>
                <td align ="left">

<%--  <asp:Panel ID="Panel2" runat="server"  GroupingText="शपथ पत्र"  Visible="false" >--%>
 <div class="panel panel-success">
      <div class="panel-heading"  style="color:red; font-size:15px; font-weight:bold;">शपथ पत्र</div>
      <div class="panel-body"  >
          <table>
              <tr>
                  <td valign="top" colspan="2">
    <div class="panel-heading"  style="color:red; font-size:15px; font-weight:bold;">आवेदन की शर्तें </div>
    
        <ul align="left">
            <li> <b>मै प्रमाणित करता/करती हूँ कि मेरे परिवार (पति, पत्नी और अवयस्क सदस्य) में :  </b> <br />
                1. परिवार के पास खेती योग्य भूमि है|<br />
                2. परिवार से मेरे अलावा पति/पत्नी/अवयस्क द्वारा आवेदन नहीं किया गया है |<br />
                3. मैं/परिवार  संस्थागत भूमिधारक नहीं हूँ/है|<br />
                4. मैं/ परिवार का कोई सदस्य कभी भी निम्नलिखित पदों पर कार्यरत नहीं था/हूँ/है |<br />
                &nbsp;&nbsp;4.1 संवैधानिक पद
                <br />
                &nbsp;&nbsp;4.2 केंद्र/ राज्य में  पूर्ववत / कार्यरत - मंत्री, लोक सभा/ राज्य सभा/ विधान सभा/ विधान परिषद्, महापौर नगर निगम/ नगर पालिका, सभापति जिला पंचायत|<br />
                &nbsp;&nbsp;4.3 केंद्र/राज्य अधिकारी/कर्मचारी, सरकार द्वारा स्थापित स्वयातशासी संस्था के कर्मचारी, स्थानीय निकाय के नियमित कर्मचारी (वर्ग 4/ ग्रुप D/ बहु-उद्देशीय कर्मचारी को छोड़ कर )<br />
                &nbsp;&nbsp;4.4 सेवानिवृत/ मासिक पेंशन धारक जिनकी पेंशन 10000/- रूपये से ज्यादा हो (वर्ग 4/ ग्रुप D/ बहु-उद्देशीय कर्मचारी को छोड़ कर)<br />
                &nbsp;&nbsp;4.5 पिछले साल में करदाता नहीं हैं|<br />
                &nbsp;&nbsp;4.6 डॉक्टर, इंजिनियर, वकील, चार्टर्ड अकाउंटेंट, पंजीकृत वास्तुकार(Registered Architect) इत्यादि का पेशेवर संस्था का सदस्य नहीं हूँ/है| <br />
                 
            </li>
        </ul>
       <%-- <asp:Button ID="Button3" runat="server" Text="Close" class="button" />--%>
          
               

                  </td>  

              </tr>
               <tr>
                   <td valign="top">
                       <asp:CheckBox ID="CheckBox1" runat="server"  /> &nbsp;&nbsp;
                   </td>
                   <td valign="top">मैं/परिवार उपर्युक्त बिन्दुओ को पढ़कर सुनिश्चित कर लिया हूँ/है कि मैं/परिवार उपर्युक्त शर्तो का पालन करता/करती है/हूँ |
                       <asp:LinkButton ID="lnk" runat="server" class="btn btn-warning" Text="क्लिक करें ..." Visible="false"></asp:LinkButton>
                   </td>
                   <%--OnClick="lnk_Click"--%>
              </tr>
               <tr>

                  <td valign="top" >
                        <asp:CheckBox ID="CheckBox2" runat="server" /> &nbsp;&nbsp;
                  </td>
                   <td valign="top" >
                       मेरे द्वारा दिया गया उपर्युक्त विवरण सही है| विवरण गलत होने की स्थिति में आवेदन रद्द होने की जिम्मेवारी मेरी होगी| मुझसे अनुदान राशि वसूल की जा सकती है तथा मेरे ऊपर दंडात्मक कार्रवाई की जा सकती है|  
                   </td>

              </tr>
             <tr>

                  <td valign="top" >
                        <asp:CheckBox ID="CheckBox3" runat="server" /> &nbsp;&nbsp;
                  </td>
                   <td valign="top" >
                      मैं अपना आधार नंबर एवं अन्य सूचनायें इस योजना में पात्रता के सत्यापन हेतु उपयोग की अनुमति देता/देती हूँ | 
                   </td>

              </tr>
              <tr>

                  <td valign="top" >
                        <asp:CheckBox ID="CheckBox4" runat="server" /> &nbsp;&nbsp;
                  </td>
                   <td valign="top" >
                      मेरे द्वारा दिया गया नाम और जन्म का दिनांक आधार के अनुसार सही है। 
                   </td>

              </tr>
          </table>

          </div> 
            </div> 

       <%-- </asp:Panel>--%>
                </td>

            </tr>

        </table>
      
        </center>
        <asp:Panel ID="pnl1" runat="server">
            <center>
            <table>
                <tr>

                    <td align="left">&nbsp;&nbsp;
                        <asp:Button ID="Button4" runat="server" Text="Get OTP" class="btn btn-success" OnClick="Button4_Click" /></td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" MaxLength="4" class="form-control" Width="70px" Visible="false"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="Validate & Apply" class="btn btn-success" Visible="false" OnClick="Button3_Click" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                      <td colspan="3" style="font-family:Verdana; font-size:12px;  color:red; font-weight:bold;">OTP Expire in 60 Seceonds</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Verdana" Font-Size="12px" OnClick="LinkButton2_Click" Visible="False">Re-Send OTP</asp:LinkButton>
                       
                </tr>
            </table>
                <table>
                    <tr>
                        <td>

                             <asp:Label ID="Label2" runat="server" Text="" class="label label-danger" Font-Size="12px"></asp:Label> 
                        </td>
                    </tr>
                </table>
                </center>
        </asp:Panel>
          
        <center>
        <asp:Panel ID="pnlPayment" runat="server" Visible="false">
             <table>
                    <tr>
                        <td align="center">
               <asp:Button ID="btnFirstProduct" runat="server" Text="Make Payment"  class="btn btn-info" 
                            onclick="btnFirstProduct_Click"/>
                            </td> </tr> </table> 
        </asp:Panel>
            </center>
        <asp:Panel ID="pnlSubmit" runat="server" Visible="false">
             <div class="panel panel-success">
            <div class="panel-heading">भूमि का दस्तावेज/स्वघोषित भूमि दस्तावेज (150KB in PDF Format Only) </div>
            <div class="panel-body" >
                <center>   
                    <table class="table table-bordered">
                      <tr>
                          <td align="center"  >
                
       <asp:FileUpload ID="FileUpload1" runat="server"   class="btn btn-primary" Font-Size="12px" Font-Names="Verdana"></asp:FileUpload>
    
                             
                          </td>
                      </tr>
                    </table>    
                    </center>
            </div>
        </div>
            <center>
            
        <table width="100%">
            <tr>
               
                <td align="center" >
                    <div class="panel panel-success">
      <div class="panel-heading"></div>
      <div class="panel-body" style="font-size:12px;">
                  <%--   <asp:Panel ID="PnlFinal" runat="server"  GroupingText="Submit"  Visible="false" >--%>
          

                    <asp:Button ID="btnSubmit" runat="server" Text ="Submit" class="btn btn-success" OnClick="btnSubmit_Click" /> 
                      &nbsp;<asp:Button ID="btncancel" runat="server" Text ="Cancel" class="btn btn-danger" OnClick="btncancel_Click"/>
             <asp:Button ID="Button2" runat="server" Text ="Print" class="btn btn-primary" OnClick="Button2_Click"  Enabled="true"  ></asp:Button> 
          </div> </div> 
                    <asp:HiddenField ID="hfTotalRakawa" runat="server" />
    <%--</asp:Panel> --%>
                </td>
                  

            </tr>
        </table>
        </center>
        </asp:Panel>
    </asp:Panel>
        



     <!-- Signup Modal -->
	<div class="modal fade" id="signout-modal">
		<div class="modal-dialog modal-dialog-centered">
			<div class="modal-content modal-lg">

				<!-- Modal Header -->
				<div class="modal-header text-center d-block p-5 border-bottom-0">
					<h3 class="modal-title">User Type</h3>
					<button type="button" class="close position-absolute" style="right: 15px; top: 8px;" data-dismiss="modal">&times;</button>
				</div>

				<!-- Modal body -->
				<div class="modal-body">
					<%--<p class="text-center">Are you sure you want to Sign Out?</p>--%>
					<div class="text-center py-4">
					
							 <table  class="table table-bordered"> 
                    
                        <tr>
                            <td>
                                <asp:ImageButton ID="LNLcsc" runat="server" ImageUrl="~/Images/CSC-Services.png" Width="200px" Height="50px" OnClick="LNLcsc_Click" />
                            </td>
                              <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/sahaj.jpg" Width="150px" Height="50px" PostBackUrl="https://retail.sahaj.co.in/web/guest/home" />
                            </td>
                             </tr>
                             <tr>
                              <td colspan="2">
                                <asp:ImageButton IID="btnAbc" runat="server" ImageUrl="~/Images/Guser.jpg" Width="200px" Height="50px" />
                            </td>
                        </tr>
                    </table>
					
					</div>
				</div>
			</div>
		</div>
	</div>

    
        <%--    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup" CancelControlID="btnCloseee" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="190px" Width="800px" Font-Size="14px">
                <div class="panel panel-success">
                        <div class="panel-heading">USER</div>
                        <div class="panel-body" >
                <table  class="table table-bordered"> 
                    
                        <tr>
                            <td>
                                <asp:ImageButton ID="LNLcsc" runat="server" ImageUrl="~/Images/CSC-Services.png" Width="200px" Height="50px" OnClick="LNLcsc_Click" />
                            </td>
                              <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/sahaj.jpg" Width="150px" Height="50px" PostBackUrl="https://retail.sahaj.co.in/web/guest/home" />
                            </td>
                              <td>
                                <asp:ImageButton IID="btnAbc" runat="server" ImageUrl="~/Images/Guser.jpg" Width="200px" Height="50px" />
                            </td>
                        </tr>
                    <tr>
                        <td colspan="3" align="center"> 

                            <asp:Button ID="btnCloseee" runat="server" Text="Close"  class="btn btn-danger"/>
                        </td>
                    </tr>
                </table>
                            </div> </div> 
            </asp:Panel>--%>
 
</asp:Content>
 
     

