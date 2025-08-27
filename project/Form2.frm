VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form2 
   BorderStyle     =   4  '固定ﾂｰﾙ ｳｨﾝﾄﾞｳ
   Caption         =   "フォルダから追加"
   ClientHeight    =   2910
   ClientLeft      =   45
   ClientTop       =   315
   ClientWidth     =   1710
   ControlBox      =   0   'False
   Icon            =   "Form2.frx":0000
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2910
   ScaleWidth      =   1710
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows の既定値
   Begin MSComDlg.CommonDialog Dialog 
      Left            =   840
      Top             =   600
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton NoAdd 
      Caption         =   "閉じる"
      Height          =   255
      Left            =   960
      TabIndex        =   4
      Top             =   2640
      Width           =   735
   End
   Begin VB.CommandButton FolderAdd 
      Caption         =   "追加"
      Height          =   255
      Left            =   0
      TabIndex        =   3
      Top             =   2640
      Width           =   855
   End
   Begin VB.FileListBox File 
      Appearance      =   0  'ﾌﾗｯﾄ
      Archive         =   0   'False
      Enabled         =   0   'False
      Height          =   2004
      Left            =   1800
      Pattern         =   "*.mp3;*.cda;*.wav;*.mpl"
      TabIndex        =   2
      Top             =   480
      Width           =   1335
   End
   Begin VB.DirListBox DirSelect 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   2190
      Left            =   0
      TabIndex        =   1
      Top             =   360
      Width           =   1695
   End
   Begin VB.DriveListBox Drive 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   300
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   1695
   End
End
Attribute VB_Name = "Form2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub DirSelect_Change() 'フォルダ変更
 File.Path = DirSelect.Path 'ファイルルート
End Sub

Private Sub Drive_Change() 'ドライブ変更
'On Error Resume Next
 DirSelect.Path = Drive.Drive 'ドライブルート
If Error = "ﾃﾞﾊﾞｲｽが準備されていません。" Then
 MsgBox "デバイスがありません", , "Error"
 DirSelect.Enabled = False '無効
Else
 DirSelect.Enabled = True '有効
End If
End Sub

Private Sub FolderAdd_Click() '追加 1830
    AddNum = 0
    
    Dim cFso As FileSystemObject
    Set cFso = New FileSystemObject
    
    Dim Flag As Boolean 'Do抜け出しフラグ
        Flag = False

    DoEvents
    
    Do
        If File.ListCount > 0 Or DirSelect.ListCount <> DirSelect.ListIndex + 1 Then 'ファイルもしくはフォルダがある
            For num = 0 To File.ListCount - 1 Step 1
                FolderAdd.Enabled = False '追加中は無効
                NoAdd.Enabled = False '追加中は閉じるを無効
                File.ListIndex = num '選択
                Form1.Dialog.FileName = File.Path + "\" + File.FileName 'ルートをダイアログに代入
                
                If cFso.GetExtensionName(Form1.Dialog.FileName) = "mpl" Then  '再生リストの場合
                    Call Buttom.MusicListLoad(Form1.Dialog.FileName, "FolderBtm") 'リストを開く
                Else
                    AddNum = AddNum + 1
                    Buttom.MusicOpen (Form1.Dialog.FileName) '開く
  
                    Form1.Status = AddNum & "曲追加しました。"  '状態
                    Form1.InfoPaint
                End If
                
                Form1.Status = AddNum & "曲を追加中です。"
                Form1.InfoPaint
            Next
            
            If DirSelect.ListIndex + 1 < DirSelect.ListCount Then
                DirSelect.ListIndex = DirSelect.ListIndex + 1 '次のディレクトリ
                File.Path = DirSelect.List(DirSelect.ListIndex) + "\"
            Else
                Flag = True
            End If
        
        Else
            Flag = True
        End If
    
    Loop Until Flag = True

    If AddNum > 0 Then
        Beep
        Form1.Status = AddNum & "曲追加しました。" '状態
    Else
        Beep
        MsgBox "対応ファイルが見つかりませんでした。", , "Error"
    End If
 
 Set cFso = Nothing

    Form1.InfoPaint
   Unload Me '表示を消す
End Sub



Private Sub NoAdd_Click() '閉じる
 Unload Me
End Sub
