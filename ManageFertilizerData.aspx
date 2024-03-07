<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true" CodeFile="ManageFertilizerData.aspx.cs" Inherits="ManageFertilizerData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Manage Fertilizer Data</div><br />
    <asp:Panel ID="pnlPasscode" runat="server" >
        <table class="table-bordered table-responsive table table-striped " style="width: 100%;" align="center">
            <tr>
                <td>Passcode</td>
                <td><asp:TextBox ID="txtPasscode" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                            <asp:Button ID="btnOK" runat="server" Text="OK" CssClass="btn btn-success" OnClick="btnOK_Click" />
                       
                </td>
            </tr>
        </table>
        

    </asp:Panel>

    <asp:Panel ID="pnlStep" runat="server" Visible="false">

    <div class="row">
        <div class="input-group mb-3 col-lg-3">
            <asp:Button ID="btnBackup" runat="server" Text="Step 1 (Backup Data)" CssClass="btn btn-success" OnClick="btnBackup_Click"/>
        </div>
        <div class="input-group mb-3 col-lg-3">
            <asp:Button ID="btnTruncate" runat="server" Text="Step 2 (Erase Data)"  CssClass="btn btn-success" OnClick="btnTruncate_Click"/>
        </div>
        <div class="input-group mb-3 col-lg-3">
            <label>Upload Data :</label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <div class="input-group mb-3 col-lg-3">
            <asp:Button ID="btnUpload" runat="server" Text="Step 3 (Upload Data)" CssClass="btn btn-success" OnClick="btnUpload_Click"/>
        </div>
    </div>
        </asp:Panel>

     <div >

         <asp:GridView ID="gvView" runat="server" EmptyDataText="No record found" AllowPaging="false"
                     AutoGenerateColumns="false" Width="100%" AlternatingRowStyle-CssClass="alt" CssClass="table table-bordered table-striped">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                       
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1+"." %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Rid" HeaderText="Rid" />
                        <asp:BoundField DataField="DistName" HeaderText="DistName" />
                        <asp:BoundField DataField="BlockName" HeaderText="BlockName" />
                        <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                        <asp:BoundField DataField="RetailerName" HeaderText="RetailerName" />
                        <asp:BoundField DataField="Comname" HeaderText="Comname" />
                        <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                        <asp:BoundField DataField="Product" HeaderText="Product" />
                    </Columns>
                    
                </asp:GridView>

    </div>
</asp:Content>

