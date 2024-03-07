<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="ReconsileList.aspx.cs" Inherits="HQ_RecoveredListBy_DAO" %>

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
     <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center"> PM Kisan Reconsile List by Bunty/Nitish</div><br />
    <div class="table-responsive">
        <table>
            <tr>
                <td>District</td>
                <td><asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select">
            </asp:DropDownList></td>
                <td>Payment Mode</td>
                <td>
                    <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="form-select">
                        <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                        <asp:ListItem Value="ITR">Income Tax Payee Farmer</asp:ListItem>
                        <asp:ListItem Value="OTH">Ineligible Farmer</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Reconsile Mode</td>
                <td>
                    <asp:DropDownList ID="ddlApproved" runat="server" CssClass="form-select">
                        <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                        <asp:ListItem Value="Y">Matched</asp:ListItem>
                        <asp:ListItem Value="N">Not Matched </asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td><asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click"  /></td>
            </tr>
            
        </table>
    </div>
    <div class="input-group mb-3 col-lg-4">
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    <div class="table-responsive">
          
        <asp:GridView ID="gvdata" runat="server" CssClass="table table-bordered table-striped"
                                   AutoGenerateColumns="False" OnPreRender="gvdata_PreRender"
                                   EmptyDataText="There are no data records to display." Font-Size="10px" DataKeyNames="RegistrationId">
            <Columns>
                
                <asp:TemplateField HeaderText="क्रम संख्या">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DistrictName" HeaderText="जिला" />
                <asp:BoundField DataField="BlockName" HeaderText="प्रखंड" />
                <asp:BoundField DataField="PanchayatName" HeaderText="पंचायत" />
                <asp:BoundField DataField="RevenueVillageName" HeaderText="गावं" />
                 <asp:BoundField DataField="RegistrationId" HeaderText="पंजीकरण संख्या (DBT)" />
                 <asp:BoundField DataField="reg_no" HeaderText="पंजीकरण संख्या (PMKS)" />
               <asp:BoundField DataField="Farmer_Name" HeaderText="किसान का नाम" />
                <asp:BoundField DataField="Father_Name" HeaderText="पिता/पति का नाम" />
                <asp:BoundField DataField="AccountNo" HeaderText="खाता संख्या" />
                <asp:BoundField DataField="NoOfInstallments" HeaderText="किस्त" />
                <asp:BoundField DataField="RntAmount" HeaderText="वापसी रकम" />
                <asp:BoundField DataField="AmountReturn" HeaderText="वापसी रकम किसान के द्वारा " />
                <asp:BoundField DataField="PaymentMode" HeaderText="तरीका" />
                <asp:BoundField DataField="TransactionNo" HeaderText="यू०टी०र नंबर (Trans No)" />
                <asp:BoundField DataField="TranDate" HeaderText="यू०टी०र दिनांक (Trans Date)" />
                
               <asp:TemplateField HeaderText="दस्तावेज़">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("TranSacAttachment")%>'
                            Target="_blank">View</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                 
            </Columns>
            <RowStyle />
        </asp:GridView>
                             
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

