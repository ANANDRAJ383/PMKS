<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="ApproveDieselApplication.aspx.cs" Inherits="ApproveDieselApplication" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script language="JavaScript" type="text/javascript">
       function reSum() {
        var num1 = parseInt(document.getElementById("ContentPlaceHolder1_lblApprovedSubsidyAmount").value);
        var num2 = parseInt(document.getElementById("ContentPlaceHolder1_txtDAOApprovedAmount").value);
                        if (isNaN(num1)) { num1 = 0; }
           if (isNaN(num2)) { num2 = 0; } 

           alert('Enter Less Value !');
           if (num2 <= num1)
               {
               }
               else
           {
               alert('Enter Less Value !');
                  return false;
           }
                //document.getElementById("ContentPlaceHolder1_txtTotal").value = num1 + num2 ;
    }
    </script>


    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #1C6794; padding: 5px; margin-top: 5px; width: 100%;" align="center">Verify Diesel Subsidy Data 2022-23 of District :- <asp:Label ID="lblDistrict" runat="server"></asp:Label></div><br />
    

    <div class="row">
        <div class="input-group mb-3 col-lg-4">
            <label>Block : &nbsp;</label>
            <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"
                AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

        <div class="input-group mb-3 col-lg-4">
            <label>Panchayat : &nbsp;</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlPanchayat" runat="server" Width="150px" CssClass="form-select" ValidationGroup="s">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

         <div class="input-group mb-3 col-lg-4">
            
  <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click"  /> 
</div>
     <div class="input-group mb-3 col-lg-12" align="center">
       <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>     

</div>   
       
    </div>

      <div align="center">
            <asp:Button ID="btnApproved" runat="server" Text="Approve" CssClass="btn btn-success" Visible="false" OnClick="btnApproved_Click"  /> 
          <asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label> 
        <asp:LinkButton ID="lnbDownloadExcel" runat="server" Text="Download Excel"  Font-Bold="true" onclick="lnbDownloadExcel_Click" Visible="false"></asp:LinkButton></div>
        <div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" AllowPaging="true" PageSize="50"
            DataKeyNames="Registration_ID,Application_ID" AutoGenerateColumns="false" Width="100%"  AlternatingRowStyle-CssClass="alt" 
                onpageindexchanging="gvdata_PageIndexChanging" Font-Size="10px" CssClass="Grid"  >
                <AlternatingRowStyle CssClass="alt" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" Text="Select all" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkDetails" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Farmer Detail"  >
                    <ItemTemplate>
                        <strong>Registration Id :- </strong>
                        <asp:Label ID="lnkregid" runat="server" Text='<%#Bind("Registration_ID") %>'></asp:Label><br />
                        <strong>Application ID : </strong> <asp:LinkButton ID="lnkAppId" runat="server" Text='<%#Bind("Application_ID") %>' CommandArgument='<%#Bind("Application_ID") %>' CommandName="view" OnClick="lnkregid_Click2"></asp:LinkButton><br />
                        <strong>Name : </strong><%#Eval("ApplicantName")%><br />
                        <strong>Father/Husband Name : </strong><%#Eval("Father_Husband_Name")%><br />
                        <strong>Mobile No: </strong><%#Eval("MOBILENO")%><br />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address Detail" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <strong>Block : </strong><%#Eval("blockname")%><br />
                        <strong>Panchayat : </strong><%#Eval("PanchayatName")%><br />
                        <strong>Village : </strong><%#Eval("VillName")%><br />
                    </ItemTemplate>
                    <HeaderStyle Width="10%" />
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
                

                <asp:TemplateField HeaderText="Farmer Land Detail" HeaderStyle-Width="15%" ItemStyle-Width="15%">
                    <ItemTemplate>
                        <strong>Total Affected Rakwa :- </strong><%#Eval("Totallandcultivation")%><br />
                        <strong>Amount: </strong><%#Eval("Totalamount")%><br />
                        <strong>Petrol Pump Name: </strong><%#Eval("PetrolPumpName")%><br />  
                        <strong>No of Irrigation: </strong><%#Eval("NoofApply")%><br />
                        <strong>Farmer Type: </strong><%#Eval("LandType")%><br />
                    </ItemTemplate>
                    <HeaderStyle Width="15%" />
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AC Approved Status">
                    <ItemTemplate>
                        <strong>Rakwa :- </strong><asp:Label ID="lblApprovedRakwa" runat="server" Text='<%#Bind("ACSubsidyLandArea") %>'></asp:Label><br />
                        <strong>Amount :- </strong><asp:Label ID="lblApprovedSubsidyAmount" runat="server" Text='<%#Bind("Amount") %>'></asp:Label><br />
                        <strong>Irrigation :- </strong><asp:Label ID="lblApprovedIrrigation" runat="server" Text='<%#Bind("ACIrrCont") %>'></asp:Label><br />
			<strong>Remarks:- </strong><asp:Label ID="lblACRemarks" runat="server" Text='<%#Bind("AC_remarks") %>'></asp:Label><br />
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="View Document">
                    <ItemTemplate>

                      <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("Imagepath")%>' Target="_blank" Font-Size="Medium">Diesel Receipt</asp:HyperLink><br />
                       <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("LandCertificate")%>' Target="_blank" Font-Size="Medium">Irrigation Receipt</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="DAO Remarks">
                    <ItemTemplate>
                        <strong>Status :- </strong><asp:DropDownList ID="ddlApproved" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlApproved_SelectedIndexChanged" >
                                     <asp:ListItem Text="स्वीकृत" Value="1"></asp:ListItem> 
                                      <asp:ListItem Text="अस्वीकृत" Value="2"></asp:ListItem> 

                                 </asp:DropDownList>    
                                 <br />
                        <strong>Approved Amount :- </strong><asp:TextBox  ID="txtDAOApprovedAmount"  runat="server"   OnTextChanged="QtyChanged" AutoPostBack="true"
                             onchange="reSum()" onkeyup="reSum()" Text='<%#Bind("Amount")%>'></asp:TextBox><br />
                        <strong>Comment :- </strong><asp:TextBox  ID="txtCommentDAO"  runat="server" ></asp:TextBox><br />
                    </ItemTemplate>
                </asp:TemplateField>
           
                 </Columns>
            <HeaderStyle BackColor="#014275" ForeColor="White" Font-Size="10pt" />
            <RowStyle Font-Size="10pt" />
        </asp:GridView>


                               </ContentTemplate>
                        </asp:UpdatePanel>
                               
                               </div>

    
</asp:Content>

