<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="PMkisanSocialAuditData.aspx.cs" Inherits="ADM_DieselReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Bootstrap -->
    <link href="../cssPMKS/bootstrap.min.css" rel="stylesheet" />
    <!-- Datatables-->
    <link href="../cssPMKS/dataTables.bootstrap4.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div style="margin: 30px 50px 10px 50px;">

        <div class="row">
            <!-- Revenue breakdown chart example-->
            <div class="col-lg-12 ">
                <div class="card card-raised h-100">
                    <div class="card-header bg-transparent px-4">
                        <div class="d-flex justify-content-between align-items-center">
                            <div class="me-4">
                                <h2 class="card-title mb-0"><b><asp:Label ID="lblRType" runat="server" ></asp:Label></b></h2>
                            </div>

                        </div>
                    </div>

                    <div class="row mb-3 m-2">
                        <asp:Button ID="btnExport" runat="server" Text="Export To Excel"  Visible="false" OnClick="btnExport_Click" />
                        <div class="col-12 col-sm-4 col-md-4 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Report Type</b> <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-select"
                                    AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1">District Wise 100% Physical Verification Done</asp:ListItem>
                                    <asp:ListItem Value="2">Panchayat Wise 100% Physical Verification Done</asp:ListItem>
                                    <asp:ListItem Value="3">District wise Ankeshan</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 col-sm-4 col-md-4 mb-3">
                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-primary" OnClick="btnShow_Click" />
                            </div>
                        </div>


                    </div>

                    <div class="m-1">
                        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF"></asp:Label>
                        
                        <asp:GridView ID="gvdata" runat="server"
                            CssClass="table table-bordered table-striped" AutoGenerateColumns="false"
                            ShowFooter="True" EmptyDataText="There are no data records to display."
                            OnRowDataBound="gvdata_RowDataBound" Font-Size="10" >
                            <Columns>

                                <asp:TemplateField HeaderText="Sl No" HeaderStyle-Width="8%" HeaderStyle-Font-Bold="true"
                                    HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="8%" />
                                </asp:TemplateField>
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
                                        <asp:Label ID="lblTotalBen" Text='<%#Eval("total")%>' runat="server" Style="float: right;"></asp:Label>
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
                                <asp:TemplateField HeaderText="Total Verified" HeaderStyle-HorizontalAlign="center"
                                    HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVerified" Text='<%#Eval("Verified")%>' runat="server" Style="float: right;"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle BorderColor="#999999" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Center"
                                        BorderStyle="Solid" />
                                    <ItemStyle HorizontalAlign="Right" Width="12px" ForeColor="Black" />
                                    <FooterTemplate>
                                        <asp:Label ID="lblVerified" runat="server" Text='0' Font-Bold="true" Font-Size="Medium"
                                            Style="float: right;"></asp:Label>
                                    </FooterTemplate>
                                    <FooterStyle HorizontalAlign="Right" ForeColor="Black" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Verified" HeaderText="Death" />
                                <asp:BoundField DataField="VerifiedEligible" HeaderText="Eligible" />
                                <asp:BoundField DataField="VerifiedIneligible" HeaderText="Ineligible" />
                                <asp:BoundField DataField="TotalVerified" HeaderText="Total Verified" />
                                <asp:BoundField DataField="Pending" HeaderText="Pending" />

                            </Columns>
                            <RowStyle />
                        </asp:GridView>

                        <asp:GridView ID="GridPanOld" runat="server" EmptyDataText="No record found"
                            CssClass="table table-striped"
                            AutoGenerateColumns="false" Font-Size="12px" OnPreRender="GridPanOld_PreRender">
                            <Columns>

                                <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1+"." %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DistName" HeaderText="District Name" />
                                <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                                <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" />
                                <asp:BoundField DataField="total" HeaderText="Total" />
                                <asp:BoundField DataField="Verified" HeaderText="VerifiedDeath" />
                                <asp:BoundField DataField="VerifiedEligible" HeaderText="VerifiedEligible" />
                                <asp:BoundField DataField="VerifiedIneligible" HeaderText="VerifiedIneligible" />
                                <asp:BoundField DataField="TotalVerified" HeaderText="Total Verified" />
                                <asp:BoundField DataField="Pending" HeaderText="Pending" />
                            </Columns>
                            <RowStyle />
                        </asp:GridView>

                        <asp:GridView ID="GridAnk" runat="server" EmptyDataText="No record found"
                            CssClass="table table-striped" OnPreRender="GridAnk_PreRender"
                            AutoGenerateColumns="false" Font-Size="12px">
                            <Columns>

                                <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1+"." %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Distname" HeaderText="District Name" />
                                <asp:BoundField DataField="NoOfFarmer" HeaderText="Total" />
                                <asp:BoundField DataField="NoofVillage" HeaderText="NoofVillage" />
                                <asp:BoundField DataField="RevVillCovered" HeaderText="RevVillCovered" />
                                <asp:BoundField DataField="BenifAuditCompleted" HeaderText="BenifAuditCompleted" />
                                <asp:BoundField DataField="IneliglibleBenif" HeaderText="IneliglibleBenif" />
                                <asp:BoundField DataField="EligibleNonBenif" HeaderText="EligibleNonBenif" />
                                <asp:BoundField DataField="EnterDate" HeaderText="EnterDate" />


                            </Columns>
                            <RowStyle />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <!-- jQuery and Bootstrap JS files -->
    <script src="../JsPMKS/jquery-3.4.1.js"></script>


    <!-- Datatables-->
    <script src="../JsPMKS/jquery.dataTables.min.js"></script>
    <script src="../JsPMKS/dataTables.bootstrap4.min.js">
    </script>
    <script src="../JsPMKS/dataTables.buttons.min.js">
    </script>
    <script src="../JsPMKS/buttons.bootstrap4.min.js">
    </script>
    <script src="../JsPMKS/jszip.min.js"></script>
    <script src="../JsPMKS/pdfmake.min.js"></script>
    <script src="../JsPMKS/vfs_fonts.js"></script>
    <script src="../JsPMKS/buttons.html5.min.js"></script>
    <script src="../JsPMKS/buttons.print.min.js"></script>
    <script src="../JsPMKS/buttons.colVis.min.js"></script>
    <script src="../JsPMKS/datatables-init.js"></script>

    <!-- pace -->
    <script>
        var handleDataTableButtons = function () {
            "use strict";
            0 !== $('#<%= gvdata.ClientID %>').length &&
            $('#<%= gvdata.ClientID %>').DataTable({
                    dom: "Bfrtip",
                    buttons: [{
                        extend: "copy",
                        className: "btn-sm"
                    }, {
                        extend: "csv",
                        className: "btn-sm"
                    }, {
                        extend: "excel",
                        className: "btn-sm"
                    }, {
                        extend: "pdf",
                        className: "btn-sm"
                    }, {
                        extend: "print",
                        className: "btn-sm"
                    }],
                    responsive: !0
                })
        },
            TableManageButtons = function () {
                "use strict";
                return {
                    init: function () {
                        handleDataTableButtons()
                    }
                }
            }();
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= gvdata.ClientID %>').dataTable();
    });
        TableManageButtons.init();
    </script>


</asp:Content>

