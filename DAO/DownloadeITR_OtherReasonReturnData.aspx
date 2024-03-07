﻿<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="DownloadeITR_OtherReasonReturnData.aspx.cs" Inherits="CSC_DownloadeKYCData" EnableEventValidation = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Downloade ITR_Other Reason Return Data List</div><br />
    <table class="table-bordered  table table-striped " style="width: 100%;">
        <tr>
            <td>District</td>
             <td><asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"  >
                           <ContentTemplate><asp:DropDownList ID="ddlDist" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlDist_SelectedIndexChanged">
            </asp:DropDownList> </ContentTemplate>
                        </asp:UpdatePanel></td>
             <td>Block</td>
            <td> <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"  >
                           <ContentTemplate><asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged">
            </asp:DropDownList> </ContentTemplate>
                        </asp:UpdatePanel></td>
             <td>Panchayat</td>
             <td><asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate><asp:DropDownList ID="ddlPanchayat" runat="server" CssClass="form-select">
            </asp:DropDownList></ContentTemplate>
                        </asp:UpdatePanel></td>
            <td> <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always"  >
                           <ContentTemplate><asp:RadioButtonList ID="rbtType" runat="server" 
                        RepeatDirection="Horizontal">
                                              <asp:ListItem Value="I">ITR</asp:ListItem>
                                              <asp:ListItem Value="O">Other</asp:ListItem>
                                          </asp:RadioButtonList></ContentTemplate>
                        </asp:UpdatePanel></td>
            <td><asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="btn btn-success" OnClick="btnDownload_Click"  /></td>
        </tr>
    </table>
    


<div class="form-row">
    </div>

       
</asp:Content>

