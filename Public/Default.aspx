<%@ Page Title="" Language="C#" MasterPageFile="PublicMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Public_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br/><br/>
    <table class="table-bordered  table table-striped ">
        <tr>
            <td>
                <a href="AppStatus.aspx"><span>1. Check Registration Status</span></a>
            </td>
            <td>
                <a href="PrintRegistration.aspx"><span>2. Print Registration Status</span></a>  
            </td>
            
        </tr>
        <tr>
            <td>
                <a href="CheckApplicationStatusPM.aspx"><span>3. Check PM Kisan Registration Status</span></a>
            </td>
            <td>
                <a href="Print_PMKisanYojna.aspx"><span>4. Print PM Kisan Registration </span></a>
            </td>
        </tr>
    </table>
</asp:Content>

