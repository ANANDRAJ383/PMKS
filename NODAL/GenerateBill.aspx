<%@ Page Title="" Language="C#" MasterPageFile="NODALMasterPage.master" AutoEventWireup="true" CodeFile="GenerateBill.aspx.cs" Inherits="NODAL_GenerateBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #1C6794; padding: 5px; margin-top: 5px; width: 100%;" align="center">Diesel Subsidy Kharif- 2022-23 :- <asp:Label ID="lblBank" runat="server" Text=",HDFC BANK ,Raja Bazar"></asp:Label></div><br />
    <div class="row">
        <div class="input-group mb-3 col-lg-3">
            <label>District : &nbsp;</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlDist" runat="server" CssClass="form-select" ValidationGroup="s">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="input-group mb-3 col-lg-3">
            <label>Verified By : &nbsp;</label>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlVeriy" runat="server" CssClass="form-select" ValidationGroup="s">
                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Verified By DAO" Value="1"></asp:ListItem>
                    </asp:DropDownList>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="input-group mb-3 col-lg-3">
            <label>&nbsp;</label>
            <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" />
        </div>
    </div>
    <div class="row">
    <div class="input-group mb-3 col-lg-6" align="center">
            <asp:Label ID="lblDataMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF"></asp:Label>

        </div>
        </div>
    <div class="row" style="overflow-y: scroll; height:300px;">

        <div class="input-group mb-3 col-lg-6" align="center">
            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#FF3300"></asp:Label>

        </div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:GridView ID="gdviewbank" runat="server" EmptyDataText="No record found" AllowPaging="false"
                    DataKeyNames="Registration_ID,Application_ID" AutoGenerateColumns="false" Width="100%" AlternatingRowStyle-CssClass="alt" Font-Size="10px" CssClass="table table-bordered table-striped">
                    <AlternatingRowStyle CssClass="alt" />
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
                        <asp:BoundField DataField="UserNumber" HeaderText="User Number" />
                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                        <asp:BoundField DataField="UserReference" HeaderText="User Reference" />
                        <asp:BoundField DataField="SettlementDate" HeaderText="Settlement Date" />
                        <asp:BoundField DataField="Users_Bank_Account_Number" HeaderText="User's Bank Account Number" />
                        <asp:BoundField DataField="Destinationbankinn" HeaderText="Destinationbankinn" />
                        <asp:BoundField DataField="AadhaarNumber" HeaderText="Beneficiary Aadhaar No" />
                        <asp:BoundField DataField="Application_ID" HeaderText="User Credit Reference" />
                        <asp:BoundField DataField="DAO_Approvedamt" HeaderText="Amount" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No" />
                    </Columns>
                    <HeaderStyle BackColor="#014275" ForeColor="White" Font-Size="10pt" />
                    <RowStyle Font-Size="10pt" />
                </asp:GridView>

               
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
     <div class="row">
        <div class="input-group mb-3 col-lg-3" align="center" style="margin-top: 25px;">
            <label>&nbsp;</label>
            <asp:Button ID="btnSelectData" runat="server" Text ="SELECTED DATA VIEW " OnClick="btnSelectData_Click"  Visible="false" Font-Names="Verdana"  class="btn btn-success"/>
        </div>
         </div>
    <div class="row" style="overflow-y: scroll; height:300px;">
         <asp:GridView ID="grdChecke" runat="server" EmptyDataText="No record found" AllowPaging="false"
                     AutoGenerateColumns="false" Width="100%" AlternatingRowStyle-CssClass="alt" Font-Size="10px" CssClass="table table-bordered table-striped">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                       
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1+"." %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="UserNumber" HeaderText="User Number" />
                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                        <asp:BoundField DataField="UserReference" HeaderText="User Reference" />
                        <asp:BoundField DataField="SettlementDate" HeaderText="Settlement Date" />
                        <asp:BoundField DataField="Users_Bank_Account_Number" HeaderText="User's Bank Account Number" />
                        <asp:BoundField DataField="Destinationbankinn" HeaderText="Destinationbankinn" />
                        <asp:BoundField DataField="AadhaarNumber" HeaderText="Beneficiary Aadhaar No" />
                        <asp:BoundField DataField="Application_ID" HeaderText="User Credit Reference" />
                        <asp:BoundField DataField="DAO_Approvedamt" HeaderText="Amount" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No" />
                    </Columns>
                    <HeaderStyle BackColor="#014275" ForeColor="White" Font-Size="10pt" />
                    <RowStyle Font-Size="10pt" />
                </asp:GridView>

    </div>
   




     <center> 
                                  <asp:Panel ID="pnlCSV" runat="server" Visible="false" >
                                   <table >
                                       <tr>
                                           <td colspan="7">     <asp:Label  ID="Label4" runat="server" class="label label-danger" Font-Bold="True" Font-Size="13px" Text="** Disply above data approved for final list By Nodal. Kindly Re-check and proceed."></asp:Label></td>
                                       </tr>
                                <tr>
                                     
                                    <td>&nbsp;&nbsp;
                                        <asp:Button ID="btnexport" runat="server" class="btn btn-success" Font-Bold="True" Font-Names="veradana" Font-Size="Medium" OnClick="btnexport_Click" Text="GENERATE FINAL LIST" />
                                        </td>
                                </tr>
                                       
                            </table>
                                      </asp:Panel></center>
</asp:Content>

