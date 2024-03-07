<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="KIS2223Report.aspx.cs" Inherits="DAO_KIS2223Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>


.mydropdownlist
{
color: #fff;
font-size: 15px;
padding: 5px 10px;
border-radius: 5px;
background-color: lightcoral;
font-weight: bold;
}
</style>

     <meta charset="utf-8" />  
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />  
    <%--<link href="Content/bootstrap.cosmo.min.css" rel="stylesheet" /> --%> 
    <%--<link href="Content/StyleSheet.css" rel="stylesheet" />--%>  
         <!-- Bootstrap -->
    <link href="../cssPMKS/bootstrap.min.css" rel="stylesheet" />
 
    <!-- Datatables-->
    <link href="../cssPMKS/dataTables.bootstrap4.css" 
     rel="stylesheet" />
    <link href="../cssPMKS/buttons.bootstrap4.css" 
     rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h5>Accept / Reject List of Krishi Input Subsidy-2022-23</h5>
<hr />
    <table class="table-bordered  table table-striped " style="width: 100%;">
            <tr>
                <td>
                    Choose The Action:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlItems" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlItems_SelectedIndexChanged" Width="126px">
                    <asp:ListItem Text="--Choose--" Value="0" />
                    <asp:ListItem Text="Accept" Value="1" />
                    <asp:ListItem Text="Reject" Value="2" /> 
                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp; 
                </td>
           
        <td>
             <asp:Button ID="Button1" runat="server" Text="View" CssClass="btn btn-success" Height="42px" OnClick="Button1_Click" />
        </td>
                 </tr>
        <tr>
            <td colspan="3">
                  <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/excel.jpg" Height="22px" Width="33px" Visible="False" OnClick="ImageButton1_Click"/>
            </td>
        </tr>
        </table>

    <div>


</div>
    <asp:gridview ID="gdview1" runat="server" AutoGenerateColumns="false" Width="100%"  AlternatingRowStyle-CssClass="alt" Font-Size="10px" CssClass="Grid" EmptyDataText="No record found">
         <Columns>
                <asp:TemplateField HeaderText="SN">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1+"." %>
                        </ItemTemplate>
                </asp:TemplateField>
             <asp:BoundField DataField="Application_ID" HeaderText="Application ID" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle CssClass="smallSize" Font-Size="12px" />
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Applicantname" HeaderText="Applicant Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle CssClass="smallSize" Font-Size="12px" />
                              <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Father_Husband_Name" HeaderText="Father/Husband Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle CssClass="smallSize" Font-Size="12px" />
                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Blockname" HeaderText="Block Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle CssClass="smallSize" Font-Size="12px"  />
                               <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="panchayatname" HeaderText="panchayat Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle CssClass="smallSize" Font-Size="12px"  />
                               <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VillageName" HeaderText="Village Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle CssClass="smallSize" Font-Size="12px"  />
                               <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                            </asp:BoundField>
          </Columns>
    </asp:gridview>
    
</asp:Content>

<%--select 
[Application_ID],[ApplicantName],[Father_Husband_Name],[Blockname],[panchayatname],[VillageName],

from input2223_onlineapply where distcode= and dao_status=--%>