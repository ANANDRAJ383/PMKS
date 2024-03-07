<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="UpdateDOB.aspx.cs" Inherits="DAO_UpdateDOB" %>
<%@ Register assembly="RJS.Web.WebControl.PopCalendar" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">शत प्रतिशत भोतीक सत्यापन मे प्राप्त आधार अनुरूप जन्म तिथि सुधार करने हेतु विवरण </div><br />
    <table class="table-bordered  table table-striped " style="width: 100%;">
         <tr>
             <td>Enter Registration Id</td>             
             <td><asp:TextBox ID="txtRegId" runat="server" class="form-control" placeholder="Enter Registration Id" ></asp:TextBox></td>
             <td><asp:Button ID="btnView" class="btn btn-primary b-btn" runat="server" Text="View" OnClick="btnView_Click"  ></asp:Button></td>
         </tr>
     </table> 
    <div class="input-group mb-3 col-lg-4">
        &nbsp;
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
    <table class="table-bordered  table table-striped " style="width: 100%;" id="tblData" runat="server" visible="false"> 
        <tr>
            <td><span>नाम | Name :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>पिता/पति का नाम | Father/Husband Name :-</span></td>
            <td style="color: #FF0000; font-size: large"><asp:Label ID="lblFName" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
       <tr>
            <td><span>मोबाइल नंबर | Mobile Number :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblMobile" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>लिंग | Gender :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblGender" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td><span>जन्म की तारीख | Date of birth :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblDOB" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>किसान प्रकार | Farmer type :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblFarmerType" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td>सही जन्म तिथि | Correct Date of Birth :-</td>
            <td >
                 <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
               <rjs:PopCalendar ID="PopCalendar1" runat="server" AutoPostBack="True" 
                    Control="txtDOB" Format="dd mmm yyyy"  To-Date="02-01-2001"/> 
            </td>
            <td colspan="2">
            <asp:Button ID="btnSave" class="btn-danger" runat="server" Text="Update" OnClick="btnSave_Click"   ></asp:Button>
            </td>
        </tr>
        
    </table>
                                </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>

