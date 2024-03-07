<%@ Page Title="" Language="C#" MasterPageFile="~/MainSite.master" AutoEventWireup="true" CodeFile="AdminIncPagePMKS.aspx.cs" Inherits="AgricultureDept.AdminIncPage" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="panel panel-success">
      <div class="panel-heading" style="font-weight:bold;font-size:14px;">Enter Passcode</div>
      <div class="panel-body" style="font-size:12px;">
          <center>
          <table class="table-bordered  table table-striped " >
              <tr>
                  <td>Passcode:</td>
                  <td>
                      <asp:TextBox runat="server" ID="txtPassode" TextMode="Password" class="form-control"></asp:TextBox>
                  </td>
                  <td>   <asp:Button ID="btnLogIn" runat="server" Text="Proceed"  Font-Bold="True"   class="btn btn-success" OnClick="btnLogIn_Click" /></td>
              </tr>

          </table>
              </center>
          </div> 
         </div> 


    <asp:Panel ID="pnl1" runat ="server" Visible="false" >
         <div class="panel panel-success">
      <div class="panel-heading" style="font-weight:bold;font-size:14px;">SQL QUERY WINDOW</div>
      <div class="panel-body" style="font-size:12px;">
    <table width ="100%">
        <tr>
            <td width="20%" valign="top">
                  <asp:Button ID="Button1" runat="server" Text="Get Table" OnClick="Button1_Click" />

    <asp:GridView ID="grd1" runat="server" ></asp:GridView>
            </td>

             <td width="100%" valign="top">
                 <asp:TextBox TextMode="MultiLine" Width="900px" Height="300px" runat="server" ID="txt1" ></asp:TextBox>
                   <asp:Button ID="Button2" runat="server" Text="Get Data" OnClick="Button2_Click" />

    <asp:GridView ID="GridView1" runat="server"  CssClass="table table-bordered  table-striped" OnPreRender="gvdata_PreRender"></asp:GridView>
             </td>
        </tr>
       
    </table>

   
          <table>
               <tr>
              <td>
                  <asp:GridView ID="GridView4" runat="server"></asp:GridView>
              </td>
          </tr>
          </table>
         </asp:Panel>
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
            0 !== $('#<%= GridView1.ClientID %>').length &&
                $('#<%= GridView1.ClientID %>').DataTable({
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
            $('#<%= GridView1.ClientID %>').dataTable();
        });
        TableManageButtons.init();
    </script>
</asp:Content>
