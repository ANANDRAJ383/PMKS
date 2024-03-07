<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="PMkisanSocialAuditData.aspx.cs" Inherits="ADM_DieselReport" EnableEventValidation = "false"%>

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
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Daily Report <asp:Label ID="lblRType" runat="server" ></asp:Label></div><br />

    <div class="row">
        <div class="input-group mb-3 col-lg-4">
            <label>Report Type :</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged" >
                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                <asp:ListItem Value="1" >Block Wies 100% Physical Verification Done</asp:ListItem>
                <asp:ListItem Value="2" >Panchayat Wies100% Physical Verification Done</asp:ListItem>
                <asp:ListItem Value="3" >District wies Ankeshan</asp:ListItem>
                
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

        

        <div class="input-group mb-3 col-lg-4">
             
  <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
             <asp:Button ID="btnExport" runat="server" Text="Export To Excel" CssClass="btn btn-success" Visible="false" OnClick="btnExport_Click" />
                    
        </div>

        <div class="input-group mb-3 col-lg-4">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel> 
</div>
    </div>

    <div class="form-row">
    </div>

        <div >
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                              
                               <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-striped"
                                   AutoGenerateColumns="true" Font-Size="12px" OnPreRender="gvdata_PreRender">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <%--<asp:BoundField DataField="DistName" HeaderText="District Name" />
                                       <asp:BoundField DataField="total" HeaderText="TotalApp" />
                                       <asp:BoundField DataField="Verified" HeaderText="Total Verified" />--%>

                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>

                               <asp:GridView ID="GridPanOld" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-striped"
                                   AutoGenerateColumns="false" Font-Size="12px" OnPreRender="GridPanOld_PreRender">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="DistName" HeaderText="District Name" />
                                       <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                                       <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" />
                                       <asp:BoundField DataField="total" HeaderText="Total" />
                                       <asp:BoundField DataField="Verified" HeaderText="Verified" />
                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>

                               <asp:GridView ID="GridAnk" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-striped" OnPreRender="GridAnk_PreRender"
                                   AutoGenerateColumns="false" Font-Size="12px">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="Distname" HeaderText="District Name" />
                                       <asp:BoundField DataField="NoOfFarmer" HeaderText="Total" />
                                       <asp:BoundField DataField="NoofVillage" HeaderText="NoofVillage" />
                                       <asp:BoundField DataField="RevVillCovered" HeaderText="RevVillCovered" />                                       
                                       <asp:BoundField DataField="BenifAuditCompleted" HeaderText="BenifAuditCompleted" />
                                       <asp:BoundField DataField="IneliglibleBenif" HeaderText="IneliglibleBenif" />
                                       <asp:BoundField DataField="EligibleNonBenif" HeaderText="EligibleNonBenif" /> 
                                       <asp:BoundField DataField="EnterDate" HeaderText="EnterDate" />
                                       
                                   
                                   </Columns>
                                   <RowStyle />
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

