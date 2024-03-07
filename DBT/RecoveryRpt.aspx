<%@ Page Title="" Language="C#" MasterPageFile="DBTMasterPage.master" AutoEventWireup="true" CodeFile="RecoveryRpt.aspx.cs" Inherits="DBT_RecoveryRpt" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="divData" runat="server" style="font-family: Cambria; font-size: 18px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">
        <asp:Label ID="lblMsg" runat="server" Text="पीएम किसान रिकवरी डेटा रिपोर्ट "></asp:Label>  
         :- <asp:Button ID="Button1" runat="server" Text="Export Excel" OnClick="Button1_Click" /></div><br />

    <div>

        <div class="table-responsive">  
                                    <asp:GridView ID="gvdata" runat="server" Width="100%" 
                                        CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False"
                                         EmptyDataText="There are no data records to display." Font-Size="18px">  
                                        <Columns> 
                                             <asp:TemplateField HeaderText="क्रम संख्या" >
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                                            <asp:BoundField DataField="DistName" HeaderText="जिले का नाम" ItemStyle-ForeColor="#0033CC" />  
                                            <asp:BoundField DataField="Total_ITR" HeaderText="कुल आईटीआर"  />  
                                            <asp:BoundField DataField="Total_Ineligible" HeaderText="कुल अपात्र"  />  
                                            <asp:BoundField DataField="Total_ITRRecovery" HeaderText="कुल आईटीआर वसूली"  />  
                                            <asp:BoundField DataField="Total_IneligibleRecovery" HeaderText="कुल अपात्र वसूली" />  
                                            <asp:BoundField DataField="BKAC" HeaderText="भारत कोष"  />  
                                            <asp:BoundField DataField="RKAC" HeaderText="राज्य कोष खाता संख्या (40903138323, IFSC: SBIN0006379)" />  
                                            <asp:BoundField DataField="SLBC" HeaderText="SLBC/BANK द्वारा वसूली" />  
                                            <asp:BoundField DataField="PMKAC" HeaderText="प्रसानिक मद-खाता संख्या (38269533475, IFSC: SBIN0006379)" />  
                                            <asp:BoundField DataField="OtherAC" HeaderText="अन्य कारणों से अयोग्य घोषित किसान खाता संख्या (40903140467, IFSC: SBIN0006379)"  />  
                                        </Columns>  
                                    </asp:GridView>  
                                </div>
    </div>
</asp:Content>

