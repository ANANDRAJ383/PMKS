<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="PMKisanV4V5Report.aspx.cs" Inherits="ADM_PMKisanReport" EnableEventValidation = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">V4/V5 Daily Report Pending at CO login</div><br />

  <div class="card-group">
  <div class="card">
    <%--<img src="../images/Pm-Kisan-Yojana.png" class="card-img-top" alt="...">--%>
    <div class="card-body">
      <h5 class="card-title">V4 (New/Recon/Re-Recon)</h5>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
        <asp:GridView ID="GridV4" runat="server" EmptyDataText="No record found"
            CssClass="table table-bordered  table-striped"
            AutoGenerateColumns="false" Font-Size="12px" OnRowCommand="GridV4_RowCommand">
            <Columns>

                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Blockname" HeaderText="Block Name" />
                <asp:TemplateField HeaderText="Total Farmers" HeaderStyle-ForeColor="#FF3300">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkTotalFarmers" runat="server" Text='<%#Eval("TotalFarmers") %>'
                            CommandArgument='<%# Eval("BlockCode") %>' CommandName="BlockCode"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="TotalFarmers" HeaderText="Total Farmers" />--%>

            </Columns>
            <RowStyle />
        </asp:GridView>
      </ContentTemplate>
                        </asp:UpdatePanel>
    </div>
  </div>
  <div class="card">
   <%-- <img src="../images/Pm-Kisan-Yojana.png" class="card-img-top" alt="...">--%>
    <div class="card-body">
      <h5 class="card-title">V5 (Land Sheeding No)</h5>
         <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
        <asp:GridView ID="GridV5" runat="server" EmptyDataText="No record found"
            CssClass="table table-bordered  table-striped"
            AutoGenerateColumns="false" Font-Size="12px" OnRowCommand="GridV5_RowCommand">
            <Columns>

                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                <asp:TemplateField HeaderText="Total Farmers" HeaderStyle-ForeColor="#FF3300">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkTotalFarmers" runat="server" Text='<%#Eval("TotalFarmers1") %>'
                            CommandArgument='<%# Eval("BlockCode") %>' CommandName="BlockCode"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
              <%--  <asp:BoundField DataField="TotalFarmers1" HeaderText="Total Farmers" />--%>


            </Columns>
            <RowStyle />
        </asp:GridView>
    </ContentTemplate>
                        </asp:UpdatePanel>
    </div>
      </div>
      </div>
</asp:Content>

