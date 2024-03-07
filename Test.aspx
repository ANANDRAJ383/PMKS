<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html>

<html>
<head>


    <script>
        function myFunction() {
            document.getElementById("p").innerHTML = "My First JS";
        }
    </script>
</head>
<body>
    <div>
        <p id="p">Test</p>
        <%--<asp:Button ID="btnOK" runat="server" Text="Click" onclick="myFunction()" />--%>
        <button type="button" onclick="myFunction()">Try it</button>
    </div>

</body>
</html>