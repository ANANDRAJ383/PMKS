<%@ Page Title="" Language="C#" MasterPageFile="MasterPagePublic.master" AutoEventWireup="true" CodeFile="Print_PMKisanYojna.aspx.cs" Inherits="Print_PMKisan" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
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
   <center>
    <table class="table-bordered table-responsive table table-striped " style="width:100%">
            <tr style="width:100%">
<td>
    

    <asp:RadioButtonList ID="rbApp" runat="server"  RepeatDirection="Horizontal" Width="100%" >
        <asp:ListItem Value="N">नए आवेदन</asp:ListItem>
        <asp:ListItem Value="RE">पुनर्विचार आवेदन</asp:ListItem>
        <asp:ListItem Value="RERE">पुनर्विचार मे रद आवेदन पर पुनः विचार</asp:ListItem>
    </asp:RadioButtonList>
</td>
                <td>पंजीकरण संख्या:</td>
                <td><asp:TextBox ID="txtRno" runat="server" ></asp:TextBox></td>
                <td>
                    <asp:Button ID="btnShow" runat="server" Text="Show" class="btn btn-danger" OnClick="btnShow_Click" /></td>
                <td><button type="button" class="btn btn-danger" onclick="printdiv('div_print');">Print <span class="badge">1</span></button> </td>
            </tr>
        </table>
    
        
            

        </center> 
    <div id="div_print" width="920px">

    
    <asp:Panel ID="pnlBody" runat="server" >
        <div class="panel panel-success">
        <div class="panel-heading" style="font-family: Verdana; font-weight: bold; font-size: 18px; color: green;" align="center">
            <asp:Image ID="Image1" runat="server" Height="62px" ImageUrl="~/Images/EmblemIndia.svg.png" Width="60px" />
&nbsp;Pradhan Mantri KIsan SAmman Nidhi Yojna(PM-KISAN)<asp:Image ID="Image2" runat="server" Height="62px" ImageUrl="~/Images/bihar_sarkar.png" Width="60px" />
        </div>
    </div>
        <div class="panel panel-success">
            <div class="panel-heading">किसान का विवरण</div>
            <div class="panel-body" style="font-size: 12px;">
                <center>
             <table id="tblsearchrecord"  width="80%"  class="table table-bordered"> <%--cellpadding="1" cellspacing="1"--%>

            <tr > 
                <td>
                    <asp:Label ID="lblregid" runat="server" Text="पंजीकरण संख्या :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblregistrationid" runat="server" Font-Bold="True" Font-Size="13px" ForeColor="Red" ></asp:Label>
                </td>
                <td >  <asp:Label ID="lblfrmrtype" runat="server" Text="कृषक श्रेणी :"></asp:Label></td>
                <td style="text-align: left">  <asp:Label ID="lblfrmsrtype" runat="server" Font-Size="13px" ForeColor="Red"></asp:Label></td>
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
                <td colspan="2">
                   <asp:Label ID="lblBank" runat="server" Font-Size="13px"></asp:Label>
                </td>
            </tr>
                 <tr>
                     <td>अकाउंट नंबर :</td>
                     <td>
                         <asp:Label ID="lblAcIfc" runat="server" Font-Size="13px"></asp:Label>
                     </td>
                     <td>IFSC कोड :</td>
                     <td colspan="2">
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
            <div class="panel-heading">किसान का प्रकार एवं भूमि विवरण</div>
            <div class="panel-body" style="font-size: 12px;">
                <%-- <asp:Panel ID="Panel3" runat="server"  Visible="false"  GroupingText="किसान का प्रकार एवं भूमि विवरण" Font-Size="13px">--%>
                <center>        <table>
            <tr>
                <td>किसान का प्रकार:&nbsp;&nbsp;&nbsp;&nbsp; </td>
             
                
                <td>
                    <asp:Label ID="ddlKisanType" runat="server" Width="150px" Font-Bold="True" Font-Size="13px" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
                     <div class="panel-heading">खेती करने योग्य भूमि का विवरण</div>
      <div class="panel-body" style="font-size:12px;">
            <asp:GridView ID="grdLand" runat="server"  AutoGenerateColumns="false" CssClass="table table-bordered  table-striped" >
              <Columns>
                  <asp:TemplateField HeaderText="Sl. No." ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Names="Comic Sans MS" Font-Size="12px" ForeColor="Green" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                                </asp:TemplateField>
                  <asp:BoundField HeaderText="जिला का नाम" DataField="DistName" HeaderStyle-Font-Size="12px"/>
                   <asp:BoundField HeaderText="राजस्व अंचल" DataField="BlockName" HeaderStyle-Font-Size="12px" />
                  
                   <asp:BoundField HeaderText="खाता नंबर" DataField="Khatano" HeaderStyle-Font-Size="12px" />
                  <asp:BoundField HeaderText="खेसरा नंबर" DataField="keshrano" HeaderStyle-Font-Size="12px"/>
                   <asp:BoundField HeaderText="थाना नंबर" DataField="thanano" HeaderStyle-Font-Size="12px" Visible="false"/>
                   <asp:BoundField HeaderText="रकवा" DataField="rakwa" HeaderStyle-Font-Size="12px" />
                   <asp:BoundField HeaderText="फार्मिंग रकवा" DataField="FarmingRakwa" HeaderStyle-Font-Size="12px" />
                   <asp:BoundField HeaderText="Entry Date" DataField="EntryDate" HeaderStyle-Font-Size="12px" />
              </Columns>
          </asp:GridView>

            
          </div> </div> 
               <div class="panel panel-success">
      <div class="panel-heading">परिवार का विवरण</div>
      <div class="panel-body" style="font-size:12px;">
          <asp:GridView ID="gvFamilyView" AutoGenerateColumns="False" runat="server" class="table table-bordered" >
        
        <Columns>
       
            <asp:TemplateField HeaderText="S.No.">
                <ItemTemplate>
                    <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>' />
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Registration ID">
                <ItemTemplate>               
                    <asp:Label ID="lblReg" runat="server" Text='<%#Eval("Registration_ID")%>' />               
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Member Type">
                <ItemTemplate>               
                    <asp:Label ID="lblMember" runat="server" Text='<%#Eval("Relation")%>' />               
                </ItemTemplate>
            </asp:TemplateField>
           
           <asp:TemplateField HeaderText="Member Status">
                <ItemTemplate>               
                    <asp:Label ID="lblMemberStatus" runat="server" Text='<%#Eval("RelativeLive")%>' />               
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

          </div> </div> 
              </center>

              
            </div>
        </div>

         <div class="panel panel-success">
            <div class="panel-heading">भूमि का दस्तावेज (150KB in PDF Format Only) </div>
            <div class="panel-body" style="font-size: 12px;">
                <center>   
                    <table class="table table-bordered">
                      <tr>
                          <td align="center"  >
                                 <button type="button" class="btn btn-danger">भूमि दस्तावेज सफलतापूर्वक अपलोड <span class="badge">1</span></button>    
                            
                          </td>
                      </tr>
                    </table>    
                    </center>
                </div>
             </div>
        <table width="100%">
            <tr>
                <td align ="left">

<%--  <asp:Panel ID="Panel2" runat="server"  GroupingText="शपथ पत्र" Font-Size="13px" Visible="false" >--%>
 <div class="panel panel-success">
      <div class="panel-heading">शपथ पत्र</div>
      <div class="panel-body" style="font-size:12px;">
          <table>
              <tr>
                  <td valign="top" colspan="2">
    <div class="panel-heading">आवेदन की शर्तें </div>
      <div class="panel-body" style="font-size:12px;">
        <ul align="left">
            <li>मै प्रमाणित करता/करती हूँ कि मेरे परिवार (पति, पत्नी और अवयस्क सदस्य) में:  <br />
                1. परिवार के हिस्से का कुल खेती योग्य रकवा 2 हेक्टेयर/5 एकड़/494.82 डिसिमिल से ज्यादा नहीं है|<br />
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
           </div> 
                </div> 

                  </td>  

              </tr>
               <tr>
                   <td valign="top">
                       <asp:CheckBox ID="CheckBox1" runat="server"   Checked="true" Enabled="false" /> &nbsp;&nbsp;
                   </td>
                   <td valign="top">मैं/परिवार उपर्युक्त बिन्दुओ को पढ़कर सुनिश्चित कर लिया हूँ/है कि मैं/परिवार उपर्युक्त शर्तो का पालन करता/करती है/हूँ |
                       <asp:LinkButton ID="lnk" runat="server" class="btn btn-warning" Text="क्लिक करें ..." Visible="false"></asp:LinkButton>
                   </td>
                   <%--OnClick="lnk_Click"--%>
              </tr>
               <tr>

                  <td valign="top" >
                        <asp:CheckBox ID="CheckBox2" runat="server" Checked="true" Enabled="false"  /> &nbsp;&nbsp;
                  </td>
                   <td valign="top" >
                        मेरे द्वारा दिया गया उपर्युक्त विवरण सही है| विवरण गलत होने की स्थिति में आवेदन रद्द होने की जिम्मेवारी मेरी होगी| मुझसे अनुदान राशि वसूल की जा सकती है तथा मेरे ऊपर दंडात्मक कार्रवाई की जा सकती है|  
                   </td>

              </tr>
             <tr>

                  <td valign="top" >
                        <asp:CheckBox ID="CheckBox3" runat="server" Checked="true" Enabled="false"  /> &nbsp;&nbsp;
                  </td>
                   <td valign="top" >
                      मैं अपना आधार नंबर एवं अन्य सूचनायें इस योजना में पात्रता के सत्यापन हेतु उपयोग की अनुमति देता/देती हूँ | 
                   </td>

              </tr>
          </table>
         
    </asp:Panel>
    </div>


</asp:Content>
