<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="ReConsileDataFromDAO_SLBC.aspx.cs" Inherits="HQ_ReConsileDataFromBank" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">एसएलबीसी डेटा सूची से कटौती की राशि </div><br />
    <div>
    <table class="table-bordered  table table-striped " style="width: 100%;">
        <tr>
            <td>ज़िला</td>
            <td><asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select">
            </asp:DropDownList></td>
            <td><asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" /></td>
        </tr>
    </table>
        </div>
    <div class="input-group mb-3 col-lg-4">
             &nbsp;
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    <div>
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                 CssClass="table table-bordered table-striped"
            DataKeyNames="RegistrationID" AutoGenerateColumns="false"  Font-Size="10px" >
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
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("RegistrationID") %>'></asp:Label>
                        <br />PMKS RegNo:-<asp:Label ID="Label1" runat="server" Text='<%#Eval("PM_RegNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:BoundField DataField="PM_RegNo" HeaderText="PMK RegNo" />--%>
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
                <asp:BoundField DataField="PMode" HeaderText="Payment RtnMode" />
               <asp:BoundField  DataField="Amount" HeaderText="SLBC Amount" />
               <asp:BoundField  DataField="INSTALLMENT" HeaderText="SLBC INSTALLMENT" />
                <asp:BoundField  DataField="AmountReturn" HeaderText="PMKS_DBT Amount"  ItemStyle-ForeColor="#FF6600" />
               <asp:BoundField  DataField="ReturnInstallment" HeaderText="PMKS_DBT INSTALLMENT"  ItemStyle-ForeColor="#FF6600" />
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
    </div>
</asp:Content>

