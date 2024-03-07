<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LandDetailInputRe23.aspx.cs" Inherits="LandDetailInputRe23" enableEventValidation="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../vendor/bootstrap/css/bootstrap.min.css" />
    <!-- Custom styles for this template -->
    <link rel="stylesheet" href="../css/base.css" />
    <link rel="stylesheet" href="../css/GridView.css" />
    <link rel="stylesheet" href="../css/base-responsive.css" />
    <link rel="stylesheet" href="../css/animate.min.css" />
    <link rel="stylesheet" href="../css/slicknav.min.css" />
    <link rel="stylesheet" href="../css/font-awesome.min.css" />
    <link href="../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="../css/entryform.css" />
    </head>
<body style="background-color: #5ed07c;">
    <form id="form1" runat="server">
        <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold; background-color: #5ed07c; padding: 5px; width: 100%;"
            align="center">
            जमीन विवरणी(Krishi Input Subsidy-2022-23)
            <asp:Label ID="lblRegId" runat="server"></asp:Label>
        </div>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Font-Size="10px" CssClass="Grid" DataKeyNames="RegistrationID,slno" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <%--RegistrationID,Khatano,keshrano,thanano,FarmingRakwa,Affectedrakwa,CropType--%>
                <asp:TemplateField HeaderText="क्रम संख्या" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                    <HeaderStyle CssClass="smallSize" Width="10px" />
                </asp:TemplateField>

                <asp:BoundField DataField="RegistrationID" HeaderText="Registration ID" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                    <HeaderStyle CssClass="smallSize" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                 <asp:BoundField DataField="slno" HeaderText="Land Sr. No." ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                    <HeaderStyle CssClass="smallSize" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Khatano" HeaderText="Khata No" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                    <HeaderStyle CssClass="smallSize" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="keshrano" HeaderText="Khesra No" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                    <HeaderStyle CssClass="smallSize" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="thanano" HeaderText="Thana No" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                    <HeaderStyle CssClass="smallSize" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="FarmingRakwa" HeaderText="Farming Rakwa" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                    <HeaderStyle CssClass="smallSize" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Affectedrakwa" HeaderText="Affected Rakwa" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                    <HeaderStyle CssClass="smallSize" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="CropType" HeaderText="Crop Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                    <HeaderStyle CssClass="smallSize" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                 <asp:BoundField DataField="affectedtype" HeaderText="Irrigation Type" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                    <HeaderStyle CssClass="smallSize" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Take Action">
                    <ItemTemplate>
                        <asp:Button ID="btnTakeAction" Text="Approve Land Detail" runat="server" OnClick="btnTakeAction_Click" class="btn btn-success" /><br />
                      <%--  <asp:ImageButton ID="img1" runat="server" ImageUrl ="~/images/Check.png" Width="30px"/>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DAOChangeLandType" HeaderText="Action Status" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                    <HeaderStyle CssClass="smallSize" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle Font-Size="Small" />
            <PagerStyle CssClass="pager" />
            <RowStyle CssClass="rows" />
        </asp:GridView>
        <div>

            <asp:Button ID="btnBack" runat="server" Text="Close" class="btn-danger" OnClick="btnBack_Click" Height="40px" Font-Size="16px" />

            <asp:Button ID="btnRefresh" runat="server" Text="Refresh" class="btn-primary" Height="40px" Font-Size="16px"  OnClick="btnRefresh_Click"/>
<br/>
** कृपया आवेदन स्वीकृत एवं अस्वीकृत करने के उपरांत Refresh बटन का इतेमाल करें |
        </div>
        <center>
        <asp:Panel ID="pnl1" runat="server" Visible="false" >
            <table>
                <tr>
                    <td style="font-family:Verdana; font-size:12px;">
                        Application ID: 
                    </td>
                     <td style="font-family:Verdana; font-size:12px ; text-align:left;">
                       <asp:Label ID="lbl1" runat="server" ForeColor="Red" Font-Names="Verdana" Font-Bold="true"  ></asp:Label>
                         Sr. No:  <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Names="Verdana" Font-Bold="true"  ></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="font-family:Verdana; font-size:12px;">
                        Land Type</td>
                     <td style="font-family:Verdana; font-size:12px; text-align:left;">
                         <asp:Label ID="lbl2" runat="server" Font-Bold="true" Font-Names="Verdana" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="font-family:Verdana; font-size:12px;">
                        Crop Name</td>
                     <td style="font-family:Verdana; font-size:12px; text-align: left;">
                         <asp:Label ID="lbl3" runat="server" Font-Bold="true" Font-Names="Verdana" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family:Verdana; font-size:12px;">
                        Land Type:
                    </td>
                     <td style="font-family:Verdana; font-size:12px; text-align: left;">
                         <asp:DropDownList ID="ddlLandType" runat="server">
                             <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                             <asp:ListItem Text="सिंचित" Value="1"></asp:ListItem>
                             <asp:ListItem Text="असिंचित" Value="2"></asp:ListItem>
                         </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="font-family:Verdana; font-size:12px;">
                        Affected Rakwa:
                    </td>
                    <td style="font-family:Verdana; font-size:12px;">
                        <asp:TextBox ID="lblAffectedLand" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="font-family:Verdana; font-size:12px;">
                        Approved Rakwa(In Dicimil):
                    </td>
                    <td style="font-family:Verdana; font-size:12px;">
                        <asp:TextBox ID="txtapprovedLand" runat="server"></asp:TextBox>
                    </td>
                </tr>
<tr>
                    <td style="font-family:Verdana; font-size:12px;">
                        Remarks:
                    </td>
                    <td style="font-family:Verdana; font-size:12px;">
                        <asp:TextBox ID="txtRemarks" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-family:Verdana; font-size:12px;">
** जमीन रद्द कि स्थिति में रकवा 0.00 प्रविष्टि करें |
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                    </td>
                </tr>
            </table>

        </asp:Panel>
        </center>
    </form>
</body>
</html>
