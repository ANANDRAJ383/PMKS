<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="DownloadeItr_OtherRegionData.aspx.cs" Inherits="CSC_DownloadeKYCData" EnableEventValidation = "false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div style="font-family: Cambria; font-size: 18px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">Download ITR and Other Resion Return Data List</div><br />

    <div class="col-lg-12">
        <h5>Please Chosse the Resion</h5>
        <div class="form-check form-check-inline">
            <asp:RadioButton runat="server" class="form-check-input" id="rbItr" ></asp:RadioButton>
  <label class="form-check-label" for="inlineRadio1">ITR</label>
</div>
<div class="form-check form-check-inline">
    <asp:RadioButton runat="server" class="form-check-input" id="rbOther"></asp:RadioButton>
  <label class="form-check-label" for="inlineRadio2">Other Resion</label>
</div>

    </div>


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
            <td><asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="btn btn-success" OnClick="btnDownload_Click"  /></td>
        </tr>
    </table>
    


<div class="form-row">
    </div>

       
</asp:Content>

