VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form2 
   BorderStyle     =   4  '�Œ�°� ����޳
   Caption         =   "�t�H���_����ǉ�"
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
   StartUpPosition =   3  'Windows �̊���l
   Begin MSComDlg.CommonDialog Dialog 
      Left            =   840
      Top             =   600
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.CommandButton NoAdd 
      Caption         =   "����"
      Height          =   255
      Left            =   960
      TabIndex        =   4
      Top             =   2640
      Width           =   735
   End
   Begin VB.CommandButton FolderAdd 
      Caption         =   "�ǉ�"
      Height          =   255
      Left            =   0
      TabIndex        =   3
      Top             =   2640
      Width           =   855
   End
   Begin VB.FileListBox File 
      Appearance      =   0  '�ׯ�
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
      Appearance      =   0  '�ׯ�
      Height          =   2190
      Left            =   0
      TabIndex        =   1
      Top             =   360
      Width           =   1695
   End
   Begin VB.DriveListBox Drive 
      Appearance      =   0  '�ׯ�
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
Private Sub DirSelect_Change() '�t�H���_�ύX
 File.Path = DirSelect.Path '�t�@�C�����[�g
End Sub

Private Sub Drive_Change() '�h���C�u�ύX
'On Error Resume Next
 DirSelect.Path = Drive.Drive '�h���C�u���[�g
If Error = "���޲�����������Ă��܂���B" Then
 MsgBox "�f�o�C�X������܂���", , "Error"
 DirSelect.Enabled = False '����
Else
 DirSelect.Enabled = True '�L��
End If
End Sub

Private Sub FolderAdd_Click() '�ǉ� 1830
    AddNum = 0
    
    Dim cFso As FileSystemObject
    Set cFso = New FileSystemObject
    
    Dim Flag As Boolean 'Do�����o���t���O
        Flag = False

    DoEvents
    
    Do
        If File.ListCount > 0 Or DirSelect.ListCount <> DirSelect.ListIndex + 1 Then '�t�@�C���������̓t�H���_������
            For num = 0 To File.ListCount - 1 Step 1
                FolderAdd.Enabled = False '�ǉ����͖���
                NoAdd.Enabled = False '�ǉ����͕���𖳌�
                File.ListIndex = num '�I��
                Form1.Dialog.FileName = File.Path + "\" + File.FileName '���[�g���_�C�A���O�ɑ��
                
                If cFso.GetExtensionName(Form1.Dialog.FileName) = "mpl" Then  '�Đ����X�g�̏ꍇ
                    Call Buttom.MusicListLoad(Form1.Dialog.FileName, "FolderBtm") '���X�g���J��
                Else
                    AddNum = AddNum + 1
                    Buttom.MusicOpen (Form1.Dialog.FileName) '�J��
  
                    Form1.Status = AddNum & "�Ȓǉ����܂����B"  '���
                    Form1.InfoPaint
                End If
                
                Form1.Status = AddNum & "�Ȃ�ǉ����ł��B"
                Form1.InfoPaint
            Next
            
            If DirSelect.ListIndex + 1 < DirSelect.ListCount Then
                DirSelect.ListIndex = DirSelect.ListIndex + 1 '���̃f�B���N�g��
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
        Form1.Status = AddNum & "�Ȓǉ����܂����B" '���
    Else
        Beep
        MsgBox "�Ή��t�@�C����������܂���ł����B", , "Error"
    End If
 
 Set cFso = Nothing

    Form1.InfoPaint
   Unload Me '�\��������
End Sub



Private Sub NoAdd_Click() '����
 Unload Me
End Sub
