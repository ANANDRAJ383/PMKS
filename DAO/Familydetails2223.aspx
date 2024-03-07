<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="Familydetails2223.aspx.cs" Inherits="DAO_Familydetails2223" %>

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
    <style type="text/css">
        .auto-style1 {
            width: 579px;
        }
    </style>
</head>
<body style="background-color: #5ed07c;">
    <form id="form1" runat="server">
       <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">परिवार विवरणी(Krishi Input Subsidy-2022-23) <asp:Label ID="lblRegId" runat="server" ></asp:Label></div><br />
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Font-Size="10px" CssClass="Grid">
                            <Columns>
                                <%--select RegistrationID,Member,live,Name_FamilyMember from Input2223_FamilyMemberDetailAadharInfo--%>
                                    <asp:TemplateField HeaderText="क्रम संख्या" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1+"." %>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="smallSize" Width="10px" />
                                    </asp:TemplateField>
                                 
                                <asp:BoundField DataField="RegistrationID" HeaderText="पंजीकरण संख्या" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                                    <HeaderStyle CssClass="smallSize" />
                                    <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="Member" HeaderText="सम्बन्ध(परिवार से)" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                                    <HeaderStyle CssClass="smallSize" />
                                    <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>
                               <asp:BoundField DataField="Name_FamilyMember" HeaderText="नाम" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                                    <HeaderStyle CssClass="smallSize" />
                                    <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>
                                  
                               <asp:BoundField DataField="live" HeaderText="वर्तमान स्थिति" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                                    <HeaderStyle CssClass="smallSize" />
                                    <ItemStyle HorizontalAlign="Left" />
                                 </asp:BoundField>
                                 
                            </Columns>
                            <HeaderStyle Font-Size="Small" />
                            <PagerStyle CssClass="pager" />
                            <RowStyle CssClass="rows" />
                        </asp:GridView>
    <div>

        <asp:Button ID="btnBack" runat="server" Text="Close"   class="btn-danger" Height="40px"  Font-Size="16" OnClick="btnBack_Click" />
    </div>

    </form>
</body>
</html>

