<%@ Page Title="" Language="C#" MasterPageFile="~/NODAL/NODALMasterPage.master" AutoEventWireup="true" CodeFile="FTODieselSubsidt2223.aspx.cs" Inherits="NODAL_FTODieselSubsidt2223" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">

 p.MsoNormal
	{margin-top:0cm;
	margin-right:0cm;
	margin-bottom:10.0pt;
	margin-left:0cm;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
        .auto-style1 {
            height: 32px;
        }
        .auto-style2 {
            height: 248px;
        }
    </style>
    <script type="text/javascript">

        function printdiv(printpage) {
            var headstr = "<html><head><title></title></head><body>";
            var footstr = "</body>";
            var newstr = document.all.item(printpage).innerHTML;
            var oldstr = document.body.innerHTML;
            document.body.innerHTML = headstr + newstr + footstr;
            window.print();
            document.body.innerHTML = oldstr;
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <center>
          <button type="button" class="btn btn-danger" onclick="printdiv('div_print');">Print <span class="badge">1</span></button>      
        </center> 
    <div id="div_print" width="920px">

    <div class="panel panel-success">
        <div class="panel-heading" style="font-weight: bold; font-size: 18px;">FTO Diesel Subsidy Kharif- 2022-23</div>
        <div class="panel-body" style="font-size: 12px;">
            <table class="table table-bordered">
                <tr>

                    <td align="center" style="font-size:18px; font-weight:bold">
                       
                        Request for Fund Transfer
                           <br />
                           Agriculture Department, Govt. of Bihar</td>
                </tr>


            </table>
            <table class="table table-bordered" style="font-weight: bold; font-size: 18px;">
                <tr>
                    <td align="left">   FTO No: -	 
                        <asp:Label ID="lblFtoNo" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                    </td>
                    <td align="right"> Date: -<asp:Label ID="lblDate" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td align="left" colspan="2" class="auto-style1">   
                       
                           For the period from –&nbsp;&nbsp; 2022-23</td>
                </tr>

            </table>
 <table class="table table-bordered">
                
                <tr>
                    <td align="left" style="font-size:20px; font-family:Verdana; text-align: justify;" class="auto-style2">   
                       
                            Department of Agriculture, Government of Bihar, is hereby requested to release an amount of Rs.  
                            <asp:Label ID="lblRealesAmount" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
                            /-&nbsp;for crediting, the
benefits under&nbsp;Diesel Subsidy Kharif-2022-23 in the beneficiary's Aadhaar seeded account.
                        <br />
                        <br />
                            Total number of beneficiaries included in this request is (<asp:Label ID="lblTotalBen" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
                            )
                          <br />
                        <br />
                       <%-- In Word (<label id="lblmsg" runat="server"  />)
                        <br />
                        <br />--%>
                            Total amount due to the beneficiaries is Rs. 
                            <asp:Label ID="lblAmount" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
&nbsp;/-.&nbsp;&nbsp;<br />
                        <br />
                        <table width="100%">
                            <tr>
                                <td align="left">Amount In Word (<label id="lblmsg" runat="server" style="font-weight: bold; color: #FF0000"></label>)</td>
                            </tr>
                        </table> 
                          <br />
                        <br />
                            It is certified that the details of beneficiaries included in this request have been verified and found to be correct&nbsp; as per&nbsp; recommendation by the District Agriculture Officer.&nbsp;&nbsp;
                          <br />
                        <br />

                        The Amount will be deducted from Account No: <b>50100233408583</b> of HDFC BANK ,Raja Bazar Patna Branch.



                    </td>
                    
                </tr>

                 
            </table>
        </div>

   
        
     <table width="100%">
                    <tr>


                        <td align="left" style="font-size: 20px; font-family: Verdana;">

                            <%-- <table width="100%">
                                <tr>--%>
                            <%--<td align="right" >--%>

                            <br />
                            <br style="text-align: right" />

                            <strong>Md. Ismail&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <br />
                            </strong>Dy. Director (PP) HQ 
                                        <br />
                            surveillance and IPM
                            <br />
&nbsp;&nbsp;&nbsp;&nbsp;


                            Cum&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <br />
                            Nodal Officer DBT Cell 
                            <br />
                            Dept. of Agriculture, Bihar 
                         <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />





                            Sign & Stamp

                               

                        </td>

                    </tr>
                </table></div> </div>
</asp:Content>

