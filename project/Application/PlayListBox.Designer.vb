<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayListBox
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MusicList = New System.Windows.Forms.DataGridView()
        Me.State = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Subtitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlayTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Artist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Album = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bitrate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Samplerate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MusicListMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ColumnViewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayNoViewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.TitleViewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubTitleViewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.TimeViewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArtistViewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlbumViewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.BitrateViewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.SamplerateViewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.PathViewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSizeViewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.OnppDB = New Onpp.OnppDB()
        CType(Me.MusicList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MusicListMenu.SuspendLayout()
        CType(Me.OnppDB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MusicList
        '
        Me.MusicList.AllowUserToAddRows = False
        Me.MusicList.AllowUserToDeleteRows = False
        Me.MusicList.AllowUserToOrderColumns = True
        Me.MusicList.AllowUserToResizeRows = False
        Me.MusicList.AutoGenerateColumns = False
        Me.MusicList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.MusicList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MusicList.CausesValidation = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MusicList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MusicList.ColumnHeadersHeight = 20
        Me.MusicList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.MusicList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.State, Me.No, Me.Title, Me.Subtitle, Me.PlayTime, Me.Artist, Me.Album, Me.Bitrate, Me.Samplerate, Me.FileSize, Me.Path})
        Me.MusicList.ContextMenuStrip = Me.MusicListMenu
        Me.MusicList.DataMember = "PlayListView"
        Me.MusicList.DataSource = Me.OnppDB
        Me.MusicList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MusicList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.MusicList.Location = New System.Drawing.Point(0, 0)
        Me.MusicList.MultiSelect = False
        Me.MusicList.Name = "MusicList"
        Me.MusicList.ReadOnly = True
        Me.MusicList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MusicList.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.MusicList.RowHeadersVisible = False
        Me.MusicList.RowHeadersWidth = 23
        Me.MusicList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.MusicList.RowTemplate.Height = 17
        Me.MusicList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MusicList.ShowCellErrors = False
        Me.MusicList.ShowEditingIcon = False
        Me.MusicList.ShowRowErrors = False
        Me.MusicList.Size = New System.Drawing.Size(318, 216)
        Me.MusicList.StandardTab = True
        Me.MusicList.TabIndex = 14
        Me.MusicList.VirtualMode = True
        '
        'State
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.State.DefaultCellStyle = DataGridViewCellStyle2
        Me.State.FillWeight = 20.0!
        Me.State.Frozen = True
        Me.State.HeaderText = "◆"
        Me.State.Name = "State"
        Me.State.ReadOnly = True
        Me.State.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.State.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.State.ToolTipText = "再生マーカー"
        Me.State.Width = 20
        '
        'No
        '
        Me.No.DataPropertyName = "No"
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.No.ToolTipText = "曲番号"
        '
        'Title
        '
        Me.Title.DataPropertyName = "Title"
        Me.Title.FillWeight = 150.0!
        Me.Title.HeaderText = "曲名"
        Me.Title.Name = "Title"
        Me.Title.ReadOnly = True
        Me.Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Title.ToolTipText = "曲名"
        Me.Title.Width = 150
        '
        'Subtitle
        '
        Me.Subtitle.DataPropertyName = "Subtitle"
        Me.Subtitle.HeaderText = "サブタイトル"
        Me.Subtitle.Name = "Subtitle"
        Me.Subtitle.ReadOnly = True
        Me.Subtitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Subtitle.ToolTipText = "サブタイトル"
        '
        'PlayTime
        '
        Me.PlayTime.FillWeight = 45.0!
        Me.PlayTime.HeaderText = "時間"
        Me.PlayTime.Name = "PlayTime"
        Me.PlayTime.ReadOnly = True
        Me.PlayTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.PlayTime.ToolTipText = "時間"
        Me.PlayTime.Width = 45
        '
        'Artist
        '
        Me.Artist.DataPropertyName = "Artist"
        Me.Artist.HeaderText = "アーティスト"
        Me.Artist.Name = "Artist"
        Me.Artist.ReadOnly = True
        Me.Artist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Artist.ToolTipText = "アーティスト"
        '
        'Album
        '
        Me.Album.DataPropertyName = "Album"
        Me.Album.HeaderText = "アルバム"
        Me.Album.Name = "Album"
        Me.Album.ReadOnly = True
        Me.Album.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Album.ToolTipText = "アルバム"
        '
        'Bitrate
        '
        Me.Bitrate.DataPropertyName = "Bitrate"
        Me.Bitrate.HeaderText = "kbps"
        Me.Bitrate.Name = "Bitrate"
        Me.Bitrate.ReadOnly = True
        Me.Bitrate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Bitrate.ToolTipText = "ビットレート"
        '
        'Samplerate
        '
        Me.Samplerate.DataPropertyName = "Samplerate"
        Me.Samplerate.HeaderText = "Hz"
        Me.Samplerate.Name = "Samplerate"
        Me.Samplerate.ReadOnly = True
        Me.Samplerate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Samplerate.ToolTipText = "サンプルレート"
        '
        'FileSize
        '
        Me.FileSize.HeaderText = "Size"
        Me.FileSize.Name = "FileSize"
        Me.FileSize.ReadOnly = True
        Me.FileSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.FileSize.ToolTipText = "ファイルサイズ"
        Me.FileSize.Visible = False
        '
        'Path
        '
        Me.Path.DataPropertyName = "Path"
        Me.Path.HeaderText = "Path"
        Me.Path.Name = "Path"
        Me.Path.ReadOnly = True
        Me.Path.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Path.ToolTipText = "場所"
        '
        'MusicListMenu
        '
        Me.MusicListMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ColumnViewMenu})
        Me.MusicListMenu.Name = "MusicListMenu"
        Me.MusicListMenu.ShowCheckMargin = True
        Me.MusicListMenu.ShowImageMargin = False
        Me.MusicListMenu.Size = New System.Drawing.Size(123, 26)
        '
        'ColumnViewMenu
        '
        Me.ColumnViewMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayNoViewBtm, Me.TitleViewBtm, Me.SubTitleViewBtm, Me.TimeViewBtm, Me.ArtistViewBtm, Me.AlbumViewBtm, Me.BitrateViewBtm, Me.SamplerateViewBtm, Me.PathViewBtm, Me.FileSizeViewBtm})
        Me.ColumnViewMenu.Name = "ColumnViewMenu"
        Me.ColumnViewMenu.Size = New System.Drawing.Size(122, 22)
        Me.ColumnViewMenu.Text = "表示項目"
        '
        'PlayNoViewBtm
        '
        Me.PlayNoViewBtm.AutoToolTip = True
        Me.PlayNoViewBtm.CheckOnClick = True
        Me.PlayNoViewBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.PlayNoViewBtm.Name = "PlayNoViewBtm"
        Me.PlayNoViewBtm.Size = New System.Drawing.Size(142, 22)
        Me.PlayNoViewBtm.Text = "No"
        Me.PlayNoViewBtm.ToolTipText = "No"
        '
        'TitleViewBtm
        '
        Me.TitleViewBtm.AutoToolTip = True
        Me.TitleViewBtm.CheckOnClick = True
        Me.TitleViewBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TitleViewBtm.Name = "TitleViewBtm"
        Me.TitleViewBtm.Size = New System.Drawing.Size(142, 22)
        Me.TitleViewBtm.Text = "曲名"
        '
        'SubTitleViewBtm
        '
        Me.SubTitleViewBtm.AutoToolTip = True
        Me.SubTitleViewBtm.CheckOnClick = True
        Me.SubTitleViewBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SubTitleViewBtm.Name = "SubTitleViewBtm"
        Me.SubTitleViewBtm.Size = New System.Drawing.Size(142, 22)
        Me.SubTitleViewBtm.Text = "サブタイトル"
        '
        'TimeViewBtm
        '
        Me.TimeViewBtm.AutoToolTip = True
        Me.TimeViewBtm.CheckOnClick = True
        Me.TimeViewBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TimeViewBtm.Name = "TimeViewBtm"
        Me.TimeViewBtm.Size = New System.Drawing.Size(142, 22)
        Me.TimeViewBtm.Text = "時間"
        '
        'ArtistViewBtm
        '
        Me.ArtistViewBtm.AutoToolTip = True
        Me.ArtistViewBtm.CheckOnClick = True
        Me.ArtistViewBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ArtistViewBtm.Name = "ArtistViewBtm"
        Me.ArtistViewBtm.Size = New System.Drawing.Size(142, 22)
        Me.ArtistViewBtm.Text = "アーティスト"
        '
        'AlbumViewBtm
        '
        Me.AlbumViewBtm.AutoToolTip = True
        Me.AlbumViewBtm.CheckOnClick = True
        Me.AlbumViewBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AlbumViewBtm.Name = "AlbumViewBtm"
        Me.AlbumViewBtm.Size = New System.Drawing.Size(142, 22)
        Me.AlbumViewBtm.Text = "アルバム"
        '
        'BitrateViewBtm
        '
        Me.BitrateViewBtm.AutoToolTip = True
        Me.BitrateViewBtm.CheckOnClick = True
        Me.BitrateViewBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.BitrateViewBtm.Name = "BitrateViewBtm"
        Me.BitrateViewBtm.Size = New System.Drawing.Size(142, 22)
        Me.BitrateViewBtm.Text = "ビットレート"
        Me.BitrateViewBtm.ToolTipText = "ビットレート"
        '
        'SamplerateViewBtm
        '
        Me.SamplerateViewBtm.AutoToolTip = True
        Me.SamplerateViewBtm.CheckOnClick = True
        Me.SamplerateViewBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SamplerateViewBtm.Name = "SamplerateViewBtm"
        Me.SamplerateViewBtm.Size = New System.Drawing.Size(142, 22)
        Me.SamplerateViewBtm.Text = "サンプルレート"
        Me.SamplerateViewBtm.ToolTipText = "サンプリング周波数"
        '
        'PathViewBtm
        '
        Me.PathViewBtm.AutoToolTip = True
        Me.PathViewBtm.CheckOnClick = True
        Me.PathViewBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.PathViewBtm.Name = "PathViewBtm"
        Me.PathViewBtm.Size = New System.Drawing.Size(142, 22)
        Me.PathViewBtm.Text = "ファイルの場所"
        '
        'FileSizeViewBtm
        '
        Me.FileSizeViewBtm.AutoToolTip = True
        Me.FileSizeViewBtm.CheckOnClick = True
        Me.FileSizeViewBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.FileSizeViewBtm.Name = "FileSizeViewBtm"
        Me.FileSizeViewBtm.Size = New System.Drawing.Size(142, 22)
        Me.FileSizeViewBtm.Text = "ファイルサイズ"
        '
        'OnppDB
        '
        Me.OnppDB.CaseSensitive = True
        Me.OnppDB.DataSetName = "OnppDB"
        Me.OnppDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PlayListBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(318, 216)
        Me.Controls.Add(Me.MusicList)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.DoubleBuffered = True
        Me.Name = "PlayListBox"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "プレイリスト"
        CType(Me.MusicList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MusicListMenu.ResumeLayout(False)
        CType(Me.OnppDB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MusicList As System.Windows.Forms.DataGridView
    Friend WithEvents OnppDB As Onpp.OnppDB
    Friend WithEvents MusicListMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents State As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Subtitle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlayTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Artist As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Album As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bitrate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Samplerate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnViewMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlayNoViewBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TitleViewBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SubTitleViewBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimeViewBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArtistViewBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlbumViewBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BitrateViewBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SamplerateViewBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PathViewBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileSizeViewBtm As System.Windows.Forms.ToolStripMenuItem
End Class
