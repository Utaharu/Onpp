Attribute VB_Name = "Control"
Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long

Dim NowFiles As String '現在再生中のファイル名
Public FileType As String 'デバイス種別

'再生位置制御用
Dim StartPosition As String '開始位置
Dim SeekPosition As String 'シーク位置
Dim NowPosition As String
Dim EndPosition As String '終了位置

Public Files As String
Dim Retbuffer As String * 255
Public Flag As String 'フラグ

Private Type tagID3v1
 Header         As String * 3
 MusicName   As String * 30
 ArtistName   As String * 30
 AlbamName   As String * 30
 MakeYear     As String * 4
 Coment       As String * 28
 TrackNum(1) As Byte
 Genre(0)       As Byte
End Type
Public Sub DiviceType(FileName As String)
ty = Right(FileName, 3)
 If ty = "mp3" Or ty = "wav" Then
  FileType = "waveaudio"
 ElseIf ty = "cda" Then
  FileType = "cdaudio"
 Else
   mciSendString "Capability " + """" + FileName + """" + " device type", Retbuffer, Len(Retbuffer), 0 'デバイス種別
   FileType = DelNull(Retbuffer)
End If
End Sub
Public Sub MusicOpen()
  mciSendString "Open " + """" + Files + """", vbNull, 0, 0  '開く"
  mciSendString "Set " + """" + Files + """" + " time format milliseconds", vbNull, 0, 0
End Sub
Public Sub MusicPlay() '再生
 If Flag = "Pause" Then
  Control.MusicResume '再開
 Else
   NowFiles = Files
  DoEvents
   Control.DiviceType (NowFiles) 'デバイス
  If FileType = "cdaudio" Then 'CDの場合
    trackno = Control.GetTrack(Files, "No") 'トラックの情報取得
    StartPosition = Control.GetTrack(Files, "StartPosition") '再生開始位置
    EndPosition = Control.GetTrack(Files, "EndPosition") '終了位置
    A = " from " & Val(StartPosition) + Val(SeekPosition) & " to " & Val(StartPosition) + Val(EndPosition) 'CD再生用-再生位置設定
   Else '再生位置の初期化
    StartPosition = 0
    SeekPosition = 0
    EndPosition = 0
  End If
  VolumeChange (Form1.Volume.Value)
 mciSendString "Play " + """" + NowFiles + """" + A, Retbuffer, Len(Retbuffer), 0    '再生
  SeekPosition = 0 '移動位置の初期化
 End If
  Flag = "Play" 'フラグ
End Sub
Public Sub MusicStop() '停止
 mciSendString "Seek " + """" + NowFiles + """" + " to 0", Retbuffer, Len(Retbuffer), 0 '再生位置を最初に
 mciSendString "Stop " + """" + NowFiles + """", Retbuffer, Len(Retbuffer), 0
  Flag = "BtmStop" 'フラグ
End Sub
Public Sub MusicPause() '一時停止
  mciSendString "Pause " + """" + NowFiles + """", Retbuffer, Len(Retbuffer), 0
 Flag = "Pause" 'フラグ
End Sub
Public Sub MusicResume() '再開
  mciSendString "Resume " + """" + NowFiles + """", Retbuffer, Len(Retbuffer), 0
End Sub
Public Sub MusicClose(FileName As String) '閉じる
 mciSendString "Close " + """" + FileName + """", Retbuffer, Len(Retbuffer), 0  '閉じる
End Sub
Public Sub MusicPosition(Position As Long) '早送り・巻き戻し
 SeekPosition = Position * 1000 '値を合わせる
   mciSendString "Seek """ & NowFiles & """ to " & SeekPosition + Val(StartPosition), Retbuffer, Len(Retbuffer), 0 '再生位置変更
End Sub
Public Sub VolumeChange(Value As Integer)
 mciSendString "SetAudio """ & NowFiles & """  Volume to " & Value, "", 0, 0
End Sub
Function Status() '状態
 mciSendString "Status " + """" + NowFiles + """" + " mode", Retbuffer, Len(Retbuffer), 0   '状態取得
 
 If InStr(Retbuffer, "playing") = 1 Then
  Status = "再生中"
  Control.DiviceType (NowFiles) 'デバイス
  If FileType = "cdaudio" Then 'CDの場合
   E = EndPosition \ 1000
   N = NowPosition \ 1000
   If E <= N Or E <= (N - 1) Or E <= (N + 1) Then
    Form1.Toolbar.Buttons.Item(10).Value = tbrPressed '押す
    Buttom.MusicNext '次の曲
   End If
  End If
 Else
 If InStr(Retbuffer, "paused") = 1 Then
  Status = "一時停止"
 Else
 If InStr(Retbuffer, "stopped") = 1 Then
  Status = "停止"
  If Flag = "Play" Then
   Form1.Toolbar.Buttons.Item(10).Value = tbrPressed '押す
   Buttom.MusicNext '次の曲
  End If
 Else
  Status = "停止"
 End If
 End If
 End If

End Function

Function NowTime() '再生時間
  mciSendString "Status " + """" + NowFiles + """" + " position", Retbuffer, Len(Retbuffer), 0 '再生時間
  
 PlayPosition = (Val(Retbuffer) - Val(StartPosition)) / 1000 '再生位置現在値（スライダー用）
   NowPosition = Val(Retbuffer)
  Retbuffer = Val(Retbuffer) - Val(StartPosition)
' Form1.Caption = StartPosition & "/" & NowPosition & "/" & EndPosition
 
 M = Val(Retbuffer) \ 1000 \ 60 '分に
 S = Val(Retbuffer) \ 1000 Mod 60 '秒に
 
  If M < 10 Then '0を付け足す
  M = "0" & M
 End If
 If S < 10 Then '0を付け足す
  S = "0" & S
 End If

  NowTime = M & ":" & S '出力
End Function
Function AllTime() '総合時間
 Control.DiviceType (Control.Files) 'デバイスの種類
If FileType = "cdaudio" Then 'CDの場合
  trackno = Control.GetTrack(Files, "No") 'トラック取得
  A = " track " & trackno 'CD用
End If

  mciSendString "Status " + """" + Files + """" + " length" + A, Retbuffer, Len(Retbuffer), 0  '総合時間取得
  EndPosition = Val(Retbuffer) + Val(StartPosition) '終了位置
  AllPosition = (Val(Retbuffer)) / 1000 '再生位置最大値（スライダー用)

 M = Val(Retbuffer) \ 1000 \ 60  '分に
 S = Val(Retbuffer) \ 1000 Mod 60 '秒に
 
  If M < 10 Then '0を付け足す
  M = "0" & M
 End If
 If S < 10 Then '0を付け足す
  S = "0" & S
 End If
 
 AllTime = M & ":" & S '出力
End Function
Function GetTrack(FileName As String, Flag As String) 'トラック取得
 If Flag = "No" Then 'トラック番号
  GetTrack = Val(Left(Right(FileName, 6), 2)) 'トラック
 End If
 If Flag = "StartPosition" Then '再生開始位置
   trackno = Control.GetTrack(FileName, "No") 'トラック取得
  mciSendString "Status " + """" + NowFiles + """" + " position track " & trackno, Retbuffer, Len(Retbuffer), 0 'タイムフォーマット
    GetTrack = Val(Retbuffer) '開始位置代入
 End If
 If Flag = "EndPosition" Then '再生終了位置
  trackno = Control.GetTrack(FileName, "No") 'トラック取得
    mciSendString "Status " + """" + Files + """" + " length track " & trackno, Retbuffer, Len(Retbuffer), 0  '総合時間取得
    GetTrack = Val(Retbuffer)  '終了位置
End If
End Function
Function GetMp3Tag(FileName As String, Types As String)

'ID3v1は無視してます。全部ID3v1.1だと考えて処理

Dim FilesLen As Long
Dim ID3v1 As tagID3v1

DoEvents
    Open FileName For Binary As #2
    'ファイルが異常
    If LOF(2) <= 128 Then
        GetMp3Tag = "None"
        Close #2
        Exit Function
    End If

    FilesLen = FileLen(FileName)
    Get #2, FilesLen - 127, ID3v1

    If ID3v1.Header <> "TAG" Then
        GetMp3Tag = "None"
    Else 'ID3v1がある場合の処理
     If Types = "Title" Then '曲名
      GetMp3Tag = DelNull(ID3v1.MusicName)
     Else
     If Types = "Artist" Then 'アーティスト
      GetMp3Tag = DelNull(ID3v1.ArtistName)
     Else
     If Types = "Albam" Then 'アルバム名
      GetMp3Tag = DelNull(ID3v1.AlbamName)
     Else
     If Types = "Make" Then '製作年
      GetMp3Tag = DelNull(ID3v1.MakeYear)
     Else
     If Types = "Coment" Then 'コメント
      GetMp3Tag = DelNull(ID3v1.Coment)
     Else
     If Types = "Track" Then 'トラック
      GetMp3Tag = DelNull(CInt(ID3v1.TrackNum(1)))
     Else
      Err
    End If
    End If
    End If
    End If
    End If
    End If
End If
 If GetMp3Tag = "" Then
  GetMp3Tag = "None"
 End If
 Close #2
End Function

'Null文字を取り除く処理
Private Function DelNull(Buffer As String) As String
    If InStr(Buffer, vbNullChar) Then
        DelNull = Left$(Buffer, InStr(Buffer, vbNullChar) - 1)
    Else
        DelNull = Buffer
    End If
End Function

    
