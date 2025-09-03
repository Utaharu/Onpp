Partial Class OnppDB

    Partial Class PlayListDataDataTable


        Private Sub PlayListDataDataTable_RowDeleing(sender As Object, e As System.Data.DataRowChangeEventArgs) Handles Me.RowDeleting
            'PlayListData ItemDelete - > PlayListView連動
            If e.Row.Table.TableName = "PlayListData" Then
                SumPlayTime -= Convert.ToInt32(e.Row("PlayTime"))
                '                MainForm.SumTime.Text = TS_Change(SumPlayTime)

                MainForm.DB.Tables("PlayListView").Rows.Remove(MainForm.DB.Tables("PlayListView").Rows.Find(e.Row.Item("No")))

                If PlayInfo.PlayIndex > 0 Then
                    MainForm.MusicNum.Text = (PlayInfo.PlayIndex + 1) & " / " & MainForm.DB.Tables("PlayListView").Rows.Count.ToString
                Else
                    MainForm.MusicNum.Text = (PlayInfo.PlayIndex) & " / " & MainForm.DB.Tables("PlayListView").Rows.Count.ToString
                End If

            End If
        End Sub

        Private Sub PlayListDataDataTable_RowChanged(sender As Object, e As System.Data.DataRowChangeEventArgs) Handles Me.RowChanged
            If e.Action = Data.DataRowAction.Add And e.Row.Table.TableName = "PlayListData" Then
                MainForm.DB.Tables("PlayListView").Rows.Add(e.Row("No"), e.Row("Title"), e.Row("SubTitle"), Convert.ToInt32(e.Row("PlayTime")), e.Row("Artist"), e.Row("Album"), e.Row("Bitrate"), e.Row("Samplerate"), e.Row("FileSize"), e.Row("Path"))
                ' MainForm.DB.Tables("PlayListView").Rows.Add(e.Row("No"), DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, e.Row("Path"))

                If PlayInfo.PlayIndex > 0 Then
                    MainForm.MusicNum.Text = (PlayInfo.PlayIndex + 1) & " / " & MainForm.DB.Tables("PlayListView").Rows.Count.ToString
                Else
                    MainForm.MusicNum.Text = (PlayInfo.PlayIndex) & " / " & MainForm.DB.Tables("PlayListView").Rows.Count.ToString
                End If

                SumPlayTime += Convert.ToInt32(e.Row("PlayTime"))
                '            MainForm.SumTime.Text = TS_Change(SumPlayTime)
            End If
        End Sub

        Private Sub PlayListDataDataTable_TableCleared(sender As Object, e As System.Data.DataTableClearEventArgs) Handles Me.TableCleared
            'PlayListData Clear -> PlayListView連動
            If e.TableName = "PlayListData" Then
                MainForm.DB.Tables("PlayListView").Rows.Clear()

                MainForm.MusicNum.Text = "0 / " & MainForm.DB.Tables("PlayListView").Rows.Count.ToString
                SumPlayTime = 0
                '         MainForm.SumTime.Text = TS_Change(SumPlayTime)
            End If

        End Sub
    End Class

End Class
