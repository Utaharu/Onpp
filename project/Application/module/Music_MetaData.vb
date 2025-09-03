

Imports System.Configuration
Imports System.Net.Mime.MediaTypeNames
Imports System.Runtime.CompilerServices
Imports System.Text
Imports HundredMilesSoftware.UltraID3Lib

Module Music_MetaData
    Private Data As TagLib.File

    Public Tag As TagID3
    Structure TagID3
        Dim Header As String
        Dim MusicTitle As String
        Dim SubTitle As String
        Dim ArtistName As String
        Dim AlbumName As String
        Dim MakeYear As UInteger
        Dim Coment As String
        Dim TrackNum As Integer
        Dim Genre As String
        Dim Lyrics As String
        Dim PlayTimeString As String
        Dim PlayTime As Double
        Dim Bitrate As Integer
        Dim Samplerate As Integer
        Dim Size As Long
        Dim DeviceType As String
        Dim Path As String
    End Structure

    Public Sub Load(ByVal FilePath As String)
        Tag = New TagID3
        Try
            If IO.File.Exists(FilePath) Then
                Tag.Path = FilePath
                Tag.DeviceType = Music.GetDeviceType(FilePath)

                If Tag.DeviceType <> "mp3_audio" And Tag.DeviceType <> "" And Tag.DeviceType <> "m4a_audio" Then
                    RIff.GetWaveTag(Tag.Path)
                Else

                    Data = TagLib.File.Create(Tag.Path)
                    Title()
                    Album()
                    Artist()
                    Comment()
                    SubTitle()
                    Samplerate()
                    Bitrate()
                    Year()
                    Genre()
                    FileSize()
                    TotalPlayTime()

                End If
            Else
                Debug.Print("ファイルが見つからないため、Music Meta Tagが取得できませんでした。")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Title()
        Dim AText, BText As String
        Dim TagVal As String = ""
        Try
            'Title
            If IsNothing(Data.Tag.Title) = False Or Data.Tag.Title <> "" Then
                AText = Unicode_Utf16(Data.Tag.Title)
                BText = Iso8859_Sjis(Data.Tag.Title)

                Debug.Print(AText & " / " & "B : " & BText & vbNewLine)

                If AText.Count > BText.Count Then
                    Tag.MusicTitle = BText
                ElseIf AText <> "" Then
                    Tag.MusicTitle = AText
                End If
            End If

        Catch ex As Exception
        End Try
        If Tag.MusicTitle = "" Then Tag.MusicTitle = IO.Path.GetFileNameWithoutExtension(Tag.Path)
    End Sub
    Public Sub Album()
        'Album
        Dim AText, BText As String
        If IsNothing(Data.Tag.Album) = False Or Data.Tag.Album <> "" Then
            AText = Unicode_Utf16(Data.Tag.Album)
            BText = Iso8859_Sjis(Data.Tag.Album)

            If AText.Length > BText.Length Then
                Tag.AlbumName = BText
            ElseIf AText <> "" Then
                Tag.AlbumName = AText
            End If
        End If
        If Tag.AlbumName = "" Then Tag.AlbumName = "None"
    End Sub

    Public Sub Artist()
        Dim AText, BText As String
        'Artist
        If IsNothing(Data.Tag.Performers) = False Or Data.Tag.Performers.Length > 0 Then
            AText = Unicode_Utf16(Data.Tag.Performers(0))
            BText = Iso8859_Sjis(Data.Tag.Performers(0))

            If AText.Length > BText.Length Then
                Tag.ArtistName = BText
            ElseIf AText <> "" Then
                Tag.ArtistName = AText
            End If
        End If
        If Tag.ArtistName = "" Then Tag.ArtistName = "None"

    End Sub
    Public Sub Comment()
        'Comment
        Dim AText, BText As String
        If IsNothing(Data.Tag.Comment) = False Or Data.Tag.Comment <> "" Then
            AText = Unicode_Utf16(Data.Tag.Comment)
            BText = Iso8859_Sjis(Data.Tag.Comment)

            If AText.Length > BText.Length Then
                Tag.Coment = BText
            ElseIf AText <> "" Then
                Tag.Coment = AText
            End If
        End If
        If Tag.Coment = "" Then Tag.Coment = "None"
    End Sub

    Public Sub SubTitle()
        Dim AText, BText As String
        'SubTitle
        '                If IsNothing(data.ID3v2Tag.Frames.GetFrame(HundredMilesSoftware.UltraID3Lib.CommonSingleInstanceID3v2FrameTypes.Subtitle)) = False Then
        '                Dim subtitle As String = CType(data.ID3v2Tag.Frames.GetFrame(HundredMilesSoftware.UltraID3Lib.CommonSingleInstanceID3v2FrameTypes.Subtitle), HundredMilesSoftware.UltraID3Lib.ID3v23SubtitleFrame).Subtitle
        '
        '               AText = HundredMilesSoftware.UltraID3Lib.UltraID3.GetCustomEncodedText(subtitle, System.Text.Encoding.Default, System.Text.Encoding.GetEncoding("Shift-JIS"))
        '              BText = HundredMilesSoftware.UltraID3Lib.UltraID3.GetCustomEncodedText(subtitle, System.Text.Encoding.GetEncoding("ISO-8859-1"), System.Text.Encoding.GetEncoding("Shift-JIS"))
        '
        '           If AText.Length > BText.Length Then
        '          Tag.SubTitle = BText
        '         Else
        '        Tag.SubTitle = AText
        'End If
        'End If
        If Tag.SubTitle = "" Then Tag.SubTitle = "None"
    End Sub
    Public Sub Samplerate()
        If IsNothing(Data.Properties.AudioSampleRate) = False Then Tag.Samplerate = Data.Properties.AudioSampleRate 'Samplerate
    End Sub
    Public Sub Bitrate()
        If IsNothing(Data.Properties.AudioBitrate) = False Then Tag.Bitrate = Data.Properties.AudioBitrate 'Bitrate
    End Sub
    Public Sub Year()
        If IsNothing(Data.Tag.Year) = False And Data.Tag.Year > 0 Then 'MakeYear
            Tag.MakeYear = Data.Tag.Year
        End If
    End Sub
    Public Sub Genre()
        If IsNothing(Data.Tag.Genres) = False Then Tag.Genre = Data.Tag.Genres.FirstOrDefault
    End Sub
    Public Sub FileSize()
        'FileSize Unit
        Tag.Size = FileIO.FileSystem.GetFileInfo(Tag.Path).Length
    End Sub
    Public Sub TotalPlayTime()
        If Tag.DeviceType <> "cd_audio" And Tag.DeviceType <> "" Then
            Tag.PlayTime = Data.Properties.Duration.TotalMilliseconds 'TotalPlayTime
        End If
        '曲を開いて情報取得
        If Tag.PlayTime <= 0 Then
            Music.Open(Tag.Path)
            Tag.DeviceType = Music.GetDeviceType(Tag.Path)
            Tag.PlayTime = Convert.ToDouble(GetAllTime(Tag.Path, Tag.DeviceType)) 'TotalPlayTime
            Music.Close(Tag.Path) '閉じる
        End If
    End Sub
    Function ConvertText(Text As String) As String
        Dim Ascii As New System.Text.ASCIIEncoding
        Dim ByteText() As Byte
        ByteText = Ascii.GetBytes(Text)
        Return System.Text.UTF8Encoding.UTF8.GetString(ByteText)
        '        System.Text.Encoding.ASCII.

    End Function

    Function Unicode_Utf16(Text As String) As String

        Return HundredMilesSoftware.UltraID3Lib.UltraID3.GetCustomEncodedText(Text, System.Text.Encoding.Default, System.Text.Encoding.GetEncoding("Shift-JIS"))



        '   Dim a() As Byte
        '   a = System.Text.Encoding.Unicode.GetBytes(Text)
        '   Dim B(a.Count) As Byte

        '   Dim ss As Integer
        '   For num = 0 To a.Count - 1

        '   If a(num) > 0 Then
        ' b(ss) = a(num)
        ' ss += 1

        ' End If
        '  Next
        '  Return System.Text.Encoding.GetEncoding("Shift-JIS").GetString(a)
    End Function
    Function Iso8859_Sjis(Text As String) As String
        Return HundredMilesSoftware.UltraID3Lib.UltraID3.GetCustomEncodedText(Text, System.Text.Encoding.GetEncoding("ISO-8859-1"), System.Text.Encoding.GetEncoding("Shift-JIS"))
        '
        '        Return System.Text.Encoding.GetEncoding("Shift-JIS").GetString(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(Text))
    End Function


    '    Public Sub Title()
    '    Dim AText, BText As String
    '    Dim TagVal As String = ""
    '    Try
    'Title
    '    If IsNothing(Data.Tag.Title) = False Or Data.Tag.Title <> "" Then
    '                AText = Unicode_Utf16(Data.Tag.Title)
    '                BText = Iso8859_Sjis(Data.Tag.Title)

    '                Debug.Print(AText & " / " & "B : " & BText & vbNewLine)

    '    If AText.Count > BText.Count Then
    '                   Tag.MusicTitle = BText
    '   ElseIf AText <> "" Then
    '                   Tag.MusicTitle = AText
    '   End If
    '   End If

    '   Catch ex As Exception
    '    End Try
    '    If Tag.MusicTitle = "" Then Tag.MusicTitle = IO.Path.GetFileNameWithoutExtension(Data.Name)
    '    End Sub
End Module