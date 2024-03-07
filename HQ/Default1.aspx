﻿<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="ADM_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="my-5" >
				<div class="">
					<div style="text-align: center" class="bg-light p-4 b-dbcard"><h3>नए आवेदन</h3>
					<div class="row text-center pl-4" >
					    <div class="col-lg-3 col-sm-12 p-3 b-customize" >
					        <div class="bg-warning p-4 b-dbcard">
					        <%--	<i class="fa fa-wheat position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i>--%>
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total Application Recevied</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"> <asp:Label ID="lblTotalForVerifyN" runat="server"  Text ="0"></asp:Label> </h3>
					        		
					        	</div>
					        </div>
					    </div>
					    <div class="col-lg-3 col-sm-12 p-3 b-customize" >
					        <div class="bg-info  p-4 b-dbcard">
					        	<%--<i class="fas fa-vial position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i> --%>
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total Pending</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><asp:Label ID="lblTotalPendingN" runat="server"  Text ="0"></asp:Label></h3>
					        		
					        	</div>
					        </div>
					    </div>
						<div class="col-lg-3 col-sm-12 p-3 b-customize" >
					        <div class="bg-success  p-4 b-dbcard">
					        	
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total Approved</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><asp:Label ID="lblTotalAcceptedN" runat="server"  Text ="0"></asp:Label></h3>
					        		
					        	</div>
					        </div>
					    </div>
					    <div class="col-lg-3 col-sm-12 p-3 b-customize" >
					        <div class="bg-danger  p-4 b-dbcard">
					        	
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total Rejected</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><asp:Label ID="lblTotalRejectedN" runat="server"  Text ="0"></asp:Label></h3>
					        		 
					        	</div>
					        </div>
					    </div>

					</div>
					
					</div>
				</div>
		 </div>
	
	

</asp:Content>
