<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true" CodeFile="PMKisanPaymentDoneDataList.aspx.cs" Inherits="PMKisanPaymentDoneDataList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
 <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">View Farmer Detail</div><br />
       <div class="row">
           <div class="input-group mb-3 col-lg-3">
            <label>District :</label>
            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" >
            </asp:DropDownList>
        </div>
        <div class="input-group mb-3 col-lg-3">
            <label>Block :</label>
            <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

        <div class="input-group mb-3 col-lg-3">
            <label>Village :</label>
            <asp:DropDownList ID="ddlVillage" runat="server" CssClass="form-select"
                 ValidationGroup="s">
            </asp:DropDownList>

        </div>

         <div class="input-group mb-4 col-lg-3">
             &nbsp;
  <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn-danger" OnClick="btnShow_Click"  /> 
</div>
    </div>

    <div >
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                AllowPaging="true" PageSize="10" CssClass="table table-bordered table-responsive table-striped"
            AutoGenerateColumns="false"   Font-Size="12px" onpageindexchanging="gvdata_PageIndexChanging">
            <Columns>
                
                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:BoundField DataField="DistrictName" HeaderText="District Name" />
                <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                <asp:BoundField DataField="VillageName" HeaderText="Village Name" />
                <asp:TemplateField HeaderText="Registration Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("Reg_No") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Farmer_Name" HeaderText="Farmer Name" />
                <asp:BoundField DataField="Father_Name" HeaderText="Father Name" />
                <asp:TemplateField HeaderText="Bank Detail">
                    <ItemTemplate>
                        <strong>Account Number: </strong>
                        <%#Eval("AccountNo")%><br />
                        <strong>IFSC Code: </strong>
                        <%#Eval("IFSC_Code")%><br />
                    </ItemTemplate>
                </asp:TemplateField>
               
               <asp:BoundField  DataField="Registration_Date" HeaderText="Registration Date" />
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnViewDetail" Text="View Detail" runat="server"  class="btn btn-success"/>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <RowStyle />
        </asp:GridView>
        </div>
</asp:Content>

