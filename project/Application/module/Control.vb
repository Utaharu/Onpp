Module Control
    Public Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (lpstrCommand As String, lpstrReturnString As String, uReturnLength As Integer, hwndCallback As Integer) As Integer
    Public Declare Function mciGetErrorString Lib "winmm.dll" Alias "mciGetErrorStringA" (dwError As Long, lpBuffer As String, lpBufLength As Long) As Long


    'config
    Public TempFolder As String = Application.StartupPath + "\tmp\"
    Public DataDirectory As String = Application.StartupPath + "\data"
    Public ConfigFile As String = DataDirectory + "\config.xml"
    Public StartUpFile As String = DataDirectory + "\startup.xml"
    Public RootTreeFile As String = DataDirectory + "\tree.xml"
    Public Error_LogFile As String = DataDirectory + "\error.txt"

    Public Const PlayMarker As String = "◆"
    Public Const TargetFile As String = "*.mp3;*.m4a;*.mp4;*.flac;*.cda;*.wav;*.mpl"

    'Form size
    Public Const FormMaxH As Integer = 240
    Public Const FormMaxW As Integer = 390

    Public Const FormMinH As Integer = 85
    Public Const FormMinW As Integer = 390


    Public PlayMode As String '再生モード
    Public PlayInfo As PlayPropaty

    Public AddNum As Integer

    'File Add Theard
    Public DirFileAdding As New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf FileSearch))
    Delegate Sub FileAdd_DG(FileRoot As String)

    Public FilesAdding As New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf Files_Add))
    Delegate Sub FilesAdd_DG(Files() As String)

    'Playing Info Theard
    Public StatusPrintMode As String

    Public hWnd As Integer

    'Object
    Public InfoBox As New Label
    Public DirDialog As New FolderBrowserDialog

    Public GetFileList As New ArrayList

    Structure PlayPropaty
        Dim Status As String
        Dim PlayNo As Integer '曲順番号(リストで割り振られる番号)
        Dim PlayIndex As Integer 'リスト位置(リスト上のインデックス)
        Dim NowFiles As String '現在再生中のファイル名
        Dim DeviceType As String 'デバイス種別

        '再生位置制御用
        Dim StartPosition As Integer '開始位置
        Dim SeekPosition As Integer 'シーク位置
        Dim NowPosition As Integer
        Dim EndPosition As Integer '終了位置
    End Structure

    Public Sub PlayList_Add(FilePath As String) '曲追加
        Music_MetaData.Load(FilePath) 'Music Tag 取得

        Dim no As Integer = MainForm.DB.Tables("PlayListData").Rows.Count + 1
        MainForm.DB.Tables("PlayListData").Rows.Add(no, Music_MetaData.Tag.MusicTitle, Music_MetaData.Tag.SubTitle, Music_MetaData.Tag.PlayTime, Music_MetaData.Tag.ArtistName, Music_MetaData.Tag.AlbumName, Music_MetaData.Tag.Bitrate, Music_MetaData.Tag.Samplerate, Music_MetaData.Tag.Size, FilePath)
        'MainForm.DB.Tables("PlayListData").Rows.Add(no, "", "", 0, "", "", 0, 0, 0, FilePath)

        Button.ButtonOnOff() 'ボタンの有効無効
    End Sub

    Public Sub File_Add(ByVal FileRoot As String) 'ファイル追加

        If System.IO.Path.GetExtension(FileRoot) = ".mpl" Then '再生リストの場合
            Button.MusicListLoad(FileRoot) 'リストを開く
        Else
            AddNum += 1
            Control.PlayList_Add(FileRoot) '開く

        End If

        Status.Text = AddNum & "曲追加しました。"  '状態
        InfoPaint()

    End Sub
    Public Sub Files_Add(FileList As Object)
        Dim File As ArrayList
        File = CType(FileList, ArrayList)
        Dim sp As New Stopwatch
        sp.Start()
        AddNum = 0
        For A = 0 To File.Count - 1
            InfoBox.Invoke(New FileAdd_DG(AddressOf File_Add), File.Item(A))
        Next
        sp.Stop()
        MsgBox(sp.Elapsed.ToString)
        InfoBox.Invoke(
            Sub()
                PlayListBox.MusicList.ScrollBars = ScrollBars.Both

                MainForm.Enabled = True
                MainForm.OneAddBtm.Checked = False '元に戻す
                Beep()
            End Sub
            )
    End Sub
    Public Sub FileSearch(ByVal RootPath As Object) 'フォルダから追加　スレッド

        Dim Filter() As String = TargetFile.Split(CChar(";"))

        GetFileList.Clear()

        For Each ext As String In Filter
            Dim FileList As IEnumerable(Of String)
            FileList = IO.Directory.EnumerateFiles(RootPath.ToString, ext, IO.SearchOption.AllDirectories)

            For Each File In FileList
                'InfoBox.Invoke(New FileAdd_DG(AddressOf File_Add), File)
                Control.GetFileList.Add(File)
            Next
        Next

    End Sub

    Public Sub ObjectCreate()

        InfoBox = New Label
        InfoBox.AutoSize = False
        InfoBox.SetBounds(5, 26, 266, 19)
        InfoBox.TextAlign = ContentAlignment.MiddleLeft
        InfoBox.Padding = New System.Windows.Forms.Padding(2)
        InfoBox.Margin = New System.Windows.Forms.Padding(0)
        InfoBox.BorderStyle = BorderStyle.FixedSingle
        InfoBox.BackColor = Color.White
        InfoBox.Enabled = True
        InfoBox.Font = New Font(MainForm.Font.FontFamily, 9, FontStyle.Bold)
        InfoBox.Dock = DockStyle.Fill
        MainForm.InfoPanel.Controls.Add(InfoBox, 0, 0)

        DirDialog = New FolderBrowserDialog


        MainForm.TrayIcon.Icon = MainForm.Icon
        MainForm.TrayIcon.Text = "おんぷっぷ"

    End Sub

    Public Sub PositionSet()
        If Status.PlayFlag = "Playing" Or Status.PlayFlag = "Pause" Then
            PlayInfo.NowPosition = Convert.ToInt32(Music.GetNowTime) '現在の再生位置
        End If
    End Sub

    Friend Function GetTableIndex(ByVal TargetTableName As String, ByVal GetListNo As Integer) As Integer
        Return Mainform.DB.Tables(TargetTableName).Rows.IndexOf(Mainform.DB.Tables(TargetTableName).Rows.Find(GetListNo))
    End Function
    Friend Sub PopUp_Dialog(ByVal Status As String, ByVal Music_Title As String, ByVal Music_Artist As String, ByVal Music_Time As String) 'PlayInfo Popup
        Dim newPopup As New InfoDialog

        newPopup.Text = MainForm.Text
        newPopup.Status.Text = Status
        newPopup.Title.Text = Music_Title
        newPopup.Artist.Text = Music_Artist
        newPopup.PlayTime.Text = Music_Time

        newPopup.SetDesktopLocation(Screen.PrimaryScreen.WorkingArea.Right - newPopup.Width, Screen.PrimaryScreen.WorkingArea.Bottom - newPopup.Height)
        newPopup.ShowWithoutActive()
        newPopup.Visible = True
    End Sub

End Module
