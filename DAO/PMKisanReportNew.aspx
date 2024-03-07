<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="PMKisanReportNew.aspx.cs" Inherits="ADM_PMKisanReport" EnableEventValidation = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">PM Kisan Daily Report :-<asp:Label ID="lblRType" runat="server" ></asp:Label></div><br />

    <div class="row">
        <div class="input-group mb-3 col-lg-4">
            <label>Report Type :</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged" >
                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                <asp:ListItem Value="Block" >Block Wise</asp:ListItem>
                <asp:ListItem Value="Panch" >Panchayat Wise</asp:ListItem>
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

        <div class="input-group mb-3 col-lg-4">
            <label>Application Type :</label>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlApplicationType" runat="server" CssClass="form-select"
                  AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlApplicationType_SelectedIndexChanged">
                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                 <asp:ListItem Value="NEW" >New</asp:ListItem>             
                <asp:ListItem Value="NRE" >Recon</asp:ListItem>
                <asp:ListItem Value="NRRE" >Re-Recon</asp:ListItem>
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

        <div class="input-group mb-3 col-lg-4">
             
  <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             
             <asp:Button ID="btnExport" runat="server" Text="Export To Excel" CssClass="btn btn-success"  OnClick="btnExport_Click" />
                    
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

                                <asp:GridView ID="GridDistA" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-bordered  table-striped"
                                   AutoGenerateColumns="false" Font-Size="12px">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="distName" HeaderText="District Name" />
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />
                                       <asp:BoundField DataField="COAccept" HeaderText="COAccept" />
                                       <asp:BoundField DataField="COReject" HeaderText="COReject" />
                                       <asp:BoundField DataField="COPending" HeaderText="COPending" />
                                       <asp:BoundField DataField="ADMRAccept" HeaderText="ADMRAccept" />
                                       <asp:BoundField DataField="ADMRReject" HeaderText="ADMRReject" />
                                       <asp:BoundField DataField="ADMRPending" HeaderText="ADMRPending" />
                                       <asp:BoundField DataField="FileSend" HeaderText="FileSend" />


                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>

                               <asp:GridView ID="GridBlockA" runat="server" EmptyDataText="No record found"
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
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />
                                       <asp:BoundField DataField="COAccept" HeaderText="COAccept" />
                                       <asp:BoundField DataField="COReject" HeaderText="COReject" />
                                       <asp:BoundField DataField="COPending" HeaderText="COPending" />
                                       <asp:BoundField DataField="ADMRAccept" HeaderText="ADMRAccept" />
                                       <asp:BoundField DataField="ADMRReject" HeaderText="ADMRReject" />
                                       <asp:BoundField DataField="ADMRPending" HeaderText="ADMRPending" />

                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>

                               <asp:GridView ID="GridPanA" runat="server" EmptyDataText="No record found"
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
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />                                       
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />

                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>








                               <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-bordered  table-striped"
                                   AutoGenerateColumns="false" Font-Size="12px">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="distName" HeaderText="District Name" />
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />
                                       <asp:BoundField DataField="COAccept" HeaderText="COAccept" />
                                       <asp:BoundField DataField="COReject" HeaderText="COReject" />
                                       <asp:BoundField DataField="COPending" HeaderText="COPending" />
                                       <asp:BoundField DataField="ADMRAccept" HeaderText="ADMRAccept" />
                                       <asp:BoundField DataField="ADMRReject" HeaderText="ADMRReject" />
                                       <asp:BoundField DataField="ADMRPending" HeaderText="ADMRPending" />
                                       <asp:BoundField DataField="FileSend" HeaderText="FileSend" />


                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>

                               <asp:GridView ID="GridBlockOld" runat="server" EmptyDataText="No record found"
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
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />
                                       <asp:BoundField DataField="COAccept" HeaderText="COAccept" />
                                       <asp:BoundField DataField="COReject" HeaderText="COReject" />
                                       <asp:BoundField DataField="COPending" HeaderText="COPending" />
                                       <asp:BoundField DataField="ADMRAccept" HeaderText="ADMRAccept" />
                                       <asp:BoundField DataField="ADMRReject" HeaderText="ADMRReject" />
                                       <asp:BoundField DataField="ADMRPending" HeaderText="ADMRPending" />

                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>

                               <asp:GridView ID="GridPanchOld" runat="server" EmptyDataText="No record found"
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
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />                                       
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />

                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>




                                <asp:GridView ID="GridDistNew" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-bordered  table-striped"
                                   AutoGenerateColumns="false" Font-Size="12px">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="distName" HeaderText="District Name" />
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />
                                       <asp:BoundField DataField="COAccept" HeaderText="COAccept" />
                                       <asp:BoundField DataField="COReject" HeaderText="COReject" />
                                       <asp:BoundField DataField="COPending" HeaderText="COPending" />                                      
                                       <asp:BoundField DataField="ADMRAccept" HeaderText="ADMRAccept" />
                                       <asp:BoundField DataField="ADMRReject" HeaderText="ADMRReject" />
                                       <asp:BoundField DataField="ADMRPending" HeaderText="ADMRPending" />
                                       <asp:BoundField DataField="FileSend" HeaderText="FileSend" />
                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>
                               <asp:GridView ID="GridBlockNew" runat="server" EmptyDataText="No record found"
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
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />
                                       <asp:BoundField DataField="COAccept" HeaderText="COAccept" />
                                       <asp:BoundField DataField="COReject" HeaderText="COReject" />
                                       <asp:BoundField DataField="COPending" HeaderText="COPending" />
                                        
                                       <asp:BoundField DataField="ADMRAccept" HeaderText="ADMRAccept" />
                                       <asp:BoundField DataField="ADMRReject" HeaderText="ADMRReject" />
                                       <asp:BoundField DataField="ADMRPending" HeaderText="ADMRPending" />

                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>

                               <asp:GridView ID="GridPanNew" runat="server" EmptyDataText="No record found"
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
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />                                       
                                       <asp:BoundField DataField="ACAccept" HeaderText="ACAccept" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />

                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>


                                <asp:GridView ID="GridViewOldRe" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-bordered  table-striped"
                                   AutoGenerateColumns="false" Font-Size="12px">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="distName" HeaderText="District Name" />
                                       <asp:BoundField DataField="Application" HeaderText="Total App" />
                                       <asp:BoundField DataField="DAOApplication" HeaderText="DAOApplication" />
                                       <asp:BoundField DataField="DAOAccept" HeaderText="DAOAccept" />
                                       <asp:BoundField DataField="DAOReject" HeaderText="DAOReject" />
                                       <asp:BoundField DataField="ADMRApplication" HeaderText="ADMRApplication" />
                                       <asp:BoundField DataField="ADMAcceptApplication_From_CO_ADM" HeaderText="ADM Accept Application From_CO_ADM" />
                                       <asp:BoundField DataField="ADMAcceptApplication_From_DAO" HeaderText="ADM Accept Application_From_DAO" />                                      
                                       <asp:BoundField DataField="ADMAcceptRe_ADMRejected" HeaderText="ADMAccept Re_ADMRejected" />
                                       <asp:BoundField DataField="ReADMAcceptRe_rejected" HeaderText="Re ADM Re_rejected" />
                                       <asp:BoundField DataField="ReADMReject" HeaderText="Re ADM Reject" />
                                       <asp:BoundField DataField="FileSend" HeaderText="FileSend" />
                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>

                                <asp:GridView ID="GridViewReconNew" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-bordered  table-striped"
                                   AutoGenerateColumns="false" Font-Size="12px">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="distName" HeaderText="District Name" />
                                       <asp:BoundField DataField="TotalApp" HeaderText="Total App" />
                                       <asp:BoundField DataField="COAccept" HeaderText="COAccept" />
                                       <asp:BoundField DataField="COReject" HeaderText="COReject" />
                                       <asp:BoundField DataField="COPending" HeaderText="COPending" />
                                       <asp:BoundField DataField="DAOAccept" HeaderText="DAOAccept" />
                                       <asp:BoundField DataField="DAOReject" HeaderText="DAOReject" />
                                       <asp:BoundField DataField="DAOPending" HeaderText="DAOPending" />                                      
                                       <asp:BoundField DataField="ADMRAccept" HeaderText="ADMRAccept" />
                                       <asp:BoundField DataField="ADMRReject" HeaderText="ADMRReject" />
                                       <asp:BoundField DataField="ADMRPending" HeaderText="ADMRPending" />
                                       <asp:BoundField DataField="FileSend" HeaderText="FileSend" />
                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>

                               <asp:GridView ID="GridViewBlockReconNew" runat="server" EmptyDataText="No record found"
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
                                       <asp:BoundField DataField="TotalApp" HeaderText="Total App" />
                                       <asp:BoundField DataField="COAccept" HeaderText="COAccept" />
                                       <asp:BoundField DataField="COReject" HeaderText="COReject" />
                                       <asp:BoundField DataField="COPending" HeaderText="COPending" />
                                       <asp:BoundField DataField="DAOAccept" HeaderText="DAOAccept" />
                                       <asp:BoundField DataField="DAOReject" HeaderText="DAOReject" />
                                       <asp:BoundField DataField="DAOPending" HeaderText="DAOPending" />                                      
                                       <asp:BoundField DataField="ADMRAccept" HeaderText="ADMRAccept" />
                                       <asp:BoundField DataField="ADMRReject" HeaderText="ADMRReject" />
                                       <asp:BoundField DataField="ADMRPending" HeaderText="ADMRPending" />
                                       <asp:BoundField DataField="FileSend" HeaderText="FileSend" />
                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>

                               <asp:GridView ID="GridViewBlockReconOld" runat="server" EmptyDataText="No record found"
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
                                       <asp:BoundField DataField="Application" HeaderText="Total App" />
                                       <asp:BoundField DataField="DAOApplication" HeaderText="DAOApplication" />
                                       <asp:BoundField DataField="DAOAccept" HeaderText="DAOAccept" />
                                       <asp:BoundField DataField="DAOReject" HeaderText="DAOReject" />
                                       <asp:BoundField DataField="ADMRApplication" HeaderText="ADMRApplication" />
                                       <asp:BoundField DataField="ADMAcceptApplication_From_CO_ADM" HeaderText="ADM Accept Application From_CO_ADM" />
                                       <asp:BoundField DataField="ADMAcceptApplication_From_DAO" HeaderText="ADM Accept Application_From_DAO" />                                      
                                       <asp:BoundField DataField="ADMAcceptRe_ADMRejected" HeaderText="ADMAccept Re_ADMRejected" />
                                       <asp:BoundField DataField="ReADMAcceptRe_rejected" HeaderText="Re ADM Re_rejected" />
                                       <asp:BoundField DataField="ReADMReject" HeaderText="Re ADM Reject" />
                                       <asp:BoundField DataField="FileSend" HeaderText="FileSend" />
                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>
            </ContentTemplate>
                        </asp:UpdatePanel> 
        </div>
</asp:Content>

