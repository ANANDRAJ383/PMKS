<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMain.master" AutoEventWireup="true" CodeFile="PendingReportPanchayat.aspx.cs" Inherits="PendingReportPanchayat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <div class="container-fluid">
                    <div class="d-flex clearfix mt-4">
                        <h3 class="d-inline-block" style="font-size: 32px;">AC Pending Report Panchayat Wise </h3>
                        <span class="ml-auto d-inline-block align-self-center">
                            <button type="button" class="btn btn-primary b-btn"><span class="fas fa-download fa-sm"></span>Statistic</button></span>
                    </div>
                </div>
    <%--<table class="table table-bordered mt-3">
        <tr>
            <td>
                Pending Level
            </td>
            <td>
                120 Days
            </td>
            <td>
                365 days
            </td>
            <td>
                730 Days
            </td>
            <td>
                Greater Than 1065

            </td>
        </tr>
        <tr>
            <td>
               AC Level
            </td>
            <td>
                <asp:Label runat="server" Text="" ID="lbl1Ac120"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="lblac365"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="lblac730"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="lblac1065"></asp:Label>

            </td>
        </tr>
         <tr>
            <td>
               Circle Officer Level
            </td>
            <td>
                <asp:Label runat="server" Text="" ID="Label1"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="Label2"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="Label3"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="Label4"></asp:Label>

            </td>
        </tr>
         <tr>
           <td>
               ADM Level
            </td>
            <td>
                <asp:Label runat="server" Text="" ID="Label5"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="Label6"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="Label7"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="Label8"></asp:Label>

            </td>
        </tr>
        <tr>
           <td>
              HQLevel
            </td>
            <td>
                <asp:Label runat="server" Text="" ID="Label9"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="Label10"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="Label11"></asp:Label>
            </td>
            <td>
                <asp:Label runat="server" Text=" "  ID="Label12"></asp:Label>

            </td>
        </tr>
    </table>--%>
    <table class="table table-bordered mt-3">
        <tr>
            <td>
                <asp:GridView ID="grd1" runat="server" class="table table-bordered mt-3" AutoGenerateColumns="false" DataKeyNames="distcode">
                    <Columns>
                        <asp:TemplateField HeaderText="sl#" HeaderStyle-CssClass="smallSize" HeaderStyle-BackColor="White" HeaderStyle-Font-Size="12px" HeaderStyle-Font-Names="Verdana">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1+"."%>
                            </ItemTemplate>
                            <HeaderStyle CssClass="smallSize" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="District Name" HeaderStyle-CssClass="smallSize">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkregid6" runat="server" Text='<%#Bind("DistName") %>' CommandArgument='<%#Bind("DistName") %>' CommandName="view" ForeColor="Red" Font-Size="15px" Font-Names="Verdana" Font-Bold="true"  ></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="smallSize" Font-Size="12px" Font-Names="Verdana" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Block Name" HeaderStyle-CssClass="smallSize">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Bind("BlockName") %>' CommandArgument='<%#Bind("BlockName") %>' CommandName="view" ForeColor="Red" Font-Size="15px" Font-Names="Verdana" Font-Bold="true"  ></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="smallSize" Font-Size="12px" Font-Names="Verdana" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Panchaayat Name" HeaderStyle-CssClass="smallSize">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" Text='<%#Bind("PanchayatName") %>' CommandArgument='<%#Bind("PanchayatName") %>' CommandName="view" ForeColor="Red" Font-Size="15px" Font-Names="Verdana" Font-Bold="true"  ></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="smallSize" Font-Size="12px" Font-Names="Verdana" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Within 120 Days" HeaderStyle-CssClass="smallSize">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkregid5" runat="server" Text='<%#Bind("120Days") %>' CommandArgument='<%#Bind("120Days") %>' CommandName="view" ForeColor="Red" Font-Size="15px" Font-Names="Verdana" ></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="smallSize" Font-Size="12px" Font-Names="Verdana" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="120 Days to 365 Days" HeaderStyle-CssClass="smallSize">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkregid3" runat="server" Text='<%#Bind("365Days") %>' CommandArgument='<%#Bind("365Days") %>' CommandName="view" ForeColor="Red" Font-Size="15px" Font-Names="Verdana" ></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="smallSize" Font-Size="12px" Font-Names="Verdana" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="365 Days to 730 Days" HeaderStyle-CssClass="smallSize">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkregid2" runat="server" Text='<%#Bind("730Days") %>' CommandArgument='<%#Bind("730Days") %>' CommandName="view" ForeColor="Red" Font-Size="15px" Font-Names="Verdana" ></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="smallSize" Font-Size="12px" Font-Names="Verdana" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Greater 730 Days" HeaderStyle-CssClass="smallSize">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkregid1" runat="server" Text='<%#Bind("1065Days") %>' CommandArgument='<%#Bind("1065Days") %>' CommandName="view" ForeColor="Red" Font-Size="15px" Font-Names="Verdana" ></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="smallSize" Font-Size="12px" Font-Names="Verdana" />
                        </asp:TemplateField>
                    </Columns>


                </asp:GridView>
            </td>
        </tr>
    </table>




</asp:Content>

