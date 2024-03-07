<%@ Page Title="" Language="C#" MasterPageFile="COMasterPage.master" AutoEventWireup="true" CodeFile="MutationDateVerification.aspx.cs" Inherits="CO_MutationDateVerification" EnableEventValidation="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
   
<div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center"> Land Seeding "No"- Entry for Mutation Date & Verify Application (योजना की मार्गदर्शिका के अनुसार)<br /></div><br /
    
            <div>
                <table class="table-bordered  table table-striped ">
                <tr>
                   
                    <td>Panchayat :</td>
                    <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
            <asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select">
            </asp:DropDownList>
                               </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>Type of Data</td>
                    <td> <asp:DropDownList ID="ddlType" runat="server" CssClass="form-select">
                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                 <asp:ListItem Value="1" >New</asp:ListItem>             
                <asp:ListItem Value="2" >Old</asp:ListItem>
            </asp:DropDownList></td>
                    <td><asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click"  /> </td>
                </tr>
            </table>
            </div>
    
   
        
        <div class="input-group mb-3 col-lg-4">
             &nbsp;
  <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
   
       
            <table class="table-bordered  table table-striped " style="width: 40%; margin-left:10px;">
         <tr>
             <td>Search By Registration Id</td>             
             <td><asp:TextBox ID="txtRegId" runat="server" class="form-control" placeholder="Registration Id" ></asp:TextBox></td>
             <td><asp:Button ID="btnView" class="btn btn-primary b-btn" runat="server" Text="View" OnClick="btnView_Click" ></asp:Button></td>
         </tr>
     </table>   
       
        <div >
             &nbsp;
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    

<div >
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                AllowPaging="true" PageSize="50" CssClass="table table-bordered table-striped"
            DataKeyNames="Registration_ID,ApplicationType" AutoGenerateColumns="false"   onpageindexchanging="gvdata_PageIndexChanging" Font-Size="10px" >
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" Visible="false">
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" Text="Select all" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" Visible="false"/>
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
                <asp:BoundField DataField="blockname" HeaderText="Block Name" />
                <asp:BoundField DataField="panchayatname" HeaderText="Panchayat Name" />
                <asp:BoundField DataField="VillageName" HeaderText="Village Name" />
                <asp:TemplateField HeaderText="Registration Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("Registration_ID") %>'></asp:Label>
                        <br />Application Type:-<asp:Label ID="lblApplicationType" runat="server" Text='<%#Eval("ApplicationType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                <asp:BoundField DataField="Father_Husband_Name" HeaderText="Father/Husband Name" />
                <asp:TemplateField HeaderText="Bank Detail" Visible="false">
                    <ItemTemplate>
                        <strong>Account Number: </strong>
                        <%#Eval("AccountNumber")%><br />
                        <strong>IFSC Code: </strong>
                        <%#Eval("IFSC_Code")%><br />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="khata_no" HeaderText="khata no" />  
                <asp:BoundField DataField="KhesraNo" HeaderText="KhesraNo" />
                <asp:BoundField DataField="LandDismil" HeaderText="Rakwa" />
                <asp:TemplateField HeaderText="Mutation Date of Land (दाखिल - खारिज की तिथि 01/02/2019 से पहले (योजना की मार्गदर्शिका के अनुसार)) " HeaderStyle-ForeColor="#FF3300" Visible="false">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMutationDate" runat="server" Text='<%#Eval("MutationDate") %>'></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar1" runat="server" AutoPostBack="True" 
                    Control="txtMutationDate" Format="dd mmm yyyy" To-Date="02-01-2019"  />
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:BoundField  DataField="EntryDate" HeaderText="Entry Date" Visible="false"/>
                <asp:TemplateField HeaderText="Document">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("LandPath")%>'
                            Target="_blank">View</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Mutation Date of Land(दाखिल-खारिज की तिथि 01/02/2019 से पहले )" HeaderStyle-ForeColor="#FF3300">
                <ItemTemplate>
                    <asp:Button ID="btnViewDetail1" Text="Click Here for Before 2019" runat="server" OnClick="btnViewDetailBefore_Click" class="btn btn-success"  />
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField visible="false" HeaderText="Mutation Date of Land(दाखिल-खारिज की तिथि 01/02/2019 के बाद )"  HeaderStyle-ForeColor="#FF3300">
                <ItemTemplate>
                    <asp:Button ID="btnViewDetail" Text="Click Here for After 2019" runat="server" OnClick="btnViewDetail_Click"  class="btn btn-success" />
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
            <RowStyle />
        </asp:GridView>
                               </ContentTemplate>
                        </asp:UpdatePanel> 
        </div>

</asp:Content>

