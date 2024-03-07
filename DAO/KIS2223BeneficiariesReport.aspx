<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="KIS2223BeneficiariesReport.aspx.cs" Inherits="DAO_KIS2223BeneficiariesReport" %>

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
<div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #1C6794; padding: 5px; margin-top: 5px; width: 100%;" align="center">Beneficiaries List of Krishi Input Subsidy-2022-23 </div><br />
    <table class="table-bordered  table table-striped " style="width: 100%;">
            <tr>
                <td>Block</td>
                <td>
                     <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional"  >
                           <ContentTemplate>
                    <asp:DropDownList ID="ddlblock" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlblock_SelectedIndexChanged">
                    </asp:DropDownList>
                               </ContentTemplate>
                         </asp:UpdatePanel>
                </td>
                <td>Panchayat</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                    <asp:DropDownList ID="ddlpanchayat" runat="server" CssClass="form-select">                     
                    </asp:DropDownList>
                               </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
                 <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" />
                 </td>
                </tr>
        <tr>
            <td colspan="6">
                 <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/excel.jpg" Height="22px" Width="33px" Visible="False" OnClick="ImageButton1_Click"/>
            </td>
        </tr>
        </table>
    <div class="table-responsive"> 
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                               <asp:GridView ID="gvdata" runat="server" Width="100%" CssClass="table table-striped" Font-Size="10px"
                                   AutoGenerateColumns="False"  EmptyDataText="There are no data records to display.">
                                   <Columns>

                                       <asp:TemplateField HeaderText="Sl. No.">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField> 
                                       <asp:BoundField DataField="application_id" HeaderText="Application ID"  HeaderStyle-Font-Size="12px"/>
                                       <asp:BoundField DataField="ApplicantName" HeaderText="Farmer Name"  HeaderStyle-Font-Size="12px"/>
                                       <asp:BoundField DataField="Father_Husband_Name" HeaderText="Father/Husband Name"  HeaderStyle-Font-Size="12px"/>
                                       <asp:BoundField DataField="Blockname" HeaderText="Block Name"  HeaderStyle-Font-Size="12px"/>
                                       <asp:BoundField DataField="panchayatname" HeaderText="Panchayat Name"  HeaderStyle-Font-Size="12px"/>
                                       <asp:BoundField DataField="VillageName" HeaderText="Village Name"  HeaderStyle-Font-Size="12px"/>
                                       <asp:BoundField DataField="ADM_ApprovedAmnt" HeaderText="Approved Amount"  HeaderStyle-Font-Size="12px"/> 
                                   </Columns>
                               </asp:GridView>

                           </ContentTemplate>
                        </asp:UpdatePanel>
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

