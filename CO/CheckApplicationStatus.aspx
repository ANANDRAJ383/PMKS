<%@ Page Title="" Language="C#" MasterPageFile="COMasterPage.master" AutoEventWireup="true" CodeFile="CheckApplicationStatus.aspx.cs" Inherits="CheckApplicationStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Application Status </div><br />
    <table class="table-bordered  table table-striped ">

        <tr >
           
            <td >
                  <center>
                      <asp:Image ID="imgbiharlogo" runat="server" ImageUrl="~/Images/biharlogo.png" />
                      <br />
                <asp:Label ID="lbldisplay" runat="server" Text="कृषि विभाग, बिहार सरकार" Font-Size="XX-Large" Font-Bold="True" Font-Underline="False"></asp:Label>
                      <br />
                      <asp:Label ID="Label4" runat="server" Text="प्रधानमंत्री किसान सम्मान निधि योजना"  Font-Size="Large"   Font-Bold="True" Font-Underline="True" ></asp:Label>
                       </center>
            </td>
        </tr>
        </table>
<table class="table-bordered  table table-striped ">

        <tr>
            <td >

                   <td>Enter Registeration Id </td>

                <td>
                    <asp:TextBox ID="txtRegId" runat="server" MaxLength="13" class="form-control" placeholder="Enter Registeration Id"></asp:TextBox>

                </td>

                <td >&nbsp;&nbsp;
                    <asp:Button ID="btnGet" runat="server" Text="Search" class="btn btn-success" OnClick="btnGet_Click" />
                </td>
        </tr>
    </table>
     <div >
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                AllowPaging="false" PageSize="10" CssClass="table table-bordered  table-striped" AutoGenerateColumns="false" 
             Font-Size="16px" >
            <Columns>
             
                 <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Application Type" >
           
            <ItemTemplate>
                <asp:Label ID="lblatype" runat="server" Text='<%# Bind("atype") %>' Font-Bold="True" Font-Size="11" ForeColor="red"></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
                <asp:TemplateField HeaderText="Applicant Name" >
           
            <ItemTemplate>
                <asp:Label ID="lblMsg" runat="server" Text='<%# Bind("ApplicantName") %>' Font-Bold="True" Font-Size="11" ForeColor="red"></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
 <asp:TemplateField HeaderText="Status" >
           
            <ItemTemplate>
                <asp:Label ID="lblMsg" runat="server" Text='<%# Bind("C_Status") %>' Font-Bold="True" Font-Size="11" ForeColor="red"></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
            </Columns>
            <RowStyle />
        </asp:GridView>
        </div>

    <div>

         <table class="table-bordered  table table-striped " style="width: 100%;" id="tblRemarks" runat="server" visible="false">
        <tr>
            <td colspan="2" style="font-size: large">अभियुक्ति</td>
        </tr>
        <tr id="td1" runat="server">
            <td >आवेदक के ऑनलाइन आवेदन में जमीन दस्तावेज संलग्न पाया गया,जमीन का रकवा शून्य (0)  है एवं जमीन दूसरे जिला/प्रखण्ड/पंचायत का  है | </td>
              <td> <asp:Label ID="lbl1" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red" ></asp:Label></td>
        </tr>
        <tr id="td2" runat="server">
            <td >आवेदक किसान के अलावा कोई अन्य परिवार के सदस्य योजना का लाभ ले रहे हैं ?</td>
              <td> <asp:Label ID="lbl2" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red"></asp:Label></td>
        </tr>
        <tr id="td3" runat="server">
            <td >आवेदन में दिए गए डाटा के अनुसार परिवार के सदस्य जीवित/मृत हैं इसकी पुष्टि किया गया एवं डाटा में कोई अंतर पाया गया |</td>
               <td> <asp:Label ID="lbl3" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red"></asp:Label></td>
        </tr>
          <tr id="td4" runat="server">
            <td >आवेदन में दिए गए किसान के परिवार की विवरणी का सत्यापन यानि (पिता, माता, पति, पत्नी एवं अवयस्क बच्चे) का मिलान आवेदक के आधार एवं परिवार के सदस्य के आधार विवरणी से कर लिया गया |</td>
               <td> <asp:Label ID="lbl4" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red"></asp:Label></td>
        </tr>
          <tr id="td5" runat="server">
            <td >आवेदन में दिये गये बैंक खाता का मिलान आवेदक के बैंक पासबुक से किया गया | साथ ही साथ बैंक खाता आधार एवं NPCI से लिंक है कि नहीं इसकी पुष्टि यथा संभव (https://resident.uidai.gov.in/bank-mapper) से किया गया | डाटा में कोई अंतर है|</td>
              <td> <asp:Label ID="lbl5" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red"></asp:Label></td>
        </tr>
          <tr id="td6" runat="server">
            <td >आवेदक किसान द्वारा ऑनलाइन आवेदन के समय संलग्न किये गए जमीन सम्बंधित कागजात में किसान के नाम का मिलान किया गया | डाटा में कोई अंतर है|</td>
              <td> <asp:Label ID="lbl6" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red"></asp:Label></td>
        </tr>
          <tr id="td7" runat="server">
            <td >आवेदक किसान परिवार रैयत नहीं है एवं किसान के पास खेती करने योग्य भूमि है |</td>
             <td> <asp:Label ID="lbl7" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red"></asp:Label></td>
        </tr>
        <tr id="td8" runat="server">
            <td >आवेदक का जमीन टोपो लैंड/वासगीत पर्चा/सरकारी भूमि या आबादी की भूमि  है|</td>
               <td> <asp:Label ID="lbl8" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red"></asp:Label></td>
        </tr>
        <tr id="td9" runat="server">
            <td >आवेदक योजना के अपात्रता की शर्तों में आते हैं एवं योजना की पात्रता नहीं रखते हैं|</td>
              <td> <asp:Label ID="lbl9" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red"></asp:Label></td>
        </tr>
        
       
    </table>

 <table class="table-bordered  table table-striped " style="width: 100%;" id="tblCORemarks" runat="server" visible="false">
        <tr>
            <td colspan="2">अभियुक्ति</td>
        </tr>
        <tr id="Tr1" runat="server">
            <td >आवेदक किसान का जमीन दस्तावेज एवं जमीन विवरण सही नहीं है | </td>
              <td> <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red" ></asp:Label></td>
        </tr>
        <tr id="Tr2" runat="server">
            <td >जमीन दस्तावेज अद्यतन यानि वर्ष (2018-19-20-21-22) का नहीं हैं |</td>
              <td> <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red"></asp:Label></td>
        </tr>
        <tr id="Tr3" runat="server">
            <td >आवेदन पर अनुमोदन नहीं दिया जा सकता है|</td>
               <td> <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="10" ForeColor="red"></asp:Label></td>
        </tr>
         
    </table>
        
    </div>
     <div id="idland" runat="server" visible="false">
        <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">खेती करने योग्य भूमि का विवरण</div>
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
                   <asp:BoundField HeaderText="फार्मिंग रकवा" DataField="FarmingRakwa" HeaderStyle-Font-Size="12px" Visible="false"/>
		<asp:BoundField DataField="OwnerName" HeaderText="मालिक का नाम" />
              </Columns>
          </asp:GridView>
    </div>
</asp:Content>

