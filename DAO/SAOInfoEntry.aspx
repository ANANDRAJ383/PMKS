<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="SAOInfoEntry.aspx.cs" Inherits="DAO_SAOInfoEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script language="JavaScript" type="text/javascript">
          function onlyNumbers(evt) {
              var e = event || evt;
              var charCode = e.which || e.keyCode;
              if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                  alert('Enter Numbers Only');
                  return false;
              }
              return true;
          }
      </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">SAO Information Entry</div><br />
      <div class="row">
           <div class="input-group mb-3 col-lg-3">
            <label>Sub Division :</label>
            <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlSubDivision" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>
        <div class="input-group mb-3 col-lg-3">
            <label>Name:- </label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>
        <div class="input-group mb-3 col-lg-3">
            <label>Mobile No:- </label>
            <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" onkeypress="return onlyNumbers();"></asp:TextBox>
        </div>
        <div class="input-group mb-3 col-lg-3">
            &nbsp;
  <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
        </div>
    </div>

    <div >
 <asp:UpdatePanel ID="up" runat="server" UpdateMode="Always">
            <ContentTemplate>
         <asp:GridView ID="gvView" runat="server" EmptyDataText="No record found" AllowPaging="false"  DataKeyNames="SubDivisionCode"  OnRowDeleting="gvView_RowDeleting"
                     AutoGenerateColumns="false" Width="100%" AlternatingRowStyle-CssClass="alt" CssClass="table table-bordered table-striped">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                       
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1+"." %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SubDivisionName" HeaderText="Sub Division" />
                        <asp:BoundField DataField="Name" HeaderText="Officer Name" />
                         <asp:BoundField DataField="MobileNo" HeaderText="Officer MobileNo" />
                        <asp:BoundField DataField="ActionDate" HeaderText="Action Date" />
<asp:CommandField ShowDeleteButton="true" /> 
                    </Columns>                    
                </asp:GridView>
 <br />
        <asp:Label runat="server" Text=" " ID="lblname"       ForeColor="#507CD1" Font-Size="20px"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>

