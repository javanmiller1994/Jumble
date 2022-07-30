Public Class Form_More

#Region " Clicks"

    Private Sub Form_More_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Me.Close()
        Form1.Activate()
    End Sub

    Private Sub Form_More_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Activate()
    End Sub

    Private Sub Form_More_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Form1.Activate()
    End Sub

    Public Sub ButtonClicks(sender As Object, e As EventArgs) Handles but_Life360.Click, but_Instagram.Click, but_Google.Click, but_Facebook.Click, but_Drive.Click, but_Calendar.Click
        Form1.but_Strikethrough.Visible = False
        Form1.but_removeformatting.Visible = False

        Select Case sender.Name
            Case "but_Calendar"
                If Form1.web_Calendar.Address = Nothing Or Form1.web_Calendar.Address = "" Then
                    Form1.web_Calendar.Load("https://calendar.google.com/calendar/u/" & Form1.GoogleAcoount & "/r")
                End If
                Form1.web_Shared = Form1.web_Calendar
            Case "but_Drive"
                Try
                    If Signal_form.proc Is Nothing Then
                        Signal_form.proc = Process.Start("C:\Users\Video Operator\AppData\Local\Programs\signal-desktop\Signal.exe")
                        ' Signal_form.proc.WaitForInputIdle()

                        Form1.SuspendDrawing(Me)
                        Threading.Thread.Sleep(2500)
                        Signal_form.SetParent(Signal_form.proc.MainWindowHandle, Form1.Panel_main.Handle)
                        Signal_form.ChangeStyles()
                        Form1.SuspendDrawing(Form1)
                        Threading.Thread.Sleep(300)
                        Signal_form.SetWindowPos(Signal_form.proc.MainWindowHandle, 0, -15, 0,
                                                 Form1.Panel_main.Width + 27, Form1.Panel_main.Height + 8, Signal_form.SWP_FRAMECHANGED Or Signal_form.SWP_DRAWFRAME Or Signal_form.SWP_NOZORDER)

                        Form1.panel_NavButtons.BringToFront()
                        Form1.web_Shared.BringToFront()
                        Form1.web_Shared.Focus()
                        Form1.ResumeDrawing(Form1)
                    End If
                    Form1.panel_NavButtons.BringToFront()
                    Form1.web_Shared.BringToFront()
                    Form1.web_Shared.Focus()
                    Signal_form.SetParent(Signal_form.proc.MainWindowHandle, Form1.Panel_main.Handle)
                    Signal_form.ChangeStyles()
                    Threading.Thread.Sleep(300)
                    Signal_form.SetWindowPos(Signal_form.proc.MainWindowHandle, 0, -15, 0,
                                             Form1.Panel_main.Width + 27, Form1.Panel_main.Height + 8, Signal_form.SWP_FRAMECHANGED Or Signal_form.SWP_DRAWFRAME Or Signal_form.SWP_NOZORDER)

                    Form1.panel_NavButtons.BringToFront()
                    Form1.panel_NavButtons.BringToFront()
                Catch ex As Exception

                End Try
                Signal_form.Hide()
                ' Form1.web_Shared = Form1.web_Drive
            Case "but_Google"
                If Form1.web_Google.Address = Nothing Or Form1.web_Google.Address = "" Then
                    Form1.web_Google.Load("https://google.com/")
                End If
                Form1.web_Shared = Form1.web_Google
            Case "but_Instagram"
                If Form1.web_Instagram.Address = Nothing Or Form1.web_Instagram.Address = "" Then
                    Form1.web_Instagram.Load("https://instagram.com/")
                End If
                Form1.web_Shared = Form1.web_Instagram
            Case "but_Facebook"
                If Form1.web_Facebook.Address = Nothing Or Form1.web_Facebook.Address = "" Then
                    Form1.web_Facebook.Load("https://facebook.com/")
                End If
                Form1.web_Shared = Form1.web_Facebook
            Case "but_Life360"
                If Form1.web_Life360.Address = Nothing Or Form1.web_Life360.Address = "" Then
                    Form1.web_Life360.Load("https://www.life360.com/circles/#/map")
                End If
                Form1.web_Shared = Form1.web_Life360
        End Select
        Try
            Form1.IsGoogle()
        Catch ex As Exception
        End Try

        If sender.name <> "but_Drive" Then
            Form1.web_Shared.BringToFront()
            Form1.web_Shared.Focus()
        Else
            Threading.Thread.Sleep(350)
            Form1.panel_NavButtons.BringToFront()
            Form1.panel_NavButtons.BringToFront()
            Form1.panel_NavButtons.Focus()
        End If

        Me.Close()
    End Sub



#End Region

#Region " Graphics"
    Dim hover As Boolean = False
    Private Sub but_WhatsApp_MouseEnter(sender As Object, e As EventArgs) Handles but_Calendar.MouseEnter, but_Drive.MouseEnter, but_Google.MouseEnter,
            but_Instagram.MouseEnter, but_Facebook.MouseEnter, but_Life360.MouseEnter
        sender.backcolor = Form1.HoverColor ' Color.Gray
        hover = True

        '   ToolTip1.Show(sender.name.ToString.Replace("but_", ""), sender)
    End Sub

    Private Sub but_WhatsApp_MouseLeave(sender As Object, e As EventArgs) Handles but_Calendar.MouseLeave, but_Drive.MouseLeave, but_Google.MouseLeave,
            but_Instagram.MouseLeave, but_Facebook.MouseLeave, but_Life360.MouseLeave
        sender.backcolor = Color.Transparent ' Color.FromArgb(64, 64, 64)
    End Sub

    Private Sub but_WhatsApp_MouseDown(sender As Object, e As MouseEventArgs) Handles but_Calendar.MouseDown, but_Drive.MouseDown, but_Google.MouseDown,
          but_Instagram.MouseDown, but_Facebook.MouseDown, but_Life360.MouseDown
        sender.backcolor = Form1.PressColor ' Color.DimGray
    End Sub

    Private Sub but_WhatsApp_MouseUp(sender As Object, e As MouseEventArgs) Handles but_Calendar.MouseUp, but_Drive.MouseUp, but_Google.MouseUp,
              but_Instagram.MouseUp, but_Facebook.MouseUp, but_Life360.MouseUp
        If hover Then
            sender.backcolor = Form1.HoverColor 'Color.Gray
        Else
            sender.backcolor = Color.Transparent ' Color.FromArgb(64, 64, 64)
        End If
    End Sub

    Private Sub Form_More_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.BackColor = Form1.DefaultColor

    End Sub






#End Region


End Class