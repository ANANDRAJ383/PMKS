<%@ Page Title="" Language="C#" MasterPageFile="ADMMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ADM_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .card-body {
    -ms-flex: 1 1 auto;
    flex: 1 1 auto;
    min-height: 1px;
    padding: 0.25rem;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	
	<div class="row mt-5">

        <div class="col-lg-6">
            <div class="col-sm-12">
   <div class="card bg-secondary  mb-3" >
  <div class="card-header"> <b>AC Report</b></div>
  <div class="card-body">
    <table class="table table-success table-striped">
 <tr>
  <td>Type</td>
  <td>Total App</td>
  <td >Accepted</td>
  <td class="text-danger">Rejected</td>
  <td >Pending</td>
</tr>
     <tr>
  <td>NEW</td>
  <td >
      <asp:Label id="lblTotalAC" runat="server" Text="1000"></asp:Label></td>
  <td><asp:Label id="lblACAcpt" runat="server" Text="500"></asp:Label></td>
  <td class="text-danger"><asp:Label id="lblACRjct" runat="server" Text="300"></asp:Label></td>
  <td><asp:Label id="lblACPending" runat="server" Text="200"></asp:Label></td>
</tr>

</table>
  </div>
  </div>
      </div>

  <div class="col-sm-12">
    <div class="card bg-warning">
         <div class="card-header"><b>CO Report</b></div>
     
  <div class="card-body">
     <table class="table table-dark table-striped-columns"> 
 <tr>
  <th scope="col">Type</th>
  <th scope="col">Total App</th>
  <th scope="col">Accepted</th>
  <th scope="col" class="text-danger">Rejected</th>
  <th scope="col">Pending</th>
</tr>
     <tr>
  <td>V1</td>
  <td >
      <asp:Label id="lblCOTotal" runat="server" Text="1000"></asp:Label></td>
  <td><asp:Label id="lblCOAcpt" runat="server" Text="500"></asp:Label></td>
  <td class="text-danger"><asp:Label id="lblCORjct" runat="server" Text="300"></asp:Label></td>
  <td><asp:Label id="lblCOPending" runat="server" Text="200"></asp:Label></td>
</tr>

       <tr>
  <td>V2</td>
  <td >
      <asp:Label id="lblCOReTotal" runat="server" Text="1000"></asp:Label></td>
  <td><asp:Label id="lblCOReAcpt" runat="server" Text="500"></asp:Label></td>
  <td class="text-danger"><asp:Label id="lblCOReRjct" runat="server" Text="300"></asp:Label></td>
  <td><asp:Label id="lblCORePending" runat="server" Text="200"></asp:Label></td>
</tr>

          <tr>
  <td>V3</td>
  <td >
      <asp:Label id="lblCOReReTotal" runat="server" Text="1000"></asp:Label></td>
  <td><asp:Label id="lblCOReReAcpt" runat="server" Text="500"></asp:Label></td>
  <td class="text-danger"><asp:Label id="lblCOReReRjct" runat="server" Text="300"></asp:Label></td>
  <td><asp:Label id="lblCOReRePending" runat="server" Text="200"></asp:Label></td>
</tr>
         <tr>
  <td >V4 (Pending)</td>
  
  <td colspan="4"><asp:Label id="lblv4pending" runat="server" Text="200"></asp:Label></td>
</tr>
         <tr>
  <td>V5 (pending)</td>
  
     
  <td colspan="4"><asp:Label id="lblV5pending" runat="server" Text="200"></asp:Label></td>
</tr>

</table>
  </div>
      </div>
  </div>
        </div>


        <div class="col-lg-6">

             <div class="col-sm-12">
   <div class="card bg-info mb-3" >
  <div class="card-header"> <b>DAO Report</b></div>
  <div class="card-body">
    <table class="table table-success table-striped-columns">
 <tr>
  <td>Type</td>
  <td>Total App</td>
  <td >Accepted</td>
  <td class="text-danger">Rejected</td>
  <td >Pending</td>
</tr>
     <tr>
  <td>V2(RECON)</td>
  <td >
      <asp:Label id="lblDAOReTotal" runat="server" Text="1000"></asp:Label></td>
  <td><asp:Label id="lblDAOReAcpt" runat="server" Text="500"></asp:Label></td>
  <td class="text-danger"><asp:Label id="lblDAOReRjct" runat="server" Text="300"></asp:Label></td>
  <td><asp:Label id="lblDAORePending" runat="server" Text="200"></asp:Label></td>
</tr>

        <tr>
  <td>V3(RE-RECON)</td>
  <td >
      <asp:Label id="lblDAOReReTotal" runat="server" Text="1000"></asp:Label></td>
  <td><asp:Label id="lblDAOReReAcpt" runat="server" Text="500"></asp:Label></td>
  <td class="text-danger"><asp:Label id="lblDAOReReRjct" runat="server" Text="300"></asp:Label></td>
  <td><asp:Label id="lblDAOReRePending" runat="server" Text="200"></asp:Label></td>
</tr>

       
</table>
  </div>
  </div>
      </div>

        <div class="col-sm-12">
    <div class="card bg-success">
         <div class="card-header"><b>ADM(Revenu) Report</b></div>
     
  <div class="card-body">
     <table class="table table-success table-bordered table-hover "> 
 <tr>
  <th scope="col">Type</th>
  <th scope="col">Total App</th>
  <th scope="col">Accepted</th>
  <th scope="col">Rejected</th>
  <th scope="col">Pending</th>
</tr>
     <tr>
  <td>V1</td>
  <td >
      <asp:Label id="lblADMRTotal" runat="server" Text="1000"></asp:Label></td>
  <td><asp:Label id="lblADMRAcpt" runat="server" Text="500"></asp:Label></td>
  <td class="text-danger"><asp:Label id="lblADMRRjct" runat="server" Text="300"></asp:Label></td>
  <td><asp:Label id="lblADMRPending" runat="server" Text="200"></asp:Label></td>
</tr>

       <tr>
  <td>V2</td>
  <td >
      <asp:Label id="lblADMRReTotal" runat="server" Text="1000"></asp:Label></td>
  <td><asp:Label id="lblADMRReAcpt" runat="server" Text="500"></asp:Label></td>
  <td class="text-danger"><asp:Label id="lblADMRReRjct" runat="server" Text="300"></asp:Label></td>
  <td><asp:Label id="lblADMRRePending" runat="server" Text="200"></asp:Label></td>
</tr>

          <tr>
  <td>V3</td>
  <td >
      <asp:Label id="lblADMRReReTotal" runat="server" Text="1000"></asp:Label></td>
  <td><asp:Label id="lblADMRReReAcpt" runat="server" Text="500"></asp:Label></td>
  <td class="text-danger"><asp:Label id="lblADMRReReRjct" runat="server" Text="300"></asp:Label></td>
  <td><asp:Label id="lblADMRReRePending" runat="server" Text="200"></asp:Label></td>
</tr>

         
</table>
  </div>
      </div>
  </div>
        </div>

  
</div><!----===End Row===--->

    <div class="row">
        
       
        



<!---- <div class="col-sm-6">
    <div class="card bg-info">
         <div class="card-header"><b>CO Report</b></div>
     
  <div class="card-body">
     <table class="table table-dark table-striped-columns"> 
 <tr>
  <th scope="col">Type</th>
  <th scope="col">Total App</th>
  <th scope="col">Accepted</th>
  <th scope="col" class="text-danger">Rejected</th>
  <th scope="col">Pending</th>
</tr>
     <tr>
  <th scope="row">V1.</th>
  <td >1000</td>
  <td>500</td>
  <th scope="row" class="text-danger">300</th>
  <td>200</td>
</tr>

         <tr>
 <th scope="row">V2.</th>
  <td >1000</td>
  <td>500</td>
  <th scope="row" class="text-danger">300</th>
  <td>200</td>
</tr>

         <tr>
 <th scope="row">V3.</th>
  <td >1000</td>
  <td>500</td>
  <th scope="row" class="text-danger">300</th>
  <td>200</td>
</tr>

         <tr>
 <th scope="row">V4.</th>
  <td >1000</td>
  <td>500</td>
  <th scope="row" class="text-danger">300</th>
  <th scope="row" >200</th>
</tr>

</table>
  </div>
      </div>
  </div>--->

</div><!----===End Row===--->
	

</asp:Content>

