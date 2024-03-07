<%@ Page Title="" Language="C#" MasterPageFile="ADM.master" AutoEventWireup="true" CodeFile="Diesel2324BlockWise.aspx.cs" Inherits="HQ_Diesel2324" EnableEventValidation = "false"%>

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
      <div style="font-family: Cambria; font-size: 22px; color:white; font-weight: bold;
        background-color: #1C6794; padding: 5px; margin-top: 5px; width: 100%;" align="center">Download Diesel Subsidy Block Wise Data 2023-24 :- <asp:Label ID="lblDistrict" runat="server"></asp:Label></div><br />

        <div class="row">
             
             <div class="input-group mb-3 col-lg-6">
 <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true"
                OnPreRender="GridView_PreRender"
                CssClass="table table-striped">
            </asp:GridView>
            <asp:Button ID="dslbtn" runat="server" Text="Diesel Sub-2023-24(report)" CssClass="btn btn-success" OnClick="dslbtn_Click" />
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
            0 !== $('#<%= GridView2.ClientID %>').length && 
                  $('#<%= GridView2.ClientID %>').DataTable({
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
            $('#<%= GridView2.ClientID %>').dataTable();
        });
        TableManageButtons.init();
    </script>
</asp:Content>

