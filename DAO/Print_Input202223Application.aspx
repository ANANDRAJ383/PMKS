<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMasterNew.master" AutoEventWireup="true" CodeFile="Print_Input202223Application.aspx.cs" Inherits="Print_Input202223Application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
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
    </style>

    <script type="text/javascript">
        function validate(evt) {

            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31
                && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
    <script type="text/javascript">

        function printdiv(printpage) {
            var headstr = "<html><head><title></title></head><body>";
            var footstr = "</body>";
            var newstr = document.all.item(printpage).innerHTML;
            var oldstr = document.body.innerHTML;
            document.body.innerHTML = headstr + newstr + footstr;
            window.print();
            document.body.innerHTML = oldstr;
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <center>
          <button type="button" class="btn btn-danger" onclick="printdiv('div_print');">Print <span class="badge">1</span></button>     
          <%-- <asp:Panel ID="Panel3" runat="server"  Visible="false"  GroupingText="किसान का प्रकार एवं भूमि विवरण" Font-Size="13px">--%>
        </center>
    <div id="div_print" width="920px">

        <div class="panel panel-success">
            <div class="panel-heading" style="font-family: Verdana; font-weight: bold; font-size: 18px; color: green;" align="center">
                &nbsp;<div class="panel-heading" style="font-family: Verdana; font-weight: bold; font-size:18px; color: green;" align="center"><asp:Image ID="Image2" runat="server" Height="62px" ImageUrl="~/Images/bihar_sarkar.png" Width="60px" />
                  &nbsp; कृषि इनपुट अनुदान योजना (2022-23)<br />
                  वर्ष 2022-23 के रबी मौसम में असामयिक वर्षापात/ओलावृष्टि/आंधी तूफान के कारण प्रतीवेदित 6 जिलों के 20 प्रखंडो एवं 299 पंचायतो में क्षतिग्रस्त फसलों के लिए कृषि इनपुट अनुदान हेतु ऑनलाइन&nbsp; आवेदन प्रपत्र<br />
                </div> 
    
            </div>
        </div>
        <asp:Panel ID="pnlBody" runat="server">
            <div class="panel panel-success">
                <div class="panel-heading">किसान का विवरण</div>
                <div class="panel-body" style="font-size: 12px;">
                    <center>
             <table id="tblsearchrecord"  width="80%"  class="table table-bordered"> <%--cellpadding="1" cellspacing="1"--%>

            <tr > 
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td >  आवेदन करने की तिथि : </td>
                <td style="text-align: left">  
                    <asp:Label ID="lblDate" runat="server" Font-Bold="True" Font-Size="13px" Font-Underline="True" ForeColor="Red"></asp:Label>
                </td>
            </tr>
                 <tr>
                     <td>
                         <asp:Label ID="lblregid" runat="server" Text="पंजीकरण संख्या/आवेदन संख्या :"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="lblregistrationid" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="Red"></asp:Label>
                         /
                         <asp:Label ID="lblApp" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="Red"></asp:Label>
                     </td>
                     <td>
                         <asp:Label ID="lblfrmrtype" runat="server" Text="कृषक श्रेणी :"></asp:Label>
                     </td>
                     <td style="text-align: left">
                         <asp:Label ID="lblfrmsrtype" runat="server" Font-Size="13px" ForeColor="Red"></asp:Label>
                     </td>
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
                <td  >
                    <asp:Label ID="lbldob" runat="server" Text="जन्म तिथि :"></asp:Label>
                </td>
                <td  >
                    <asp:Label ID="lblfrmrdob" runat="server" Font-Size="12px"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="lblage" runat="server" Text="वर्तमान उम्र :"></asp:Label>
                </td>
                <td  >
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
                    <asp:Label ID="lblVill" runat="server" Font-Size="13px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="lbladhr" runat="server" Text="आधार संख्या :"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="lblaadaar" runat="server" Font-Size="13px"></asp:Label>
                </td>
                <td >
                    <asp:Label ID="lblmbl" runat="server" Text="मोबाइल नंबर :"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:Label ID="lblmobile" runat="server" Font-Size="13px"></asp:Label>
                </td>
            </tr>
            <tr >
                <td>
                    <asp:Label ID="lblgnder" runat="server" Text="लिंग :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblgender" runat="server" Font-Size="13px"></asp:Label>
                </td>
                <td>
                  बैंक का नाम :
                </td>
                <td>
                   <asp:Label ID="lblBank" runat="server" Font-Size="13px"></asp:Label>
                </td>
            </tr>
                 <tr>
                     <td>अकाउंट नंबर :</td>
                     <td>
                         <asp:Label ID="lblAcIfc" runat="server" Font-Size="13px"></asp:Label>
                     </td>
                     <td>IFSC कोड :</td>
                     <td>
                         <asp:Label ID="lblIFSCCode" runat="server" Font-Size="13px"></asp:Label>
                     </td>
                 </tr>
               
        </table>
          </center>
                </div>
            </div>
            <%-- <asp:Panel ID="Panel1" runat="server" GroupingText="किसान का विवरण" Font-Names="Comic Sans MS" Font-Size="13px" Width="100%" Visible="false" >--%>

            <%-- </asp:Panel>--%>
            <div class="panel panel-success">
                <div class="panel-heading">परिवार का विवरण</div>
                <div class="panel-body" style="font-size: 12px;">
                 <asp:GridView ID="gvView" AutoGenerateColumns="False" runat="server" class="table table-bordered" DataKeyNames="Addhar">

                        <Columns>

                            <asp:TemplateField HeaderText="S.No." HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Registration ID" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblReg" runat="server" Text='<%#Eval("RegistrationID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Member Type" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblMember" runat="server" Text='<%#Eval("Member")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Member Status" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblMemberStatus" runat="server" Text='<%#Eval("Live")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Aadhaar No" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblAadhaarNo" runat="server" Text='<%#Eval("Addhar")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name_FamilyMember")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOB" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB_FamilyMember")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnDeleteFamilyMember" Text="Remove" runat="server" OnClick="btnDeleteFamilyMember_Click" class="btn btn-success" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                    </div> </div> 

            <div class="panel panel-success">
                <div class="panel-heading">किसान का प्रकार एवं भूमि विवरण</div>
                <div class="panel-body" style="font-size: 12px;">
                    <%-- <asp:Panel ID="Panel3" runat="server"  Visible="false"  GroupingText="किसान का प्रकार एवं भूमि विवरण" Font-Size="13px">--%>
                    <center>        <table>
            <tr>
                <td>खेती करने योग्य कुल जमीन: &nbsp;&nbsp;&nbsp;&nbsp; </td>
             
                
                <td>
                    <asp:UpdatePanel ID="upd11" runat="server" >
                        <ContentTemplate >
                    <asp:Label ID="ddlKisanType" runat="server" Width="150px" Font-Bold="True" Font-Size="13px" ForeColor="Red"></asp:Label>
                            </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            
                  
                        <td>क्षति का रकवा (डिसमिल में): </td>
                        <td>    <asp:Label ID="lblDicimil" runat="server" Width="150px" Font-Bold="True" Font-Size="13px" ForeColor="Red"></asp:Label></td>
                  
                   
                        <td>कुल अनुमानित अनुदान राशि : </td>
                        <td>    <asp:Label ID="lblAmount" runat="server" Width="150px" Font-Bold="True" Font-Size="13px" ForeColor="Red"></asp:Label></td>
                    </tr>
        </table>
              <br />
            <table>
              <tr>
                  <td>
                      <asp:UpdatePanel ID="upd1" runat="server">
            <ContentTemplate>
                <div class="panel panel-success">
      <div class="panel-heading">खेती करने योग्य भूमि का विवरण</div>
      <div class="panel-body" style="font-size:12px;">
          <asp:GridView ID="grd1" runat="server"  AutoGenerateColumns="false" class="table table-bordered" >
          
              
                                  

                                    
              <Columns>
                  <asp:TemplateField HeaderText="Sl. No." ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Names="Comic Sans MS" Font-Size="12px" ForeColor="Green" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                                </asp:TemplateField>
                   
                  
                   <asp:BoundField HeaderText="किसान का प्रकार" DataField="KisanType" HeaderStyle-Font-Size="12px"/>
                   <asp:BoundField HeaderText="फसल के नाम" DataField="CropType" HeaderStyle-Font-Size="12px"/>
                   <asp:BoundField HeaderText="जमीन का प्रकार" DataField="LandType" HeaderStyle-Font-Size="12px"/>
                   <asp:BoundField HeaderText="क्षति का कारण" DataField="AffectedType" HeaderStyle-Font-Size="12px"/>                 
                   <asp:BoundField HeaderText="थाना नंबर" DataField="thanano" HeaderStyle-Font-Size="12px"/>
                   <asp:BoundField HeaderText="खाता नंबर" DataField="Khatano" HeaderStyle-Font-Size="12px"/>
                   <asp:BoundField HeaderText="खेसरा नंबर" DataField="keshrano" HeaderStyle-Font-Size="12px" />
                   <asp:BoundField HeaderText="लगाये गए फसल का कुल रकवा" DataField="FarmingRakwa" HeaderStyle-Font-Size="12px"/>
                   <asp:BoundField HeaderText="क्षति का रकवा (डिसमिल में)" DataField="Affectedrakwa" HeaderStyle-Font-Size="12px"/>
                   <asp:BoundField HeaderText="अनुमानित अनुदान राशि" DataField="AnudanAmount" HeaderStyle-Font-Size="12px" />
                   <asp:BoundField HeaderText="1. बगल के किसान का नाम" DataField="FName" HeaderStyle-Font-Size="12px" />
                   <asp:BoundField HeaderText="2. बगल के किसान का नाम" DataField="SName" HeaderStyle-Font-Size="12px" />      

              </Columns>
          </asp:GridView>

            
          </div> </div> 
      <%--  </asp:Panel>
                --%>
                </ContentTemplate>
                          </asp:UpdatePanel>

                  </td>

              </tr>
               <%-- <tr>
                    <td>कुल हिस्सा का रकवा : <asp:TextBox ID="txtTotal" runat="server"  Enabled="false" ></asp:TextBox> </td>
                </tr>--%>
            </table>
              </center>

                    <%-- </asp:Panel>--%>
                </div>
            </div>


        </asp:Panel>
    </div>

    <asp:Panel ID="Panel1" runat="server" Visible="true">
        <div class="panel panel-success">
            <div class="panel-heading">आवश्यक जानकारी</div>
            <div class="panel-body" style="font-size: 14px;">
                <span style="color: rgb(51, 51, 51); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">1. आवेदन सबमिट होने के बाद यदि आवेदन में कोई भी त्रुटि हो तो ,त्रुटि का बदलाव 48 घंटे के अंदर कर लें, अन्यथा आवेदन उसी रूप में 48 घंटे के बाद संबन्धित कृषि समन्वयक को जांच हेतु अग्रसारित हो जायेगा और संबन्धित त्रुटि में कोई भी बदलाव संभव नहीं होगा | अंतिम तिथि के बाद किसी भी तरह का अपडेट नहीं किया जा सकता है | आवेदन के अंतिम तिथि के बाद 48 घंटे तक  का अपडेट मान्य नहीं है | </span><br style="box-sizing: border-box; color: rgb(51, 51, 51); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;" />
                <span style="color: rgb(51, 51, 51); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">2. यह योजना केवल 2 हेक्टेयर (494 डिसिमिल भूमि) तक&nbsp; के लिए देय है |</span><br style="box-sizing: border-box; color: rgb(51, 51, 51); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;" />
                <span style="color: rgb(51, 51, 51); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">3. कृपया आवेदन मे किए गए सुधार को पुनः जांच ले | एक बार सुधार अपडेट होने के पश्चात दुबारा सुधार संभव नहीं होगा |</span><br style="box-sizing: border-box; color: rgb(51, 51, 51); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;" />
                <span style="color: rgb(51, 51, 51); font-family: &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">4. किसान का प्रकार &quot;स्वयं&quot; होने की स्थिति मे भूमि के दस्तावेज़ के लिए (एलपीसी/जमीन रसीद/वंशावली/जमाबंदी/विक्रय पत्र),&quot;वास्तविक खेतिहर&quot; के स्थिति में स्व-घोषणा प्रमाण पत्र तथा &quot;वास्तविक खेतिहर + स्वयं &quot; के स्थिति में भूमि के दस्तावेज़ के साथ-साथ स्व-घोषणा पत्र संलग्न करना अनिवार्य है |</span></div>

        </div>
    </asp:Panel>

</asp:Content>


