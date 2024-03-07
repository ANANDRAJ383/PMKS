<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="TargetEntry.aspx.cs" Inherits="Reconcile_DAO_TargetEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script language="JavaScript" type="text/javascript">
        function onlyNumbers(evt) {
            var e = event || evt;
            var charCode = e.which || e.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                alert('Enter Numbers Only');
                return false;
            }
            return true;
        }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="margin: 30px 25px 10px 25px;">

        <div class="row">
            <!-- Revenue breakdown chart example-->
            <div class="col-lg-12 ">
                <div class="card card-raised h-100">
                    <div class="card-header bg-transparent px-4">
                        <div class="d-flex justify-content-between align-items-center">
                            <div class="me-4">
                                <h2 class="card-title mb-0"><b>पीएम-किसान कार्य की प्रविष्टि</b></h2>
                            </div>

                        </div>
                    </div>


                    <div class="row mb-3 m-5">
                        <div class="col-12 col-sm-4 col-md-4 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Sub Divison</b> <span class="mandatory">*</span></label>
                                <asp:DropDownList ID="ddlSubDivison" runat="server" CssClass="form-select" 
                                    OnSelectedIndexChanged="ddlSubDivison_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 col-sm-4 col-md-4 mb-4">
                            <div class="form-group">
                                <label class="control-label"><b>Block</b> <span class="mandatory">*</span>  </label>
                                <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select"                               OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged" AutoPostBack="true" >
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 col-sm-4 col-md-4 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>Entry For </b><span class="mandatory">*</span> </label>
                                <asp:DropDownList ID="ddlEntryFor" runat="server" CssClass="form-select" 
                                    OnSelectedIndexChanged="ddlEntryFor_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Selected="True" Value="0" Text="--Select--"></asp:ListItem>
                                    <asp:ListItem Value="eKYC" Text="eKYC"></asp:ListItem>
                                    <asp:ListItem Value="NPCI" Text="NPCI"></asp:ListItem>
                                    <asp:ListItem Value="Recovery" Text="Recovery"></asp:ListItem>
                                    <asp:ListItem Value="PV" Text="Physical Verification"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 col-sm-4 col-md-4 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>लंबित कुल किसानों की संख्या</b> <span class="mandatory">*</span></label>
                                <asp:TextBox ID="lblPending" runat="server" CssClass="Disabled form-control" Text="0" onkeypress=" return onlyNumbers();" ReadOnly="true"></asp:TextBox>
                            </div>

                        </div>

                        <div class="col-12 col-sm-4 col-md-4 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>गत सप्ताह में किये गए के कुल किसानों की संख्या</b><span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtPendingLastWeek" runat="server" CssClass="form-control" ReadOnly="true" Text="0" onkeypress=" return onlyNumbers();" 
                                    OnTextChanged="txtPendingLastWeek_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-12 col-sm-4 col-md-4 mb-3">
                            <div class="form-group">
                                <label class="control-label"><b>मौजूदा सप्ताह में किये गए के कुल किसानों की संख्या</b><span class="mandatory">*</span></label>
                                <asp:TextBox ID="txtPendingCurrentWeek" runat="server" CssClass="form-control" Text="0" onkeypress=" return onlyNumbers();" 
                                    OnTextChanged="txtPendingCurrentWeek_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-4 col-sm-12 col-md-4"></div>
                            <div class="col-lg-4 col-sm-12 col-md-4">
                                <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="btn btn-raised-primary" OnClick="btnSave_Click" />
                            </div>

                            <div class="col-lg-4 col-sm-12 col-md-4"></div>
                        </div>

                    </div>

                </div>
            </div>
        </div>
<div >
  <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#0066FF" ></asp:Label>
</div>
    </div>
</asp:Content>

