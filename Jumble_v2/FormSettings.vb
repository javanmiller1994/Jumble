Imports CefSharp.WinForms
Imports CefSharp
Imports System.Text.RegularExpressions
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports IWshRuntimeLibrary
Imports System.Net
Imports System.IO

Partial Public Class FormSettings
    Inherits DevExpress.XtraEditors.XtraForm



    Private Sub FormSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeComponent()
        ' Me.Parent = Form1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent

        Me.Location = New Point(Form1.Location.X + Form1.Width \ 2 - Me.Width \ 2, Form1.Location.Y + Form1.Height \ 2 - Me.Height \ 2)


        Me.Text = "Settings - v" & Application.ProductVersion


        cb_Icon2.Checked = My.Settings.Icon2Load
        cb_Icon3.Checked = My.Settings.Icon3Load
        cb_Icon4.Checked = My.Settings.Icon4Load
        cb_Icon5.Checked = My.Settings.Icon5Load
        cb_Icon6.Checked = My.Settings.Icon6Load
        cb_Icon7.Checked = My.Settings.Icon7Load

        cb_Instagram.Checked = My.Settings.LoadInstagram
        cb_Facebook.Checked = My.Settings.LoadFacebook
        cb_Life360.Checked = My.Settings.LoadLife360
        cb_Calendar.Checked = My.Settings.LoadCalendar
        cb_Google.Checked = My.Settings.LoadGoogle
        cb_Startup.Checked = My.Settings.Startup


        cb_UserAgent.Checked = My.Settings.UseCustomUserAgent
        tb_UserAgent.Text = My.Settings.CustomUserAgent

    End Sub

    Private Sub but_Ok_Click(sender As Object, e As EventArgs) Handles but_Ok.Click
        'Form1.GoogleAcoount = 0
        ' Form1.LoadGoogle()
        ' Form1.web_6.Load(My.Settings.Icon6URL)


        My.Settings.Icon2Load = cb_Icon2.Checked
        My.Settings.Icon3Load = cb_Icon3.Checked
        My.Settings.Icon4Load = cb_Icon4.Checked
        My.Settings.Icon5Load = cb_Icon5.Checked
        My.Settings.Icon6Load = cb_Icon6.Checked
        My.Settings.Icon7Load = cb_Icon7.Checked

        My.Settings.LoadInstagram = cb_Instagram.Checked
        My.Settings.LoadFacebook = cb_Facebook.Checked
        My.Settings.LoadLife360 = cb_Life360.Checked
        My.Settings.LoadCalendar = cb_Calendar.Checked
        My.Settings.LoadGoogle = cb_Google.Checked
        My.Settings.Startup = cb_Startup.Checked

        My.Settings.UseCustomUserAgent = cb_UserAgent.Checked
        My.Settings.CustomUserAgent = tb_UserAgent.Text

        My.Settings.Save()
        Form1.but_Settings.BackColor = Color.FromArgb(64, 64, 64)
        Me.Close()

    End Sub

    Private Sub but_Cancel_Click(sender As Object, e As EventArgs) Handles but_Cancel.Click
        Me.Close()
    End Sub

    Private Sub cb_Startup_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Startup.CheckedChanged
        Select Case cb_Startup.Checked
            Case True
                If Not IO.File.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Application.ProductName) & ".lnk") Then
                    Dim WshShell As WshShell = New WshShell()
                    Dim ShortcutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
                    Dim Shortcut As IWshShortcut = CType(WshShell.CreateShortcut(System.IO.Path.Combine(ShortcutPath, Application.ProductName) & ".lnk"), IWshShortcut)
                    Shortcut.TargetPath = Application.ExecutablePath
                    Shortcut.WorkingDirectory = Application.StartupPath
                    Shortcut.Description = "Jumble"
                    Shortcut.Save()
                End If
            Case False
                If IO.File.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Application.ProductName) & ".lnk") Then
                    IO.File.Delete(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Application.ProductName) & ".lnk")
                End If
        End Select

    End Sub

#Region " Check for update"
    Private Sub FormSettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Timer1.Start()
    End Sub
    Public Shared VersionNumber As String
    Public Shared MaxCheck As Integer = 0
    Public Shared Retry As Integer = 0
    Public Shared Function InternetConnection() As Boolean
        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch
            Return False
        End Try

    End Function
    Public Sub GetVersionNumber()
        If InternetConnection() = False Then
            'Form1.ShowMsg("No Internet Connection", "Error", True)
            Exit Sub
        End If
        If Retry >= 2 Then
            Exit Sub
        End If
        If MaxCheck >= 3 Then
            Exit Sub
        End If
        Try
            Dim address As String = "https://www.dropbox.com/s/v1opbu54kwz0cvy/version.txt?dl=1"
            Dim client As WebClient = New WebClient()

            Dim _UserAgent As String = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36"
            client.Headers.Add(HttpRequestHeader.UserAgent, _UserAgent)
            client.Headers.Add("Content-Type", "application / zip, application / octet - stream")
            client.Headers.Add("Accept-Language", "pt-BR, pt;q=0.5")
            client.Headers.Add("Accept", "Text/ html, application / xhtml + Xml, application / Xml;q=0.9,*/*;q=0.8")

            Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
            VersionNumber = reader.ReadToEnd()

            Dim version As String = CInt(VersionNumber.Replace(".", ""))
        Catch ex As Exception
            Retry += 1
        End Try
        MaxCheck += 1

    End Sub
    Public Function CheckForUpdate() As Boolean
        Dim Available As Boolean = False
        If InternetConnection() = False Then
            'Form1.ShowMsg("No Internet Connection", "Error", True)
            Exit Function
        End If
        If Retry >= 2 Then
            Exit Function
        End If
        Try
            GetVersionNumber()

            Dim version As Integer = CInt(VersionNumber.Replace(".", ""))
            If version > CInt(Application.ProductVersion.Replace(".", "")) Then
                Available = True

            Else
                Available = False
            End If

        Catch ex As Exception
            Retry += 1
        End Try

        Return Available

    End Function

    Private Sub but_Update_Click(sender As Object, e As EventArgs) Handles but_Update.Click
        Process.Start("https://www.dropbox.com/s/6nlucqcy6njr8ku/Jumble.exe?dl=1")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If CheckForUpdate() = True Then
            Me.Text = "Settings - v" & Application.ProductVersion & " - Update " & VersionNumber & " Available"
            but_Update.Visible = True
        End If
    End Sub



#End Region



End Class

