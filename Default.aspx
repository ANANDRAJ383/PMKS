<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:FileUpload ID="FileUpload1"  CssClass="button"  runat="server" />
    <asp:Button ID="btnImport" CssClass="button" runat="server" Text="Import" OnClick="ImportCSV" />
             <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Send SMS" />
    <hr />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
        </div>
    </form>
</body>
</html>
