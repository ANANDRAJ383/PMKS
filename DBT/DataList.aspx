<%@ Page Title="" Language="C#" MasterPageFile="DBTMasterPage.master" AutoEventWireup="true" CodeFile="DataList.aspx.cs" Inherits="DBT_DataList" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
.mydatagrid
{
width: 100%;
border: solid 2px black;
min-width: 100%;
}
.header
{
background-color: #2a5197;
font-family: Arial;
color: White;
border: none 0px transparent;
height: 25px;
text-align: center;
font-size: 14px;
}

.rows
{    
background-color: #fff;
font-family: Arial;
font-size: 14px;
color: #000;
min-height: 25px;
text-align: left;
border:  0px ;
}
.rows:hover
{
background-color: #ff8000;
font-family: Arial;
color: #fff;
text-align: left;
}
.selectedrow
{
background-color: #ff8000;
font-family: Arial;
color: #fff;
font-weight: bold;
text-align: left;
}
.mydatagrid a /** FOR THE PAGING ICONS **/
{
background-color: Transparent;
padding: 5px 5px 5px 5px;

text-decoration: none;
font-weight: bold;
}

.mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/
{
background-color: #000;
color: #fff;
}
.mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
{
background-color: #c9c9c9;
color: #000;
padding: 5px 5px 5px 5px;
}
.pager
{
background-color: #646464;
font-family: Arial;
color: White;
height: 30px;
text-align: left;
}

.mydatagrid td
{
padding: 5px;
}
.mydatagrid th
{
padding: 5px;
}

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>Q Type</td>
            <td><asp:TextBox ID="txtTRDate" runat="server" TextMode="MultiLine" Width="1000px"></asp:TextBox></td>
            <td><asp:Button ID="btnSave" runat="server" Text="OK" class="btn btn-success" OnClick="btnSave_Click"  /></td>
            <td><asp:Button ID="btnExport" runat="server" Text="Excel" class="btn btn-success" OnClick="btnExport_Click"/></td>
        </tr>
    </table>
    <div>
        <asp:GridView id="grdData" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows"></asp:GridView>
    </div>
</asp:Content>

