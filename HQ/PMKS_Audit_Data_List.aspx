<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="PMKS_Audit_Data_List.aspx.cs" Inherits="LoginList" EnableEventValidation="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <!-- Bootstrap -->
    <link href="../cssPMKS/bootstrap.min.css" rel="stylesheet" />
    <!-- Datatables-->
    <link href="../cssPMKS/dataTables.bootstrap4.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   
<div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Print Application for Audit </div><br />
    

    <div class="row">
        <div class="input-group mb-3 col-lg-3">
            <label>District :</label>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlDist" runat="server" CssClass="form-select">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>
        
         <div class="input-group mb-3 col-lg-2">
             &nbsp;
  <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click"  /> 
</div>
        
        
   </div>

<div class="form-row">
    <div class="input-group mb-3 col-lg-6">
             &nbsp;
        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    </div>

        <div >
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                CssClass="table table-bordered table-striped"
            DataKeyNames="BiharRegNo" AutoGenerateColumns="false"    Font-Size="12px" OnPreRender="gvdata_PreRender">
            <Columns>
              
                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Registration Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("BiharRegNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Document">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("LPCPath")%>'
                            Target="_blank" ImageUrl="../images/DocView.png" ImageWidth="60px" Height="60px">View</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Application Detail"  HeaderStyle-ForeColor="#FF3300">
                <ItemTemplate>
                    <asp:Button ID="btnViewDetail" Text="Print" runat="server" OnClick="btnViewDetail_Click"  class="btn btn-success" />
                </ItemTemplate>
            </asp:TemplateField>
               
            </Columns>
            <RowStyle />
        </asp:GridView>
                               </ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

     <!-- jQuery and Bootstrap JS files -->
    <script src="../JsPMKS/jquery-3.4.1.js"></script>


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

