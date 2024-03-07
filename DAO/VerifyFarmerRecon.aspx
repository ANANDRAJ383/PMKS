<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master" AutoEventWireup="true" CodeFile="VerifyFarmerRecon.aspx.cs" Inherits="DAO_VerifyFarmerRe_Recon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <br />
<div style="font-family: Cambria; font-size: 22px; color: #000; font-weight: bold;
        background-color: #5ed07c; padding: 5px; width: 100%;" align="center">PM-KISAN आवेदन सत्यापन <asp:Label ID="lblRegId" runat="server" ></asp:Label></div><br />

    <table class="table-bordered  table table-striped " style="width: 100%;" align="center">
        <tr>
            <td colspan="2">सत्यापन बिंदु</td>
        </tr>
        <tr>
            <td>1. संलग्न दस्तावेज में जमीन का रकवा शून्य (0) नहीं है |</td>
             <td> <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem >Yes</asp:ListItem>
                        <asp:ListItem >No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>2. पंचायत स्तर से पुष्टि हुई कि आवेदक के अलावा कोई अन्य परिवार के सदस्य योजना का लाभ नहीं ले रहे हैं |</td>
              <td> <asp:RadioButtonList ID="rb2" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem >Yes</asp:ListItem>
                        <asp:ListItem >No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>3. जमीन सम्बंधित कागजात में किसान के नाम का मिलान किया गया |डाटा में कोई अंतर नहीं है |</td>
              <td> <asp:RadioButtonList ID="rb3" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem >Yes</asp:ListItem>
                        <asp:ListItem >No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
          <tr>
            <td>4. आवेदन में जमीन दस्तावेज अद्यतन है |</td>
              <td> <asp:RadioButtonList ID="rb4" runat="server" RepeatDirection="Horizontal" Width="100%">
                        <asp:ListItem >Yes</asp:ListItem>
                        <asp:ListItem >No</asp:ListItem>
                    </asp:RadioButtonList></td>
        </tr>
          <tr>
            <td>5. आवेदक योजना के दिशा-निर्देश के अनुसार योग्य पाए गए|</td>
              <td> 
                  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
                  <asp:RadioButtonList ID="rb5" runat="server" RepeatDirection="Horizontal" Width="100%" OnSelectedIndexChanged="rb5_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem >Yes</asp:ListItem>
                        <asp:ListItem >No</asp:ListItem>
                    </asp:RadioButtonList>
                              
             <asp:DropDownList ID="ddlReason" runat="server"  CssClass="form-select" Visible="false">                 
             </asp:DropDownList>
                          </ContentTemplate>
                        </asp:UpdatePanel>       


              </td>
        </tr>
          
        
        <tr>
            <td  >
                        <asp:CheckBox ID="CheckBox2" runat="server" /> &nbsp;&nbsp;
                  </td>
             <td>उपरोक्त जानकारी सही है एवं सत्यापन किया जा सकता है । </td>
        </tr>
        <tr>
            <td><asp:Button ID="bnSave" runat="server" Text="सत्यापित एवं सुरक्षित करें"   class="btn btn-success" OnClick="bnSave_Click"  /> </td>
            <td><asp:Button ID="btnBack" runat="server" Text="Back"   class="btn-danger" OnClick="btnBack_Click" Height="40px"  Font-Size="16" /></td>
        </tr>
        
    </table>
</asp:Content>

