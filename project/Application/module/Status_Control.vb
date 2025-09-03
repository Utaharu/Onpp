Module Status_Control
    Public Status As New PlayStatus
    Public PlayRun As New System.Threading.Thread(New Threading.ThreadStart(AddressOf PlayRun_Proc))
    Delegate Sub PInfoRef()

    Dim FrameStartTime As Long
    Dim FrameEndTime As Long

    Public SumPlayTime As Integer

    Structure PlayStatus
        Dim Times As String '時間
        Dim Text As String '情報
        Dim TextSize As Integer '文字数
        Dim ScrollNum As Integer 'スクロール数
        Dim Log As String 'スクロール前Text
        Dim PlayFlag As String
        Dim ProcFlag As String
    End Structure

    Public Sub PlayRun_Proc() 'Status更新間隔
        Dim StopWatch As New System.Diagnostics.Stopwatch
        Dim PlayTimeOutSec As Integer = 10

        Try
            FrameStartTime = Now.Ticks
            Do

                InfoBox.Invoke(New PInfoRef(AddressOf PositionSet))

                Select Case Status.ProcFlag
                    Case "PlayRequest"
                        StopWatch.Reset()
                        StopWatch.Start()
                        InfoBox.BeginInvoke(New PInfoRef(AddressOf Music.PlayRequest)) '再生Req
                        Status.ProcFlag = "PlayRequesting"
                    Case "PlayReady", "PlayRequesting"
                        If StopWatch.Elapsed.Seconds > PlayTimeOutSec Then
                            StopWatch.Stop()
                            Status.ProcFlag = "NoFile"
                            InfoBox.Invoke(
                                Sub()
                                    Beep()
                                    PopUp_Dialog(
                                        "再生不可",
                                        MainForm.DB.Tables("PlayListView").Rows(PlayInfo.PlayIndex).Item("Title").ToString,
                                        MainForm.DB.Tables("PlayListView").Rows(PlayInfo.PlayIndex).Item("Artist").ToString,
                                        TS_Change(Convert.ToInt32(MainForm.DB.Tables("PlayListData").Rows(PlayInfo.PlayIndex).Item("PlayTime")))
                                    )
                                    Status.Text = "再生できません。"
                                    Music.Close(PlayInfo.NowFiles)
                                End Sub
                            )
                            Threading.Thread.Sleep(3000)
                            InfoBox.Invoke(
                                    Sub()
                                        Button.MusicNext()
                                    End Sub
                            )
                        End If
                    Case "PlayStart"
                        InfoBox.Invoke(New PInfoRef(AddressOf Music.PlayBack)) 'PlayCmd
                End Select
                Threading.Thread.Sleep(200)

                InfoBox.Invoke(New PInfoRef(AddressOf StatusPrint))

                FrameStartTime = Now.Ticks
                '                FrameEndTime = Now.Ticks

            Loop
        Catch e As Threading.ThreadAbortException
            Return
        Finally

        End Try

    End Sub
    Public Sub StatusPrint() 'ステータス表示

        Try
            '            If StatusPrintMode = "PlayInfo" And Flag.IndexOf("EndStop") = -1 Then

            If StatusPrintMode = "PlayInfo" Then
                PlayInfo.Status = GetStatus()
                Dim PlayRow = PlayListBox.MusicList.Rows(GetTableIndex("PlayListView", PlayInfo.PlayNo))
                Status.Times = TS_Change(PlayInfo.NowPosition) & "/" & TS_Change(PlayInfo.EndPosition) '再生時間/総合時間 PlayRow.Cells("TimeString").FormattedValue.ToString
                Status.Log = "[" & PlayInfo.Status & "] " & PlayRow.Cells("No").Value.ToString & " - " & PlayRow.Cells("Title").Value.ToString & " (" & PlayRow.Cells("Artist").Value.ToString & ") " '状態

                If MainForm.TrayIcon.Visible = True Then
                    MainForm.TrayIcon.Text = "状態 : " & PlayInfo.Status & vbNewLine &
                        "曲名 : " & PlayRow.Cells("Title").Value.ToString & vbNewLine &
                        "歌手 : " & PlayRow.Cells("Artist").Value.ToString & vbNewLine &
                        "時間 : " & Status.Times
                End If

                'PlayPosition Slider
                Dim SliderPosition As Integer = PlayInfo.NowPosition \ 1000
                If MainForm.Slider.Minimum <= SliderPosition And MainForm.Slider.Maximum >= SliderPosition And PlayInfo.SeekPosition <= 0 Then
                    MainForm.Slider.Value = SliderPosition  '現在位置(スライダー)
                End If
            End If
            '                Form1.TimeBox.Text = Times
            '3390 / 4560


            '            If Form1.WindowState = 1 Then
            '   Form1.Text = Status.Text
            ' Else
            MainForm.Text = "おんぷっぷ " '& PlayInfo.StartPosition & "/" & PlayInfo.NowPosition & "/" & PlayInfo.EndPosition
            ' End If
        Catch ex As Exception
        End Try

        If StatusPrintMode = "PlayInfo" And Status.Log <> "" Then
            '文字スクロール周期の調整 500ms
            If (FrameStartTime - FrameEndTime) >= 5000000 Then

                If Status.ScrollNum = 0 Then
                    Status.TextSize = Status.Log.Length '文字数
                Else
                    Status.TextSize = Status.Log.Length '文字数
                    If Status.TextSize > 0 And Status.ScrollNum <= Status.TextSize Then '文字数がスクロール以上か
                        Try
                            Status.Text = Status.Log.Substring(Status.ScrollNum) '右から文字数-スクロール数を切り出す。
                            Status.Text += Status.Log.Substring(0, Status.ScrollNum) '左からスクロール数を切り出し、後ろに付け足す。
                        Catch ex As Exception
                        End Try
                    Else
                        Status.ScrollNum = 0 'スクロール数を初期化
                    End If
                End If
                Status.ScrollNum += 1 'スクロール数を増加

                FrameEndTime = Now.Ticks
            End If
        End If
        InfoPaint()

    End Sub

    Friend Sub InfoPaint() '時間などの情報
        If InfoBox.Text <> Status.Text Then InfoBox.Text = Status.Text : InfoBox.Update()
        If MainForm.TimeBox.Text <> Status.Times Then MainForm.TimeBox.Text = Status.Times : MainForm.TimeBox.Update()
        InfoBox.BeginInvoke(
            Sub()
                MainForm.SumTime.Text = TS_Change(SumPlayTime)
            End Sub
        )
        '3390 / 4560

        If MainForm.WindowState = 1 Then
            MainForm.Text = Status.Text
        Else
            '            Me.Text = "おんぷっぷ"
        End If

        Application.DoEvents()

    End Sub

    Friend Function TS_Change(ByVal Sec As Integer) As String
        TS_Change = ""
        Dim H As String = "0"
        Dim M As String = "0"
        Dim S As String = "0"

        If Sec > 1000 Then
            H = Convert.ToString(Sec \ 1000 \ 60 \ 60).PadLeft(2, Convert.ToChar("0")) '時に
            M = Convert.ToString(Sec \ 1000 \ 60 Mod 60).PadLeft(2, Convert.ToChar("0")) '分に
            S = Convert.ToString(Sec \ 1000 Mod 60).PadLeft(2, Convert.ToChar("0")) '秒に
        End If

        If Convert.ToInt32(H) <= 0 Then H = "00"
        If Convert.ToInt32(M) <= 0 Then M = "00"
        If Convert.ToInt32(S) <= 0 Then S = "00"

        If Convert.ToInt32(H) > 0 Then TS_Change = H & ":"
        TS_Change &= M & ":" & S '出力
    End Function
End Module
