<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMain.master" AutoEventWireup="true" CodeFile="PhysicalVerification.aspx.cs" Inherits="PhysicalVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <ul class="breadcrumb">
          <li><a href="dashboardNew.aspx">Dashboard</a></li>
          <li>Physical Verification</li>
      </ul>
      <div class="container-fluid">
        <h2 class="mt-4">Physical Verification</h2>
        <p>Particular Farmer 5-10 % can be search by Aadhaar Number</p>
        <p>Step 1: Click Update Button . </p>
        <p>Step 2: Generate 5%-10% Farmerlist in XML Format.</p>


        <!-- Charts -->
        <div class="row">
        	<div class="col-md-12 p-sm-5">
                <form action="" class="w-sm-50 w-auto mx-auto">

                	<div class="form-group">
						<label for="name">Aadhaar No:</label>
						<input type="text" class="form-control" id="name" placeholder="Enter Aadhar No.">
					</div>
					<button type="submit" class="btn btn-primary b-btn">Submit</button>
                    <br /><br /><br />
                     <h2 class="mt-4">XML Generate Proccess</h2>
                    <asp:Button ID="btnUpdate"  class="btn btn-danger" runat="server"  Text="Step -1: Update Date" OnClick="btnUpdate_Click"></asp:Button>
                    <asp:Button  ID="btnCout" class="btn btn-primary" runat="server"  Text="Count Total Farmer" OnClick="btnCout_Click"></asp:Button>
                    <asp:Button  ID="btnGenerate" class="btn btn-primary b-btn" runat="server" Text="Step -2: Generate XML" OnClick="btnGenerate_Click"></asp:Button>
                    <br />
                    <asp:Label ID="lblAction" runat="server" Text=""></asp:Label>

                    <br />

                       <asp:GridView runat="server" ID="grd1" EmptyDataText="Data not avialable..!!!!" AutoGenerateColumns="False"  DataKeyNames="XMLSheet" >
                        <columns>
                            <asp:TemplateField HeaderText="sl#" HeaderStyle-BackColor="White" HeaderStyle-Font-Size="12px" ItemStyle-Font-Size="12px" HeaderStyle-Font-Names="Verdana">
                                <itemtemplate>
                                    <%#Container.DataItemIndex+1+"."%>
                                </itemtemplate>
                                <headerstyle cssclass="smallSize" font-size="12px" />
                            </asp:TemplateField>
                           
                            <asp:BoundField DataField="actiondate" HeaderText="XML Generate Date" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="White" HeaderStyle-CssClass="smallSize">
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

