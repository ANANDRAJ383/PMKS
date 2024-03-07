<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="SAOIDPass.aspx.cs" Inherits="DAO_PanchayatEnrtyPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #1C6794; padding: 5px; margin-top: 5px; width: 100%;" align="center">SAO User ID and Password</div><br />
   <%-- <table class="table-bordered  table table-striped " style="width: 100%;">
            <tr>
                <td>Block</td>
                <td>
                     <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional"  >
                           <ContentTemplate>
                    <asp:DropDownList ID="ddlblock" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlblock_SelectedIndexChanged">
                    </asp:DropDownList>
                               </ContentTemplate>
                         </asp:UpdatePanel>
                </td>
                <td>Panchayat</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                    <asp:DropDownList ID="ddlpanchayat" runat="server" CssClass="form-select">                     
                    </asp:DropDownList>
                               </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
                 <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click"/>
                 </td>
                </tr>
        <tr>
            <td colspan="6">
                 &nbsp;</td>
        </tr>
        </table>--%>
   <%-- <asp:Panel ID="pnldata" runat="server" Visible="false">
        <table class="table-bordered  table table-striped " style="width: 100%;">
            <tr>
                <td>User ID:</td> 
                <td><asp:Label ID="lblname" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>          
                <td>Panchayat Name:</td>
                <td><asp:Label ID="lblpanname" runat="server" Text=""></asp:Label></td>
                </tr>
         <tr>
             <td>Enter Name:</td>
             <td><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-lg" ></asp:TextBox></td>
         </tr>
          <tr>
             <td>Mobile Number:</td>
             <td><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-lg" MaxLength="10"></asp:TextBox></td>
         </tr>
         <tr>
             <td>  <asp:Button ID="Button2" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="Button2_Click"/></td>
         </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label></td>
            </tr>
    </table>
    </asp:Panel>--%>
     
    <asp:Panel ID="pnlgdview" runat="server" Visible="false">
        <asp:UpdatePanel ID="up" runat="server" UpdateMode="Always">
            <ContentTemplate>
         <asp:GridView ID="gvView" runat="server" EmptyDataText="No record found" AllowPaging="false" 
                     AutoGenerateColumns="false" Width="100%" AlternatingRowStyle-CssClass="alt" CssClass="table table-bordered table-striped">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                       
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1+"." %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="SDMName_En" HeaderText="Subdivision Name" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Mobileno" HeaderText="Mobile Number" />
                        <asp:BoundField DataField="userid" HeaderText="User ID" />
                        <asp:BoundField DataField="password" HeaderText="Password" />
                    </Columns>
                    
                </asp:GridView>
                 
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>

