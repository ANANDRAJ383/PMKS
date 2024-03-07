<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="DAOInputRecon2223.aspx.cs" Inherits="DAO_DAOInputRecon2223" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script language="JavaScript" type="text/javascript">
        function reSum() {
            var num1 = parseInt(document.getElementById("ContentPlaceHolder1_lblApprovedSubsidyAmount").value);
            var num2 = parseInt(document.getElementById("ContentPlaceHolder1_txtDAOApprovedAmount").value);
            if (isNaN(num1)) { num1 = 0; }
            if (isNaN(num2)) { num2 = 0; }

            alert('Enter Less Value !');
            if (num2 <= num1) {
            }
            else {
                alert('Enter Less Value !');
                return false;
            }
            //document.getElementById("ContentPlaceHolder1_txtTotal").value = num1 + num2 ;
        }
    </script>

    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        .modal {
            display: none;
            position: absolute;
            top: 0px;
            left: 0px;
            background-color: black;
            z-index: 100;
            opacity: 0.8;
            filter: alpha(opacity=60);
            -moz-opacity: 0.8;
            min-height: 100%;
        }

        #divImage {
            display: none;
            z-index: 1000;
            position: fixed;
            top: 0;
            left: 0;
            background-color: White;
            height: 550px;
            width: 600px;
            padding: 3px;
            border: solid 1px black;
        }
    </style>
    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold; background-color: #1C6794; padding: 5px; margin-top: 5px; width: 100%;"
        align="center">
        Verify Input Subsidy Data 2022-23 of District :-
        <asp:Label ID="lblDistrict" runat="server"></asp:Label>
    </div>
    <br />


    <div class="row">
        <div class="input-group mb-3 col-lg-4">
            <label>Block : &nbsp;</label>
            <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"
                        AutoPostBack="True" ValidationGroup="s" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="input-group mb-3 col-lg-4">
            <label>Panchayat : &nbsp;</label>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlPanchayat" runat="server" Width="150px" CssClass="form-select" ValidationGroup="s">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="input-group mb-3 col-lg-4">

            <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click" />
 <asp:Button ID="btnShow0" runat="server" Text="Refresh" CssClass="btn btn-danger" OnClick="btnShow0_Click" />
           
            <br />
            <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="" Visible="true"></asp:Label>

        </div>
        <div class="input-group mb-1 col-lg-12" align="center">
            <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF"></asp:Label>

        </div>

    </div>
**भूमि दस्तावेज देखने के लिये कृपया चेकबॉक्स को चेक करें
            <br />
**** कृपया आवेदन स्वीकृत एवं अस्वीकृत करने के उपरांत Refresh बटन का इतेमाल करें |
    <div align="center">
        <asp:Button ID="btnApproved" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="btnApproved_Click" Visible="False" />
        <asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label>
        <asp:LinkButton ID="lnbDownloadExcel" runat="server" Text="Download Excel" Font-Bold="true"></asp:LinkButton>
 
    </div>
    <div>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found"  
                    DataKeyNames="Registration_ID,Application_ID" AutoGenerateColumns="false" Width="100%" AlternatingRowStyle-CssClass="alt"
                    Font-Size="10px" CssClass="Grid">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
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
                        <asp:TemplateField HeaderText="Farmer Detail">
                            <ItemTemplate>
                                <strong>Registration Id :- </strong>
                                <asp:Label ID="lnkregid" runat="server" Text='<%#Bind("Registration_ID") %>'></asp:Label><br />
                                <strong>Application ID : </strong>
                                <asp:LinkButton ID="lnkAppId" runat="server" Text='<%#Bind("Application_ID") %>' CommandArgument='<%#Bind("Application_ID") %>' CommandName="view" OnClick="lnkAppId_Click"></asp:LinkButton><br />
                                <strong>Name : </strong><%#Eval("ApplicantName")%><br />
                                <strong>Father/Husband Name : </strong><%#Eval("Father_Husband_Name")%><br />
                                <strong>Mobile No: </strong><%#Eval("MOBILENO")%><br />

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address Detail" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <strong>Block : </strong><%#Eval("blockname")%><br />
                                <strong>Panchayat : </strong><%#Eval("PanchayatName")%><br />
                                <strong>Village : </strong><%#Eval("VillageName")%><br />
                            </ItemTemplate>
                            <HeaderStyle Width="10%" />
                            <ItemStyle Width="10%" />
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Farmer Land Detail" HeaderStyle-Width="15%" ItemStyle-Width="15%">
                            <ItemTemplate>
                                <strong>Total Rakwa :- </strong><%#Eval("TotalLand")%><br />
                                <strong>Total Affected Rakwa :- </strong><%#Eval("TotalAffectedRakwa")%><br />
                                <strong>Amount: </strong><%#Eval("TotalSubsidy")%><br />
                                <strong>Farmer Type: </strong><%#Eval("FARMERTYPE")%><br />
                            </ItemTemplate>
                            <HeaderStyle Width="15%" />
                            <ItemStyle Width="15%" />
                        </asp:TemplateField>
                      <%--  <asp:TemplateField HeaderText="AC Approved Status">
                            <ItemTemplate>
                                <strong>Change Rakwa :- </strong>
                                <asp:Label ID="lblApprovedRakwa" runat="server" Text='<%#Bind("ac_changerakwa") %>'></asp:Label><br />
                                <strong>Change Amount :- </strong>
                                <asp:Label ID="lblApprovedSubsidyAmount" runat="server" Text='<%#Bind("ac_changeamount") %>'></asp:Label><br />
                                <strong>Remarks:- </strong>
                                <asp:Label ID="lblACRemarks" runat="server" Text='<%#Bind("AC_remarks") %>'></asp:Label><br />
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="View Document">
                            <ItemTemplate>
                                <%--<asp:LinkButton ID="lnkRead" runat="server" Text="✉ View" CommandName="Read" ForeColor="Green" OnClientClick="window.open('newPage.aspx?fileName=<%#Eval('LandPath')%>','_newtab');"></asp:LinkButton>--%>
                                <asp:LinkButton ID="lnkRead" runat="server" Text="✉ View" CommandArgument='<%# Eval("LandPath") %>' Font-Size="18px" OnClick="lnkRead_Click1"></asp:LinkButton>
                                <br />


                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="DAO Remarks" Visible="false">
                            <ItemTemplate>
                                <strong>Status :- </strong>
                                <asp:DropDownList ID="ddlApproved" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlApproved_SelectedIndexChanged" >
                                    <asp:ListItem Text="स्वीकृत" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="अस्वीकृत" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <strong>Reject Cause :- </strong>
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="100px" AutoPostBack="True" Enabled="false">
                                    <asp:ListItem Text="आवेदन विवरण में त्रुटि|" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="जमीन विवरण में त्रुटि|" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="आवेदक के अलावा अन्य परिवार के सदस्य लाभ नहीं ले रहे है||" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="जमीन दस्तावेज अद्यतन नहीं है |" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="आवेदक के नाम से जमीन दस्तावेज नहीं है |" Value="5"></asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <strong>Approved Amount :- </strong>
                                <asp:TextBox ID="txtDAOApprovedAmount" runat="server" AutoPostBack="true"
                                    onchange="reSum()" onkeyup="reSum()" Text='<%#Bind("ac_changeamount")%>'></asp:TextBox><br />
                                <strong>Comment :- </strong>
                                <asp:TextBox ID="txtCommentDAO" runat="server"></asp:TextBox><br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Take Action">
                            <ItemTemplate>
                                <asp:Button ID="btnLandDetail" Text="Approve Land Detail" runat="server" OnClick="btnLandDetail_Click" class="btn btn-success" /><br />
                                <asp:Button ID="btnfamilydetails" Text="View Family Detail" runat="server" class="btn btn-success" OnClick="btnfamilydetails_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle BackColor="#014275" ForeColor="White" Font-Size="10pt" />
                    <RowStyle Font-Size="10pt" />
                </asp:GridView>


            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

    <%--// POP UP DISPLY HERE.....--%>
</asp:Content>

