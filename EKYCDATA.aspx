<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EKYCDATA.aspx.cs" Inherits="EKYCDATA" EnableEventValidation = "false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="vendor/bootstrap/css/bootstrap.min.css" />
    <!-- Custom styles for this template -->
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/base-responsive.css" />
    <link rel="stylesheet" href="css/animate.min.css" />
    <link rel="stylesheet" href="css/slicknav.min.css" />
    <link rel="stylesheet" href="css/font-awesome.min.css" />
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="css/entryform.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">EKYC Not done data List </div><br />
   <div class="row">
       <div class="col-lg-6">
           <div class="col-lg-9">
               <asp:TextBox ID="txtName" CssClass="input-group" runat="server" placeholder="Enter Name"></asp:TextBox>
           </div>
           <div class="col-lg-3">
               <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-success" OnClick="btnSearch_Click"  /> 
           </div>                            
        </div>
   </div>
            <div class="row">
        <div class=" col-lg-4">
            &nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Update Record" class="btn btn-success" OnClick="bnSave_Click" Visible="false" /> 
             <asp:Button ID="btnExport" runat="server" Text="Export To Excel" CssClass="btn btn-success" Visible="false" OnClick="btnExport_Click" />
        </div>

        
    </div>
    

<div class="form-row">
    </div>

        <div style="margin: 10px;">
            <div class="input-group mb-3 col-lg-9">
            &nbsp;
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF"></asp:Label>
               
        </div>
             <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                AllowPaging="false"  CssClass="table table-bordered table-striped"
            DataKeyNames="BiharRegNo" AutoGenerateColumns="false" Font-Size="12px">
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center"  >
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" Text="Select all" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" Enabled="false"/>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkDetails" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Font-Bold="true" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SN" Visible="false">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Registration Id">
                    <ItemTemplate>
                        <asp:Label ID="lblRegistrationID" runat="server" Text='<%#Eval("BiharRegNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Farmer_Registration_No" HeaderText="PM Kisan Reg No" />
                <asp:BoundField DataField="Farmer_Name" HeaderText="Applicant Name" />
                <asp:BoundField DataField="Father_Name" HeaderText="Father/Husband Name" />
                <asp:BoundField DataField="PanchayatName" HeaderText="Panchayat Name" Visible="false"/>
                <asp:BoundField DataField="LandVillageName" HeaderText="Village Name" />
               <asp:BoundField  DataField="MobileNumber" HeaderText="Mobile Number" />
             
            </Columns>
            <RowStyle />
        </asp:GridView>
                                </ContentTemplate>
                        </asp:UpdatePanel>
        </div>
        </div>
         <div class="row">
        <div class=" col-lg-6">
            लाभार्थी की मृत्यु:
           
        </div>
             <div class=" col-lg-6">
                  <asp:RadioButtonList ID="rbtDeathStatus" runat="server" 
                        RepeatDirection="Horizontal" TabIndex="23">
                                              <asp:ListItem Selected="True" Value="N">No / नहीं</asp:ListItem>
                                              <asp:ListItem Value="Y">Yes / हाँ</asp:ListItem>
                                              <asp:ListItem Value="T">Not Traceable / लाभार्थी नहीं मिल रहा है </asp:ListItem>
                                              <asp:ListItem Value="H">Head of familey already receive benefits</asp:ListItem>
                                              <asp:ListItem Value="P">Employee of State/central/psu/pensions /professional /constitutional post holder</asp:ListItem>
                                          </asp:RadioButtonList>
             </div>
             </div>
    </form>
</body>
</html>
