<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="RecoveryEntryListForReConcile.aspx.cs" Inherits="ADM_ReconcileList" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Bootstrap -->
    <link href="../cssPMKS/bootstrap.min.css" rel="stylesheet" />
    <!-- Datatables-->
    <link href="../cssPMKS/dataTables.bootstrap4.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="margin: 30px 50px 10px 50px;">

        <div class="row">
            <!-- Revenue breakdown chart example-->
            <div class="col-lg-12 ">
                <div class="card card-raised h-100">
                    <div class="card-header bg-transparent px-4">
                        <div class="d-flex justify-content-between align-items-center">
                            <div class="me-4">
                                <h2 class="card-title mb-0"><b>RECOVERY ENTRY LIST FOR RECONCILE (NEW)</b></h2>
                            </div>

                        </div>
                    </div>

                    <div class="row mb-3 m-2">
                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>District</b> <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Block</b> <span class="mandatory">*</span>  </label>
                                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 col-sm-3 col-md-3 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Panchyat</b><span class="mandatory">*</span> </label>
                                <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select" 
                                    OnSelectedIndexChanged="ddlPanchayat_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Village</b><span class="mandatory">*</span> </label>
                                <asp:DropDownList ID="ddlVillage" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <div class="form-group">
                               <label class="control-label" ><b>वापसी का खाता</b> <span class="mandatory">*</span></label>         

                     <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="form-select" >
                            <asp:ListItem Value="">-- Select --</asp:ListItem>
                            <asp:ListItem Value="1">भारत कोष</asp:ListItem>
                        <asp:ListItem Value="2">कृषि निदेशक खाता संख्या (40903138323, IFSC: SBIN0006379)</asp:ListItem>                       
                            <asp:ListItem Value="3">प्रसानिक मद-खाता संख्या (38269533475, IFSC: SBIN0006379)</asp:ListItem>
                    <asp:ListItem Text="अन्य कारणों से अयोग्य घोषित किसान खाता संख्या (40903140467, IFSC: SBIN0006379)" Value="4"></asp:ListItem>                   
                        </asp:DropDownList>
                            </div>
                        </div>
			
  <div class="row ">
                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <div class="form-group">
                                 <label class="control-label"><b>From Date</b><span class="mandatory">*</span></label>
                           <div class="input-group">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-text" id="basic-addon2">
                                    <rjs:popcalendar ID="PopCalendar1" runat="server" Control="txtDate" Format="dd mmm yyyy" To-Today="true" />
                                </span>
                                </div>
                            </div>
                        </div>

                        <div class="col-12 col-sm-2 col-md-2 mb-3">
                            <label class="control-label"><b>To Date</b><span class="mandatory">*</span></label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control"></asp:TextBox>
                                        <span class="input-group-text" id="basic-addon1">
                                            <rjs:popcalendar ID="PopCalendar2" runat="server" Control="txtToDate" Format="dd mmm yyyy" To-Today="true" />
                                        </span>

                                    </div>
                        </div>

                        <div class="col-12 col-sm-3 col-md-3 mb-3">
                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-primary" OnClick="btnShow_Click" />
                            </div>
                        </div>

                         <div class="col-12 col-sm-3 col-md-3 mb-3">
                            <div class="form-group">
                                <br />
                                <asp:Button ID="btnUpdate" runat="server" Text="Approve" CssClass="btn btn-primary" OnClick="btnUpdate_Click" Visible="false" />
                            </div>


                        

                    </div>
                                                </div>

                    </div>

                    <div class="m-1" style="overflow-x:scroll;">
                        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
                        <asp:GridView ID="gvdata" runat="server" Width="100%" CssClass="table table-bordered table-striped" DataKeyNames="reg_no"
                                   AutoGenerateColumns="False" onpageindexchanging="gvdata_PageIndexChanging" AllowPaging="true" PageSize="10"
                                   EmptyDataText="There are no data records to display." OnRowDataBound="gvdata_RowDataBound">
                                   <Columns>
                                       <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" Text="Select all" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkDetails" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                </asp:TemplateField>
                                       <asp:TemplateField HeaderText="क्रम संख्या">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="DistrictName" HeaderText="जिला" />
                                       <asp:BoundField DataField="BlockName" HeaderText="प्रखंड" Visible="false" />
                                       <asp:BoundField DataField="PanchayatName" HeaderText="पंचायत" Visible="false" />
                                       <asp:BoundField DataField="RevenueVillageName" HeaderText="ग्राम" Visible="false" />
                                       <asp:BoundField DataField="Registration_Id" HeaderText="पंजीकरण संख्या (DBT)" Visible="false"/>
                                       <asp:TemplateField HeaderText="पंजीकरण संख्या (PMKS)">
                                           <ItemTemplate>
                                               <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("reg_no") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="reg_no" HeaderText="पंजीकरण संख्या (PMKS)" Visible="false" />
                                       <asp:BoundField DataField="Farmer_Name" HeaderText="किसान का नाम" />
                                       <asp:BoundField DataField="Father_Name" HeaderText="पिता/पति का नाम" Visible="false"/>
                                       <asp:BoundField DataField="MobileNo" HeaderText="मोबाइल नंबर" />
                                       <asp:BoundField DataField="NoOfInstallments" HeaderText="किस्त" />
                                       <asp:BoundField DataField="RntAmount" HeaderText="वापसी रकम" />
                                       <asp:BoundField DataField="PaymentReturnAC" HeaderText="भुगतान वापसी ए.सी"  Visible="false"/>
                                       <asp:BoundField DataField="TransactionNo" HeaderText="ट्रांजेक्शन नंबर" />
                                       <asp:BoundField DataField="TransactionDate" HeaderText="ट्रांजेक्शन दिनांक"  DataFormatString="{0:MM/dd/yyyy}"  />                                       
                                       <asp:BoundField DataField="PaymentReturnMode" HeaderText="वापसी का तरीका" />
					                    <asp:BoundField DataField="IsLean" HeaderText="IsLean" Visible="false"/>
					                    <asp:BoundField DataField="UpdateRole" HeaderText="Action By" />
				                        <asp:BoundField DataField="Reason" HeaderText="कारण" />
                                        <asp:BoundField DataField="ReasonDetails" HeaderText="अयोग्य के कारण"  Visible="false"/>
                                       <asp:TemplateField HeaderText="ट्रांजेक्शन रसीद">
                                           <ItemTemplate>
                                               <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("DocPath")%>'
                                                   Target="_blank">View Doc</asp:HyperLink>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       
                                       <asp:TemplateField HeaderText="Action">
                                           <ItemTemplate>
                                               <asp:DropDownList ID="ddlApproved" runat="server" CssClass="form-select">
                                                   <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                                   <asp:ListItem Value="Y">Accept</asp:ListItem>
                                                   <asp:ListItem Value="N">Reject</asp:ListItem>
                                               </asp:DropDownList>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Payment Return Account">
                                           <ItemTemplate >
                                               <asp:DropDownList ID="ddlPaymentType1" runat="server" >
                                                   <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                   <asp:ListItem Value="1">भारत कोष</asp:ListItem>
                                                   <asp:ListItem Value="2">कृषि निदेशक खाता संख्या (40903138323, IFSC: SBIN0006379)</asp:ListItem>
                                                   <asp:ListItem Value="3">प्रसानिक मद-खाता संख्या (38269533475, IFSC: SBIN0006379)</asp:ListItem>
                                                   <asp:ListItem Text="अन्य कारणों से अयोग्य घोषित किसान खाता संख्या (40903140467, IFSC: SBIN0006379)" Value="4"></asp:ListItem>
                                               </asp:DropDownList>
                                           </ItemTemplate>
                                          
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Part Payment">
                                           <ItemTemplate>
                                               <asp:DropDownList ID="ddlPartPayment" runat="server" CssClass="form-select">
                                                   <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                                   <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                   <asp:ListItem Value="N">No</asp:ListItem>
                                               </asp:DropDownList>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Part Payment Installment" >
                                           <ItemTemplate>
                                               <asp:TextBox id="txtPartPaymentInstallment" runat="server"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Remarks" >
                                           <ItemTemplate>
                                               <asp:TextBox id="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                     
                                   </Columns>
                               </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- jQuery and Bootstrap JS files -->
    <script src="../JsPMKS/jquery-3.4.1.js"></script>


    <!-- Datatables-->
    <!--<script src="../JsPMKS/jquery.dataTables.min.js"></script>-->
    <!--<script src="../JsPMKS/dataTables.bootstrap4.min.js">
    </script>-->
    <!--<script src="../JsPMKS/dataTables.buttons.min.js">
    </script>-->
    <!--<script src="../JsPMKS/buttons.bootstrap4.min.js">
    </script>-->
    <!--<script src="../JsPMKS/jszip.min.js"></script>-->
    <!--<script src="../JsPMKS/pdfmake.min.js"></script>-->
    <!--<script src="../JsPMKS/vfs_fonts.js"></script>-->
    <!--<script src="../JsPMKS/buttons.html5.min.js"></script>-->
    <!--<script src="../JsPMKS/buttons.print.min.js"></script>-->
    <!--<script src="../JsPMKS/buttons.colVis.min.js"></script>-->
    <!--<script src="../JsPMKS/datatables-init.js"></script>-->

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

