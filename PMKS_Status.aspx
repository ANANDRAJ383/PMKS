<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PMKS_Status.aspx.cs" Inherits="PMKS_Status" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Bootstrap -->
    <link href="../cssPMKS/bootstrap.min.css" rel="stylesheet" />
    <!-- Datatables-->
    <link href="../cssPMKS/dataTables.bootstrap4.css" rel="stylesheet" />
    <title></title>
</head>
<body >
    <form id="form1" runat="server">
         <table class="table-bordered  table table-striped ">

        <tr >
           
            <td >
                  <center>
                      <asp:Image ID="imgbiharlogo" runat="server" ImageUrl="~/Images/biharlogo.png" />
                      <br /><br />
                <asp:Label ID="lbldisplay" runat="server" Text="कृषि विभाग, बिहार सरकार" Font-Size="XX-Large" Font-Bold="True" Font-Underline="False"></asp:Label>
                      <br />
                      <asp:Label ID="Label4" runat="server" Text="प्रधानमंत्री किसान सम्मान निधि योजना"  Font-Size="Large"   Font-Bold="True" Font-Underline="True" ></asp:Label>
                       </center>
            </td>
        </tr>
        </table>
     <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Application Status as on :- <asp:Label ID="lblDate" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></div><br />
        <table class="table-bordered  table table-striped ">

            <tr>
                <td> <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal"  CssClass="form-check-label">
            <asp:ListItem Selected="True" Value="M"> &nbsp;पंजीकृत मोबाइल नंबर &nbsp;</asp:ListItem>
            <asp:ListItem Value="R">&nbsp;पंजीकरण संख्या &nbsp;</asp:ListItem>
			<asp:ListItem Value="B">&nbsp;पीएम किसान पंजीकरण संख्या (उदाहरण- BR0000000)</asp:ListItem>
        </asp:RadioButtonList></td>
                <td>
                    <asp:TextBox ID="txtRegId" runat="server" MaxLength="13" class="form-control" placeholder="Enter Registeration Id"></asp:TextBox>
                </td>
                <td>&nbsp;&nbsp;
                    <asp:Button ID="btnGet" runat="server" Text="Search" class="btn btn-success" OnClick="btnGet_Click"  />
                </td>
            </tr>
        </table>
        <asp:Panel runat="server" ID="pnlData" Visible="false">
           <table class="table-bordered  table table-striped " style="width: 100%;"> 
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
            
            <td><span>जन्म की तारीख | Date of birth :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblDOB" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            
        </tr>
       
        <tr>
            <td><span>जिला | District :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblDist" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>प्रखंड |Block:-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblBlock" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
         <tr>
            <td><span>पंचायत |Panchayat :-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblPanchayat" runat="server" Font-Bold="True" Font-Italic="True"></asp:Label></td>
            <td><span>गाँव |Village:-</span></td>
            <td style="color: #FF0000; font-size: large">
                <asp:Label ID="lblVillage" Font-Italic="True" runat="server" Text="" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td>स्थिति | Status :-</td>
            <td colspan="3" style="color: #FF0000; font-size: large">
                <asp:Label ID="lblStatus" Font-Italic="True" runat="server" Font-Bold="True"></asp:Label><br />
                
            </td>
        </tr>
       
    </table>
        </asp:Panel>
       <div style="margin-left:10px">

           <ul class="list-group">
  <li class="list-group-item"><asp:Label ID="lblS1" Font-Italic="True" runat="server" Font-Bold="True" Text="A simple default list group item"></asp:Label> </li>

  <li class="list-group-item list-group-item-primary"><asp:Label ID="lblS2" Font-Italic="True" runat="server" Font-Bold="True" Text="A simple primary list group item"></asp:Label></li>
  <li class="list-group-item list-group-item-secondary">A simple secondary list group item</li>
  <li class="list-group-item list-group-item-success">A simple success list group item</li>
  <li class="list-group-item list-group-item-danger">A simple danger list group item</li>
  
</ul>
           
       </div>
    </form>
</body>
</html>
