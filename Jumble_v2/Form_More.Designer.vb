<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_More
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.but_Instagram = New System.Windows.Forms.PictureBox()
        Me.but_Facebook = New System.Windows.Forms.PictureBox()
        Me.but_Google = New System.Windows.Forms.PictureBox()
        Me.but_Drive = New System.Windows.Forms.PictureBox()
        Me.but_Life360 = New System.Windows.Forms.PictureBox()
        Me.but_Calendar = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.but_Instagram, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Facebook, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Google, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Drive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Life360, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.but_Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.but_Google, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.but_Drive, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.but_Instagram, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.but_Facebook, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.but_Calendar, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.but_Life360, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(50, 450)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'but_Instagram
        '
        Me.but_Instagram.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.instagram_logo
        Me.but_Instagram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Instagram.Location = New System.Drawing.Point(3, 77)
        Me.but_Instagram.Name = "but_Instagram"
        Me.but_Instagram.Size = New System.Drawing.Size(44, 50)
        Me.but_Instagram.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.but_Instagram.TabIndex = 2
        Me.but_Instagram.TabStop = False
        '
        'but_Facebook
        '
        Me.but_Facebook.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.facebook_logo_2019
        Me.but_Facebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Facebook.Location = New System.Drawing.Point(3, 151)
        Me.but_Facebook.Name = "but_Facebook"
        Me.but_Facebook.Size = New System.Drawing.Size(44, 50)
        Me.but_Facebook.TabIndex = 6
        Me.but_Facebook.TabStop = False
        '
        'but_Google
        '
        Me.but_Google.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.Google_Icon
        Me.but_Google.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Google.Location = New System.Drawing.Point(3, 373)
        Me.but_Google.Name = "but_Google"
        Me.but_Google.Size = New System.Drawing.Size(44, 50)
        Me.but_Google.TabIndex = 0
        Me.but_Google.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Google, "Google Search")
        '
        'but_Drive
        '
        Me.but_Drive.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.Signal_white
        Me.but_Drive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Drive.Location = New System.Drawing.Point(3, 3)
        Me.but_Drive.Name = "but_Drive"
        Me.but_Drive.Size = New System.Drawing.Size(44, 50)
        Me.but_Drive.TabIndex = 4
        Me.but_Drive.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Drive, "Google Drive")
        '
        'but_Life360
        '
        Me.but_Life360.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.life360_logo
        Me.but_Life360.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Life360.Location = New System.Drawing.Point(3, 225)
        Me.but_Life360.Name = "but_Life360"
        Me.but_Life360.Size = New System.Drawing.Size(44, 50)
        Me.but_Life360.TabIndex = 5
        Me.but_Life360.TabStop = False
        '
        'but_Calendar
        '
        Me.but_Calendar.BackgroundImage = Global.Jumble_v2.My.Resources.Resources.google_calendar
        Me.but_Calendar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.but_Calendar.Location = New System.Drawing.Point(3, 299)
        Me.but_Calendar.Name = "but_Calendar"
        Me.but_Calendar.Size = New System.Drawing.Size(44, 50)
        Me.but_Calendar.TabIndex = 3
        Me.but_Calendar.TabStop = False
        Me.ToolTip1.SetToolTip(Me.but_Calendar, "Google Calendar")
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 1000
        Me.ToolTip1.BackColor = System.Drawing.Color.Gray
        Me.ToolTip1.ForeColor = System.Drawing.Color.White
        Me.ToolTip1.InitialDelay = 250
        Me.ToolTip1.ReshowDelay = 100
        '
        'Form_More
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(50, 450)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_More"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Form_More"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.but_Instagram, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Facebook, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Google, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Drive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Life360, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.but_Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents but_Instagram As PictureBox
    Friend WithEvents but_Facebook As PictureBox
    Friend WithEvents but_Calendar As PictureBox
    Friend WithEvents but_Drive As PictureBox
    Friend WithEvents but_Life360 As PictureBox
    Friend WithEvents but_Google As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
