<%@ Page Title="" Language="C#" MasterPageFile="COMasterPage.master" AutoEventWireup="true" CodeFile="UpdateVillage.aspx.cs" Inherits="DAO_UpdateVillage" %>

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
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">गांव का नाम नहीं रहने के कारण भारत सरकार के द्वारा लोटया गया डेटा का लिस्ट गांव का नाम भरने के लिए</div><br />
    

    <div class="row">
        <table>
            <tr>
                <td>
            <label>Block :</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> </td>
      

        <td>
            <label>Panchayat :</label>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select"
                 ValidationGroup="s">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </td>

        <td> 
             &nbsp;
  <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-info" OnClick="btnShow_Click"  /> 
</td><td> 
             &nbsp;
  <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click"  Visible="false" /> 
</td>
      </tr></table>   
        <div class="input-group mb-3 col-lg-4">
             &nbsp;
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    </div>
    <div class="form-row">
    </div>

        <div >
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found"  
                CssClass="table table-bordered  table-striped" OnPreRender="gvdata_PreRender"
           AutoGenerateColumns="false" Font-Size="12px" OnRowDataBound="gvdata_RowDataBound" DataKeyNames="PanchayatCode,Registration_ID">
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" Text="Select all" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkDetails" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="blockname" HeaderText="Block Name" />
                <asp:BoundField DataField="panchayatname" HeaderText="Panchayat Name" />
                <asp:TemplateField HeaderText="Village">
                    <ItemTemplate>
                        <div >
                            <asp:DropDownList ID="ddlVillage" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                            
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="PanchayatCode" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblPanchayatCode" runat="server" Text='<%#Eval("PanchayatCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PMKS_Reg_No" HeaderText="PMKS_Reg_No" />
                <asp:TemplateField HeaderText="Registration Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("Registration_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                <asp:BoundField DataField="Father_Husband_Name" HeaderText="Father/Husband Name" />
               
               
                
               
             
                
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

