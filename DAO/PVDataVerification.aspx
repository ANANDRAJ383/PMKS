<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="PVDataVerification.aspx.cs" Inherits="DAO_DataListForVerification_Re_Recon" EnableEventValidation="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   
<div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Verification of Reconsider Application</div><br />
    

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


        <div> Type :<asp:DropDownList ID="ddlType" runat="server" CssClass="form-select" ValidationGroup="s" >
                <asp:ListItem Selected="True" Value="0" Text="--Select--"></asp:ListItem>
                <asp:ListItem  Value="Ineligible" Text="Ineligible"></asp:ListItem>
                <asp:ListItem  Value="Death" Text="Death"></asp:ListItem>
            </asp:DropDownList></div>
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
                AllowPaging="true" PageSize="50" CssClass="table table-bordered table-striped"
            DataKeyNames="RegistrationNo" AutoGenerateColumns="false"   onpageindexchanging="gvdata_PageIndexChanging" Font-Size="12px" >
            <Columns>
                 <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" Text="Select all"  Enabled="false"/>
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
                 <asp:TemplateField HeaderText="Address Detail" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <strong>Block : </strong><%#Eval("BlockName")%><br />
                        <strong>Panchayat : </strong><%#Eval("PanchayatName")%><br />
                    </ItemTemplate>
                    <HeaderStyle Width="10%" />
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Registration Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("RegistrationNo") %>'></asp:Label>

                       <br /><asp:Label ID="lblPKID" runat="server" Text='<%#Eval("PMK_NO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FarmerName" HeaderText="Farmer Name" />
                <asp:BoundField DataField="FatherName" HeaderText="Father/Husband Name" />
                <asp:BoundField DataField="PhyVerifResponse" HeaderText="PhyVerifResponse" />
                <asp:BoundField DataField="PhyVerifDate" HeaderText="PhyVerifDate" Visible="false" />
                <asp:TemplateField HeaderText="PhyVerifDate">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPhyVerifDate" runat="server" Text='<%#Eval("PhyVerifDate") %>'></asp:TextBox>
                         <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="txtPhyVerifDate" Format="dd mmm yyyy" To-Today="true" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Accept/Reject">
                    <ItemTemplate>
                        <div class="form-select">
                            <asp:DropDownList ID="ddlStatus" runat="server"  CssClass="form-select">
                                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                <asp:ListItem Value="1">Accept</asp:ListItem>
                                <asp:ListItem Value="2">Reject</asp:ListItem>
                            </asp:DropDownList>
                            
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Document">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("VerificationImagePath")%>'
                            Target="_blank">View</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                 
               <%-- <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnViewDetail" Text="Verify" runat="server" OnClick="btnViewDetail_Click"  class="btn btn-success"/>
                </ItemTemplate>
            </asp:TemplateField>--%>
            </Columns>
            <RowStyle />
        </asp:GridView>                
                               </ContentTemplate>
                        </asp:UpdatePanel> 
        </div>
 
</asp:Content>

