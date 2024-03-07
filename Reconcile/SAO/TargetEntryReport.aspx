<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="TargetEntryReport.aspx.cs" Inherits="Reconcile_DAO_TargetEntryReport" %>

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
                                <h2 class="card-title mb-0"><b>पीएम-किसान कार्य की प्रविष्टि रिपोर्ट </b></h2>
                            </div>

                        </div>
                    </div>


                    <div class="row mb-3 m-5">
                        <div class="col-12 col-sm-3 col-md-3 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Sub Divison</b> <span class="mandatory">*</span></label>

                                <asp:DropDownList ID="ddlSubDivison" runat="server" CssClass="form-select" 
                                    OnSelectedIndexChanged="ddlSubDivison_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 col-sm-3 col-md-3 mb-4">
                            <div class="form-group">
                                <label class="control-label"><b>Block</b> <span class="mandatory">*</span>  </label>
                                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 col-sm-3 col-md-3 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Report For </b><span class="mandatory">*</span> </label>
                                <asp:DropDownList ID="ddlEntryFor" runat="server" CssClass="form-select">
                                    <asp:ListItem Selected="True" Value="0" Text="--Select--"></asp:ListItem>
                                    <asp:ListItem Value="eKYC" Text="eKYC"></asp:ListItem>
                                    <asp:ListItem Value="NPCI" Text="NPCI"></asp:ListItem>
                                    <asp:ListItem Value="Recovery" Text="Recovery"></asp:ListItem>
                                    <asp:ListItem Value="PV" Text="Physical Verification"></asp:ListItem>
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
                                AutoGenerateColumns="False" OnPreRender="gvdata_PreRender"
                                EmptyDataText="There are no data records to display.">
                                <Columns>
                                    <asp:TemplateField HeaderText="क्रम संख्या">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1+"." %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DistName" HeaderText="District Name" />
                                    <asp:BoundField DataField="SubDivisonName" HeaderText="Sub Divison Name" />
                                    <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                                    <asp:BoundField DataField="Pending" HeaderText="Total Penging" />
                                    <asp:BoundField DataField="LastWeekWorkDone" HeaderText="Last Week Work Done" />
                                    <asp:BoundField DataField="LastWeekWorkDonePer" HeaderText="Last Week Work Done %" />
                                    <asp:BoundField DataField="CurrentWeekWorkDone" HeaderText="Current Week Work Done" />
                                    <asp:BoundField DataField="CurrentWeekWorkDonePer" HeaderText="Current Week Work Done %" />


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

