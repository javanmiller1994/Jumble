Partial Public Class FormSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSettings))
        Me.but_Ok = New DevExpress.XtraEditors.SimpleButton()
        Me.but_Cancel = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cb_Icon2 = New DevExpress.XtraEditors.CheckEdit()
        Me.cb_Instagram = New DevExpress.XtraEditors.CheckEdit()
        Me.cb_Facebook = New DevExpress.XtraEditors.CheckEdit()
        Me.cb_Life360 = New DevExpress.XtraEditors.CheckEdit()
        Me.cb_Calendar = New DevExpress.XtraEditors.CheckEdit()
        Me.cb_Google = New DevExpress.XtraEditors.CheckEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cb_Startup = New DevExpress.XtraEditors.CheckEdit()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.but_Update = New DevExpress.XtraEditors.SimpleButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb_Icon3 = New DevExpress.XtraEditors.CheckEdit()
        Me.cb_Icon4 = New DevExpress.XtraEditors.CheckEdit()
        Me.cb_Icon5 = New DevExpress.XtraEditors.CheckEdit()
        Me.cb_Icon6 = New DevExpress.XtraEditors.CheckEdit()
        Me.cb_Icon7 = New DevExpress.XtraEditors.CheckEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_Icon1 = New DevExpress.XtraEditors.CheckEdit()
        Me.cb_UserAgent = New DevExpress.XtraEditors.CheckEdit()
        Me.tb_UserAgent = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MemoEdit1 = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.cb_Icon2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Instagram.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Facebook.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Life360.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Calendar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Google.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Startup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Icon3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Icon4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Icon5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Icon6.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Icon7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_Icon1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb_UserAgent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tb_UserAgent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'but_Ok
        '
        Me.but_Ok.AllowFocus = False
        Me.but_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.but_Ok.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.but_Ok.Appearance.Options.UseFont = True
        Me.but_Ok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.but_Ok.Location = New System.Drawing.Point(602, 468)
        Me.but_Ok.Name = "but_Ok"
        Me.but_Ok.Size = New System.Drawing.Size(114, 39)
        Me.but_Ok.TabIndex = 0
        Me.but_Ok.Text = "Okay"
        '
        'but_Cancel
        '
        Me.but_Cancel.AllowFocus = False
        Me.but_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.but_Cancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.but_Cancel.Appearance.Options.UseFont = True
        Me.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.but_Cancel.Location = New System.Drawing.Point(722, 468)
        Me.but_Cancel.Name = "but_Cancel"
        Me.but_Cancel.Size = New System.Drawing.Size(114, 39)
        Me.but_Cancel.TabIndex = 1
        Me.but_Cancel.Text = "Close"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 21)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Load on App Startup:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 105)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Instagram" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Facebook" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Life360" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Calendar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Google Search"
        '
        'cb_Icon2
        '
        Me.cb_Icon2.Location = New System.Drawing.Point(129, 63)
        Me.cb_Icon2.Name = "cb_Icon2"
        Me.cb_Icon2.Properties.AllowFocused = False
        Me.cb_Icon2.Size = New System.Drawing.Size(15, 19)
        Me.cb_Icon2.TabIndex = 6
        '
        'cb_Instagram
        '
        Me.cb_Instagram.Location = New System.Drawing.Point(129, 228)
        Me.cb_Instagram.Name = "cb_Instagram"
        Me.cb_Instagram.Properties.AllowFocused = False
        Me.cb_Instagram.Size = New System.Drawing.Size(15, 19)
        Me.cb_Instagram.TabIndex = 7
        '
        'cb_Facebook
        '
        Me.cb_Facebook.Location = New System.Drawing.Point(129, 249)
        Me.cb_Facebook.Name = "cb_Facebook"
        Me.cb_Facebook.Properties.AllowFocused = False
        Me.cb_Facebook.Size = New System.Drawing.Size(15, 19)
        Me.cb_Facebook.TabIndex = 8
        '
        'cb_Life360
        '
        Me.cb_Life360.Location = New System.Drawing.Point(129, 270)
        Me.cb_Life360.Name = "cb_Life360"
        Me.cb_Life360.Properties.AllowFocused = False
        Me.cb_Life360.Size = New System.Drawing.Size(15, 19)
        Me.cb_Life360.TabIndex = 9
        '
        'cb_Calendar
        '
        Me.cb_Calendar.Location = New System.Drawing.Point(129, 291)
        Me.cb_Calendar.Name = "cb_Calendar"
        Me.cb_Calendar.Properties.AllowFocused = False
        Me.cb_Calendar.Size = New System.Drawing.Size(15, 19)
        Me.cb_Calendar.TabIndex = 10
        '
        'cb_Google
        '
        Me.cb_Google.Location = New System.Drawing.Point(129, 312)
        Me.cb_Google.Name = "cb_Google"
        Me.cb_Google.Properties.AllowFocused = False
        Me.cb_Google.Size = New System.Drawing.Size(15, 19)
        Me.cb_Google.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 358)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(207, 21)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Load App on System Startup"
        '
        'cb_Startup
        '
        Me.cb_Startup.Location = New System.Drawing.Point(225, 362)
        Me.cb_Startup.Name = "cb_Startup"
        Me.cb_Startup.Properties.AllowFocused = False
        Me.cb_Startup.Size = New System.Drawing.Size(15, 19)
        Me.cb_Startup.TabIndex = 12
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RichTextBox1.Location = New System.Drawing.Point(270, 12)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(326, 330)
        Me.RichTextBox1.TabIndex = 13
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'RichTextBox2
        '
        Me.RichTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RichTextBox2.Location = New System.Drawing.Point(602, 12)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.ReadOnly = True
        Me.RichTextBox2.Size = New System.Drawing.Size(234, 330)
        Me.RichTextBox2.TabIndex = 14
        Me.RichTextBox2.Text = resources.GetString("RichTextBox2.Text")
        '
        'but_Update
        '
        Me.but_Update.AllowFocus = False
        Me.but_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.but_Update.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.but_Update.Appearance.Options.UseFont = True
        Me.but_Update.Location = New System.Drawing.Point(477, 468)
        Me.but_Update.Name = "but_Update"
        Me.but_Update.Size = New System.Drawing.Size(119, 39)
        Me.but_Update.TabIndex = 15
        Me.but_Update.Text = "Update Now"
        Me.but_Update.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1500
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 147)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Icon 1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Icon 2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Icon 3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Icon 4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Icon 5" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Icon 6" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Icon 7"
        '
        'cb_Icon3
        '
        Me.cb_Icon3.Location = New System.Drawing.Point(129, 84)
        Me.cb_Icon3.Name = "cb_Icon3"
        Me.cb_Icon3.Properties.AllowFocused = False
        Me.cb_Icon3.Size = New System.Drawing.Size(15, 19)
        Me.cb_Icon3.TabIndex = 6
        '
        'cb_Icon4
        '
        Me.cb_Icon4.Location = New System.Drawing.Point(129, 105)
        Me.cb_Icon4.Name = "cb_Icon4"
        Me.cb_Icon4.Properties.AllowFocused = False
        Me.cb_Icon4.Size = New System.Drawing.Size(15, 19)
        Me.cb_Icon4.TabIndex = 6
        '
        'cb_Icon5
        '
        Me.cb_Icon5.Location = New System.Drawing.Point(129, 126)
        Me.cb_Icon5.Name = "cb_Icon5"
        Me.cb_Icon5.Properties.AllowFocused = False
        Me.cb_Icon5.Size = New System.Drawing.Size(15, 19)
        Me.cb_Icon5.TabIndex = 6
        '
        'cb_Icon6
        '
        Me.cb_Icon6.Location = New System.Drawing.Point(129, 147)
        Me.cb_Icon6.Name = "cb_Icon6"
        Me.cb_Icon6.Properties.AllowFocused = False
        Me.cb_Icon6.Size = New System.Drawing.Size(15, 19)
        Me.cb_Icon6.TabIndex = 6
        '
        'cb_Icon7
        '
        Me.cb_Icon7.Location = New System.Drawing.Point(129, 168)
        Me.cb_Icon7.Name = "cb_Icon7"
        Me.cb_Icon7.Properties.AllowFocused = False
        Me.cb_Icon7.Size = New System.Drawing.Size(15, 19)
        Me.cb_Icon7.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 21)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "More"
        '
        'cb_Icon1
        '
        Me.cb_Icon1.EditValue = True
        Me.cb_Icon1.Enabled = False
        Me.cb_Icon1.Location = New System.Drawing.Point(129, 42)
        Me.cb_Icon1.Name = "cb_Icon1"
        Me.cb_Icon1.Properties.AllowFocused = False
        Me.cb_Icon1.Size = New System.Drawing.Size(15, 19)
        Me.cb_Icon1.TabIndex = 17
        '
        'cb_UserAgent
        '
        Me.cb_UserAgent.Location = New System.Drawing.Point(16, 387)
        Me.cb_UserAgent.Name = "cb_UserAgent"
        Me.cb_UserAgent.Properties.AllowFocused = False
        Me.cb_UserAgent.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_UserAgent.Properties.Appearance.Options.UseFont = True
        Me.cb_UserAgent.Properties.Caption = "Use Custom User Agent"
        Me.cb_UserAgent.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.cb_UserAgent.Size = New System.Drawing.Size(224, 25)
        Me.cb_UserAgent.TabIndex = 18
        Me.cb_UserAgent.ToolTip = "Changes require app restart"
        '
        'tb_UserAgent
        '
        Me.tb_UserAgent.Location = New System.Drawing.Point(16, 418)
        Me.tb_UserAgent.Name = "tb_UserAgent"
        Me.tb_UserAgent.Size = New System.Drawing.Size(224, 20)
        Me.tb_UserAgent.TabIndex = 19
        Me.tb_UserAgent.ToolTip = "Changes require app restart"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(12, 441)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 21)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Sample User Agent:"
        '
        'MemoEdit1
        '
        Me.MemoEdit1.EditValue = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) " &
    "Chrome/70.0.3538.102 Safari/537.36 Edge/18.19582"
        Me.MemoEdit1.Location = New System.Drawing.Point(16, 465)
        Me.MemoEdit1.Name = "MemoEdit1"
        Me.MemoEdit1.Properties.AllowFocused = False
        Me.MemoEdit1.Properties.ReadOnly = True
        Me.MemoEdit1.Size = New System.Drawing.Size(403, 42)
        Me.MemoEdit1.TabIndex = 21
        '
        'FormSettings
        '
        Me.ClientSize = New System.Drawing.Size(848, 519)
        Me.Controls.Add(Me.MemoEdit1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tb_UserAgent)
        Me.Controls.Add(Me.cb_UserAgent)
        Me.Controls.Add(Me.cb_Icon1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.but_Update)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cb_Startup)
        Me.Controls.Add(Me.cb_Google)
        Me.Controls.Add(Me.cb_Calendar)
        Me.Controls.Add(Me.cb_Life360)
        Me.Controls.Add(Me.cb_Facebook)
        Me.Controls.Add(Me.cb_Instagram)
        Me.Controls.Add(Me.cb_Icon7)
        Me.Controls.Add(Me.cb_Icon6)
        Me.Controls.Add(Me.cb_Icon5)
        Me.Controls.Add(Me.cb_Icon4)
        Me.Controls.Add(Me.cb_Icon3)
        Me.Controls.Add(Me.cb_Icon2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.but_Cancel)
        Me.Controls.Add(Me.but_Ok)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.Icon = CType(resources.GetObject("FormSettings.IconOptions.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        CType(Me.cb_Icon2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Instagram.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Facebook.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Life360.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Calendar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Google.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Startup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Icon3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Icon4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Icon5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Icon6.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Icon7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_Icon1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb_UserAgent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tb_UserAgent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MemoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents but_Ok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents but_Cancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cb_Icon2 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cb_Instagram As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cb_Facebook As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cb_Life360 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cb_Calendar As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cb_Google As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents cb_Startup As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents but_Update As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents cb_Icon3 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cb_Icon4 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cb_Icon5 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cb_Icon6 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cb_Icon7 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents cb_Icon1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cb_UserAgent As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tb_UserAgent As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As Label
    Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit

#End Region

End Class
