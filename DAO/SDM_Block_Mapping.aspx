<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="SDM_Block_Mapping.aspx.cs" Inherits="DAO_SDM_Block_Mapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Map Blocks in Subdivision</div><br />
    

    <div class="row">
        <div class="input-group mb-3 col-lg-4">
            <label>Sub Division :</label>
            <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlSubDivision" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlSubDivision_SelectedIndexChanged">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

        <div class="input-group mb-3 col-lg-4">
            <label>Block :</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                           <ContentTemplate>
            <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"
                 ValidationGroup="s">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

         <div class="input-group mb-3 col-lg-4">
             &nbsp;
  <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success" OnClick="btnAdd_Click"  /> 
</div>
        
        <div class="input-group mb-3 col-lg-4">
             &nbsp;
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    </div>
    <div >

           <asp:UpdatePanel ID="up" runat="server" UpdateMode="Always">
            <ContentTemplate>
         <asp:GridView ID="gvView" runat="server" EmptyDataText="No record found" AllowPaging="false" DataKeyNames="BlockCode"  OnRowDeleting="gvView_RowDeleting"
                     AutoGenerateColumns="false" Width="100%" AlternatingRowStyle-CssClass="alt" CssClass="table table-bordered table-striped">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                       
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1+"." %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DistName" HeaderText="District" />
                        <asp:BoundField DataField="SubDivisionName" HeaderText="Sub Division" />
                        <asp:BoundField DataField="BlockName" HeaderText="Block" />
                        <asp:BoundField DataField="DistCode" HeaderText="District Code" />
                        <asp:BoundField DataField="SubDivisionCode" HeaderText="Sub Division Code" />
                        <asp:BoundField DataField="BlockCode" HeaderText="Block Code" />
                        <asp:BoundField DataField="ActionDate" HeaderText="Action Date" />
                        <asp:CommandField ShowDeleteButton="true" /> 
                    </Columns>
                    
                </asp:GridView>
                 <br />
        <asp:Label runat="server" Text=" " ID="lblname"       ForeColor="#507CD1" Font-Size="20px"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <br />
  
</asp:Content>

