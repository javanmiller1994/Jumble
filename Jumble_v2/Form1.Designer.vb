Partial Public Class Form1
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.panel_App = New System.Windows.Forms.Panel()
        Me.Panel_main = New System.Windows.Forms.Panel()
        Me.web_1 = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_Facebook = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_Instagram = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_Life360 = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_Google = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_Drive = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_Calendar = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_6 = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_2 = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_4 = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_5 = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_7 = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.web_3 = New CefSharp.WinForms.ChromiumWebBrowser()
        Me.panel_NavButtons = New System.Windows.Forms.Panel()
        Me.but_Signal = New System.Windows.Forms.PictureBox()
        Me.but_Checklist = New System.Windows.Forms.PictureBox()
        Me.but_Customize = New System.Windows.Forms.PictureBox()
        Me.but_Settings = New System.Windows.Forms.PictureBox()
        Me.but_removeformatting = New System.Windows.Forms.PictureBox()
        Me.but_Strikethrough = New System.Windows.Forms.PictureBox()
        Me.but_Reload = New System.Windows.Forms.PictureBox()
        Me.gmail_2 = New System.Windows.Forms.PictureBox()
        Me.gmail_1 = New System.Windows.Forms.PictureBox()
        Me.but_Forward = New System.Windows.Forms.PictureBox()
        Me.but_back = New System.Windows.Forms.PictureBox()
        Me.panel_NavBar = New System.Windows.Forms.Panel()
        Me.panel_Apps = New System.Windows.Forms.TableLayoutPanel()
        Me.but_More = New System.Windows.Forms.PictureBox()
        Me.but_Icon2 = New System.Windows.Forms.PictureBox()
        Me.but_Icon1 = New System.Windows.Forms.PictureBox()
        Me.but_Icon3 = New System.Windows.Forms.PictureBox()
        Me.but_Icon4 = New System.Windows.Forms.PictureBox()
        Me.but_Icon5 = New System.Windows.Forms.PictureBox()
        Me.but_Icon7 = New System.Windows.Forms.PictureBox()
        Me.but_Icon6 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.timer_WhatsApp = New System.Windows.Forms.Timer(Me.components)
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NotifyManager = New DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(Me.components)
        Me.timer_ClearNotifications = New System.Windows.Forms.Timer(Me.components)
        Me.timer_ResetIcons = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_shutdown = New System.Windows.Forms.Timer(Me.components)
        Me.timer_SkinChange = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.RtClickMenu = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.menubut_NewWindow = New DevExpress.XtraBars.BarButtonItem()
        Me.menubut_NewWindowCurrent = New DevExpress.XtraBars.BarButtonItem()
        Me.menubut_NewURL = New DevExpress.XtraBars.BarButtonItem()
        Me.menubut_CopyURL = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.panel_App.SuspendLayout()
        Me.Panel_main.SuspendLayout()
        Me.panel_NavButtons.SuspendLayout()
        CType(Me.but_Signal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Checklist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Customize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_removeformatting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Strikethrough, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Reload, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gmail_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gmail_1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Forward, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_back, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_NavBar.SuspendLayout()
        Me.panel_Apps.SuspendLayout()
        CType(Me.but_More, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Icon2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Icon1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Icon3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Icon4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Icon5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Icon7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Icon6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NotifyManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RtClickMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel_App
        '
        Me.panel_App.BackColor = System.Drawing.Color.Transparent
        Me.panel_App.Controls.Add(Me.Panel_main)
        Me.panel_App.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_App.Location = New System.Drawing.Point(0, 0)
        Me.panel_App.Name = "panel_App"
        Me.panel_App.Padding = New System.Windows.Forms.Padding(50, 0, 0, 0)
        Me.panel_App.Size = New System.Drawing.Size(821, 510)
        Me.panel_App.TabIndex = 0
        '
        'Panel_main
        '
        Me.Panel_main.Controls.Add(Me.web_1)
        Me.Panel_main.Controls.Add(Me.web_Facebook)
        Me.Panel_main.Controls.Add(Me.web_Instagram)
        Me.Panel_main.Controls.Add(Me.web_Life360)
        Me.Panel_main.Controls.Add(Me.web_Google)
        Me.Panel_main.Controls.Add(Me.web_Drive)
        Me.Panel_main.Controls.Add(Me.web_Calendar)
        Me.Panel_main.Controls.Add(Me.web_6)
        Me.Panel_main.Controls.Add(Me.web_2)
        Me.Panel_main.Controls.Add(Me.web_4)
        Me.Panel_main.Controls.Add(Me.web_5)
        Me.Panel_main.Controls.Add(Me.web_7)
        Me.Panel_main.Controls.Add(Me.web_3)
        Me.Panel_main.Controls.Add(Me.panel_NavButtons)
        Me.Panel_main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_main.Location = New System.Drawing.Point(50, 0)
        Me.Panel_main.Name = "Panel_main"
        Me.Panel_main.Size = New System.Drawing.Size(771, 510)
        Me.Panel_main.TabIndex = 3
        '
        'web_1
        '
        Me.web_1.ActivateBrowserOnCreation = False
        Me.web_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_1.Location = New System.Drawing.Point(0, 30)
        Me.web_1.Name = "web_1"
        Me.web_1.Size = New System.Drawing.Size(771, 480)
        Me.web_1.TabIndex = 2
        '
        'web_Facebook
        '
        Me.web_Facebook.ActivateBrowserOnCreation = False
        Me.web_Facebook.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_Facebook.Location = New System.Drawing.Point(0, 30)
        Me.web_Facebook.Name = "web_Facebook"
        Me.web_Facebook.Size = New System.Drawing.Size(771, 480)
        Me.web_Facebook.TabIndex = 9
        '
        'web_Instagram
        '
        Me.web_Instagram.ActivateBrowserOnCreation = False
        Me.web_Instagram.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_Instagram.Location = New System.Drawing.Point(0, 30)
        Me.web_Instagram.Name = "web_Instagram"
        Me.web_Instagram.Size = New System.Drawing.Size(771, 480)
        Me.web_Instagram.TabIndex = 8
        '
        'web_Life360
        '
        Me.web_Life360.ActivateBrowserOnCreation = False
        Me.web_Life360.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_Life360.Location = New System.Drawing.Point(0, 30)
        Me.web_Life360.Name = "web_Life360"
        Me.web_Life360.Size = New System.Drawing.Size(771, 480)
        Me.web_Life360.TabIndex = 7
        '
        'web_Google
        '
        Me.web_Google.ActivateBrowserOnCreation = False
        Me.web_Google.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_Google.Location = New System.Drawing.Point(0, 30)
        Me.web_Google.Name = "web_Google"
        Me.web_Google.Size = New System.Drawing.Size(771, 480)
        Me.web_Google.TabIndex = 6
        '
        'web_Drive
        '
        Me.web_Drive.ActivateBrowserOnCreation = False
        Me.web_Drive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_Drive.Location = New System.Drawing.Point(0, 30)
        Me.web_Drive.Name = "web_Drive"
        Me.web_Drive.Size = New System.Drawing.Size(771, 480)
        Me.web_Drive.TabIndex = 5
        '
        'web_Calendar
        '
        Me.web_Calendar.ActivateBrowserOnCreation = False
        Me.web_Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_Calendar.Location = New System.Drawing.Point(0, 30)
        Me.web_Calendar.Name = "web_Calendar"
        Me.web_Calendar.Size = New System.Drawing.Size(771, 480)
        Me.web_Calendar.TabIndex = 4
        '
        'web_6
        '
        Me.web_6.ActivateBrowserOnCreation = False
        Me.web_6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_6.Location = New System.Drawing.Point(0, 30)
        Me.web_6.Name = "web_6"
        Me.web_6.Size = New System.Drawing.Size(771, 480)
        Me.web_6.TabIndex = 3
        '
        'web_2
        '
        Me.web_2.ActivateBrowserOnCreation = False
        Me.web_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_2.Location = New System.Drawing.Point(0, 30)
        Me.web_2.Name = "web_2"
        Me.web_2.Size = New System.Drawing.Size(771, 480)
        Me.web_2.TabIndex = 2
        '
        'web_4
        '
        Me.web_4.ActivateBrowserOnCreation = False
        Me.web_4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_4.Location = New System.Drawing.Point(0, 30)
        Me.web_4.Name = "web_4"
        Me.web_4.Size = New System.Drawing.Size(771, 480)
        Me.web_4.TabIndex = 2
        '
        'web_5
        '
        Me.web_5.ActivateBrowserOnCreation = False
        Me.web_5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_5.Location = New System.Drawing.Point(0, 30)
        Me.web_5.Name = "web_5"
        Me.web_5.Size = New System.Drawing.Size(771, 480)
        Me.web_5.TabIndex = 2
        '
        'web_7
        '
        Me.web_7.ActivateBrowserOnCreation = False
        Me.web_7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_7.Location = New System.Drawing.Point(0, 30)
        Me.web_7.Name = "web_7"
        Me.web_7.Size = New System.Drawing.Size(771, 480)
        Me.web_7.TabIndex = 2
        '
        'web_3
        '
        Me.web_3.ActivateBrowserOnCreation = False
        Me.web_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web_3.Location = New System.Drawing.Point(0, 30)
        Me.web_3.Name = "web_3"
        Me.web_3.Size = New System.Drawing.Size(771, 480)
        Me.web_3.TabIndex = 3
        '
        'panel_NavButtons
        '
        Me.panel_NavButtons.Controls.Add(Me.but_Signal)
        Me.panel_NavButtons.Controls.Add(Me.but_Checklist)
        Me.panel_NavButtons.Controls.Add(Me.but_Customize)
        Me.panel_NavButtons.Controls.Add(Me.but_Settings)
        Me.panel_NavButtons.Controls.Add(Me.but_removeformatting)
        Me.panel_NavButtons.Controls.Add(Me.but_Strikethrough)
        Me.panel_NavButtons.Controls.Add(Me.but_Reload)
        Me.panel_NavButtons.Controls.Add(Me.gmail_2)
        Me.panel_NavButtons.Controls.Add(Me.gmail_1)
        Me.panel_NavButtons.Controls.Add(Me.but_Forward)
        Me.panel_NavButtons.Controls.Add(Me.but_back)
        Me.panel_NavButtons.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel_NavButtons.Location = New System.Drawing.Point(0, 0)
        Me.panel_NavButtons.Name = "panel_NavButtons"
        Me.panel_NavButtons.Size = New System.Drawing.Size(771, 30)
        Me.panel_NavButtons.TabIndex = 2
        '
        'but_Signal
        '
        Me.but_Signal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.but_Signal.BackColor = System.Drawing.Color.Transparent
        Me.but_Signal.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.Signal_white
        Me.but_Signal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Signal.Location = New System.Drawing.Point(641, 2)
        Me.but_Signal.Name = "but_Signal"
        Me.but_Signal.Size = New System.Drawing.Size(25, 25)
        Me.but_Signal.TabIndex = 13
        Me.but_Signal.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Signal, "Signal")
        Me.but_Signal.Visible = False
        '
        'but_Checklist
        '
        Me.but_Checklist.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.but_Checklist.BackColor = System.Drawing.Color.Transparent
        Me.but_Checklist.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.Checklist
        Me.but_Checklist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Checklist.Location = New System.Drawing.Point(672, 2)
        Me.but_Checklist.Name = "but_Checklist"
        Me.but_Checklist.Size = New System.Drawing.Size(25, 25)
        Me.but_Checklist.TabIndex = 13
        Me.but_Checklist.TabStop = False
        '
        'but_Customize
        '
        Me.but_Customize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.but_Customize.BackColor = System.Drawing.Color.Transparent
        Me.but_Customize.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.Paint_Brush_Icon
        Me.but_Customize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Customize.Location = New System.Drawing.Point(703, 2)
        Me.but_Customize.Name = "but_Customize"
        Me.but_Customize.Size = New System.Drawing.Size(25, 25)
        Me.but_Customize.TabIndex = 13
        Me.but_Customize.TabStop = False
        '
        'but_Settings
        '
        Me.but_Settings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.but_Settings.BackColor = System.Drawing.Color.Transparent
        Me.but_Settings.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.MenuIcon_Settings
        Me.but_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Settings.Location = New System.Drawing.Point(734, 2)
        Me.but_Settings.Name = "but_Settings"
        Me.but_Settings.Size = New System.Drawing.Size(25, 25)
        Me.but_Settings.TabIndex = 13
        Me.but_Settings.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Settings, "Settings")
        '
        'but_removeformatting
        '
        Me.but_removeformatting.BackColor = System.Drawing.Color.Transparent
        Me.but_removeformatting.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.RemoveFormatting
        Me.but_removeformatting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_removeformatting.Location = New System.Drawing.Point(192, 2)
        Me.but_removeformatting.Name = "but_removeformatting"
        Me.but_removeformatting.Size = New System.Drawing.Size(25, 25)
        Me.but_removeformatting.TabIndex = 12
        Me.but_removeformatting.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_removeformatting, "Remove Formatting")
        Me.but_removeformatting.Visible = False
        '
        'but_Strikethrough
        '
        Me.but_Strikethrough.BackColor = System.Drawing.Color.Transparent
        Me.but_Strikethrough.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.strikethrough
        Me.but_Strikethrough.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Strikethrough.Location = New System.Drawing.Point(161, 2)
        Me.but_Strikethrough.Name = "but_Strikethrough"
        Me.but_Strikethrough.Size = New System.Drawing.Size(25, 25)
        Me.but_Strikethrough.TabIndex = 11
        Me.but_Strikethrough.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Strikethrough, "Strikethrough")
        Me.but_Strikethrough.Visible = False
        '
        'but_Reload
        '
        Me.but_Reload.BackColor = System.Drawing.Color.Transparent
        Me.but_Reload.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.Refresh
        Me.but_Reload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Reload.Location = New System.Drawing.Point(68, 2)
        Me.but_Reload.Name = "but_Reload"
        Me.but_Reload.Size = New System.Drawing.Size(25, 25)
        Me.but_Reload.TabIndex = 10
        Me.but_Reload.TabStop = False
        '
        'gmail_2
        '
        Me.gmail_2.BackColor = System.Drawing.Color.Transparent
        Me.gmail_2.BackgroundImage = CType(resources.GetObject("gmail_2.BackgroundImage"), System.Drawing.Image)
        Me.gmail_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.gmail_2.Location = New System.Drawing.Point(130, 2)
        Me.gmail_2.Name = "gmail_2"
        Me.gmail_2.Size = New System.Drawing.Size(25, 25)
        Me.gmail_2.TabIndex = 9
        Me.gmail_2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.gmail_2, "Load Google Account 2")
        '
        'gmail_1
        '
        Me.gmail_1.BackColor = System.Drawing.Color.Transparent
        Me.gmail_1.BackgroundImage = CType(resources.GetObject("gmail_1.BackgroundImage"), System.Drawing.Image)
        Me.gmail_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.gmail_1.Location = New System.Drawing.Point(99, 2)
        Me.gmail_1.Name = "gmail_1"
        Me.gmail_1.Size = New System.Drawing.Size(25, 25)
        Me.gmail_1.TabIndex = 8
        Me.gmail_1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.gmail_1, "Load Google Account 1")
        '
        'but_Forward
        '
        Me.but_Forward.BackColor = System.Drawing.Color.Transparent
        Me.but_Forward.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.SwitchForward
        Me.but_Forward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Forward.Location = New System.Drawing.Point(37, 2)
        Me.but_Forward.Name = "but_Forward"
        Me.but_Forward.Size = New System.Drawing.Size(25, 25)
        Me.but_Forward.TabIndex = 5
        Me.but_Forward.TabStop = False
        '
        'but_back
        '
        Me.but_back.BackColor = System.Drawing.Color.Transparent
        Me.but_back.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.SwitchBack
        Me.but_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_back.Location = New System.Drawing.Point(6, 2)
        Me.but_back.Name = "but_back"
        Me.but_back.Size = New System.Drawing.Size(25, 25)
        Me.but_back.TabIndex = 4
        Me.but_back.TabStop = False
        '
        'panel_NavBar
        '
        Me.panel_NavBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.panel_NavBar.Controls.Add(Me.panel_Apps)
        Me.panel_NavBar.Dock = System.Windows.Forms.DockStyle.Left
        Me.panel_NavBar.Location = New System.Drawing.Point(0, 0)
        Me.panel_NavBar.Name = "panel_NavBar"
        Me.panel_NavBar.Size = New System.Drawing.Size(50, 510)
        Me.panel_NavBar.TabIndex = 1
        '
        'panel_Apps
        '
        Me.panel_Apps.BackColor = System.Drawing.Color.Transparent
        Me.panel_Apps.ColumnCount = 1
        Me.panel_Apps.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.panel_Apps.Controls.Add(Me.but_More, 0, 7)
        Me.panel_Apps.Controls.Add(Me.but_Icon2, 0, 1)
        Me.panel_Apps.Controls.Add(Me.but_Icon1, 0, 0)
        Me.panel_Apps.Controls.Add(Me.but_Icon3, 0, 2)
        Me.panel_Apps.Controls.Add(Me.but_Icon4, 0, 3)
        Me.panel_Apps.Controls.Add(Me.but_Icon5, 0, 4)
        Me.panel_Apps.Controls.Add(Me.but_Icon7, 0, 6)
        Me.panel_Apps.Controls.Add(Me.but_Icon6, 0, 5)
        Me.panel_Apps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel_Apps.Location = New System.Drawing.Point(0, 0)
        Me.panel_Apps.Name = "panel_Apps"
        Me.panel_Apps.RowCount = 8
        Me.panel_Apps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.panel_Apps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.panel_Apps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.panel_Apps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.panel_Apps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.panel_Apps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.panel_Apps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.panel_Apps.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.panel_Apps.Size = New System.Drawing.Size(50, 510)
        Me.panel_Apps.TabIndex = 0
        '
        'but_More
        '
        Me.but_More.BackColor = System.Drawing.Color.Transparent
        Me.but_More.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.SwitchForward1
        Me.but_More.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_More.Location = New System.Drawing.Point(3, 444)
        Me.but_More.Name = "but_More"
        Me.but_More.Size = New System.Drawing.Size(44, 50)
        Me.but_More.TabIndex = 7
        Me.but_More.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_More, "More")
        '
        'but_Icon2
        '
        Me.but_Icon2.BackColor = System.Drawing.Color.Transparent
        Me.but_Icon2.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.messages_icon
        Me.but_Icon2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Icon2.Location = New System.Drawing.Point(3, 66)
        Me.but_Icon2.Name = "but_Icon2"
        Me.but_Icon2.Size = New System.Drawing.Size(44, 50)
        Me.but_Icon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.but_Icon2.TabIndex = 2
        Me.but_Icon2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Icon2, "Messages")
        '
        'but_Icon1
        '
        Me.but_Icon1.BackColor = System.Drawing.Color.Transparent
        Me.but_Icon1.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.WhatsApp_Icon
        Me.but_Icon1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Icon1.Location = New System.Drawing.Point(3, 3)
        Me.but_Icon1.Name = "but_Icon1"
        Me.but_Icon1.Size = New System.Drawing.Size(44, 50)
        Me.but_Icon1.TabIndex = 1
        Me.but_Icon1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Icon1, "WhatsApp")
        '
        'but_Icon3
        '
        Me.but_Icon3.BackColor = System.Drawing.Color.Transparent
        Me.but_Icon3.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.gmail_icon
        Me.but_Icon3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Icon3.Location = New System.Drawing.Point(3, 129)
        Me.but_Icon3.Name = "but_Icon3"
        Me.but_Icon3.Size = New System.Drawing.Size(44, 50)
        Me.but_Icon3.TabIndex = 6
        Me.but_Icon3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Icon3, "Gmail")
        '
        'but_Icon4
        '
        Me.but_Icon4.BackColor = System.Drawing.Color.Transparent
        Me.but_Icon4.BackgroundImage = CType(resources.GetObject("but_Icon4.BackgroundImage"), System.Drawing.Image)
        Me.but_Icon4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Icon4.Location = New System.Drawing.Point(3, 192)
        Me.but_Icon4.Name = "but_Icon4"
        Me.but_Icon4.Size = New System.Drawing.Size(44, 50)
        Me.but_Icon4.TabIndex = 3
        Me.but_Icon4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Icon4, "Midweek Playlist")
        '
        'but_Icon5
        '
        Me.but_Icon5.BackColor = System.Drawing.Color.Transparent
        Me.but_Icon5.BackgroundImage = CType(resources.GetObject("but_Icon5.BackgroundImage"), System.Drawing.Image)
        Me.but_Icon5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Icon5.Location = New System.Drawing.Point(3, 255)
        Me.but_Icon5.Name = "but_Icon5"
        Me.but_Icon5.Size = New System.Drawing.Size(44, 50)
        Me.but_Icon5.TabIndex = 4
        Me.but_Icon5.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Icon5, "Weekend Playlist")
        '
        'but_Icon7
        '
        Me.but_Icon7.BackColor = System.Drawing.Color.Transparent
        Me.but_Icon7.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.google_sheet
        Me.but_Icon7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Icon7.Location = New System.Drawing.Point(3, 381)
        Me.but_Icon7.Name = "but_Icon7"
        Me.but_Icon7.Size = New System.Drawing.Size(44, 50)
        Me.but_Icon7.TabIndex = 5
        Me.but_Icon7.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Icon7, "Meeting Responsibilities Schedule")
        '
        'but_Icon6
        '
        Me.but_Icon6.BackColor = System.Drawing.Color.Transparent
        Me.but_Icon6.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.dropbox_icon
        Me.but_Icon6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Icon6.Location = New System.Drawing.Point(3, 318)
        Me.but_Icon6.Name = "but_Icon6"
        Me.but_Icon6.Size = New System.Drawing.Size(44, 50)
        Me.but_Icon6.TabIndex = 0
        Me.but_Icon6.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Icon6, "Dropbox - Meeting Info")
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 1000
        Me.ToolTip1.BackColor = System.Drawing.Color.Gray
        Me.ToolTip1.ForeColor = System.Drawing.Color.White
        Me.ToolTip1.InitialDelay = 250
        Me.ToolTip1.ReshowDelay = 100
        '
        'timer_WhatsApp
        '
        Me.timer_WhatsApp.Enabled = True
        Me.timer_WhatsApp.Interval = 3500
        '
        'TrayIcon
        '
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "Jumble"
        '
        'NotifyManager
        '
        Me.NotifyManager.ApplicationIconPath = "Jumble.exe"
        Me.NotifyManager.ApplicationId = "Jumble"
        Me.NotifyManager.ApplicationName = "Jumble"
        Me.NotifyManager.Notifications.AddRange(New DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties() {New DevExpress.XtraBars.ToastNotifications.ToastNotification("437717eb-6b16-42d3-95fc-69943fe4397d", Global.Jumble_v2.My.Resources.Resources.Messages, "Messages", "You have a new message", "Hello", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("35bfc156-9ce7-4482-832e-4a66e24ef3ba", Global.Jumble_v2.My.Resources.Resources.WhatsApp_Logo_1, "WhatsApp", "Hello", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor i" &
                    "ncididunt ut labore et dolore magna aliqua.", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04), New DevExpress.XtraBars.ToastNotifications.ToastNotification("84f69eaa-10f2-486f-9f38-d8b1a224d9af", Global.Jumble_v2.My.Resources.Resources.gmail_icon, "Gmail", "You have a new email message", "", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText04)})
        '
        'timer_ClearNotifications
        '
        Me.timer_ClearNotifications.Interval = 10000
        '
        'timer_ResetIcons
        '
        Me.timer_ResetIcons.Enabled = True
        '
        'Timer_shutdown
        '
        '
        'timer_SkinChange
        '
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'RtClickMenu
        '
        Me.RtClickMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.menubut_NewWindow), New DevExpress.XtraBars.LinkPersistInfo(Me.menubut_NewWindowCurrent), New DevExpress.XtraBars.LinkPersistInfo(Me.menubut_NewURL), New DevExpress.XtraBars.LinkPersistInfo(Me.menubut_CopyURL)})
        Me.RtClickMenu.Manager = Me.BarManager1
        Me.RtClickMenu.Name = "RtClickMenu"
        '
        'menubut_NewWindow
        '
        Me.menubut_NewWindow.Caption = "Open Default URL"
        Me.menubut_NewWindow.Id = 0
        Me.menubut_NewWindow.Name = "menubut_NewWindow"
        '
        'menubut_NewWindowCurrent
        '
        Me.menubut_NewWindowCurrent.Caption = "Open Current URL"
        Me.menubut_NewWindowCurrent.Id = 3
        Me.menubut_NewWindowCurrent.Name = "menubut_NewWindowCurrent"
        '
        'menubut_NewURL
        '
        Me.menubut_NewURL.Caption = "Enter New URL"
        Me.menubut_NewURL.Id = 1
        Me.menubut_NewURL.Name = "menubut_NewURL"
        '
        'menubut_CopyURL
        '
        Me.menubut_CopyURL.Caption = "Copy URL"
        Me.menubut_CopyURL.Id = 2
        Me.menubut_CopyURL.Name = "menubut_CopyURL"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.menubut_NewWindow, Me.menubut_NewURL, Me.menubut_CopyURL, Me.menubut_NewWindowCurrent})
        Me.BarManager1.MaxItemId = 4
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(821, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 510)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(821, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 510)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(821, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 510)
        '
        'Form1
        '
        Me.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(88, Byte), Integer))
        Me.Appearance.Options.UseBackColor = True
        Me.ClientSize = New System.Drawing.Size(821, 510)
        Me.Controls.Add(Me.panel_NavBar)
        Me.Controls.Add(Me.panel_App)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.Icon = CType(resources.GetObject("Form1.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.Image = Global.Jumble_v2.My.Resources.Resources.Jumble_Logo
        Me.Name = "Form1"
        Me.Text = "Jumble"
        Me.panel_App.ResumeLayout(False)
        Me.Panel_main.ResumeLayout(False)
        Me.panel_NavButtons.ResumeLayout(False)
        CType(Me.but_Signal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Checklist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Customize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Settings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_removeformatting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Strikethrough, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Reload, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gmail_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gmail_1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Forward, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_back, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_NavBar.ResumeLayout(False)
        Me.panel_Apps.ResumeLayout(False)
        CType(Me.but_More, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Icon2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Icon1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Icon3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Icon4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Icon5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Icon7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Icon6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NotifyManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RtClickMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panel_App As System.Windows.Forms.Panel
    Friend WithEvents panel_NavBar As System.Windows.Forms.Panel
    Friend WithEvents panel_Apps As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents but_Icon6 As System.Windows.Forms.PictureBox
    Friend WithEvents but_Icon1 As System.Windows.Forms.PictureBox
    Friend WithEvents but_Icon2 As System.Windows.Forms.PictureBox
    Friend WithEvents but_Icon4 As System.Windows.Forms.PictureBox
    Friend WithEvents but_Icon5 As System.Windows.Forms.PictureBox
    Friend WithEvents but_Icon7 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents web_2 As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents web_6 As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents web_7 As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents web_5 As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents web_4 As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents web_1 As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents timer_WhatsApp As Timer
    Friend WithEvents TrayIcon As NotifyIcon
    Friend WithEvents NotifyManager As DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager
    Friend WithEvents but_Icon3 As PictureBox
    Friend WithEvents web_3 As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents panel_NavButtons As Panel
    Friend WithEvents but_Forward As PictureBox
    Friend WithEvents but_back As PictureBox
    Friend WithEvents Panel_main As Panel
    Friend WithEvents gmail_1 As PictureBox
    Friend WithEvents gmail_2 As PictureBox
    Friend WithEvents but_More As PictureBox
    Friend WithEvents web_Drive As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents web_Calendar As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents web_Google As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents but_Reload As PictureBox
    Friend WithEvents web_Facebook As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents web_Instagram As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents web_Life360 As CefSharp.WinForms.ChromiumWebBrowser
    Friend WithEvents but_Strikethrough As PictureBox
    Friend WithEvents but_removeformatting As PictureBox
    Friend WithEvents but_Settings As PictureBox
    Friend WithEvents timer_ClearNotifications As Timer
    Friend WithEvents but_Customize As PictureBox
    Friend WithEvents timer_ResetIcons As Timer
    Friend WithEvents Timer_shutdown As Timer
    Friend WithEvents but_Checklist As PictureBox
    Friend WithEvents timer_SkinChange As Timer
    Friend WithEvents but_Signal As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents RtClickMenu As DevExpress.XtraBars.PopupMenu
    Friend WithEvents menubut_NewWindow As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents menubut_NewURL As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents menubut_CopyURL As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents menubut_NewWindowCurrent As DevExpress.XtraBars.BarButtonItem

#End Region

End Class
