<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="PhysicalVerificationReportNew.aspx.cs" Inherits="Reconcile_DAO_TargetEntryReport" %>

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
                                <h2 class="card-title mb-0"><b>पीएम-किसान भौतिक सत्यापन रिपोर्ट </b></h2>
                            </div>

                        </div>
                    </div>


                    <div class="row mb-3 m-5">
                        <div class="col-12 col-sm-2 col-md-3 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>District</b> <span class="mandatory">*</span></label>

                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select" 
                                    OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-12 col-sm-2 col-md-3 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Block</b> <span class="mandatory">*</span></label>

                                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select" 
                                    OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            
                        </div>
			<div class="col-12 col-sm-3 col-md-3 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Panchayat</b> <span class="mandatory">*</span></label>

                                <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-12 col-sm-3 col-md-3 mb-3">
                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-raised-primary" OnClick="btnShow_Click" />
                            </div>
                        </div>


                        <div class="m-1">
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF"></asp:Label>
                            <asp:GridView ID="gvdata" runat="server" Width="100%" CssClass="table table-bordered table-striped"
                                AutoGenerateColumns="False" OnPreRender="gvdata_PreRender" Visible="false"
                                EmptyDataText="There are no data records to display." OnRowCommand="gvdata_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="क्रम संख्या">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1+"." %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DistName" HeaderText="District Name" />
                                    <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                                    <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" />
                                    <asp:BoundField DataField="total" HeaderText="Total" />
                                    <asp:BoundField DataField="VerifiedDeath" HeaderText="Death" />
                                    <asp:BoundField DataField="VerifiedEligible" HeaderText="Eligible" />
                                    <asp:BoundField DataField="VerifiedIneligible" HeaderText="Ineligible" />
                                    <asp:BoundField DataField="TotalVerified" HeaderText="Total Verified" />
                                    <%--<asp:BoundField DataField="Pending" HeaderText="Pending" />--%>
                                    <asp:TemplateField HeaderText="Pending" HeaderStyle-ForeColor="#FF3300">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkPending" runat="server" Text='<%#Eval("Pending") %>' 
                                                CommandArgument='<%# Eval("PanchayatCode") %>' CommandName="PanchayatCode"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                             <asp:GridView ID="GridViewPVData" runat="server" Width="100%" CssClass="table table-bordered table-striped"
                                AutoGenerateColumns="False" Visible="false"
                                EmptyDataText="There are no data records to display." OnRowCommand="gvdata_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="क्रम संख्या">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1+"." %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Districtname" HeaderText="District" />
                                    <asp:BoundField DataField="Blockname" HeaderText="Block" />
                                    <asp:BoundField DataField="Panchayatname" HeaderText="Panchayat" />
                                    <asp:BoundField DataField="VillageName" HeaderText="Village" />
                                    <asp:BoundField DataField="Registration_Id" HeaderText="RegistrationId" />
                                    <asp:BoundField DataField="PMKS_Reg_No" HeaderText="PMKS_Reg_No" />
                                    <asp:BoundField DataField="ApplicationType" HeaderText="ApplicationType" />
                                    <asp:BoundField DataField="ApplicantName" HeaderText="ApplicantName" />
                                    <asp:BoundField DataField="Father_Husband_Name" HeaderText="Father/Husband Name" />
                                    <asp:BoundField DataField="MOBILENO" HeaderText="MOBILENO" />
                                    <asp:BoundField DataField="AadharCard" HeaderText="Aadhar" />
                                    
                                </Columns>
                            </asp:GridView>
                        </div>


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

