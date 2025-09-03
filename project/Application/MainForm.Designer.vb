<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Dim ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Dim ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
        Dim ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
        Dim ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MainMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PlayList_SwBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayList_DockBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayList_WindowBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.FavoriteBoxBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.InfoPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.Slider = New System.Windows.Forms.TrackBar()
        Me.TimeBox = New System.Windows.Forms.Label()
        Me.VolumeVal = New System.Windows.Forms.NumericUpDown()
        Me.ToolBox = New System.Windows.Forms.ToolStrip()
        Me.OneAddBtm = New System.Windows.Forms.ToolStripButton()
        Me.DirAddBtm = New System.Windows.Forms.ToolStripButton()
        Me.OneDelBtm = New System.Windows.Forms.ToolStripButton()
        Me.AllDelBtm = New System.Windows.Forms.ToolStripButton()
        Me.ListSaveBtm = New System.Windows.Forms.ToolStripButton()
        Me.PlayListBtm = New System.Windows.Forms.ToolStripButton()
        Me.FavoriteBtm = New System.Windows.Forms.ToolStripButton()
        Me.PlayBtm = New System.Windows.Forms.ToolStripButton()
        Me.StopBtm = New System.Windows.Forms.ToolStripButton()
        Me.PauseBtm = New System.Windows.Forms.ToolStripButton()
        Me.BackBtm = New System.Windows.Forms.ToolStripButton()
        Me.NextBtm = New System.Windows.Forms.ToolStripButton()
        Me.NormalPlayBtm = New System.Windows.Forms.ToolStripButton()
        Me.RepeatPlayBtm = New System.Windows.Forms.ToolStripButton()
        Me.ShuffleBtm = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MusicNum = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SumTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SW_Info = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DB = New Onpp.OnppDB()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MainMenu.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        Me.InfoPanel.SuspendLayout()
        CType(Me.Slider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VolumeVal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolBox.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        CType(Me.DB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripSeparator1
        '
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New System.Drawing.Size(6, 20)
        '
        'ToolStripSeparator2
        '
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New System.Drawing.Size(6, 20)
        '
        'ToolStripSeparator5
        '
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New System.Drawing.Size(6, 20)
        '
        'ToolStripSeparator3
        '
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New System.Drawing.Size(6, 20)
        '
        'ToolStripSeparator4
        '
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New System.Drawing.Size(6, 20)
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn1.FillWeight = 20.0!
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "◆"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.ToolTipText = "再生マーカー"
        Me.DataGridViewTextBoxColumn1.Width = 20
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "No"
        Me.DataGridViewTextBoxColumn2.FillWeight = 35.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "No"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn2.ToolTipText = "No"
        Me.DataGridViewTextBoxColumn2.Width = 35
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Title"
        Me.DataGridViewTextBoxColumn3.FillWeight = 145.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "曲名"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn3.ToolTipText = "曲名"
        Me.DataGridViewTextBoxColumn3.Width = 145
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Subtitle"
        Me.DataGridViewTextBoxColumn4.HeaderText = "サブタイトル"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn4.ToolTipText = "サブタイトル"
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 125
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.FillWeight = 45.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "時間"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn5.ToolTipText = "時間"
        Me.DataGridViewTextBoxColumn5.Width = 45
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Artist"
        Me.DataGridViewTextBoxColumn6.HeaderText = "アーティスト"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn6.ToolTipText = "アーティスト"
        Me.DataGridViewTextBoxColumn6.Width = 125
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Album"
        Me.DataGridViewTextBoxColumn7.HeaderText = "アルバム"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn7.ToolTipText = "アルバム"
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 125
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Bitrate"
        Me.DataGridViewTextBoxColumn8.FillWeight = 30.0!
        Me.DataGridViewTextBoxColumn8.HeaderText = "kbps"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn8.ToolTipText = "ビットレート"
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 30
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Samplerate"
        Me.DataGridViewTextBoxColumn9.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn9.HeaderText = "Hz"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn9.ToolTipText = "サンプルレート"
        Me.DataGridViewTextBoxColumn9.Visible = False
        Me.DataGridViewTextBoxColumn9.Width = 50
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Size"
        Me.DataGridViewTextBoxColumn10.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn10.ToolTipText = "ファイルサイズ"
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 125
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Path"
        Me.DataGridViewTextBoxColumn11.HeaderText = "ファイルの場所"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.DataGridViewTextBoxColumn11.ToolTipText = "ファイルの場所"
        Me.DataGridViewTextBoxColumn11.Visible = False
        Me.DataGridViewTextBoxColumn11.Width = 125
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.White
        Me.ImageList1.Images.SetKeyName(0, "Play_Off")
        Me.ImageList1.Images.SetKeyName(1, "Play_On")
        Me.ImageList1.Images.SetKeyName(2, "Stop_Off")
        Me.ImageList1.Images.SetKeyName(3, "stop_on.bmp")
        Me.ImageList1.Images.SetKeyName(4, "Pause_Off")
        Me.ImageList1.Images.SetKeyName(5, "Pause_On")
        Me.ImageList1.Images.SetKeyName(6, "Next_Off")
        Me.ImageList1.Images.SetKeyName(7, "Next_On")
        Me.ImageList1.Images.SetKeyName(8, "Back_Off")
        Me.ImageList1.Images.SetKeyName(9, "Back_On")
        Me.ImageList1.Images.SetKeyName(10, "One_Open")
        Me.ImageList1.Images.SetKeyName(11, "Folder_Open")
        Me.ImageList1.Images.SetKeyName(12, "Normal_Off")
        Me.ImageList1.Images.SetKeyName(13, "Normal_On")
        Me.ImageList1.Images.SetKeyName(14, "Repeat_Off")
        Me.ImageList1.Images.SetKeyName(15, "Repear_On")
        Me.ImageList1.Images.SetKeyName(16, "Random_Off")
        Me.ImageList1.Images.SetKeyName(17, "Random_On")
        Me.ImageList1.Images.SetKeyName(18, "One_Del")
        Me.ImageList1.Images.SetKeyName(19, "All_Del")
        Me.ImageList1.Images.SetKeyName(20, "List_Off")
        Me.ImageList1.Images.SetKeyName(21, "List_On")
        Me.ImageList1.Images.SetKeyName(22, "save")
        Me.ImageList1.Images.SetKeyName(23, "favorite")
        '
        'MainMenu
        '
        Me.MainMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayList_SwBtm, Me.FavoriteBoxBtm})
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(127, 48)
        '
        'PlayList_SwBtm
        '
        Me.PlayList_SwBtm.AutoToolTip = True
        Me.PlayList_SwBtm.CheckOnClick = True
        Me.PlayList_SwBtm.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlayList_DockBtm, Me.PlayList_WindowBtm})
        Me.PlayList_SwBtm.Name = "PlayList_SwBtm"
        Me.PlayList_SwBtm.Size = New System.Drawing.Size(126, 22)
        Me.PlayList_SwBtm.Text = "プレイリスト"
        Me.PlayList_SwBtm.ToolTipText = "プレイリストの位置"
        '
        'PlayList_DockBtm
        '
        Me.PlayList_DockBtm.AutoToolTip = True
        Me.PlayList_DockBtm.CheckOnClick = True
        Me.PlayList_DockBtm.Name = "PlayList_DockBtm"
        Me.PlayList_DockBtm.Size = New System.Drawing.Size(117, 22)
        Me.PlayList_DockBtm.Text = "ドッキング"
        Me.PlayList_DockBtm.ToolTipText = "プレイリストをドッキングして表示"
        '
        'PlayList_WindowBtm
        '
        Me.PlayList_WindowBtm.AutoToolTip = True
        Me.PlayList_WindowBtm.CheckOnClick = True
        Me.PlayList_WindowBtm.Name = "PlayList_WindowBtm"
        Me.PlayList_WindowBtm.Size = New System.Drawing.Size(117, 22)
        Me.PlayList_WindowBtm.Text = "ウィンドウ"
        Me.PlayList_WindowBtm.ToolTipText = "プレイリストを別ウィンドウに表示"
        '
        'FavoriteBoxBtm
        '
        Me.FavoriteBoxBtm.CheckOnClick = True
        Me.FavoriteBoxBtm.Name = "FavoriteBoxBtm"
        Me.FavoriteBoxBtm.Size = New System.Drawing.Size(126, 22)
        Me.FavoriteBoxBtm.Text = "お気に入り"
        Me.FavoriteBoxBtm.ToolTipText = "お気に入り管理"
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.InfoPanel)
        Me.MainPanel.Controls.Add(Me.VolumeVal)
        Me.MainPanel.Controls.Add(Me.ToolBox)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Padding = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.MainPanel.Size = New System.Drawing.Size(690, 61)
        Me.MainPanel.TabIndex = 26
        '
        'InfoPanel
        '
        Me.InfoPanel.ColumnCount = 2
        Me.InfoPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.InfoPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.InfoPanel.Controls.Add(Me.Slider, 0, 1)
        Me.InfoPanel.Controls.Add(Me.TimeBox, 1, 0)
        Me.InfoPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InfoPanel.Location = New System.Drawing.Point(5, 25)
        Me.InfoPanel.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.InfoPanel.Name = "InfoPanel"
        Me.InfoPanel.RowCount = 2
        Me.InfoPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.InfoPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.InfoPanel.Size = New System.Drawing.Size(680, 31)
        Me.InfoPanel.TabIndex = 11
        '
        'Slider
        '
        Me.Slider.AutoSize = False
        Me.InfoPanel.SetColumnSpan(Me.Slider, 2)
        Me.Slider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Slider.Location = New System.Drawing.Point(0, 20)
        Me.Slider.Margin = New System.Windows.Forms.Padding(0)
        Me.Slider.Name = "Slider"
        Me.Slider.Size = New System.Drawing.Size(680, 15)
        Me.Slider.TabIndex = 12
        Me.Slider.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'TimeBox
        '
        Me.TimeBox.AutoSize = True
        Me.TimeBox.BackColor = System.Drawing.Color.White
        Me.TimeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TimeBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TimeBox.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TimeBox.Location = New System.Drawing.Point(560, 0)
        Me.TimeBox.Margin = New System.Windows.Forms.Padding(0)
        Me.TimeBox.Name = "TimeBox"
        Me.TimeBox.Size = New System.Drawing.Size(120, 20)
        Me.TimeBox.TabIndex = 10
        Me.TimeBox.Text = "TimeBox"
        Me.TimeBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VolumeVal
        '
        Me.VolumeVal.Location = New System.Drawing.Point(333, 5)
        Me.VolumeVal.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.VolumeVal.Name = "VolumeVal"
        Me.VolumeVal.Size = New System.Drawing.Size(45, 19)
        Me.VolumeVal.TabIndex = 9
        Me.VolumeVal.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'ToolBox
        '
        Me.ToolBox.AutoSize = False
        Me.ToolBox.BackColor = System.Drawing.SystemColors.Control
        Me.ToolBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolBox.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolBox.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolBox.ImageScalingSize = New System.Drawing.Size(12, 12)
        Me.ToolBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OneAddBtm, Me.DirAddBtm, Me.OneDelBtm, Me.AllDelBtm, Me.ListSaveBtm, ToolStripSeparator1, Me.PlayListBtm, Me.FavoriteBtm, ToolStripSeparator4, Me.PlayBtm, Me.StopBtm, Me.PauseBtm, Me.BackBtm, Me.NextBtm, ToolStripSeparator2, Me.NormalPlayBtm, Me.RepeatPlayBtm, ToolStripSeparator5, Me.ShuffleBtm, ToolStripSeparator3, Me.ToolStripLabel1})
        Me.ToolBox.Location = New System.Drawing.Point(5, 5)
        Me.ToolBox.Name = "ToolBox"
        Me.ToolBox.Padding = New System.Windows.Forms.Padding(0)
        Me.ToolBox.Size = New System.Drawing.Size(680, 20)
        Me.ToolBox.TabIndex = 2
        '
        'OneAddBtm
        '
        Me.OneAddBtm.AutoSize = False
        Me.OneAddBtm.BackColor = System.Drawing.SystemColors.Control
        Me.OneAddBtm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.OneAddBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OneAddBtm.Image = CType(resources.GetObject("OneAddBtm.Image"), System.Drawing.Image)
        Me.OneAddBtm.ImageTransparentColor = System.Drawing.Color.White
        Me.OneAddBtm.Name = "OneAddBtm"
        Me.OneAddBtm.Size = New System.Drawing.Size(18, 19)
        Me.OneAddBtm.Text = "ToolStripButton1"
        Me.OneAddBtm.ToolTipText = "曲の追加"
        '
        'DirAddBtm
        '
        Me.DirAddBtm.AutoSize = False
        Me.DirAddBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DirAddBtm.Image = CType(resources.GetObject("DirAddBtm.Image"), System.Drawing.Image)
        Me.DirAddBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DirAddBtm.Name = "DirAddBtm"
        Me.DirAddBtm.Size = New System.Drawing.Size(18, 19)
        Me.DirAddBtm.Text = "ToolStripButton1"
        Me.DirAddBtm.ToolTipText = "フォルダから追加"
        '
        'OneDelBtm
        '
        Me.OneDelBtm.AutoSize = False
        Me.OneDelBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OneDelBtm.Image = CType(resources.GetObject("OneDelBtm.Image"), System.Drawing.Image)
        Me.OneDelBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OneDelBtm.Name = "OneDelBtm"
        Me.OneDelBtm.Size = New System.Drawing.Size(18, 19)
        Me.OneDelBtm.Text = "ToolStripButton1"
        Me.OneDelBtm.ToolTipText = "プレイリストから1曲を削除"
        '
        'AllDelBtm
        '
        Me.AllDelBtm.AutoSize = False
        Me.AllDelBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AllDelBtm.Image = CType(resources.GetObject("AllDelBtm.Image"), System.Drawing.Image)
        Me.AllDelBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AllDelBtm.Name = "AllDelBtm"
        Me.AllDelBtm.Size = New System.Drawing.Size(23, 17)
        Me.AllDelBtm.Text = "ToolStripButton1"
        Me.AllDelBtm.ToolTipText = "プレイリストから全曲削除"
        '
        'ListSaveBtm
        '
        Me.ListSaveBtm.AutoSize = False
        Me.ListSaveBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ListSaveBtm.Image = CType(resources.GetObject("ListSaveBtm.Image"), System.Drawing.Image)
        Me.ListSaveBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ListSaveBtm.Name = "ListSaveBtm"
        Me.ListSaveBtm.Size = New System.Drawing.Size(18, 19)
        Me.ListSaveBtm.Text = "ToolStripButton1"
        Me.ListSaveBtm.ToolTipText = "プレイリストの保存"
        '
        'PlayListBtm
        '
        Me.PlayListBtm.AutoSize = False
        Me.PlayListBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PlayListBtm.Image = CType(resources.GetObject("PlayListBtm.Image"), System.Drawing.Image)
        Me.PlayListBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PlayListBtm.Name = "PlayListBtm"
        Me.PlayListBtm.Size = New System.Drawing.Size(18, 19)
        Me.PlayListBtm.Text = "ToolStripButton1"
        Me.PlayListBtm.ToolTipText = "プレイリスト On/Off"
        '
        'FavoriteBtm
        '
        Me.FavoriteBtm.AutoSize = False
        Me.FavoriteBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FavoriteBtm.Image = CType(resources.GetObject("FavoriteBtm.Image"), System.Drawing.Image)
        Me.FavoriteBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FavoriteBtm.Name = "FavoriteBtm"
        Me.FavoriteBtm.Size = New System.Drawing.Size(18, 19)
        Me.FavoriteBtm.Text = "ToolStripButton1"
        Me.FavoriteBtm.ToolTipText = "お気に入り"
        '
        'PlayBtm
        '
        Me.PlayBtm.AutoSize = False
        Me.PlayBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PlayBtm.Image = CType(resources.GetObject("PlayBtm.Image"), System.Drawing.Image)
        Me.PlayBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PlayBtm.Name = "PlayBtm"
        Me.PlayBtm.Size = New System.Drawing.Size(18, 19)
        Me.PlayBtm.Text = "ToolStripButton1"
        Me.PlayBtm.ToolTipText = "再生"
        '
        'StopBtm
        '
        Me.StopBtm.AutoSize = False
        Me.StopBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StopBtm.Image = CType(resources.GetObject("StopBtm.Image"), System.Drawing.Image)
        Me.StopBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.StopBtm.Name = "StopBtm"
        Me.StopBtm.Size = New System.Drawing.Size(18, 19)
        Me.StopBtm.Text = "ToolStripButton1"
        Me.StopBtm.ToolTipText = "停止"
        '
        'PauseBtm
        '
        Me.PauseBtm.AutoSize = False
        Me.PauseBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PauseBtm.Image = CType(resources.GetObject("PauseBtm.Image"), System.Drawing.Image)
        Me.PauseBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PauseBtm.Name = "PauseBtm"
        Me.PauseBtm.Size = New System.Drawing.Size(18, 19)
        Me.PauseBtm.Text = "ToolStripButton1"
        Me.PauseBtm.ToolTipText = "一時停止"
        '
        'BackBtm
        '
        Me.BackBtm.AutoSize = False
        Me.BackBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BackBtm.Image = CType(resources.GetObject("BackBtm.Image"), System.Drawing.Image)
        Me.BackBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BackBtm.Name = "BackBtm"
        Me.BackBtm.Size = New System.Drawing.Size(18, 19)
        Me.BackBtm.Text = "ToolStripButton1"
        Me.BackBtm.ToolTipText = "前曲"
        '
        'NextBtm
        '
        Me.NextBtm.AutoSize = False
        Me.NextBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NextBtm.Image = CType(resources.GetObject("NextBtm.Image"), System.Drawing.Image)
        Me.NextBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NextBtm.Name = "NextBtm"
        Me.NextBtm.Size = New System.Drawing.Size(18, 19)
        Me.NextBtm.Text = "ToolStripButton1"
        Me.NextBtm.ToolTipText = "次曲"
        '
        'NormalPlayBtm
        '
        Me.NormalPlayBtm.AutoSize = False
        Me.NormalPlayBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NormalPlayBtm.Image = CType(resources.GetObject("NormalPlayBtm.Image"), System.Drawing.Image)
        Me.NormalPlayBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NormalPlayBtm.Name = "NormalPlayBtm"
        Me.NormalPlayBtm.Size = New System.Drawing.Size(18, 19)
        Me.NormalPlayBtm.Text = "ToolStripButton1"
        Me.NormalPlayBtm.ToolTipText = "通常再生（プレイリストの最後まで1回再生）"
        '
        'RepeatPlayBtm
        '
        Me.RepeatPlayBtm.AutoSize = False
        Me.RepeatPlayBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RepeatPlayBtm.Image = CType(resources.GetObject("RepeatPlayBtm.Image"), System.Drawing.Image)
        Me.RepeatPlayBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RepeatPlayBtm.Name = "RepeatPlayBtm"
        Me.RepeatPlayBtm.Size = New System.Drawing.Size(18, 19)
        Me.RepeatPlayBtm.Text = "ToolStripButton1"
        Me.RepeatPlayBtm.ToolTipText = "リピート再生（最後曲の再生が終了後、1曲目に戻って再生）"
        '
        'ShuffleBtm
        '
        Me.ShuffleBtm.AutoSize = False
        Me.ShuffleBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ShuffleBtm.Image = CType(resources.GetObject("ShuffleBtm.Image"), System.Drawing.Image)
        Me.ShuffleBtm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ShuffleBtm.Name = "ShuffleBtm"
        Me.ShuffleBtm.Size = New System.Drawing.Size(18, 19)
        Me.ShuffleBtm.Text = "ToolStripButton1"
        Me.ShuffleBtm.ToolTipText = "リスト シャッフル"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(25, 20)
        Me.ToolStripLabel1.Text = "♪>"
        Me.ToolStripLabel1.ToolTipText = "音量(0-1000)"
        '
        'StatusBar
        '
        Me.StatusBar.ImageScalingSize = New System.Drawing.Size(12, 12)
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.MusicNum, Me.ToolStripStatusLabel2, Me.SumTime, Me.SW_Info})
        Me.StatusBar.Location = New System.Drawing.Point(0, 292)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(690, 24)
        Me.StatusBar.TabIndex = 28
        Me.StatusBar.Text = "StatusBar"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(32, 19)
        Me.ToolStripStatusLabel1.Text = "曲 : "
        '
        'MusicNum
        '
        Me.MusicNum.AutoToolTip = True
        Me.MusicNum.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.MusicNum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.MusicNum.Name = "MusicNum"
        Me.MusicNum.Size = New System.Drawing.Size(64, 19)
        Me.MusicNum.Text = "1000/1000"
        Me.MusicNum.ToolTipText = "再生数 / 曲数"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(56, 19)
        Me.ToolStripStatusLabel2.Text = "総時間 : "
        Me.ToolStripStatusLabel2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SumTime
        '
        Me.SumTime.AutoToolTip = True
        Me.SumTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.SumTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SumTime.Name = "SumTime"
        Me.SumTime.Size = New System.Drawing.Size(59, 19)
        Me.SumTime.Text = "-- : -- : --"
        Me.SumTime.ToolTipText = "総時間"
        '
        'SW_Info
        '
        Me.SW_Info.Name = "SW_Info"
        Me.SW_Info.Size = New System.Drawing.Size(28, 19)
        Me.SW_Info.Text = "info"
        '
        'DB
        '
        Me.DB.CaseSensitive = True
        Me.DB.DataSetName = "DB"
        Me.DB.Locale = New System.Globalization.CultureInfo("")
        Me.DB.Namespace = "http://tempuri.org/DataSet1.xsd"
        Me.DB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TrayIcon
        '
        Me.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TrayIcon.Text = "おんぷっぷ"
        Me.TrayIcon.Visible = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(690, 316)
        Me.ContextMenuStrip = Me.MainMenu
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.MainPanel)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.ShowInTaskbar = False
        Me.Text = "おんぷっぷ"
        Me.MainMenu.ResumeLayout(False)
        Me.MainPanel.ResumeLayout(False)
        Me.InfoPanel.ResumeLayout(False)
        Me.InfoPanel.PerformLayout()
        CType(Me.Slider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VolumeVal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolBox.ResumeLayout(False)
        Me.ToolBox.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        CType(Me.DB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents MainMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PlayList_SwBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlayList_DockBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FavoriteBoxBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlayList_WindowBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents InfoPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Slider As System.Windows.Forms.TrackBar
    Friend WithEvents TimeBox As System.Windows.Forms.Label
    Friend WithEvents VolumeVal As System.Windows.Forms.NumericUpDown
    Private WithEvents ToolBox As System.Windows.Forms.ToolStrip
    Public WithEvents OneAddBtm As System.Windows.Forms.ToolStripButton
    Friend WithEvents DirAddBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents OneDelBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents AllDelBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents PlayBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents StopBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents PauseBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents BackBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents NextBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents NormalPlayBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents RepeatPlayBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents ShuffleBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents ListSaveBtm As System.Windows.Forms.ToolStripButton
    Public WithEvents PlayListBtm As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MusicNum As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SumTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Public WithEvents FavoriteBtm As ToolStripButton
    Friend WithEvents DB As OnppDB
    Friend WithEvents SW_Info As ToolStripStatusLabel
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
End Class
