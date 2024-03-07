<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="DistrictWisePVData.aspx.cs" Inherits="DBT_DistrictWisePVData" EnableEventValidation="false" %>

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
        <asp:Label ID="lblMsg" runat="server" Text="Physical Verification Data Report"></asp:Label> :-         
        <%-- <asp:Button ID="Button1" runat="server" Text="Export Excel" OnClick="Button1_Click" />--%>

    </div><br />

    <div>

        <div class="table-responsive"> 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                                    <asp:GridView ID="gvdata" runat="server" Width="100%" CssClass="table table-bordered table-striped"
                                        AutoGenerateColumns="False" OnPreRender="gvdata_PreRender"
                                         EmptyDataText="There are no data records to display.">  
                                        <Columns> 
                                             <asp:TemplateField HeaderText="SN" >
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                                            <asp:BoundField DataField="DistName" HeaderText="Distrit Name"  />
						    
                                            <asp:BoundField DataField="Total" HeaderText="Total"  />  
                                            <asp:BoundField DataField="Ineligible" HeaderText="Ineligible" />  
                                            <asp:BoundField DataField="Eligible" HeaderText="Eligible"  />  
                                            <asp:BoundField DataField="Death" HeaderText="Death"  />
                                             <asp:BoundField DataField="DeathDAO" HeaderText="Death by DAO"  /> 
                                            <asp:BoundField DataField="IneligibleDAO" HeaderText="Ineligible by DAO" /> 
                                            <asp:BoundField DataField="DAO_Status" HeaderText="DAO Verifyed" /> 
                                         
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

