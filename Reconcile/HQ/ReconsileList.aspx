﻿<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="ReconsileList.aspx.cs" Inherits="HQ_RecoveredListBy_DAO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <!-- Bootstrap -->
    <link href="../cssPMKS/bootstrap.min.css" rel="stylesheet" />
 
    <!-- Datatables-->
    <link href="../cssPMKS/dataTables.bootstrap4.css" 
     rel="stylesheet" />
    <link href="../cssPMKS/buttons.bootstrap4.css" 
     rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="margin: 30px 50px 10px 50px;">

        <div class="row">
            <!-- Revenue breakdown chart example-->
            <div class="col-lg-12 ">
                <div class="card card-raised h-100">
                    <div class="card-header bg-transparent px-4">
                        <div class="d-flex justify-content-between align-items-center">
                            <div class="me-4">
                                <h2 class="card-title mb-0"><b>PM Kisan Reconcile List by Bunty/Nitish</b></h2>
                            </div>

                        </div>
                    </div>

                    <div class="row mb-3 m-2">
                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>District</b> <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select" 				OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Payment Mode</b> <span class="mandatory">*</span>  </label>
                                <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="form-select">
                        <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                        <asp:ListItem Value="ITR">Income Tax Payee Farmer</asp:ListItem>
                        <asp:ListItem Value="OTH">Ineligible Farmer</asp:ListItem>
                    </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Reconsiled</b> <span class="mandatory">*</span>  </label>
                               <asp:DropDownList ID="ddlApproved" runat="server" CssClass="form-select">
                        <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                        <asp:ListItem Value="Y">Matched</asp:ListItem>
                        <asp:ListItem Value="N">Not Matched </asp:ListItem>
                    </asp:DropDownList>
                            </div>
                        </div>
    <div class="col-12 col-sm-3 col-md-3 mb-3">
                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click"  />
                            </div>
                        </div>
     
  
  <div class="m-1" style="overflow-x:scroll;">
          <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
        <asp:GridView ID="gvdata" runat="server" CssClass="table table-bordered table-striped"
                                   AutoGenerateColumns="False" OnPreRender="gvdata_PreRender"
                                   EmptyDataText="There are no data records to display." Font-Size="10px" DataKeyNames="Registration_Id">
            <Columns>
                
                <asp:TemplateField HeaderText="क्रम संख्या">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DistrictName" HeaderText="जिला" />
                <asp:BoundField DataField="BlockName" HeaderText="प्रखंड" Visible="false" />
                <asp:BoundField DataField="PanchayatName" HeaderText="पंचायत" Visible="false" />
                <asp:BoundField DataField="RevenueVillageName" HeaderText="ग्राम" Visible="false" />
                <asp:BoundField DataField="Registration_Id" HeaderText="पंजीकरण संख्या (DBT)" />
                <asp:TemplateField HeaderText="पंजीकरण संख्या (PMKS)">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("reg_no") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="reg_no" HeaderText="पंजीकरण संख्या (PMKS)" Visible="false" />
                <asp:BoundField DataField="Farmer_Name" HeaderText="किसान का नाम" />
                <asp:BoundField DataField="Father_Name" HeaderText="पिता/पति का नाम" Visible="false" />
                <asp:BoundField DataField="MobileNo" HeaderText="मोबाइल नंबर" />
                <asp:BoundField DataField="NoOfInstallments" HeaderText="किस्त" />
                <asp:BoundField DataField="RntAmount" HeaderText="वापसी रकम" />
                <asp:BoundField DataField="PaymentReturnAC" HeaderText="भुगतान वापसी ए.सी" />
                <asp:BoundField DataField="TransactionNo" HeaderText="ट्रांजेक्शन नंबर" />
                <asp:BoundField DataField="TransactionDate" HeaderText="ट्रांजेक्शन दिनांक" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField DataField="PaymentReturnMode" HeaderText="वापसी का तरीका" />
                <asp:BoundField DataField="IsLean" HeaderText="IsLean" Visible="false" />
                <asp:BoundField DataField="UpdateRole" HeaderText="Action By" Visible="false" />
                <asp:BoundField DataField="Reason" HeaderText="कारण" Visible="false" />
                <asp:BoundField DataField="ReasonDetails" HeaderText="अयोग्य के कारण" Visible="false" />
                <asp:TemplateField HeaderText="ट्रांजेक्शन रसीद">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("DocPath")%>'
                            Target="_blank">View Doc</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <RowStyle />
        </asp:GridView>
              </div>                
        </div>
                    </div>
                </div>
            </div>
        </div>
    
    <!-- jQuery and Bootstrap JS files -->
    <script src="../JsPMKS/jquery-3.4.1.js"></script>
    <script src="../js/popper.min.js"></script>
    <script src="../cssPMKS/bootstrap.min.js"></script>

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

