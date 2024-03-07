<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true" CodeFile="PMKisanDBStatus.aspx.cs" Inherits="PMKisanDBStatus" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
 <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">View District Wise Farmer Details - As Par Database</div><br />
    <div>
    <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found"  Width="100%"
                CssClass="table table-bordered table-responsive table-striped"
            AutoGenerateColumns="false"   Font-Size="12px" OnRowDataBound="gvdata_RowDataBound" ShowFooter="True">
            <Columns>
                
                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="District">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDistrict" runat="server" Text='<%# Eval("DistrictName") %>'
                        CommandName="blk" CommandArgument='<%# Eval("DistrictName") %>'>'></asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
                <%-- <asp:BoundField DataField="DistrictName" HeaderText="District " />--%>
                <asp:BoundField DataField="Total" HeaderText="Total" />
                
            </Columns>
            <RowStyle />
        </asp:GridView>
        </div>
</asp:Content>

