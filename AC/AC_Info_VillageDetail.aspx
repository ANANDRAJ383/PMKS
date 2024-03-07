<%@ Page Title="" Language="C#" MasterPageFile="ACMasterPage.master" AutoEventWireup="true" CodeFile="AC_Info_VillageDetail.aspx.cs" Inherits="DAO_RefundDetailForm" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="JavaScript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt;
            var charCode = e.which || e.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert('Enter Numbers Only');
                return false;
            }
            return true;
        }
    </script>
      <!-- Bootstrap -->
    <link href="../cssPMKS/bootstrap.min.css" rel="stylesheet" />
    <!-- Datatables-->
    <link href="../cssPMKS/dataTables.bootstrap4.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Fill Your Details With Village </div><br />
   <div >

        <div class="row" id="divRow" runat="server" visible="true">
            <div class="col-12 col-sm-4 col-md-4 mb-3">
             <div class="form-group">
                                <label"><b>Name</b> <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="Disabled form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                </div>
            <div class="col-12 col-sm-4 col-md-4 mb-3">
            <div class="form-group">
                                <label ><b>Mobile Number</b> <span class="mandatory">*</span>  </label>
                               <asp:TextBox ID="txtMobileNo" runat="server" CssClass="Disabled form-control" MaxLength="10" ReadOnly="true" onkeypress="return onlyNumbers();"></asp:TextBox>
                            </div>
                </div>
            <div class="col-12 col-sm-4 col-md-4 mb-3">
             <div class="form-group">
                                <label ><b>eMail Id</b><span class="mandatory">*</span> </label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="Disabled form-control"></asp:TextBox>
                            </div>
                </div>
            <div class="col-12 col-sm-4 col-md-4 mb-3">
            <div class="form-group">
                                <label ><b>Name as per Aadhaar</b><span class="mandatory">*</span> </label>
                                <asp:TextBox ID="txtNameInAadhaar" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                </div>
            <div class="col-12 col-sm-4 col-md-4 mb-3">
            <div class="form-group">
                                <label ><b>Aadhaar Number</b> <span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtAadhaarNo" runat="server" MaxLength="12" CssClass="Disabled form-control"  onkeypress="return onlyNumbers();" ></asp:TextBox>
                            </div>
                </div>
            <div class="col-12 col-sm-4 col-md-4 mb-3">
             <div class="form-group">
                                <label ><b>Village Name</b><span class="mandatory">*</span></label>
                                <asp:CheckBoxList ID="chkVillage" runat="server" CssClass="form-select" ></asp:CheckBoxList>
                            </div>
                </div>
             <div class="col-lg-4 ">
                                <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSave_Click"  />
                            </div>

                    </div>
       <div >
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
       <div class="m-1">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF"></asp:Label>
                            <asp:GridView ID="gvdata" runat="server" Width="100%" CssClass="table table-bordered table-striped"
                                AutoGenerateColumns="False" OnPreRender="gvdata_PreRender"
                                EmptyDataText="There are no data records to display.">
                                <Columns>
                                    <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1+"." %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DistName" HeaderText="District Name" />
                                    <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                                    <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" />
                                    <asp:BoundField DataField="VillageName" HeaderText="Village Name" />
                                    <asp:BoundField DataField="NameInAadhaar" HeaderText="Name" />
                                    <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                                    <asp:BoundField DataField="EmailId" HeaderText="EmailId" />
                                    <asp:BoundField DataField="AadhaarNo" HeaderText="AadhaarNo" />


                                </Columns>
                            </asp:GridView>
                        </div>
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
                    },{
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

