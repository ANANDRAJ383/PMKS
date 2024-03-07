Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Net
Imports System.Drawing
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class DAL
    'Public Shared sqlconn As New SqlConnection
    Public Shared imgg As String ', app_registered, dcode_registered, dob_registered, final_applno As String
    
    Public Shared Function FilterBadchars(ByVal _Param As String) As String
        Dim _newchars As String = ""
        Dim _i As Integer

        Dim badchars() As String = {"onfocus", """", "=", "onmouseover", "prompt", "%27", "%28", "%20", "%29", "alert#", "alert", "'or", "`or", "`or`", "'or'", "'='", "`=`", "'", "`", "9,9,9", "src", "onload", "select", "drop", "insert", "delete", "xp_", "having", "union", "group", "update", "script", "<script", "</script>", "language", "javascript", "vbscript", "http", "--", "~", "$", "<", ">", "(", ")", "%", "\", "+", ":", ";", "@", "_", "{", "}", "|", ",", ".", "?", "[", "]", "-", "!", "#", "^", "&", "*"}

        '===================================
        _newchars = _Param
        For _i = 0 To UBound(badchars)
            _newchars = Replace(_newchars, badchars(_i), "", 1, -1, CompareMethod.Text)
        Next
        '=================================
        If IsNothing(_newchars) Then
            _newchars = ""
        End If

        Return _newchars
    End Function

    Public Shared Function FilterBadchars_pass(ByVal _Param As String) As String
        Dim _newchars As String = ""
        Dim _i As Integer

        Dim badchars() As String = {"onfocus", "/", """", "=", "alert", "'or", "`or", "`or`", "'or'", "'='", "`=`", "'", "`", "9,9,9", "src", "onload", "select", "drop", "insert", "delete", "xp_", "having", "union", "group", "update", "script", "<script", "</script>", "language", "javascript", "vbscript", "http", "--", "~", "$", "<", ">", "(", ")", "%", "\", "+", ":", ";"}
        '===================================
        _newchars = _Param
        For _i = 0 To UBound(badchars)
            _newchars = Replace(_newchars, badchars(_i), "", 1, -1, CompareMethod.Text)
        Next
        '=================================
        If IsNothing(_newchars) Then
            _newchars = ""
        End If

        Return _newchars
    End Function

    Public Shared Function FilterBadchars_querystring(ByVal _Param As String) As String
        Dim _newchars As String = ""
        Dim _i As Integer
        Dim position As Integer
        _newchars = _Param

        '@_{}|,.?[]-
        '/ is allowed 
        Dim badchars() As String = {"onfocus", """", "=", "onmouseover", "prompt", "%27", "%28", "%20", "%29", "alert#", "alert", "'or", "`or", "`or`", "'or'", "'='", "`=`", "'", "`", "9,9,9", "src", "onload", "select", "drop", "insert", "delete", "xp_", "having", "union", "group", "update", "script", "<script", "</script>", "language", "javascript", "vbscript", "http", "--", "~", "$", "<", ">", "(", ")", "%", "\", "+", ":", ";", "@", "_", "{", "}", "|", ",", ".", "?", "[", "]", "-"}
        '===================================

        For _i = 0 To UBound(badchars)
            position = InStr(_newchars, badchars(_i))

            If position = 0 Then

            Else
                'HttpContext.Current.Response.Redirect(HttpContext.Current.Server.MapPath("Errorpage.aspx"))
                HttpContext.Current.Response.Redirect("~/errorpage.aspx")
                'Response.Redirect("~/errorpage.aspx", False)
            End If
        Next
        '===================================
        Return _newchars
    End Function

    Public Shared Function date_valid(ByVal txt As String) As Boolean
        ' First find spiltter in textbox 
        ' split the string on splitter
        Dim separater As String = String.Empty
        Dim dateString As String = String.Empty
        Dim ArrayLen As Integer
        Dim Mon_Array() = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}
        Dim lMon_Array() = {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}
        Dim lpyear As Boolean = False
        Dim Day As String = String.Empty
        Dim mont As String = String.Empty
        Dim yr As String = String.Empty

        separater = ""
        If InStr(txt, "/") > 0 Then
            separater = "/"
        ElseIf InStr(txt, "-") > 0 Then
            separater = "-"
        ElseIf InStr(txt, ".") > 0 Then
            separater = "."
        End If

        dateString = txt
        Dim DateArray() = Split(dateString, separater)
        ArrayLen = DateArray.Length()

        If ArrayLen <> 3 Or separater = "" Then
            Return False
        End If

        If Not IsNumeric(DateArray(0)) Then
            Return False
        End If

        If Not IsNumeric(DateArray(1)) Then
            Return False
        End If

        If Not IsNumeric(DateArray(2)) Then
            Return False
        End If


        Day = DateArray(0)
        mont = DateArray(1)
        yr = DateArray(2)

        If CInt(mont) < 1 Or CInt(mont) > 12 Then
            Return False
        End If

        If CInt(Day) < 1 Or CInt(Day) > 31 Then
            Return False
        End If


        If DateArray(2).ToString.Length <> 4 Then
            Return False
        Else
            If CInt(yr) < 1900 Or CInt(yr) > 2012 Then
                Return False
            Else
                'Check for Leap Year
                If (CInt(yr) Mod 4) = 0 And Not (CInt(yr) Mod 100 = 0) Then
                    lpyear = True
                End If
            End If
        End If

        If lpyear = False And CInt(Day) > Mon_Array(CInt(mont) - 1) Then
            Return False
        End If

        If lpyear And CInt(Day) > lMon_Array(CInt(mont) - 1) Then
            Return False
        Else
            Return True
        End If
    End Function
    'REINITIALIZE COOKIE VALUE AT EACH REQUEST
    Public Sub reCookie()
        Dim num As String
        Dim rn As New Random
        num = rn.Next(1000, 9999).ToString + rn.Next(10000, 99999).ToString + rn.Next(100000, 999999).ToString
        If (Not HttpContext.Current.Request.Cookies("ASPFIXATION") Is Nothing) Then
            HttpContext.Current.Response.Cookies.Clear()
        End If
        HttpContext.Current.Response.Cookies.Add(New HttpCookie("ASPFIXATION", GetHashWIPAddress(num)))
        HttpContext.Current.Session("ASPFIXATION") = num
    End Sub
    'Public Sub reCookie()
    '    Dim num, strip As String
    '    Dim rn As New Random
    '    Dim verobj As New verify
    '    strip = verobj.GetIP()
    '    Dim ccid As String = HttpContext.Current.Request.Cookies("ASPFIXATION").Value
    '    Dim aa As String = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(HttpContext.Current.Session("ASPFIXATION").ToString() & strip, "MD5")
    '    If aa <> ccid Then
    '        'HttpContext.Current.Response.Redirect("~/sessionExpired.aspx") ' un comment
    '        HttpContext.Current.Response.Redirect("~/errorpage.aspx", False)
    '    End If
    '    num = rn.Next(1000, 9999).ToString + rn.Next(10000, 99999).ToString + rn.Next(100000, 999999).ToString
    '    If (Not HttpContext.Current.Request.Cookies("ASPFIXATION") Is Nothing) Then
    '        HttpContext.Current.Response.Cookies.Clear()
    '    End If
    '    HttpContext.Current.Response.Cookies.Add(New HttpCookie("ASPFIXATION", System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(num & strip, "MD5")))
    '    HttpContext.Current.Session("ASPFIXATION") = num
    'End Sub
    'TO HANDLE SESSION HIJACKING
    Public Function checkSessionHijack() As Exception
        Dim cookie_value, session_value As String
        cookie_value = System.Web.HttpContext.Current.Request.Cookies("ASPFIXATION").Value
        session_value = System.Web.HttpContext.Current.Session("ASPFIXATION")
        If cookie_value <> GetHashWIPAddress(session_value) Then
            System.Web.HttpContext.Current.Session.Abandon()
            HttpContext.Current.Response.Buffer = False
            Throw New Exception("sessionhijackerror")
            'HttpContext.Current.Response.Redirect("~/errorpage.aspx", False)
        End If
    End Function

    'TO GET HASH WITH IP TO CHECK SESSION HIJACKING
    Public Function GetHashWIPAddress(ByVal s As String) As String
        Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Dim enc As String = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile((HttpContext.Current.Request.UserHostAddress.ToString + s), "MD5")
        Return enc
    End Function
    Public Shared Function CHK_ASPFIXATION1_ID(ByVal ASPFIXATION1 As String) As Boolean
        '--- chk aspfixation1 for blank value ------
        If (ASPFIXATION1.Trim = "") Then
            System.Web.HttpContext.Current.Session.Abandon()
            HttpContext.Current.Response.Buffer = False
            HttpContext.Current.Response.Redirect("errorpage.aspx", False)
        End If
        Return True
    End Function
    '-------------------------------------------
    Public Shared Function FilterBadchars_textFile(ByVal _Param As String) As String
        Dim _newchars As String = ""
        Dim _i As Integer

        Dim badchars() As String = {"onfocus", """", "=", "onmouseover", "prompt", "%27", "%28", "%20", "%29", "alert#", "alert", "'or", "`or", "`or`", "'or'", "'='", "`=`", "'", "`", "9,9,9", "src", "onload", "select", "drop", "insert", "delete", "xp_", "having", "union", "group", "update", "script", "<script", "</script>", "language", "javascript", "vbscript", "http", "--", "~", "$", "<", ">", "(", ")", "%", "\", "+", ":", ";", "@", "_", "{", "}", "|", ".", "?", "[", "]", "-", "!", "#", "^", "&", "*"}

        '===================================
        _newchars = _Param
        For _i = 0 To UBound(badchars)
            _newchars = Replace(_newchars, badchars(_i), "", 1, -1, CompareMethod.Text)
        Next
        '=================================
        If IsNothing(_newchars) Then
            _newchars = ""
        End If

        Return _newchars
    End Function

    '===== Function used to Generate check digit
    Public Function GenerateCheckDigit(ByVal NumInString As String) As Int16

        Dim OddSum As Int16 = 0
        Dim EvenSum As Int16 = 0
        Dim i As Int16 = 0
        Dim Digit As Int16
        Dim Generate_Mod As Int16 = 0

        If IsNumeric(NumInString) = False Then 'must be numeric
            Return 0
        End If

        For i = 0 To NumInString.Length - 1
            Digit = Convert.ToInt32(NumInString.Substring(i, 1))
            If (i Mod 2 <> 0) Then
                EvenSum += Digit
            Else
                OddSum += Digit
            End If
        Next
        Generate_Mod = (((OddSum * 3) + EvenSum) Mod 10)

        If Generate_Mod = 0 Then 'in case of mod 0
            Generate_Mod = 1
        Else 'in case of mod 1-9
            'no chage
        End If

        Return (10 - Generate_Mod)

    End Function

    '===== Function used to verify check digit
    Public Function Verify_CheckDigit(ByVal NumInString As String) As Boolean

        Dim str1 As String = ""
        Dim str2 As String = ""
        Dim flag As Boolean = False

        If IsNumeric(NumInString) = False Then 'must be numeric
            flag = False
        ElseIf NumInString.Length <> 11 Then ' String must be 11 digit
            flag = False
        ElseIf NumInString.Length = 11 Then
            str1 = NumInString.Substring(0, 10) ' starting 1-10 digit means registration no
            str2 = NumInString.Substring(10, 1) ' and 10-11 digit means check digit

            If GenerateCheckDigit(str1).ToString = str2 Then ' match
                flag = True
            Else ' unmatch
                flag = False
            End If
        Else
            flag = False
        End If

        Return flag
    End Function
    Public Function Encrypt(ByVal StrEncode As String)
        Dim encodedString As String
        encodedString = (Convert.ToBase64String(System.Text.UnicodeEncoding.ASCII.GetBytes(StrEncode)))
        Return (encodedString)
    End Function
    Public Function Decrypt(ByVal StrDecode As String)
        Try
            Dim decodedString As String
            decodedString = System.Text.UnicodeEncoding.ASCII.GetString(Convert.FromBase64String(StrDecode))
            Return decodedString
        Catch ex As Exception
            'checkExcep(ex.Message.Substring(0, ex.Message.IndexOf(".")))
        End Try


    End Function
    'Public Function capchaBadchars(ByVal _Param As String) As String
    '    Dim _newchars As String = ""
    '    Dim _i As Integer
    '    Dim _j As Integer
    '    Dim badchars() As String = {"=", """", "'or", "`or", "`or`", "'or'", "'='", "`=`", "'", "`", "xp_", "<script", "</script>", "--", "~", "$", "<", ">", "(", ")", "%", "\", "+", ":", ";", "@", "_", "{", "}", "|", ",", ".", "?", "[", "]", "-", "!", "#", "^", "&", "*"}

    '    '===================================
    '    _newchars = _Param
    '    For _i = 0 To UBound(badchars)
    '        _newchars = Replace(_newchars, badchars(_i), _newchars, 1, -1, CompareMethod.Text)
    '        If _newchars = badchars(_i) Then
    '            _j = 1
    '            Exit Function
    '        Else
    '            _j = 0
    '        End If
    '    Next

    '    Return _j
    'End Function
End Class
