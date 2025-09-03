Imports System.IO

Public Class MainForm
    Dim resizeFlag As Boolean
    Dim MinFlag As Boolean

    Dim MFormFlag As Boolean
    Public Property ImageList As ImageList
    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)
        Hotkey_Proc(m)
    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Dim no As Integer
        Dim PlayListColum As String = ""

        Dim NowColum As DataGridViewColumn = PlayListBox.MusicList.Columns.GetFirstColumn(DataGridViewElementStates.Visible)

        If PlayListBox.MusicList.Rows.Count > 0 Then no = PlayInfo.PlayNo Else no = 0 '再生番号

        For cnt = 1 To PlayListBox.MusicList.Columns.GetColumnCount(DataGridViewElementStates.Visible) - 1
            NowColum = PlayListBox.MusicList.Columns.GetNextColumn(NowColum, DataGridViewElementStates.Visible, DataGridViewElementStates.None)
            PlayListColum &= NowColum.Name & ":" & NowColum.Width & ","
        Next
        'mo,no,position,list,volume

        '状態を保存
        DB_Control.Save(no, PlayListColum)

        'Hotkey解除
        Hotkey_UnRegister()

        If PlayRun.IsAlive = True Then PlayRun.Abort()

        Me.Visible = False


        Music.Stopped()
        Music.Close("all")

        TrayIcon.Visible = False
        TrayIcon.Dispose()

        Reset()
        FileClose()
        If IO.Directory.Exists(TempFolder) Then FileIO.FileSystem.DeleteDirectory(TempFolder, FileIO.DeleteDirectoryOption.DeleteAllContents) 'TempfolderClose
        End

    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FileClose()

        TrayIcon.Icon = Me.Icon
        Me.Show()

        SW_Info.Text = ""

        Me.MinimumSize = New System.Drawing.Size(FormMinW, FormMinH)

        'Hotkeyを登録
        Hotkey_Register()

        TimeBox.ResetText()

        Dim instance As ToolStrip
        Dim value As ImageList
        instance = ToolBox

        value = ImageList1

        instance.ImageList = value
        'ToolInage
        OneAddBtm.ImageIndex = 10
        DirAddBtm.ImageIndex = 11
        OneDelBtm.ImageIndex = 18
        AllDelBtm.ImageIndex = 19
        PlayBtm.ImageIndex = 0
        StopBtm.ImageIndex = 2
        PauseBtm.ImageIndex = 4
        BackBtm.ImageIndex = 8
        NextBtm.ImageIndex = 6
        NormalPlayBtm.ImageIndex = 12
        RepeatPlayBtm.ImageIndex = 14
        ShuffleBtm.ImageIndex = 16
        PlayListBtm.ImageIndex = 20
        ListSaveBtm.ImageIndex = 22
        FavoriteBtm.ImageIndex = 23

        ObjectCreate()

        'Status表示用スレッド
        If PlayRun.IsAlive = False Then
            PlayRun = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf PlayRun_Proc))
            PlayRun.IsBackground = True
            PlayRun.Start()
        End If

        PlayInfo.PlayNo = 1
        PlayInfo.PlayIndex = 0

        ButtonOnOff()

        StatusPrintMode = ""

        DB_Control.Load()

        PlayListBox.MdiParent = Me
        PlayList_DockBtm.PerformClick()


Fnot:
        If DB.Tables("PlayListView").Rows.Count <= 0 Then
            Status.Text = "曲を追加してください。"
        Else
            Status.Text = "前回の状態を復元しました。"
        End If
        Status.Times = "--:--/--:--" '時間表示

        If PlayMode = "" Then Button.SetPlayMode("Normal")

        Status.ProcFlag = "WakeUp"
        Status.PlayFlag = "WakeUP"

        PlayListBtm.PerformClick()

        DB.AcceptChanges()

        Button.ButtonOnOff() 'ボタンの有効無効
        hWnd = Me.Handle.ToInt32()
    End Sub
    Private Sub FavoriteBoxBtm_Click(sender As System.Object, e As System.EventArgs) Handles FavoriteBoxBtm.Click
        If FavoriteBoxBtm.Checked = True Then

            FavoriteBox.SetDesktopLocation(Me.DesktopLocation.X + Me.Size.Width, Me.DesktopLocation.Y)
            FavoriteBox.Show(Me)
        Else
            FavoriteBox.Hide()
        End If
    End Sub
    Private Sub PlayList_DockBtm_Click(sender As System.Object, e As System.EventArgs) Handles PlayList_DockBtm.Click 'PlayList -> Dock
        If PlayList_DockBtm.Checked = True Then
            PlayList_WindowBtm.Checked = False

            PlayListBox.MdiParent = Me 'Parent Change

            If PlayListBtm.Checked = True Then PlayListBox.Show()
        Else
            PlayList_WindowBtm.PerformClick()
        End If
    End Sub
    Private Sub PlayList_WindowBtm_Click(sender As System.Object, e As System.EventArgs) Handles PlayList_WindowBtm.Click 'PlayList -> Window
        If PlayList_WindowBtm.Checked = True Then
            PlayList_DockBtm.Checked = False

            PlayListBox.MdiParent = Nothing 'Parent Change

            If PlayListBtm.Checked = True Then PlayListBox.Show()
        Else
            PlayList_DockBtm.PerformClick()
        End If
    End Sub

    Private Sub PlayList_SwBtm_Click(sender As System.Object, e As System.EventArgs) Handles PlayList_SwBtm.Click
        If PlayList_SwBtm.Checked = True Then
            PlayListBox.Show()
        Else
            PlayListBox.Hide()
        End If
    End Sub

    Private Sub ToolBox_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolBox.ItemClicked
        Select Case e.ClickedItem.Name
            Case "OneAddBtm"
                AddNum = 0

                Button.FileOpenDialog()

                OneAddBtm.Checked = False '元に戻す
                Button.ButtonOnOff() 'ボタンの有効無効
            Case "DirAddBtm"
                AddNum = 0
                Button.DirectoryDialog()

            Case "OneDelBtm"
                If OneDelBtm.Checked = False Then '1曲削除
                    Button.MusicOneDel() '削除
                    Beep()
                    OneDelBtm.Checked = False '元に戻す
                End If
            Case "AllDelBtm"
                If AllDelBtm.Checked = False Then '全曲削除
                    Button.MusicAllDel() '削除
                    Beep()
                    AllDelBtm.Checked = False '元に戻す
                End If
            Case "PlayBtm"
                If PlayBtm.Checked = False Then '再生
                    PlayBtm.Checked = True
                    Button.MusicPlay() '再生
                    Status.ScrollNum = 0 'スクロール数
                Else
                    Button.MusicPause() '一時停止
                End If
            Case "StopBtm"
                If StopBtm.Checked = False Then '停止
                    Button.MusicStop(False) '停止
                End If
            Case "PauseBtm"
                If PauseBtm.Checked = False Then '一時停止
                    Button.MusicPause() '一時停止
                Else
                    Button.MusicPlay() '再開
                End If
            Case "BackBtm"
                If BackBtm.Checked = False Then '前曲
                    Button.MusicBack()
                End If
            Case "NextBtm"
                If NextBtm.Checked = False Then '次曲
                    Button.MusicNext()
                End If

            Case "NormalPlayBtm"
                Button.SetPlayMode("Normal")

            Case "RepeatPlayBtm"
                Button.SetPlayMode("Repeat")

            Case "ShuffleBtm"
                ListShuffle()

            Case "ListSaveBtm"
                Button.FileSaveDialog()
                ListSaveBtm.Checked = False '元に戻す

            Case "PlayListBtm"
                If PlayListBtm.Checked = False Then  'プレイリスト
                    PlayListBox.Show()
                Else
                    PlayListBox.Hide()
                End If
            Case "FavoriteBtm"
                FavoriteBoxBtm.PerformClick()
        End Select
        Exit Sub

Cancel:
        OneAddBtm.Checked = False '元に戻す
    End Sub

    Private Sub Slider_Scroll(sender As System.Object, e As System.EventArgs) Handles Slider.Scroll   '早送り・巻き戻し
        Music.MovePosition(Slider.Value) '再生位置変更
    End Sub

    Private Sub VolumeVal_ValueChanged(sender As System.Object, e As System.EventArgs) Handles VolumeVal.ValueChanged        '音量変更
        Music.VolumeChange(Convert.ToInt32(VolumeVal.Value))
    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
            Me.Hide()
            TrayIcon.Visible = True
        End If
    End Sub
    Private Sub TrayIcon_Click(sender As Object, e As EventArgs) Handles TrayIcon.Click
        Me.Show()
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Activate()
        TrayIcon.Visible = False
    End Sub

End Class
