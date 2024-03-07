<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMain.master" AutoEventWireup="true" CodeFile="StopPayment.aspx.cs" Inherits="StopPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li><a href="dashboardNew.aspx">Dashboard</a></li>
        <li>Physical Verification</li>
    </ul>
    <div class="container-fluid">
        <h2 class="mt-4">Stop Payment</h2>
        <p>Farmer 66540 can be search by Aadhaar Number </p>
        <p>Step 1: Select Lot No . </p>
        <p>Step 2: Generate&nbsp; Farmerlist in XML Format.</p>


        <!-- Charts -->
        <div class="row">
            <div class="col-md-12 p-sm-5" style="left: 0px; top: 0px">
                <form action="" class="w-sm-50 w-auto mx-auto">

                    <div class="form-group">
                        <label for="name">PM KISAN Registration No:</label>
                        <asp:TextBox ID="txt1" runat="server" class="form-control"   placeholder="Enter Registration No."></asp:TextBox> 
                    </div>
                   <asp:Button ID="Button1" class="btn btn-danger" runat="server" Text="Search"  Visible="true" OnClick="Button1_Click"></asp:Button>
                    <br />
                    <br />
                    <br />
                    <h2 class="mt-4">XML Generate Proccess</h2>
                    <asp:Button ID="btnUpdate" class="btn btn-danger" runat="server" Text="Step -1: Update Date" OnClick="btnUpdate_Click"   Enabled="False"></asp:Button>
                    
                    
                            <asp:DropDownList ID="ddlLot" runat="server"   Font-Names="Verdana" Font-Size="12px"
                                class="btn btn-default dropdown-toggle">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Lot No-1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Lot No-2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Lot No-3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Lot No-4" Value="4"></asp:ListItem>
                       
                            </asp:DropDownList>

                    <asp:Button ID="btnCout" class="btn btn-primary" runat="server" Text="Count Total Farmer" OnClick="btnCout_Click"></asp:Button>
                    <asp:Button ID="btnGenerate" class="btn btn-primary b-btn" runat="server" Text="Step -2: Generate XML" OnClick="btnGenerate_Click"></asp:Button>
                    <br />
                    <asp:Label ID="lblAction" runat="server" Text=""></asp:Label>

                    <br />

                    <asp:GridView runat="server" ID="grd1" EmptyDataText="Data not avialable..!!!!" AutoGenerateColumns="False" >
                        <columns>
                            <asp:TemplateField HeaderText="sl#" HeaderStyle-BackColor="White" HeaderStyle-Font-Size="12px" ItemStyle-Font-Size="12px" HeaderStyle-Font-Names="Verdana">
                                <itemtemplate>
                                    <%#Container.DataItemIndex+1+"."%>
                                </itemtemplate>
                                <headerstyle cssclass="smallSize" font-size="12px" />
                            </asp:TemplateField>
                           
                            <asp:BoundField DataField="ActionDate" HeaderText="XML Generate Date" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="White" HeaderStyle-CssClass="smallSize">
                                <headerstyle cssclass="smallSize" font-size="12px" font-names="Verdana" />
                                <itemstyle horizontalalign="Left" font-size="12px" font-names="Verdana" />
                            </asp:BoundField>
                            <asp:BoundField DataField="XMLSheet" HeaderText="XML Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="White" HeaderStyle-CssClass="smallSize" HeaderStyle-HorizontalAlign="Left">
                                <headerstyle cssclass="smallSize" horizontalalign="Left" font-size="12px" font-names="Verdana" />
                                <itemstyle horizontalalign="Left" font-size="12px" font-names="Verdana" />
                            </asp:BoundField>
                             <asp:TemplateField HeaderText="Download Link" HeaderStyle-CssClass="smallSize">
                                <itemtemplate>
                                    <asp:LinkButton ID="lnkregid" runat="server" Text='<%#Bind("XMLSheet") %>' CommandArgument='<%#Bind("XMLSheet") %>' CommandName="view" ForeColor="Red" Font-Size="12px" Font-Names="Verdana" OnClick="lnkregid_Click"></asp:LinkButton>
                                    
                                </itemtemplate>
                                <headerstyle cssclass="smallSize" font-size="12px" font-names="Verdana" />
                            </asp:TemplateField>
                        </columns>

                    </asp:GridView>
                </form>
            </div>
        </div>
    </div>

</asp:Content>

