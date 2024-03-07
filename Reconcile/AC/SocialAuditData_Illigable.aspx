<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="SocialAuditData_Illigable.aspx.cs" Inherits="ADM_ReconcileList" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
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
                                <h2 class="card-title mb-0"><b>BENIFICIARY LIST || शत प्रतिशत भौतीक सत्यापन (अपात्र/Death) से प्राप्त लाभुकों का विवरण</b></h2>
                            </div>

                        </div>
                    </div>

                    <div class="row mb-3 m-2">
                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>District</b> <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Block</b> <span class="mandatory">*</span>  </label>
                                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 col-sm-3 col-md-3 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Panchyat</b><span class="mandatory">*</span> </label>
                                <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-12 col-sm-3 col-md-3 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Type</b><span class="mandatory">*</span> </label>
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-select" 
                                    OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="0" Text="--Select--"></asp:ListItem>
                                    <asp:ListItem Value="Ineligible" Text="Ineligible"></asp:ListItem>
                                    <asp:ListItem Value="Death" Text="Death"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>


                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-primary" OnClick="btnShow_Click" />
                            </div>
                        </div>


                    </div>

                    <div class="m-1" style="overflow-x:scroll;">
                        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
                        <asp:GridView ID="gvdata" runat="server" CssClass="table-bordered table"
                            AutoGenerateColumns="False" OnPreRender="gvdata_PreRender"  DataKeyNames="RegistrationNo"
                            EmptyDataText="There are no data records to display.">
                            <Columns>
                                
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" Text="Select all" Enabled="false" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDetails" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SN">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1+"." %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address Detail" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <strong>Block : </strong><%#Eval("BlockName")%><br />
                                        <strong>Panchayat : </strong><%#Eval("PanchayatName")%><br />
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Registration Id">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("RegistrationNo") %>'></asp:Label>

                                        <br />
                                        PMKisan Reg No:-<asp:Label ID="lblPKID" runat="server" Text='<%#Eval("PMK_NO") %>'></asp:Label>
                                        <br />
                                        Aadhar No:-<asp:Label ID="lblUID" runat="server" Text='<%#Eval("AadharNumber") %>'></asp:Label>
                                        <br />
                                        Mobile No:-<asp:Label ID="lblMobile" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FarmerName" HeaderText="Farmer Name" />
                                <asp:BoundField DataField="FatherName" HeaderText="Father/Husband Name" />
                                <asp:BoundField DataField="PhyVerifResponse" HeaderText="PhyVerifResponse" />

                                <asp:TemplateField HeaderText="AC Remark" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <strong>Reason : </strong><%#Eval("ACRemarks")%><br />
                                        <strong>Reason Code : </strong><%#Eval("PhyVerifReason")%><br />
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>


                                <asp:BoundField DataField="ACRemarks" HeaderText="AC Remark" Visible="false" />
                                <asp:BoundField DataField="PhyVerifDate" HeaderText="Ineligible Date / Date of Death" />
                                <asp:TemplateField HeaderText="Ineligible Date / Date of Death" Visible="false">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPhyVerifDate" runat="server" Text='<%#Eval("PhyVerifDate") %>'></asp:TextBox>
                                        <rjs:popcalendar id="PopCalendar1" runat="server" control="txtPhyVerifDate" format="dd mmm yyyy" to-today="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Accept/Reject" Visible="false">
                                    <ItemTemplate>
                                        <div class="form-select">
                                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select">
                                                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Accept</asp:ListItem>
                                                <asp:ListItem Value="2">Reject</asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remarks" Visible="false">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Document">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("VerificationImagePath")%>'
                                            Target="_blank">View</asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Button ID="btnViewDetail" Text="Save" runat="server" OnClick="btnViewDetail_Click" class="btn btn-success" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
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

