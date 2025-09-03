Module Button
    Public Sub MusicOneDel() '1曲削除
        Dim CNo As Integer
        If PlayListBox.MusicList.SelectedRows.Count > 0 Then CNo = GetTableIndex("PlayListData", Convert.ToInt32(PlayListBox.MusicList.SelectedRows(0).Cells("No").Value))

        If PlayListBox.MusicList.Rows.Count > 0 Then '曲の有無
            If MainForm.PlayBtm.Checked = False And MainForm.PauseBtm.Checked = False Then
                MainForm.DB.Tables("PlayListData").Rows.RemoveAt(CNo) '削除
                PlayListBox.MusicList.SuspendLayout()
                MainForm.DB.AcceptChanges()

                Status.Text = "1曲削除しました。" '状態
                Button.ButtonOnOff() 'ボタンの有効無効
                Music.Close("all")
                If PlayListBox.MusicList.Rows.Count > 0 Then '曲の有無
                    If PlayListBox.MusicList.Rows.Count > CNo Then  '曲が後ろにまだあれば
                        PlayListBox.MusicList.CurrentCell = PlayListBox.MusicList.Rows(CNo).Cells("No") '同じ位置選択
                    Else '無ければ
                        PlayListBox.MusicList.CurrentCell = PlayListBox.MusicList.Rows(CNo - 1).Cells("No") '1曲前を選択
                    End If
                End If
                Button.ButtonOnOff() 'ボタンの有無効
            Else
                Status.Text = "再生中か一時停止中の為、削除できません。" '状態
            End If
        Else
            Status.Text = "曲が追加されていません。" '状態
        End If
    End Sub
    Public Sub MusicAllDel() '全曲削除
        If MainForm.PlayBtm.Checked = False And MainForm.PauseBtm.Checked = False Then
            MainForm.DB.Tables("PlayListData").Rows.Clear() '消去

            Status.Text = "全曲削除しました。" '状態
            Button.ButtonOnOff() 'ボタンの有効無効
            Music.Close("all")

            StatusPrintMode = ""
            PlayInfo.PlayNo = 1
            PlayInfo.PlayIndex = 0
            PlayInfo.NowFiles = ""

            '            PlayRun.Abort()
        Else
            Status.Text = "再生中か一時停止中の為、削除できません。" '状態
        End If
    End Sub

    Public Sub MusicPlay() '再生
        Status.Text = ""

        If PlayListBox.MusicList.Rows.Count > 0 Then

            Button.PlayButtonReset() 'ボタンをOFF

            'PlayBtm = On
            MainForm.PlayBtm.ImageIndex = 1
            MainForm.PlayBtm.Checked = True
            MainForm.PlayBtm.CheckState = CheckState.Indeterminate

            If Status.PlayFlag <> "Pause" Then
                If PlayInfo.NowFiles <> "" Then Music.Close(PlayInfo.NowFiles) '前曲を閉じる
                PlayInfo.PlayNo = Convert.ToInt32(PlayListBox.MusicList.SelectedRows(0).Cells("No").Value) '再生番号
                PlayInfo.PlayIndex = GetTableIndex("PlayListView", PlayInfo.PlayNo) '再生リスト番号(ListIndex)
                PlayInfo.NowFiles = PlayListBox.MusicList.Rows(PlayInfo.PlayIndex).Cells("Path").Value.ToString
                Status.PlayFlag = "Stop"
            End If
            PlayListBox.MusicList.CurrentCell = PlayListBox.MusicList.Rows(PlayInfo.PlayIndex).Cells("Title") '再生曲を選択
            PlayListBox.MusicList.Refresh()

            'StatusBar
            MainForm.MusicNum.Text = (PlayInfo.PlayIndex + 1) & " / " & MainForm.DB.Tables("PlayListView").Rows.Count.ToString

            'TaskBaloon

            InfoBox.Invoke(
                    Sub()

                        Dim B_Title As String
                        If Status.PlayFlag <> "Pause" Then B_Title = "再生" Else B_Title = "再開"
                        PopUp_Dialog(
                                B_Title,
                                MainForm.DB.Tables("PlayListView").Rows(PlayInfo.PlayIndex).Item("Title").ToString,
                                MainForm.DB.Tables("PlayListView").Rows(PlayInfo.PlayIndex).Item("Artist").ToString,
                                TS_Change(Convert.ToInt32(MainForm.DB.Tables("PlayListData").Rows(PlayInfo.PlayIndex).Item("PlayTime")))
                        )

                    End Sub
                )

            If Status.ProcFlag <> "PlayRequesting" Then Status.ProcFlag = "PlayRequest"

            StatusPrintMode = "PlayInfo"

        End If

        Button.ButtonOnOff() 'ボタンの有効無効

    End Sub
    Public Sub MusicStop(ByVal CloseFlag As Boolean) '停止
        If PlayListBox.MusicList.Rows.Count > 0 Then
            If MainForm.StopBtm.ImageIndex = 2 Then
                Button.PlayButtonReset() 'ボタンをOFF
                MainForm.StopBtm.ImageIndex = 3 'ON")
                MainForm.StopBtm.Checked = True '押されたまま")

                '  If PlayInfo.SeekPosition > 0 Then PlayInfo.SeekPosition = 0 'シーク中に停止ボタンが押された場合の為にSeekFlagをoff
                Music.Stopped()

                '停止後のステータス表示の更新

                'Application.DoEvents()
                StatusPrint()

                If CloseFlag = True Then Music.Close("all")

            End If
        End If
        Button.ButtonOnOff() 'ボタンの有効無効
    End Sub
    Public Sub MusicPause() '一時停止
        If PlayListBox.MusicList.Rows.Count > 0 Then
            If MainForm.PauseBtm.ImageIndex = 4 Then
                Button.PlayButtonReset() 'ボタンをOFF
                MainForm.PauseBtm.ImageIndex = 5 'ON"
                MainForm.PauseBtm.Checked = True '押されたまま
                Music.Pause()
                'TaskBaloon
                InfoBox.BeginInvoke(
                    Sub()
                        Dim B_Title As String
                        B_Title = "一時停止"
                        PopUp_Dialog(
                            B_Title,
                            MainForm.DB.Tables("PlayListView").Rows(PlayInfo.PlayIndex).Item("Title").ToString,
                            MainForm.DB.Tables("PlayListView").Rows(PlayInfo.PlayIndex).Item("Artist").ToString,
                            Status.Times
                        )

                    End Sub
                )
            End If
        End If
        Button.ButtonOnOff() 'ボタンの有効無効
    End Sub
    Public Sub MusicNext() '次曲
        If PlayListBox.MusicList.Rows.Count > 0 Then
            Button.PlayButtonReset() 'ボタンをOFF
            MainForm.NextBtm.ImageIndex = 7 'ON

            If Status.PlayFlag.IndexOf("BtmStop") < 0 And Status.PlayFlag.IndexOf("EndStop") < 0 Then Button.MusicStop(True) '停止

            Dim NextIndex As Integer = PlayInfo.PlayIndex + 1
            If NextIndex >= PlayListBox.MusicList.Rows.Count Then
                NextIndex = 0 '次の曲がない(最初の曲へ)
                If PlayMode = "Repeat" And PlayListBox.MusicList.CurrentCell.RowIndex = NextIndex Then Status.PlayFlag = "Restart"
            End If

            PlayListBox.MusicList.CurrentCell = PlayListBox.MusicList.Rows(NextIndex).Cells("No") '次の曲を選択
            If (NextIndex = 0 And PlayMode = "Repeat") Or NextIndex > 0 Or (Status.PlayFlag = "Restart" And NextIndex = 0) Then Button.MusicPlay() '再生ボタン
            If Status.PlayFlag = "BtmStop" And NextIndex = 0 And PlayMode = "Normal" Then Status.PlayFlag = "EndStop" '通常再生時、再生終了フラグ

            MainForm.NextBtm.ImageIndex = 6 'off
            MainForm.NextBtm.Checked = False
        End If
        Button.ButtonOnOff() 'ボタンの有効無効
    End Sub
    Public Sub MusicBack() '前曲
        Button.ButtonOnOff() 'ボタンの有効無効
        If PlayListBox.MusicList.Rows.Count > 0 Then

            Button.PlayButtonReset() 'ボタンをOFF
            MainForm.BackBtm.ImageIndex = 9 'ON")
            Button.MusicStop(True)   '停止

            Dim BackIndex As Integer = PlayInfo.PlayIndex - 1
            If BackIndex < 0 Then BackIndex = PlayListBox.MusicList.Rows.Count - 1

            PlayListBox.MusicList.CurrentCell = PlayListBox.MusicList.Rows.Item(BackIndex).Cells("No") '前の曲を選択
            Button.MusicPlay() '再生

            MainForm.BackBtm.ImageIndex = 8 'Off")
        End If
    End Sub

    Public Sub ListShuffle() 'リスト　シャッフル
        If MainForm.PlayBtm.Checked = False And MainForm.PauseBtm.Checked = False Then
            MainForm.ShuffleBtm.ImageIndex = 17 'ONra

            If MainForm.ShuffleBtm.Checked = False Then 'シャッフル

                'シャッフル リスト生成
                Dim ShuffleList As New Data.DataTable("ShuffleList")
                ShuffleList.Locale = Globalization.CultureInfo.CurrentCulture
                PlayListBox.MusicList.SuspendLayout() 'バインド中断（クリア時のスクロール防止)
                PlayListBox.MusicList.ScrollBars = ScrollBars.None


                ShuffleList = MainForm.DB.Tables("PlayListData").Copy 'PlayListDataTableをコピー
                ShuffleList.TableName = "ShuffleList"
                ' ShuffleList.Load(MainForm.DB.Tables("PlayListData").CreateDataReader)
                MainForm.DB.Tables("PlayListData").Rows.Clear()
                '                Mainform.DB.Tables("PlayListView").Rows.Clear()
                '

                '並び替え
                Do While (ShuffleList.Rows.Count <> 0)
                    Dim Lno As Integer
                    Randomize()
                    Lno = Convert.ToInt32(Rnd() * ShuffleList.Rows.Count) '並び替え対象アイテム算出

                    If Lno > 0 Then Lno -= 1
                    MainForm.DB.Tables("PlayListData").Rows.Add(ShuffleList.Rows(Lno).ItemArray) '並び替え対象アイテム追加

                    ShuffleList.Rows.RemoveAt(Lno)
                Loop

                PlayListBox.MusicList.ResumeLayout() '再開
                PlayListBox.MusicList.ScrollBars = ScrollBars.Vertical

                ShuffleList.Dispose()
            End If

            Status.Text = "曲順をシャッフルしました。"
            Beep()
        Else
            Status.Text = "再生中か一時停止中の為、削除できません。" '状態
        End If
        MainForm.ShuffleBtm.ImageIndex = 16 'Off
    End Sub

    Public Sub MusicListSave(FileName As String) '保存
        Try
            '            MainForm.DB.Tables("PlayListData").Namespace = "MusicList"
            MainForm.DB.Tables("PlayListData").WriteXml(FileName, Data.XmlWriteMode.WriteSchema)
            Beep()
            Status.Text = "プレイリストを保存しました。"
        Catch e As Xml.XmlException
            If IO.File.Exists(FileName) = False Then Status.Text = "プレイリストの保存に失敗しました" : MsgBox("プレイリストの保存に失敗しました。", MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub
    Public Sub MusicListLoad(FileName As String) '読み込み
        PlayListBox.MusicList.SuspendLayout()

        Status.Text = "リストから追加中…"
        Try
            Dim MusicList As New Data.DataTable

            MusicList = MainForm.DB.Tables("PlayListData").Clone
            MusicList.Rows.Clear()
            MusicList.PrimaryKey = New Data.DataColumn() {}
            MusicList.Columns("No").Unique = False
            ' MusicList.Namespace = "MusicList"
            MusicList.ReadXmlSchema(FileName)
            MusicList.ReadXml(FileName)

            'MusicList.TableName = "MusicList"
            Dim Ext As String = TargetFile.Replace("*", "")
            Dim ExtList() = Ext.Split(CChar(";"))

            Dim sp As New Stopwatch
            sp.Start()

            For A = 1 To MusicList.Rows.Count
                Dim No As Integer
                If MainForm.DB.Tables("PlayListData").Rows.Count > 0 Then No = MainForm.DB.Tables("PlayListData").Rows.Count
                MusicList.Rows.Item(A - 1).Item("No") = No + A
                '                If IO.File.Exists(row.Item("Path").ToString) And Array.IndexOf(ExtList, IO.Path.GetExtension(row.Item("Path").ToString)) > -1 Then
                '        MusicList.Rows.CopyTo(row.ItemArray, 0)
                '                File_Add(row.Item("Path").ToString)
                AddNum += 1
                ' End If
                '                Status.Text = AddNum & "曲追加しました。"  '状態
                '               Control.InfoPaint()
            Next


            MainForm.DB.Tables("PlayListData").Load(MusicList.CreateDataReader)

            MainForm.DB.Tables("PlayListData").WriteXml(Application.StartupPath & "\list_tmp.xml")
            MainForm.DB.Tables("PlayListData").Rows.Clear()
            MainForm.DB.Tables("PlayListData").ReadXml(Application.StartupPath & "\list_tmp.xml")



            MainForm.DB.AcceptChanges()
            sp.Stop()
            MainForm.SW_Info.Text = sp.Elapsed.ToString

            ' If IO.File.Exists(Application.StartupPath & "\list_tmp.xml") = True Then IO.File.Delete(Application.StartupPath & "\list_tmp.xml")
        Catch e As Xml.XmlException

            MsgBox(e.Message)
        End Try

        PlayListBox.MusicList.ResumeLayout()
    End Sub

    Public Sub FileSaveDialog() '曲リスト保存
        Dim SaveDialog As New SaveFileDialog

        SaveDialog.Title = "曲リストの保存" 'ダイアログ名
        SaveDialog.Filter = "音楽再生リスト(*.mpl)|*.mpl" '拡張子
        SaveDialog.FileName = ""

        ' 存在しているファイルを指定した場合は、上書きするかどうかの問い合わせを表示する
        SaveDialog.OverwritePrompt = True
        ' ダイアログボックスを閉じる前に現在のディレクトリを復元する
        SaveDialog.RestoreDirectory = True

        If DialogResult.Cancel = SaveDialog.ShowDialog() Then GoTo Cancel 'ダイアログの表示
        Button.MusicListSave(SaveDialog.FileName) '保存
        Beep()
        Status.Text = "リストを保存しました。" '状態

Cancel:
    End Sub
    Public Sub FileOpenDialog() '1曲追加
        If PlayListBox.MusicList.Rows.Count = 0 Then PlayInfo.PlayIndex = 0
        Dim FDialog As New OpenFileDialog

        FDialog.Title = "開く" 'ダイアログ名
        FDialog.FileName = ""
        FDialog.Filter = "対応ファイル|" & TargetFile & "|MP3|*.mp3|CDA|*.cda|WAV|*.wav|音楽再生リスト(*.mpl)|*.mpl|全てのファイル(*.*)|*.*" '拡張子
        FDialog.Multiselect = True
        If DialogResult.Cancel = FDialog.ShowDialog() Then GoTo Cancel 'ダイアログの表示

        MainForm.Enabled = False

        For Each File As String In FDialog.FileNames
            File_Add(File)
            '            Application.DoEvents()
        Next

        MainForm.DB.Tables("PlayListData").AcceptChanges() 'Comit

        MainForm.Enabled = True
        Beep()
Cancel:

    End Sub
    Public Sub DirectoryDialog() 'フォルダから追加

        If PlayListBox.MusicList.Rows.Count = 0 Then PlayInfo.PlayIndex = 0
        Dim DirDialog As New FolderBrowserDialog
        DirDialog.ShowNewFolderButton = False

        DirDialog.Description = "フォルダから追加"

        If DialogResult.Cancel = DirDialog.ShowDialog() Then GoTo cancel

        MainForm.Enabled = False
        PlayListBox.MusicList.ScrollBars = ScrollBars.None

        Dim sp As New Stopwatch
        sp.Start()

        Dim Filter() As String = TargetFile.Split(CChar(";"))

        GetFileList.Clear()

        'ファイルを取得
        DirFileAdding = New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf Control.FileSearch))
        DirFileAdding.IsBackground = True
        DirFileAdding.Start(DirDialog.SelectedPath)
        DirFileAdding.Join()

        'リストに追加
        'Thread
        '   FilesAdding = New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf Control.Files_Add))
        '        FilesAdding = New Threading.Thread(New Threading.ThreadStart(AddressOf Control.Files_Add))
        '  FilesAdding.IsBackground = True
        'FilesAdding.Start(GetFileList)

        For Each file As String In GetFileList
            Control.File_Add(file)
            '  MainForm.MusicList.Update()
        Next

        sp.Stop()
        MainForm.SW_Info.Text = sp.Elapsed.ToString 'Proc Sec
        GetFileList.Clear()
        Beep()
        MainForm.Enabled = True
Skip:

cancel:
        MainForm.OneAddBtm.Checked = False '元に戻す
    End Sub
    Public Sub SetPlayMode(ByVal Mode As String)
        Button.ModeButtonReset() 'ボタンOFF

        If MainForm.NormalPlayBtm.Checked = False And Mode = "Normal" Then '通常再生
            PlayMode = "Normal" 'モード代入
            MainForm.NormalPlayBtm.ImageIndex = 13 'ON
            MainForm.NormalPlayBtm.Checked = True

        ElseIf MainForm.RepeatPlayBtm.Checked = False And Mode = "Repeat" Then 'リピート再生
            PlayMode = "Repeat" 'モード代入
            MainForm.RepeatPlayBtm.ImageIndex = 15 'ON
            MainForm.RepeatPlayBtm.Checked = True
        End If

    End Sub
    Public Sub PlayButtonReset() 'ボタンをOFFにする

        MainForm.PlayBtm.ImageIndex = 0 'OFF")
        MainForm.PlayBtm.Checked = False

        MainForm.StopBtm.ImageIndex = 2 'OFF")
        MainForm.StopBtm.Checked = False

        MainForm.PauseBtm.ImageIndex = 4 'OFF")
        MainForm.PauseBtm.Checked = False
    End Sub
    Public Sub ModeButtonReset() 'モードボタンをOFFにする
        MainForm.NormalPlayBtm.ImageIndex = 12 'OFF")
        MainForm.NormalPlayBtm.Checked = False

        MainForm.RepeatPlayBtm.ImageIndex = 14 'OFF")
        MainForm.RepeatPlayBtm.Checked = False
    End Sub
    Public Sub ButtonOnOff() 'ボタン有無効

        If MainForm.PlayBtm.Checked = True Then '再生がON
            MainForm.PlayBtm.Enabled = True '再生")
            MainForm.StopBtm.Enabled = True '停止")
            MainForm.PauseBtm.Enabled = True '一時停止")
        End If
        If MainForm.StopBtm.Checked = True Then '停止がON
            MainForm.PlayBtm.Enabled = True '再生")
            MainForm.StopBtm.Enabled = False '停止")
            MainForm.PauseBtm.Enabled = False '一時停止")
        End If
        If MainForm.PauseBtm.Checked = True Then '一時停止がON
            MainForm.PlayBtm.Enabled = True '再生")
            MainForm.StopBtm.Enabled = True '停止")
            MainForm.PauseBtm.Enabled = False '一時停止")
        End If
        If PlayListBox.MusicList.Rows.Count > 0 Then 'ON
            MainForm.PlayBtm.Enabled = True '再生")
            MainForm.BackBtm.Enabled = True '前曲")
            MainForm.NextBtm.Enabled = True '次曲")
            MainForm.Slider.Enabled = True 'スライダ
        End If
        If PlayListBox.MusicList.Rows.Count <= 0 Then 'OFF
            MainForm.PlayBtm.Enabled = False '再生")
            MainForm.StopBtm.Enabled = False '停止")
            MainForm.PauseBtm.Enabled = False '一時停止")
            MainForm.BackBtm.Enabled = False '前曲")
            MainForm.NextBtm.Enabled = False '次曲")
            MainForm.Slider.Enabled = False 'スライダ
        End If

    End Sub

    Public Sub MusicListMenuOnOff() 'PlayList Colum ToolStripMenu
        If PlayListBox.MusicList.Columns("No").Visible = True Then PlayListBox.PlayNoViewBtm.Checked = True Else PlayListBox.PlayNoViewBtm.Checked = False
        If PlayListBox.MusicList.Columns("Title").Visible = True Then PlayListBox.TitleViewBtm.Checked = True Else PlayListBox.TitleViewBtm.Checked = False
        If PlayListBox.MusicList.Columns("SubTitle").Visible = True Then PlayListBox.SubTitleViewBtm.Checked = True Else PlayListBox.SubTitleViewBtm.Checked = False
        If PlayListBox.MusicList.Columns("PlayTime").Visible = True Then PlayListBox.TimeViewBtm.Checked = True Else PlayListBox.TimeViewBtm.Checked = False
        If PlayListBox.MusicList.Columns("Artist").Visible = True Then PlayListBox.ArtistViewBtm.Checked = True Else PlayListBox.ArtistViewBtm.Checked = False
        If PlayListBox.MusicList.Columns("Album").Visible = True Then PlayListBox.AlbumViewBtm.Checked = True Else PlayListBox.AlbumViewBtm.Checked = False
        If PlayListBox.MusicList.Columns("Path").Visible = True Then PlayListBox.PathViewBtm.Checked = True Else PlayListBox.PathViewBtm.Checked = False
        If PlayListBox.MusicList.Columns("Bitrate").Visible = True Then PlayListBox.BitrateViewBtm.Checked = True Else PlayListBox.BitrateViewBtm.Checked = False
        If PlayListBox.MusicList.Columns("Samplerate").Visible = True Then PlayListBox.SamplerateViewBtm.Checked = True Else PlayListBox.SamplerateViewBtm.Checked = False
        If PlayListBox.MusicList.Columns("FileSize").Visible = True Then PlayListBox.FileSizeViewBtm.Checked = True Else PlayListBox.FileSizeViewBtm.Checked = False

    End Sub
End Module
