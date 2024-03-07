<%@ Page Title="" Language="C#" MasterPageFile="COMasterPage.master" AutoEventWireup="true" CodeFile="MutationDateEntryRural.aspx.cs" Inherits="CO_MutationDateVerification" EnableEventValidation="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   
<div style="font-family: Cambria; font-size: 22px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Entry Mutation Date & Verify Application Rural Data (Return from GOI)</div><br />
    

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
       
            <table class="table-bordered  table table-striped " style="width: 40%; margin-left:10px;">
         <tr>
             <td>Search By Registration Id</td>             
             <td><asp:TextBox ID="txtRegId" runat="server" class="form-control" placeholder="Registration Id" ></asp:TextBox></td>
             <td><asp:Button ID="btnView" class="btn btn-primary b-btn" runat="server" Text="View" OnClick="btnView_Click" ></asp:Button></td>
         </tr>
     </table>   
       
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
                 CssClass="table table-bordered table-striped"
            DataKeyNames="Registration_ID" AutoGenerateColumns="false"    Font-Size="12px" >
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" Text="Select all" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" Enabled="false"/>
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
                <asp:BoundField DataField="blockname" HeaderText="Block Name" />
                <asp:BoundField DataField="panchayatname" HeaderText="Panchayat Name" />
                <asp:BoundField DataField="VillageName" HeaderText="Village Name" />
                <asp:TemplateField HeaderText="Registration Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("Registration_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                <asp:BoundField DataField="Father_Husband_Name" HeaderText="Father/Husband Name" />
                
                <asp:TemplateField HeaderText="Mutation Date of Land (दाखिल - खारिज की तिथि 01/02/2019 से पहले (योजना की मार्गदर्शिका के अनुसार)) " HeaderStyle-ForeColor="#FF3300" Visible="false">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMutationDate" runat="server" Text='<%#Eval("MutationDate") %>'></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar1" runat="server" AutoPostBack="True" 
                    Control="txtMutationDate" Format="dd mmm yyyy" To-Date="02-01-2019"  />
                    </ItemTemplate>
                </asp:TemplateField>
              <asp:TemplateField HeaderText="Mutation Date of Land(दाखिल-खारिज की तिथि 01/02/2019 से पहले )" HeaderStyle-ForeColor="#FF3300">
                <ItemTemplate>
                    <asp:Button ID="btnViewDetail1" Text="2019 से पहले के लिए यहां क्लिक करें" runat="server"   OnClick="btnViewDetailBefore_Click" class="btn btn-success"  />
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Mutation Date of Land(दाखिल-खारिज की तिथि 01/02/2019 के बाद )"  HeaderStyle-ForeColor="#FF3300">
                <ItemTemplate>
                    <asp:Button ID="btnViewDetail" Text="2019 के बाद के लिए यहां क्लिक करें"  runat="server" OnClick="btnViewDetail_Click"  class="btn btn-success" />
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Document">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("LandPath")%>'
                            Target="_blank">View</asp:HyperLink>
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
            <td>उपरोक्त जानकारी सही है एवं सत्यापन किया जा सकता है । </td>
            <td ><asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal" Width="100%" Height="68px">
                        <asp:ListItem Value="1">Accept</asp:ListItem>
                        <asp:ListItem Value="2">Reject</asp:ListItem>
                    </asp:RadioButtonList></td>
            <td ><asp:Button ID="bnSave" runat="server" Text="सत्यापित एवं सुरक्षित करें"   class="btn btn-success" OnClick="bnSave_Click" Height="69px"  Visible="false"/> </td>
        </tr>
    </table>
</asp:Content>

