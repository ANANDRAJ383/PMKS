<%@ Page Title="" Language="C#" MasterPageFile="MasterPagePublic.master" AutoEventWireup="true" CodeFile="CheckApplicationStatusPM.aspx.cs" Inherits="CheckApplicationStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
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
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Application Status </div><br />
    <table class="table-bordered  table table-striped ">

        <tr>
            

                   <td>Enter Registeration Id </td>

                <td>
                    <asp:TextBox ID="txtRegId" runat="server" MaxLength="13" class="form-control" placeholder="Enter Registeration Id"></asp:TextBox>

                </td>

                <td >&nbsp;&nbsp;
                    <asp:Button ID="btnGet" runat="server" Text="Search" class="btn btn-success" OnClick="btnGet_Click" />
                </td>
        </tr>
    </table>
     <div >


         <br />
    
   
                                

        <asp:GridView ID="gvdata" runat="server" EmptyDataText="No record found" 
                AllowPaging="false" PageSize="10" CssClass="table table-bordered  table-striped" AutoGenerateColumns="false" 
             Font-Size="16px" >
            <Columns>
             
                 <asp:TemplateField HeaderText="SN">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1+"." %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Application Type" >
           
            <ItemTemplate>
                <asp:Label ID="lblatype" runat="server" Text='<%# Bind("atype") %>' Font-Bold="True" Font-Size="11" ForeColor="red"></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
                <asp:TemplateField HeaderText="Applicant Name" >
           
            <ItemTemplate>
                <asp:Label ID="lblMsg" runat="server" Text='<%# Bind("ApplicantName") %>' Font-Bold="True" Font-Size="11" ForeColor="red"></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>

                <asp:TemplateField HeaderText="PMKS Registration No">

                    <ItemTemplate>
                        <asp:Label ID="lblPMKS_Reg_No" runat="server" Text='<%# Bind("PMKS_Reg_No") %>' Font-Bold="True" Font-Size="11" ForeColor="red"></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

<asp:TemplateField HeaderText="Mutation Date" >
           
            <ItemTemplate>
                <asp:Label ID="lblMsg" runat="server" Text='<%# Bind("LandMutationDate") %>' Font-Bold="True" Font-Size="11" ForeColor="red"></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
 <asp:TemplateField HeaderText="Status" >
           
            <ItemTemplate>
                <asp:Label ID="lblMsg" runat="server" Text='<%# Bind("C_Status") %>' Font-Bold="True" Font-Size="11" ForeColor="red"></asp:Label>
            </ItemTemplate>
            
        </asp:TemplateField>
            </Columns>
            <RowStyle />
        </asp:GridView>
        </div>
    <div>
        <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">खेती करने योग्य भूमि का विवरण</div>
        <asp:GridView ID="grdLand" runat="server"  AutoGenerateColumns="false" CssClass="table table-bordered  table-striped" >
              <Columns>
                  <asp:TemplateField HeaderText="Sl. No." ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Font-Names="Comic Sans MS" Font-Size="12px" ForeColor="Green" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
                                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                                </asp:TemplateField>
                  <asp:BoundField HeaderText="जिला का नाम" DataField="DistName" HeaderStyle-Font-Size="12px"/>
                   <asp:BoundField HeaderText="राजस्व अंचल" DataField="BlockName" HeaderStyle-Font-Size="12px" />
                  
                   <asp:BoundField HeaderText="खाता नंबर" DataField="Khatano" HeaderStyle-Font-Size="12px" />
                  <asp:BoundField HeaderText="खेसरा नंबर" DataField="keshrano" HeaderStyle-Font-Size="12px"/>
                   <asp:BoundField HeaderText="थाना नंबर" DataField="thanano" HeaderStyle-Font-Size="12px" Visible="false"/>
                   <asp:BoundField HeaderText="रकवा" DataField="rakwa" HeaderStyle-Font-Size="12px" />
                   <asp:BoundField HeaderText="फार्मिंग रकवा" DataField="FarmingRakwa" HeaderStyle-Font-Size="12px" />
              </Columns>
          </asp:GridView>
    </div>
   
</asp:Content>

