<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="Reconsile_Data_List.aspx.cs" Inherits="DBT_DistrictWisePVData" EnableEventValidation="false" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">

    </div><br />

    <div>
        <table class="table-bordered  table table-striped " style="width: 100%;">
            <tr>
                <td>District</td>
                <td>
                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                </td>
                <td>Return Reason</td>
                <td>
                    <asp:DropDownList ID="ddlReason" runat="server" CssClass="form-select">
                        <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                        <asp:ListItem Value="ITR">Income Tax Payee Farmer</asp:ListItem>
                        <asp:ListItem Value="OTH">Ineligible Farmer</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Payment Mode</td>
                <td>
                    <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-select">
                        <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                        <asp:ListItem Value="AADHAR">Aadhaar Based</asp:ListItem>
                        <asp:ListItem Value="ACCOUNT">Account Based</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Bank</td>
                <td>
                    <asp:DropDownList ID="ddlBank" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" />
                </td>
            </tr>
        </table>
        <div class="table-responsive"> 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                               <asp:GridView ID="gvdata" runat="server" Width="100%" CssClass="table table-bordered table-striped"
                                   AutoGenerateColumns="False" OnPreRender="gvdata_PreRender"
                                   EmptyDataText="There are no data records to display.">
                                   <Columns>

                                       <asp:TemplateField HeaderText="क्रम संख्या">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="DistrictName" HeaderText="जिला" />
                                       <asp:BoundField DataField="BlockName" HeaderText="प्रखंड" />
                                       <asp:BoundField DataField="PanchayatName" HeaderText="पंचायत" />
                                       <asp:BoundField DataField="RevenueVillageName" HeaderText="ग्राम" />
                                       <asp:BoundField DataField="Registration_Id" HeaderText="पंजीकरण संख्या (DBT)" />
                                       <asp:BoundField DataField="reg_no" HeaderText="पंजीकरण संख्या (PMKS)" />
                                       <asp:BoundField DataField="Farmer_Name" HeaderText="किसान का नाम" />
                                       <asp:BoundField DataField="Father_Name" HeaderText="पिता/पति का नाम" />
                                       <asp:BoundField DataField="MobileNo" HeaderText="मोबाइल नंबर" />
                                       <asp:BoundField DataField="BankName" HeaderText="Bank" Visible="false"/>
                                       <asp:BoundField DataField="IFSC_Code" HeaderText="आईएफएससी कोड" />
                                       <asp:BoundField DataField="AccountNo" HeaderText="खाता संख्या" />
                                       <asp:BoundField DataField="NoOfInstallments" HeaderText="किस्त" />
                                       <asp:BoundField DataField="RntAmount" HeaderText="वापसी रकम" />
					<asp:BoundField DataField="Reason" HeaderText="Reason" />
                                   </Columns>
                               </asp:GridView>

                           </ContentTemplate>
                        </asp:UpdatePanel>
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

