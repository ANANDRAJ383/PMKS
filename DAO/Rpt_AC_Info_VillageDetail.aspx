<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="Rpt_AC_Info_VillageDetail.aspx.cs" Inherits="DAO_RefundDetailForm" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div style="margin: 30px 25px 10px 25px;">

        <div class="row">
            <!-- Revenue breakdown chart example-->
            <div class="col-lg-12 ">
                <div class="card card-raised h-100">
                    <div class="card-header bg-transparent px-4">
                        <div class="d-flex justify-content-between align-items-center">
                            <div class="me-4">
                                <h2 class="card-title mb-0"><b>AC Details</b></h2>
                            </div>

                        </div>
                    </div>
                    <div class="row mb-3 m-5">
                        <div class="col-12 col-sm-4 col-md-4 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Block</b> <span class="mandatory">*</span>  </label>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                            </div>
                        </div>

                        <div class="col-12 col-sm-4 col-md-4 mb-4">
                            <div class="form-group">
                                <label class="control-label"><b>Panchyat</b><span class="mandatory">*</span> </label>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                                <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                            </div>
                        </div>

                        

                        <div class="row">
                            <div class="col-lg-4 col-sm-12 col-md-4"></div>
                            <div class="col-lg-4 col-sm-12 col-md-4">
                                <asp:Button ID="btnSave" runat="server" Text="Show" class="btn btn-success" OnClick="btnSave_Click"  />
                            </div>

                            
                        </div>

                    </div>

                </div>
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

   <script type="text/javascript">   
    $(function () {
        var dtToday = new Date();

        var month = dtToday.getMonth() + 1;
        var day = dtToday.getDate();
        var year = dtToday.getFullYear();
        if (month < 10)
            month = '0' + month.toString();
        if (day < 10)
            day = '0' + day.toString();

        var minDate = year + '-' + month + '-' + day;

        // or instead:
        // var maxDate = dtToday.toISOString().substr(0, 10);

        //alert(maxDate);
       
       // $('#txtDate').attr('max', minDate);
        $('[id*=txtDate]').attr('max', minDate);
    });
 </script>

     

  <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
</asp:Content>

