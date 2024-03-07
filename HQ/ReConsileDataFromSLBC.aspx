<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="ReConsileDataFromSLBC.aspx.cs" Inherits="HQ_ReConsileDataFromBank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">
         <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"  >
                           <ContentTemplate><asp:Label ID="lblMsg" runat="server" Font-Bold="True" 
            Font-Size="22pt" ForeColor="#0066FF" ></asp:Label></ContentTemplate>
                        </asp:UpdatePanel> 

        
        </div><br />
    <div>
       <asp:LinkButton id="btnExport" runat="server" Text="Export In Excel" Visible="false"></asp:LinkButton>
        <asp:LinkButton id="lnkBack" runat="server" Text="Back" Visible="false"></asp:LinkButton>
    </div>
   <div>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
        <asp:GridView ID="grdBankData" runat="server" EmptyDataText="No record found" 
               CssClass="table table-bordered table-striped" AutoGenerateColumns="false"  Font-Size="12px" OnRowCommand="grdBankData_RowCommand" Visible="false">
            <Columns>
               
                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="District Name">
                    <ItemTemplate>
                        <asp:LinkButton id="lnkDistrict" runat="server" Text='<%#Eval("DistName") %>' CommandArgument='<%# Eval("DistCode") %>' CommandName="Dist"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TotalRecovery" HeaderText="Total Recovery Farmers" />
                <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount Recovered" />
               
                
            </Columns>
            <RowStyle />
        </asp:GridView>
                               </ContentTemplate>
                        </asp:UpdatePanel> 
    </div>
    <div class="input-group mb-3 col-lg-4">
             &nbsp;
  
</div>
    <div>
          <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
               CssClass="table table-bordered table-striped"
            DataKeyNames="Registration_ID" AutoGenerateColumns="false"  Font-Size="12px" Visible="false">
            <Columns>
               
                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DistName" HeaderText="District Name" />
                <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" />
                <asp:BoundField DataField="VILLNAME" HeaderText="Village Name" />
                <asp:TemplateField HeaderText="Registration Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("Registration_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PM_RegNo" HeaderText="PMK RegNo" />
                <asp:BoundField DataField="FarmerName" HeaderText="Applicant Name" />
                <asp:BoundField DataField="Father_Husband_Name" HeaderText="Father/Husband Name" />
                <asp:TemplateField HeaderText="Bank Detail">
                    <ItemTemplate>
                        <strong>Account Number: </strong>
                        <%#Eval("AccountNumber")%><br />
                        <strong>IFSC Code: </strong>
                        <%#Eval("IFSC_Code")%><br />
                    </ItemTemplate>
                </asp:TemplateField>
                
               <asp:BoundField  DataField="Amount" HeaderText="Amount" />
               <asp:BoundField  DataField="INSTALLMENT" HeaderText="INSTALLMENT" />
                 <asp:BoundField  DataField="ReasonofIneligibility" HeaderText="Reason of Ineligibility" />
               <asp:BoundField  DataField="MobileNo" HeaderText="MobileNo" />
                <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:Button ID="btnViewDetail" Text="Done" runat="server"   class="btn btn-success"/>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <RowStyle />
        </asp:GridView>
                               </ContentTemplate>
                        </asp:UpdatePanel>
    </div>
</asp:Content>

