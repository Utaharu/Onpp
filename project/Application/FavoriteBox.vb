Imports TagLib.Matroska

Public Class FavoriteBox
    Private Sub FavoriteBox_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason <> CloseReason.FormOwnerClosing Then
            e.Cancel = True
            MainForm.FavoriteBoxBtm.Checked = False
            Me.Visible = False
        Else
            'Favorite RootTree Save
            MainForm.DB.Tables("TreeView").Clear()
            If RootTree.Nodes.Count > 0 Then
                Dim LevelNo As Integer
                RootTree.SelectedNode = RootTree.Nodes(0)

                Do
                    If IsNothing(RootTree.SelectedNode.Tag) = False And IsNothing(RootTree.SelectedNode.Text) = False Then
                        MainForm.DB.Tables("TreeView").Rows.Add(LevelNo, RootTree.SelectedNode.Text, RootTree.SelectedNode.Tag.ToString)
                    End If

                    If IsNothing(RootTree.SelectedNode.FirstNode) = False Then 'Child Node Found
                        RootTree.SelectedNode = RootTree.SelectedNode.FirstNode
                        LevelNo += 1
                    Else
                        'Next Node
                        If IsNothing(RootTree.SelectedNode.NextNode) = True Then '= Level Node is Not Found
                            Do While IsNothing(RootTree.SelectedNode.NextNode) 'Parent - NextNode Search
                                RootTree.SelectedNode = RootTree.SelectedNode.Parent
                                LevelNo -= 1
                                If LevelNo < 0 Then GoTo Finish 'None NextNode
                            Loop

                            RootTree.SelectedNode = RootTree.SelectedNode.NextNode 'Parent - NextNode Found
                        Else
                            RootTree.SelectedNode = RootTree.SelectedNode.NextNode 'Brother - NextNode Found
                        End If
                    End If
                    If LevelNo < 0 Then Exit Do

                Loop
Finish:
            End If
        End If
    End Sub

    Private Sub Form_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        MeInfo.Text = ""
        RootPath.ResetText()

        NodeAdd_Btm.Image = MainForm.ImageList1.Images("Folder_Open")
        SeletNodeDel_Btm.Image = MainForm.ImageList1.Images("One_Del")
        AllNodeDel_Btm.Image = MainForm.ImageList1.Images("All_Del")

        'Favorite RootTree Load
        Dim Nlevel As Integer
        If IO.File.Exists(RootTreeFile) Then
            MainForm.DB.Tables("TreeView").ReadXml(RootTreeFile)

            For Each row As Data.DataRow In MainForm.DB.Tables("TreeView").Rows
                If IO.Directory.Exists(row.Item("Tag").ToString) Then 'Root Check
                    If Convert.ToInt32(row.Item("Level")) = 0 Then '0Level
                        RootTree.Nodes.Add(row.Item("Name").ToString, row.Item("Name").ToString).Tag = row.Item("Tag").ToString
                        RootTree.SelectedNode = RootTree.Nodes.Find(row.Item("Name").ToString, False)(0)

                    ElseIf Convert.ToInt32(row.Item("Level")) = Nlevel Then '=Level
                        RootTree.SelectedNode.Parent.Nodes.Add(row.Item("Name").ToString, row.Item("Name").ToString).Tag = row.Item("Tag").ToString
                        RootTree.SelectedNode = RootTree.SelectedNode.Parent.Nodes.Find(row.Item("Name").ToString, False)(0)

                    ElseIf Convert.ToInt32(row.Item("Level")) > Nlevel Then '+Level
                        RootTree.SelectedNode.Nodes.Add(row.Item("Name").ToString, row.Item("Name").ToString).Tag = row.Item("Tag").ToString
                        RootTree.SelectedNode = RootTree.SelectedNode.Nodes.Find(row.Item("Name").ToString, True)(0)

                    ElseIf Convert.ToInt32(row.Item("Level")) < Nlevel Then '-Level
                        For A = 0 To Nlevel
                            If Convert.ToInt32(row.Item("Level")) > Nlevel - A Then
                                RootTree.SelectedNode.Nodes.Add(row.Item("Name").ToString, row.Item("Name").ToString).Tag = row.Item("Tag").ToString
                                RootTree.SelectedNode = RootTree.SelectedNode.Nodes.Find(row.Item("Name").ToString, True)(0)
                                Exit For
                            Else
                                RootTree.SelectedNode = RootTree.SelectedNode.Parent
                            End If
                        Next
                    End If
                    Nlevel = Convert.ToInt32(row.Item("Level"))
                End If
            Next

            RootTree.CollapseAll()
            If RootTree.Nodes.Count > 0 Then
                RootTree.SelectedNode = RootTree.Nodes(0)
            End If
        End If

    End Sub

    Private Sub Form_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize 'Form Riseze
        If Me.Dock = DockStyle.None And Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.Dock = DockStyle.Fill
        ElseIf Me.Dock = DockStyle.Fill And Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
            Me.Dock = DockStyle.None
        End If
    End Sub

    Private Sub SelectItemAddBtm_Click(sender As System.Object, e As System.EventArgs) Handles SelectItemAddBtm.Click 'SelectFile -> PlayList Add
        If FileList.SelectedRows.Count > 0 Then
            AddNum = 0
            MeInfo.Text = "追加中…"

            PlayListBox.MusicList.ScrollBars = ScrollBars.None
            Me.Enabled = False
            MainForm.Enabled = False

            For Each item As DataGridViewRow In FileList.SelectedRows
                File_Add(item.Tag.ToString) 'PlayList Add
                Me.MeInfo.Text = "追加中… " & AddNum & " / " & FileList.SelectedRows.Count
                '                item.Selected = False
            Next
            MainForm.DB.Tables("PlayListData").AcceptChanges()

            MainForm.Enabled = True
            Me.Enabled = True
            PlayListBox.MusicList.ScrollBars = ScrollBars.Both

            MeInfo.Text = "選択ファイルをプレイリストに追加しました。"
            Beep()
        Else
            MeInfo.Text = "選択ファイルがありません。"
        End If
    End Sub

    Private Sub SelectItemNewBtm_Click(sender As System.Object, e As System.EventArgs) Handles SelectItemNewBtm.Click 'SelectFile -> New PlayList Make
        If FileList.SelectedRows.Count > 0 Then
            Button.MusicAllDel()
            AddNum = 0
            MeInfo.Text = Status.Text
            If MainForm.DB.Tables("PlayListData").Rows.Count = 0 Then
                MeInfo.Text = "作成中…"

                PlayListBox.MusicList.ScrollBars = ScrollBars.None
                Me.Enabled = False
                MainForm.Enabled = False

                For Each item As DataGridViewRow In FileList.SelectedRows
                    File_Add(item.Tag.ToString) 'PlayList add
                    Me.MeInfo.Text = "作成中… " & AddNum & " / " & FileList.SelectedRows.Count
                    item.Selected = False
                Next
                MainForm.DB.Tables("PlayListData").AcceptChanges()

                MainForm.Enabled = True
                Me.Enabled = True
                PlayListBox.MusicList.ScrollBars = ScrollBars.Both

                MeInfo.Text = "選択ファイルからプレイリストを作成しました。"
                Beep()
            End If
        ElseIf MainForm.DB.Tables("PlayListData").Rows.Count = 0 And FileList.SelectedRows.Count = 0 Then
            MeInfo.Text = "選択ファイルがありません"
            Beep()
        End If
    End Sub

    Private Sub AllItemAddBtm_Click(sender As System.Object, e As System.EventArgs) Handles AllItemAddBtm.Click 'AllFile -> PlayList Add
        If FileList.Rows.Count > 0 Then
            AddNum = 0
            MeInfo.Text = "追加中…"

            PlayListBox.MusicList.ScrollBars = ScrollBars.None
            Me.Enabled = False
            MainForm.Enabled = False

            For Each item As DataGridViewRow In FileList.Rows
                File_Add(item.Tag.ToString) 'PlayList Add
                Me.MeInfo.Text = "追加中… " & AddNum & " / " & FileList.Rows.Count
                Me.MeInfo.Text = Status.Text
            Next
            MainForm.DB.Tables("PlayListData").AcceptChanges()

            MainForm.Enabled = True
            Me.Enabled = True
            PlayListBox.MusicList.ScrollBars = ScrollBars.Both

            MeInfo.Text = "ファイルリストからプレイリストに追加しました。"
            Beep()
        Else
            MeInfo.Text = "ファイルがありません。"
            Beep()
        End If
    End Sub

    Private Sub AllItemNewBtm_Click(sender As System.Object, e As System.EventArgs) Handles AllItemNewBtm.Click 'AllFile -> New PlayList Make
        If FileList.Rows.Count > 0 Then
            AddNum = 0
            Button.MusicAllDel()
            MeInfo.Text = Status.Text
            If MainForm.DB.Tables("PlayListData").Rows.Count = 0 Then
                MeInfo.Text = "作成中…"

                PlayListBox.MusicList.ScrollBars = ScrollBars.None
                Me.Enabled = False
                MainForm.Enabled = False

                For Each item As DataGridViewRow In FileList.Rows
                    File_Add(item.Tag.ToString) 'PlayList Add
                    Me.MeInfo.Text = "作成中… " & AddNum & " / " & FileList.Rows.Count
                Next
                MainForm.DB.Tables("PlayListData").AcceptChanges()

                MainForm.Enabled = True
                Me.Enabled = True
                PlayListBox.MusicList.ScrollBars = ScrollBars.Both

                MeInfo.Text = "ファイルリストからプレイリストを作成しました。"
                Beep()
            End If
        Else
            MeInfo.Text = "ファイルがありません"
            Beep()
        End If
    End Sub
    Private Sub RootItemNewBtm_Click(sender As System.Object, e As System.EventArgs) Handles RootSelectItemNewBtm.Click 'RootFile -> New PlayList Make
        If FileList.Rows.Count > 0 Then
            AddNum = 0
            Button.MusicAllDel()
            MeInfo.Text = Status.Text
            If MainForm.DB.Tables("PlayListData").Rows.Count = 0 Then
                MeInfo.Text = "作成中…"

                PlayListBox.MusicList.ScrollBars = ScrollBars.None
                Me.Enabled = False
                MainForm.Enabled = False

                For Each item As DataGridViewRow In FileList.Rows
                    If RootPath.Text = System.IO.Path.GetDirectoryName(item.Tag.ToString) Then
                        File_Add(item.Tag.ToString) 'PlayList Add
                        Me.MeInfo.Text = "作成中… " & AddNum & " / " & FileList.Rows.Count
                    End If
                Next
                MainForm.DB.Tables("PlayListData").AcceptChanges()

                MainForm.Enabled = True
                Me.Enabled = True
                PlayListBox.MusicList.ScrollBars = ScrollBars.Both

                MeInfo.Text = "同ルートのみのプレイリストを作成しました。"
                Beep()
            End If
        Else
            MeInfo.Text = "ファイルがありません"
            Beep()
        End If
    End Sub
    Private Sub RootItemAddBtm_Click(sender As System.Object, e As System.EventArgs) Handles RootSelectItemAddBtm.Click 'RootFile -> PlayListAdd
        If FileList.Rows.Count > 0 Then
            AddNum = 0
            MeInfo.Text = "追加中…"

            PlayListBox.MusicList.ScrollBars = ScrollBars.None
            Me.Enabled = False
            MainForm.Enabled = False

            For Each item As DataGridViewRow In FileList.Rows
                If RootPath.Text = System.IO.Path.GetDirectoryName(item.Tag.ToString) Then
                    File_Add(item.Tag.ToString) 'PlayList Add
                    Me.MeInfo.Text = "追加中… " & AddNum & " / " & FileList.Rows.Count
                    Me.MeInfo.Text = Status.Text
                End If
            Next
            MainForm.DB.Tables("PlayListData").AcceptChanges()

            MainForm.Enabled = True
            Me.Enabled = True
            PlayListBox.MusicList.ScrollBars = ScrollBars.Both

            MeInfo.Text = "ファイルリストからプレイリストに追加しました。"
            Beep()
        Else
            MeInfo.Text = "ファイルがありません。"
            Beep()
        End If
    End Sub
    Private Sub NodeAddBtm_Click(sender As System.Object, e As System.EventArgs) Handles NodeAdd_Menu.Click
        Dim fdialog As New FolderBrowserDialog
        fdialog.ShowNewFolderButton = False

        Me.Enabled = False

        If DialogResult.Cancel <> fdialog.ShowDialog() Then
            Dim Filter() As String = TargetFile.Split(CChar(";"))

            '            Dim sw As New Stopwatch 追加処理秒数測定用
            '           sw.Start()

            Dim ParentName As String = FileIO.FileSystem.GetDirectoryInfo(fdialog.SelectedPath).Name

            Dim ParentNode = RootTree.Nodes.Find(ParentName, False)

            'ParentRoot
            If ParentNode.Length = 0 Then
                RootTree.Nodes.Add(ParentName, ParentName) 'Parent Node Add
                RootTree.Nodes(ParentName).Tag = fdialog.SelectedPath 'RootPath

                ParentNode = RootTree.Nodes.Find(ParentName, False)
            End If

            'FileSearch
            '            Dim PathList As New ArrayList
            RootTree.BeginUpdate()
            Dim DirCol As IEnumerable(Of String) = IO.Directory.EnumerateDirectories(fdialog.SelectedPath, "*", IO.SearchOption.AllDirectories)

            For Each Folder As String In DirCol
                For Each ext As String In Filter

                    Dim FileCol As IEnumerable(Of String) = IO.Directory.EnumerateFiles(Folder, ext, IO.SearchOption.AllDirectories)
                    For Each File In FileCol

                        '                      PathList.Add(File.Replace(fdialog.SelectedPath, "").Replace(IO.Path.GetFileName(File), ""))
                        Dim Root() As String = File.Replace(fdialog.SelectedPath, "").Split(IO.Path.DirectorySeparatorChar) 'IO.Path.GetDirectoryName(FileCol(A)).Replace(fdialog.SelectedPath, "").Split(IO.Path.DirectorySeparatorChar)
                        RootTree.SelectedNode = ParentNode(0) 'Node - NowPosition -> Parent Node

                        'ChildRoot
                        For B = 0 To Root.Length - 2
                            If Root(B) <> "" Then
                                If RootTree.SelectedNode.Nodes.Find(Root(B), False).Length = 0 Then
                                    RootTree.SelectedNode.Nodes.Add(Root(B), Root(B)) 'Child Node Add
                                    RootTree.SelectedNode.Nodes.Find(Root(B), False)(0).Tag = RootTree.SelectedNode.Tag.ToString + "\" + Root(B) 'RootPath
                                End If
                                RootTree.SelectedNode = RootTree.SelectedNode.Nodes.Find(Root(B), False)(0) 'Node - NowPosition -> NewChild Node
                            End If
                        Next

                        GoTo NextFolder
                    Next
                Next
NextFolder:
            Next

            '            sw.Stop()
            '           MsgBox(sw.Elapsed.ToString)

            RootTree.CollapseAll()
            RootTree.EndUpdate()

        End If
        Me.Enabled = True
    End Sub

    Private Sub SelectNodeDel_Menu_Click(sender As System.Object, e As System.EventArgs) Handles SelectNodeDel_Menu.Click 'Selected Node Remove
        If IsNothing(RootTree.SelectedNode) = False Then
            If RootTree.SelectedNode.Tag.ToString = RootPath.Text Then RootPath.ResetText() : FileList.Rows.Clear()
            MeInfo.Text = "お気に入り:「" & RootTree.SelectedNode.Text & "」を削除しました。"
            RootTree.SelectedNode.Remove()
        Else
            MeInfo.Text = "お気に入りが選択されていません。"
        End If

    End Sub

    Private Sub AllNodeDel_Menu_Click(sender As System.Object, e As System.EventArgs) Handles AllNodeDel_Menu.Click 'All Node Clear
        If RootTree.Nodes.Count > 0 Then
            RootPath.ResetText()
            FileList.Rows.Clear()
            RootTree.Nodes.Clear()
            MeInfo.Text = "お気に入りを全て削除しました。"
        Else
            MeInfo.Text = "既に削除済みです"
        End If

    End Sub

    Private Sub NodeAdd_Btm_Click(sender As Object, e As EventArgs) Handles NodeAdd_Btm.Click 'F
        NodeAdd_Menu.PerformClick()
    End Sub

    Private Sub SeletNodeDel_Btm_Click(sender As Object, e As EventArgs) Handles SeletNodeDel_Btm.Click
        SelectNodeDel_Menu.PerformClick()
    End Sub

    Private Sub AllNodeDel_Btm_Click(sender As Object, e As EventArgs) Handles AllNodeDel_Btm.Click
        AllNodeDel_Menu.PerformClick()
    End Sub

    Private Sub FavoriteBox_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        MainForm.FavoriteBtm.Checked = Me.Visible
    End Sub
    Private Sub FileList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles FileList.CellDoubleClick
        SelectItemAddBtm.PerformClick()
    End Sub

    Private Sub RootTree_DragOver(sender As Object, e As DragEventArgs) Handles RootTree.DragOver
        If e.Data.GetDataPresent(GetType(TreeNode)) And (e.AllowedEffect And DragDropEffects.Move) = DragDropEffects.Move Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If

        If e.Effect <> DragDropEffects.None Then
            Dim rt As TreeView = CType(sender, TreeView)
            Dim target As TreeNode =
                rt.GetNodeAt(rt.PointToClient(New Point(e.X, e.Y)))
            Dim [source] As TreeNode =
                CType(e.Data.GetData(GetType(TreeNode)), TreeNode)
            If target IsNot Nothing AndAlso target IsNot [source] Then
                If target.IsSelected = False Then
                    rt.SelectedNode = target
                End If
            Else
                e.Effect = DragDropEffects.None
            End If
        End If

    End Sub

    Private Sub RootTree_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles RootTree.ItemDrag
        Dim rt As TreeView = CType(sender, TreeView)
        rt.SelectedNode = CType(e.Item, TreeNode)
        rt.Focus()

        'DragStart
        Dim DEffect As DragDropEffects = rt.DoDragDrop(e.Item, DragDropEffects.Move)

        If (DEffect And DragDropEffects.Move) = DragDropEffects.Move Then
            rt.Nodes.Remove(CType(e.Item, TreeNode))
        End If
    End Sub
    Private Sub RootTree_DragDrop(sender As Object, e As DragEventArgs) Handles RootTree.DragDrop
        If e.Data.GetDataPresent(GetType(TreeNode)) Then
            Dim rt As TreeView = CType(sender, TreeView)
            Dim [source] As TreeNode = CType(e.Data.GetData(GetType(TreeNode)), TreeNode)
            Dim target As TreeNode = rt.GetNodeAt(rt.PointToClient(New Point(e.X, e.Y)))

            If target IsNot Nothing AndAlso target IsNot [source] AndAlso Not IsChildNode([source], target) Then
                Dim clone As TreeNode = CType([source].Clone(), TreeNode)
                target.Nodes.Add(clone)
                target.Expand()
                RootTree.SelectedNode = clone
                RootPath.Text = RootTree.SelectedNode.Tag.ToString
            Else
                e.Effect = DragDropEffects.None
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Shared Function IsChildNode(ByVal parentNode As TreeNode, ByVal childNode As TreeNode) As Boolean
        If childNode.Parent Is parentNode Then
            Return True
        ElseIf childNode.Parent IsNot Nothing Then
            Return IsChildNode(parentNode, childNode.Parent)
        Else
            Return False
        End If
    End Function

    Private Sub RootTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles RootTree.AfterSelect 'Folder Select
        If e.Action <> TreeViewAction.Unknown Or (e.Action = TreeViewAction.Unknown And e.Node.Level = 0) Then
            Me.Enabled = False

            If IsNothing(e.Node.Tag) Then GoTo NoPath
            If e.Node.Tag.ToString = "" Then GoTo NoPath

            If IO.Directory.Exists(e.Node.Tag.ToString) Then
                If RootPath.Text <> e.Node.Tag.ToString Then 'RootPath
                    RootPath.Text = e.Node.Tag.ToString
                End If
            Else
                FileList.Rows.Clear()
                RootPath.Text = e.Node.Tag.ToString
NoPath:
                MeInfo.Text = "不明な場所です。"
            End If

            Me.Enabled = True
        End If

    End Sub
    Private Sub RootTree_NodeMouseClick(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles RootTree.NodeMouseClick 'NodeClick Selected
        If e.Node.IsSelected = True Then
        End If
    End Sub
    Private Sub RootPath_TextChanged(sender As Object, e As EventArgs) Handles RootPath.TextChanged
        MeInfo.Text = "ファイルを探しています。"
        FileList.Rows.Clear()

        If IO.Directory.Exists(RootPath.Text) Then
            'FileSearch
            FileList.SuspendLayout()
            Dim Filter() As String = TargetFile.Split(CChar(";"))
            For Each ext As String In Filter
                Dim File As IEnumerable(Of String) = System.IO.Directory.EnumerateFiles(RootPath.Text, ext, IO.SearchOption.AllDirectories)
                For Each item As String In File
                    Dim Place As String = item.Replace(RootPath.Text, "")

                    FileList.Rows.Add(System.IO.Path.GetFileName(item), Place) 'FileAdd
                    FileList.Rows(FileList.Rows.Count - 1).Tag = item 'RootPath
                Next
            Next
            FileList.ResumeLayout()
            FileList.Update()
        End If

        If FileList.Rows.Count > 0 Then
            MeInfo.Text = FileList.Rows.Count & "個のファイルが見つかりました。"
        Else
            MeInfo.Text = "ファイルが見つかりませんでした。"
        End If

    End Sub
End Class
