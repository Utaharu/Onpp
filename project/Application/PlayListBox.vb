Public Class PlayListBox

    Dim SortList As New ArrayList'ソート順管理
    Private Sub PlayListBox_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing 'FormClose
        If e.CloseReason <> CloseReason.MdiFormClosing Then
            e.Cancel = True
            Me.Visible = False
        End If
    End Sub
    Private Sub PlayListBox_FormLoad(sender As Object, e As System.EventArgs) Handles Me.Load 'FormLoad
        MusicList.DataSource = MainForm.DB
        MusicList.DataMember = MainForm.DB.Tables("PlayListView").TableName

        'PlayListColum
        If MainForm.DB.Tables("ConfigData").Rows.Count > 0 Then
            Dim ColuMusicList() As String = MainForm.DB.Tables("ConfigData").Rows(0).Item("PlayListColum").ToString.Split(CChar(","))
            Dim CSizeList(MusicList.Columns.Count - 1) As Integer
            'ColumSize分解
            For cnt = 0 To ColuMusicList.Count - 1
                If ColuMusicList(cnt).Split(CChar(":"))(0) <> "" Then
                    CSizeList(cnt) = Convert.ToInt32(ColuMusicList(cnt).Split(CChar(":"))(1)) 'ColumSize
                    ColuMusicList(cnt) = ColuMusicList(cnt).Split(CChar(":"))(0) 'ColumName
                End If
            Next

            'Colum表示の並び替え及び、サイズ復元
            For cnt = 1 To MusicList.Columns.Count - 1
                If MusicList.Columns(cnt).Name <> "" Then
                    Dim GetIndex As Integer = Array.IndexOf(ColuMusicList, MusicList.Columns(cnt).Name) 'リストにColumが有るか
                    If GetIndex < 0 Then
                        MusicList.Columns(cnt).Visible = False
                    Else
                        If CSizeList(cnt) > 0 Then MusicList.Columns(cnt).Width = CSizeList(GetIndex) 'ColumSize
                        MusicList.Columns(cnt).DisplayIndex = GetIndex + 1 'DisplayViewIndex
                        MusicList.Columns(cnt).Visible = True
                    End If
                End If
            Next

        End If

        If PlayInfo.PlayIndex <= 0 Then PlayInfo.PlayIndex = 0
        If MusicList.Rows.Count > 0 And PlayInfo.PlayIndex >= 0 And PlayInfo.PlayIndex <= MusicList.Rows.Count Then
            MusicList.CurrentCell = MusicList.Rows(PlayInfo.PlayIndex).Cells("No") '曲選択
        End If

        'StatusBar
        If PlayInfo.PlayIndex >= 0 Then
            MainForm.MusicNum.Text = (PlayInfo.PlayIndex + 1) & " / " & MainForm.DB.Tables("PlayListView").Rows.Count.ToString
        Else
            MainForm.MusicNum.Text = PlayInfo.PlayIndex & " / " & MainForm.DB.Tables("PlayListView").Rows.Count.ToString
        End If

        Button.MusicListMenuOnOff()
    End Sub
    Private Sub MusicList_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MusicList.KeyDown  'MusicList上でDelete
        If e.KeyCode = Keys.Delete Then
            If MusicList.SelectedRows.Count > 0 Then
                Button.MusicOneDel() '1曲削除
                Beep()
            End If
        End If
    End Sub
    Private Sub MusicList_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles MusicList.CellMouseDoubleClick      'Itemクリック
        If e.RowIndex >= 0 Then
            MainForm.StopBtm.PerformClick()  '停止
            MainForm.PlayBtm.PerformClick() '再生
        End If
    End Sub
    Private Sub MusicList_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles MusicList.ColumnHeaderMouseClick   'Sort
        'ProgramaticSort
        If e.ColumnIndex > 0 Then
            'Selected SortKey StatusChange 選択されたソートキーの状態変更
            If SortList.IndexOf(MusicList.Columns(e.ColumnIndex).Name) < 0 Then SortList.Add(MusicList.Columns(e.ColumnIndex).Name) 'ソート順の記録
            If MusicList.Columns(e.ColumnIndex).HeaderCell.SortGlyphDirection = SortOrder.None Then 'None->DESC
                MusicList.Columns(e.ColumnIndex).HeaderCell.SortGlyphDirection = SortOrder.Descending

            ElseIf MusicList.Columns(e.ColumnIndex).HeaderCell.SortGlyphDirection = SortOrder.Descending Then
                MusicList.Columns(e.ColumnIndex).HeaderCell.SortGlyphDirection = SortOrder.Ascending
            ElseIf MusicList.Columns(e.ColumnIndex).HeaderCell.SortGlyphDirection = SortOrder.Ascending Then 'ASC->None
                MusicList.Columns(e.ColumnIndex).HeaderCell.SortGlyphDirection = SortOrder.None
                MusicList.Columns(e.ColumnIndex).HeaderText = Mainform.DB.Tables("PlayListData").Columns(MusicList.Columns(e.ColumnIndex).Name).Caption
                If SortList.IndexOf(MusicList.Columns(e.ColumnIndex).Name) >= 0 Then SortList.RemoveAt(SortList.IndexOf(MusicList.Columns(e.ColumnIndex).Name)) 'ソート順の削除
            End If

            'ソートキー順にソート用コマンド生成
            Dim SortCmd As String = ""
            For Each colmname As String In SortList
                If MusicList.Columns(colmname).HeaderCell.SortGlyphDirection = SortOrder.Descending Then
                    If SortCmd <> "" Then SortCmd &= ","
                    SortCmd &= MusicList.Columns(colmname).Name & " " & "DESC"
                ElseIf MusicList.Columns(colmname).HeaderCell.SortGlyphDirection = SortOrder.Ascending Then 'ASC->None
                    If SortCmd <> "" Then SortCmd &= ","
                    SortCmd &= MusicList.Columns(colmname).Name & " " & "ASC"
                End If

            Next

            MusicList.SuspendLayout()


            Dim sorttable As Data.DataTable
            sorttable = Mainform.DB.Tables("PlayListData").Clone '構造をコピー
            sorttable.TableName = "SortTable"
            sorttable.Rows.Clear()

            'ついでにPlayListViewのソートを解除する為に、PlayListDataをリロード
            Mainform.DB.Tables("PlayListData").WriteXml(Application.StartupPath & "\sort_tmp.xml")
            Mainform.DB.Tables("PlayListData").Clear()
            Mainform.DB.Tables("PlayListData").ReadXml(Application.StartupPath & "\sort_tmp.xml")
            If IO.File.Exists(Application.StartupPath & "\sort_tmp.xml") = True Then IO.File.Delete(Application.StartupPath & "\sort_tmp.xml") '削除

            'Sort
            Dim tcol() As Data.DataRow = Mainform.DB.Tables("PlayListView").Select(Nothing, SortCmd)

            'Sorted Table Make Proc
            For Each row As Data.DataRow In tcol
                sorttable.Rows.Add(row.ItemArray)
            Next

            'PlayListViewに反映
            Mainform.DB.Tables("PlayListView").Rows.Clear()
            Mainform.DB.Tables("PlayListView").Load(sorttable.CreateDataReader)
            sorttable.Dispose()


            ' If DB.Tables("PlayListView").Rows.IndexOf(DB.Tables("PlayListView").Rows.Find(PlayInfo.PlayNo)) > -1 Then
            If GetTableIndex("PlayListView", PlayInfo.PlayNo) > -1 Then

                MusicList.CurrentCell = MusicList.Rows(GetTableIndex("PlayListView", PlayInfo.PlayNo)).Cells("No") '移動後の再生アイテム位置をcurrentに指定
            End If

            MusicList.ResumeLayout()


            Dim sortTarget() As String = SortCmd.Split(CChar(","))
            For Each val As String In sortTarget
                If val <> "" Then
                    Dim cname As String = val.Split(CChar(" "))(0)
                    If val.Split(CChar(" "))(1) = "DESC" Then
                        MusicList.Columns(cname).HeaderText = Mainform.DB.Tables("PlayListData").Columns(cname).Caption & "▼"
                        MusicList.Columns(cname).HeaderCell.SortGlyphDirection = SortOrder.Descending 'DESC->ASC

                    End If
                    If val.Split(CChar(" "))(1) = "ASC" Then
                        MusicList.Columns(cname).HeaderText = Mainform.DB.Tables("PlayListData").Columns(cname).Caption & "△"
                        MusicList.Columns(cname).HeaderCell.SortGlyphDirection = SortOrder.Ascending
                    End If
                End If
            Next

        End If

    End Sub

    Private Sub MusicList_CurrentCellChanged(sender As Object, e As System.EventArgs) Handles MusicList.CurrentCellChanged
        If IsNothing(MusicList.CurrentCell) = False Then MusicList.Focus()
    End Sub
    Private Sub PlayNoViewBtm_Click(sender As System.Object, e As System.EventArgs) Handles PlayNoViewBtm.Click 'ViewColum - No
        If PlayNoViewBtm.Checked = False Then MusicList.Columns("No").Visible = False Else MusicList.Columns("No").Visible = True
    End Sub

    Private Sub TitleViewBtm_Click(sender As System.Object, e As System.EventArgs) Handles TitleViewBtm.Click 'ViewColum - Title
        If TitleViewBtm.Checked = False Then MusicList.Columns("Title").Visible = False Else MusicList.Columns("Title").Visible = True
    End Sub

    Private Sub SubTitleViewBtm_Click(sender As System.Object, e As System.EventArgs) Handles SubTitleViewBtm.Click 'ViewColum - SubTitle
        If SubTitleViewBtm.Checked = False Then MusicList.Columns("SubTitle").Visible = False Else MusicList.Columns("SubTitle").Visible = True
    End Sub

    Private Sub TimeViewBtm_Click(sender As System.Object, e As System.EventArgs) Handles TimeViewBtm.Click 'ViewColum - PlayTime
        If TimeViewBtm.Checked = False Then MusicList.Columns("PlayTime").Visible = False Else MusicList.Columns("PlayTime").Visible = True
    End Sub

    Private Sub ArtistViewBtm_Click(sender As System.Object, e As System.EventArgs) Handles ArtistViewBtm.Click 'ViewColum - Artist
        If ArtistViewBtm.Checked = False Then MusicList.Columns("Artist").Visible = False Else MusicList.Columns("Artist").Visible = True
    End Sub

    Private Sub AlbumViewBtm_Click(sender As System.Object, e As System.EventArgs) Handles AlbumViewBtm.Click 'ViewColum - Album
        If AlbumViewBtm.Checked = False Then MusicList.Columns("Album").Visible = False Else MusicList.Columns("Album").Visible = True
    End Sub

    Private Sub BitrateViewBtm_Click(sender As System.Object, e As System.EventArgs) Handles BitrateViewBtm.Click 'ViewColum - Bitrate
        If BitrateViewBtm.Checked = False Then MusicList.Columns("Bitrate").Visible = False Else MusicList.Columns("Bitrate").Visible = True
    End Sub

    Private Sub SamplerateViewBtm_Click(sender As System.Object, e As System.EventArgs) Handles SamplerateViewBtm.Click 'ViewColum - Samplerate
        If SamplerateViewBtm.Checked = False Then MusicList.Columns("Samplerate").Visible = False Else MusicList.Columns("Samplerate").Visible = True
    End Sub

    Private Sub PathViewBtm_Click(sender As System.Object, e As System.EventArgs) Handles PathViewBtm.Click 'ViewColum - Path
        If PathViewBtm.Checked = False Then MusicList.Columns("Path").Visible = False Else MusicList.Columns("Path").Visible = True
    End Sub

    Private Sub FileSizeViewBtm_Click(sender As System.Object, e As System.EventArgs) Handles FileSizeViewBtm.Click 'ViewColum - FileSize
        If FileSizeViewBtm.Checked = False Then MusicList.Columns("FileSize").Visible = False Else MusicList.Columns("FileSize").Visible = True
    End Sub

    Private Sub PlayListBox_VisibleChanged(sender As Object, e As System.EventArgs) Handles Me.VisibleChanged
        MainForm.PlayListBtm.Checked = Me.Visible
        Select Case Me.Visible
            Case True
                '                Me.ClientSize = New System.Drawing.Size(FormMaxW, FormMaxH)
                Select Case MainForm.PlayList_DockBtm.Checked
                    Case True 'PlayList -> Dock
                        MainForm.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable 'PlayList Dock -> MainForm Max
                        MainForm.StatusBar.SizingGrip = True
                        MainForm.ClientSize = New System.Drawing.Size(Me.Width, FormMaxH)
                        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                        Me.Dock = DockStyle.Fill

                    Case False 'PlayList -> Window
                        MainForm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                        MainForm.StatusBar.SizingGrip = False
                        MainForm.ClientSize = New System.Drawing.Size(FormMinW - 20, FormMinH) 'PlayList Window -> MainForm Small

                        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
                        Me.Dock = DockStyle.None
                End Select
                MainForm.PlayListBtm.ImageIndex = 21 'ON
                MainForm.PlayList_SwBtm.Checked = True


            Case False
                '                Me.ClientSize = New System.Drawing.Size(FormMinW, FormMinH)
                MainForm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                MainForm.StatusBar.SizingGrip = False
                MainForm.ClientSize = New System.Drawing.Size(FormMinW - 20, FormMinH)


                MainForm.PlayListBtm.ImageIndex = 20 'OFf()
                MainForm.PlayList_SwBtm.Checked = False
                Me.Dock = DockStyle.None
        End Select


    End Sub

    Private Sub MusicList_CellValueNeeded(sender As Object, e As DataGridViewCellValueEventArgs) Handles MusicList.CellValueNeeded
        Try

            If e.RowIndex <= MainForm.DB.Tables("PlayListData").Rows.Count - 1 Then

                If e.ColumnIndex = MusicList.Columns("State").Index Then
                    If e.RowIndex = GetTableIndex("PlayListView", PlayInfo.PlayNo) Then
                        e.Value = PlayMarker
                    Else
                        e.Value = DBNull.Value
                    End If
                ElseIf e.ColumnIndex = MusicList.Columns("FileSize").Index Then
                    'PlayListData - FileSizeSearch -> FileSize Unit String Print
                    If Convert.ToInt32(MainForm.DB.Tables("PlayListData").Rows(e.RowIndex).Item("FileSize")) > 0 Then

                        Dim sv As Double = Convert.ToInt32(MainForm.DB.Tables("PlayListData").Rows.Find(MainForm.DB.Tables("PlayListView").Rows(e.RowIndex).Item("No")).Item("FileSize"))
                        Dim unit() As String = {"B", "KB", "MB", "GB", "TB"}
                        For A = 0 To unit.Length - 1
                            If (sv / 1024) >= 1 Then
                                sv /= 1024
                            Else
                                e.Value = Format(sv, "###.##") & unit(A)
                                Exit For
                            End If
                        Next
                    Else
                        e.Value = DBNull.Value
                    End If
                ElseIf e.ColumnIndex = MusicList.Columns("PlayTime").Index Then
                    'PlayListData - Playtime Search -> PlaytimeString Print
                    If Convert.ToInt32(MainForm.DB.Tables("PlayListData").Rows(e.RowIndex).Item("PlayTime")) > 0 And IsNothing(e.Value) = True Then

                        e.Value = TS_Change(Convert.ToInt32(MainForm.DB.Tables("PlayListData").Rows.Find(MainForm.DB.Tables("PlayListView").Rows(e.RowIndex).Item("No")).Item("PlayTime")))
                    Else
                        e.Value = DBNull.Value
                    End If
                End If
            End If
            Exit Sub
        Catch
        End Try
    End Sub
End Class