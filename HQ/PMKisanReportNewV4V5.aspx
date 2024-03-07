<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="PMKisanReportNewV4V5.aspx.cs" Inherits="ADM_PMKisanReport" EnableEventValidation = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Daily Report<asp:Label ID="lblRType" runat="server" ></asp:Label></div><br />

    <div class="row">
        <div class="input-group mb-3 col-lg-4">
            <label>Report Type :</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged" >
                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
               
              <asp:ListItem Value="Dist" >District Wise</asp:ListItem>
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

        <div class="input-group mb-3 col-lg-4">
            <label>Application Type :</label>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlApplicationType" runat="server" CssClass="form-select"
                  AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlApplicationType_SelectedIndexChanged">
                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                 <asp:ListItem Value="V4" >V4 (New/Recon/Re-Recon)</asp:ListItem>             
                <asp:ListItem Value="V5" >V5 (Land Sheeding No)</asp:ListItem>
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

        <div class="input-group mb-3 col-lg-4">
             
  <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
             <asp:Button ID="btnExport" runat="server" Text="Export To Excel" CssClass="btn btn-success"  OnClick="btnExport_Click" />
                    
        </div>

        <div class="input-group mb-3 col-lg-4">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel> 
</div>
    </div>

    <div class="form-row">
    </div>

        <div >
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>

                                <asp:GridView ID="GridV4" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-bordered  table-striped"
                                   AutoGenerateColumns="false" Font-Size="12px">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="distName" HeaderText="District Name" />
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />


                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>

                               <asp:GridView ID="GridV5" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-bordered  table-striped"
                                   AutoGenerateColumns="false" Font-Size="12px">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="distName" HeaderText="District Name" />
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />


                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>
            </ContentTemplate>
                        </asp:UpdatePanel> 
        </div>
</asp:Content>

