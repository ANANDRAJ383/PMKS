<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="PMKisanV4V5Report.aspx.cs" Inherits="ADM_PMKisanReport" EnableEventValidation = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Daily Report<asp:Label ID="lblRType" runat="server" ></asp:Label></div><br />

  <div class="card-group">
  <div class="card">
    <img src="../images/Pm-Kisan-Yojana.png" class="card-img-top" alt="...">
    <div class="card-body">
      <h5 class="card-title">V4 (New/Recon/Re-Recon)</h5>
        <asp:GridView ID="GridV4" runat="server" EmptyDataText="No record found"
            CssClass="table table-bordered  table-striped"
            AutoGenerateColumns="false" Font-Size="12px">
            <Columns>

                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Districtname" HeaderText="District Name" />
                <asp:BoundField DataField="TotalFarmers" HeaderText="Total Farmers" />

            </Columns>
            <RowStyle />
        </asp:GridView>
      <p class="card-text"><small class="text-body-secondary">Last updated 3 mins ago</small></p>
    </div>
  </div>
  <div class="card">
    <img src="../images/Pm-Kisan-Yojana.png" class="card-img-top" alt="...">
    <div class="card-body">
      <h5 class="card-title">V5 (Land Sheeding No)</h5>
        <asp:GridView ID="GridV5" runat="server" EmptyDataText="No record found"
            CssClass="table table-bordered  table-striped"
            AutoGenerateColumns="false" Font-Size="12px">
            <Columns>

                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DistName" HeaderText="District Name" />
                <asp:BoundField DataField="TotalFarmers1" HeaderText="Total Farmers" />


            </Columns>
            <RowStyle />
        </asp:GridView>
      <p class="card-text"><small class="text-body-secondary">Last updated 3 mins ago</small></p>
    </div>
      </div>
</asp:Content>

