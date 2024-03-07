<%@ Page Title="" Language="C#" MasterPageFile="ADMRMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ADMR_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	 <div class="my-5" id="b-homedb">
				<div class="">
					<div class="row text-center pl-4" id="sortable-cards">
					    <div class="col-lg-6 col-sm-12 p-3 b-customize" style="background-color:aqua">
					        <div class="bg-light p-4 b-dbcard">
					        	<%--<i class="fa fa-wheat position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i> --%>
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total Farmers for Verification'</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"> <asp:Label ID="lblTotalForVerify" runat="server"  Text ="10000"></asp:Label> </h3>
					        		
					        	</div>
					        </div>
					    </div>

					    <div class="col-lg-6 col-sm-12 p-3 b-customize" style="background-color:aqua">
					        <div class="bg-light p-4 b-dbcard">
					        	<%--<i class="fas fa-vial position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i> --%>
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total AC Verified</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><asp:Label ID="lblTotalAcVerifyed" runat="server"  Text ="10000"></asp:Label></h3>
					        		
					        	</div>
					        </div>
					    </div>

					    <div class="col-lg-6 col-sm-12 p-3 b-customize" style="background-color:aqua">
					        <div class="bg-light p-4 b-dbcard">
					        	<%--<i class="fas fa-tractor position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i> --%>
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total Rejected</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><asp:Label ID="lblTotalCORejected" runat="server"  Text ="2000"></asp:Label></h3>
					        		 
					        	</div>
					        </div>
					    </div>

					    <div class="col-lg-6 col-sm-12 p-3 b-customize" style="background-color:aqua">
					        <div class="bg-light p-4 b-dbcard">
					        	<%--<i class="fas fa-rupee-sign position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i> --%>
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total Accepted</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><asp:Label ID="lblTotalCOAccepted" runat="server"  Text ="7000"></asp:Label></h3>
					        		
					        	</div>
					        </div>
					    </div>

						<div class="col-lg-6 col-sm-12 p-3 b-customize" style="background-color:aqua">
					        <div class="bg-light p-4 b-dbcard">
					        	<%--<i class="fas fa-rupee-sign position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i> --%>
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Pending for Verification</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><asp:Label ID="lblTotalPending" runat="server"  Text ="1000"></asp:Label></h3>
					        		
					        	</div>
					        </div>
					    </div>

						<div class="col-lg-6 col-sm-12 p-3 b-customize" style="background-color:aqua">
					        <div class="bg-light p-4 b-dbcard">
					        	<%--<i class="fas fa-rupee-sign position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i> --%>
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Pending for Verification</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><asp:Label ID="Label1" runat="server"  Text ="1000"></asp:Label></h3>
					        		
					        	</div>
					        </div>
					    </div>
					</div>
				</div>
		 </div>
</asp:Content>

