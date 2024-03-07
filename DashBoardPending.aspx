<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageMain.master" AutoEventWireup="true" CodeFile="DashBoardPending.aspx.cs" Inherits="DashBoardPending" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="container-fluid">
                    <div class="d-flex clearfix mt-4">
                        <h3 class="d-inline-block" style="font-size: 32px;">Dashboard</h3>
                        <span class="ml-auto d-inline-block align-self-center">
                            <button type="button" class="btn btn-primary b-btn"><span class="fas fa-download fa-sm"></span>Statistic</button></span>
                    </div>
                </div>
    <div class="my-5" id="b-homedb">

			<div class="container">
				<h4 class="text-center mb-3 b-latest-data">Fresh Application Pending Latest Data - All Levels</h4>
				<div class="pl-4 text-right" style="font-size: 24px">
					<span class="mr-2" id="one-item-row" style="cursor: pointer;">
						<i class="fas fa-bars"></i>
					</span>
					<span class="mr-2" id="two-item-row" style="cursor: pointer;">
						<i class="fas fa-th-large"></i>
					</span>
					<span class="mr-2" id="three-item-row" style="cursor: pointer;">
						<i class="fas fa-th"></i>
					</span>
				</div>
				
				<div class="">
					<div class="row text-center pl-4" id="sortable-cards">
					    <div class="col-lg-6 col-sm-12 p-3 b-customize">
					        <div class="bg-light p-4 b-dbcard">
					        	<i class="fa fa-wheat position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i> 
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total Pending at AC Level</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><a href="PendingReport.aspx"><asp:Label ID="lbl1" runat="server"  Text =""></asp:Label></a>  </h3>
					        		<div class="text-left" style="margin: 10px 0px 5px;">
					        			<span class="badge badge-success">+8%</span> 
					        			<span style="font-size:13px;"> From previous period</span>
					        		</div>
					        	</div>
					        </div>
					    </div>

					    <div class="col-lg-6 col-sm-12 p-3 b-customize">
					        <div class="bg-light p-4 b-dbcard">
					        	<i class="fas fa-vial position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i> 
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total Pending at CO Level</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><a href="PendingReportCO.aspx"><asp:Label ID="Label1" runat="server"  Text =""></asp:Label></a> </h3>
					        		<div class="text-left" style="margin: 10px 0px 5px;">
					        			<span class="badge badge-success">12%</span> 
					        			<span style="font-size:13px;"> From previous period</span>
					        		</div>
					        	</div>
					        </div>
					    </div>

					    <div class="col-lg-6 col-sm-12 p-3 b-customize">
					        <div class="bg-light p-4 b-dbcard">
					        	<i class="fas fa-tractor position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i> 
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total Pending at ADM Level</p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><a href="PendingReportADM.aspx"><asp:Label ID="Label2" runat="server"  Text =""></asp:Label></a> </h3>
					        		<div class="text-left" style="margin: 10px 0px 5px;">
					        			<span class="badge badge-success">4%</span> 
					        			<span style="font-size:13px;"> From previous period</span>
					        		</div> 
					        	</div>
					        </div>
					    </div>

					    <%--<div class="col-lg-6 col-sm-12 p-3 b-customize">
					        <div class="bg-light p-4 b-dbcard">
					        	<i class="fas fa-rupee-sign position-absolute" style="font-size:35px; right: 40px; top: 40px;"></i> 
					        	<div class=""> 
					        		<p class="text-left font-weight-bold" style="font-size: 14px;">Total Pendng </p>
					        		<h3 class="text-left font-weight-bold" style="margin-top: -5px"><asp:Label ID="Label3" runat="server"  Text =""></asp:Label></h3>
					        		<div class="text-left" style="margin: 10px 0px 5px;">
					        			<span class="badge badge-success">+28%</span> 
					        			<span style="font-size:13px;"> From previous period</span>
					        		</div>
					        	</div>
					        </div>
					    </div>--%>

					</div>
				</div>

			</div>

		</div>
</asp:Content>

