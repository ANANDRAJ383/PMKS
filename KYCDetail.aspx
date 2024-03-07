<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="KYCDetail.aspx.cs" Inherits="AC_KYCDetail" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">EKYC Not done data List </div><br />
    <div class="row">
  

        <div class="col-lg-4">
            &nbsp;
            <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" Visible="false" />
        </div>
        <div class=" col-lg-4">
            &nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Done" class="btn btn-success" OnClick="bnSave_Click" Visible="false" />
        </div>

        
    </div>


<div class="form-row">
    </div>

        <div >
            <div class="input-group mb-3 col-lg-9">
            &nbsp;
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF"></asp:Label>
        </div>

            <asp:PlaceHolder  ID = "PlaceHolder1" runat="server" />  


             <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                AllowPaging="false"  CssClass="table table-bordered table-striped"
            DataKeyNames="BiharRegNo" AutoGenerateColumns="false" Font-Size="12px">
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
                 <asp:TemplateField HeaderText="Registration Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("BiharRegNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Farmer_Registration_No" HeaderText="PM Kisan Registration No" />
                <asp:BoundField DataField="Farmer_Name" HeaderText="Applicant Name" />
                <asp:BoundField DataField="Father_Name" HeaderText="Father/Husband Name" />
                <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" />
                <asp:BoundField DataField="LandVillageName" HeaderText="Village Name" />
               <asp:BoundField  DataField="MobileNumber" HeaderText="Mobile Number" />
             
            </Columns>
            <RowStyle />
        </asp:GridView>
                                </ContentTemplate>
                        </asp:UpdatePanel>--%>
        </div>
</asp:Content>

