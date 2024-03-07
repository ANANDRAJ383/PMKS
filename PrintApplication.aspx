<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true" CodeFile="PrintApplication.aspx.cs" Inherits="PrintApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
        <center>
 <input name="b_print" type="button" class="ipt" onclick="printdiv('div_print');" value=" Print ">
        </center> 
    <div id="div_print" width="920px">
<table width="100%">
        <tr>
            <td style="border-style: none none solid none; border-width: thin; border-color: #FF0000; font-family: Verdana; font-weight: bold; font-size: 15px; " align="center" class="auto-style1">
                <asp:Image ID="Image1" runat="server" Height="68px" ImageUrl="~/Images/biharlogo.png" Width="59px" />
                <br />
                कृषि विभाग <br />
                डीजल सब्सिडी (खरीफ 2022-23) अनुदान योजना</td>
        </tr>
    </table>

    
           <div class="panel panel-danger">
        <div class="panel-heading" style="font-size:13px; font-weight:bold;">किसान का विवरण</div>
        <div class="panel-body" style="font-size: 12px;">
        <table   class="table table-bordered">

                    <tr>
                        <td>
                            आवेदन संख्या :
                        </td>
                        <td>
                            <asp:Label ID="lblApplicationID" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblregid" runat="server" Text="पंजीकरण संख्या :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblregistrationid" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red" Text=""></asp:Label>
                        </td>
                        <td colspan="2">आवेदन की तिथि :</td>
                        <td>
                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblname" runat="server" Text="किसान का पूरा नाम :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblfulname" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblfthrname" runat="server" Text="पिता का नाम :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblfathername" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldob" runat="server" Text="जन्म तिथि :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblfrmrdob" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblage" runat="server" Text="वर्तमान उम्र (साल में):"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblttlage" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbldist" runat="server" Text="जिला :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbldistname" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblblk" runat="server" Text="प्रखण्ड. :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblblockname" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbladhr" runat="server" Text="आधार संख्या :"></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:Label ID="lblaadaar" runat="server" Text=""></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblmbl" runat="server" Text="मोबाइल नंबर :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblmobile" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblgnder" runat="server" Text="लिंग :"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblgender" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblfrmrtype" runat="server" Text="कृषक श्रेणी :"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblfrmsrtype" runat="server"></asp:Label>
                        </td>
                    </tr>
                    </table>
            </div> 
               </div> 
       
           <div class="panel panel-danger">
        <div class="panel-heading" style="font-size:13px; font-weight:bold;">भूमि एवं अनुदान विवरण</div>
        <div class="panel-body" style="font-size: 12px;">
           <table  class="table table-bordered">
                <tr>
                    <td>
मौसम:</td>
                    <td>
                        <asp:Label ID="lblSeason" runat="server" Text="खरीफ"></asp:Label>
                    </td>
                     <td>किसान का प्रकार: </td>
                     <td>
                         <asp:Label ID="lblFarmerType" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>फसल के नाम :	</td>
                    <td>
                        <asp:Label ID="lblCropName" runat="server"></asp:Label>
                    </td>
                     <td>कुल जमीन :	</td>
                     <td>
                         <asp:Label ID="lblLand" runat="server"></asp:Label>
                         (डिसमिल)</td>
                </tr>
                <tr>
                    <td><span style="color: rgb(51, 51, 51); font-family: &quot;Comic Sans MS&quot;; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: -webkit-right; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">कुल सिंचित जमीन का रकवा<span>&nbsp;: </span></span></td>
                    <td>
                        <asp:Label ID="lbltotalLand" runat="server"></asp:Label>(डिसमिल)
                    </td>
                    <td><b style="color: rgb(51, 51, 51); font-family: &quot;Comic Sans MS&quot;; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: -webkit-center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">कुल अनुदेय राशि:</b><span style="color: rgb(51, 51, 51); font-family: 'Comic Sans MS'; font-size: 13px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: -webkit-center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none; background-color: rgb(255, 255, 255)">&nbsp;</span></td>
                    <td>
                        <asp:Label ID="lblSubsidyAmnt" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>रसीद संख्या एवं पेट्रोल पंप का नाम </td>
                    <td>
                        <asp:Label ID="lblPetrolName" runat="server"></asp:Label>
                    </td>
                    <td>क्रय किये गए डीजल का मूल्य:</td>
                    <td>
                        <asp:Label ID="lblDieselRate" runat="server"></asp:Label>
                    </td>
                </tr>
              
                </table>
            </div> </div> 
              
            <center>

             <asp:Panel ID="pnl1" runat="server" >
                   <div class="panel panel-danger">
        <div class="panel-heading" style="font-size:13px; font-weight:bold;">प्रभावित जमीन का विवरण (स्वयं)</div>
        <div class="panel-body" style="font-size: 12px;">
                                        <table  class="table table-bordered">
                                            <tr>
                                                <td class="auto-style1">
                                                    <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="false" Font-Size="12px" HeaderStyle-Font-Size="10px" >
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl. No." ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Names="Comic Sans MS" Font-Size="12px" ForeColor="Green" />
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" Font-Size="12px" />
                                                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                                                            </asp:TemplateField>
                                                          
                                                            <asp:BoundField DataField="KhataNo" HeaderText="खाता नंबर" HeaderStyle-Font-Size="12px" />
                                                              <asp:BoundField DataField="KhesraNo" HeaderText="खेसरा नंबर"  HeaderStyle-Font-Size="12px"/>
                                                              <asp:BoundField DataField="ThanaNo" HeaderText="थाना नंबर"  HeaderStyle-Font-Size="12px"/>
                                                              <asp:BoundField DataField="Rakba" HeaderText="कुल रकवा (डिसमिल में)"  HeaderStyle-Font-Size="12px"/>
                                                              <asp:BoundField DataField="Witness1" HeaderText="1. बगल के किसान का नाम "  HeaderStyle-Font-Size="12px"/>
                                                              <asp:BoundField DataField="Witness2" HeaderText="2. बगल के किसान का नाम"  HeaderStyle-Font-Size="12px"/>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
            </div> </div> 
                           </asp:Panel>         
                 <asp:Panel ID="pnl2" runat="server" >
                   <div class="panel panel-danger">
        <div class="panel-heading" style="font-size:13px; font-weight:bold;">प्रभावित जमीन का विवरण (वास्तविक जोतदार/खेतिहर)</div>
        <div class="panel-body" style="font-size: 12px;">
                                        <table  class="table table-bordered">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="false" Font-Size="12px" HeaderStyle-Font-Size="12px" >
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl. No." ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Names="Comic Sans MS" Font-Size="12px" ForeColor="Green" />
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%"  Font-Size="12px"/>
                                                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                                                            </asp:TemplateField>
                                                         <asp:BoundField DataField="KhesraNo" HeaderText="खेसरा नंबर"  HeaderStyle-Font-Size="12px"/>
                                                              <asp:BoundField DataField="ThanaNo" HeaderText="थाना नंबर"  HeaderStyle-Font-Size="12px"/>
                                                              <asp:BoundField DataField="Rakba" HeaderText="कुल रकवा (डिसमिल में)"  HeaderStyle-Font-Size="12px"/>
                                                              <asp:BoundField DataField="Witness1" HeaderText="1. बगल के किसान का नाम "  HeaderStyle-Font-Size="12px"/>
                                                              <asp:BoundField DataField="Witness2" HeaderText="2. बगल के किसान का नाम"  HeaderStyle-Font-Size="12px"/>
                                                            
                                                          
                                                            
                                                                                                 </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                             
                                           
                                             
                                        </table>
            </div> </div> 
                                 </asp:Panel>   
                <table>
                     <tr>
                                                 <td align="left"><asp:PlaceHolder ID="plBarCode" runat="server" /></td>
                                            </tr>
                                            
                                            <tr>
                                               
                                                <td style="text-align: right; font-size: large; font-weight: bold; font-style: italic;">कृषि विभाग, बिहार सरकार&nbsp; </td>
                                            </tr>
                </table> </center>
                
        </div> 
</asp:Content>

