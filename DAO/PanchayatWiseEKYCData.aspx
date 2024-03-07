<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="PanchayatWiseEKYCData.aspx.cs" Inherits="DBT_DistrictWiseEKYCData" EnableEventValidation = "false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8" />  
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />  
    <link href="Content/bootstrap.cosmo.min.css" rel="stylesheet" />  
    <link href="Content/StyleSheet.css" rel="stylesheet" />  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">EKYC Data Report as on (15-10-2023) </div><br />

    <div>
        <div><asp:Button ID="btnExport" runat="server" Text="Export To Excel" CssClass="btn btn-success"  OnClick="btnExport_Click" /></div>
        <div class="table-responsive">  
                                    <asp:GridView ID="gvdata" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"
                                         EmptyDataText="There are no data records to display.">  
                                        <Columns> 
                                             <asp:TemplateField HeaderText="SN" >
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                                            <asp:BoundField DataField="DistName" HeaderText="Distrit Name" />
                                            <asp:BoundField DataField="BlockName" HeaderText="Block Name" />
                                            <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" />
                                            <asp:BoundField DataField="Total" HeaderText="Total"  />  
                                            <asp:BoundField DataField="KYCDone" HeaderText="KYCDone" />  
                                            <asp:BoundField DataField="KYCPending" HeaderText="KYC Pending" />  
                                        </Columns>  
                                    </asp:GridView>  
                                </div>
    </div>
      
</asp:Content>

