<%@ Page Title="" Language="C#" MasterPageFile="DBTMasterPage.master" AutoEventWireup="true" CodeFile="DistrictWisePVData.aspx.cs" Inherits="DBT_DistrictWisePVData" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8" />  
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />  
    <%--<link href="Content/bootstrap.cosmo.min.css" rel="stylesheet" /> --%> 
    <%--<link href="Content/StyleSheet.css" rel="stylesheet" />--%>  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">
        <asp:Label ID="lblMsg" runat="server" Text="Physical Verification Data Report"></asp:Label> :-         
         <asp:Button ID="Button1" runat="server" Text="Export Excel" OnClick="Button1_Click" />

    </div><br />

    <div>

        <div class="table-responsive"> 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                                    <asp:GridView ID="gvdata" runat="server" Width="100%" CssClass="table table-bordered table-striped"
                                        AutoGenerateColumns="False"
                                         EmptyDataText="There are no data records to display.">  
                                        <Columns> 
                                             <asp:TemplateField HeaderText="SN" >
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                                            <asp:BoundField DataField="DistName" HeaderText="Distrit Name" ReadOnly="True" />  
                                            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />  
                                            <asp:BoundField DataField="Ineligible" HeaderText="Ineligible" SortExpression="Ineligible" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" />  
                                            <asp:BoundField DataField="Eligible" HeaderText="Eligible" SortExpression="Eligible" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />  
                                            <asp:BoundField DataField="Death" HeaderText="Death" SortExpression="Death" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" /> 
                                            <asp:BoundField DataField="DAO_Status" HeaderText="DAO Verifyed" /> 
                                         
                                        </Columns>  
                                    </asp:GridView>  

                               </ContentTemplate>
                        </asp:UpdatePanel>
                                </div>
    </div>
      
</asp:Content>

