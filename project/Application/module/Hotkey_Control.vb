Module Hotkey_Control
    'HotKey
    Public Declare Function RegisterHotKey Lib "user32" (hwnd As IntPtr, id As Integer, fsModifiers As Integer, vk As Keys) As Integer
    Public Declare Function UnregisterHotKey Lib "user32" (hwnd As IntPtr, id As Integer) As Integer
    Public Declare Function GlobalAddAtom Lib "kernel32" Alias "GlobalAddAtomA" (lpString As String) As Short
    Public Declare Function GlobalDeleteAtom Lib "kernel32" (ByVal nAtom As Short) As Short
    Public Const WM_HOTKEY As Integer = &H312
    Public Const WM_KEYDOWN As Integer = &H100
    Public Const ModKey_Ctrl As Integer = &H1
    Public Const ModKey_Alt As Integer = &H2
    Public Const ModKey_Shift As Integer = &H4
    Public HotKey As New HotKey_Set
    Structure HotKey_Val
        Dim Id As Short
        Dim ModKey As Integer
        Dim Key As Keys
    End Structure
    Structure HotKey_Set
        Dim MediaKey_Play As HotKey_Val
        Dim MediaKey_Next As HotKey_Val
        Dim MediaKey_Back As HotKey_Val
        Dim MediaKey_Stop As HotKey_Val
        Dim ShortCut_Play As HotKey_Val
        Dim ShortCut_Next As HotKey_Val
        Dim ShortCut_Back As HotKey_Val
        Dim ShortCut_Stop As HotKey_Val
    End Structure
    Friend Function Get_HotKeyID(HotKeyName As String) As Short 'HotkeyIDの生成
        Return GlobalAddAtom(HotKeyName & MainForm.GetHashCode().ToString())
    End Function
    Friend Sub Create_HotkeyId()
        ' ホットキーのために唯一無二のIDを生成する
        HotKey.MediaKey_Play.Id = Get_HotKeyID("Onpp-MediaKey_Play")
        HotKey.MediaKey_Next.Id = Get_HotKeyID("Onpp-MediaKey_Next")
        HotKey.MediaKey_Back.Id = Get_HotKeyID("Onpp-MediaKey_Back")
        HotKey.MediaKey_Stop.Id = Get_HotKeyID("Onpp-MediaKey_Stop")
        HotKey.ShortCut_Play.Id = Get_HotKeyID("Onpp-ShortCut_Play")
        HotKey.ShortCut_Next.Id = Get_HotKeyID("Onpp-ShortCut_Next")
        HotKey.ShortCut_Back.Id = Get_HotKeyID("Onpp-ShortCut_Back")
        HotKey.ShortCut_Stop.Id = Get_HotKeyID("Onpp-ShortCut_Stop")
    End Sub
    Friend Sub Set_HotKey()
        HotKey.MediaKey_Play.Key = Keys.MediaPlayPause
        HotKey.MediaKey_Next.Key = Keys.MediaNextTrack
        HotKey.MediaKey_Back.Key = Keys.MediaPreviousTrack
        HotKey.MediaKey_Stop.Key = Keys.MediaStop

        'ShortCut Key
        HotKey.ShortCut_Play.ModKey = ModKey_Ctrl Or ModKey_Alt
        HotKey.ShortCut_Play.Key = Keys.P
        HotKey.ShortCut_Next.ModKey = ModKey_Ctrl Or ModKey_Alt
        HotKey.ShortCut_Next.Key = Keys.N
        HotKey.ShortCut_Back.ModKey = ModKey_Ctrl Or ModKey_Alt
        HotKey.ShortCut_Back.Key = Keys.B
        HotKey.ShortCut_Stop.ModKey = ModKey_Ctrl Or ModKey_Alt
        HotKey.ShortCut_Stop.Key = Keys.S
    End Sub
    Public Sub Hotkey_Register()
        Create_HotkeyId()
        Set_HotKey()

        ' キーを登録する
        RegisterHotKey(MainForm.Handle, HotKey.MediaKey_Play.Id, 0, HotKey.MediaKey_Play.Key)
        RegisterHotKey(MainForm.Handle, HotKey.MediaKey_Next.Id, 0, HotKey.MediaKey_Next.Key)
        RegisterHotKey(MainForm.Handle, HotKey.MediaKey_Back.Id, 0, HotKey.MediaKey_Back.Key)
        RegisterHotKey(MainForm.Handle, HotKey.MediaKey_Stop.Id, 0, HotKey.MediaKey_Stop.Key)

        RegisterHotKey(MainForm.Handle, HotKey.ShortCut_Play.Id, HotKey.ShortCut_Play.ModKey, HotKey.ShortCut_Play.Key)
        RegisterHotKey(MainForm.Handle, HotKey.ShortCut_Next.Id, HotKey.ShortCut_Next.ModKey, HotKey.ShortCut_Next.Key)
        RegisterHotKey(MainForm.Handle, HotKey.ShortCut_Back.Id, HotKey.ShortCut_Back.ModKey, HotKey.ShortCut_Back.Key)
        RegisterHotKey(MainForm.Handle, HotKey.ShortCut_Stop.Id, HotKey.ShortCut_Stop.ModKey, HotKey.ShortCut_Stop.Key)
    End Sub
    Public Sub Hotkey_UnRegister()
        ' ホットキーの登録を解除し、アトムを削除する
        UnregisterHotKey(MainForm.Handle, HotKey.MediaKey_Next.Id)
        UnregisterHotKey(MainForm.Handle, HotKey.MediaKey_Back.Id)
        UnregisterHotKey(MainForm.Handle, HotKey.MediaKey_Stop.Id)
        UnregisterHotKey(MainForm.Handle, HotKey.ShortCut_Play.Id)
        UnregisterHotKey(MainForm.Handle, HotKey.ShortCut_Next.Id)
        UnregisterHotKey(MainForm.Handle, HotKey.ShortCut_Back.Id)
        UnregisterHotKey(MainForm.Handle, HotKey.ShortCut_Stop.Id)

        GlobalDeleteAtom(HotKey.MediaKey_Play.Id)
        GlobalDeleteAtom(HotKey.MediaKey_Next.Id)
        GlobalDeleteAtom(HotKey.MediaKey_Back.Id)
        GlobalDeleteAtom(HotKey.MediaKey_Stop.Id)
        GlobalDeleteAtom(HotKey.ShortCut_Play.Id)
        GlobalDeleteAtom(HotKey.ShortCut_Next.Id)
        GlobalDeleteAtom(HotKey.ShortCut_Back.Id)
        GlobalDeleteAtom(HotKey.ShortCut_Stop.Id)
    End Sub
    Public Sub Hotkey_Proc(ByRef m As Message)
        If m.Msg = WM_HOTKEY Then
            ' ホットキーが押されたときの処理
            Debug.Print("HotID:" & m.WParam.ToInt64)
            Select Case m.WParam.ToInt64
                Case HotKey.MediaKey_Play.Id, HotKey.ShortCut_Play.Id
                    If MainForm.PlayBtm.Checked = True And MainForm.PauseBtm.Enabled = True Then
                        MainForm.PauseBtm.PerformClick()
                    Else
                        If MainForm.PlayBtm.Enabled = True Then
                            MainForm.PlayBtm.PerformClick()
                        Else
                            Beep()
                        End If
                    End If

                Case HotKey.MediaKey_Next.Id, HotKey.ShortCut_Next.Id
                    If MainForm.NextBtm.Enabled = True Then
                        MainForm.NextBtm.PerformClick()
                    Else
                        Beep()
                    End If

                Case HotKey.MediaKey_Back.Id, HotKey.ShortCut_Back.Id
                    If MainForm.BackBtm.Enabled = True Then
                        MainForm.BackBtm.PerformClick()
                    Else
                        Beep()
                    End If
                Case HotKey.MediaKey_Stop.Id, HotKey.ShortCut_Stop.Id
                    If MainForm.StopBtm.Enabled = True Then
                        MainForm.StopBtm.PerformClick()
                    Else
                        Beep()
                    End If
            End Select

        End If
    End Sub

End Module
