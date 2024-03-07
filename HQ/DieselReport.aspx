<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="DieselReport.aspx.cs" Inherits="ADM_DieselReport" EnableEventValidation = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                <asp:ListItem Value="1" >District Wise</asp:ListItem>
		<asp:ListItem Value="9" >District Wise Recon</asp:ListItem>
                <asp:ListItem Value="2" >Block Wise</asp:ListItem>
                <asp:ListItem Value="3" >Panchayat Wise</asp:ListItem>
                <asp:ListItem Value="4" >Panchayat Wise Days Pending</asp:ListItem>
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
                                   CssClass="table table-bordered table-striped"
                                   AutoGenerateColumns="false" Font-Size="12px">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="DistName" HeaderText="District Name" />
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp" />
					<asp:BoundField DataField="TotalAppRecon" HeaderText="TotalAppRecon" />
					<asp:BoundField DataField="GrandTotalApp" HeaderText="GrandTotalApp" />
                                       <asp:BoundField DataField="ACApproved" HeaderText="ACApproved" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />
                                       <asp:BoundField DataField="ACSubsidyLandArea" HeaderText="ACApprovedLand" />
                                       
                                       <asp:BoundField DataField="DAOApproved" HeaderText="DAOApproved" />
                                       <asp:BoundField DataField="DAOReject" HeaderText="DAOReject" />
                                       <asp:BoundField DataField="DAOPending" HeaderText="DAOPending" />
					<asp:BoundField DataField="DAO_ApprovedAmt" HeaderText="DAO_ApprovedAmt" />
                                       <asp:BoundField DataField="SendToBank" HeaderText="SendToBank" />
                                       <asp:BoundField DataField="BankSendAmnt" HeaderText="BankSend Amount" />

                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>


				<asp:GridView ID="gvdataRe" runat="server" EmptyDataText="No record found"
                                   CssClass="table table-bordered table-striped"
                                   AutoGenerateColumns="false" Font-Size="12px">
                                   <Columns>

                                       <asp:TemplateField HeaderText="SN">
                                           <ItemTemplate>
                                               <%#Container.DataItemIndex+1+"." %>
                                           </ItemTemplate>
                                       </asp:TemplateField>
                                       <asp:BoundField DataField="DistName" HeaderText="District Name" />
                                       <asp:BoundField DataField="TotalApp" HeaderText="TotalApp Recon" />
                                       <asp:BoundField DataField="ACApproved" HeaderText="ACApproved" />
                                       <asp:BoundField DataField="ACReject" HeaderText="ACReject" />
                                       <asp:BoundField DataField="ACPending" HeaderText="ACPending" />
                                       <asp:BoundField DataField="ACSubsidyLandArea" HeaderText="ACApprovedLand" />
                                       
                                       <asp:BoundField DataField="DAOApproved" HeaderText="DAOApproved" />
                                       <asp:BoundField DataField="DAOReject" HeaderText="DAOReject" />
                                       <asp:BoundField DataField="DAOPending" HeaderText="DAOPending" />
					<asp:BoundField DataField="DAO_ApprovedAmt" HeaderText="DAO_ApprovedAmt" />
                                       <asp:BoundField DataField="SendToBank" HeaderText="SendToBank" />
                                       <asp:BoundField DataField="BankSendAmnt" HeaderText="BankSend Amount" />

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
                                       <asp:BoundField DataField="DAOAccept" HeaderText="DAOAccept" />
                                       <asp:BoundField DataField="DAOReject" HeaderText="DAOReject" />
                                       <asp:BoundField DataField="DAOPending" HeaderText="DAOPending" />
					<asp:BoundField DataField="DAO_ApprovedAmt" HeaderText="DAO_ApprovedAmt" />
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
                                       <asp:BoundField DataField="ACSubsidyLandArea" HeaderText="ACApprovedLand" />
                                       
                                   
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
                                       
                                       <asp:BoundField DataField="ACPendinggRETER8DAYS" HeaderText="ACPending > 10 DAYS" />
                                       <asp:BoundField DataField="ACPendingWithin8DAYS" HeaderText="ACPending < 10 DAYS" />
                                        
                                   </Columns>
                                   <RowStyle />
                               </asp:GridView>
                               
            </ContentTemplate>
                        </asp:UpdatePanel> 
        </div>
</asp:Content>

