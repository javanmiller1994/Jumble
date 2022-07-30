Public Class Checklist_form
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged, CheckBox9.CheckedChanged, CheckBox8.CheckedChanged, CheckBox7.CheckedChanged, CheckBox6.CheckedChanged, CheckBox5.CheckedChanged, CheckBox4.CheckedChanged, CheckBox3.CheckedChanged, CheckBox2.CheckedChanged
        Select Case sender.checked
            Case True
                sender.font = New Font("Segoe UI", 12, FontStyle.Strikeout)
            Case False
                sender.font = New Font("Segoe UI", 12, FontStyle.Bold)
        End Select
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Hide()
    End Sub

    Private Sub Checklist_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterForm(Me, Form1)
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

End Class