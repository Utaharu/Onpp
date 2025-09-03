Module RIff
    Public Declare Function mmioOpen Lib "winmm.dll" Alias "mmioOpenA" (ByVal szFileName As String, lpmmioinfo As MMIOINFO, ByVal dwOpenFlags As Long) As IntPtr
    Public Declare Function mmioRead Lib "winmm.dll" (ByVal hmmio As IntPtr, ByRef pch As WAVEFORMATEX, ByVal cch As Integer) As Integer

    Public Declare Function mmioGetInfo Lib "winmm.dll" Alias "mmioGetInfo" (ByVal hmmio As IntPtr, lpmmioinfo As MMIOINFO, ByVal uFlags As Long) As Long
    Public Declare Function mmioDescend Lib "winmm.dll" Alias "mmioDescend" (ByVal hmmio As IntPtr, lpck As MMCKINFO, lpckParent As MMCKINFO, ByVal uFlags As Long) As Integer
    Public Declare Function mmioStringToFOURCC Lib "winmm.dll" Alias "mmioStringToFOURCCA" (ByVal sz As String, ByVal uFlags As Integer) As Integer
    Public Declare Function mmioAscend Lib "winmm.dll" (ByVal hmmio As IntPtr, ByRef lpck As MMCKINFO, ByVal uFlags As Integer) As Integer
    Public Declare Function mmioClose Lib "winmm.dll" Alias "mmioClose" (ByVal hmmio As IntPtr, ByVal uFlags As Long) As Integer
    Public Declare Function mmioDescendParent Lib "winmm.dll" Alias "mmioDescend" (ByVal hmmio As IntPtr, ByRef lpck As MMCKINFO, ByVal x As Integer, ByVal uFlags As Integer) As Integer
    Public Declare Function mmioReadString Lib "winmm.dll" Alias "mmioRead" (ByVal hmmio As IntPtr, ByVal pch() As Byte, ByVal cch As Integer) As Integer
    Public Declare Function mmioSeek Lib "winmm.dll" Alias "mmioSeek" (ByVal hmmio As IntPtr, ByVal lOffset As Long, ByVal iOrigin As Integer) As Long


    Public Const CALLBACK_WINDOW As Integer = &H10000
    Public Const CALLBACK_FUNCTION As Integer = &H30000
    Public Const MMIO_READ As Integer = &H0
    Public Const MMIO_FINDCHUNK As Integer = &H10
    Public Const MMIO_FINDRIFF As Integer = &H20
    Public Const MMIO_FINDLIST = &H40    '  mmioDescend(): find a RIFF chunk

    Public Const MM_WOM_DONE As Integer = &H3BD
    Public Const SEEK_CUR As Integer = 1
    Public Const SEEK_END As Integer = 2
    Public Const SEEK_SET As Integer = 0
    Public Const TIME_BYTES As Integer = &H4
    Public Const WHDR_DONE As Integer = &H1
    Public Const NUM_BUFFERS As Integer = 5
    Public Const BUFFER_SECONDS As Single = 0.1
    Public Const MMSYSERR_NOERROR As Integer = 0

    Public ParentInInfo, ParentFmtInfo, ParentDataInfo As MMCKINFO

    Public Const MMIOERR_CANNOTOPEN = (MMIOERR_BASE + 3)  '  cannot open
    Public Const MMIOERR_BASE = 256
    Public Structure WAVEFORMATEX
        Dim wFormatTag As Short
        Dim nChannels As Short
        Dim nSamplesPerSec As Integer
        Dim nAvgBytesPerSec As Integer
        Dim nBlockAlign As Short
        Dim wBitsPerSample As Short
        Dim cbSize As Short
    End Structure
    Structure MMCKINFO
        Dim ckid As Integer
        Dim ckSize As Integer
        Dim fccType As Integer
        Dim dwDataOffset As Integer
        Dim dwFlags As Integer
    End Structure

    Public Structure MMIOINFO
        Dim dwFlags As Integer
        Dim fccIOProc As Integer
        Dim pIOProc As Integer
        Dim wErrorRet As Integer
        Dim htask As Integer
        Dim cchBuffer As Integer
        Dim pchBuffer As String
        Dim pchNext As String
        Dim pchEndRead As String
        Dim pchEndWrite As String
        Dim lBufOffset As Integer
        Dim lDiskOffset As Integer
        Dim adwInfo1 As Integer
        Dim adwInfo2 As Integer
        Dim adwInfo3 As Integer
        Dim adwInfo4 As Integer
        Dim dwReserved1 As Integer
        Dim dwReserved2 As Integer
        Dim hmmio As Integer
    End Structure
    Public Sub GetWaveTag(ByVal File As String)
        '        If IsNothing(riff_reader) = True Then riff_reader = New IO.StreamReader(MusicList.SelectedRows(0).Cells("Path").Value.ToString)
        '       Dim a As New System.IO.BinaryReader(riff_reader.BaseStream)
        Dim FilePath As String = File
        Dim Fhnd As IntPtr ' file handle

        Dim ParentInInfo, ParentFmtInfo, ParentDataInfo, ListDataInfo As MMCKINFO

        Dim rc As Integer ' Return code
        Dim WaveFormat As WAVEFORMATEX
        Dim size As Integer

        Fhnd = mmioOpen(File, Nothing, MMIO_READ)

        If Music_MetaData.Tag.DeviceType = "wave_audio" Then ParentInInfo.fccType = mmioStringToFOURCC("WAVE", 0)
        If Music_MetaData.Tag.DeviceType = "cd_audio" Then ParentInInfo.fccType = mmioStringToFOURCC("CDDA", 0)
        '読み込み
        rc = mmioDescendParent(Fhnd, ParentInInfo, Nothing, MMIO_FINDRIFF)

        If rc <> MMSYSERR_NOERROR Then GoTo GetEnd


        'ListChunk Search
        ListDataInfo.fccType = mmioStringToFOURCC("INFO", 0)
        rc = mmioDescendParent(Fhnd, ListDataInfo, Nothing, MMIO_FINDCHUNK)

        If rc <> MMSYSERR_NOERROR Then GoTo GetFormat

GetArtist:
        mmioSeek(Fhnd, ListDataInfo.dwDataOffset + 4, SEEK_SET)
        'List - Artist Item Search
        Dim IartInfo As MMCKINFO
        IartInfo.ckid = mmioStringToFOURCC("IART", 0)
        rc = mmioDescendParent(Fhnd, IartInfo, Nothing, MMIO_FINDCHUNK)

        If rc <> MMSYSERR_NOERROR Then GoTo GetTitle

        'Get Artist Data
        Dim Artist(IartInfo.ckSize) As Byte
        size = mmioReadString(Fhnd, Artist, IartInfo.ckSize)

        If size = IartInfo.ckSize Then Music_MetaData.Tag.ArtistName = System.Text.Encoding.GetEncoding("Shift_JIS").GetString(Artist) Else Music_MetaData.Tag.ArtistName = "None"

GetTitle:
        'List - Title Item Search
        mmioSeek(Fhnd, ListDataInfo.dwDataOffset + 4, SEEK_SET)

        Dim InamInfo As New MMCKINFO
        InamInfo.ckid = mmioStringToFOURCC("INAM", 0)
        rc = mmioDescendParent(Fhnd, InamInfo, Nothing, MMIO_FINDCHUNK)

        If rc <> MMSYSERR_NOERROR Then GoTo GetAlbum

        'Get Title Data
        Dim Title(InamInfo.ckSize) As Byte
        size = mmioReadString(Fhnd, Title, InamInfo.ckSize)

        If size = InamInfo.ckSize Then Music_MetaData.Tag.MusicTitle = System.Text.Encoding.GetEncoding("Shift_JIS").GetString(Title) Else Music_MetaData.Tag.MusicTitle = "None"

GetAlbum:
        'List - Album Item Search
        mmioSeek(Fhnd, ListDataInfo.dwDataOffset + 4, SEEK_SET)

        Dim IprdInfo As New MMCKINFO
        IprdInfo.ckid = mmioStringToFOURCC("IPRD", 0)
        '        rc = mmioDescend(Fhnd, IprdInfo, Nothing, MMIO_FINDCHUNK)
        rc = mmioDescendParent(Fhnd, IprdInfo, Nothing, MMIO_FINDCHUNK)

        If rc <> MMSYSERR_NOERROR Then GoTo GetGenle

        'Get Album Data
        Dim Album(IprdInfo.ckSize) As Byte
        size = mmioReadString(Fhnd, Album, IprdInfo.ckSize)

        If size = IprdInfo.ckSize Then Music_MetaData.Tag.AlbumName = System.Text.Encoding.GetEncoding("Shift_JIS").GetString(Album) Else Music_MetaData.Tag.AlbumName = "None"

GetGenle:
        'List - Genre Item Search
        mmioSeek(Fhnd, ListDataInfo.dwDataOffset + 4, SEEK_SET)

        Dim IgnrInfo As New MMCKINFO
        IgnrInfo.ckid = mmioStringToFOURCC("IGNR", 0)
        rc = mmioDescendParent(Fhnd, IgnrInfo, Nothing, MMIO_FINDCHUNK)

        If rc <> MMSYSERR_NOERROR Then GoTo GetFormat

        'Get Genre Data
        Dim Genre(IgnrInfo.ckSize) As Byte
        size = mmioReadString(Fhnd, Genre, IgnrInfo.ckSize)

        If size = IgnrInfo.ckSize Then Music_MetaData.Tag.Genre = System.Text.Encoding.GetEncoding("Shift_JIS").GetString(Genre) Else Music_MetaData.Tag.Genre = "None"

GetFormat:
        mmioSeek(Fhnd, ParentInInfo.dwDataOffset + 4, SEEK_SET)

        ParentFmtInfo.ckid = mmioStringToFOURCC("fmt ", 0)
        '読み込み
        rc = mmioDescendParent(Fhnd, ParentFmtInfo, Nothing, MMIO_FINDCHUNK)
        If rc <> MMSYSERR_NOERROR Then GoTo GetEnd

        size = mmioRead(Fhnd, WaveFormat, ParentFmtInfo.ckSize)
        If size = ParentFmtInfo.ckSize Then Music_MetaData.Tag.Samplerate = WaveFormat.nSamplesPerSec : Music_MetaData.Tag.Bitrate = WaveFormat.nAvgBytesPerSec \ 1024

        'Back ParentChank
        mmioSeek(Fhnd, ParentFmtInfo.dwDataOffset + 4, SEEK_SET)

        'GetDataChank
        ParentDataInfo.ckid = mmioStringToFOURCC("data", 0)
        rc = mmioDescendParent(Fhnd, ParentDataInfo, Nothing, MMIO_FINDCHUNK)

        If ParentDataInfo.ckSize > 0 Then
            If Music_MetaData.Tag.DeviceType = "wave_audio" Then Music_MetaData.Tag.PlayTime = Convert.ToInt32(ParentDataInfo.ckSize / WaveFormat.nAvgBytesPerSec) * 1000 'MusicPlayTime
            If Music_MetaData.Tag.DeviceType = "cd_audio" Then Music_MetaData.Tag.PlayTime = Convert.ToInt32(WaveFormat.nBlockAlign \ 75) * 1000
        Else
            Music.Open(FilePath) '曲を開いて情報取得
            Music_MetaData.Tag.DeviceType = Music.GetDeviceType(FilePath)
            Music_MetaData.Tag.PlayTime = Convert.ToInt32(GetAllTime(FilePath, Music_MetaData.Tag.DeviceType)) 'TotalPlayTime
            Music.Close(FilePath) '閉じる
        End If

        Dim WavData(ParentDataInfo.ckSize) As Byte
        size = mmioReadString(Fhnd, WavData, ParentDataInfo.ckSize)

GetEnd:
        If Music_MetaData.Tag.MusicTitle = "" Then Music_MetaData.Tag.MusicTitle = IO.Path.GetFileNameWithoutExtension(FilePath)
        If Music_MetaData.Tag.AlbumName = "" Then Music_MetaData.Tag.AlbumName = "None"
        If Music_MetaData.Tag.ArtistName = "" Then Music_MetaData.Tag.ArtistName = "None"
        If Music_MetaData.Tag.Coment = "" Then Music_MetaData.Tag.Coment = "None"
        If Music_MetaData.Tag.SubTitle = "" Then Music_MetaData.Tag.SubTitle = "None"

        '        If size <> ParentDatainfo.ckSize Then Return


        mmioClose(Fhnd, 0) 'MMioClose
    End Sub
End Module
