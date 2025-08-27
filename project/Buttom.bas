Attribute VB_Name = "Buttom"
Public PlayMode As String '再生モード
Public AddNum As Integer

Public PlayNo As Long '再生番号
Public PlayPosition As Long '再生位置
Public AllPosition As Long '総合位置
Public Sub MusicOpen(FileName As String) '曲追加
  Control.Files = FileName 'ファイルルートの代入
   Control.MusicOpen '曲を開いて情報取得
  
  Form1.List.ListItems.Add , , Form1.List.ListItems.Count + 1 'No
 
  If Control.GetMp3Tag(FileName, "Title") <> "None" Then '曲名取得
   Form1.List.ListItems.Item(Form1.List.ListItems.Count).ListSubItems.Add , , Trim(Control.GetMp3Tag(Control.Files, "Title")) 'タグ内
  Else
    Form1.List.ListItems.Item(Form1.List.ListItems.Count).ListSubItems.Add , , Left(Dir(Control.Files), Len(Dir(Control.Files)) - 4) 'ファイル名を
  End If

   Form1.List.ListItems.Item(Form1.List.ListItems.Count).ListSubItems.Add , , Trim(Control.AllTime) '時間
   Form1.List.ListItems.Item(Form1.List.ListItems.Count).ListSubItems.Item(2).Tag = Control.GetTrack(Control.Files, "EndPosition") '終了位置をタグに
    Form1.List.ListItems.Item(Form1.List.ListItems.Count).ListSubItems.Add , , Trim(Control.GetMp3Tag(Control.Files, "Artist")) 'アーティスト

   Form1.List.ListItems.Item(Form1.List.ListItems.Count).Tag = Control.Files 'アクセス先をリストに埋め込む
  Buttom.ButtonOnOff 'ボタンの有効無効
  
   Control.MusicClose (Control.Files) '閉じる
    
End Sub
Public Sub MusicOneDel() '1曲削除
If Form1.List.ListItems.Count > 0 Then '曲の有無
 If Form1.Toolbar.Buttons.Item("PlayBtm").Value = tbrUnpressed And Form1.Toolbar.Buttons.Item("PauseBtm").Value = tbrUnpressed Then
   Form1.List.ListItems.Remove (Form1.List.SelectedItem.Index) '削除
    For num = 1 To Form1.List.ListItems.Count Step 1
     Form1.List.ListItems.Item(num).Text = num '番号書き換え
    Next
    Form1.Status = "1曲削除しました。" '状態
     Buttom.ButtonOnOff 'ボタンの有効無効
        Control.MusicClose ("all")
 If Form1.List.ListItems.Count > 0 Then '曲の有無
  If Form1.List.ListItems.Count >= Form1.List.SelectedItem.Index Then  '曲が後ろにまだあれば
    Form1.List.ListItems.Item(Form1.List.SelectedItem.Index).Selected = True '同じ位置選択
  Else '無ければ
   Form1.List.ListItems.Item(Form1.List.SelectedItem.Index - 1).Selected = True '1曲前を選択
  End If
 End If
   Form1.List.SetFocus 'フォーカスを当てる
   Buttom.ButtonOnOff 'ボタンの有無効
  Else
   Form1.Status = "再生中か一時停止中の為、削除できません。" '状態
 End If
Else
 Form1.Status = "曲が追加されていません。" '状態
End If
 Form1.InfoPaint
End Sub
Public Sub MusicAllDel() '全曲削除
 If Form1.Toolbar.Buttons.Item("PlayBtm").Value = tbrUnpressed And Form1.Toolbar.Buttons.Item("PauseBtm").Value = tbrUnpressed Then
  Form1.List.ListItems.Clear '消去
  Form1.Status = "全曲削除しました。" '状態
   Buttom.ButtonOnOff 'ボタンの有効無効
    Control.MusicClose ("all")
 Else
   Form1.Status = "再生中か一時停止中の為、削除できません。" '状態
 End If
  Form1.InfoPaint
End Sub

Public Sub MusicPlay() '再生
If Form1.List.ListItems.Count > 0 Then

 Buttom.PlayButtonReset 'ボタンをOFF
 Form1.Toolbar.Buttons.Item("PlayBtm").Image = 2 'ON
  Form1.Toolbar.Buttons.Item("PlayBtm").Value = tbrPressed '押されたまま
   Control.DiviceType (Control.Files)
  If Control.Flag = "BtmStop" And Control.FileType = "cdaudio" Then
      Control.MusicClose (Control.Files)
  End If
 Control.Files = Form1.List.SelectedItem.Tag 'ファイルルート
 Control.MusicOpen '開く
 Control.MusicPlay '再生
 PlayNo = Form1.List.SelectedItem.Index '再生番号
  
 Form1.List.SelectedItem.EnsureVisible
 
 Control.Files = Form1.List.ListItems.Item(PlayNo).Tag '再生中のファイル
 Control.AllTime '総合時間の取得-再生位置の最大値を取得
 
 On Error Resume Next
 Form1.Slider.Max = AllPosition '再生位置の最大値
 
 Form1.PlayTime.Enabled = True '再生時間
 Form1.Scroll.Enabled = True '文字スクロールON
End If
 Buttom.ButtonOnOff 'ボタンの有効無効

End Sub
Public Sub MusicStop(closeflag As Boolean) '停止
If Form1.List.ListItems.Count > 0 Then
 Buttom.PlayButtonReset 'ボタンをOFF
 Form1.Toolbar.Buttons.Item("StopBtm").Image = 4 'ON
 Form1.Toolbar.Buttons.Item("StopBtm").Value = tbrPressed '押されたまま
 Control.MusicStop
 If closeflag = True Then
   Control.MusicClose ("all")
 End If
End If
 Buttom.ButtonOnOff 'ボタンの有効無効
End Sub
Public Sub MusicPause() '一時停止
If Form1.List.ListItems.Count > 0 Then
 Buttom.PlayButtonReset 'ボタンをOFF
 Form1.Toolbar.Buttons.Item("PauseBtm").Image = 6 'ON
 Form1.Toolbar.Buttons.Item("PauseBtm").Value = tbrPressed '押されたまま
 Control.MusicPause
End If
 Buttom.ButtonOnOff 'ボタンの有効無効
End Sub
Public Sub MusicNext() '次曲
If Form1.List.ListItems.Count > 0 Then
  Control.MusicPosition (0) '再生位置を最初にする
 Buttom.PlayButtonReset 'ボタンをOFF
 Form1.Toolbar.Buttons.Item("NextBtm").Image = 8 'ON
  Buttom.MusicStop (True) '停止
  Form1.List.ListItems.Item(PlayNo).Selected = True '現在再生中のを選択する。
'  Form1.List.SetFocus
'モード別
 If PlayMode = "Random" Then 'ランダム再生
  Randomize
   Form1.List.ListItems.Item(Int(Rnd * Form1.List.ListItems.Count) + 1).Selected = True 'ランダムに次の曲を選択
'    Form1.List.SetFocus
    Buttom.MusicPlay '再生
 Else
  If Form1.List.SelectedItem.Index < Form1.List.ListItems.Count Then '通常再生/繰り返し再生 - 次に曲がある
    Form1.List.ListItems.Item(Form1.List.SelectedItem.Index + 1).Selected = True '次の曲を選択
'     Form1.List.SetFocus
     Buttom.MusicPlay '再生
  Else
   Form1.List.ListItems.Item(1).Selected = True '最初の曲を選択
   PlayNo = 1 '再生番号変更
    If PlayMode = "Repeat" Then '繰り返し再生
'      Form1.List.SetFocus
      Buttom.MusicPlay '再生
    End If
  End If
 End If
 Form1.Toolbar.Buttons.Item("NextBtm").Image = 7 'off
End If
 Buttom.ButtonOnOff 'ボタンの有効無効
End Sub
Public Sub MusicBack() '前曲
 Buttom.ButtonOnOff 'ボタンの有効無効
If Form1.List.ListItems.Count > 0 Then
  Control.MusicPosition (0) '再生位置を最初の位置へ
 Buttom.PlayButtonReset 'ボタンをOFF
 Form1.Toolbar.Buttons.Item("BackBtm").Image = 10 'ON
  Buttom.MusicStop (True)   '停止
  Form1.List.ListItems.Item(PlayNo).Selected = True '現在再生中のを選択する。
  Form1.List.SetFocus
  
  If Form1.List.SelectedItem.Index > 1 Then '前に曲がある
   Form1.List.ListItems.Item(Form1.List.SelectedItem.Index - 1).Selected = True '前の曲を選択
   Form1.List.SetFocus
    Buttom.MusicPlay '再生
  Else
    Form1.List.ListItems.Item(Form1.List.ListItems.Count).Selected = True '最後の曲を選択
    Form1.List.SetFocus
    Buttom.MusicPlay '再生
  End If
 Form1.Toolbar.Buttons.Item("BackBtm").Image = 9 'Off
End If
End Sub
Public Sub ListShuffle()
    Form1.Toolbar.Buttons.Item("ListShuffle").Image = 18 'ON
    If Form1.Toolbar.Buttons.Item("PlayBtm").Value = tbrUnpressed And Form1.Toolbar.Buttons.Item("PauseBtm").Value = tbrUnpressed Then
    
    'シャッフルしてリストを形成
        Form1.BackList.ListItems.Clear
     
    'シャッフル
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
    
        '元の表示リストにコピー
         Form1.List.ListItems.Clear
    
        For A = 1 To Form1.BackList.ListItems.Count
            Form1.List.ListItems.Add = A
            Form1.List.ListItems(A).Tag = Form1.BackList.ListItems(A).Tag
            Form1.List.ListItems(A).ListSubItems.Add = Form1.BackList.ListItems(A).ListSubItems(1).Text
            Form1.List.ListItems(A).ListSubItems.Add = Form1.BackList.ListItems(A).ListSubItems(2).Text
            Form1.List.ListItems(A).ListSubItems.Add = Form1.BackList.ListItems(A).ListSubItems(3).Text
        Next
    
        'バックリストの消去
       Form1.BackList.ListItems.Clear
    
     Else
        Form1.Status = "再生中か一時停止中の為、削除できません。" '状態
     End If
  Form1.InfoPaint
    
  Form1.Toolbar.Buttons.Item("ListShuffle").Image = 17 'Off
   Form1.Toolbar.Buttons.Item("ListShuffle").Value = tbrUnpressed
End Sub
Public Sub MusicListSave(FileName As String, Mode As String) '保存
 Open FileName For Output As #1 'ファイルを開く
   
    If Mode = "Close" Then
        Dim md, pl, no, ps As Integer
     
        If Form1.Toolbar.Buttons.Item("NormalPlay").Value = tbrPressed Then md = 1 '再生モード
        If Form1.Toolbar.Buttons.Item("RepeatPlay").Value = tbrPressed Then md = 2
        If Form1.Toolbar.Buttons.Item("PlayList").Value = tbrUnpressed Then pl = 0 'リスト表示
        If Form1.Toolbar.Buttons.Item("PlayList").Value = tbrPressed Then pl = 1
        If Form1.List.ListItems.Count > 0 Then no = PlayNo Else no = 0 '再生番号
            ps = Form1.Slider.Value '再生位置
        Write #1, md, pl, no, ps, Form1.Volume.Value '保存
    End If
   
   
   For A = 1 To Form1.List.ListItems.Count Step 1
    Form1.List.ListItems.Item(A).Selected = True '選択
    Form1.List.SetFocus
       Write #1, Form1.List.SelectedItem.Tag, Form1.List.SelectedItem.ListSubItems(1).Text, Form1.List.SelectedItem.ListSubItems(2).Text, Form1.List.SelectedItem.ListSubItems(2).Tag, Form1.List.SelectedItem.ListSubItems(3).Text 'データ保存
   Next
 Close #1 '閉じる
End Sub
Public Sub MusicListLoad(FileName As String, Mode As String) '読み込み
    Dim cFso As FileSystemObject
    Set cFso = New FileSystemObject
    

    Dim ReadData(5) As String
    
    Open FileName For Input As #1 '開く
 
    Do Until EOF(1)
        Dim mfdat() As String
        cnt = cnt + 1
        
         Input #1, ReadData(0), ReadData(1), ReadData(2), ReadData(3), ReadData(4) 'ファイルから１行読込
        
        If Mode = "Start" And cnt = 1 Then
           Dim Data() As String
           
           Select Case Val(ReadData(0))
         Case 1:
          Form1.Toolbar.Buttons.Item("NormalPlay").Value = tbrPressed '通常再生ON
          Form1.Toolbar.Buttons.Item("NormalPlay").Image = 14 'ON
          Buttom.PlayMode = "Nomal" '再生モード
         Case 2:
           Form1.Toolbar.Buttons.Item("RepeatPlay").Value = tbrPressed '繰り返し再生ON
           Form1.Toolbar.Buttons.Item("RepeatPlay").Image = 16 'ON
           Buttom.PlayMode = "Repeat" '再生モード
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
          PlayNo = Val(ReadData(2)) '再生番号
          Form1.Volume.Value = Val(ReadData(4)) '音量
          Form1.VolumeVal.Text = Form1.Volume.Value
         
          Form1.Visible = True 'フォーム表示
        
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
         Form1.Status = "状態復元中 - " & AddNum & "曲追加" '状態
         Times = "--:--/--:--" '時間表示
         Form1.InfoPaint '更新
       End If
    Loop
   
    If Mode = "Start" Then
      If (cnt - 1) = AddNum Then Form1.Status = "前回のリストから" & AddNum & "曲追加しました。" Else Form1.Status = "前回リストから" & AddNum & "/" & (cnt - 1) & "曲追加しました。"
    Else
         If cnt = AddNum Then Form1.Status = "リストから" & AddNum & "曲追加しました。" Else Form1.Status = "リストから" & AddNum & "/" & cnt & "曲追加しました。"
         
           If AddNum > 0 Then MsgBox "リストから" & AddNum & "曲追加しました。", , "おんぷっぷ"
    End If
   

   
 Close #1
 
     Set cFso = Nothing
     
  Form1.InfoPaint
End Sub
Public Sub PlayButtonReset() 'ボタンをOFFにする
  Form1.Toolbar.Buttons.Item("PlayBtm").Image = 1 'OFF
  Form1.Toolbar.Buttons.Item("StopBtm").Image = 3 'OFF
  Form1.Toolbar.Buttons.Item("PauseBtm").Image = 5 'OFF
End Sub
Public Sub ModeButtonReset() 'モードボタンをOFFにする
  Form1.Toolbar.Buttons.Item("NormalPlay").Image = 13 'OFF
  Form1.Toolbar.Buttons.Item("RepeatPlay").Image = 15 'OFF
End Sub
Public Sub ButtonOnOff() 'ボタン有無効
 If Form1.Toolbar.Buttons.Item("PlayBtm").Value = tbrPressed Then '再生がON
  Form1.Toolbar.Buttons.Item("PlayBtm").Enabled = True '再生
  Form1.Toolbar.Buttons.Item("StopBtm").Enabled = True '停止
  Form1.Toolbar.Buttons.Item("PauseBtm").Enabled = True '一時停止
 End If
 If Form1.Toolbar.Buttons.Item("StopBtm").Value = tbrPressed Then '停止がON
  Form1.Toolbar.Buttons.Item("PlayBtm").Enabled = True '再生
  Form1.Toolbar.Buttons.Item("StopBtm").Enabled = False '停止
  Form1.Toolbar.Buttons.Item("PauseBtm").Enabled = False '一時停止
 End If
 If Form1.Toolbar.Buttons.Item("PauseBtm").Value = tbrPressed Then '一時停止がON
  Form1.Toolbar.Buttons.Item("PlayBtm").Enabled = True '再生
  Form1.Toolbar.Buttons.Item("StopBtm").Enabled = False '停止
  Form1.Toolbar.Buttons.Item("PauseBtm").Enabled = False '一時停止
 End If
 If Form1.List.ListItems.Count > 0 Then 'ON
  Form1.Toolbar.Buttons.Item("PlayBtm").Enabled = True '再生
  Form1.Toolbar.Buttons.Item("BackBtm").Enabled = True '前曲
  Form1.Toolbar.Buttons.Item("NextBtm").Enabled = True '次曲
  Form1.Slider.Enabled = True 'スライダ
 End If
 If Form1.List.ListItems.Count <= 0 Then 'OFF
  Form1.Toolbar.Buttons.Item("PlayBtm").Enabled = False '再生
  Form1.Toolbar.Buttons.Item("StopBtm").Enabled = False '停止
  Form1.Toolbar.Buttons.Item("PauseBtm").Enabled = False '一時停止
  Form1.Toolbar.Buttons.Item("BackBtm").Enabled = False '前曲
  Form1.Toolbar.Buttons.Item("NextBtm").Enabled = False '次曲
  Form1.Slider.Enabled = False 'スライダ
 End If

End Sub

