<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="ContactDetails.aspx.cs" Inherits="HQ_ContactDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">District/Block/Panchayat Operators Mobile Number | Email Id </div><br />
     <div class="row">
        <div class="input-group mb-3 col-lg-3">
            <label>District :</label>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlDist" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
            </asp:DropDownList> </ContentTemplate>
                        </asp:UpdatePanel>
        </div>
        <div class="input-group mb-3 col-lg-2">
            <label>Block :</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
            </asp:DropDownList> </ContentTemplate>
                        </asp:UpdatePanel>
        </div>

        <div class="input-group mb-3 col-lg-2">
            <label>Panchayat :</label>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select"
                 ValidationGroup="s">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel>
        </div>
         <div class="input-group mb-3 col-lg-3">
            <label>Role</label>
            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select" ValidationGroup="s">
                <asp:ListItem Value="0" Selected="True" Text="--Select--"></asp:ListItem>
                <asp:ListItem Value ="AC" Text="AC"></asp:ListItem>
                <asp:ListItem Value ="CO" Text="CO"></asp:ListItem>
                <asp:ListItem Value ="DAO" Text="DAO"></asp:ListItem>
                <asp:ListItem Value ="ADM(Revenue)" Text="ADM(Revenue)"></asp:ListItem>
            </asp:DropDownList>
              </div>
         <div class="input-group mb-3 col-lg-2">
             &nbsp;
  <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click"  /> 
</div>
        
        
   </div>
    <div class="input-group mb-3 col-lg-6">
             &nbsp;
        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
     <div >
            
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                 CssClass="table table-bordered table-striped"
             AutoGenerateColumns="false"    Font-Size="12px" >
            <Columns>
                
                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DistName" HeaderText="District Name" />
                <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" />
                
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="txtUserName" runat="server" Text='<%#Eval("Name") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Mobile No">
                    <ItemTemplate>
                        <asp:Label ID="txtMobileNo" runat="server" Text='<%#Eval("Mobileno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email Id">
                    <ItemTemplate>
                        <asp:Label ID="txtEmailId" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               
            </Columns>
            <RowStyle />
        </asp:GridView>
                               
        </div>
</asp:Content>

