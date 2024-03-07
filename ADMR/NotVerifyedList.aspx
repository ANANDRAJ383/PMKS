<%@ Page Title="" Language="C#" MasterPageFile="~/CO/COMasterPage.master" AutoEventWireup="true" CodeFile="NotVerifyedList.aspx.cs" Inherits="CO_NotVerifyedList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">CO Verified  List  </div><br />
    

    <div class="row">
        <div class="input-group mb-3 col-lg-4">
            <label>Block :</label>
            <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

        <div class="input-group mb-3 col-lg-4">
            <label>Panchayat :</label>
            <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select" ValidationGroup="s">
            </asp:DropDownList>
        </div>
        <div class="input-group mb-3 col-lg-4">
            <label>Report Type :</label>
            <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-select">
                <asp:ListItem Value="0"> Select </asp:ListItem>
                <asp:ListItem Value="1">Accept List</asp:ListItem>
                <asp:ListItem Value="2">Reject List</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="input-group mb-3 col-lg-4">
            &nbsp;
            <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn-danger" OnClick="btnShow_Click" />
        </div>

        <div class="input-group mb-3 col-lg-4">
            &nbsp;
            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF"></asp:Label>
        </div>
    </div>



    

<div class="form-row">
       
    </div>

        <div >
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                AllowPaging="true" PageSize="20" CssClass="table table-bordered table-responsive table-striped"
            DataKeyNames="slno" AutoGenerateColumns="false"   onpageindexchanging="gvdata_PageIndexChanging" Font-Size="12px">
            <Columns>
               
                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="blockname" HeaderText="Block Name" />
                <asp:BoundField DataField="panchayatname" HeaderText="Panchayat Name" />
                <asp:BoundField DataField="VillageName" HeaderText="Village Name" />
                <asp:TemplateField HeaderText="Registration Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("Registration_ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                <asp:BoundField DataField="Father_Husband_Name" HeaderText="Father/Husband Name" />
                <asp:TemplateField HeaderText="Bank Detail">
                    <ItemTemplate>
                        <strong>Account Number: </strong>
                        <%#Eval("AccountNumber")%><br />
                        <strong>IFSC Code: </strong>
                        <%#Eval("IFSC_Code")%><br />
                    </ItemTemplate>
                </asp:TemplateField>
               
                
               <asp:BoundField  DataField="EntryDate" HeaderText="Entry Date" />
                <asp:TemplateField HeaderText="Document">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("LandPath")%>'
                            Target="_blank">View</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle />
        </asp:GridView>
        </div>
</asp:Content>

