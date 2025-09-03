
Imports System.IO

Module Music
    Dim PositionCheck As P_check
    Private Delegate Sub mcmd_DG(ByVal cmd As String)
    Structure P_check
        Dim BeforePosition As Integer
        Dim Cnt As Integer
    End Structure
    Public Function MCmd(ByVal mciCommand As String) As String

        Dim ErCode As Integer
        Dim Retbuffer As String = New String(Chr(0), 1024)
        Dim Send As String = mciCommand
        Try
            ErCode = mciSendString(mciCommand, Retbuffer, Len(Retbuffer), hWnd)

            'Retbuffer = DelNull(Retbuffer)
        Catch ex As Exception
            If ErCode <> 0 Then
                Dim ErrBuffer As String = New String(Chr(0), 1024)
                mciGetErrorString(ErCode, ErrBuffer, Len(ErrBuffer))
                'Error Log File 
                System.IO.File.AppendAllText(Error_LogFile, vbNewLine & vbNewLine &
                                                "##### " & Today.ToLongDateString & " " & Now.TimeOfDay.ToString & vbNewLine &
                                                "mciSendString: " & Send & vbNewLine & "ERROR: " & ErrBuffer
                             )
            End If
        End Try

        If Retbuffer <> "" Then Retbuffer = Retbuffer.Replace(vbNullChar, "")
        If Retbuffer = "" Then Retbuffer = Nothing

        MCmd = Retbuffer
    End Function
    Friend Sub Open(ByVal FilePath As String)
        Dim DT As String = ""
        If PlayInfo.DeviceType = "m4a_audio" Then DT = " type videodisc"

        MCmd("Open " + """" + FilePath + """" + DT)  '開く"
        MCmd("Set " + """" + FilePath + """" + " time format milliseconds")
    End Sub

    Friend Sub PlayRequest() '再生
        If IO.File.Exists(PlayInfo.NowFiles) = False Then GoTo NoFile
        If Array.IndexOf(TargetFile.Replace("*", "").Split(CChar(";")), IO.Path.GetExtension(PlayInfo.NowFiles).ToLower) < 0 Then GoTo NoFile

        'Album Art　Check
        If Status.PlayFlag <> "Pause" And PlayInfo.SeekPosition <= 0 Then 'And PlayInfo.EndPosition <= 0 Then '一時中止 / シーク中でない /　開けてない
            Music.Close(PlayInfo.NowFiles) '一応Close
            Try

                Dim ID3Tag = TagLib.File.Create(PlayInfo.NowFiles)

                'GetID3Tag(AlbumArt)
                Dim AlbumArtTag = ID3Tag.Tag.Pictures

                'アルバムアートが組み込まれている場合、アートタグを削除した一時ファイルを作成してそれを再生してみる。
                If AlbumArtTag.Count > 0 Then
                    'File Copy -> Temp
                    Dim TempPath As String = TempFolder & FileIO.FileSystem.GetName(PlayInfo.NowFiles)
                    FileIO.FileSystem.CopyFile(PlayInfo.NowFiles, TempPath, True) 'FileCopy
                    FileIO.FileSystem.GetFileInfo(TempPath).Attributes = IO.FileAttributes.Normal

                    Dim Temp_Id3Tag = TagLib.File.Create(TempPath)
                    Temp_Id3Tag.RemoveTags(TagLib.TagTypes.AllTags)
                    Temp_Id3Tag.Save()

                    PlayInfo.NowFiles = TempPath 'PlayRootChange
                End If
            Catch ex As Exception
                Debug.Print("Err (PlayRequest):" + ex.Message)


                '              GoTo NoFile
            End Try
        End If
ReTry:
        If PlayListBox.MusicList.Rows.Count > 0 Then
            If MainForm.DB.Tables("ConfigData").Rows.Count > 0 Then
                MainForm.DB.Tables("ConfigData").Rows(0).Item(0) = PlayMode
                MainForm.DB.Tables("ConfigData").Rows(0).Item(1) = PlayInfo.PlayNo
                MainForm.DB.Tables("ConfigData").Rows(0).Item(2) = MainForm.PlayListBtm.Checked
                MainForm.DB.Tables("ConfigData").Rows(0).Item(3) = MainForm.VolumeVal.Value
            Else
                MainForm.DB.Tables("ConfigData").Rows.Add(PlayMode, PlayInfo.PlayNo, MainForm.PlayListBtm.Checked, MainForm.VolumeVal.Value)
            End If
        End If

        MainForm.DB.Tables("ConfigData").WriteXml(ConfigFile)

        '情報代入
        PlayInfo.DeviceType = Music.GetDeviceType(PlayInfo.NowFiles) 'DeviceType
        If Status.PlayFlag <> "Pause" Then PlayInfo.NowPosition = 0 : Music.Open(PlayInfo.NowFiles) '開く
        PlayInfo.StartPosition = Music.GetTrack(PlayInfo.NowFiles, "StartPosition") '再生開始位置
        '        PlayInfo.EndPosition = Convert.ToInt32(Music.GetAllTime(PlayInfo.NowFiles, PlayInfo.DeviceType)) 'MciSendStringから終了位置
        PlayInfo.EndPosition = Convert.ToInt32(MainForm.DB.Tables("PlayListView").Rows(PlayInfo.PlayIndex).Item("PlayTime").ToString) 'DBから終了位置
        PlayListBox.MusicList.Rows(PlayInfo.PlayIndex).Cells("PlayTime").Value = TS_Change(PlayInfo.EndPosition)

        MainForm.Slider.Maximum = PlayInfo.EndPosition \ 1000 '再生位置最大値（スライダー用)

        VolumeChange(MainForm.VolumeVal.Value)

        Status.ProcFlag = "PlayReady" 'フラグ

        Exit Sub

NoFile:
        Status.Text = "再生できません。"
        Music.Close(PlayInfo.NowFiles)
        Button.MusicNext()

    End Sub
    Friend Sub PlayBack()
        Dim A As String = ""
        'CD再生用-再生位置設定
        If PlayInfo.DeviceType = "cd_audio" Then A = " from " & PlayInfo.StartPosition + PlayInfo.NowPosition & " to " & PlayInfo.StartPosition + PlayInfo.EndPosition & " notify"

        MCmd("Play " + """" + PlayInfo.NowFiles + """" + A)   '再生
        PlayInfo.SeekPosition = 0 '移動位置の初期化
        Status.PlayFlag = "Play"
        Status.ProcFlag = "Play"

    End Sub
    Friend Sub Stopped() '停止
        MCmd("Seek " + """" + PlayInfo.NowFiles + """" + " to 0") '再生位置を最初に
        MCmd("Stop " + """" + PlayInfo.NowFiles + """")

        If PlayInfo.SeekPosition = 0 Then Status.PlayFlag = "BtmStop" 'フラグ
    End Sub
    Friend Sub Pause() '一時停止
        MCmd("Pause " + """" + PlayInfo.NowFiles + """")
        Status.PlayFlag = "Pause" 'フラグ
    End Sub
    Friend Sub Reopen() '再開
        MCmd("Resume " + """" + PlayInfo.NowFiles + """")
    End Sub
    Friend Sub Close(FileName As String) '閉じる

        MCmd("Close " + """" + FileName + """")  '閉じる

        'TempFile Delete
        If FileName <> "all" And FileIO.FileSystem.FileExists(TempFolder & FileIO.FileSystem.GetName(FileName)) = True Then
            FileIO.FileSystem.DeleteFile(TempFolder & FileIO.FileSystem.GetName(FileName))
        End If

    End Sub
    Friend Sub MovePosition(Position As Integer) '早送り・巻き戻し
        If PlayInfo.SeekPosition = 0 Then Button.MusicPause() '一時停止

        If PlayInfo.EndPosition > 0 Then
            'SeekFlag = True
            PlayInfo.SeekPosition = Position * 1000 '値を合わせる
            MCmd("Seek """ & PlayInfo.NowFiles & """ to " & (PlayInfo.SeekPosition + PlayInfo.StartPosition)) '再生位置変更
        End If

        Button.ButtonOnOff() 'ボタンの有効無効
    End Sub
    Friend Sub VolumeChange(ByVal Value As Decimal)
        If PlayInfo.NowFiles <> "" Then MCmd("SetAudio """ & PlayInfo.NowFiles & """  Volume to " & Value)
    End Sub
    Friend Function GetNowTime() As Integer '再生時間
        '        If Flag <> "stop" Then

        GetNowTime = Convert.ToInt32(MCmd("Status " + """" + PlayInfo.NowFiles + """" + " position")) - PlayInfo.StartPosition
        ' Else
        '      Return PlayInfo.NowPosition
        ' End If
    End Function
    Friend Function GetAllTime(ByVal FilePath As String, ByVal DeviceType As String) As Integer '総合時間

        Dim A, TrackNo As String
        A = ""

        'デバイスの種類
        If DeviceType = "cd_audio" Then 'CDの場合
            TrackNo = Convert.ToString(Music.GetTrack(FilePath, "No")) 'トラック取得
            A = " track " & TrackNo 'CD用
        End If

        GetAllTime = Convert.ToInt32(MCmd("Status " + """" + FilePath & """" + " length" + A)) '総合時間取得

    End Function
    Friend Function GetTrack(ByVal FileName As String, ByVal Flag As String) As Integer 'トラック取得
        Dim TrackNo As String = "1"

        GetTrack = 0

        If GetDeviceType(FileName) = "cd_audio" Then GetTrack = Convert.ToInt32(Left(Right(FileName, 6), 2)) 'トラック

        If Flag = "StartPosition" Then '再生開始位置
            TrackNo = Music.GetTrack(FileName, "No").ToString 'トラック取得
            Dim TimeFormat As String = MCmd("Status " + """" + PlayInfo.NowFiles + """" + " position track " & GetTrack)
            If TimeFormat <> "" Then
                GetTrack = Convert.ToInt32(TimeFormat) 'タイムフォーマット
            End If
        End If
    End Function
    Public Function GetDeviceType(ByVal FilePath As String) As String
        Dim Ty As String
        '       Ty = FileIO.FileSystem.GetFileInfo(FileName).Extension
        Ty = IO.Path.GetExtension(FilePath).ToLower

        If Ty = ".mp3" Then
            GetDeviceType = "mp3_audio"
        ElseIf Ty = ".wav" Then
            GetDeviceType = "wave_audio"
        ElseIf Ty = ".cda" Then
            GetDeviceType = "cd_audio"
        ElseIf Ty = ".m4a" Then
            GetDeviceType = "m4a_audio"
        Else
            GetDeviceType = Music.MCmd("Capability " + """" + FilePath + """" + " device type") 'デバイス種別
        End If
    End Function
    Friend Function GetStatus() As String '状態

        Dim A As String
        If Status.ProcFlag = "PlayReady" Then A = " ready" Else A = " mode"
        Dim PlayFlag As String = MCmd("Status " + """" & PlayInfo.NowFiles + """" + A)   '状態取得

        If PlayFlag = "stopped" And Status.PlayFlag = "Pause" Then PlayFlag = "paused" '処理フラグがPauseの場合、ステータスを強制的に一時停止にする


        Select Case PlayFlag
            Case "true"
                If Status.ProcFlag = "PlayReady" Then
                    Status.ProcFlag = "PlayStart"
                    GetStatus = "準備完了"

                Else
                    GetStatus = PlayInfo.Status
                End If

            Case "playing"
                Status.PlayFlag = "Playing"
                GetStatus = "再生中"

                If PositionCheck.BeforePosition > 0 And PlayInfo.EndPosition = PlayInfo.NowPosition And Status.PlayFlag = "Playing" Then
                    PositionCheck.Cnt += 1
                    If PositionCheck.Cnt >= 10 Then
                        System.IO.File.AppendAllText(Error_LogFile,
                            "##### " & Today.ToLongDateString & " " & Now.TimeOfDay.ToString & vbNewLine &
                            "再生失敗:" & PlayInfo.NowFiles & vbNewLine
                            )
                        GoTo NextPlay
                    End If


                Else
                    PositionCheck.BeforePosition = PlayInfo.NowPosition
                    PositionCheck.Cnt = 0
                End If

            Case "paused"
                GetStatus = "一時停止"

            Case "stopped"
                GetStatus = "停止"

                PositionCheck = New P_check
                If Status.PlayFlag = "Playing" Then Status.PlayFlag = "Stopped" : GoTo NextPlay

            Case Else
                GetStatus = "停止"

        End Select

        Exit Function

NextPlay:
        Status.PlayFlag = "AutoNext"
        MainForm.NextBtm.Checked = True '押す
        Button.MusicNext() '次の曲
    End Function


End Module
