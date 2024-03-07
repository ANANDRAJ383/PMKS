<%@ Page Title="" Language="C#" MasterPageFile="DAOMasterPage.master"  CodeFile="DAOPraliApproval.aspx.cs" Inherits="DAO_DAOPraliApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <script type="text/javascript">
          function CheckBoxSelectionValidationdiesel() {
              var count = 0;
              var objgridview = document.getElementById('<%= gdviewdrought.ClientID %>');
              /*Get all the controls preent in gridview*/
              for (var i = 0; i < objgridview.getElementsByTagName("input").length; i++) {
                  /*Get the input control type*/
                  var chknode = objgridview.getElementsByTagName("input")[i];
                  /*Check weather checkbox is selected or not*/
                  if (chknode != null && chknode.type == "checkbox" && chknode.checked) {
                      count = count + 1;
                  }
              }
              /*Alert message if none of the checkboc is selected*/
              if (count == 0) {
                  alert("Please select atleast one checkbox from gridview.");
                  return false;
              }
              else {
                  return true;
              }
          }
    </script>
      <script type="text/javascript">
         function Validate_Checkbox() {

             var chks = document.getElementsByTagName('input');
             var hasChecked = false;
             for (var i = 0; i < chks.length; i++) {
                 if (chks[i].checked) {
                     hasChecked = true;
                     break;
                 }
             }
             if (hasChecked == false) {
                 alert('Please select at least one checkbox..!');
                 return false;
             }
             return true;
         }

    </script>
      <script type="text/javascript">
         function CheckRow(objRef) {
             //Get the Row based on checkbox
             var row = objRef.parentNode.parentNode;
             if (objRef.checked) {
                 //Change the gridview row color when checkbox #5CADFFchecked change
                 row.style.backgroundColor = "white";
             }
             else {
                 //If checkbox not checked change default row color#AED6FF
                 if (row.rowIndex % 2 == 0) {
                     //Alternating Row Color
                     row.style.backgroundColor = "white";
                 }
                 else {
                     row.style.backgroundColor = "white";
                 }
             }

             //Get the reference of GridView
             var GridView = row.parentNode;

             //Get all input elements in Gridview
             var inputList = GridView.getElementsByTagName("input");

             for (var i = 0; i < inputList.length; i++) {
                 //The First element is the Header Checkbox
                 var headerCheckBox = inputList[0];

                 //Based on all or none checkboxes
                 //are checked check/uncheck Header Checkbox
                 var checked = true;
                 if (inputList[i].type == "checkbox" && inputList[i]
                                                    != headerCheckBox) {
                     if (!inputList[i].checked) {
                         checked = false;
                         break;
                     }
                 }
             }
             headerCheckBox.checked = checked;
         }
         function checkAllRow(objRef) {
             var GridView = objRef.parentNode.parentNode.parentNode;
             var inputList = GridView.getElementsByTagName("input");
             for (var i = 0; i < inputList.length; i++) {
                 //Get the Cell To find out ColumnIndex
                 var row = inputList[i].parentNode.parentNode;
                 if (inputList[i].type == "checkbox" && objRef
                                                     != inputList[i]) {
                     if (objRef.checked) {
                         //If the header checkbox is checked
                         //check all checkboxes
                         //and highlight all rows
                         row.style.backgroundColor = "#5CADFF";
                         inputList[i].checked = true;
                     }
                     else {
                         //If the header checkbox is checked
                         //uncheck all checkboxes
                         //and change rowcolor back to original
                         if (row.rowIndex % 2 == 0) {
                             //Alternating Row Color
                             row.style.backgroundColor = "#AED6FF";
                         }
                         else {
                             row.style.backgroundColor = "white";
                         }
                         inputList[i].checked = false;
                     }
                 }
             }
         }
    </script>
      <script language="Javascript">


        function valphone(e) {
            var allow = '1234567890.'
            var k;
            k = document.all ? parseInt(e.keyCode) : parseInt(e.which);
            return (allow.indexOf(String.fromCharCode(k)) != -1);
        }
    </script>    
      <script type="text/javascript">
        function ClearFileUploadControl() {
            var upload = document.getgetElementById("FileUpload1");
            upload.select()
            clrctrl = upload.createTextRange();
            clr.execCommand('delete');
            upload.focus();
        }
    </script>  
      <script type="text/javascript">
        function LoadDiv(url) {
            var img = new Image();
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            var imgLoader = document.getElementById("imgLoader");
            imgLoader.style.display = "block";
            img.onload = function () {
                imgFull.src = img.src;
                imgFull.style.display = "block";
                imgLoader.style.display = "none";
            };
            img.src = url;
            var width = document.body.clientWidth;
            if (document.body.clientHeight > document.body.scrollHeight) {
                bcgDiv.style.height = document.body.clientHeight + "px";
            }
            else {
                bcgDiv.style.height = document.body.scrollHeight + "px";
            }
            imgDiv.style.left = (width - 650) / 2 + "px";
            imgDiv.style.top = "20px";
            bcgDiv.style.width = "100%";

            bcgDiv.style.display = "block";
            imgDiv.style.display = "block";
            return false;
        }
        function HideDiv() {
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            if (bcgDiv != null) {
                bcgDiv.style.display = "none";
                imgDiv.style.display = "none";
                imgFull.style.display = "none";
            }
        }
</script>

    <style type="text/css">
body
{
    margin: 0;
    padding: 0;
    height: 100%;
}
.modal
{
    display: none;
    position: absolute;
    top: 0px;
    left: 0px;
    background-color: black;
    z-index: 100;
    opacity: 0.8;
    filter: alpha(opacity=60);
    -moz-opacity: 0.8;
    min-height: 100%;
}
#divImage
{
    display: none;
    z-index: 1000;
    position: fixed;
    top: 0;
    left: 0;
    background-color: White;
    height: 550px;
    width: 600px;
    padding: 3px;
    border: solid 1px black;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div style="font-family: Cambria; font-size: 18px; color: #fff; font-weight: bold;
        background-color: #5ed07c;  width: 100%;" align="center">Stubble Burn Records (Reported by AC)</div><br />
    <asp:Panel runat="server" ID="pnlgdview" GroupingText="" Font-Names="Verdana" Font-Size="10pt" ScrollBars="Horizontal"  Width="100%">
          <div class="panel panel-success">
               
                <div class="panel-body" style="font-size: 12px;">
<div>
     <asp:UpdatePanel ID="UpdatePanelMain" runat="server" UpdateMode="Always"  >
                           <ContentTemplate>
    <asp:GridView ID="gdviewdrought" runat="server" DataKeyNames="Registrationno" AutoGenerateColumns="false" AllowPaging="true"  PageSize="40"
                        CssClass="table table-bordered  table-striped"  EmptyDataText="No Record Found..">
                 <Columns>
                     <asp:TemplateField ItemStyle-Width="40px">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chknew" runat="server"  onclick="checkAllRow(this);" AutoPostBack="true" OnCheckedChanged="chknew_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" onclick="CheckRow(this);" ></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                            <asp:TemplateField HeaderText="क्रम संख्या" HeaderStyle-CssClass="smallSize">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1+"." %>
                                </ItemTemplate>
                               
                                <HeaderStyle CssClass="smallSize" />
                               
                            </asp:TemplateField>
                          
                             
                           <asp:BoundField DataField="Registrationno" HeaderText="पंजीकरण संख्या"></asp:BoundField>
                            <asp:BoundField DataField="FarmersName" HeaderText="आवेदक" >
                            </asp:BoundField>
                            <asp:BoundField DataField="FatherHusbandName" HeaderText="पिता/पति का नाम" ></asp:BoundField>
                            <asp:BoundField DataField="MobileNumber" HeaderText="मोबाइल नंबर" ></asp:BoundField>
                            <asp:BoundField DataField="LandArea" HeaderText="प्रभावित रकवा" ></asp:BoundField>
                            <asp:BoundField DataField="CropName" HeaderText="फसल का नाम" ></asp:BoundField>
                            <asp:BoundField DataField="Remarks" HeaderText="AC अभियुक्ति" ></asp:BoundField>
                            <asp:TemplateField HeaderText="ViewImage"  >
                                <ItemTemplate>
                                 <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#Bind("doc") %>' Height="50px" Width="100px" Style="cursor: pointer"  OnClientClick="return LoadDiv(this.src);"/>                              
                                </ItemTemplate>
                            </asp:TemplateField>

                      <asp:TemplateField  HeaderText="Download"  Visible="false">
                             <ItemTemplate>
                                     <asp:LinkButton ID="lnkDownload"  Text = "Download" CommandArgument = '<%# Eval("ParaliPath") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton> <%--OnClick = "DownloadFile"--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="Document">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("doc")%>'
                            Target="_blank">View</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                         <asp:TemplateField  HeaderText="सत्यापन एवं अभियुक्ति (BAO)" >
                             <ItemTemplate>
                                 <asp:DropDownList ID="ddlApproved" runat="server" Width="100px" >
                                     <asp:ListItem Text="स्वीकृत" Value="1"></asp:ListItem> 
                                      <asp:ListItem Text="अस्वीकृत" Value="2"></asp:ListItem> 

                                 </asp:DropDownList>    
                                 <asp:TextBox  ID="txtCommentDAO"  runat="server" TextMode="MultiLine" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                            
                        </Columns>
        </asp:GridView>

                               </ContentTemplate>
                        </asp:UpdatePanel>
</div>

                    <div>
                         <asp:Button ID="btnremarks" runat="server" Text="Submit" Font-Names="Verdana"  Font-Bold="true"  OnClientClick="javascript:return CheckBoxSelectionValidationdiesel();" OnClick="btnremarks_Click" />
                    </div>
       
                    </div> </div> 
        
    </asp:Panel>


     <div id="divBackground" class="modal">
</div>
<div id="divImage">
<table class="table-bordered  table table-striped " style="width: 100%;">
    <tr>
        <td valign="middle" align="center">
            <img id="imgLoader" alt="" src="Images/loader.gif" />
            <img id="imgFull" alt="" src="" style="display: none; height: 500px; width: 590px" />
        </td>
    </tr>
    <tr>
        <td align="center" valign="bottom">
            <input id="btnClose" type="button" value="close" onclick="HideDiv()" />
        </td>
    </tr>
</table>

</asp:Content>

