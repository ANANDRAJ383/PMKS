<%@ Page Title="" Language="C#" MasterPageFile="DBTMasterPage.master" AutoEventWireup="true" CodeFile="LoginList.aspx.cs" Inherits="LoginList" EnableEventValidation="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   
<div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Verification of Reconsider Application</div><br />
    

    <div class="row">
        <div class="input-group mb-3 col-lg-3">
            <label>District :</label>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlDist" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>
        <div class="input-group mb-3 col-lg-2">
            <label>Block :</label>
            <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

        <div class="input-group mb-3 col-lg-2">
            <label>Panchayat :</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select"
                 ValidationGroup="s">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>
         <div class="input-group mb-3 col-lg-3">
            <label>Enter User Id : &nbsp;</label>
            <asp:TextBox ID="txtUser_Id" runat="server" placeholder=" User Id" ></asp:TextBox>
              </div>
         <div class="input-group mb-3 col-lg-2">
             &nbsp;
  <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click"  /> 
</div>
        
        
   </div>

<div class="form-row">
    <div class="input-group mb-3 col-lg-6">
             &nbsp;
    <asp:Button ID="btnApproved" runat="server" Text="Change" CssClass="btn btn-success" Visible="false" OnClick="btnApproved_Click"  />
        </div>
    <div class="input-group mb-3 col-lg-6">
             &nbsp;
        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    </div>

        <div >
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                AllowPaging="true" PageSize="10" CssClass="table table-bordered table-striped"
            DataKeyNames="userid" AutoGenerateColumns="false"   onpageindexchanging="gvdata_PageIndexChanging" Font-Size="12px" >
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
                <asp:BoundField DataField="DistName" HeaderText="District Name" />
                <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" />
                <asp:TemplateField HeaderText="User Id">
                    <ItemTemplate>
                        <asp:Label ID="lblUserId" runat="server" Text='<%#Eval("userid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="userrole" HeaderText="User Role" />
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:TextBox ID="txtUserName" runat="server" Text='<%#Eval("Name") %>' ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Password">
                    <ItemTemplate>
                        <asp:TextBox ID="txtPassword" runat="server" Text='<%#Eval("password") %>' Enabled="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile No">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMobileNo" runat="server" Text='<%#Eval("Mobileno") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email Id">
                    <ItemTemplate>
                        <asp:TextBox ID="txtEmailId" runat="server" Text='<%#Eval("Email") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
            <RowStyle />
        </asp:GridView>
                               </ContentTemplate>
                        </asp:UpdatePanel> 
        </div>
 
</asp:Content>

