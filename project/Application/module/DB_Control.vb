Imports System.IO

Module DB_Control

    Public Sub Load()

        If Directory.Exists(DataDirectory) = False Then IO.Directory.CreateDirectory(DataDirectory)
        If IO.File.Exists(ConfigFile) <> True Then
            MainForm.DB.Tables("ConfigData").Rows.Add("Normal", 0, "true", 1000, "No:38,Title:207,PlayTime:51,Artist:100,Album:100,Path:100,")
            MainForm.DB.Tables("ConfigData").WriteXml(ConfigFile)

        Else
            MainForm.DB.Tables("ConfigData").ReadXml(ConfigFile)
        End If
        If IO.File.Exists(StartUpFile) <> True Then
            MainForm.DB.Tables("PlayListData").NewRow()
            MainForm.DB.Tables("PlayListData").WriteXml(StartUpFile)
        Else
            MainForm.DB.Tables("PlayListData").ReadXml(StartUpFile)
        End If

        If IO.File.Exists(RootTreeFile) <> True Then
            MainForm.DB.Tables("TreeView").NewRow()
            MainForm.DB.Tables("TreeView").WriteXml(RootTreeFile)
        End If
        IO.File.Delete(Error_LogFile)
        IO.File.Create(Error_LogFile)

        'DBからフォーム状態復元
        If MainForm.DB.Tables("ConfigData").Rows.Count > 0 Then

            'mo,no,position,list,volume
            Button.SetPlayMode(MainForm.DB.Tables("ConfigData").Rows(0).Item("PlayMode").ToString) '再生モード
                MainForm.PlayListBtm.Checked = Not Convert.ToBoolean(MainForm.DB.Tables("ConfigData").Rows(0).Item("PlayList")) 'プレイリストBtm

                '再生番号
                If IsNumeric(MainForm.DB.Tables("ConfigData").Rows(0).Item("PlayNo")) And Convert.ToInt32(MainForm.DB.Tables("ConfigData").Rows(0).Item("PlayNo")) > 0 Then
                    PlayInfo.PlayNo = Convert.ToInt32(MainForm.DB.Tables("ConfigData").Rows(0).Item("PlayNo"))
                    PlayInfo.PlayIndex = GetTableIndex("PlayListView", PlayInfo.PlayNo)
                Else
                    PlayInfo.PlayNo = 1 : PlayInfo.PlayIndex = 0
                End If

                MainForm.VolumeVal.Value = Convert.ToDecimal(MainForm.DB.Tables("ConfigData").Rows(0).Item("PlayVolume")) '音量

            End If
    End Sub

    Public Sub Save(PlayNo As Integer, PlayListColum As String)
        If MainForm.DB.Tables("ConfigData").Rows.Count > 0 Then MainForm.DB.Tables("ConfigData").Rows.Clear()
        MainForm.DB.Tables("ConfigData").Rows.Add(PlayMode, PlayNo, MainForm.PlayListBtm.Checked, MainForm.VolumeVal.Value, PlayListColum)

        MainForm.DB.Tables("ConfigData").WriteXml(ConfigFile)
        MainForm.DB.Tables("PlayListData").WriteXml(StartUpFile)

        If FavoriteBox.IsHandleCreated = True Then MainForm.DB.Tables("TreeView").WriteXml(RootTreeFile)
    End Sub
End Module
