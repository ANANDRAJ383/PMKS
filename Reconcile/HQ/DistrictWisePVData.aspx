<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="DistrictWisePVData.aspx.cs" Inherits="DBT_DistrictWisePVData" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8" />  
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />  
    <%--<link href="Content/bootstrap.cosmo.min.css" rel="stylesheet" /> --%> 
    <%--<link href="Content/StyleSheet.css" rel="stylesheet" />--%>  
         <!-- Bootstrap -->
    <link href="../cssPMKS/bootstrap.min.css" rel="stylesheet" />
 
    <!-- Datatables-->
    <link href="../cssPMKS/dataTables.bootstrap4.css" 
     rel="stylesheet" />
    <link href="../cssPMKS/buttons.bootstrap4.css" 
     rel="stylesheet" />
    <script>
        $('#gvdata').dataTable({
            "pageLength": 50
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">
        <asp:Label ID="lblMsg" runat="server" Text="Physical Verification Data Report"></asp:Label> :-         
        <asp:Button ID="Button1" runat="server" Text="Export Excel" OnClick="Button1_Click" />

    </div><br />

    <div>

        <div class="table-responsive"> 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                                    <asp:GridView ID="gvdata" runat="server" Width="100%" CssClass="table table-bordered table-striped"
                                        AutoGenerateColumns="False"  ShowFooter="True" 
                                         EmptyDataText="There are no data records to display." OnRowDataBound="gvdata_RowDataBound" Font-Size="10">  
                                        <Columns> 
                                            <asp:TemplateField HeaderText="Sl No" HeaderStyle-Width="8%" HeaderStyle-Font-Bold="true" 
                                                HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1"> 
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                        <HeaderStyle Font-Bold="True" Width="8%" />
                    </asp:TemplateField>
                                            <%--<asp:BoundField DataField="DistName" HeaderText="Distrit Name"  />--%>
                        <asp:TemplateField HeaderText="District Name" HeaderStyle-HorizontalAlign="Left"
                        HeaderStyle-Width="15%" HeaderStyle-BorderWidth="1" HeaderStyle-Font-Bold="true"
                        HeaderStyle-BorderColor="ActiveBorder">
                        <ItemTemplate>
                            <asp:LinkButton ID="LnkDist" runat="server" Text='<%#Eval("DistName") %>' Font-Underline="false"
                                 ForeColor="Blue"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" BorderStyle="Solid" BorderColor="#999999" />
                        <ItemStyle HorizontalAlign="Center" ForeColor="Black" />
                        <FooterTemplate>
                            <asp:Label ID="lblTot" runat="server" Text='Total' Font-Bold="true" Font-Size="Medium"
                                Style="float: right;"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Right" ForeColor="Red" />
                    </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Beneficiary" HeaderStyle-HorizontalAlign="center"
                        HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalBen" Text='<%#Eval("Total")%>' runat="server" Style="float: right;"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#999999" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Center"
                            BorderStyle="Solid" />
                        <ItemStyle HorizontalAlign="Right" Width="12px" ForeColor="Black" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotalBen" runat="server" Text='0' Font-Bold="true" Font-Size="Medium"
                                Style="float: right;"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Right" ForeColor="Black" />
                    </asp:TemplateField>

                                           <%-- <asp:BoundField DataField="Total" HeaderText="Total"  />--%>
                                            <asp:TemplateField HeaderText="Total Ineligible" HeaderStyle-HorizontalAlign="center"
                        HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1">
                        <ItemTemplate>
                            <asp:Label ID="lblIneligible" Text='<%#Eval("Ineligible")%>' runat="server" Style="float: right;"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#999999" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Center"
                            BorderStyle="Solid" />
                        <ItemStyle HorizontalAlign="Right" Width="12px" ForeColor="Black" />
                        <FooterTemplate>
                            <asp:Label ID="lblIneligible" runat="server" Text='0' Font-Bold="true" Font-Size="Medium"
                                Style="float: right;"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Right" ForeColor="Black" />
                    </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Ineligible" HeaderText="Ineligible" />--%> 
                                            <asp:TemplateField HeaderText="Total Ineligible" HeaderStyle-HorizontalAlign="center"
                        HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1">
                        <ItemTemplate>
                            <asp:Label ID="lblEligible" Text='<%#Eval("Eligible")%>' runat="server" Style="float: right;"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#999999" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Center"
                            BorderStyle="Solid" />
                        <ItemStyle HorizontalAlign="Right" Width="12px" ForeColor="Black" />
                        <FooterTemplate>
                            <asp:Label ID="lblEligible" runat="server" Text='0' Font-Bold="true" Font-Size="Medium"
                                Style="float: right;"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Right" ForeColor="Black" />
                    </asp:TemplateField>
                                           <%-- <asp:BoundField DataField="Eligible" HeaderText="Eligible"  />--%>
                                            <asp:TemplateField HeaderText="Total Death" HeaderStyle-HorizontalAlign="center"
                        HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1">
                        <ItemTemplate>
                            <asp:Label ID="lblDeath" Text='<%#Eval("Death")%>' runat="server" Style="float: right;"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#999999" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Center"
                            BorderStyle="Solid" />
                        <ItemStyle HorizontalAlign="Right" Width="12px" ForeColor="Black" />
                        <FooterTemplate>
                            <asp:Label ID="lblDeath" runat="server" Text='0' Font-Bold="true" Font-Size="Medium"
                                Style="float: right;"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Right" ForeColor="Black" />
                    </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Death" HeaderText="Death"  />--%>
                                              <asp:TemplateField HeaderText="Total Death by DAO" HeaderStyle-HorizontalAlign="center"
                        HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1">
                        <ItemTemplate>
                            <asp:Label ID="lblDeathDAO" Text='<%#Eval("DeathDAO")%>' runat="server" Style="float: right;"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#999999" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Center"
                            BorderStyle="Solid" />
                        <ItemStyle HorizontalAlign="Right" Width="12px" ForeColor="Black" />
                        <FooterTemplate>
                            <asp:Label ID="lblDeathDAO" runat="server" Text='0' Font-Bold="true" Font-Size="Medium"
                                Style="float: right;"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Right" ForeColor="Black" />
                    </asp:TemplateField>

                                             <%--<asp:BoundField DataField="DeathDAO" HeaderText="Death by DAO"  />--%> 
                                                 <asp:TemplateField HeaderText="Total Ineligible by DAO" HeaderStyle-HorizontalAlign="center"
                        HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1">
                        <ItemTemplate>
                            <asp:Label ID="lblIneligibleDAO" Text='<%#Eval("IneligibleDAO")%>' runat="server" Style="float: right;"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#999999" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Center"
                            BorderStyle="Solid" />
                        <ItemStyle HorizontalAlign="Right" Width="12px" ForeColor="Black" />
                        <FooterTemplate>
                            <asp:Label ID="lblIneligibleDAO" runat="server" Text='0' Font-Bold="true" Font-Size="Medium"
                                Style="float: right;"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Right" ForeColor="Black" />
                    </asp:TemplateField>
                                            <%--<asp:BoundField DataField="IneligibleDAO" HeaderText="Ineligible by DAO" />--%> 
                                            <asp:TemplateField HeaderText="Total DAO by Verifyed" HeaderStyle-HorizontalAlign="center"
                        HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1">
                        <ItemTemplate>
                            <asp:Label ID="lblDAO_Status" Text='<%#Eval("DAO_Status")%>' runat="server" Style="float: right;"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderColor="#999999" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Center"
                            BorderStyle="Solid" />
                        <ItemStyle HorizontalAlign="Right" Width="10px" ForeColor="Black" />
                        <FooterTemplate>
                            <asp:Label ID="lblDAO_Status" runat="server" Text='0' Font-Bold="true" Font-Size="Medium"
                                Style="float: right;"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Right" ForeColor="Black" />
                    </asp:TemplateField>
 			<asp:BoundField DataField="TotalVerified" HeaderText="Total Verified" />
				    <asp:BoundField DataField="Pending" HeaderText="Pending" />
                                            <%--<asp:BoundField DataField="DAO_Status" HeaderText="DAO Verifyed" />--%> 
                                         
                                        </Columns>  
                                    </asp:GridView>  

                               </ContentTemplate>
                        </asp:UpdatePanel>
                                </div>
    </div>
     
</asp:Content>

