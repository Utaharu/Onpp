VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   AutoRedraw      =   -1  'True
   BorderStyle     =   1  '固定(実線)
   Caption         =   "おんぷっぷ"
   ClientHeight    =   2325
   ClientLeft      =   45
   ClientTop       =   360
   ClientWidth     =   5340
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   2325
   ScaleWidth      =   5340
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  '画面の中央
   Begin MSComctlLib.ListView BackList 
      Height          =   1095
      Left            =   2640
      TabIndex        =   5
      Top             =   1200
      Visible         =   0   'False
      Width           =   3495
      _ExtentX        =   6165
      _ExtentY        =   1931
      View            =   3
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   0   'False
      FullRowSelect   =   -1  'True
      GridLines       =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   0
      NumItems        =   4
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Text            =   "No"
         Object.Width           =   706
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   1
         Text            =   "曲名"
         Object.Width           =   4057
      EndProperty
      BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   2
         Text            =   "時間"
         Object.Width           =   1128
      EndProperty
      BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   3
         Text            =   "アーティスト"
         Object.Width           =   2751
      EndProperty
   End
   Begin VB.Timer PlayTime 
      Enabled         =   0   'False
      Interval        =   1
      Left            =   2160
      Top             =   1920
   End
   Begin MSComctlLib.Slider Slider 
      Height          =   255
      Left            =   0
      TabIndex        =   1
      Top             =   720
      Width           =   5295
      _ExtentX        =   9340
      _ExtentY        =   450
      _Version        =   393216
      Enabled         =   0   'False
      TickStyle       =   3
   End
   Begin VB.Timer Scroll 
      Enabled         =   0   'False
      Interval        =   500
      Left            =   2880
      Top             =   1920
   End
   Begin MSComctlLib.ImageList ImageList1 
      Left            =   600
      Top             =   1920
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   12
      ImageHeight     =   12
      MaskColor       =   16777215
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   24
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":1002
            Key             =   "Play_Off"
         EndProperty
         BeginProperty ListImage2 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":1204
            Key             =   "Play_On"
         EndProperty
         BeginProperty ListImage3 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":1406
            Key             =   "Stop_Off"
         EndProperty
         BeginProperty ListImage4 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":1608
            Key             =   "Stop_On"
         EndProperty
         BeginProperty ListImage5 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":180A
            Key             =   "Pause_Off"
         EndProperty
         BeginProperty ListImage6 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":1A0C
            Key             =   "Pause_On"
         EndProperty
         BeginProperty ListImage7 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":1C0E
            Key             =   "Next_Off"
         EndProperty
         BeginProperty ListImage8 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":1E10
            Key             =   "Next_On"
         EndProperty
         BeginProperty ListImage9 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":2012
            Key             =   "Back_Off"
         EndProperty
         BeginProperty ListImage10 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":2214
            Key             =   "Back_On"
         EndProperty
         BeginProperty ListImage11 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":2416
            Key             =   "One_Add"
         EndProperty
         BeginProperty ListImage12 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":2618
            Key             =   "Folder_Add"
         EndProperty
         BeginProperty ListImage13 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":281A
            Key             =   "Nomal_Off"
         EndProperty
         BeginProperty ListImage14 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":2A1C
            Key             =   "Nomal_On"
         EndProperty
         BeginProperty ListImage15 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":2C1E
            Key             =   "Repeat_Off"
         EndProperty
         BeginProperty ListImage16 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":2E20
            Key             =   "Repeat_On"
         EndProperty
         BeginProperty ListImage17 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":3022
            Key             =   "Shuffle_Off"
         EndProperty
         BeginProperty ListImage18 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":3224
            Key             =   "Shuffle_On"
         EndProperty
         BeginProperty ListImage19 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":3426
            Key             =   "One_Del"
         EndProperty
         BeginProperty ListImage20 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":3628
            Key             =   "All_Del"
         EndProperty
         BeginProperty ListImage21 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":382A
            Key             =   "New"
         EndProperty
         BeginProperty ListImage22 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":393C
            Key             =   "Save"
         EndProperty
         BeginProperty ListImage23 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":3A4E
            Key             =   "List_Off"
         EndProperty
         BeginProperty ListImage24 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "Form1.frx":3F30
            Key             =   "List_On"
         EndProperty
      EndProperty
   End
   Begin MSComDlg.CommonDialog Dialog 
      Left            =   3360
      Top             =   1920
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
      CancelError     =   -1  'True
      MaxFileSize     =   32767
   End
   Begin MSComctlLib.ListView List 
      Height          =   1335
      Left            =   0
      TabIndex        =   0
      Top             =   975
      Width           =   5295
      _ExtentX        =   9340
      _ExtentY        =   2355
      View            =   3
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   0   'False
      FullRowSelect   =   -1  'True
      GridLines       =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   0
      NumItems        =   4
      BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         Text            =   "No"
         Object.Width           =   706
      EndProperty
      BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   1
         Text            =   "曲名"
         Object.Width           =   4057
      EndProperty
      BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   2
         Text            =   "時間"
         Object.Width           =   1128
      EndProperty
      BeginProperty ColumnHeader(4) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
         SubItemIndex    =   3
         Text            =   "アーティスト"
         Object.Width           =   2751
      EndProperty
   End
   Begin MSComctlLib.Toolbar Toolbar 
      Align           =   1  '上揃え
      Height          =   270
      Left            =   0
      TabIndex        =   2
      Top             =   0
      Width           =   5340
      _ExtentX        =   9419
      _ExtentY        =   476
      ButtonWidth     =   503
      ButtonHeight    =   476
      Style           =   1
      ImageList       =   "ImageList1"
      HotImageList    =   "ImageList1"
      _Version        =   393216
      BeginProperty Buttons {66833FE8-8583-11D1-B16A-00C0F0283628} 
         NumButtons      =   20
         BeginProperty Button1 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "OneAdd"
            Object.ToolTipText     =   "曲の追加"
            ImageKey        =   "One_Add"
            Style           =   1
         EndProperty
         BeginProperty Button2 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "OneDel"
            Object.ToolTipText     =   "1曲削除"
            ImageKey        =   "One_Del"
            Style           =   1
         EndProperty
         BeginProperty Button3 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "FolderAdd"
            Object.ToolTipText     =   "フォルダから追加"
            ImageKey        =   "Folder_Add"
            Style           =   2
         EndProperty
         BeginProperty Button4 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "AllDel"
            Object.ToolTipText     =   "全曲削除"
            ImageKey        =   "All_Del"
            Style           =   1
         EndProperty
         BeginProperty Button5 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   4
         EndProperty
         BeginProperty Button6 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "PlayBtm"
            Object.ToolTipText     =   "再生"
            ImageKey        =   "Play_Off"
            Style           =   2
         EndProperty
         BeginProperty Button7 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "StopBtm"
            Object.ToolTipText     =   "停止"
            ImageKey        =   "Stop_Off"
            Style           =   2
         EndProperty
         BeginProperty Button8 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "PauseBtm"
            Object.ToolTipText     =   "一時停止"
            ImageKey        =   "Pause_Off"
            Style           =   2
         EndProperty
         BeginProperty Button9 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "BackBtm"
            Object.ToolTipText     =   "前曲"
            ImageKey        =   "Back_Off"
            Style           =   2
         EndProperty
         BeginProperty Button10 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Enabled         =   0   'False
            Key             =   "NextBtm"
            Object.ToolTipText     =   "次曲"
            ImageKey        =   "Next_Off"
            Style           =   2
         EndProperty
         BeginProperty Button11 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   4
         EndProperty
         BeginProperty Button12 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "NormalPlay"
            Object.ToolTipText     =   "通常再生"
            ImageKey        =   "Nomal_Off"
            Style           =   2
         EndProperty
         BeginProperty Button13 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "RepeatPlay"
            Object.ToolTipText     =   "リピート再生"
            ImageKey        =   "Repeat_Off"
            Style           =   2
         EndProperty
         BeginProperty Button14 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   4
         EndProperty
         BeginProperty Button15 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "ListShuffle"
            Object.ToolTipText     =   "リスト シャッフル"
            ImageKey        =   "Shuffle_Off"
            Style           =   1
         EndProperty
         BeginProperty Button16 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   4
         EndProperty
         BeginProperty Button17 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "ListSave"
            Object.ToolTipText     =   "曲リストの保存"
            ImageKey        =   "Save"
         EndProperty
         BeginProperty Button18 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   3
         EndProperty
         BeginProperty Button19 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Key             =   "PlayList"
            Object.ToolTipText     =   "プレイリスト"
            ImageKey        =   "List_On"
            Style           =   1
            Value           =   1
         EndProperty
         BeginProperty Button20 {66833FEA-8583-11D1-B16A-00C0F0283628} 
            Style           =   4
         EndProperty
      EndProperty
      Begin MSComCtl2.UpDown Volume 
         Height          =   270
         Left            =   5100
         TabIndex        =   4
         Top             =   0
         Width           =   255
         _ExtentX        =   450
         _ExtentY        =   476
         _Version        =   393216
         Value           =   1000
         BuddyControl    =   "VolumeVal"
         BuddyDispid     =   196611
         OrigLeft        =   5040
         OrigRight       =   5295
         OrigBottom      =   255
         Increment       =   10
         Max             =   1000
         SyncBuddy       =   -1  'True
         BuddyProperty   =   65547
         Enabled         =   -1  'True
      End
      Begin VB.TextBox VolumeVal 
         Alignment       =   2  '中央揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   270
         Left            =   4600
         TabIndex        =   3
         Text            =   "1000"
         ToolTipText     =   "音量"
         Top             =   0
         Width           =   480
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim TextSize As Long '文字数
Dim ScrollNum As Long 'スクロール数
Dim Log As String

Dim Times As String
Public Status As String
Public Sub InfoPaint() '時間などの情報

   Form1.Cls
 Form1.DrawWidth = 1: Form1.FontBold = True
 Form1.Line (0, 360)-(4145, 610), vbWhite, BF '枠
 Form1.Line (0, 360)-(4145, 610), vbBlack, B '中
 Form1.CurrentX = 30: Form1.CurrentY = 400: Form1.Print Status

'3375
 Form1.DrawWidth = 1: Form1.FontBold = True
 Form1.Line (4160, 360)-(5330, 610), vbWhite, BF '枠
 Form1.Line (4160, 360)-(5330, 610), vbBlack, B '中
 Form1.CurrentX = 4250: Form1.CurrentY = 400: Form1.Print Times
 '3390 / 4560
 
 If Form1.WindowState = 1 Then
  Form1.Caption = Status
 Else
  Form1.Caption = "おんぷっぷ"
 End If
End Sub

Private Sub Form_Load()
 PlayNo = 1

Volume.Value = Val(VolumeVal.Text)
AddNum = 0

        Dim cFso As FileSystemObject
        Set cFso = New FileSystemObject
    
    If cFso.FileExists(App.Path + "\start.dat") Then
        Call Buttom.MusicListLoad(App.Path + "\start.dat", "Start")
        
        If List.ListItems.Count > 0 Then
            List.ListItems.Item(PlayNo).Selected = True '選択
            List.SetFocus '反転
            List.SelectedItem.EnsureVisible
        End If
    End If
      
      Buttom.ButtonOnOff 'ボタンの有効無効
Fnot:
 If List.ListItems.Count <= 0 Then
    Status = "曲を追加してください。"
 End If


 If PlayMode = "" Then
  Toolbar.Buttons.Item("NormalPlay").Value = tbrPressed '通常再生ON
   Toolbar.Buttons.Item("NormalPlay").Image = 14 'ON
   Buttom.PlayMode = "Nomal" '再生モード
 End If
   Form1.InfoPaint
   
   Set cFso = Nothing
End Sub

Private Sub Form_Unload(Cancel As Integer) 'アンロード
 Form1.Visible = True
 
' On Error Resume Next
    Call Buttom.MusicListSave(App.Path + "\start.dat", "Close")

 
 Control.MusicStop
 Control.MusicClose ("all")
 Reset
 Close All
 End
End Sub

Private Sub List_DblClick() 'リストをダブルクリック
 Buttom.MusicStop (True) '停止
 Control.MusicClose ("all")
  Control.MusicPosition (0) '最初の位置に
 Buttom.MusicPlay '再生
End Sub

Private Sub List_ItemClick(ByVal Item As MSComCtlLib.ListItem) 'アイテムクリック
 Dialog.FileName = List.SelectedItem.Tag
End Sub
Private Sub List_KeyDown(KeyCode As Integer, Shift As Integer)
On Error Resume Next
 If KeyCode = 46 And List.SelectedItem.Text <> "" Then
  Buttom.MusicOneDel '1曲削除
  Beep
 End If
End Sub

Private Sub PlayTime_Timer()

On Error Resume Next
 Log = "[" + Control.Status + "] " + Form1.List.ListItems.Item(PlayNo).Text + " - " + Form1.List.ListItems.Item(PlayNo).ListSubItems(1).Text + " (" + Form1.List.ListItems.Item(PlayNo).ListSubItems(3).Text + ") " '状態
 Times = Control.NowTime & "/" & Form1.List.ListItems.Item(PlayNo).ListSubItems(2).Text '再生時間/総合時間
 Slider.Value = PlayPosition '現在時間
 Form1.InfoPaint
End Sub
Private Sub Scroll_Timer() '文字スクロール
If ScrollNum = 0 Then
 TextSize = Len(Log) '文字数
Else
If ScrollNum <= TextSize Then '文字数がスクロール以上か
 Status = Right(Log, TextSize - ScrollNum) '右から文字数-スクロール数を切り出す。
 Status = Status + Left(Log, ScrollNum) '左からスクロール数を切り出し、後ろに付け足す。
Else
 ScrollNum = 0 'スクロール数を初期化
End If
End If
 ScrollNum = ScrollNum + 1 'スクロール数を増加
End Sub
Private Sub Slider_Scroll() '早送り・巻き戻し
 Buttom.MusicStop (False) '停止
 Control.MusicPosition (Slider.Value) '再生位置変更
End Sub

Private Sub Toolbar_ButtonClick(ByVal Button As MSComCtlLib.Button)
  Select Case Button.Key
   Case "OneAdd"
    If Toolbar.Buttons.Item("OneAdd").Value = tbrPressed Then '1曲追加
    
        Dim cFso As FileSystemObject
        Set cFso = New FileSystemObject
    
        AddNum = 0
        
        Dialog.DialogTitle = "開く" 'ダイアログ名
        Dialog.Flags = cdlOFNAllowMultiselect Or cdlOFNExplorer
        
        Dialog.FileName = ""
        Dialog.Filter = "対応ファイル|*.mp3;*.cda;*.wav;*.mpl|MP3|*.mp3|CDA|*.cda|WAV|*.wav|音楽再生リスト(*.mpl)|*.mpl|全てのファイル(*.*)|*.*|" '拡張子
        
        On Error GoTo Cancel
        
        Dialog.ShowOpen 'ダイアログの表示[
        
        Dim FileList() As String
        
        If UBound(Split(Dialog.FileName, vbNullChar)) = 0 Then Dialog.FileName = CurDir(Dialog.FileName) & vbNullChar & Replace(Dialog.FileName, CurDir(Dialog.FileName) & "\", "")
        FileList() = Split(Dialog.FileName, vbNullChar)
      
        For A = 1 To UBound(FileList)
            FileList(A) = FileList(0) & "\" & FileList(A) 'ルート
            
            If cFso.GetExtensionName(FileList(A)) = "mpl" Then  '再生リストの場合
                Call Buttom.MusicListLoad(FileList(A), "OneBtm") 'リストを開く
            Else
                AddNum = AddNum + 1
                Buttom.MusicOpen (FileList(A)) '開く
  
                Status = AddNum & "曲追加しました。"  '状態
                Form1.InfoPaint
            End If
        Next A
      
      Set cFso = Nothing
     
     Buttom.ButtonOnOff 'ボタンの有効無効
     
      Beep
      Form1.Toolbar.Buttons.Item(Button.Index).Value = tbrUnpressed '元に戻す
    End If
   Case "OneDel"
    If Toolbar.Buttons.Item(Button.Index).Value = tbrPressed Then '1曲削除
     Buttom.MusicOneDel '削除
      Beep
      Form1.Toolbar.Buttons.Item(Button.Index).Value = tbrUnpressed '元に戻す
    End If
   Case "FolderAdd"
    If Toolbar.Buttons.Item(3).Value = tbrPressed Then 'フォルダから追加
       Form2.Show vbModal
      Form1.Toolbar.Buttons.Item(3).Value = tbrUnpressed '元に戻す
    End If
   Case "AllDel"
    If Toolbar.Buttons.Item(Button.Index).Value = tbrPressed Then '全曲削除
     Buttom.MusicAllDel '削除
      Beep
     Form1.Toolbar.Buttons.Item(Button.Index).Value = tbrUnpressed '元に戻す
    End If
   Case "PlayBtm"
    If Toolbar.Buttons.Item(Button.Index).Value = tbrPressed Then '再生
       Buttom.MusicPlay '再生
        ScrollNum = 0 'スクロール数
    End If
   Case "StopBtm"
    If Toolbar.Buttons.Item(Button.Index).Value = tbrPressed Then '停止
       Buttom.MusicStop (False) '停止
    End If
   Case "PauseBtm"
    If Toolbar.Buttons.Item(Button.Index).Value = tbrPressed Then '一時停止
       Buttom.MusicPause '一時停止
    End If
   Case "BackBtm"
    If Toolbar.Buttons.Item(Button.Index).Value = tbrPressed Then '前曲
     Buttom.MusicBack
    End If
   Case "NextBtm"
    If Toolbar.Buttons.Item(Button.Index).Value = tbrPressed Then '次曲
       Buttom.MusicNext
    End If
   Case "NormalPlay"
    If Toolbar.Buttons.Item(Button.Index).Value = tbrPressed Then '通常再生
     Buttom.ModeButtonReset 'ボタンOFF
     Buttom.PlayMode = "Nomal" 'モード代入
     Toolbar.Buttons.Item(Button.Index).Image = 14 'ON
    End If
   Case "RepeatPlay"
    If Toolbar.Buttons.Item(Button.Index).Value = tbrPressed Then 'リピート再生
     Buttom.ModeButtonReset 'ボタンOFF
     Buttom.PlayMode = "Repeat" 'モード代入
     Toolbar.Buttons.Item(Button.Index).Image = 16 'ON
    End If
   Case "ListShuffle"
    If Toolbar.Buttons.Item(Button.Index).Value = tbrPressed Then 'リストシャッフル
        ListShuffle
'     Buttom.PlayMode = "Random" 'モード代入

    End If
    
   Case "ListSave"
    Dialog.DialogTitle = "曲リストの保存" 'ダイアログ名
    Dialog.FileName = ""
    Dialog.Filter = "音楽再生リスト(*.mpl)|*.mpl|" '拡張子
    ' 存在しているファイルを指定した場合は、上書きするかどうかの問い合わせを表示する
    Dialog.Flags = Dialog.Flags Or FileOpenConstants.cdlOFNOverwritePrompt
    ' ダイアログボックスを閉じる前に現在のディレクトリを復元する
    Dialog.Flags = Dialog.Flags Or FileOpenConstants.cdlOFNNoChangeDir
     On Error GoTo Cancel
      Dialog.ShowSave 'ダイアログの表示
         Call Buttom.MusicListSave(Dialog.FileName, "SaveBtm")     '保存
        Beep
        Status = "リストを保存しました。" '状態
         Form1.InfoPaint
    Form1.Toolbar.Buttons.Item(Button.Index).Value = tbrUnpressed '元に戻す
  Case "PlayList"
   If Toolbar.Buttons.Item(Button.Index).Value = tbrPressed Then 'プレイリスト
    Form1.Height = 2805
     Toolbar.Buttons.Item(Button.Index).Image = 24 'ON
   Else
    Form1.Height = Form1.Slider.Top + Form1.Slider.Height + 350
     Toolbar.Buttons.Item(Button.Index).Image = 23 'OFF
   End If
   End Select
 Exit Sub
Cancel:
 If Err <> 32755 Then
   MsgBox Err.Description, , "エラー"
 End If
  Form1.Toolbar.Buttons.Item(1).Value = tbrUnpressed '元に戻す
End Sub

Private Sub Volume_Change() '音量変更
 Control.VolumeChange (Volume.Value)
 Volume.ToolTipText = Volume.Value
End Sub

Private Sub VolumeVal_Change() '音量値
 If IsNumeric(VolumeVal.Text) And Val(VolumeVal.Text) <= 1000 Then
    Volume.Value = Val(VolumeVal.Text)
 Else
  Beep
  VolumeVal.Text = Volume.Value
 End If
End Sub
