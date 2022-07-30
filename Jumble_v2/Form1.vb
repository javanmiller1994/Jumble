Imports CefSharp.WinForms
Imports CefSharp
Imports System.Text.RegularExpressions
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Security.Cryptography.X509Certificates
Imports DevExpress.XtraBars.ToastNotifications
Imports DevExpress.LookAndFeel
Imports System.Runtime.InteropServices
Imports DevExpress.XtraEditors

Partial Public Class Form1
    Inherits DevExpress.XtraEditors.XtraForm

#Region " Initialize"
    <STAThread>
    Public Shared Sub Main(ByVal args As String())

        Application.Run(Form1)
    End Sub
    Dim WhatsAppThread As Threading.Thread
    Shared Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
    End Sub
    Public Sub New()

        Dim settings As New CefSettings With {
            .CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\CEF",
            .PackLoadingDisabled = False,
            .UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.69 Safari/537.36 Edg/95.0.1020.53"
        }
        If My.Settings.UseCustomUserAgent Then
            If My.Settings.CustomUserAgent <> "" Then
                settings.UserAgent = My.Settings.CustomUserAgent
            End If
        End If

        ' Default: .UserAgent = "Mozilla/5.0 (X11; CrOS x86_64 13310.59.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.84 Safari/537.36 Mozilla/5.0 (X11; CrOS armv7l 13310.59.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.84 Safari/537.36 Mozilla/5.0 (X11; CrOS aarch64 13310.59.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.84 Safari/537.36"
        '.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 Safari/537.36 Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 Safari/537.36 Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.83 Safari/537.36  Mozilla/5.0 (iPhone; CPU iPhone OS 13_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Mobile/15E148 [FBAN/FBIOS;FBDV/iPhone11,8;FBMD/iPhone;FBSN/iOS;FBSV/13.3.1;FBSS/2;FBID/phone;FBLC/en_US;FBOP/5;FBCR/] Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) WhatsApp/2.2017.6 Chrome/76.0.3809.146 Electron/6.1.9 Safari/537.36"
        '.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.69 Safari/537.36 Edg/95.0.1020.53"

        settings.CefCommandLineArgs.Add("--enable-media-stream")
        settings.CefCommandLineArgs.Add("--disable-signin-frame-client-certs")
        settings.CefCommandLineArgs.Add("--persist-session-cookies=true")
        settings.CefCommandLineArgs.Add("persist-session-cookies")
        'settings.CefCommandLineArgs.Add("enable-system-flash")
        settings.CefCommandLineArgs.Add("allow-running-insecure-content")
        settings.CefCommandLineArgs.Add("enable-features", "CastMediaRouteProvider,NetworkServiceInProcess")
        settings.CefCommandLineArgs.Add("debug-plugin-loading", "1")
        settings.CefCommandLineArgs.Add("allow-outdated-plugins", "1")
        settings.CefCommandLineArgs.Add("always-authorize-plugins", "1")
        settings.CefCommandLineArgs.Add("disable-web-security", "1")
        settings.CefCommandLineArgs.Add("enable-npapi", "1")
        settings.CefCommandLineArgs.Remove("enable-system-flash")
        settings.CefCommandLineArgs.Add("enable-system-flash", "1")
        settings.CefCommandLineArgs.Add("clang_use_chrome_plugins", "False")
        settings.CefCommandLineArgs.Add("ignore-certificate-errors", String.Empty)

        ' settings.CefCommandLineArgs.Add("disable-web-security")
        CefSharp.Cef.Initialize(settings, performDependencyCheck:=True, browserProcessHandler:=Nothing)
        ' CefSharp.Cef.Initialize(settings)

        WhatsAppThread = New Threading.Thread(AddressOf GetWhatsAppBadge)

        Me.CheckForIllegalCrossThreadCalls = False
        InitializeComponent()
    End Sub

#End Region
#Region " Declarations"
    Dim AppLoaded As Boolean = False
    Dim MainIcon As Icon = My.Resources.Jumble_Logo1
    Dim BadgeIcon As Icon = My.Resources.Jumble_Logo_Badges1
    Dim WhatsAppBadge As New Label
    Dim GmailBadge As New Label
    Dim MessagesBadge As New Label
    Public Shared GoogleAcoount As Integer = 0

    Public Shared web_Shared As ChromiumWebBrowser
    Dim web_WhatsApp As ChromiumWebBrowser
    Dim web_Messages As ChromiumWebBrowser
    Dim web_Gmail As ChromiumWebBrowser


    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal wMsg As Int32, ByVal wParam As Boolean, ByVal lParam As Int32) As Integer
    End Function
    Private Const WM_SETREDRAW As Integer = 11

    Public Shared Sub SuspendDrawing(ByVal parent As Control)
        SendMessage(parent.Handle, WM_SETREDRAW, False, 0)
    End Sub

    Public Shared Sub ResumeDrawing(ByVal parent As Control)
        SendMessage(parent.Handle, WM_SETREDRAW, True, 0)
        parent.Refresh()
    End Sub


    Function ParseDigits(ByVal strRawValue As String) As String
        Dim strDigits As String = ""
        If strRawValue = Nothing Then Return strDigits


        For Each c As Char In strRawValue.ToCharArray()
            If IsNumeric(c) Then
                strDigits &= c
            End If
        Next c


        ' return the number string, or "" if no numbers were in the string.
        Return strDigits
    End Function

#End Region

#Region " Snap to Screen Edges"
    Private Const SnapDist As Integer = 15
    Private Function DoSnap(ByVal pos As Integer, ByVal edge As Integer) As Boolean
        Dim delta As Integer = pos - edge
        Return delta > 0 AndAlso delta <= SnapDist
    End Function



    Public Sub WindowMoving()
        Dim scn As Screen = Screen.FromPoint(Me.Location)
        If DoSnap(Me.Left, scn.WorkingArea.Left) Then Me.Left = scn.WorkingArea.Left
        If DoSnap(Me.Top, scn.WorkingArea.Top) Then Me.Top = scn.WorkingArea.Top
        If DoSnap(scn.WorkingArea.Right, Me.Right) Then Me.Left = scn.WorkingArea.Right - Me.Width
        If DoSnap(scn.WorkingArea.Bottom, Me.Bottom) Then Me.Top = scn.WorkingArea.Bottom - Me.Height
    End Sub

#End Region

#Region " Load / Close"
#Region " Declarations"
    Private WithEvents Download_Handler As New DownloadHandler
    Private WithEvents Request_Handler As New BrowserRequestHandler
    Private WithEvents Menu_Handler As New MyCustomMenuHandler
    Public DefaultColor As Color
    Public HoverColor As Color
    Public PressColor As Color
    Public ContextMenu1 As New ContextMenu
    Public but_show As New MenuItem
    Public but_Close As New MenuItem

#End Region

    Public Shared Property AllowRoundedWindowCorners As Boolean = True

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler Microsoft.Win32.SystemEvents.SessionEnding, AddressOf Handler_SessionEnding
        Try
            Select Case My.Settings.RoundedCorners
                Case True
                    WindowsFormsSettings.AllowRoundedWindowCorners = DevExpress.Utils.DefaultBoolean.True
                Case False
                    WindowsFormsSettings.AllowRoundedWindowCorners = DevExpress.Utils.DefaultBoolean.False
            End Select

        Catch ex As Exception

        End Try

        Me.CheckForIllegalCrossThreadCalls = False
        UserLookAndFeel.Default.SetSkinStyle(My.Settings.SkinName)
        ChangeSkin()

        If My.Settings.Icon1URL = "about:blank" Then
            CustomizeForm.ShowDialog()
        End If
        Setup_Images()
        Me.Location = My.Settings.location
        Me.Size = My.Settings.size
        web_Shared = web_1

        web_1.DownloadHandler = Download_Handler
        web_2.DownloadHandler = Download_Handler
        web_4.DownloadHandler = Download_Handler
        web_5.DownloadHandler = Download_Handler
        web_7.DownloadHandler = Download_Handler
        web_6.DownloadHandler = Download_Handler
        web_3.DownloadHandler = Download_Handler
        web_Calendar.DownloadHandler = Download_Handler
        web_Drive.DownloadHandler = Download_Handler
        web_Google.DownloadHandler = Download_Handler
        web_Instagram.DownloadHandler = Download_Handler
        web_Facebook.DownloadHandler = Download_Handler
        web_Life360.DownloadHandler = Download_Handler


        web_1.MenuHandler = Menu_Handler
        web_2.MenuHandler = Menu_Handler
        web_4.MenuHandler = Menu_Handler
        web_5.MenuHandler = Menu_Handler
        web_7.MenuHandler = Menu_Handler
        web_6.MenuHandler = Menu_Handler
        web_3.MenuHandler = Menu_Handler
        web_Calendar.MenuHandler = Menu_Handler
        web_Drive.MenuHandler = Menu_Handler
        web_Google.MenuHandler = Menu_Handler
        web_Instagram.MenuHandler = Menu_Handler
        web_Facebook.MenuHandler = Menu_Handler
        web_Life360.MenuHandler = Menu_Handler

        If Not My.Settings.Icon1URL.Contains("google") And Not My.Settings.Icon1URL.Contains("dropbox") Then
            web_1.RequestHandler = Request_Handler
        ElseIf My.Settings.Icon2URL.Contains("messages") Then
            web_2.RequestHandler = Request_Handler
        End If
        If Not My.Settings.Icon2URL.Contains("google") And Not My.Settings.Icon2URL.Contains("dropbox") Then
            web_2.RequestHandler = Request_Handler
        ElseIf My.Settings.Icon2URL.Contains("messages") Then
            web_2.RequestHandler = Request_Handler
        End If
        If Not My.Settings.Icon3URL.Contains("google") And Not My.Settings.Icon3URL.Contains("dropbox") Then
            web_3.RequestHandler = Request_Handler
        ElseIf My.Settings.Icon3URL.Contains("messages") Then
            web_3.RequestHandler = Request_Handler
        End If
        If Not My.Settings.Icon4URL.Contains("google") And Not My.Settings.Icon4URL.Contains("dropbox") Then
            web_4.RequestHandler = Request_Handler '   web_Midweek.RequestHandler = Request_Handler
        ElseIf My.Settings.Icon4URL.Contains("messages") Then
            web_4.RequestHandler = Request_Handler
        End If
        If Not My.Settings.Icon5URL.Contains("google") And Not My.Settings.Icon5URL.Contains("dropbox") Then
            web_5.RequestHandler = Request_Handler '   web_Weekend.RequestHandler = Request_Handler
        ElseIf My.Settings.Icon5URL.Contains("messages") Then
            web_5.RequestHandler = Request_Handler
        End If
        If Not My.Settings.Icon6URL.Contains("google") And Not My.Settings.Icon6URL.Contains("dropbox") Then
            web_6.RequestHandler = Request_Handler  '   web_Dropbox.RequestHandler = Request_Handler
        ElseIf My.Settings.Icon6URL.Contains("messages") Then
            web_6.RequestHandler = Request_Handler
        End If
        If Not My.Settings.Icon7URL.Contains("google") And Not My.Settings.Icon7URL.Contains("dropbox") Then
            web_7.RequestHandler = Request_Handler '   web_Schedule.RequestHandler = Request_Handler
        ElseIf My.Settings.Icon7URL.Contains("messages") Then
            web_7.RequestHandler = Request_Handler
        End If
        ' web_Calendar.RequestHandler = Request_Handler
        web_Drive.RequestHandler = Request_Handler
        web_Google.RequestHandler = Request_Handler
        web_Instagram.RequestHandler = Request_Handler
        web_Facebook.RequestHandler = Request_Handler
        ' web_Life360.RequestHandler = Request_Handler

        LoadURLS()

        If My.Settings.LoadInstagram Then
            web_Instagram.Load("instagram.com")
        End If
        If My.Settings.LoadFacebook Then
            web_Facebook.Load("facebook.com")
        End If
        If My.Settings.LoadLife360 Then
            web_Life360.Load("https://www.life360.com/circles/#/map")
        End If

        AddHandler web_Shared.FrameLoadEnd, AddressOf web_1_FrameLoadEnd

        LoadGoogle()

        SetupBadges()

        SetupToolTips()
        TrayIcon.Visible = True
        AddHandler but_show.Click, AddressOf TrayIcon_MouseDoubleClick
        AddHandler but_Close.Click, AddressOf but_Close_Click
        but_show.Text = "Show Jumble"
        but_Close.Text = "Close"
        ContextMenu1.MenuItems.AddRange({but_show, but_Close})

        TrayIcon.ContextMenu = ContextMenu1

        AddHandler web_Shared.KeyDown, AddressOf web_Shared_KeyDown


        AppLoaded = True
    End Sub

    Public Sub web_Shared_KeyDown(sender As Object, e As KeyEventArgs)
        e.SuppressKeyPress = True
        e.Handled = True
    End Sub
    Private Sub Panel_main_KeyDown(sender As Object, e As KeyEventArgs) Handles Panel_main.KeyDown
        e.SuppressKeyPress = True
        e.Handled = True
    End Sub
    Public Sub ChangeSkin()

        timer_SkinChange.Start()
    End Sub
    Dim ColorWheelShown As Boolean = False
    Private Sub timer_SkinChange_Tick(sender As Object, e As EventArgs) Handles timer_SkinChange.Tick
        Try
            Select Case My.Settings.RoundedCorners
                Case True
                    WindowsFormsSettings.AllowRoundedWindowCorners = DevExpress.Utils.DefaultBoolean.True
                Case False
                    WindowsFormsSettings.AllowRoundedWindowCorners = DevExpress.Utils.DefaultBoolean.False
            End Select


        Catch ex As Exception

        End Try



        DefaultColor = DevExpress.Skins.CommonSkins.GetSkin(UserLookAndFeel.Default.ActiveLookAndFeel).Colors.GetColor(DevExpress.Skins.CommonColors.Control)
        If UserLookAndFeel.Default.ActiveLookAndFeel.ActiveSkinName = "The Bezier" Then
            DefaultColor = Color.FromArgb(71, 71, 71)

        End If


        Dim R_hover As Integer = DefaultColor.R + 20
        Dim G_hover As Integer = DefaultColor.G + 20
        Dim B_hover As Integer = DefaultColor.B + 20

        Dim R_press As Integer = DefaultColor.R - 20
        Dim G_press As Integer = DefaultColor.G - 20
        Dim B_press As Integer = DefaultColor.B - 20
        If DefaultColor.R + 20 >= 255 Then
            R_hover = 230
            R_press = 210
        Else
            If DefaultColor.R - 20 <= 0 Then
                R_press = 0
            End If
        End If
        If DefaultColor.G + 20 >= 255 Then
            G_hover = 230
            G_press = 210
        Else
            If DefaultColor.G - 20 <= 0 Then
                G_press = 0
            End If
        End If
        If DefaultColor.B + 20 >= 255 Then
            B_hover = 230
            B_press = 210
        Else
            If DefaultColor.B - 20 <= 0 Then
                B_press = 0
            End If
        End If





        HoverColor = Color.FromArgb(R_hover, G_hover, B_hover)
        PressColor = Color.FromArgb(R_press, G_press, B_press)
        panel_Apps.BackColor = DefaultColor
        panel_NavButtons.BackColor = DefaultColor
        Try
            Form_More.BackColor = DefaultColor
        Catch ex As Exception

        End Try
        timer_SkinChange.Stop()
    End Sub

    Public Sub Handler_SessionEnding(ByVal sender As Object, ByVal e As Microsoft.Win32.SessionEndingEventArgs)
        Try
            DoFormClosing()
        Catch ex As Exception
            Application.Exit()
            Application.ExitThread()
        End Try


        If e.Reason = Microsoft.Win32.SessionEndReasons.Logoff Then
            '  MessageBox.Show("User is logging off")
        ElseIf e.Reason = Microsoft.Win32.SessionEndReasons.SystemShutdown Then
            ' MessageBox.Show("System is shutting down")
        End If
        Application.Exit()
        Application.ExitThread()
    End Sub
    Dim FormIsClosing As Boolean = False
    Public Sub DoFormClosing()

        FormIsClosing = True
        timer_WhatsApp.Stop()
        'web_1.GetBrowser.CloseBrowser(True)
        'Timer_shutdown.Start()
        CefSharp.Cef.ShutdownWithoutChecks()


        My.Settings.location = Me.Location
        My.Settings.size = Me.Size
        My.Settings.SkinName = UserLookAndFeel.Default.SkinName
        My.Settings.Save()

        My.Settings.Save()
        CefSharp.Cef.Shutdown()
        Application.Exit()
        Application.ExitThread()

        Application.Exit()
        Application.ExitThread()
    End Sub
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        DoFormClosing()
    End Sub
    Private Sub Timer_shutdown_Tick(sender As Object, e As EventArgs) Handles Timer_shutdown.Tick
        Application.Exit()
        Application.ExitThread()
    End Sub

    Dim xformNavButtons As New Form()

    Private Sub Form1_Move(sender As Object, e As EventArgs) Handles Me.Move
        '  xformNavButtons.Location = New Point(Me.Location.X + 400, Me.Location.Y + 5)
        If Me.WindowState = FormWindowState.Normal Then
            xformNavButtons.Location = New Point(Me.Location.X + 80, Me.Location.Y + 5)

        ElseIf Me.WindowState = FormWindowState.Maximized Then
            xformNavButtons.Location = New Point(Me.Location.X + 89, Me.Location.Y + 10)

        End If

        WindowMoving()
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        web_Shared.Focus()
    End Sub

    Public Sub LoadURLS()

        If Not My.Settings.Icon1URL.Contains("google") Then
            web_1.Load(My.Settings.Icon1URL)
        Else
            web_1.Load(newURL(My.Settings.Icon1URL))
        End If

        If My.Settings.Icon2Load Then
            If Not My.Settings.Icon2URL.Contains("google") Then
                web_2.Load(My.Settings.Icon2URL)
            Else
                web_2.Load(newURL(My.Settings.Icon2URL))
            End If
        End If


        If My.Settings.Icon3Load Then
            If Not My.Settings.Icon3URL.Contains("google") Then
                web_3.Load(My.Settings.Icon3URL)
            Else
                web_3.Load(newURL(My.Settings.Icon3URL))
            End If
        End If


        If My.Settings.Icon4Load Then
            If Not My.Settings.Icon4URL.Contains("google") Then
                web_4.Load(My.Settings.Icon4URL)
            Else
                web_4.Load(newURL(My.Settings.Icon4URL))
            End If
        End If


        If My.Settings.Icon5Load Then
            If Not My.Settings.Icon5URL.Contains("google") Then
                web_5.Load(My.Settings.Icon5URL)
            Else
                web_5.Load(newURL(My.Settings.Icon5URL))
            End If
        End If


        If My.Settings.Icon6Load Then
            If Not My.Settings.Icon6URL.Contains("google") Then
                web_6.Load(My.Settings.Icon6URL)
            Else
                web_6.Load(newURL(My.Settings.Icon6URL))
            End If
        End If


        If My.Settings.Icon7Load Then
            If Not My.Settings.Icon7URL.Contains("google") Then
                web_7.Load(My.Settings.Icon7URL)
            Else
                web_7.Load(newURL(My.Settings.Icon7URL))
            End If
        End If


    End Sub
    Public Function newURL(str) As String
        str = str.Replace("/u/0", "/u/" & GoogleAcoount).Replace("/u/1", "/u/" & GoogleAcoount)

        Return str
    End Function

    Public Sub Setup_Images()
        If My.Settings.Icon1Image = "" Then
            My.Settings.Icon1Image = Application.StartupPath & "\Icons\Icon1.png"
        End If
        but_Icon1.BackgroundImage = Image.FromFile(My.Settings.Icon1Image)

        If My.Settings.Icon2Image = "" Then
            My.Settings.Icon2Image = Application.StartupPath & "\Icons\Icon2.png"
        End If
        but_Icon2.BackgroundImage = Image.FromFile(My.Settings.Icon2Image)

        If My.Settings.Icon3Image = "" Then
            My.Settings.Icon3Image = Application.StartupPath & "\Icons\Icon3.png"
        End If
        but_Icon3.BackgroundImage = Image.FromFile(My.Settings.Icon3Image)

        If My.Settings.Icon4Image = "" Then
            My.Settings.Icon4Image = Application.StartupPath & "\Icons\Icon4.png"
        End If
        but_Icon4.BackgroundImage = Image.FromFile(My.Settings.Icon4Image)

        If My.Settings.Icon5Image = "" Then
            My.Settings.Icon5Image = Application.StartupPath & "\Icons\Icon5.png"
        End If
        but_Icon5.BackgroundImage = Image.FromFile(My.Settings.Icon5Image)

        If My.Settings.Icon6Image = "" Then
            My.Settings.Icon6Image = Application.StartupPath & "\Icons\Icon6.png"
        End If
        but_Icon6.BackgroundImage = Image.FromFile(My.Settings.Icon6Image)

        If My.Settings.Icon7Image = "" Then
            My.Settings.Icon7Image = Application.StartupPath & "\Icons\Icon7.png"
        End If
        but_Icon7.BackgroundImage = Image.FromFile(My.Settings.Icon7Image)
    End Sub

    Public Sub SetupToolTips()
        ToolTip1.SetToolTip(but_Icon1, My.Settings.Icon1Name)
        ToolTip1.SetToolTip(but_Icon2, My.Settings.Icon2Name)
        ToolTip1.SetToolTip(but_Icon3, My.Settings.Icon3Name)
        ToolTip1.SetToolTip(but_Icon4, My.Settings.Icon4Name)
        ToolTip1.SetToolTip(but_Icon5, My.Settings.Icon5Name)
        ToolTip1.SetToolTip(but_Icon6, My.Settings.Icon6Name)
        ToolTip1.SetToolTip(but_Icon7, My.Settings.Icon7Name)

    End Sub

    Public Sub SetupBadges()
        SetupWhatsApp()
        SetupGmail()
        SetupMessages()
    End Sub
    Public Sub SetupWhatsApp()

        Dim webNum As Integer
        Dim but_WhatsAppIcon As PictureBox
        Dim web As ChromiumWebBrowser
        ' MsgBox(but_Icon1.Parent.Name)
        For Each c As Control In Panel_main.Controls
            If c.GetType Is GetType(ChromiumWebBrowser) Then
                web = c
                If web.Address <> "" And web.Address <> String.Empty And web.Address <> Nothing Then
                    If web.Address.Contains("whatsapp") Then
                        webNum = CInt(ParseDigits(web.Name))
                        web_WhatsApp = web
                    End If
                End If
            End If
        Next
        Dim pic As PictureBox

        For Each c As Control In panel_Apps.Controls
            If c.GetType Is GetType(PictureBox) Then
                pic = c
                ' MsgBox(c.Name.ToString)
                If pic.Name.Contains("but_") And pic.Name.Contains(webNum) Then
                    but_WhatsAppIcon = pic
                End If
            End If
        Next
        Try
            but_WhatsAppIcon.Controls.Add(WhatsAppBadge)
            'but_Icon1.Controls.Add(WhatsAppBadge)

        Catch ex As Exception
            Return
        End Try

        'GetWhatsAppCode()

        Dim path = New System.Drawing.Drawing2D.GraphicsPath()
        Me.WhatsAppBadge.MaximumSize = New System.Drawing.Size(19, 19)
        Me.WhatsAppBadge.MinimumSize = New System.Drawing.Size(19, 19)
        path.AddEllipse(0, 0, WhatsAppBadge.Width, WhatsAppBadge.Height)

        WhatsAppBadge.Region = New Region(path)

        Me.WhatsAppBadge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.WhatsAppBadge.AutoSize = True
        Me.WhatsAppBadge.BackColor = System.Drawing.Color.Red 'FromArgb(34, 177, 76)
        ' Me.WhatsAppBadge.MaximumSize = New System.Drawing.Size(19, 13)
        ' Me.WhatsAppBadge.MinimumSize = New System.Drawing.Size(19, 13)
        Me.WhatsAppBadge.Size = New System.Drawing.Size(19, 13)
        WhatsAppBadge.Location = New Point(25, 0)
        Me.WhatsAppBadge.Text = "1"
        Me.WhatsAppBadge.Font = New Font(WhatsAppBadge.Font.FontFamily, WhatsAppBadge.Font.Size, FontStyle.Bold)
        Me.WhatsAppBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.WhatsAppBadge.Visible = False

        AddHandler WhatsAppBadge.VisibleChanged, AddressOf label_MsgBadge_VisibleChanged
    End Sub
    Public Sub SetupGmail()

        Dim webNum As Integer
        Dim but_GmailIcon As PictureBox
        Dim web As ChromiumWebBrowser
        For Each c As Control In Panel_main.Controls
            If c.GetType Is GetType(ChromiumWebBrowser) Then
                web = c
                If web.Address <> "" And web.Address <> String.Empty And web.Address <> Nothing Then
                    If web.Address.Contains("mail") Then
                        webNum = CInt(ParseDigits(web.Name))
                        web_Gmail = web
                    End If
                End If
            End If
        Next
        Dim pic As PictureBox
        For Each c As Control In panel_Apps.Controls
            If c.GetType Is GetType(PictureBox) Then
                pic = c
                If pic.Name.Contains("but_") And pic.Name.Contains(webNum) Then
                    but_GmailIcon = pic
                End If
            End If
        Next
        Try
            but_GmailIcon.Controls.Add(GmailBadge)
        Catch ex As Exception
            Return
        End Try

        Dim path = New System.Drawing.Drawing2D.GraphicsPath()
        Me.GmailBadge.MaximumSize = New System.Drawing.Size(19, 19)
        Me.GmailBadge.MinimumSize = New System.Drawing.Size(19, 19)
        path.AddEllipse(0, 0, GmailBadge.Width, GmailBadge.Height)

        GmailBadge.Region = New Region(path)
        'but_Icon3.Controls.Add(GmailBadge)
        Me.GmailBadge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GmailBadge.AutoSize = True
        Me.GmailBadge.BackColor = System.Drawing.Color.Red 'FromArgb(34, 177, 76)
        ' Me.GmailBadge.MaximumSize = New System.Drawing.Size(19, 13)
        ' Me.GmailBadge.MinimumSize = New System.Drawing.Size(19, 13)
        Me.GmailBadge.Size = New System.Drawing.Size(19, 13)

        GmailBadge.Location = New Point(25, 0)
        Me.GmailBadge.Font = New Font(GmailBadge.Font.FontFamily, GmailBadge.Font.Size, FontStyle.Bold)
        Me.GmailBadge.Text = "1"
        Me.GmailBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.GmailBadge.Visible = False

        AddHandler GmailBadge.VisibleChanged, AddressOf label_MsgBadge_VisibleChanged
    End Sub
    Public Sub SetupMessages()
        Dim webNum As Integer
        Dim but_MessagesIcon As PictureBox
        Dim web As ChromiumWebBrowser
        For Each c As Control In Panel_main.Controls
            If c.GetType Is GetType(ChromiumWebBrowser) Then
                web = c
                If web.Address <> "" And web.Address <> String.Empty And web.Address <> Nothing Then
                    If web.Address.Contains("messages") Then
                        webNum = CInt(ParseDigits(web.Name))
                        web_Messages = web
                    End If
                End If
            End If

        Next
        Dim pic As PictureBox
        For Each c As Control In panel_Apps.Controls
            If c.GetType Is GetType(PictureBox) Then
                pic = c
                If pic.Name.Contains("but_") And pic.Name.Contains(webNum) Then
                    but_MessagesIcon = pic
                End If
            End If
        Next

        Try
            but_MessagesIcon.Controls.Add(MessagesBadge)
        Catch ex As Exception
            Return
        End Try

        Dim path = New System.Drawing.Drawing2D.GraphicsPath()
        Me.MessagesBadge.MaximumSize = New System.Drawing.Size(19, 19)
        Me.MessagesBadge.MinimumSize = New System.Drawing.Size(19, 19)
        path.AddEllipse(0, 0, MessagesBadge.Width, MessagesBadge.Height)


        MessagesBadge.Region = New Region(path)
        '   but_Icon2.Controls.Add(MessagesBadge)
        Me.MessagesBadge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MessagesBadge.AutoSize = True
        Me.MessagesBadge.BackColor = System.Drawing.Color.Red 'FromArgb(34, 177, 76)
        '  Me.MessagesBadge.MaximumSize = New System.Drawing.Size(19, 13)
        '  Me.MessagesBadge.MinimumSize = New System.Drawing.Size(19, 13)
        Me.MessagesBadge.Size = New System.Drawing.Size(19, 13)
        MessagesBadge.Location = New Point(25, 0)
        Me.MessagesBadge.Font = New Font(MessagesBadge.Font.FontFamily, MessagesBadge.Font.Size, FontStyle.Bold)
        Me.MessagesBadge.Text = "1"
        Me.MessagesBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MessagesBadge.Visible = False

        AddHandler MessagesBadge.VisibleChanged, AddressOf label_MsgBadge_VisibleChanged
    End Sub


#End Region

#Region " Load Google Account"
    Public Sub LoadGoogle()

        If My.Settings.LoadCalendar Then
            web_Calendar.Load("https://calendar.google.com/calendar/u/" & GoogleAcoount & "/r")
        End If
        web_Drive.Load("https://drive.google.com/drive/u/" & GoogleAcoount & "/starred")
        If My.Settings.LoadGoogle Then
            web_Google.Load("https://google.com/")
        End If
        If web_Shared.Address.Contains("google") Or web_Shared.Address.Contains("gmail") Then
            If web_Shared.Address.Contains("document") Then
                'MsgBox(Net.WebUtility.UrlEncode(web_Shared.Address))
                Select Case GoogleAcoount
                    Case 0
                        web_Shared.Load(web_Shared.Address.Replace("/edit", "") & "/?authuser=mail.google.com/u/" & GoogleAcoount)
                    Case 1
                        web_Shared.Load(web_Shared.Address.Replace("/edit", "") & "/?authuser=pittsburghslc@gmail.com")

                End Select

                ' web_Shared.Load("https://accounts.google.com/AccountChooser/signinchooser?hl=en&continue=" & Net.WebUtility.UrlEncode(web_Shared.Address) & "%3Faaac%3Dtrue&faa=1&flowName=GlifWebSignIn&flowEntry=AccountChooser")

            ElseIf web_Shared.Address.Contains("spreadsheet") Then
                Select Case GoogleAcoount
                    Case 0
                        web_Shared.Load(web_Shared.Address.Replace("/edit#gid=0", "") & "/?authuser=mail.google.com/u/" & GoogleAcoount)
                    Case 1
                        web_Shared.Load(web_Shared.Address.Replace("/edit#gid=0", "") & "/?authuser=pittsburghslc@gmail.com")

                End Select

            Else
                web_Shared.Load(newURL(web_Shared.Address))
            End If

        End If
        IsGoogle()
    End Sub
    Public Sub IsGoogle()
        Try
            If web_Shared.Address.Contains("google") Or web_Shared.Address.Contains("gmail") Then
                but_Strikethrough.Visible = True
                but_removeformatting.Visible = True
                gmail_1.Visible = True
                gmail_2.Visible = True
            Else
                but_Strikethrough.Visible = False
                but_removeformatting.Visible = False
                gmail_1.Visible = False
                gmail_2.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub web_1_FrameLoadEnd(sender As Object, e As FrameLoadEndEventArgs)

        IsGoogle()
        CefSharp.Cef.AddCrossOriginWhitelistEntry("http://app.slack.com", "test", "", True)
        CefSharp.Cef.AddCrossOriginWhitelistEntry("http://gmail.com", "test", "", True)

    End Sub
#Region " Google Account Buttons"
    Private Sub gmail_1_Click(sender As Object, e As EventArgs) Handles gmail_1.Click
        GoogleAcoount = 0
        LoadGoogle()

        ' web_Gmail.Load("https://mail.google.com/mail/u/0/")
    End Sub

    Private Sub gmail_2_Click(sender As Object, e As EventArgs) Handles gmail_2.Click
        GoogleAcoount = 1
        'MsgBox(web_Shared.Address)
        LoadGoogle()
        '  web_Gmail.Load("https://mail.google.com/mail/u/1/")
    End Sub


#End Region


#End Region

#Region " Button Clicks & Right Click Menu"

#Region " Right Click"
    Dim CurrentURL As String
    Private Sub but_Icon3_MouseClick(sender As Object, e As MouseEventArgs) Handles but_Icon1.MouseClick, but_Icon5.MouseClick, but_Icon7.MouseClick, but_Icon4.MouseClick,
        but_Icon2.MouseClick, but_Icon3.MouseClick, but_Icon6.MouseClick

        Dim URL As String = CurrentURL
        If e.Button = MouseButtons.Right Then
            Select Case sender.Name
                Case "but_Icon1"
                    URL = My.Settings.Icon1URL

                Case "but_Icon2"
                    URL = My.Settings.Icon2URL

                Case "but_Icon3"
                    URL = My.Settings.Icon3URL

                Case "but_Icon4"
                    URL = My.Settings.Icon4URL

                Case "but_Icon5"
                    URL = My.Settings.Icon5URL

                Case "but_Icon6"
                    URL = My.Settings.Icon6URL

                Case "but_Icon7"
                    URL = My.Settings.Icon7URL

            End Select

            CurrentURL = URL
            RtClickMenu.ShowPopup(MousePosition)




            Return
        End If
    End Sub

    Private Sub menubut_NewWindow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles menubut_NewWindow.ItemClick
        System.Diagnostics.Process.Start(CurrentURL)
    End Sub
    Private Sub menubut_NewWindowCurrent_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles menubut_NewWindowCurrent.ItemClick
        System.Diagnostics.Process.Start(web_Shared.Address.ToString)
    End Sub

    Private Sub menubut_CopyURL_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles menubut_CopyURL.ItemClick
        Clipboard.SetText(web_Shared.Address.ToString)
        MsgBox("Copied: " & web_Shared.Address.ToString)
    End Sub

    Private Sub menubut_NewURL_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles menubut_NewURL.ItemClick
        Dim Message, Title, MyValue As String
        Message = "Enter new URL"    ' Set prompt.
        Title = "Enter new URL"    ' Set title.

        ' Display message, title, and default value.
        MyValue = InputBox(Message, Title, web_Shared.Address)

        web_Shared.Load(MyValue)

    End Sub
#End Region




    Public Sub ButtonClicks(sender As Object, e As EventArgs) Handles but_Icon1.Click, but_Icon5.Click, but_Icon7.Click, but_Icon4.Click, but_Icon2.Click, but_Icon3.Click, but_Icon6.Click

        '    web_Shared = sender
        SuspendDrawing(Me)

        'panel_NavButtons.BringToFront()

        '  panel_NavButtons.BringToFront()

        ' Dim PageScroll As Point
        Select Case sender.Name
            Case "but_Icon1"
                If web_1.Address = Nothing Or web_1.Address = "" Then
                    web_1.Load(newURL(My.Settings.Icon1URL))
                End If
                web_Shared = web_1

            Case "but_Icon2"
                If web_2.Address = Nothing Or web_2.Address = "" Then
                    web_2.Load(newURL(My.Settings.Icon2URL))
                End If
                web_Shared = web_2

            Case "but_Icon3"
                If web_3.Address = Nothing Or web_3.Address = "" Then
                    web_3.Load(newURL(My.Settings.Icon3URL))
                End If
                web_Shared = web_3
            Case "but_Icon4"

                If web_4.Address = Nothing Or web_4.Address = "" Then
                    web_4.Load(newURL(My.Settings.Icon4URL))
                End If
                web_Shared = web_4
            Case "but_Icon5"
                If web_5.Address = Nothing Or web_5.Address = "" Then
                    web_5.Load(newURL(My.Settings.Icon5URL))
                End If
                web_Shared = web_5
            Case "but_Icon6"
                If web_6.Address = Nothing Or web_6.Address = "" Then
                    web_6.Load(newURL(My.Settings.Icon6URL))
                End If
                web_Shared = web_6
            Case "but_Icon7"
                If web_7.Address = Nothing Or web_7.Address = "" Then
                    web_7.Load(newURL(My.Settings.Icon7URL))
                End If
                web_Shared = web_7

            Case "but_Calendar"

            Case "but_Drive"

            Case "but_Google"

            Case "but_Instagram"

            Case "but_Facebook"

            Case "but_Life360"

        End Select

        IsGoogle()
        '  panel_NavButtons.BringToFront()
        ' panel_NavButtons.BringToFront()
        ' Timer1.Interval = 400
        'Timer1.Start()
        ' SuspendDrawing(Me)
        Try
            Signal_form.SendToBack()
        Catch ex As Exception

        End Try

        web_Shared.BringToFront()
        web_Shared.Focus()


        timer_WhatsApp.Start()

        ResumeDrawing(Me)
    End Sub



    Private Sub but_More_Click(sender As Object, e As EventArgs) Handles but_More.Click
        Dim xform = Form_More

        If Application.OpenForms.OfType(Of Form).Contains(xform) Then Return

        xform.Show()
        xform.Size = New Size(50, 450)
        xform.Location = New Point(Me.Location.X + but_More.Width + 15, (Me.Location.Y + but_More.Location.Y) - (xform.Height) + (but_More.Height) + 28)
        xform.BringToFront()

    End Sub

    Private Sub but_Strikethrough_Click(sender As Object, e As EventArgs) Handles but_Strikethrough.Click
        Try
            web_Shared.Focus()
            SendKeys.Send("%+5")
        Catch ex As Exception
            web_Shared.BringToFront()
            web_Shared.Focus()
            SendKeys.Send("%+5")
        End Try

    End Sub

    Private Sub but_removeformatting_Click(sender As Object, e As EventArgs) Handles but_removeformatting.Click
        Try
            web_Shared.Focus()
            SendKeys.Send("^\")
        Catch ex As Exception
            web_Shared.BringToFront()
            web_Shared.Focus()
            SendKeys.Send("^\")
        End Try
    End Sub


    Private Sub but_Settings_Click(sender As Object, e As EventArgs) Handles but_Settings.Click
        but_Settings.BackColor = Color.FromArgb(64, 64, 64)
        FormSettings.StartPosition = FormStartPosition.CenterParent
        FormSettings.ShowDialog()
        FormSettings.StartPosition = FormStartPosition.CenterParent



    End Sub


    Private Sub but_Customize_Click(sender As Object, e As EventArgs) Handles but_Customize.Click
        ColorWheelShown = False
        but_Customize.BackColor = Color.FromArgb(64, 64, 64)

        Dim xform As New CustomizeForm
        xform.StartPosition = FormStartPosition.CenterParent
        If xform.ShowDialog = DialogResult.OK Then
            LoadURLS()

            Setup_Images()
            'System.Threading.Thread.Sleep(3000)
            ' Try
            ' Dim web As New ChromiumWebBrowser
            ' Do While web.IsLoading = False
            ' For Each c As Control In Panel_main.Controls
            ' If c.GetType Is GetType(ChromiumWebBrowser) Then
            ' Web = c
            '
            '        End If
            '           Next
            ''                Loop'

            '           Catch ex As Exception

            '           End Try
            '
            SetupToolTips()
            SetupBadges()

            but_Customize.BackColor = Color.FromArgb(64, 64, 64)
        End If
        but_Customize.BackColor = Color.FromArgb(64, 64, 64)
        hover = False
    End Sub




#End Region
#Region " Navigation Buttons"

    Private Sub but_back_Click(sender As Object, e As EventArgs) Handles but_back.Click
        web_Shared.GetBrowser.GoBack()
    End Sub

    Private Sub but_Forward_Click(sender As Object, e As EventArgs) Handles but_Forward.Click
        web_Shared.GetBrowser.GoForward()
    End Sub

    Private Sub but_Reload_Click(sender As Object, e As EventArgs) Handles but_Reload.Click
        web_Shared.GetBrowser.Reload()
    End Sub

#End Region

#Region " Notifications"

#Region " Declarations"

    Dim NotificationType As String = "WhatsApp"
    Dim GmailCount As Integer = 0

    Dim WhatsAppNotificationMsg As String
    Dim WhatsAppCurrentBadge As Integer = 0
    Dim WhatsAppNotified As Boolean = False
    Dim MessagesNotificationMsg As String
    Dim MessagesCurrentBadge As Integer = 0
    Dim MessagesNotified As Boolean = False
    Dim MSGlist_notified As New List(Of String)
    Dim webMSGlist_notified As New List(Of String)

#End Region

#Region " WhatsApp"
    Dim ReadingCode As Boolean = False
    ' Dim IsTyping As Boolean = False
    Private Sub timer_WhatsApp_Tick(sender As Object, e As EventArgs) Handles timer_WhatsApp.Tick
        If FormIsClosing Then Return
        Try
            If web_WhatsApp.CanExecuteJavascriptInMainFrame = False Then
                SetupWhatsApp()
                ' Return
            End If
        Catch ex As Exception

        End Try

        Try
            'Dim thread As New Threading.Thread(AddressOf GetWhatsAppBadge)
            ' WhatsAppThread.Start()
            ' WhatsAppThread.Join()
            GetWhatsAppBadge()
        Catch ex As Exception
            ReadingCode = False
            Try
                SetupWhatsApp()
                '  timer_WhatsApp.Stop()
                timer_WhatsApp.Start()
            Catch

            End Try
        End Try

        Try
            GetGmailBadge()
        Catch ex As Exception

        End Try

        Try
            GetMessagesBadge()
        Catch ex As Exception

        End Try


    End Sub



    'IMPORTANT CODE!!!!!!!!!!!!!!!!!!!!!!!!
    Public Sub GetWhatsAppCode(ByVal restart As Boolean)
        If FormIsClosing Then Return



        ' Get Counter
        Dim str As String
        Dim ReadHTML = web_WhatsApp.EvaluateScriptAsync("(function() {  var x = document.body.innerHTML; return x; })();")
        Dim response = ReadHTML.Result
        str = response.Result.ToString
        Dim myMatches As MatchCollection : Dim myPattern As New Regex("unread message") : myMatches = myPattern.Matches(str)

        If restart Then
            _Counter = 0
        End If


        ' Message Count
        Dim successfulMatch As Match
        For Each successfulMatch In myMatches
            Dim strstart As Integer = InStrRev(str, """ aria-label=""", successfulMatch.Index)  ' InStrRev(str, "<span class=""", successfulMatch.Index) ' 12/16/2021
            Dim strend As Integer = InStrRev(str, """ aria-label=""", successfulMatch.Index) + 29 ' 12/16/2021
            CounterCode = str.Substring(strstart, strend - strstart) '.Replace("<span class=""", "").Replace(""" aria-label=""", "").Replace("<", "").Replace("""", "")                 .Replace("span class=", "")
            '            MsgBox(CounterCode)
            Dim finalstr As String = str.Substring(successfulMatch.Index + 5, 20)

            finalstr = finalstr.Replace(CounterCode, "") : finalstr = Regex.Replace(finalstr, "[^\r\n0-9]", "")
            ' MsgBox(finalstr)
            If finalstr <> "" And finalstr <> Nothing Then  ' finalstr <> "1" And
                _Counter += CInt(finalstr) '- 1
            End If
        Next

        ' Message
        Try
            Dim msgstart As Integer = InStrRev(str, "<span dir=""ltr"" class=""", successfulMatch.Index)
            'Dim msgend As Integer = InStrRev(str.Substring(msgstart, 20), """>", str.Substring(msgstart, 20).Count) + msgstart + 50
            Dim msgend As Integer = InStrRev(str, """>", msgstart + 55) + 1

            MsgStartCode = str.Substring(msgstart, msgend - msgstart).Replace("span dir=""ltr"" ", "").Replace("</span><", "").Replace("</span>", "")
            ' MsgBox(MsgStartCode)
        Catch ex As Exception
        End Try

        ' Sender / Who
        Try
            Dim whostart As Integer = InStrRev(str, WhoStartCode, successfulMatch.Index)
            '   Dim whostart2 As Integer = InStrRev(str, """ class=""", whostart + 50)
            Dim whoend As Integer = InStrRev(str, """>", whostart + 90) + 1
            Dim whostart2 As Integer = InStrRev(str, """ class=""", whoend) - 1
            WhoEndCode = str.Substring(whostart2, whoend - whostart2)
            ' MsgBox(WhoEndCode)


        Catch ex As Exception

        End Try


    End Sub

    'IMPORTANT CODE!!!!!!!!!!!!!!!!!!!!!!!!
    '//////////////// New Code goes here!!!
    Public CounterCode As String = """ aria-label=""" ' "_38M1B"
    Public _Counter As Integer
    Public MsgStartCode As String = "" '"class=""_35k-1 _1adfa _3-8er"">"
    Public MsgEndCode As String = "</span></span>"
    Public WhoStartCode As String = "<span dir=""auto"" title=""" ' "<span class=""N2dUK""><span dir=""auto"" title="""
    Public WhoEndCode As String = ""  ' """ class=""_35k-1 _1adfa _3-8er"">"

    Dim x As Integer = 0
    Public Sub GetWhatsAppBadge()
        Try
            If FormIsClosing Then Return
            If ReadingCode Then Return
            timer_WhatsApp.Stop()
            ' If IsTyping Then Return
            ' timer_WhatsApp.Interval = 100
            Dim str As String
            Dim ReadHTML = web_WhatsApp.EvaluateScriptAsync("(function() {  var x = document.body.innerHTML; return x; })();")
            Dim response = ReadHTML.Result
            str = response.Result.ToString
            WhatsAppBadge.Visible = False
            If _Counter = 0 Then
                WhatsAppBadge.Visible = False
            End If
            'IMPORTANT CODE!!!!!!!!!!!!!!!!!!!!!!!!

            GetWhatsAppCode(True)


            If response.Success = True And response.Result.ToString <> Nothing Then

                If str.Contains(CounterCode) Then 'And Not str.Contains("typing") Then ' "_31gEB"
                    'ReadingCode = True

                    Dim myMatches As MatchCollection : Dim myPattern As New Regex(CounterCode) : Dim myString As String = str : myMatches = myPattern.Matches(myString)

                    ' Search for all the matches
                    Dim successfulMatch As Match : Dim counter As Integer = _Counter ' 0
                    Dim MSGlist_new As New List(Of String)
                    For Each successfulMatch In myMatches

                        ' counter += 1
                        If str.Contains("unread message") Then


                            ' 12-16-2021
                            'Dim finalstr As String = str.Substring(successfulMatch.Index + 5, 20)

                            'finalstr = finalstr.Replace(CounterCode, "") : finalstr = Regex.Replace(finalstr, "[^\r\n0-9]", "")
                            '' MsgBox(finalstr)
                            'If finalstr <> "1" And finalstr <> "" And finalstr <> Nothing Then
                            ' counter += CInt(finalstr) - 1
                            ' End If
                            '12-16-2021


                            If WhatsAppCurrentBadge <> counter Then
                                Try
                                    Dim msg As String '= "You have a new message." & counter
                                    Dim startstr As String = MsgStartCode '"<div class=""_3Tw1q""><span class=""_2iq-U"" title=""" ' "_3tBW6"
                                    Dim startwhostr As String = WhoStartCode '" class=""_3es8f""><span dir=""auto"" title=""" ' "_357i8"
                                    Dim who_start As Integer = InStrRev(str, startwhostr, successfulMatch.Index)
                                    Dim endstr As String = MsgEndCode ' """><span dir="""
                                    Dim msgStart As Integer = InStrRev(str, startstr, successfulMatch.Index)
                                    Dim msgEnd As Integer = InStrRev(str, endstr, successfulMatch.Index)
                                    Dim msgend2 As Integer = InStrRev(str, endstr, msgEnd)
                                    If msgend2 > (who_start + 43) Then
                                        msgEnd = msgend2
                                    End If
                                    ' Dim msg_orig As String = str.Substring(successfulMatch.Index - 3050, 3050)
                                    ' msg_orig = str
                                    msg = str.Substring(msgStart - 1, msgEnd - (msgStart)).Replace("&quot;", """").Replace("&amp;", "&").Replace(MsgStartCode, "")
                                    ' If Not str.Contains("typing") Then
                                    MSGlist_new.Add(msg)

                                    ' End If

                                Catch ex As Exception
                                End Try


                                If WhatsAppCurrentBadge > counter Then

                                    WhatsAppCurrentBadge = counter
                                    WhatsAppNotified = True

                                ElseIf WhatsAppCurrentBadge < counter Then
                                    If Not MSGlist_new.Count = 0 Then
                                        If Not MSGlist_notified.Contains(MSGlist_new.Item(MSGlist_new.Count - 1)) Then
                                            WhatsAppNotified = False
                                        End If
                                    End If

                                End If
                            Else
                                WhatsAppNotified = True
                            End If




                            If WhatsAppNotified = False Then
                                Dim who As String = "WhatsApp Message"
                                Dim msg As String = "You have a new message." & counter
                                WhatsAppCurrentBadge = counter
                                WhatsAppNotified = True
                                Try
                                    Dim who_start As Integer = InStrRev(str, WhoStartCode, successfulMatch.Index)
                                    Dim who_end2 As Integer = InStrRev(str, WhoEndCode, successfulMatch.Index)
                                    Dim who_end1 As Integer = InStrRev(str, WhoEndCode, who_end2)
                                    Dim who_end As Integer = who_end1
                                    Dim who_orig As String = str.Substring(successfulMatch.Index - 3050, 3050)
                                    who_orig = str

                                    who = who_orig.Substring(who_start - 1, who_end - (who_start)) _
                                    .Replace(WhoStartCode, "").Replace("&quot;", """").Replace("&amp;", "&")
                                    ' MsgBox("Who: " & who)

                                    Dim msgStart As Integer = InStrRev(str, MsgStartCode, successfulMatch.Index)
                                    Dim msgEnd As Integer = InStrRev(str, MsgEndCode, successfulMatch.Index)
                                    Dim msgend2 As Integer = InStrRev(str, MsgEndCode, msgEnd)
                                    If msgend2 > (who_start + 43) Then
                                        msgEnd = msgend2
                                    End If
                                    Dim msg_orig As String = str.Substring(successfulMatch.Index - 3050, 3050)
                                    msg_orig = str
                                    msg = str.Substring(msgStart - 1, msgEnd - (msgStart)).Replace("&quot;", """").Replace("&amp;", "&").Replace(MsgStartCode, "")
                                    MSGlist_notified.Add(msg)
                                    ' MsgBox("Message: " & msg)
                                    If msg.Contains("alt=") Then
                                        msg = msg.Replace("<img crossorigin=""anonymous"" src=""data:image/gif;base64,R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7"" alt=""",
                                        "").Replace(""" draggable=""false"" class=""b", "") _
                                        .Replace(" emoji wa _3-8er"" style=""background-position: 0px 0px;"">", "") _
                                        .Replace(" emoji wa _3-8er"" style=""background-position: -40px -20px;"">", "") _
                                        .Replace(" emoji wa _3-8er"" style=""background-position: 0px -80px;"">", "") _
                                        .Replace(" emoji wa _3-8er"" style=""background-position: -60px -20px;"">", "") _
                                        .Replace(" emoji wa _3-8er"" style=""background-position: ", "").Replace("px", "").Replace(";", "").Replace(">", "").Replace("-", "") _
                                        .Replace(" """, "")
                                        msg = Regex.Replace(msg, "[H\d+]", "")
                                        msg = msg.Replace(" """, "")
                                        'msg.Substring(InStrRev(msg, "alt=""") + 4, InStrRev(msg, """ draggable") - InStrRev(msg, "alt=""") - 1)
                                        'MsgBox(msg)
                                    End If
                                    If WhatsAppNotificationMsg <> msg Then
                                        WhatsAppNotificationMsg = msg
                                        NotifyManager.Notifications(1).Body = who
                                        NotifyManager.Notifications(1).Body2 = msg
                                        If Not msg.Contains("typing") Then
                                            NotifyManager.ShowNotification(NotifyManager.Notifications(1))
                                        Else
                                            WhatsAppNotified = False
                                            GetWhatsAppBadge()
                                            Return
                                        End If

                                        timer_ClearNotifications.Start()
                                        WhatsAppCurrentBadge = counter
                                        WhatsAppNotified = True
                                        NotificationType = "WhatsApp"
                                    End If

                                Catch ex As Exception
                                    'MsgBox(ex.ToString)
                                    If WhatsAppNotificationMsg <> msg Then
                                        WhatsAppCurrentBadge = counter
                                        WhatsAppNotified = True
                                        WhatsAppNotificationMsg = msg
                                        NotifyManager.Notifications(1).Body = who
                                        If Not msg.Contains("typing") Then
                                            NotifyManager.Notifications(1).Body2 = msg.Replace(counter, "")
                                        Else
                                            WhatsAppNotified = False
                                            GetWhatsAppBadge()

                                            Return
                                        End If


                                        Try
                                            If Not msg.Contains("typing") Then
                                                NotifyManager.ShowNotification(NotifyManager.Notifications(1))
                                            Else
                                                WhatsAppNotified = False
                                                GetWhatsAppBadge()
                                                Return
                                            End If

                                            timer_ClearNotifications.Start()
                                        Catch ex2 As Exception

                                        End Try
                                        NotificationType = "WhatsApp"

                                        'MsgBox("Error: Failed to show notification. This may be because the message is too long. Check for new messages.")
                                    End If
                                End Try

                            End If

                        End If

                    Next



                    WhatsAppBadge.Visible = True
                    WhatsAppBadge.Text = CType(CInt(counter), String)

                Else
                    If WhatsAppBadge.Text <> Nothing Then
                        WhatsAppBadge.Visible = False

                    End If
                    If WhatsAppBadge.Text = 0 Then
                        WhatsAppBadge.Visible = False
                    End If
                    ReadingCode = False

                End If

            Else
                WhatsAppBadge.Visible = False

            End If
            ReadingCode = False
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        timer_WhatsApp.Start()

        If _Counter = 0 Then
            WhatsAppBadge.Visible = False
        Else
            WhatsAppBadge.Visible = True
        End If

        ' GetWhatsAppCode(True)
    End Sub

#End Region

#Region " Gmail"
    Public Sub GetGmailBadge()
        Dim MessageCount As Integer = 0
        Try
            web_Gmail.EvaluateScriptAsync("document.getElementById('vh').remove();")
            Dim str As String
            Dim ReadHTML = web_Gmail.EvaluateScriptAsync("(function() {  var x = document.body.innerHTML; return x; })();")
            Dim response = ReadHTML.Result
            str = response.Result.ToString


            If response.Success = True And response.Result.ToString <> Nothing Then

                '  If str.Contains("_31gEB") And Not str.Contains("typing") Then
                Dim display As String = str
                ' My.Computer.Clipboard.SetText(display)
                If Not display = Nothing Then
                    Dim startstr As String = "aria-label=""Inbox "
                    Dim endstr As String = " unread"
                    MessageCount = CInt(display.Substring(display.IndexOf(startstr), display.IndexOf(endstr) - display.IndexOf(startstr)) _
                       .Replace(startstr, "").Replace("Inbox", "").Replace(" ", "").Replace(vbCrLf, "").TrimStart.TrimEnd)
                    ' MsgBox(MessageCount)

                End If
                '  End If

            End If

        Catch ex As Exception
        End Try

        ' If My.Settings.BadgesEnabled Then
        If MessageCount <> 0 AndAlso MessageCount <> -1 Then
            GmailBadge.Text = MessageCount.ToString
            GmailBadge.Visible = True
            If GmailCount <> MessageCount Then
                ' NotifyManager.Notifications(2).Body = 
                If Not GmailCount > MessageCount Then
                    NotificationType = "Gmail"
                    NotifyManager.ShowNotification(NotifyManager.Notifications(2))
                    timer_ClearNotifications.Start()
                End If

                GmailCount = MessageCount
            End If
        Else
            GmailBadge.Visible = False
        End If
        ' Else
        ' GmailBadge.Visible = False
        ' End If

    End Sub


#End Region

#Region " Messages"

    Public Sub GetMessagesBadge()
        Try
            Dim str As String
            Dim ReadHTML = web_Messages.EvaluateScriptAsync("(function() {  var x = document.body.innerHTML; return x; })();")
            Dim response = ReadHTML.Result
            str = response.Result.ToString
            Dim MSGlist_new As New List(Of String)

            If response.Success = True And response.Result.ToString <> Nothing Then
                Dim myMatches As MatchCollection : Dim myPattern As New Regex("text-content unread") : myMatches = myPattern.Matches(str)

                ' Search for all the matches
                Dim successfulMatch As Match : Dim counter As Integer = 0


                Dim who As String = "Web Message"
                Dim msg As String = "You have a new message." '& counter
                Dim startwhostr As String = "data-e2e-conversation-name="""">"
                Dim endstr As String = "</span><!"
                Dim msgstartstr As String = "class=""ng-star-inserted"">"
                Dim endwhostr As String = "</span>"

                ' My.Computer.Clipboard.SetText(str)
                For Each successfulMatch In myMatches
                    counter += 1



                    If str.Contains("text-content unread") Then
                        Dim who_start As Integer
                        Dim who_end As Integer
                        Dim msgstart As Integer
                        Dim msgend As Integer

                        who_start = InStrRev(str, startwhostr, successfulMatch.Index + 200)
                        who_end = InStrRev(str, endwhostr, successfulMatch.Index + 300)
                        msgstart = InStrRev(str, msgstartstr, successfulMatch.Index + 450)
                        msgend = InStrRev(str, endstr, successfulMatch.Index + 775)

                        Dim strnotemoji As String = str.Substring(who_start - 1, msgend - who_start)
                        My.Computer.Clipboard.SetText(str)
                        If strnotemoji.Contains("data-e2e-conversation-name=""""><span data-emoji-sibling="""">") Then

                            ' My.Computer.Clipboard.SetText(str)
                            'Else
                            startwhostr = "data-e2e-conversation-name=""""><span data-emoji-sibling="""">"
                            endwhostr = "</span></span>"

                            who_start = InStrRev(str, startwhostr, successfulMatch.Index + 200 + 129)
                            who_end = InStrRev(str, endwhostr, successfulMatch.Index + 300 + 129)
                            msgstart = InStrRev(str, msgstartstr, successfulMatch.Index + 450 + 129)
                            msgend = InStrRev(str, endstr, successfulMatch.Index + 775 + 229)
                        End If

                        msg = str.Substring(msgstart + 24, msgend - (msgstart + 25)).Replace("</span>", "").Replace("<span data-is-emoji="""" style=""font-size:14px;line-height:16px;"">", "").Replace("&quot;", """").Replace("&amp;", "&")
                        who = str.Substring(who_start + 29, who_end - (who_start + 30)) _
                            .Replace(startwhostr, "").Replace("</span><span data-is-emoji="""" style=""font-size:14px;line-height:16px;"">""", "").Replace("<span data-emoji-sibling="""">", "") _
                            .Replace("</span><span data-is-emoji="""" style=""font-size:14px;line-height:16px;"">", "").Replace("</span>", "").Replace("&quot;", """").Replace("&amp;", "&")
                        Try
                            MSGlist_new.Add(msg)

                        Catch ex As Exception
                        End Try
                        If MessagesCurrentBadge <> counter Then



                            If MessagesCurrentBadge > counter Then
                                MessagesCurrentBadge = counter
                                MessagesNotified = True

                            ElseIf MessagesCurrentBadge < counter Then
                                If Not MSGlist_new.Count = 0 Then
                                    If Not webMSGlist_notified.Contains(MSGlist_new.Item(MSGlist_new.Count - 1)) Then
                                        MessagesNotified = False
                                    End If
                                End If
                            End If
                        Else
                            MessagesNotified = True

                        End If
                        If Not MSGlist_new.Count = 0 Then
                            If Not webMSGlist_notified.Contains(MSGlist_new.Item(MSGlist_new.Count - 1)) Then
                                MessagesNotified = False
                            End If
                        End If




                        If MessagesNotified = False Then

                            MessagesCurrentBadge = counter
                            MessagesNotified = True

                            Try
                                webMSGlist_notified.Add(msg)

                                If MessagesNotificationMsg <> msg Then
                                    MessagesNotificationMsg = msg
                                    NotifyManager.Notifications(0).Body = who
                                    NotifyManager.Notifications(0).Body2 = msg
                                    NotifyManager.ShowNotification(NotifyManager.Notifications(0))
                                    timer_ClearNotifications.Start()
                                    MessagesCurrentBadge = counter
                                    MessagesNotified = True
                                    NotificationType = "Messages"
                                End If

                            Catch ex As Exception
                                If MessagesNotificationMsg <> msg Then
                                    MessagesCurrentBadge = counter
                                    MessagesNotified = True
                                    MessagesNotificationMsg = msg
                                    NotifyManager.Notifications(0).Body = who
                                    NotifyManager.Notifications(0).Body2 = msg.Replace(counter, "")
                                    NotifyManager.ShowNotification(NotifyManager.Notifications(0))
                                    timer_ClearNotifications.Start()
                                    NotificationType = "Messages"
                                End If
                            End Try
                        End If
                    End If
                Next
                MessagesBadge.Visible = True
                MessagesBadge.Text = CType(CInt(counter), String)
            Else
                MessagesBadge.Visible = False
            End If


            If MessagesBadge.Text = "0" Then
                MessagesBadge.Visible = False
            End If
            If Not webMSGlist_notified.Count = 0 Then
                '   MsgBox(MSGlist_new.Count & MSGlist_new.Item(MSGlist_new.Count - 1) & "  " & webMSGlist_notified.Count & webMSGlist_notified(webMSGlist_notified.Count - 1))

            End If
        Catch ex As Exception
        End Try



    End Sub


#End Region

    Private Sub NotifyManager_Activated(sender As Object, e As DevExpress.XtraBars.ToastNotifications.ToastNotificationEventArgs) Handles NotifyManager.Activated
        Me.Show()
        Me.BringToFront()
        Me.Activate()
        Select Case NotificationType
            Case "WhatsApp"
                web_Shared = web_WhatsApp
            Case "Messages"
                web_Shared = web_Messages
            Case "Gmail"
                web_Shared = web_Gmail
        End Select
        web_Shared.BringToFront()
    End Sub


    Private Sub timer_ClearNotifications_Tick(sender As Object, e As EventArgs) Handles timer_ClearNotifications.Tick
        GetWhatsAppCode(True)

        For i As Integer = 0 To NotifyManager.Notifications.Count - 1
            NotifyManager.HideNotification(NotifyManager.Notifications(i))
        Next

        '  timer_ClearNotifications.Stop()
    End Sub

    Private Sub NotifyManager_TimedOut(sender As Object, e As ToastNotificationEventArgs) Handles NotifyManager.TimedOut
        NotifyManager.HideNotifications(e.NotificationID)
    End Sub


#End Region
#Region " Taskbar Icon for Badges"

    Private Sub label_MsgBadge_VisibleChanged(sender As Object, e As EventArgs)
        ' Return
        If AppLoaded = False Then Return
        Dim ShowIcon As Boolean = False

        If WhatsAppBadge.Visible = True Then
            ShowIcon = True
        End If
        If GmailBadge.Visible = True Then
            ShowIcon = True
        End If



        If ShowIcon = True Then
            TrayIcon.Icon = BadgeIcon
            '   TrayIcon.Visible = Not TrayIcon.Visible
            'TrayIcon.Visible = Not TrayIcon.Visible
            TrayIcon.Text = "Jumble (Have messages)"
            Try
                TaskbarManager.Instance.SetOverlayIcon(My.Resources.Badge, "Jumble")
            Catch ex As Exception
            End Try
        Else
            TrayIcon.Icon = MainIcon
            TrayIcon.Text = "Jumble"
            ' TrayIcon.Visible = Not TrayIcon.Visible
            ' TrayIcon.Visible = Not TrayIcon.Visible
            Try
                TaskbarManager.Instance.SetOverlayIcon(Nothing, "Jumble")
            Catch ex As Exception
            End Try

        End If

        ' label_Gmail1Badge.BringToFront()
        ' label_Gmail2Badge.BringToFront()
        ' label_Gmail3Badge.BringToFront()
        ' label_WhatsBadge.BringToFront()
        WhatsAppBadge.BringToFront()

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub



#End Region

#Region " Graphics"
    Dim hover As Boolean = False
    Private Sub but_WhatsApp_MouseEnter(sender As Object, e As EventArgs) Handles but_Icon1.MouseEnter, but_Icon5.MouseEnter, but_Icon7.MouseEnter,
        but_Icon4.MouseEnter, but_Icon2.MouseEnter, but_Icon6.MouseEnter, but_Icon3.MouseEnter, but_back.MouseEnter, but_Forward.MouseEnter,
        gmail_1.MouseEnter, gmail_2.MouseEnter, but_More.MouseEnter, but_Reload.MouseEnter, but_Strikethrough.MouseEnter, but_removeformatting.MouseEnter, but_Settings.MouseEnter, but_Customize.MouseEnter, but_Checklist.MouseEnter, but_Signal.MouseEnter
        sender.backcolor = HoverColor ' Color.Gray
        hover = True

        '   ToolTip1.Show(sender.name.ToString.Replace("but_", ""), sender)
    End Sub

    Private Sub but_WhatsApp_MouseLeave(sender As Object, e As EventArgs) Handles but_Icon1.MouseLeave, but_Icon5.MouseLeave, but_Icon7.MouseLeave,
        but_Icon4.MouseLeave, but_Icon2.MouseLeave, but_Icon6.MouseLeave, but_Icon3.MouseLeave, but_back.MouseLeave, but_Forward.MouseLeave,
        gmail_1.MouseLeave, gmail_2.MouseLeave, but_More.MouseLeave, but_Reload.MouseLeave, but_Strikethrough.MouseLeave, but_removeformatting.MouseLeave, but_Settings.MouseLeave, but_Customize.MouseLeave, but_Checklist.MouseLeave, but_Signal.MouseLeave
        sender.backcolor = Color.Transparent ' Color.FromArgb(64, 64, 64)
    End Sub

    Private Sub but_WhatsApp_MouseDown(sender As Object, e As MouseEventArgs) Handles but_Icon1.MouseDown, but_Icon5.MouseDown,
        but_Icon4.MouseDown, but_Icon2.MouseDown, but_Icon6.MouseDown, but_Icon3.MouseDown, but_back.MouseDown, but_Forward.MouseDown,
        gmail_1.MouseDown, gmail_2.MouseDown, but_More.MouseDown, but_Reload.MouseDown, but_Strikethrough.MouseDown, but_removeformatting.MouseDown, but_Settings.MouseDown, but_Customize.MouseDown, but_Icon7.MouseDown, but_Checklist.MouseDown, but_Signal.MouseDown
        sender.backcolor = PressColor ' Color.DimGray
    End Sub

    Private Sub but_WhatsApp_MouseUp(sender As Object, e As MouseEventArgs) Handles but_Icon1.MouseUp, but_Icon5.MouseUp, but_Icon7.MouseUp,
        but_Icon4.MouseUp, but_Icon2.MouseUp, but_Icon6.MouseUp, but_Icon3.MouseUp, but_back.MouseUp, but_Forward.MouseUp, gmail_1.MouseUp,
        gmail_2.MouseUp, but_More.MouseUp, but_Reload.MouseUp, but_Strikethrough.MouseUp, but_removeformatting.MouseUp, but_Settings.MouseUp, but_Customize.MouseUp, but_Checklist.MouseUp, but_Signal.MouseUp
        If hover Then
            If sender.name <> "but_Settings" Then
                sender.backcolor = HoverColor '  Color.Gray
            Else
                sender.backcolor = Color.Transparent '  Color.FromArgb(64, 64, 64)
            End If

        Else
            sender.backcolor = Color.Transparent '  Color.FromArgb(64, 64, 64)
        End If
    End Sub

    Private Sub timer_ResetIcons_Tick(sender As Object, e As EventArgs) Handles timer_ResetIcons.Tick
        If hover = False Then
            but_Customize.BackColor = Color.Transparent ' Color.FromArgb(64, 64, 64)
            but_Settings.BackColor = Color.Transparent '  Color.FromArgb(64, 64, 64)
        End If
        timer_ResetIcons.Start()
    End Sub





#End Region

#Region " Other Buttons"

    Private Sub web_Calendar_FrameLoadEnd(sender As Object, e As FrameLoadEndEventArgs) Handles web_Calendar.FrameLoadEnd, web_Drive.FrameLoadEnd, web_Facebook.FrameLoadEnd,
            web_Google.FrameLoadEnd, web_Instagram.FrameLoadEnd, web_Life360.FrameLoadEnd
        IsGoogle()

    End Sub

    Private Sub but_Checklist_Click(sender As Object, e As EventArgs) Handles but_Checklist.Click
        Checklist_form.Show()

    End Sub

    Private Sub but_Signal_Click(sender As Object, e As EventArgs) Handles but_Signal.Click
        SuspendDrawing(Me)
        Signal_form.Show()
        Try
            Signal_form.BringToFront()
        Catch ex As Exception
        End Try
        ResumeDrawing(Me)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        panel_NavButtons.BringToFront()
        web_Shared.BringToFront()
        web_Shared.Focus()
        ResumeLayout()
        Timer1.Stop()

    End Sub

#End Region

#Region " SysTray"

    Private Sub TrayIcon_MouseDoubleClick(sender As Object, e As EventArgs) Handles TrayIcon.MouseDoubleClick
        Me.Activate()
    End Sub

    Private Sub but_Close_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

#End Region


End Class


#Region " Download Handler"
Public Class DownloadHandler
    Implements IDownloadHandler

    Public Event OnBeforeDownloadFired As EventHandler(Of DownloadItem)
    Public Event OnDownloadUpdatedFired As EventHandler(Of DownloadItem)

    Public Sub OnBeforeDownload(ByVal chromiumWebBrowser As IWebBrowser, ByVal browser As IBrowser, ByVal downloadItem As DownloadItem, ByVal callback As IBeforeDownloadCallback)
        RaiseEvent OnBeforeDownloadFired(Me, downloadItem)

        If Not callback.IsDisposed Then

            Using callback
                callback.[Continue](downloadItem.SuggestedFileName, showDialog:=True)
            End Using
        End If
    End Sub

    Public Sub OnDownloadUpdated(ByVal chromiumWebBrowser As IWebBrowser, ByVal browser As IBrowser, ByVal downloadItem As DownloadItem, ByVal callback As IDownloadItemCallback)
        RaiseEvent OnDownloadUpdatedFired(Me, downloadItem)
    End Sub

    Private Sub IDownloadHandler_OnBeforeDownload(chromiumWebBrowser As IWebBrowser, browser As IBrowser, downloadItem As DownloadItem, callback As IBeforeDownloadCallback) Implements IDownloadHandler.OnBeforeDownload
        RaiseEvent OnBeforeDownloadFired(Me, downloadItem)

        If Not callback.IsDisposed Then

            Using callback
                callback.[Continue](downloadItem.SuggestedFileName, showDialog:=True)
            End Using
        End If
        ' Throw New NotImplementedException()
    End Sub

    Private Sub IDownloadHandler_OnDownloadUpdated(chromiumWebBrowser As IWebBrowser, browser As IBrowser, downloadItem As DownloadItem, callback As IDownloadItemCallback) Implements IDownloadHandler.OnDownloadUpdated
        RaiseEvent OnDownloadUpdatedFired(Me, downloadItem)
        '    Throw New NotImplementedException()
    End Sub
End Class


#End Region

#Region " Right Click Menu"

Public Class MyCustomMenuHandler
    Implements IContextMenuHandler

    Public Sub OnBeforeContextMenu(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame, ByVal parameters As IContextMenuParams, ByVal model As IMenuModel)
    End Sub

    Public Function OnContextMenuCommand(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame, ByVal parameters As IContextMenuParams, ByVal commandId As CefMenuCommand, ByVal eventFlags As CefEventFlags) As Boolean
        Return False
    End Function

    Public Sub OnContextMenuDismissed(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame)
    End Sub

    Public Function RunContextMenu(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame, ByVal parameters As IContextMenuParams, ByVal model As IMenuModel, ByVal callback As IRunContextMenuCallback) As Boolean
        Return False
    End Function

    Private Sub IContextMenuHandler_OnBeforeContextMenu(chromiumWebBrowser As IWebBrowser, browser As IBrowser, frame As IFrame, parameters As IContextMenuParams, model As IMenuModel) Implements IContextMenuHandler.OnBeforeContextMenu
        Console.WriteLine("Context menu opened !")

        If model.Count > 0 Then
            model.AddSeparator()
        End If

        '' Navigation.
        ' model.AddItem(CType(100, CefMenuCommand), "Back")
        '  model.AddItem(CType(101, CefMenuCommand), "Forward")
        model.AddItem(CType(102, CefMenuCommand), "Reload")
        '  model.AddItem(CType(103, CefMenuCommand), "Reload No Cache")
        model.AddItem(CType(104, CefMenuCommand), "Stop Load")
        model.AddSeparator()
        model.AddItem(CefMenuCommand.Find, "Search Text/Open Link")
        '' Editing.
        ' model.AddItem(CType(110, CefMenuCommand), "Undo")
        '   model.AddItem(CType(111, CefMenuCommand), "Redo")
        '  model.AddItem(CType(112, CefMenuCommand), "Cut")
        '  model.AddItem(CType(113, CefMenuCommand), "Copy")
        '  model.AddItem(CType(114, CefMenuCommand), "Paste")
        '  model.AddItem(CType(115, CefMenuCommand), "Delete")
        '  model.AddItem(CType(116, CefMenuCommand), "SelectAll")
        model.AddSeparator()
        model.AddItem(CType(26501, CefMenuCommand), "Show DevTools")
        '  model.AddItem(CType(26502, CefMenuCommand), "Close DevTools")

        '   model.AddItem(CType(26503, CefMenuCommand), "Display alert message")
        ' Throw New NotImplementedException()
    End Sub

    Private Function IContextMenuHandler_OnContextMenuCommand(chromiumWebBrowser As IWebBrowser, browser As IBrowser, frame As IFrame, parameters As IContextMenuParams, commandId As CefMenuCommand, eventFlags As CefEventFlags) As Boolean Implements IContextMenuHandler.OnContextMenuCommand

        If commandId = CType(100, CefMenuCommand) Then
            browser.GoBack()
            Return True
        End If

        If commandId = CType(101, CefMenuCommand) Then
            browser.GoForward()
            Return True
        End If
        If commandId = CType(102, CefMenuCommand) Then
            browser.Reload()
            Return True
        End If
        If commandId = CType(103, CefMenuCommand) Then

            Return True
        End If
        If commandId = CType(104, CefMenuCommand) Then
            browser.StopLoad()
            Return True
        End If
        If commandId = CType(110, CefMenuCommand) Then

            Return True
        End If
        If commandId = CType(111, CefMenuCommand) Then
            '   browser.GetHost()
            Return True
        End If
        If commandId = CefMenuCommand.Find Then
            Try
                Dim uriResult As Uri
                Dim uriName As String = parameters.SelectionText
                Dim result As Boolean = Uri.TryCreate(uriName, UriKind.Absolute, uriResult) AndAlso (uriResult.Scheme = Uri.UriSchemeHttp OrElse uriResult.Scheme = Uri.UriSchemeHttps)
                'chromiumWebBrowser.SelectAll
                If result Then
                    Process.Start(parameters.SelectionText)
                Else
                    Process.Start("https://www.google.com/search?q=" & parameters.SelectionText)
                End If
                    
            Catch ex As Exception

            End Try

        End If
        ' If commandId = CType(112, CefMenuCommand) Then
        '     ' browser.GetHost()
        '     Return True
        ' End If
        '     ' If commandId = CType(113, CefMenuCommand) Then
        ' '  browser.GetHost()
        ' Return True
        ' End If
        ' If commandId = CType(114, CefMenuCommand) Then
        ' '  browser.GetHost()
        ' Return True
        ' End If
        ' If commandId = CType(115, CefMenuCommand) Then
        ' '    browser.GetHost()
        ' Return True
        ' End If
        ' If commandId = CType(116, CefMenuCommand) Then
        ' ' browser.GetHost()
        ' Return True
        ' End If
        '
        If commandId = CType(26501, CefMenuCommand) Then
            browser.GetHost().ShowDevTools()
            Return True
        End If

        If commandId = CType(26502, CefMenuCommand) Then
            browser.GetHost().CloseDevTools()
            Return True
        End If

        If commandId = CType(26503, CefMenuCommand) Then
            ' MessageBox.Show("An example alert message ?")
            Return True
        End If

        Return False
        '  Throw New NotImplementedException()
    End Function

    Private Sub IContextMenuHandler_OnContextMenuDismissed(chromiumWebBrowser As IWebBrowser, browser As IBrowser, frame As IFrame) Implements IContextMenuHandler.OnContextMenuDismissed
        'Throw New NotImplementedException()
    End Sub

    Private Function IContextMenuHandler_RunContextMenu(chromiumWebBrowser As IWebBrowser, browser As IBrowser, frame As IFrame, parameters As IContextMenuParams, model As IMenuModel, callback As IRunContextMenuCallback) As Boolean Implements IContextMenuHandler.RunContextMenu
        Return False
        'Throw New NotImplementedException()
    End Function
End Class


#End Region

#Region " Request Handler"

Public Class BrowserRequestHandler
    Implements IRequestHandler

    Public Function OnBeforeBrowse(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame, ByVal request As IRequest, ByVal isRedirect As Boolean) As Boolean
        Return False
        If Not request.Url.StartsWith("file:") And Not request.Url.Contains("whatsapp") _
            And Not request.Url.Contains("messages") _
            And Not request.Url.Contains("dropbox") _
            And Not request.Url.Contains("instagram") _
            And Not request.Url.Contains("facebook") _
            And Not request.Url.Contains("life360") _
            And Not request.Url.Contains("google") _
        Then
            MsgBox(request.Url)
            System.Diagnostics.Process.Start(request.Url)
            Return True
        End If

        Return False
    End Function

    Public Function OnOpenUrlFromTab(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame, ByVal targetUrl As String, ByVal targetDisposition As WindowOpenDisposition, ByVal userGesture As Boolean) As Boolean
        Return False
    End Function

    Public Function OnCertificateError(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal errorCode As CefErrorCode, ByVal requestUrl As String, ByVal sslInfo As ISslInfo, ByVal callback As IRequestCallback) As Boolean
        callback.Dispose()
        Return False
    End Function

    Public Sub OnPluginCrashed(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal pluginPath As String)
        Throw New Exception("Plugin crashed!")
    End Sub

    Public Function OnBeforeResourceLoad(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame, ByVal request As IRequest, ByVal callback As IRequestCallback) As CefReturnValue
        Return CefReturnValue.[Continue]
    End Function

    Public Function GetAuthCredentials(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame, ByVal isProxy As Boolean, ByVal host As String, ByVal port As Integer, ByVal realm As String, ByVal scheme As String, ByVal callback As IAuthCallback) As Boolean
        callback.Dispose()
        Return False
    End Function

    Public Function OnSelectClientCertificate(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal isProxy As Boolean, ByVal host As String, ByVal port As Integer, ByVal certificates As X509Certificate2Collection, ByVal callback As ISelectClientCertificateCallback) As Boolean
        callback.Dispose()
        Return False
    End Function

    Public Sub OnRenderProcessTerminated(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal status As CefTerminationStatus)
        Throw New Exception("Browser render process is terminated!")
    End Sub

    Public Function OnQuotaRequest(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal originUrl As String, ByVal newSize As Long, ByVal callback As IRequestCallback) As Boolean
        callback.Dispose()
        Return False
    End Function

    Public Sub OnResourceRedirect(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame, ByVal request As IRequest, ByVal response As IResponse, ByRef newUrl As String)
        Dim url = newUrl
        newUrl = url
    End Sub

    Public Function OnProtocolExecution(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal url As String) As Boolean
        Return url.StartsWith("mailto")
    End Function

    Public Sub OnRenderViewReady(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser)
    End Sub

    Public Function OnResourceResponse(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame, ByVal request As IRequest, ByVal response As IResponse) As Boolean
        Return False
    End Function

    Public Function GetResourceResponseFilter(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame, ByVal request As IRequest, ByVal response As IResponse) As IResponseFilter
        Return Nothing
    End Function

    Public Sub OnResourceLoadComplete(ByVal browserControl As IWebBrowser, ByVal browser As IBrowser, ByVal frame As IFrame, ByVal request As IRequest, ByVal response As IResponse, ByVal status As UrlRequestStatus, ByVal receivedContentLength As Long)
    End Sub

    Public Function OnBeforeBrowse(chromiumWebBrowser As IWebBrowser, browser As IBrowser, frame As IFrame, request As IRequest, userGesture As Boolean, isRedirect As Boolean) As Boolean Implements IRequestHandler.OnBeforeBrowse
        If Not request.Url.StartsWith("file:") _
            And Not request.Url.Contains("whatsapp") _
            And Not request.Url.Contains("messages") _
            And Not request.Url.Contains("dropbox") _
            And Not request.Url.Contains("instagram") _
            And Not request.Url.Contains("facebook") _
            And Not request.Url.Contains("life360") _
            And Not request.Url.Contains("google") _
            And Not request.Url.Contains("devtools") _
            And Not request.Url.Contains("slack") _
            And Not request.Url.Contains("client") _
            Then
            '   MsgBox(request.Url)


            System.Diagnostics.Process.Start(request.Url)
            frame.Browser.CloseBrowser(True)
            Return True
        End If

        Return False

    End Function

    Private Function IRequestHandler_OnOpenUrlFromTab(chromiumWebBrowser As IWebBrowser, browser As IBrowser, frame As IFrame, targetUrl As String, targetDisposition As WindowOpenDisposition, userGesture As Boolean) As Boolean Implements IRequestHandler.OnOpenUrlFromTab
        Return False
    End Function

    Public Function GetResourceRequestHandler(chromiumWebBrowser As IWebBrowser, browser As IBrowser, frame As IFrame, request As IRequest, isNavigation As Boolean, isDownload As Boolean, requestInitiator As String, ByRef disableDefaultHandling As Boolean) As IResourceRequestHandler Implements IRequestHandler.GetResourceRequestHandler
        ' Throw New NotImplementedException()
    End Function

    Public Function GetAuthCredentials(chromiumWebBrowser As IWebBrowser, browser As IBrowser, originUrl As String, isProxy As Boolean, host As String, port As Integer, realm As String, scheme As String, callback As IAuthCallback) As Boolean Implements IRequestHandler.GetAuthCredentials
        callback.Dispose()
        Return False
    End Function

    Private Function IRequestHandler_OnQuotaRequest(chromiumWebBrowser As IWebBrowser, browser As IBrowser, originUrl As String, newSize As Long, callback As IRequestCallback) As Boolean Implements IRequestHandler.OnQuotaRequest
        callback.Dispose()
        Return False
    End Function

    Private Function IRequestHandler_OnCertificateError(chromiumWebBrowser As IWebBrowser, browser As IBrowser, errorCode As CefErrorCode, requestUrl As String, sslInfo As ISslInfo, callback As IRequestCallback) As Boolean Implements IRequestHandler.OnCertificateError
        callback.Dispose()
        Return False
    End Function

    Private Function IRequestHandler_OnSelectClientCertificate(chromiumWebBrowser As IWebBrowser, browser As IBrowser, isProxy As Boolean, host As String, port As Integer, certificates As X509Certificate2Collection, callback As ISelectClientCertificateCallback) As Boolean Implements IRequestHandler.OnSelectClientCertificate
        callback.Dispose()
        Return False
    End Function

    Private Sub IRequestHandler_OnPluginCrashed(chromiumWebBrowser As IWebBrowser, browser As IBrowser, pluginPath As String) Implements IRequestHandler.OnPluginCrashed
        Throw New Exception("Plugin crashed!")
    End Sub

    Private Sub IRequestHandler_OnRenderViewReady(chromiumWebBrowser As IWebBrowser, browser As IBrowser) Implements IRequestHandler.OnRenderViewReady
        'Throw New NotImplementedException()
    End Sub

    Private Sub IRequestHandler_OnRenderProcessTerminated(chromiumWebBrowser As IWebBrowser, browser As IBrowser, status As CefTerminationStatus) Implements IRequestHandler.OnRenderProcessTerminated
        Throw New Exception("Browser render process is terminated!")
    End Sub
End Class


#End Region

