<%@ Page Title="" Language="C#" MasterPageFile="MasterPageupload.master" AutoEventWireup="true" CodeFile="UploadDBTPM.aspx.cs" Inherits="UploadDBTPM" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
             <cc1:ToolkitScriptManager ID="toolScriptManageer1" runat="server"></cc1:ToolkitScriptManager>  

    <table class="table-bordered table-responsive table table-striped " style="width: 100%;">
              <tr>
                  <td>Passcode:</td>
                  <td>
                      <asp:TextBox runat="server" ID="txtPassode" TextMode="Password" class="form-control"></asp:TextBox>
                  </td>
                  <td>   <asp:Button ID="btnLogIn" runat="server" Text="Proceed"  Font-Bold="True"   class="btn btn-success" OnClick="btnLogIn_Click" /></td>
              </tr>

          </table>

    <table id="tbl" runat="server" class="table-bordered table-responsive table table-striped " style="width: 100%; font-family: 'Courier New'; font-size: 19px;" visible="false">
        <tr>
            <td>
                Enter Letter No.
            </td>
            <td><asp:TextBox ID="txtLtrNo" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td>
                Enter Letter Date.
            </td>
             <td><asp:TextBox ID="txtLtrDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtLtrDate" Format="dd/MM/yyyy"> </cc1:CalendarExtender></td>
        </tr>
         <tr>
            <td>
                Upload Letter Type 
            </td>
             <td><asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="DBT" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="PMKISAN" Value="2"></asp:ListItem>
                                   </asp:DropDownList></td>
        </tr>
        <tr>
            <td>
               Upload Letter
            </td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Save" Font-Bold="True" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>

    <div>

       <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="false" class="table table-bordered" Visible="false">
            <Columns>
                <asp:TemplateField HeaderText="Sl No." HeaderStyle-CssClass="5px" ItemStyle-Font-Size="12px">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="smallSize" Width="100px" Font-Size="12px"></HeaderStyle>
                </asp:TemplateField>

                <asp:BoundField DataField="Letterno" HeaderText="Letter No." ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="12px" ItemStyle-Font-Size="12px">
                    <HeaderStyle CssClass="smallSize" Width="100px" Font-Size="12px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                </asp:BoundField>
                <asp:BoundField DataField="LetterDate" HeaderText="Letter Date." ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="12px" ItemStyle-Font-Size="12px">
                    <HeaderStyle CssClass="smallSize" Width="100px" Font-Size="12px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                </asp:BoundField>
                <asp:BoundField DataField="Uploadfor" HeaderText="Letter Type." ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="12px" ItemStyle-Font-Size="12px">
                    <HeaderStyle CssClass="smallSize" Width="100px" Font-Size="12px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                </asp:BoundField>
                <asp:BoundField DataField="Enreydate" HeaderText="Letter Entry Date." ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="12px" ItemStyle-Font-Size="12px">
                    <HeaderStyle CssClass="smallSize" Width="100px" Font-Size="12px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                </asp:BoundField>

                <asp:TemplateField HeaderText="Download Letter" HeaderStyle-CssClass="11px" ItemStyle-Font-Size="11px">
                    <ItemTemplate>
                         <asp:HyperLink ID="HyperLink1" Visible="true" Font-Underline="true" runat="server" NavigateUrl='<%#Eval("UploadLetter")%>' Target="_blank">View</asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle CssClass="smallSize" Width="100px" Font-Size="12px"></HeaderStyle>
                </asp:TemplateField>
            </Columns>


    </asp:GridView>
    </div>
</asp:Content>

