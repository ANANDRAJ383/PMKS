<%@ Page Title="" Language="C#" MasterPageFile="~/NODAL/NODALMasterPage.master" AutoEventWireup="true" CodeFile="DownloadFTODiesel.aspx.cs" Inherits="NODAL_DownloadFTODiesel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #1C6794; padding: 5px; margin-top: 5px; width: 100%;" align="center">FTO Diesel Subsidy Kharif- 2022-23 :- <asp:Label ID="lblBank" runat="server" Text=",HDFC BANK ,Raja Bazar"></asp:Label></div><br />
    <div class="row" >

         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
         <asp:GridView ID="Gridview2" runat="server" AutoGenerateColumns="false" Font-Size="12px" HeaderStyle-Font-Size="12px"  Width="100%
             " class="table table-bordered" DataKeyNames="Date, LotNo,LotID">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl. No." ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle Font-Names="Comic Sans MS" Font-Size="12px" ForeColor="Green" />
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                                                <ItemStyle HorizontalAlign="Center" Width="3%" />
                                                            </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Date" DataField="Date" >
                                                              <HeaderStyle Font-Names="Venrdana" Font-Size="13px" ForeColor="Green"  Width="3%"/>
                                                            </asp:BoundField>
                                                           
                                                        <asp:BoundField HeaderText="Lot No." DataField="LotNo" >
                                                              <HeaderStyle Font-Names="Venrdana" Font-Size="13px" ForeColor="Green"  Width="3%" />
                                                            </asp:BoundField>
                                                        <asp:BoundField HeaderText="Total No. of Beneficiary" DataField="aa" >
                                                              <HeaderStyle Font-Names="Venrdana" Font-Size="13px" ForeColor="Green"  Width="3%"/>
                                                            </asp:BoundField>
                                                            <asp:BoundField HeaderText="Total Amount" DataField="amt" >
                                                              <HeaderStyle Font-Names="Venrdana" Font-Size="13px" ForeColor="Green"  Width="3%" />
                                                            </asp:BoundField>


                                                          


                                                            <asp:TemplateField HeaderText="Dowload FTO">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="txtDownload" runat="server"   Text="FTO Download" OnClick="txtDetails_Click"  ></asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle Font-Size="13px" HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                                            </asp:TemplateField>
                                                             
                                                              <asp:BoundField HeaderText="Send Status" DataField="aaSEND" >
                                                              <HeaderStyle Font-Names="Venrdana" Font-Size="13px" ForeColor="Green"  Width="3%" />
                                                            </asp:BoundField>

                                                         
                                                        </Columns>
                                                        <HeaderStyle Font-Size="12px" />
                                                    </asp:GridView>

                    </ContentTemplate>
            </asp:UpdatePanel>
    </div>
</asp:Content>

