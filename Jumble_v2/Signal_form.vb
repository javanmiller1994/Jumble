Imports System.Runtime.InteropServices
Imports System.Threading

Public Class Signal_form

#Region " Declares"
    Declare Auto Function SetParent Lib "user32.dll" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Private Const WM_SYSCOMMAND As Integer = 274
    Private Const SC_MAXIMIZE As Integer = 61488
    Public Const SWP_NOMOVE As Short = &H2
    Public Const SWP_NOSIZE As Short = 1
    Public Const SWP_NOZORDER As Short = &H4
    Public Const SWP_SHOWWINDOW As Short = &H40
    Shared ReadOnly HWND_BOTTOM As IntPtr = New IntPtr(1)
    Public Const SWP_NOREDRAW = &H8
    Public Const SWP_NOACTIVATE = &H10
    Public Const SWP_FRAMECHANGED = &H20

    Public Const SWP_HIDEWINDOW = &H80
    Public Const SWP_NOCOPYBITS = &H100
    Public Const SWP_NOOWNERZORDER = &H200
    Public Const SWP_DRAWFRAME = SWP_FRAMECHANGED
    Public Const SWP_NOREPOSITION = SWP_NOOWNERZORDER
    Public Const FLAGS As Long = SWP_NOMOVE Or SWP_NOSIZE
    Public Const HWND_TOP = 0
    ' Public Shared GWL_STYLE As Integer = -16
    Public Const HWND_TOPMOST = -1
    Public Const HWND_NOTOPMOST = -2


    <DllImport("user32.dll", EntryPoint:="SetWindowPos")>
    Public Shared Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr, x As Int32, y As Int32, cx As Int32, cy As Int32, wFlags As Int32) As IntPtr
    End Function

    Private Declare Auto Function FindWindow Lib "user32" (ByVal ClassName As String, ByVal WindowTitle As String) As IntPtr
    Private Declare Function MoveWindow Lib "user32" (ByVal hwnd As Long, ByVal x As Long, ByVal y As Long, ByVal nWidth As Long, ByVal nHeight As Long, ByVal bRepaint As Long) As Long

    Private Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function
    Private Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As IntPtr) As Integer
    End Function



    Public Enum WindowStyles As Long

        WS_OVERLAPPED = 0
        WS_POPUP = 2147483648
        WS_CHILD = 1073741824
        WS_MINIMIZE = 536870912
        WS_VISIBLE = 268435456
        WS_DISABLED = 134217728
        WS_CLIPSIBLINGS = 67108864
        WS_CLIPCHILDREN = 33554432
        WS_MAXIMIZE = 16777216
        WS_BORDER = 8388608
        WS_DLGFRAME = 4194304
        WS_VSCROLL = 2097152
        WS_HSCROLL = 1048576
        WS_SYSMENU = 524288
        WS_THICKFRAME = 262144
        WS_GROUP = 131072
        WS_TABSTOP = 65536

        WS_MINIMIZEBOX = 131072
        WS_MAXIMIZEBOX = 65536

        WS_CAPTION = WS_BORDER Or WS_DLGFRAME
        WS_TILED = WS_OVERLAPPED
        WS_ICONIC = WS_MINIMIZE
        WS_SIZEBOX = WS_THICKFRAME
        WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW

        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED Or WS_CAPTION Or WS_SYSMENU Or
              WS_THICKFRAME Or WS_MINIMIZEBOX Or WS_MAXIMIZEBOX
        WS_POPUPWINDOW = WS_POPUP Or WS_BORDER Or WS_SYSMENU
        WS_CHILDWINDOW = WS_CHILD

        WS_EX_DLGMODALFRAME = 1
        WS_EX_NOPARENTNOTIFY = 4
        WS_EX_TOPMOST = 8
        WS_EX_ACCEPTFILES = 16
        WS_EX_TRANSPARENT = 32

        '#If (WINVER >= 400) Then
        WS_EX_MDICHILD = 64
        WS_EX_TOOLWINDOW = 128
        WS_EX_WINDOWEDGE = 256
        WS_EX_CLIENTEDGE = 512
        WS_EX_CONTEXTHELP = 1024

        WS_EX_RIGHT = 4096
        WS_EX_LEFT = 0
        WS_EX_RTLREADING = 8192
        WS_EX_LTRREADING = 0
        WS_EX_LEFTSCROLLBAR = 16384
        WS_EX_RIGHTSCROLLBAR = 0

        WS_EX_CONTROLPARENT = 65536
        WS_EX_STATICEDGE = 131072
        WS_EX_APPWINDOW = 262144

        WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE Or WS_EX_CLIENTEDGE
        WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE Or WS_EX_TOOLWINDOW Or WS_EX_TOPMOST
        '#End If

        '#If (WIN32WINNT >= 500) Then
        WS_EX_LAYERED = 524288
        '#End If

        '#If (WINVER >= 500) Then
        WS_EX_NOINHERITLAYOUT = 1048576 ' Disable inheritence of mirroring by children
        WS_EX_LAYOUTRTL = 4194304 ' Right to left mirroring
        '#End If

        '#If (WIN32WINNT >= 500) Then
        WS_EX_COMPOSITED = 33554432
        WS_EX_NOACTIVATE = 67108864
        '#End If


    End Enum


#End Region

    Public Shared proc As Process = Nothing

    Private Sub Signal_form_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CenterForm(Me, Form1)

        Form1.SuspendDrawing(Form1)
        Form1.SuspendDrawing(Me)
        Try
            'proc = Process.GetCurrentProcess
            proc = Process.Start("C:\Users\Video Operator\AppData\Local\Programs\signal-desktop\Signal.exe")
            proc.WaitForInputIdle()


            Thread.Sleep(1500)
            ChangeStyles()

            SetParent(proc.MainWindowHandle, Me.Handle)

            Me.Focus()
            Timer1.Start()
            ' SendMessage(proc.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
        Catch ex As Exception

        End Try

    End Sub
    Public Shared Sub CenterForm(ByVal frm As Form, Optional ByVal parent As Form = Nothing)
        '' Note: call this from frm's Load event!
        Dim r As Rectangle
        If parent IsNot Nothing Then
            r = parent.RectangleToScreen(parent.ClientRectangle)
        Else
            r = Screen.FromPoint(frm.Location).WorkingArea
        End If

        Dim x = r.Left + (r.Width - frm.Width) \ 2
        Dim y = r.Top + (r.Height - frm.Height) \ 2
        frm.Location = New Point(x, y)
    End Sub
    Private Sub Signal_form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub Signal_form_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        Timer1.Start()
    End Sub

    Public Sub ChangeStyles()
        Form1.SuspendDrawing(Form1)
        Form1.SuspendDrawing(Me)
        Dim GWL_STYLE As Int32 = -16
        Dim GWL_EXSTYLE As Int32 = -20
        Dim styles As WindowStyles
        'Dim newStyles As WindowStyles = WindowStyles.WS_VISIBLE Or WindowStyles.WS_POPUPWINDOW

        styles = GetWindowLong(proc.MainWindowHandle, GWL_STYLE)
        styles = styles And Not WindowStyles.WS_CAPTION
        styles = styles And Not WindowStyles.WS_SYSMENU
        styles = styles And Not WindowStyles.WS_THICKFRAME
        styles = styles And Not WindowStyles.WS_MINIMIZE
        styles = styles And Not WindowStyles.WS_MAXIMIZEBOX

        SetWindowLong(proc.MainWindowHandle, GWL_STYLE, styles)
        styles = GetWindowLong(proc.MainWindowHandle, GWL_EXSTYLE)
        SetWindowLong(proc.MainWindowHandle, GWL_EXSTYLE, styles Or WindowStyles.WS_EX_DLGMODALFRAME)
        '   SetWindowPos(proc.MainWindowHandle, 0, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_FRAMECHANGED)
        SetWindowPos(proc.MainWindowHandle, HWND_NOTOPMOST, -15, -10, Me.Width + 27, Me.Height - 10, SWP_FRAMECHANGED Or SWP_NOZORDER Or SWP_DRAWFRAME Or SWP_NOZORDER)
        Form1.ResumeDrawing(Me)
        Form1.ResumeDrawing(Form1)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Focus()
        Try
            SetParent(proc.MainWindowHandle, Me.Handle)
            ChangeStyles()

            Me.Focus()
        Catch ex As Exception
        End Try
        Timer1.Stop()
    End Sub

    Private Sub Signal_form_Move(sender As Object, e As EventArgs) Handles Me.Move
        Timer1.Stop()
    End Sub
    Public Sub SetWin_TOPMOST(hWnd As Long)
        SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, FLAGS)
    End Sub





End Class