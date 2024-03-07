<%@ WebHandler Language="VB" Class="captcha" %>

Imports System
Imports System.Web
Imports System.Drawing
Imports System.Web.SessionState

Public Class captcha
    Implements IHttpHandler
    Implements IRequiresSessionState
         
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        
        context.Response.ContentType = "image/jpeg"
        Dim captcha As New Class_Captcha()
        Dim str As String = captcha.DrawNumbers(5)
        If context.Session(Class_Captcha.SESSION_CAPTCHA) Is Nothing Then
            context.Session.Add(Class_Captcha.SESSION_CAPTCHA, str)
        Else
            context.Session(Class_Captcha.SESSION_CAPTCHA) = str
        End If
        Dim bmp As Bitmap = captcha.Result
        bmp.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg)
    End Sub
    
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property

End Class