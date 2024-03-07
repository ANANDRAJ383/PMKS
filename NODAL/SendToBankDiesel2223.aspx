<%@ Page Title="" Language="C#" MasterPageFile="~/NODAL/NODALMasterPage.master" AutoEventWireup="true" CodeFile="SendToBankDiesel2223.aspx.cs" Inherits="NODAL_SendToBankDiesel2223" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #1C6794; padding: 5px; margin-top: 5px; width: 100%;" align="center">SEND TO BANK (DIESEL SUBSIDY 2022-23)</div><br />
     
    <center>
    <table class="table-bordered table table-striped " style="width: 100%; >
       

        <tr>

             <td>Season </td>
                <td>
                    <asp:DropDownList ID="ddlSeasonID" runat="server"  Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlSeasonID_SelectedIndexChanged">
                     
            <asp:ListItem Text="खरीफ (2022-23)" Value="2" Selected="True"></asp:ListItem>
                  

                    </asp:DropDownList>

                </td>
            <td>Date:</td>
            <td> <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                               <asp:DropDownList ID="ddlDate" runat="server"  class="btn btn-default dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged"></asp:DropDownList>
                               </ContentTemplate>
                        </asp:UpdatePanel> </td>
            <td>Lot No.</td>
            <td><asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate><asp:DropDownList ID="ddlLot" runat="server"  class="btn btn-default dropdown-toggle" ></asp:DropDownList> </ContentTemplate>
                        </asp:UpdatePanel> </td>
            <td>
                     <asp:Button ID="btnsearch" runat="server" Text="Search"   Font-Bold="True" Font-Names="Century Gothic"  class="btn btn-success" OnClick="btnsearch_Click" />

            </td>
        </tr>

    </table>
        </center>
    <table>
        <tr>
            <td>

                
    <div class="panel panel-success">
        <div class="panel-heading" style="font-weight: bold; font-size: 14px;">Beneficery Details</div>
        <div class="panel-body" style="font-size: 12px; overflow-y: scroll; height:300px;" >
           <asp:gridview id="grdChecke" runat="server" autogeneratecolumns="false" datakeynames="Application_ID" allowpaging="false" 
                            emptydatatext="No Record Found.." CssClass="table table-bordered table-striped"> 
                                            <Columns>
                                                                                             
                                              <%--   <asp:BoundField DataField="slno" HeaderText="Sl." ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="smallSize">
                                                    <HeaderStyle BackColor="Green" CssClass="smallSize" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                               --%>
                              <asp:BoundField DataField="UserNumber" HeaderText="User Number" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle BackColor="Green" CssClass="smallSize"  Font-Size="12px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="UserName" HeaderText="User Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle BackColor="Green" CssClass="smallSize"  Font-Size="12px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="UserReference" HeaderText="User Reference" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle BackColor="Green" CssClass="smallSize"  Font-Size="12px"  />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SettlementDate" HeaderText="Settlement Date" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle BackColor="Green" CssClass="smallSize"  Font-Size="12px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Users_Bank_Account_Number" HeaderText="User's Bank Account Number" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle BackColor="Green" CssClass="smallSize"  Font-Size="12px"  />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="Destinationbankinn" HeaderText="Destinationbankinn" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle BackColor="Green" CssClass="smallSize"  Font-Size="12px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="AadhaarNumber" HeaderText="Beneficiary Aadhaar No" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="smallSize" HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle BackColor="Green" CssClass="smallSize" HorizontalAlign="Left"  Font-Size="12px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                                               
                             <asp:BoundField DataField="Application_ID" HeaderText="User Credit Reference" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle BackColor="Green" CssClass="smallSize"  Font-Size="12px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DAO_Approvedamt" HeaderText="Amount" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="smallSize">
                                <HeaderStyle BackColor="Green" CssClass="smallSize"  Font-Size="12px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MobileNumber" HeaderText="Mobile No" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Green" HeaderStyle-CssClass="smallSize" HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle BackColor="Green" CssClass="smallSize" HorizontalAlign="Left"  Font-Size="12px"  />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                                            </Columns>
                                        </asp:gridview>
        </div>

    </div>
            </td>
        </tr>
    </table>

    <asp:Panel ID="Panel1" runat="server">
            <center>
            <table>
                <tr>

                    <td align="left">&nbsp;&nbsp;
                        <asp:Button ID="Button4" runat="server" Text="Get OTP" class="btn btn-success" OnClick="Button4_Click" Visible="false"/></td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" MaxLength="4" class="form-control" Width="70px" Visible="false"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" Text="Generate CSV File" class="btn btn-success" Visible="false" OnClick="Button3_Click" />
                    </td>
                    <td>  </td>
                </tr>
                <tr>
                    <td>&nbsp;<td align="left" colspan="3">
                        <asp:LinkButton ID="LinkButton2" runat="server" Font-Names="Verdana" Font-Size="12px" OnClick="LinkButton2_Click" Visible="False">Re-Send OTP</asp:LinkButton>
                    </td>
                       
                </tr>
            </table>
                <table>
                    <tr>
                        <td>

                             <asp:Label ID="Label2" runat="server" Text="" class="label label-danger" Font-Size="12px"></asp:Label> 
                        </td>
                    </tr>
                </table>
                </center>
        </asp:Panel>
</asp:Content>

