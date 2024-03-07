<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="PMKTargetEntry.aspx.cs" Inherits="Reconcile_SAO_eKYCTarget" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row mt-3">
        <h3 style="margin-top:10px">पीएम-किसान कार्य की प्रविष्टि </h3>
        <div class="col-12 col-sm-3">
            <div class="form-group">
                <label class="control-label"><b>District</b></label>
                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            </div>
        <div class="col-12 col-sm-3">
                <div class="form-group">
                    <label class="control-label"><b>Sub Divison</b> </label>
                    <asp:DropDownList ID="ddlSubDivison" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                </div>
            </div>
        <div class="col-12 col-sm-3">
                <div class="form-group">
                    <label class="control-label"><b>Entry For</b> </label>
                    <asp:DropDownList ID="ddlEntryFor" runat="server" CssClass="form-select">
                        <asp:ListItem Selected="True" Value="0" Text="--Select--"></asp:ListItem>
                        <asp:ListItem Value="eKYC" Text="eKYC"></asp:ListItem>
                        <asp:ListItem Value="NPCI" Text="NPCI"></asp:ListItem>
                        <asp:ListItem Value="Recovery" Text="Recovery"></asp:ListItem>
                        <asp:ListItem Value="PV" Text="Physical Verification"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        <div class="col-12 col-sm-3 ">
                <div class="form-group">
                    <label class="control-label">&nbsp</label>
                    <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" />
                </div>
            </div>
        <div >
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    </div>
    
	<div class="table-responsive">
          
         <asp:GridView ID="gvdata" runat="server" Width="100%" CssClass="table table-bordered table-striped" Visible="false"
                                   AutoGenerateColumns="False" OnPreRender="gvdata_PreRender"
                                   EmptyDataText="There are no data records to display." >
                                   <Columns>
                                       <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                           <HeaderTemplate>
                                               <asp:CheckBox ID="chkAll" runat="server" Text="Select One" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" Enabled="false"/>
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
                                       <asp:BoundField DataField="districtName" HeaderText="जिला" />
                                       <asp:BoundField DataField="SDMName_En" HeaderText="अनुमण्डल" />
                                       <%--<asp:BoundField DataField="EntryFor" HeaderText="काम के प्रकार" />--%>
                                       <asp:TemplateField HeaderText="प्रखंड">
                                           <ItemTemplate>
                                               <asp:Label ID="lblBlock" runat="server" Text='<%#Eval("BlockName") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField> 
                                       <asp:TemplateField HeaderText="प्रखंड अन्तर्गत लंबित eKYC के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:Label ID="lblPending" runat="server" Text='<%#Eval("Pending") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="दिनांक 22-09-2023 तक किये गए eKYC के कुल किसानों की संख्या" Visible="false">
                                           <ItemTemplate>
                                               <asp:Label ID="lblDone" runat="server" Text='<%#Eval("Done") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField>                                   
                                       <asp:TemplateField HeaderText="गत सप्ताह में किये गए eKYC के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingLastWeek" runat="server" Text='<%#Eval("LastWeekWorkDone") %>' MaxLength="5" onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="मौजूदा सप्ताह में किये किये गए eKYC के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingCurrentWeek" runat="server" MaxLength="5" 
                                                   Text='<%#Eval("CurrentWeekWorkDone") %>' onkeypress=" return onlyNumbers();" ></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="गत सप्ताह में किये गए eKYC के कुल किसानों की %" Visible="false">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingLastWeekPer" runat="server" 
                                                  MaxLength="5" onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="मौजूदा सप्ताह में किये किये गए eKYC के कुल किसानों की %"  Visible="false">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingCurrentWeekPer" runat="server" MaxLength="5" 
                                                    onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField >
                                           <ItemTemplate>
                                               <asp:Button ID="btnSave" Text="Save" runat="server" class="btn btn-info" OnClick="btnSave_Click"/>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                   </Columns>
                               </asp:GridView>

        <asp:GridView ID="GridViewNPCI" runat="server" Width="100%" CssClass="table table-bordered table-striped" Visible="false"
                                   AutoGenerateColumns="False" 
                                   EmptyDataText="There are no data records to display.">
                                   <Columns>
                                       <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                           <HeaderTemplate>
                                               <asp:CheckBox ID="chkAll" runat="server" Text="Select One" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" Enabled="false"/>
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
                                       <asp:BoundField DataField="districtName" HeaderText="जिला" />
                                       <asp:BoundField DataField="SDMName_En" HeaderText="अनुमण्डल" />
                                      <%-- <asp:BoundField DataField="EntryFor" HeaderText="काम के प्रकार" />--%>
                                       <asp:TemplateField HeaderText="प्रखंड">
                                           <ItemTemplate>
                                               <asp:Label ID="lblBlock" runat="server" Text='<%#Eval("BlockName") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField> 
                                       <asp:TemplateField HeaderText="प्रखंड अन्तर्गत वांक्षित NPCI के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:Label ID="lblPending" runat="server" Text='<%#Eval("Pending") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="दिनांक 22-09-2023 तक किये गए NPCI के कुल किसानों की संख्या" Visible="false">
                                           <ItemTemplate>
                                               <asp:Label ID="lblDone" runat="server" Text='<%#Eval("Done") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField>                                   
                                       <asp:TemplateField HeaderText="गत सप्ताह में किये गए NPCI के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingLastWeek" runat="server" Text='<%#Eval("LastWeekWorkDone") %>' MaxLength="5" onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="मौजूदा सप्ताह में किये गए NPCI के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingCurrentWeek" runat="server" MaxLength="5" Text='<%#Eval("CurrentWeekWorkDone") %>' onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="गत सप्ताह में किये गए NPCI के कुल किसानों की %" Visible="false">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingLastWeekPer" runat="server" 
                                                    MaxLength="5" onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="मौजूदा सप्ताह में किये गए NPCI के कुल किसानों की %" Visible="false">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingCurrentWeekPer" runat="server" MaxLength="5" 
                                                    onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField >
                                           <ItemTemplate>
                                               <asp:Button ID="btnSave" Text="Save" runat="server" class="btn btn-info" OnClick="btnSave_Click"/>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                   </Columns>
                               </asp:GridView>

        <asp:GridView ID="GridViewRecovery" runat="server" Width="100%" CssClass="table table-bordered table-striped" Visible="false"
                                   AutoGenerateColumns="False" 
                                   EmptyDataText="There are no data records to display.">
                                   <Columns>
                                       <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                           <HeaderTemplate>
                                               <asp:CheckBox ID="chkAll" runat="server" Text="Select One" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" Enabled="false"/>
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
                                       <asp:BoundField DataField="districtName" HeaderText="जिला" />
                                       <asp:BoundField DataField="SDMName_En" HeaderText="अनुमण्डल" />
                                       
                                       <asp:TemplateField HeaderText="वांक्षित Recovery के कुल Installments">
                                           <ItemTemplate>
                                               <asp:Label ID="lblNoOfInstallments" runat="server" Text='<%#Eval("NoOfInstallments") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField> 
                                      
                                       <asp:TemplateField HeaderText="वांक्षित Recovery के कुल Amount">
                                           <ItemTemplate>
                                               <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField> 
                                       <asp:TemplateField HeaderText="प्रखंड">
                                           <ItemTemplate>
                                               <asp:Label ID="lblBlock" runat="server" Text='<%#Eval("BlockName") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField> 
                                       <asp:TemplateField HeaderText="प्रखंड अन्तर्गत वांक्षित Recovery के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:Label ID="lblPending" runat="server" Text='<%#Eval("Pending") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="दिनांक 22-09-2023 तक किये गए Recovery के कुल किसानों की संख्या" Visible="false">
                                           <ItemTemplate>
                                               <asp:Label ID="lblDone" runat="server" Text='<%#Eval("Done") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField>                                   
                                       <asp:TemplateField HeaderText="गत सप्ताह में किये गए Recovery के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingLastWeek" runat="server"  MaxLength="5" onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="गत सप्ताह में किये गए Recovery के कुल Amount">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingLastWeekAmount" runat="server"  MaxLength="5" onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="मौजूदा सप्ताह में किये गए Recovery के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingCurrentWeek" runat="server" MaxLength="5"  onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="मौजूदा सप्ताह में किये गए Recovery के कुल Amount">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingCurrentWeekAmount" runat="server" MaxLength="5"  onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="गत सप्ताह में किये गए Recovery के कुल किसानों की %" Visible="false">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingLastWeekPer" runat="server" 
                                                    MaxLength="5" onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="मौजूदा सप्ताह में किये गए Recovery के कुल किसानों की %" Visible="false">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingCurrentWeekPer" runat="server" MaxLength="5" 
                                                    onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField >
                                           <ItemTemplate>
                                               <asp:Button ID="btnSave" Text="Save" runat="server" class="btn btn-info" OnClick="btnSave_Click"/>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                   </Columns>
                               </asp:GridView>

         <asp:GridView ID="GridViewPV" runat="server" Width="100%" CssClass="table table-bordered table-striped" Visible="false"
                                   AutoGenerateColumns="False" 
                                   EmptyDataText="There are no data records to display.">
                                   <Columns>
                                       <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                           <HeaderTemplate>
                                               <asp:CheckBox ID="chkAll" runat="server" Text="Select One" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" Enabled="false"/>
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
                                       <asp:BoundField DataField="districtName" HeaderText="जिला" />
                                       <asp:BoundField DataField="SDMName_En" HeaderText="अनुमण्डल" />
                                       <asp:TemplateField HeaderText="प्रखंड">
                                           <ItemTemplate>
                                               <asp:Label ID="lblBlock" runat="server" Text='<%#Eval("BlockName") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField> 
                                       <asp:TemplateField HeaderText="प्रखंड अन्तर्गत वांक्षित Physical Verification के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:Label ID="lblPending" runat="server" Text='<%#Eval("Pending") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="दिनांक 22-09-2023 तक किये गए Physical Verification के कुल किसानों की संख्या" Visible="false">
                                           <ItemTemplate>
                                               <asp:Label ID="lblDone" runat="server" Text='<%#Eval("Done") %>'></asp:Label>
                                           </ItemTemplate>
                                       </asp:TemplateField>                                   
                                       <asp:TemplateField HeaderText="गत सप्ताह में किये गए Physical Verification के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingLastWeek" runat="server" Text='<%#Eval("LastWeekWorkDone") %>' MaxLength="5" onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="मौजूदा सप्ताह में किये गए Physical Verification के कुल किसानों की संख्या">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingCurrentWeek" runat="server" MaxLength="5" Text='<%#Eval("CurrentWeekWorkDone") %>' onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                        <asp:TemplateField HeaderText="गत सप्ताह में किये गए Physical Verification के कुल किसानों की %" Visible="false">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingLastWeekPer" runat="server" 
                                                   MaxLength="5" onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField HeaderText="मौजूदा सप्ताह में किये गए Physical Verification के कुल किसानों की %" Visible="false">
                                           <ItemTemplate>
                                               <asp:TextBox ID="txtPendingCurrentWeekPer" runat="server" MaxLength="5" 
                                                    onkeypress=" return onlyNumbers();"></asp:TextBox>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:TemplateField >
                                           <ItemTemplate>
                                               <asp:Button ID="btnSave" Text="Save" runat="server" class="btn btn-info" OnClick="btnSave_Click"/>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                   </Columns>
                               </asp:GridView>
                             
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

