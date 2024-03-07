Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

Public Class Class_Captcha
    Public Shared SESSION_CAPTCHA As String = "CAPTCHA"


    Const default_width As Integer = 135
    Const default_height As Integer = 35

    Protected m_result As Bitmap = Nothing

    Public Width As Integer
    Public Height As Integer

    Public Sub New()
        InitBitmap(default_width, default_height)
        rnd = New Random()
    End Sub

    Public Sub New(ByVal width As Integer, ByVal height As Integer)
        InitBitmap(width, height)
    End Sub

    Protected Sub InitBitmap(ByVal width__1 As Integer, ByVal height__2 As Integer)
        m_result = New Bitmap(width__1, height__2)
        Width = width__1
        Height = height__2
        rnd = New Random()
    End Sub

    Public Function Noise(ByVal p As PointF, ByVal eps As Double) As PointF
        p.X = Convert.ToSingle(rnd.NextDouble() * eps * 2 - eps) + p.X
        p.Y = Convert.ToSingle(rnd.NextDouble() * eps * 2 - eps) + p.Y
        Return p
    End Function

    Public Function Wave(ByVal p As PointF, ByVal amp As Double, ByVal size As Double) As PointF
        p.Y = Convert.ToSingle(Math.Sin(p.X / size) * amp) + p.Y
        p.X = Convert.ToSingle(Math.Sin(p.X / size) * amp) + p.X
        Return p
    End Function

    Public Function RandomWarp(ByVal path As GraphicsPath) As GraphicsPath
        ' Add line //
        Dim PsCount As Integer = 10
        Dim curvePs As PointF() = New PointF(PsCount * 2 - 1) {}
        For u As Integer = 0 To PsCount - 1
            curvePs(u).X = u * (Width / PsCount)
            curvePs(u).Y = Height / 2
        Next
        For u As Integer = PsCount To (PsCount * 2) - 1
            curvePs(u).X = (u - PsCount) * (Width / PsCount)
            curvePs(u).Y = Height / 2 + 2
        Next


        Dim eps As Double = Height * 0.05

        Dim amp As Double = rnd.NextDouble() * CDbl((Height / 3))
        Dim size As Double = rnd.NextDouble() * CDbl((Width / 4)) + Width / 8

        Dim offset As Double = CDbl((Height / 3))


        Dim pn As PointF() = New PointF(path.PointCount - 1) {}
        Dim pt As Byte() = New Byte(path.PointCount - 1) {}

        Dim np2 As New GraphicsPath()

        Dim iter As New GraphicsPathIterator(path)
        For i As Integer = 0 To iter.SubpathCount - 1
            Dim sp As New GraphicsPath()
            Dim closed As Boolean
            iter.NextSubpath(sp, closed)

            Dim m As New Matrix()
            m.RotateAt(Convert.ToSingle(rnd.NextDouble() * 30 - 15), sp.PathPoints(0))

            m.Translate(-1 * i, 0)
            'uncomment
            sp.Transform(m)

            np2.AddPath(sp, True)
        Next




        For i As Integer = 0 To np2.PointCount - 1
            'pn[i] = Noise( path.PathPoints[i] , eps);
            pn(i) = Wave(np2.PathPoints(i), amp, size)
            pt(i) = np2.PathTypes(i)
        Next

        Dim newpath As New GraphicsPath(pn, pt)

        Return newpath

    End Function

    Private rnd As Random

    Public Function DrawNumbers(ByVal len As Integer) As String
        Dim str As String = ""
        'Dim possible As String = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789abcdfghjkmnpqrstvwxyz"
        Dim possible As String = "1234567890"
        Dim ch As Char = "A"
        For i As Integer = 0 To len - 1
            ch = possible(rnd.[Next](0, possible.Length - 1))
            str = str + ch.ToString()
        Next

        DrawText(str)
        Return str
    End Function

    Public Sub DrawText(ByVal aText As String)

        Dim g As Graphics = Graphics.FromImage(m_result)
        Dim startsize As Integer = Height
        Dim f As New Font("Verdana", startsize, FontStyle.Bold, GraphicsUnit.Pixel)

        Do
            f = New Font("Verdana", startsize, GraphicsUnit.Pixel)
            startsize -= 1
        Loop While (g.MeasureString(aText, f).Width >= Width) OrElse (g.MeasureString(aText, f).Height >= Height)
        Dim sf As SizeF = g.MeasureString(aText, f)
        Dim width__1 As Integer = Convert.ToInt32(sf.Width)
        Dim height__2 As Integer = Convert.ToInt32(sf.Height)

        Dim x As Integer = Convert.ToInt32(Math.Abs(CDbl(width__1) - CDbl(Width)) * rnd.NextDouble())
        Dim y As Integer = Convert.ToInt32(Math.Abs(CDbl(height__2) - CDbl(Height)) * rnd.NextDouble())

        '//// Paths ///
        Dim path As New GraphicsPath(FillMode.Alternate)

        Dim family As New FontFamily("Verdana")
        Dim fontStyle__3 As Integer = CInt((FontStyle.Regular))
        Dim emSize As Single = f.Size
        Dim origin As New Point(x, y)
        Dim format As StringFormat = StringFormat.GenericDefault

        path.AddString(aText, family, fontStyle__3, emSize, origin, format)


        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
        Dim rect As New Rectangle(0, 0, Width, Height)
        g.FillRectangle(New System.Drawing.Drawing2D.LinearGradientBrush(rect, Color.White, Color.White, 0.0F), rect)
        g.SmoothingMode = SmoothingMode.HighQuality


        Dim noiseCol As Color = Color.FromArgb(151, 151, 151)
        Dim p As New Pen(noiseCol)


        ' generate random dots in background 

        For i As Integer = 0 To (Width * Height) / 3 - 1
            g.FillEllipse(Brushes.DarkGray, rnd.[Next](0, Width), rnd.[Next](0, Height), 1, 1)
        Next
        'noise ends here


        ' generate random lines in background 

        For i As Integer = 0 To (Width * Height) / 150 - 1
            g.DrawLine(p, rnd.[Next](0, Width), rnd.[Next](0, Height), rnd.[Next](0, Width), rnd.[Next](0, Height))
        Next

        Dim textColor As Color = Color.FromArgb(100, 80, 60)
        g.FillPath(New SolidBrush(textColor), path)

        g.Dispose()
    End Sub

    Public ReadOnly Property Result() As Bitmap
        Get
            Return m_result
        End Get
    End Property

End Class

