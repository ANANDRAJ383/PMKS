<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="ITR_ReturnRecoveryForm.aspx.cs" Inherits="DAO_ITR_ReturnRecoveryForm" EnableEventValidation="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="JavaScript" type="text/javascript">
          function onlyNumbers(evt) {
              var e = event || evt;
              var charCode = e.which || e.keyCode;
              if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                  alert('Enter Numbers Only');
                  return false;
              }
              return true;
          } 
    </script>


    <style>
        .mydatagrid
{
width: 100%;
border: solid 2px black;
min-width: 100%;
}
.header
{
background-color: #2a5197;
font-family: Arial;
color: White;
border: none 0px transparent;
height: 25px;
text-align: center;
font-size: 14px;
}

.rows
{    
background-color: #fff;
font-family: Arial;
font-size: 14px;
color: #000;
min-height: 25px;
text-align: left;
border:  0px ;
}
/*.rows:hover
{
background-color: #ff8000;
font-family: Arial;
color: #fff;
text-align: left;
}*/
.selectedrow
{
background-color: #ff8000;
font-family: Arial;
color: #fff;
font-weight: bold;
text-align: left;
}
.mydatagrid a /** FOR THE PAGING ICONS **/
{
background-color: Transparent;
padding: 5px 5px 5px 5px;

text-decoration: none;
font-weight: bold;
}


.mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
{
background-color: #c9c9c9;
color: #000;
padding: 5px 5px 5px 5px;
}
.pager
{
background-color: #646464;
font-family: Arial;
color: White;
height: 30px;
text-align: left;
}

.mydatagrid td
{
padding: 5px;
}
.mydatagrid th
{
padding: 5px;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   
<div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">पी० एम० किसान (अयोग्य आयकर दाता किसान)<br />लाभुकों से वापस की गई राशि विवरण की प्रविष्टि करने हेतु </div><br />
   

    <div class="row">
        <div class="input-group mb-3 col-lg-4">
            <label>Block :</label>
            <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

        <div class="input-group mb-3 col-lg-4">
            <label>Panchayat :</label>
            <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select"
                 ValidationGroup="s">
            </asp:DropDownList> 
        </div>

         <div class="input-group mb-3 col-lg-4">
             &nbsp;
  <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click"  /> 
</div>
        <table class="table-bordered  table table-striped " style="width: 40%;">
         <tr>
             <td>Search By Registration Id</td>             
             <td><asp:TextBox ID="txtRegId" runat="server" class="form-control" placeholder="Registration Id" ></asp:TextBox></td>
             <td><asp:Button ID="btnView" class="btn btn-primary b-btn" runat="server" Text="View" OnClick="btnView_Click" ></asp:Button></td>
         </tr>
     </table>
        <div class="input-group mb-3 col-lg-4" align="center">
             &nbsp;
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    </div>

<div class="form-row">
    </div>

        <div >
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                AllowPaging="true" PageSize="30" CssClass="mydatagrid" PagerStyle-CssClass="pager"
 HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
            DataKeyNames="RegistrationId,reg_no" AutoGenerateColumns="false"   onpageindexchanging="gvdata_PageIndexChanging" Font-Size="14px">
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" Text="सभी का चयन करे" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkDetails" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="क्रम संख्या">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:BoundField DataField="BlockName" HeaderText="Block Name" />--%>
                <asp:TemplateField HeaderText="पता का विवरण">
                    <ItemTemplate>
                        <strong>जिला: </strong>
                        <%#Eval("DistrictName")%><br /><br />
                        <strong>प्रखंड: </strong>
                        <%#Eval("BlockName")%><br /><br />
                        <strong>पंचायत: </strong>
                        <%#Eval("PancahyatName")%><br /><br />
                        <strong>ग्राम: </strong>
                        <%#Eval("RevenueVillageName")%><br />                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पंजीकरण का विवरण">
                    <ItemTemplate>
                        <strong>पंजीकरण संख्या (DBT): </strong><br />
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("RegistrationId") %>'></asp:Label><br /><br /><br />
                        <strong>पंजीकरण संख्या (PMKS): </strong><br />
                        <asp:Label ID="lblreg_no" runat="server" Text='<%#Eval("reg_no") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="लाभार्थी का विवरण">
                    <ItemTemplate>
                        <strong>किसान का नाम: </strong>
                        <%#Eval("Farmer_Name")%><br /><br />
                        <strong>पिता/पति का नाम: </strong>
                        <%#Eval("Father_Name")%><br /><br />
                        <strong>लिंग: </strong>
                        <%#Eval("Gender")%><br />                        
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:BoundField DataField="Farmer_Name" HeaderText="किसान का नाम" />
                <asp:BoundField DataField="Father_Name" HeaderText="पिता/पति का नाम" />--%>
                <asp:TemplateField HeaderText="भुगतान का विवरण">
                    <ItemTemplate>
                        <strong>खाता संख्या: </strong>
                        <%#Eval("AccountNo")%><br /><br />
                        <strong>किस्त: </strong>
                        <%#Eval("NoOfInstallments")%><br /><br />
                        <strong>वापसी रकम: </strong>
                        <%#Eval("AmountReturn")%><br />                        
                    </ItemTemplate>
                </asp:TemplateField>
              
               <asp:TemplateField HeaderText="वापस करने का विवरण" Visible="false">
                    <ItemTemplate>
                        <strong>तरीका: </strong>
                            <%#Eval("PaymentMode")%><br /><br />
                        <strong>यू०टी०र नंबर (Trans No): </strong>
                            <asp:TextBox ID="txtTRNo" runat="server" Text=<%#Eval("TransactionNo")%>></asp:TextBox><br />
                        <strong>यू०टी०र दिनांक (Trans Date): </strong>
                        <asp:TextBox ID="txtTRDate" runat="server" Text=<%#Eval("TranDate")%>></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar1" runat="server" AutoPostBack="True" 
                    Control="txtTRDate" Format="dd mmm yyyy" To-Today="true" />
                            
                    </ItemTemplate>
                </asp:TemplateField>
               <%--  <asp:TemplateField HeaderText="यूटीर (Transaction No) नंबर">
                    <ItemTemplate>
                       <asp:TextBox ID="txtRemarks" runat="server" Text=<%#Eval("TransactionNo")%>></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transaction Date">
                    <ItemTemplate>
                      <asp:TextBox ID="txtTRDate" runat="server" Text=<%#Eval("TranDate")%>></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>--%>
               <asp:TemplateField HeaderText="दस्तावेज़">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("TranSacAttachment")%>'
                            Target="_blank">View</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="भुगतान वापसी खाता" Visible="false">
                    <ItemTemplate>
                        <asp:RadioButtonList ID="ddlPaymentType" runat="server">
                            <asp:ListItem Value="1">भारत कोष</asp:ListItem>
                        <asp:ListItem Value="2">राज्य कोष खाता संख्या (40903138323, IFSC: SBIN0006379)</asp:ListItem>
                        <asp:ListItem Text="SLBC/BANK द्वारा वसूली" Value="3"></asp:ListItem>
                            <asp:ListItem Value="4">प्रसानिक मद-खाता संख्या (38269533475, IFSC: SBIN0006379)</asp:ListItem>
                    <asp:ListItem Text="अन्य कारणों से अयोग्य घोषित किसान खाता संख्या (40903140467, IFSC: SBIN0006379)" Value="5"></asp:ListItem>
                   
                        </asp:RadioButtonList>
                        
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                <ItemTemplate>
                    <asp:Button ID="btnViewDetail" Text="Select" runat="server" OnClick="btnViewDetail_Click"  class="btn btn-success"/>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <RowStyle />
        </asp:GridView>
                              
        </div>
</asp:Content>

