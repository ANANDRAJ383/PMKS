<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMain.master" AutoEventWireup="true" CodeFile="FreshData.aspx.cs" Inherits="FreshData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <ul class="breadcrumb">
          <li><a href="dashboardNew.aspx">Dashboard</a></li>
          <li>Fresh & Reconsider Verification</li>
      </ul>
      <div class="container-fluid">
        <h2 class="mt-4">Fresh & Reconsider Verification</h2>
        <p>Particular Fresh and Reconsider Farmer can be search by Aadhaar Number</p>
        <p>Step 1: Click Update Button . </p>
        <p>Step 2: Generate Farmerlist in XML Format.</p>


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
				</form>
        	</div>
        </div>        
      </div>

</asp:Content>

