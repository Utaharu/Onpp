Attribute VB_Name = "Buttom"
Public PlayMode As String '�Đ����[�h
Public AddNum As Integer

Public PlayNo As Long '�Đ��ԍ�
Public PlayPosition As Long '�Đ��ʒu
Public AllPosition As Long '�����ʒu
Public Sub MusicOpen(FileName As String) '�Ȓǉ�
  Control.Files = FileName '�t�@�C�����[�g�̑��
   Control.MusicOpen '�Ȃ��J���ď��擾
  
  Form1.List.ListItems.Add , , Form1.List.ListItems.Count + 1 'No
 
  If Control.GetMp3Tag(FileName, "Title") <> "None" Then '�Ȗ��擾
   Form1.List.ListItems.Item(Form1.List.ListItems.Count).ListSubItems.Add , , Trim(Control.GetMp3Tag(Control.Files, "Title")) '�^�O��
  Else
    Form1.List.ListItems.Item(Form1.List.ListItems.Count).ListSubItems.Add , , Left(Dir(Control.Files), Len(Dir(Control.Files)) - 4) '�t�@�C������
  End If

   Form1.List.ListItems.Item(Form1.List.ListItems.Count).ListSubItems.Add , , Trim(Control.AllTime) '����
   Form1.List.ListItems.Item(Form1.List.ListItems.Count).ListSubItems.Item(2).Tag = Control.GetTrack(Control.Files, "EndPosition") '�I���ʒu���^�O��
    Form1.List.ListItems.Item(Form1.List.ListItems.Count).ListSubItems.Add , , Trim(Control.GetMp3Tag(Control.Files, "Artist")) '�A�[�e�B�X�g

   Form1.List.ListItems.Item(Form1.List.ListItems.Count).Tag = Control.Files '�A�N�Z�X������X�g�ɖ��ߍ���
  Buttom.ButtonOnOff '�{�^���̗L������
  
   Control.MusicClose (Control.Files) '����
    
End Sub
Public Sub MusicOneDel() '1�ȍ폜
If Form1.List.ListItems.Count > 0 Then '�Ȃ̗L��
 If Form1.Toolbar.Buttons.Item("PlayBtm").Value = tbrUnpressed And Form1.Toolbar.Buttons.Item("PauseBtm").Value = tbrUnpressed Then
   Form1.List.ListItems.Remove (Form1.List.SelectedItem.Index) '�폜
    For num = 1 To Form1.List.ListItems.Count Step 1
     Form1.List.ListItems.Item(num).Text = num '�ԍ���������
    Next
    Form1.Status = "1�ȍ폜���܂����B" '���
     Buttom.ButtonOnOff '�{�^���̗L������
        Control.MusicClose ("all")
 If Form1.List.ListItems.Count > 0 Then '�Ȃ̗L��
  If Form1.List.ListItems.Count >= Form1.List.SelectedItem.Index Then  '�Ȃ����ɂ܂������
    Form1.List.ListItems.Item(Form1.List.SelectedItem.Index).Selected = True '�����ʒu�I��
  Else '�������
   Form1.List.ListItems.Item(Form1.List.SelectedItem.Index - 1).Selected = True '1�ȑO��I��
  End If
 End If
   Form1.List.SetFocus '�t�H�[�J�X�𓖂Ă�
   Buttom.ButtonOnOff '�{�^���̗L����
  Else
   Form1.Status = "�Đ������ꎞ��~���ׁ̈A�폜�ł��܂���B" '���
 End If
Else
 Form1.Status = "�Ȃ��ǉ�����Ă��܂���B" '���
End If
 Form1.InfoPaint
End Sub
Public Sub MusicAllDel() '�S�ȍ폜
 If Form1.Toolbar.Buttons.Item("PlayBtm").Value = tbrUnpressed And Form1.Toolbar.Buttons.Item("PauseBtm").Value = tbrUnpressed Then
  Form1.List.ListItems.Clear '����
  Form1.Status = "�S�ȍ폜���܂����B" '���
   Buttom.ButtonOnOff '�{�^���̗L������
    Control.MusicClose ("all")
 Else
   Form1.Status = "�Đ������ꎞ��~���ׁ̈A�폜�ł��܂���B" '���
 End If
  Form1.InfoPaint
End Sub

Public Sub MusicPlay() '�Đ�
If Form1.List.ListItems.Count > 0 Then

 Buttom.PlayButtonReset '�{�^����OFF
 Form1.Toolbar.Buttons.Item("PlayBtm").Image = 2 'ON
  Form1.Toolbar.Buttons.Item("PlayBtm").Value = tbrPressed '�����ꂽ�܂�
   Control.DiviceType (Control.Files)
  If Control.Flag = "BtmStop" And Control.FileType = "cdaudio" Then
      Control.MusicClose (Control.Files)
  End If
 Control.Files = Form1.List.SelectedItem.Tag '�t�@�C�����[�g
 Control.MusicOpen '�J��
 Control.MusicPlay '�Đ�
 PlayNo = Form1.List.SelectedItem.Index '�Đ��ԍ�
  
 Form1.List.SelectedItem.EnsureVisible
 
 Control.Files = Form1.List.ListItems.Item(PlayNo).Tag '�Đ����̃t�@�C��
 Control.AllTime '�������Ԃ̎擾-�Đ��ʒu�̍ő�l���擾
 
 On Error Resume Next
 Form1.Slider.Max = AllPosition '�Đ��ʒu�̍ő�l
 
 Form1.PlayTime.Enabled = True '�Đ�����
 Form1.Scroll.Enabled = True '�����X�N���[��ON
End If
 Buttom.ButtonOnOff '�{�^���̗L������

End Sub
Public Sub MusicStop(closeflag As Boolean) '��~
If Form1.List.ListItems.Count > 0 Then
 Buttom.PlayButtonReset '�{�^����OFF
 Form1.Toolbar.Buttons.Item("StopBtm").Image = 4 'ON
 Form1.Toolbar.Buttons.Item("StopBtm").Value = tbrPressed '�����ꂽ�܂�
 Control.MusicStop
 If closeflag = True Then
   Control.MusicClose ("all")
 End If
End If
 Buttom.ButtonOnOff '�{�^���̗L������
End Sub
Public Sub MusicPause() '�ꎞ��~
If Form1.List.ListItems.Count > 0 Then
 Buttom.PlayButtonReset '�{�^����OFF
 Form1.Toolbar.Buttons.Item("PauseBtm").Image = 6 'ON
 Form1.Toolbar.Buttons.Item("PauseBtm").Value = tbrPressed '�����ꂽ�܂�
 Control.MusicPause
End If
 Buttom.ButtonOnOff '�{�^���̗L������
End Sub
Public Sub MusicNext() '����
If Form1.List.ListItems.Count > 0 Then
  Control.MusicPosition (0) '�Đ��ʒu���ŏ��ɂ���
 Buttom.PlayButtonReset '�{�^����OFF
 Form1.Toolbar.Buttons.Item("NextBtm").Image = 8 'ON
  Buttom.MusicStop (True) '��~
  Form1.List.ListItems.Item(PlayNo).Selected = True '���ݍĐ����̂�I������B
'  Form1.List.SetFocus
'���[�h��
 If PlayMode = "Random" Then '�����_���Đ�
  Randomize
   Form1.List.ListItems.Item(Int(Rnd * Form1.List.ListItems.Count) + 1).Selected = True '�����_���Ɏ��̋Ȃ�I��
'    Form1.List.SetFocus
    Buttom.MusicPlay '�Đ�
 Else
  If Form1.List.SelectedItem.Index < Form1.List.ListItems.Count Then '�ʏ�Đ�/�J��Ԃ��Đ� - ���ɋȂ�����
    Form1.List.ListItems.Item(Form1.List.SelectedItem.Index + 1).Selected = True '���̋Ȃ�I��
'     Form1.List.SetFocus
     Buttom.MusicPlay '�Đ�
  Else
   Form1.List.ListItems.Item(1).Selected = True '�ŏ��̋Ȃ�I��
   PlayNo = 1 '�Đ��ԍ��ύX
    If PlayMode = "Repeat" Then '�J��Ԃ��Đ�
'      Form1.List.SetFocus
      Buttom.MusicPlay '�Đ�
    End If
  End If
 End If
 Form1.Toolbar.Buttons.Item("NextBtm").Image = 7 'off
End If
 Buttom.ButtonOnOff '�{�^���̗L������
End Sub
Public Sub MusicBack() '�O��
 Buttom.ButtonOnOff '�{�^���̗L������
If Form1.List.ListItems.Count > 0 Then
  Control.MusicPosition (0) '�Đ��ʒu���ŏ��̈ʒu��
 Buttom.PlayButtonReset '�{�^����OFF
 Form1.Toolbar.Buttons.Item("BackBtm").Image = 10 'ON
  Buttom.MusicStop (True)   '��~
  Form1.List.ListItems.Item(PlayNo).Selected = True '���ݍĐ����̂�I������B
  Form1.List.SetFocus
  
  If Form1.List.SelectedItem.Index > 1 Then '�O�ɋȂ�����
   Form1.List.ListItems.Item(Form1.List.SelectedItem.Index - 1).Selected = True '�O�̋Ȃ�I��
   Form1.List.SetFocus
    Buttom.MusicPlay '�Đ�
  Else
    Form1.List.ListItems.Item(Form1.List.ListItems.Count).Selected = True '�Ō�̋Ȃ�I��
    Form1.List.SetFocus
    Buttom.MusicPlay '�Đ�
  End If
 Form1.Toolbar.Buttons.Item("BackBtm").Image = 9 'Off
End If
End Sub
Public Sub ListShuffle()
    Form1.Toolbar.Buttons.Item("ListShuffle").Image = 18 'ON
    If Form1.Toolbar.Buttons.Item("PlayBtm").Value = tbrUnpressed And Form1.Toolbar.Buttons.Item("PauseBtm").Value = tbrUnpressed Then
    
    '�V���b�t�����ă��X�g���`��
        Form1.BackList.ListItems.Clear
     
    '�V���b�t��
        Do While (Form1.List.ListItems.Count <> 0)
            Dim LNo As Integer
    
            Randomize
     
            LNo = Int(Rnd * Form1.List.ListItems.Count) + 1
     
            Form1.BackList.ListItems.Add = Form1.BackList.ListItems.Count + 1
            Form1.BackList.ListItems(Form1.BackList.ListItems.Count).Tag = Form1.List.ListItems(LNo).Tag
            Form1.BackList.ListItems(Form1.BackList.ListItems.Count).ListSubItems.Add = Form1.List.ListItems(LNo).ListSubItems(1).Text
            Form1.BackList.ListItems(Form1.BackList.ListItems.Count).ListSubItems.Add = Form1.List.ListItems(LNo).ListSubItems(2).Text
            Form1.BackList.ListItems(Form1.BackList.ListItems.Count).ListSubItems.Add = Form1.List.ListItems(LNo).ListSubItems(3).Text
    
            Form1.List.ListItems.Remove (LNo)
        Loop
    
        '���̕\�����X�g�ɃR�s�[
         Form1.List.ListItems.Clear
    
        For A = 1 To Form1.BackList.ListItems.Count
            Form1.List.ListItems.Add = A
            Form1.List.ListItems(A).Tag = Form1.BackList.ListItems(A).Tag
            Form1.List.ListItems(A).ListSubItems.Add = Form1.BackList.ListItems(A).ListSubItems(1).Text
            Form1.List.ListItems(A).ListSubItems.Add = Form1.BackList.ListItems(A).ListSubItems(2).Text
            Form1.List.ListItems(A).ListSubItems.Add = Form1.BackList.ListItems(A).ListSubItems(3).Text
        Next
    
        '�o�b�N���X�g�̏���
       Form1.BackList.ListItems.Clear
    
     Else
        Form1.Status = "�Đ������ꎞ��~���ׁ̈A�폜�ł��܂���B" '���
     End If
  Form1.InfoPaint
    
  Form1.Toolbar.Buttons.Item("ListShuffle").Image = 17 'Off
   Form1.Toolbar.Buttons.Item("ListShuffle").Value = tbrUnpressed
End Sub
Public Sub MusicListSave(FileName As String, Mode As String) '�ۑ�
 Open FileName For Output As #1 '�t�@�C�����J��
   
    If Mode = "Close" Then
        Dim md, pl, no, ps As Integer
     
        If Form1.Toolbar.Buttons.Item("NormalPlay").Value = tbrPressed Then md = 1 '�Đ����[�h
        If Form1.Toolbar.Buttons.Item("RepeatPlay").Value = tbrPressed Then md = 2
        If Form1.Toolbar.Buttons.Item("PlayList").Value = tbrUnpressed Then pl = 0 '���X�g�\��
        If Form1.Toolbar.Buttons.Item("PlayList").Value = tbrPressed Then pl = 1
        If Form1.List.ListItems.Count > 0 Then no = PlayNo Else no = 0 '�Đ��ԍ�
            ps = Form1.Slider.Value '�Đ��ʒu
        Write #1, md, pl, no, ps, Form1.Volume.Value '�ۑ�
    End If
   
   
   For A = 1 To Form1.List.ListItems.Count Step 1
    Form1.List.ListItems.Item(A).Selected = True '�I��
    Form1.List.SetFocus
       Write #1, Form1.List.SelectedItem.Tag, Form1.List.SelectedItem.ListSubItems(1).Text, Form1.List.SelectedItem.ListSubItems(2).Text, Form1.List.SelectedItem.ListSubItems(2).Tag, Form1.List.SelectedItem.ListSubItems(3).Text '�f�[�^�ۑ�
   Next
 Close #1 '����
End Sub
Public Sub MusicListLoad(FileName As String, Mode As String) '�ǂݍ���
    Dim cFso As FileSystemObject
    Set cFso = New FileSystemObject
    

    Dim ReadData(5) As String
    
    Open FileName For Input As #1 '�J��
 
    Do Until EOF(1)
        Dim mfdat() As String
        cnt = cnt + 1
        
         Input #1, ReadData(0), ReadData(1), ReadData(2), ReadData(3), ReadData(4) '�t�@�C������P�s�Ǎ�
        
        If Mode = "Start" And cnt = 1 Then
           Dim Data() As String
           
           Select Case Val(ReadData(0))
         Case 1:
          Form1.Toolbar.Buttons.Item("NormalPlay").Value = tbrPressed '�ʏ�Đ�ON
          Form1.Toolbar.Buttons.Item("NormalPlay").Image = 14 'ON
          Buttom.PlayMode = "Nomal" '�Đ����[�h
         Case 2:
           Form1.Toolbar.Buttons.Item("RepeatPlay").Value = tbrPressed '�J��Ԃ��Đ�ON
           Form1.Toolbar.Buttons.Item("RepeatPlay").Image = 16 'ON
           Buttom.PlayMode = "Repeat" '�Đ����[�h
        End Select
        Select Case Val(ReadData(1))
         Case 0:
           'Form1.Height = 1475
            Form1.Height = Form1.Slider.Top + Form1.Slider.Height + 350
           Form1.Toolbar.Buttons.Item("PlayList").Image = 23 'OFF
           Form1.Toolbar.Buttons.Item("PlayList").Value = tbrUnpressed
         Case 1:
           'Form1.Height = 2685
           Form1.Height = 2805
           Form1.Toolbar.Buttons.Item("PlayList").Image = 24 'ON
           Form1.Toolbar.Buttons.Item("PlayList").Value = tbrPressed
         End Select
          PlayNo = Val(ReadData(2)) '�Đ��ԍ�
          Form1.Volume.Value = Val(ReadData(4)) '����
          Form1.VolumeVal.Text = Form1.Volume.Value
         
          Form1.Visible = True '�t�H�[���\��
        
        Else
         
                
            If cFso.FileExists(ReadData(0)) Then
                AddNum = AddNum + 1
                    
                Form1.List.ListItems.Add , , Form1.List.ListItems.Count + 1
                    Form1.List.ListItems(Form1.List.ListItems.Count).Tag = ReadData(0)
                Form1.List.ListItems(Form1.List.ListItems.Count).ListSubItems.Add , , ReadData(1)
                Form1.List.ListItems(Form1.List.ListItems.Count).ListSubItems.Add , , ReadData(2)
                    Form1.List.ListItems(Form1.List.ListItems.Count).ListSubItems(2).Tag = Val(ReadData(3))
                Form1.List.ListItems(Form1.List.ListItems.Count).ListSubItems.Add , , ReadData(4)
            End If
        
        End If
        
       If Mode = "Start" Then
         Form1.Status = "��ԕ����� - " & AddNum & "�Ȓǉ�" '���
         Times = "--:--/--:--" '���ԕ\��
         Form1.InfoPaint '�X�V
       End If
    Loop
   
    If Mode = "Start" Then
      If (cnt - 1) = AddNum Then Form1.Status = "�O��̃��X�g����" & AddNum & "�Ȓǉ����܂����B" Else Form1.Status = "�O�񃊃X�g����" & AddNum & "/" & (cnt - 1) & "�Ȓǉ����܂����B"
    Else
         If cnt = AddNum Then Form1.Status = "���X�g����" & AddNum & "�Ȓǉ����܂����B" Else Form1.Status = "���X�g����" & AddNum & "/" & cnt & "�Ȓǉ����܂����B"
         
           If AddNum > 0 Then MsgBox "���X�g����" & AddNum & "�Ȓǉ����܂����B", , "����Ղ���"
    End If
   

   
 Close #1
 
     Set cFso = Nothing
     
  Form1.InfoPaint
End Sub
Public Sub PlayButtonReset() '�{�^����OFF�ɂ���
  Form1.Toolbar.Buttons.Item("PlayBtm").Image = 1 'OFF
  Form1.Toolbar.Buttons.Item("StopBtm").Image = 3 'OFF
  Form1.Toolbar.Buttons.Item("PauseBtm").Image = 5 'OFF
End Sub
Public Sub ModeButtonReset() '���[�h�{�^����OFF�ɂ���
  Form1.Toolbar.Buttons.Item("NormalPlay").Image = 13 'OFF
  Form1.Toolbar.Buttons.Item("RepeatPlay").Image = 15 'OFF
End Sub
Public Sub ButtonOnOff() '�{�^���L����
 If Form1.Toolbar.Buttons.Item("PlayBtm").Value = tbrPressed Then '�Đ���ON
  Form1.Toolbar.Buttons.Item("PlayBtm").Enabled = True '�Đ�
  Form1.Toolbar.Buttons.Item("StopBtm").Enabled = True '��~
  Form1.Toolbar.Buttons.Item("PauseBtm").Enabled = True '�ꎞ��~
 End If
 If Form1.Toolbar.Buttons.Item("StopBtm").Value = tbrPressed Then '��~��ON
  Form1.Toolbar.Buttons.Item("PlayBtm").Enabled = True '�Đ�
  Form1.Toolbar.Buttons.Item("StopBtm").Enabled = False '��~
  Form1.Toolbar.Buttons.Item("PauseBtm").Enabled = False '�ꎞ��~
 End If
 If Form1.Toolbar.Buttons.Item("PauseBtm").Value = tbrPressed Then '�ꎞ��~��ON
  Form1.Toolbar.Buttons.Item("PlayBtm").Enabled = True '�Đ�
  Form1.Toolbar.Buttons.Item("StopBtm").Enabled = False '��~
  Form1.Toolbar.Buttons.Item("PauseBtm").Enabled = False '�ꎞ��~
 End If
 If Form1.List.ListItems.Count > 0 Then 'ON
  Form1.Toolbar.Buttons.Item("PlayBtm").Enabled = True '�Đ�
  Form1.Toolbar.Buttons.Item("BackBtm").Enabled = True '�O��
  Form1.Toolbar.Buttons.Item("NextBtm").Enabled = True '����
  Form1.Slider.Enabled = True '�X���C�_
 End If
 If Form1.List.ListItems.Count <= 0 Then 'OFF
  Form1.Toolbar.Buttons.Item("PlayBtm").Enabled = False '�Đ�
  Form1.Toolbar.Buttons.Item("StopBtm").Enabled = False '��~
  Form1.Toolbar.Buttons.Item("PauseBtm").Enabled = False '�ꎞ��~
  Form1.Toolbar.Buttons.Item("BackBtm").Enabled = False '�O��
  Form1.Toolbar.Buttons.Item("NextBtm").Enabled = False '����
  Form1.Slider.Enabled = False '�X���C�_
 End If

End Sub

