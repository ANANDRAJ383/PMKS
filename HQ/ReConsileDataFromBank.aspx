<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="ReConsileDataFromBank.aspx.cs" Inherits="HQ_ReConsileDataFromBank" %>

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
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">एसएलबीसी डेटा सूची से कटौती की राशि </div><br />
    <div>
    <table class="table-bordered  table table-striped " style="width: 100%;">
        <tr>
            <td>ज़िला</td>
            <td><asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select">
            </asp:DropDownList></td>
            <td><asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" /></td>
        </tr>
    </table>
        </div>
    <div class="input-group mb-3 col-lg-4">
             &nbsp;
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    <div>
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                 CssClass="table table-bordered table-striped" OnPreRender="gvdata_PreRender"
            DataKeyNames="Registration_ID" AutoGenerateColumns="false"  Font-Size="10px" >
            <Columns>
               
                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DistName" HeaderText="District Name" />
                <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" />
                <asp:BoundField DataField="VILLNAME" HeaderText="Village Name" />
                <asp:TemplateField HeaderText="Registration Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("Registration_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PM_RegNo" HeaderText="PMK RegNo" />
                <asp:BoundField DataField="FarmerName" HeaderText="Applicant Name" />
                <asp:BoundField DataField="Father_Husband_Name" HeaderText="Father/Husband Name" />
                <asp:BoundField DataField="IFSC_Code" HeaderText="IFSC Code" />
                <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" />
                <%--<asp:TemplateField HeaderText="Bank Detail">
                    <ItemTemplate>
                        <strong>Account Number: </strong>
                        <%#Eval("AccountNumber")%><br />
                        <strong>IFSC Code: </strong>
                        <%#Eval("IFSC_Code")%><br />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                
               <asp:BoundField  DataField="Amount" HeaderText="Amount" />
               <asp:BoundField  DataField="INSTALLMENT" HeaderText="INSTALLMENT" />
                 <asp:BoundField  DataField="ReasonofIneligibility" HeaderText="Reason of Ineligibility" />
               <asp:BoundField  DataField="MobileNo" HeaderText="MobileNo" />
                <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Button ID="btnViewDetail" Text="Done" runat="server"   class="btn btn-success"/>
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

