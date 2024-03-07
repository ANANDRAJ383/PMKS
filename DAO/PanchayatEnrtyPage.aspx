<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="PanchayatEnrtyPage.aspx.cs" Inherits="DAO_PanchayatEnrtyPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <%--<style type="text/css">
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
    <style type="text/css">
        .modalBackground {
            background-color: Yellow;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }

        .modalPopup {
            background-color: #ffffdd;
            border-width: 3px;
            border-style: solid;
            border-color: Gray;
            padding: 5px;
            width: 350px;
            height: 300px;
        }

        .modalBackground1 {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
            /*background-color: Black;
        filter: alpha(opacity=60);
        opacity: 0.6;*/
        }

        .modalPopup1 {
            background-color: #FFFFFF;
            width: 100%;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }

            .modalPopup1 .header {
                background-color: #2FBDF1;
                height: 50px;
                color: White;
                line-height: 50px;
                text-align: center;
                font-weight: bold;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
            }

            .modalPopup1 .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup1 .footer {
                padding: 6px;
            }

            .modalPopup1 .yes, .modalPopup .no {
                height: 23px;
                color: White;
                line-height: 50px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
                border-radius: 4px;
            }

            .modalPopup1 .yes {
                background-color: #2FBDF1;
                border: 1px solid #0DA9D0;
            }

            .modalPopup1 .no {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

        </style>--%>

    <style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    .modalPopup
    {
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #1C6794; padding: 5px; margin-top: 5px; width: 100%;" align="center">Entry Form for ATM / BTM to generate User ID and Password</div><br />
    <table class="table-bordered  table table-striped " style="width: 100%;">
            <tr>
                <td>Block</td>
                <td>
                     <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Conditional"  >
                           <ContentTemplate>
                    <asp:DropDownList ID="ddlblock" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlblock_SelectedIndexChanged">
                    </asp:DropDownList>
                               </ContentTemplate>
                         </asp:UpdatePanel>
                </td>
                <td>Panchayat</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                    <asp:DropDownList ID="ddlpanchayat" runat="server" CssClass="form-select">                     
                    </asp:DropDownList>
                               </ContentTemplate>
                        </asp:UpdatePanel>
                </td>
                 <td>
                        <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn btn-success" OnClick="btnShow_Click"/>
                 </td>
                </tr>
        <tr>
            <td colspan="6">
                 &nbsp;</td>
        </tr>
        </table>
    <asp:Panel ID="pnldata" runat="server" Visible="false">
        <table class="table-bordered  table table-striped " style="width: 100%;">
            <tr>
                <td>User ID:</td> 
                <td><asp:Label ID="lblname" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>          
                <td>Panchayat Name:</td>
                <td><asp:Label ID="lblpanname" runat="server" Text=""></asp:Label></td>
                </tr>
         <tr>
             <td>Enter Name:</td>
             <td><asp:TextBox ID="TextBox1" runat="server" CssClass="form-control input-lg" ></asp:TextBox></td>
         </tr>
          <tr>
             <td>Mobile Number:</td>
             <td><asp:TextBox ID="TextBox2" runat="server" CssClass="form-control input-lg" MaxLength="10"></asp:TextBox></td>
         </tr>

         <tr>
             <td>  <asp:Button ID="Button2" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="Button2_Click"/></td>
         </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label></td>
            </tr>
    </table>
    </asp:Panel>
     
    <asp:Panel ID="pnlgdview" runat="server" Visible="false">
        <asp:UpdatePanel ID="up" runat="server" UpdateMode="Always">
            <ContentTemplate>
         <asp:GridView ID="gvView" runat="server" EmptyDataText="No record found" AllowPaging="false" 
                     AutoGenerateColumns="false" Width="100%" AlternatingRowStyle-CssClass="alt" CssClass="table table-bordered table-striped">
                    <AlternatingRowStyle CssClass="alt" />
                    <Columns>
                       
                        <asp:TemplateField HeaderText="SN">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1+"." %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Blockname" HeaderText="Block" />
                        <asp:BoundField DataField="Panchayatname" HeaderText="Panchayat Name" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Mobileno" HeaderText="Mobile Number" />
                        <asp:BoundField DataField="userid" HeaderText="User ID" />
                        <asp:BoundField DataField="password" HeaderText="Password" />
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                            <asp:LinkButton ID="lnkRead"  runat="server" Text="Update"   Font-Size="Small" OnClick="lnkRead_Click1"></asp:LinkButton>                     
                            </ItemTemplate>
                </asp:TemplateField>
                    </Columns>
                    
                </asp:GridView>
                 
            </ContentTemplate>
        </asp:UpdatePanel>

    </asp:Panel>


    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
            <ContentTemplate>
      <asp:Panel ID="pnlpopup" runat="server" BackColor="White"  Width="900px" Height="700px" ScrollBars="Auto" Visible="false" >
           
            <table   class="table table-bordered" > 
            <tr>
                <td style="font-size:15px;"> Block Name</td>
                <td>
                    <asp:DropDownList ID="ddlblockupdt" runat="server" AutoPostBack="True"  class="btn btn-default dropdown-toggle" OnSelectedIndexChanged="ddlblockupdt_SelectedIndexChanged" Enabled="false" >                         
                    </asp:DropDownList>
                </td>
            </tr>  
                <tr>
                <td style="font-size:15px;"> Panchayat Name</td>
                <td>
                    <asp:Label ID="lblpanchayatnaeuodate" runat="server" Font-Size="15px"></asp:Label>
                    
                </td>
            </tr>  
         
            <tr>
                <td style="font-size:15px;" >UserID :                </td>
                 <td>    <asp:Label ID="lblID" runat="server" Font-Size="15px"></asp:Label>
                    </td>
                </tr>
                 <tr>
                     <td  style="font-size:15px;">Name: </td>
                     <td >  <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                     </td>
                </tr>
                <tr>
                     <td  style="font-size:15px;">Mobile: </td>
                     <td >  <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                     </td>
                </tr>
               
           <tr>
                <td  colspan="2">
                    <br />
                    <asp:Button ID="btnsave" CommandName="Save" runat="server" Text="Update" ValidationGroup="S"  Font-Bold="True" class="btn btn-success" OnClick="btnsave_Click" />
                    &nbsp;&nbsp;&nbsp; <asp:Button ID="btnCancel" runat="server" Text="Cancel" Font-Bold="True" class="btn btn-danger" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
                   
    </asp:Panel>
                </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>

