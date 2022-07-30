Imports DevExpress.XtraBars.Helpers
Imports DevExpress.XtraEditors

Public Class CustomizeForm
    Inherits DevExpress.XtraEditors.XtraForm

#Region " Declarations"
    Dim Image1 As String = My.Settings.Icon1Image
    Dim Image2 As String = My.Settings.Icon2Image
    Dim Image3 As String = My.Settings.Icon3Image
    Dim Image4 As String = My.Settings.Icon4Image
    Dim Image5 As String = My.Settings.Icon5Image
    Dim Image6 As String = My.Settings.Icon6Image
    Dim Image7 As String = My.Settings.Icon7Image

    Dim Loading As Boolean = True

#End Region


    Private Sub CustomizeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' InitializeComponent()
        ImageLoader.InitialDirectory = Application.StartupPath & "\Icons"
        ImageLoader.FileName = "" 'Application.StartupPath & "\Icons"

        SkinGallery.Gallery.RowCount = 6
        SkinGallery.Gallery.ColumnCount = 5
        SkinHelper.InitSkinGallery(SkinGallery)


        '#Region "Optional Settings"
        'Uncomment these lines to modify the gallery
        '---Enlarge item images

        SkinGallery.Gallery.ImageSize = New Size(25, 25)

        SkinGallery.Gallery.AllowHoverImages = False
        '---Hide item and group captions
        SkinGallery.Gallery.ShowItemText = True
        SkinGallery.Gallery.ShowGroupCaption = True
        '---Hide group selector
        SkinGallery.Gallery.AllowFilter = False
        '---Remove "Custom Skins" and "Theme Skins" groups
        SkinGallery.Gallery.Groups.RemoveAt(3)
        SkinGallery.Gallery.Groups.RemoveAt(2)
        '#End Region

        tb_Icon1Name.Text = My.Settings.Icon1Name
        tb_Icon2Name.Text = My.Settings.Icon2Name
        tb_Icon3Name.Text = My.Settings.Icon3Name
        tb_Icon4Name.Text = My.Settings.Icon4Name
        tb_Icon5Name.Text = My.Settings.Icon5Name
        tb_Icon6Name.Text = My.Settings.Icon6Name
        tb_Icon7Name.Text = My.Settings.Icon7Name

        tb_Icon1URL.Text = My.Settings.Icon1URL
        tb_Icon2URL.Text = My.Settings.Icon2URL
        tb_Icon3URL.Text = My.Settings.Icon3URL
        tb_Icon4URL.Text = My.Settings.Icon4URL
        tb_Icon5URL.Text = My.Settings.Icon5URL
        tb_Icon6URL.Text = My.Settings.Icon6URL
        tb_Icon7URL.Text = My.Settings.Icon7URL


        If My.Settings.Icon1Image = "" Then
            pb_Icon1.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\blank_app.png")
            'pb_Icon1.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\Icon1.png")
        Else
            pb_Icon1.BackgroundImage = Image.FromFile(My.Settings.Icon1Image)
        End If


        If My.Settings.Icon2Image = "" Then
            pb_Icon2.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\blank_app.png")
            ' pb_Icon2.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\Icon2.png")
        Else
            pb_Icon2.BackgroundImage = Image.FromFile(My.Settings.Icon2Image)
        End If


        If My.Settings.Icon3Image = "" Then
            pb_Icon3.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\blank_app.png")
            ' pb_Icon3.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\Icon3.png")
        Else
            pb_Icon3.BackgroundImage = Image.FromFile(My.Settings.Icon3Image)
        End If


        If My.Settings.Icon4Image = "" Then
            pb_Icon4.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\blank_app.png")
            ' pb_Icon4.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\Icon4.png")
        Else
            pb_Icon4.BackgroundImage = Image.FromFile(My.Settings.Icon4Image)
        End If


        If My.Settings.Icon5Image = "" Then
            pb_Icon5.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\blank_app.png")
            ' pb_Icon5.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\Icon5.png")
        Else
            pb_Icon5.BackgroundImage = Image.FromFile(My.Settings.Icon5Image)
        End If


        If My.Settings.Icon6Image = "" Then
            pb_Icon6.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\blank_app.png")
            'pb_Icon6.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\Icon6.png")
        Else
            pb_Icon6.BackgroundImage = Image.FromFile(My.Settings.Icon6Image)
        End If


        If My.Settings.Icon7Image = "" Then
            pb_Icon7.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\blank_app.png")
            'pb_Icon7.BackgroundImage = Image.FromFile(Application.StartupPath & "\Icons\Icon7.png")
        Else
            pb_Icon7.BackgroundImage = Image.FromFile(My.Settings.Icon7Image)
        End If

        cb_Rounded.Checked = My.Settings.RoundedCorners

        '   Me.Refresh()

        Loading = False
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles but_Okay.Click
        My.Settings.Icon1Name = tb_Icon1Name.Text
        My.Settings.Icon2Name = tb_Icon2Name.Text
        My.Settings.Icon3Name = tb_Icon3Name.Text
        My.Settings.Icon4Name = tb_Icon4Name.Text
        My.Settings.Icon5Name = tb_Icon5Name.Text
        My.Settings.Icon6Name = tb_Icon6Name.Text
        My.Settings.Icon7Name = tb_Icon7Name.Text

        My.Settings.Icon1URL = tb_Icon1URL.Text
        My.Settings.Icon2URL = tb_Icon2URL.Text
        My.Settings.Icon3URL = tb_Icon3URL.Text
        My.Settings.Icon4URL = tb_Icon4URL.Text
        My.Settings.Icon5URL = tb_Icon5URL.Text
        My.Settings.Icon6URL = tb_Icon6URL.Text
        My.Settings.Icon7URL = tb_Icon7URL.Text



        Try

            ' Image.FromFile(Image1).Save(Application.StartupPath & "\Icons\Icon1.png", Drawing.Imaging.ImageFormat.Png)
            ' IO.File.Copy(Image1, Application.StartupPath & "\Icons\Icon1.png", True)
            ' pb_Icon1.BackgroundImage.Save(Application.StartupPath & "\Icons\Icon1.png", Drawing.Imaging.ImageFormat.Png)  'My.Settings.Icon1Image = Image1
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Try
            '   pb_Icon2.BackgroundImage.Save(Application.StartupPath & "\Icons\Icon2.png", Drawing.Imaging.ImageFormat.Png)  'My.Settings.Icon2Image = Image2
        Catch ex As Exception
        End Try
        Try
            '  pb_Icon3.BackgroundImage.Save(Application.StartupPath & "\Icons\Icon3.png", Drawing.Imaging.ImageFormat.Png) 'My.Settings.Icon3Image = Image3
        Catch ex As Exception
        End Try
        Try
            ' pb_Icon4.BackgroundImage.Save(Application.StartupPath & "\Icons\Icon4.png", Drawing.Imaging.ImageFormat.Png)  'My.Settings.Icon4Image = Image4
        Catch ex As Exception
        End Try
        Try
            'pb_Icon5.BackgroundImage.Save(Application.StartupPath & "\Icons\Icon5.png", Drawing.Imaging.ImageFormat.Png)  'My.Settings.Icon5Image = Image5
        Catch ex As Exception
        End Try
        Try
            'pb_Icon6.BackgroundImage.Save(Application.StartupPath & "\Icons\Icon6.png", Drawing.Imaging.ImageFormat.Png)  'My.Settings.Icon6Image = Image6
        Catch ex As Exception
        End Try
        Try
            '  pb_Icon7.BackgroundImage.Save(Application.StartupPath & "\Icons\Icon7.png", Drawing.Imaging.ImageFormat.Png)  'My.Settings.Icon7Image = Image7
        Catch ex As Exception
        End Try

        ' If My.Settings.SkinName <> SkinSelector.SelectedItem.ToString Then
        '   My.Settings.SkinName = SkinSelector.SelectedItem.ToString
        '   Form1.ChangeSkin()
        '  End If


        My.Settings.Icon1Image = Image1
        My.Settings.Icon2Image = Image2
        My.Settings.Icon3Image = Image3
        My.Settings.Icon4Image = Image4
        My.Settings.Icon5Image = Image5
        My.Settings.Icon6Image = Image6
        My.Settings.Icon7Image = Image7

        My.Settings.Save()

        Form1.but_Customize.BackColor = Color.FromArgb(64, 64, 64)
        Me.Close()
    End Sub

    Private Sub pb_Icon1_Click(sender As Object, e As EventArgs) Handles pb_Icon7.Click, pb_Icon6.Click, pb_Icon5.Click, pb_Icon4.Click, pb_Icon3.Click, pb_Icon2.Click, pb_Icon1.Click
        If ImageLoader.ShowDialog = DialogResult.OK Then
            Dim img As String = ImageLoader.FileName
            Select Case sender.name
                Case "pb_Icon1"
                    Image1 = img
                    pb_Icon1.BackgroundImage = Image.FromFile(img)
                Case "pb_Icon2"
                    Image2 = img
                    pb_Icon2.BackgroundImage = Image.FromFile(img)
                Case "pb_Icon3"
                    Image3 = img
                    pb_Icon3.BackgroundImage = Image.FromFile(img)
                Case "pb_Icon4"
                    Image4 = img
                    pb_Icon4.BackgroundImage = Image.FromFile(img)
                Case "pb_Icon5"
                    Image5 = img
                    pb_Icon5.BackgroundImage = Image.FromFile(img)
                Case "pb_Icon6"
                    Image6 = img
                    pb_Icon6.BackgroundImage = Image.FromFile(img)
                Case "pb_Icon7"
                    Image7 = img
                    pb_Icon7.BackgroundImage = Image.FromFile(img)
            End Select

        End If
        hover = False
    End Sub

    Private Sub CustomizeForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form1.but_Customize.BackColor = Color.FromArgb(64, 64, 64)
    End Sub


#Region " Graphics"
    Dim hover As Boolean = False
    Private Sub pb_Icons_MouseEnter(sender As Object, e As EventArgs) Handles pb_Icon7.MouseEnter, pb_Icon6.MouseEnter, pb_Icon5.MouseEnter, pb_Icon4.MouseEnter,
        pb_Icon3.MouseEnter, pb_Icon2.MouseEnter, pb_Icon1.MouseEnter
        sender.backcolor = Form1.HoverColor ' Color.Gray
        hover = True
    End Sub


    Private Sub pb_Icons_MouseLeave(sender As Object, e As EventArgs) Handles pb_Icon7.MouseLeave, pb_Icon6.MouseLeave, pb_Icon5.MouseLeave, pb_Icon4.MouseLeave,
        pb_Icon3.MouseLeave, pb_Icon2.MouseLeave, pb_Icon1.MouseLeave
        sender.backcolor = Color.Transparent 'Color.FromArgb(88, 88, 88)
    End Sub

    Private Sub pb_Icons_MouseDown(sender As Object, e As MouseEventArgs) Handles pb_Icon7.MouseDown, pb_Icon6.MouseDown, pb_Icon5.MouseDown, pb_Icon4.MouseDown,
        pb_Icon3.MouseDown, pb_Icon2.MouseDown, pb_Icon1.MouseDown
        sender.backcolor = Form1.PressColor ' color.DimGray
    End Sub

    Private Sub pb_Icons_MouseUp(sender As Object, e As MouseEventArgs) Handles pb_Icon7.MouseUp, pb_Icon6.MouseUp, pb_Icon5.MouseUp, pb_Icon4.MouseUp,
        pb_Icon3.MouseUp, pb_Icon2.MouseUp, pb_Icon1.MouseUp
        If hover Then
            If sender.name <> "but_Settings" Then
                sender.backcolor = Form1.HoverColor ' Color.Gray
            Else
                sender.backcolor = Color.Transparent 'Color.FromArgb(88, 88, 88)
            End If

        Else
            sender.backcolor = Color.Transparent ' Color.FromArgb(88, 88, 88)
        End If
    End Sub


    Private Sub GalleryControl1_Gallery_ItemClick(sender As Object, e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles SkinGallery.Gallery.ItemClick

        Form1.ChangeSkin()
    End Sub

    Private Sub cb_Rounded_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Rounded.CheckedChanged
        If Loading Then Return


        My.Settings.RoundedCorners = cb_Rounded.Checked
        My.Settings.Save()
        Form1.ChangeSkin()


    End Sub






#End Region

End Class