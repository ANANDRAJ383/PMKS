<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePublic.master" AutoEventWireup="true" CodeFile="AdminIncPage.aspx.cs" Inherits="AgricultureDept.AdminIncPage" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 34px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


     <div class="panel panel-success">
      <div class="panel-heading" style="font-weight:bold;font-size:14px;">Enter Passcode</div>
      <div class="panel-body" style="font-size:12px;">
          <center>
          <table class="table table-bordered">
              <tr>
                  <td>Passcode:</td>
                  <td>
                      <asp:TextBox runat="server" ID="txtPassode" TextMode="Password" class="form-control"></asp:TextBox>
                  </td>
                  <td>   <asp:Button ID="btnLogIn" runat="server" Text="Proceed"  Font-Bold="True"   class="btn btn-success" OnClick="btnLogIn_Click" /></td>
              </tr>

          </table>
              </center>
          </div> 
         </div> 


    <asp:Panel ID="pnl1" runat ="server" Visible="false" >
         <div class="panel panel-success">
      <div class="panel-heading" style="font-weight:bold;font-size:14px;">SQL QUERY WINDOW</div>
      <div class="panel-body" style="font-size:12px;">
    <table width ="100%">
        <tr>
            <td width="20%" valign="top">
                  <asp:Button ID="Button1" runat="server" Text="Get Table" OnClick="Button1_Click" />

    <asp:GridView ID="grd1" runat="server"></asp:GridView>
            </td>

             <td width="80%" valign="top">
                 <asp:TextBox TextMode="MultiLine" Width="400px" runat="server" ID="txt1" ></asp:TextBox>
                   <asp:Button ID="Button2" runat="server" Text="Get Data" OnClick="Button2_Click" />

    <asp:GridView ID="GridView1" runat="server" Width="700px"></asp:GridView>
             </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button4" runat="server" Text="Daily Transaction(Diesel)" OnClick="Button4_Click" />
                <asp:GridView ID="GridView2" runat="server"></asp:GridView>
            </td>
        </tr>
    </table>

    <asp:TextBox ID="txtenc" runat="server" Width="150px" ></asp:TextBox>
    &nbsp;<asp:Button ID="Button3" runat="server" Text="Encrypt" OnClick="Button3_Click" />&nbsp;
      <asp:Button ID="Button5" runat="server" Text="Decrypt" OnClick="Button5_Click" />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Upload Photo" />
    <br />
    <br />
    <br />
    <br />
    <br />
          </div> </div> 
          <div class="panel panel-success">
      <div class="panel-heading" style="font-weight:bold;font-size:14px;">PM KISAN(PFMS REJECTED) </div>
      <div class="panel-body" style="font-size:12px;">
         <center>
    <table>
        <tr>
            <td>
                  <asp:Button ID="Button14" runat="server" class="btn btn-success"   Text="Generate XML File(PFMS REJECTED) " OnClick="Button14_Click" />
            </td>
        </tr>
        </table> </div> </div>

           <div class="panel panel-success">
      <div class="panel-heading" style="font-weight:bold;font-size:14px;">PM KISAN </div>
      <div class="panel-body" style="font-size:12px;">
         <center>
    <table>

        <tr>
            <td align="center" colspan="4">
                
                 <asp:Label  ID="Label4" runat="server" class="label label-danger" Font-Bold="True" Font-Size="13px"></asp:Label>
                 <br />
                 <br />
            </td>
           
               
        </tr>

        <tr>
            <td align="center">
                <asp:Label ID="lblNoofaPPLY" runat="server" class="label label-danger" Font-Bold="True" Font-Size="13px" Text="1st. Step"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label1" runat="server" class="label label-danger" Font-Bold="True" Font-Size="13px" Text="2nd. Step"></asp:Label>
            </td>
            <td align="center">
                <asp:Label ID="Label2" runat="server" class="label label-danger" Font-Bold="True" Font-Size="13px" Text="3rd. Step"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" class="label label-danger" Font-Bold="True" Font-Size="13px" Text="4th. Step"></asp:Label>
            </td>
        </tr>

        <tr>
            <td align="center">&nbsp;</td>
            <td align="center">&nbsp;</td>
            <td align="center">&nbsp;</td>
        </tr>

        <tr>
            <td >
                <asp:Button ID="btn1" runat="server" class="btn btn-success" OnClick="btn1_Click" Text="Export Data From PMKISAN" />
            </td>
            <td>&nbsp;
                <asp:Button ID="btnXML" runat="server" class="btn btn-success" OnClick="btnXML_Click" Text="Generate XML File" />
                &nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="farmer.xml" Visible="false">Download XML File</asp:LinkButton>
            </td>
            <td>
                  <asp:Button ID="Button9" runat="server" class="btn btn-success" OnClick="Button9_Click" Text="Update Status" Visible="false" />

            </td>
            <td>
                <asp:Button ID="Button8" runat="server" class="btn btn-success" OnClick="Button8_Click" Text="UPDATE PMKISAN" />
            </td>
        </tr>

        <tr>
            <td> <asp:Button ID="Button10" runat="server" class="btn btn-success" OnClick="Button10_Click" Text="REJECTED FARMER BY PFMS" /></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td colspan="4" align="center" class="auto-style1" >  <br /> <asp:Label  ID="Label3" runat="server" class="label label-danger" Font-Bold="True" Font-Size="13px" Text ="Please follow all steps carefully...."></asp:Label></td>
        </tr>

    </table>
             </center>
          </div> </div> 
    <asp:Label ID="lblResult" runat="server" ForeColor="Red" Font-Bold="true" ></asp:Label>
 
         <div class="panel panel-success">
      <div class="panel-heading" style="font-weight:bold;font-size:14px;">send sms</div>
      <div class="panel-body" style="font-size:12px;">
          <center>
          <table class="table table-bordered">
              <tr>
                 
                 <%-- <td>
                      <asp:TextBox runat="server" ID="TextBox1" TextMode="Password" class="form-control"></asp:TextBox>
                  </td>--%>
                  <td>   
                      <asp:Button ID="btn" runat="server"  class="btn btn-success" Text="Test SMS" OnClick="btn_Click"  />

                      <asp:Button ID="btnSendMail" runat="server"  class="btn btn-success" Text="Test Mail" OnClick="btnSendMail_Click"   />
                      <asp:Button ID="Button7" runat="server" Text="SEND SMS"  Font-Bold="True"   class="btn btn-success" OnClick="Button7_Click"> </asp:Button> 

                      <br />
                      <asp:DropDownList ID="ddlS" runat="server" >
                          <asp:ListItem Text="Land Error" Value="1"></asp:ListItem>
                          <asp:ListItem Text="Rejected" Value="3"></asp:ListItem>
                      </asp:DropDownList>
                    <asp:Button ID="Button11" runat="server" Text="RECONSIDER ID DROUGHT"  Font-Bold="True"   class="btn btn-success" OnClick="Button11_Click" > </asp:Button></td>

                  <td>
                       <asp:Button ID="Button12" runat="server" Text="RETURNFileDrought"  Font-Bold="True"   class="btn btn-success" OnClick="Button12_Click"  > </asp:Button>
                       <br />
                       <br />
                       <asp:Button ID="Button13" runat="server" class="btn btn-success" Font-Bold="True" OnClick="Button13_Click" Text="RETURNFileDieselKharif" />
                       <br />
                       <asp:Button ID="Button15" runat="server" OnClick="Button15_Click" Text="Button" />
                  </td>

                  
              </tr>

          </table>
              </center>
          </div> 
         </div> 

        <div class="panel panel-success">
      <div class="panel-heading" style="font-weight:bold;font-size:14px;">INPUT SUBSIDY(2019-20) REPORT(S)</div>
      <div class="panel-body" style="font-size:12px;">
      <table class="table table-bordered">
          <tr>
              <td>Choose Criteria:</td>
              <td>
                  <asp:DropDownList ID="DropDownList1" runat="server" Width="180px" class="btn btn-default dropdown-toggle">
                      <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                      <asp:ListItem Text="District" Value="1"></asp:ListItem>
                      <asp:ListItem Text="Block" Value="2"></asp:ListItem>
                      <asp:ListItem Text="Panchayat" Value="3"></asp:ListItem>
                  </asp:DropDownList></td>
              <td>Choose Scheme Type: </td>
              <td>
                  <asp:DropDownList ID="DropDownList2" runat="server" Width="180px" class="btn btn-default dropdown-toggle">
                      <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                      <asp:ListItem Text="Flood" Value="1"></asp:ListItem>
                      <asp:ListItem Text="Drought" Value="2"></asp:ListItem>
                      <asp:ListItem Text="Silt" Value="3"></asp:ListItem>
                  </asp:DropDownList></td>
          </tr>
          <tr>
              <td colspan="4" align="center">
                  <asp:Button ID="Button16" runat="server" Text="Show" Font-Bold="True" Font-Names="Verdana"  class="btn btn-success" OnClick="Button16_Click"/>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:GridView ID="GridView3" runat="server"></asp:GridView>
              </td>
          </tr>
      </table>
      </div>
    

 <div class="panel panel-success">
      <div class="panel-heading" style="font-weight:bold;font-size:14px;">REPORT(S) Section</div>
      <div class="panel-body" style="font-size:12px;">
   
           <table class="table table-bordered">
          <tr>
              <td>Scheme Name</td>
              <td>
                  <asp:DropDownList ID="ddlschemetype" runat="server" Width="280px" class="btn btn-default dropdown-toggle" >
                      <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                      <asp:ListItem Text="Input Subsidy Kharif(2020-21_17 Districts)" Value="1"></asp:ListItem>
                      <asp:ListItem Text="Input Subsidy Kharif(2020-21_05 Districts)" Value="2"></asp:ListItem>
                      <asp:ListItem Text="Input Subsidy Kharif(2020-21_04 Districts)" Value="3"></asp:ListItem>
                      <asp:ListItem Text="PMKISAN" Value="4"></asp:ListItem>
                      <asp:ListItem Text="JJH" Value="5"></asp:ListItem>
                      <asp:ListItem Text="PMKISAN Reconsider" Value="6"></asp:ListItem>
                  </asp:DropDownList></td>
              <td>Choose Level
                  <asp:DropDownList ID="ddllevel" runat="server" Width="180px" class="btn btn-default dropdown-toggle">
                      <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                      <asp:ListItem Text="District" Value="1"></asp:ListItem>
                      <asp:ListItem Text="Block" Value="2"></asp:ListItem>
                      <asp:ListItem Text="Panchayat" Value="3"></asp:ListItem>
                  </asp:DropDownList></td>
          </tr>
          <tr>
              <td colspan="4" >
                  <center>
                  <asp:Button ID="btnreport" runat="server" Text="Show" Font-Bold="True" Font-Names="Verdana"  class="btn btn-success" OnClick="btnreport_Click" />
                  </center>
              </td>
          </tr>
      </table>
          <table>
               <tr>
              <td>
                  <asp:GridView ID="GridView4" runat="server"></asp:GridView>
              </td>
          </tr>
          </table>
         </asp:Panel>

</asp:Content>
