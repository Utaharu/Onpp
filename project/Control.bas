Attribute VB_Name = "Control"
Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long

Dim NowFiles As String '���ݍĐ����̃t�@�C����
Public FileType As String '�f�o�C�X���

'�Đ��ʒu����p
Dim StartPosition As String '�J�n�ʒu
Dim SeekPosition As String '�V�[�N�ʒu
Dim NowPosition As String
Dim EndPosition As String '�I���ʒu

Public Files As String
Dim Retbuffer As String * 255
Public Flag As String '�t���O

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
   mciSendString "Capability " + """" + FileName + """" + " device type", Retbuffer, Len(Retbuffer), 0 '�f�o�C�X���
   FileType = DelNull(Retbuffer)
End If
End Sub
Public Sub MusicOpen()
  mciSendString "Open " + """" + Files + """", vbNull, 0, 0  '�J��"
  mciSendString "Set " + """" + Files + """" + " time format milliseconds", vbNull, 0, 0
End Sub
Public Sub MusicPlay() '�Đ�
 If Flag = "Pause" Then
  Control.MusicResume '�ĊJ
 Else
   NowFiles = Files
  DoEvents
   Control.DiviceType (NowFiles) '�f�o�C�X
  If FileType = "cdaudio" Then 'CD�̏ꍇ
    trackno = Control.GetTrack(Files, "No") '�g���b�N�̏��擾
    StartPosition = Control.GetTrack(Files, "StartPosition") '�Đ��J�n�ʒu
    EndPosition = Control.GetTrack(Files, "EndPosition") '�I���ʒu
    A = " from " & Val(StartPosition) + Val(SeekPosition) & " to " & Val(StartPosition) + Val(EndPosition) 'CD�Đ��p-�Đ��ʒu�ݒ�
   Else '�Đ��ʒu�̏�����
    StartPosition = 0
    SeekPosition = 0
    EndPosition = 0
  End If
  VolumeChange (Form1.Volume.Value)
 mciSendString "Play " + """" + NowFiles + """" + A, Retbuffer, Len(Retbuffer), 0    '�Đ�
  SeekPosition = 0 '�ړ��ʒu�̏�����
 End If
  Flag = "Play" '�t���O
End Sub
Public Sub MusicStop() '��~
 mciSendString "Seek " + """" + NowFiles + """" + " to 0", Retbuffer, Len(Retbuffer), 0 '�Đ��ʒu���ŏ���
 mciSendString "Stop " + """" + NowFiles + """", Retbuffer, Len(Retbuffer), 0
  Flag = "BtmStop" '�t���O
End Sub
Public Sub MusicPause() '�ꎞ��~
  mciSendString "Pause " + """" + NowFiles + """", Retbuffer, Len(Retbuffer), 0
 Flag = "Pause" '�t���O
End Sub
Public Sub MusicResume() '�ĊJ
  mciSendString "Resume " + """" + NowFiles + """", Retbuffer, Len(Retbuffer), 0
End Sub
Public Sub MusicClose(FileName As String) '����
 mciSendString "Close " + """" + FileName + """", Retbuffer, Len(Retbuffer), 0  '����
End Sub
Public Sub MusicPosition(Position As Long) '������E�����߂�
 SeekPosition = Position * 1000 '�l�����킹��
   mciSendString "Seek """ & NowFiles & """ to " & SeekPosition + Val(StartPosition), Retbuffer, Len(Retbuffer), 0 '�Đ��ʒu�ύX
End Sub
Public Sub VolumeChange(Value As Integer)
 mciSendString "SetAudio """ & NowFiles & """  Volume to " & Value, "", 0, 0
End Sub
Function Status() '���
 mciSendString "Status " + """" + NowFiles + """" + " mode", Retbuffer, Len(Retbuffer), 0   '��Ԏ擾
 
 If InStr(Retbuffer, "playing") = 1 Then
  Status = "�Đ���"
  Control.DiviceType (NowFiles) '�f�o�C�X
  If FileType = "cdaudio" Then 'CD�̏ꍇ
   E = EndPosition \ 1000
   N = NowPosition \ 1000
   If E <= N Or E <= (N - 1) Or E <= (N + 1) Then
    Form1.Toolbar.Buttons.Item(10).Value = tbrPressed '����
    Buttom.MusicNext '���̋�
   End If
  End If
 Else
 If InStr(Retbuffer, "paused") = 1 Then
  Status = "�ꎞ��~"
 Else
 If InStr(Retbuffer, "stopped") = 1 Then
  Status = "��~"
  If Flag = "Play" Then
   Form1.Toolbar.Buttons.Item(10).Value = tbrPressed '����
   Buttom.MusicNext '���̋�
  End If
 Else
  Status = "��~"
 End If
 End If
 End If

End Function

Function NowTime() '�Đ�����
  mciSendString "Status " + """" + NowFiles + """" + " position", Retbuffer, Len(Retbuffer), 0 '�Đ�����
  
 PlayPosition = (Val(Retbuffer) - Val(StartPosition)) / 1000 '�Đ��ʒu���ݒl�i�X���C�_�[�p�j
   NowPosition = Val(Retbuffer)
  Retbuffer = Val(Retbuffer) - Val(StartPosition)
' Form1.Caption = StartPosition & "/" & NowPosition & "/" & EndPosition
 
 M = Val(Retbuffer) \ 1000 \ 60 '����
 S = Val(Retbuffer) \ 1000 Mod 60 '�b��
 
  If M < 10 Then '0��t������
  M = "0" & M
 End If
 If S < 10 Then '0��t������
  S = "0" & S
 End If

  NowTime = M & ":" & S '�o��
End Function
Function AllTime() '��������
 Control.DiviceType (Control.Files) '�f�o�C�X�̎��
If FileType = "cdaudio" Then 'CD�̏ꍇ
  trackno = Control.GetTrack(Files, "No") '�g���b�N�擾
  A = " track " & trackno 'CD�p
End If

  mciSendString "Status " + """" + Files + """" + " length" + A, Retbuffer, Len(Retbuffer), 0  '�������Ԏ擾
  EndPosition = Val(Retbuffer) + Val(StartPosition) '�I���ʒu
  AllPosition = (Val(Retbuffer)) / 1000 '�Đ��ʒu�ő�l�i�X���C�_�[�p)

 M = Val(Retbuffer) \ 1000 \ 60  '����
 S = Val(Retbuffer) \ 1000 Mod 60 '�b��
 
  If M < 10 Then '0��t������
  M = "0" & M
 End If
 If S < 10 Then '0��t������
  S = "0" & S
 End If
 
 AllTime = M & ":" & S '�o��
End Function
Function GetTrack(FileName As String, Flag As String) '�g���b�N�擾
 If Flag = "No" Then '�g���b�N�ԍ�
  GetTrack = Val(Left(Right(FileName, 6), 2)) '�g���b�N
 End If
 If Flag = "StartPosition" Then '�Đ��J�n�ʒu
   trackno = Control.GetTrack(FileName, "No") '�g���b�N�擾
  mciSendString "Status " + """" + NowFiles + """" + " position track " & trackno, Retbuffer, Len(Retbuffer), 0 '�^�C���t�H�[�}�b�g
    GetTrack = Val(Retbuffer) '�J�n�ʒu���
 End If
 If Flag = "EndPosition" Then '�Đ��I���ʒu
  trackno = Control.GetTrack(FileName, "No") '�g���b�N�擾
    mciSendString "Status " + """" + Files + """" + " length track " & trackno, Retbuffer, Len(Retbuffer), 0  '�������Ԏ擾
    GetTrack = Val(Retbuffer)  '�I���ʒu
End If
End Function
Function GetMp3Tag(FileName As String, Types As String)

'ID3v1�͖������Ă܂��B�S��ID3v1.1���ƍl���ď���

Dim FilesLen As Long
Dim ID3v1 As tagID3v1

DoEvents
    Open FileName For Binary As #2
    '�t�@�C�����ُ�
    If LOF(2) <= 128 Then
        GetMp3Tag = "None"
        Close #2
        Exit Function
    End If

    FilesLen = FileLen(FileName)
    Get #2, FilesLen - 127, ID3v1

    If ID3v1.Header <> "TAG" Then
        GetMp3Tag = "None"
    Else 'ID3v1������ꍇ�̏���
     If Types = "Title" Then '�Ȗ�
      GetMp3Tag = DelNull(ID3v1.MusicName)
     Else
     If Types = "Artist" Then '�A�[�e�B�X�g
      GetMp3Tag = DelNull(ID3v1.ArtistName)
     Else
     If Types = "Albam" Then '�A���o����
      GetMp3Tag = DelNull(ID3v1.AlbamName)
     Else
     If Types = "Make" Then '����N
      GetMp3Tag = DelNull(ID3v1.MakeYear)
     Else
     If Types = "Coment" Then '�R�����g
      GetMp3Tag = DelNull(ID3v1.Coment)
     Else
     If Types = "Track" Then '�g���b�N
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

'Null��������菜������
Private Function DelNull(Buffer As String) As String
    If InStr(Buffer, vbNullChar) Then
        DelNull = Left$(Buffer, InStr(Buffer, vbNullChar) - 1)
    Else
        DelNull = Buffer
    End If
End Function

    
