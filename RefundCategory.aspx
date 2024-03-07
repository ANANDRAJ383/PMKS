<%@ Page Title="" Language="C#" MasterPageFile="~/Reconcile/MainSite.master" AutoEventWireup="true" CodeFile="RefundCategory.aspx.cs" Inherits="RefundCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
	<div class="commonboxwithshadow cscbox w-50">
		<h1 class="headingtext"><span id="ContentPlaceHolder1_Label2" class="fontbigsize">ऑनलाइन रिफंड</span></h1>
		<div class="buttonarea">
			<a href="RefundCategory.aspx" class="custombtn">Back</a>
		</div>
        <div id="ContentPlaceHolder1_UpdatePanel1">
	
				<div class="row m-0">
					<div class="col-lg-12  globalradio">
						<div class="form-group">
							<table id="ContentPlaceHolder1_rdbAction">
		<tr>
			<td>
                <asp:RadioButtonList ID="rbtnRefundCat" runat="server" RepeatDirection="Vertical" Enabled="false">
                        <asp:ListItem Selected="True" >यदि विभाग/राज्य/जिला/ब्लॉक या किसी अन्य माध्यम से देय रिफंड का भुगतान पहले ही कर दिया गया है</asp:ListItem>
                        <asp:ListItem >यदि पहले भुगतान नहीं किया है तो अब ऑनलाइन राशि वापस करने के लिए इस विकल्प का चयन करें</asp:ListItem>
                    </asp:RadioButtonList>
               
                </td>
		</tr>
	</table>
						</div>
					</div>
					<div class="col-12 col-sm-2 col-md-2 p-0">
						<div class="form-group">							
                            <asp:Button ID="btnSbmt" runat="server" Text="Submit"  CssClass="custombtn"  Font-Bold="True" OnClick="btnSbmt_Click" />
						</div>
					</div>
				</div>
			
</div>
	</div>
</asp:Content>

