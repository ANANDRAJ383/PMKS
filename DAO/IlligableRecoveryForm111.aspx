<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="IlligableRecoveryForm111.aspx.cs" Inherits="IlligableRecoveryForm" EnableEventValidation="false"%>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   
<div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">पी० एम० किसान (अयोग्य किसान)<br />भुगतान वापस करने हेतु विपत्र </div><br />
    

    <div class="row">
        <div class="input-group mb-3 col-lg-4">
            <label>Block :</label>
            <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

        <div class="input-group mb-3 col-lg-4">
            <label>Panchayat :</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select"
                 ValidationGroup="s">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

         <div class="input-group mb-3 col-lg-4">
             &nbsp;
  <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click"  /> 
</div>
        
        <div class="input-group mb-3 col-lg-4">
             &nbsp;
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    </div>

<div class="form-row">
    </div>

        <div >
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                AllowPaging="true" PageSize="10" CssClass="table table-bordered table-striped"
            DataKeyNames="DBTRegistrationId" AutoGenerateColumns="false"   onpageindexchanging="gvdata_PageIndexChanging" Font-Size="10px" >
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" Text="Select all" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkDetails" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:BoundField DataField="BlockName" HeaderText="Block Name" />--%>
                <asp:BoundField DataField="RevenueVillageName" HeaderText="Village Name" />
                <asp:TemplateField HeaderText="Registration Id(DBT)">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("DBTRegistrationId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Registration Id(PMKS)">
                    <ItemTemplate>
                        <asp:Label ID="lblreg_no" runat="server" Text='<%#Eval("reg_no") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Farmer_Name" HeaderText="Applicant Name" />
                <asp:BoundField DataField="Father_Name" HeaderText="Father/Husband Name" />
                <asp:TemplateField HeaderText="Account No (PMKisan)">
                    <ItemTemplate>
                        
                        <%#Eval("AccountNo")%>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:TemplateField HeaderText="Bank Detail (DBT)">
                    <ItemTemplate>
                        <strong>Account Number: </strong>
                        <%#Eval("DBTAccountNo")%><br />
                        <strong>IFSC Code: </strong>
                        <%#Eval("DBTIFSC")%><br />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField DataField="NoOfInstallments" HeaderText="Installment" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" />
               <asp:TemplateField HeaderText="Amount Return">
                    <ItemTemplate>
                        <asp:TextBox ID="txtAmountReturn" runat="server" onkeypress="return Validate();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Return Mode">
                    <ItemTemplate>
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="75px" CssClass="form-select">
                                <asp:ListItem>Cash</asp:ListItem>
                                <asp:ListItem>Check</asp:ListItem>
                                <asp:ListItem>Online</asp:ListItem>
                            </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transaction Date">
                    <ItemTemplate>
                       <asp:TextBox ID="txttransactiondate" runat="server" ReadOnly="true"></asp:TextBox>
                <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txttransactiondate"   From-Date="06-01-2022" To-Today="true" />
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:TemplateField HeaderText="UTR Number">
                    <ItemTemplate>
                        <asp:TextBox ID="txtUTRNumber" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnViewDetail" Text="Select" runat="server" OnClick="btnViewDetail_Click"  class="btn btn-success"/>
                </ItemTemplate>
            </asp:TemplateField>
                
            </Columns>
            <RowStyle />
        </asp:GridView>
                               </ContentTemplate>
                        </asp:UpdatePanel> 
        </div>
 <table class="table-bordered table-responsive table table-striped " style="width: 100%; background-color :aqua" align="center" id="tblBulk" runat="server" visible="false" >
        
     

        <tr>
            <td ><asp:CheckBox ID="CheckBox2" runat="server"  /> &nbsp;&nbsp;</td>
            <td>उपरोक्त जानकारी सही है एवं सत्यापन किया जा सकता है । ** Upload file only PDF/pdf </td>
            <td >Upload letter:  <asp:FileUpload ID="flu" runat="server" /> </td>
            <td ><asp:Button ID="bnSave" runat="server" Text="सत्यापित एवं सुरक्षित करें"   class="btn btn-success" OnClick="bnSave_Click" Height="69px"  /> </td>
        </tr>
    </table>
</asp:Content>

