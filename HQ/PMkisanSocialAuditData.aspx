<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="PMkisanSocialAuditData.aspx.cs" Inherits="ADM_DieselReport" EnableEventValidation = "false"%>

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
            <table>
                <tr>
                    <td>Report Type</td>
                    <td> <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged" >
                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                <asp:ListItem Value="1" >District Wies 100% Physical Verification Done</asp:ListItem>
                <asp:ListItem Value="2" >Panchayat Wies100% Physical Verification Done</asp:ListItem>
                <asp:ListItem Value="3" >District wies Ankeshan</asp:ListItem>                
            </asp:DropDownList></td>
                    <td><asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
             <asp:Button ID="btnExport" runat="server" Text="Export To Excel" CssClass="btn btn-success" Visible="false" OnClick="btnExport_Click" /></td>
                </tr>
            </table>
            
        </div>

        

        <div class="input-group mb-3 col-lg-4">
             
  
                    
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
                              
                               <asp:GridView ID="gvdata" runat="server" 
                                   CssClass="table table-bordered table-striped" AutoGenerateColumns="false"
                                  ShowFooter="True" EmptyDataText="There are no data records to display." 
                                   OnRowDataBound="gvdata_RowDataBound" Font-Size="10">
                                   <Columns>

                                        <asp:TemplateField HeaderText="Sl No" HeaderStyle-Width="8%" HeaderStyle-Font-Bold="true"
                                HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" Width="8%" />
                            </asp:TemplateField>
                                       <asp:TemplateField HeaderText="District Name" HeaderStyle-HorizontalAlign="Left"
                                HeaderStyle-Width="15%" HeaderStyle-BorderWidth="1" HeaderStyle-Font-Bold="true"
                                HeaderStyle-BorderColor="ActiveBorder">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkDist" runat="server" Text='<%#Eval("DistName") %>' Font-Underline="false"
                                        ForeColor="Blue"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" BorderStyle="Solid" BorderColor="#999999" />
                                <ItemStyle HorizontalAlign="Center" ForeColor="Black" />
                                <FooterTemplate>
                                    <asp:Label ID="lblTot" runat="server" Text='Total' Font-Bold="true" Font-Size="Medium"
                                        Style="float: right;"></asp:Label>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Right" ForeColor="Red" />
                            </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Total Beneficiary" HeaderStyle-HorizontalAlign="center"
                                HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalBen" Text='<%#Eval("total")%>' runat="server" Style="float: right;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle BorderColor="#999999" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Center"
                                    BorderStyle="Solid" />
                                <ItemStyle HorizontalAlign="Right" Width="12px" ForeColor="Black" />
                                <FooterTemplate>
                                    <asp:Label ID="lblTotalBen" runat="server" Text='0' Font-Bold="true" Font-Size="Medium"
                                        Style="float: right;"></asp:Label>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Right" ForeColor="Black" />
                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Verified" HeaderStyle-HorizontalAlign="center"
                                HeaderStyle-Font-Bold="true" HeaderStyle-BorderColor="ActiveBorder" HeaderStyle-BorderWidth="1">
                                <ItemTemplate>
                                    <asp:Label ID="lblVerified" Text='<%#Eval("Verified")%>' runat="server" Style="float: right;"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle BorderColor="#999999" BorderWidth="1px" Font-Bold="True" HorizontalAlign="Center"
                                    BorderStyle="Solid" />
                                <ItemStyle HorizontalAlign="Right" Width="12px" ForeColor="Black" />
                                <FooterTemplate>
                                    <asp:Label ID="lblVerified" runat="server" Text='0' Font-Bold="true" Font-Size="Medium"
                                        Style="float: right;"></asp:Label>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Right" ForeColor="Black" />
                            </asp:TemplateField>
                                       
                                    

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
                                       <asp:BoundField DataField="Verified" HeaderText="VerifiedDeath" />
                                       <asp:BoundField DataField="VerifiedEligible" HeaderText="VerifiedEligible" />
                                       <asp:BoundField DataField="VerifiedIneligible" HeaderText="VerifiedIneligible" />
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


                               <asp:GridView ID="GridViewPDayspending" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-bordered  table-striped"
                                   AutoGenerateColumns="false" Font-Size="12px">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="distName" HeaderText="District Name" />
                                       <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                                       <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" />
                                        <asp:BoundField DataField="Name" HeaderText="AC Name" />
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />                                       
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />  
                                       <asp:BoundField DataField="ACSubsidyLandArea" HeaderText="ACApprovedLand" />
                                       <asp:BoundField DataField="ACPendinggRETER8DAYS" HeaderText="ACPending > 12 DAYS" />
                                       <asp:BoundField DataField="ACPendingWithin8DAYS" HeaderText="ACPending < 12 DAYS" />
                                        
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

