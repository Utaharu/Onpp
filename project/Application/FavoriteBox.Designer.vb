<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FavoriteBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FavoriteBox))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LeftTable = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RootTree = New System.Windows.Forms.TreeView()
        Me.RootTreeMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NodeAdd_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NodeDeleteMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectNodeDel_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllNodeDel_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NodeAdd_Btm = New System.Windows.Forms.ToolStripButton()
        Me.SeletNodeDel_Btm = New System.Windows.Forms.ToolStripButton()
        Me.AllNodeDel_Btm = New System.Windows.Forms.ToolStripButton()
        Me.FileListMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelectItemMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectItemAddBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectItemNewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllItemMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllItemAddBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllItemNewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.RootSelectItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RootSelectItemAddBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.RootSelectItemNewBtm = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.RightTable = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RootPath = New System.Windows.Forms.RichTextBox()
        Me.FileList = New System.Windows.Forms.DataGridView()
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Place = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.MeInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LeftTable.SuspendLayout()
        Me.RootTreeMenu.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.FileListMenu.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.RightTable.SuspendLayout()
        CType(Me.FileList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LeftTable
        '
        Me.LeftTable.ColumnCount = 1
        Me.LeftTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LeftTable.Controls.Add(Me.Label4, 0, 1)
        Me.LeftTable.Controls.Add(Me.RootTree, 0, 2)
        Me.LeftTable.Controls.Add(Me.ToolStrip1, 0, 0)
        Me.LeftTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeftTable.Location = New System.Drawing.Point(0, 0)
        Me.LeftTable.Name = "LeftTable"
        Me.LeftTable.RowCount = 4
        Me.LeftTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.LeftTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.LeftTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LeftTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.LeftTable.Size = New System.Drawing.Size(232, 448)
        Me.LeftTable.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 27)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(226, 12)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "- お気に入り フォルダ リスト-"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RootTree
        '
        Me.RootTree.AllowDrop = True
        Me.RootTree.ContextMenuStrip = Me.RootTreeMenu
        Me.RootTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RootTree.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.RootTree.FullRowSelect = True
        Me.RootTree.HideSelection = False
        Me.RootTree.HotTracking = True
        Me.RootTree.Indent = 15
        Me.RootTree.ItemHeight = 15
        Me.RootTree.LabelEdit = True
        Me.RootTree.Location = New System.Drawing.Point(8, 42)
        Me.RootTree.Margin = New System.Windows.Forms.Padding(8, 3, 3, 3)
        Me.RootTree.Name = "RootTree"
        Me.RootTree.ShowNodeToolTips = True
        Me.RootTree.Size = New System.Drawing.Size(221, 378)
        Me.RootTree.TabIndex = 0
        '
        'RootTreeMenu
        '
        Me.RootTreeMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NodeAdd_Menu, Me.NodeDeleteMenu})
        Me.RootTreeMenu.Name = "ContextMenuStrip1"
        Me.RootTreeMenu.ShowImageMargin = False
        Me.RootTreeMenu.Size = New System.Drawing.Size(109, 48)
        '
        'NodeAdd_Menu
        '
        Me.NodeAdd_Menu.AutoToolTip = True
        Me.NodeAdd_Menu.Name = "NodeAdd_Menu"
        Me.NodeAdd_Menu.Size = New System.Drawing.Size(108, 22)
        Me.NodeAdd_Menu.Text = "フォルダ追加"
        Me.NodeAdd_Menu.ToolTipText = "お気に入りリストに追加"
        '
        'NodeDeleteMenu
        '
        Me.NodeDeleteMenu.AutoToolTip = True
        Me.NodeDeleteMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectNodeDel_Menu, Me.AllNodeDel_Menu})
        Me.NodeDeleteMenu.Name = "NodeDeleteMenu"
        Me.NodeDeleteMenu.Size = New System.Drawing.Size(108, 22)
        Me.NodeDeleteMenu.Text = "削除"
        Me.NodeDeleteMenu.ToolTipText = "お気に入りリストの削除操作"
        '
        'SelectNodeDel_Menu
        '
        Me.SelectNodeDel_Menu.AutoToolTip = True
        Me.SelectNodeDel_Menu.Name = "SelectNodeDel_Menu"
        Me.SelectNodeDel_Menu.Size = New System.Drawing.Size(122, 22)
        Me.SelectNodeDel_Menu.Text = "選択項目"
        Me.SelectNodeDel_Menu.ToolTipText = "お気に入りリストの選択項目を削除"
        '
        'AllNodeDel_Menu
        '
        Me.AllNodeDel_Menu.AutoToolTip = True
        Me.AllNodeDel_Menu.Name = "AllNodeDel_Menu"
        Me.AllNodeDel_Menu.Size = New System.Drawing.Size(122, 22)
        Me.AllNodeDel_Menu.Text = "全項目"
        Me.AllNodeDel_Menu.ToolTipText = "お気に入りリストの全項目を削除"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(12, 12)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NodeAdd_Btm, Me.SeletNodeDel_Btm, Me.AllNodeDel_Btm})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(232, 24)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NodeAdd_Btm
        '
        Me.NodeAdd_Btm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NodeAdd_Btm.Image = CType(resources.GetObject("NodeAdd_Btm.Image"), System.Drawing.Image)
        Me.NodeAdd_Btm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NodeAdd_Btm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NodeAdd_Btm.Name = "NodeAdd_Btm"
        Me.NodeAdd_Btm.Size = New System.Drawing.Size(23, 21)
        Me.NodeAdd_Btm.Text = "ToolStripButton1"
        Me.NodeAdd_Btm.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.NodeAdd_Btm.ToolTipText = "お気に入り追加"
        '
        'SeletNodeDel_Btm
        '
        Me.SeletNodeDel_Btm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SeletNodeDel_Btm.Image = CType(resources.GetObject("SeletNodeDel_Btm.Image"), System.Drawing.Image)
        Me.SeletNodeDel_Btm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SeletNodeDel_Btm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SeletNodeDel_Btm.Name = "SeletNodeDel_Btm"
        Me.SeletNodeDel_Btm.Size = New System.Drawing.Size(23, 21)
        Me.SeletNodeDel_Btm.Text = "ToolStripButton1"
        Me.SeletNodeDel_Btm.ToolTipText = "選択削除"
        '
        'AllNodeDel_Btm
        '
        Me.AllNodeDel_Btm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AllNodeDel_Btm.Image = CType(resources.GetObject("AllNodeDel_Btm.Image"), System.Drawing.Image)
        Me.AllNodeDel_Btm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.AllNodeDel_Btm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AllNodeDel_Btm.Name = "AllNodeDel_Btm"
        Me.AllNodeDel_Btm.Size = New System.Drawing.Size(23, 21)
        Me.AllNodeDel_Btm.Text = "ToolStripButton1"
        '
        'FileListMenu
        '
        Me.FileListMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectItemMenu, Me.AllItemMenu, Me.RootSelectItem})
        Me.FileListMenu.Name = "RootTreeFileControl"
        Me.FileListMenu.ShowImageMargin = False
        Me.FileListMenu.Size = New System.Drawing.Size(153, 70)
        '
        'SelectItemMenu
        '
        Me.SelectItemMenu.AutoToolTip = True
        Me.SelectItemMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectItemAddBtm, Me.SelectItemNewBtm})
        Me.SelectItemMenu.Name = "SelectItemMenu"
        Me.SelectItemMenu.Size = New System.Drawing.Size(152, 22)
        Me.SelectItemMenu.Text = "選択ファイル"
        Me.SelectItemMenu.ToolTipText = "ファイルリストの選択項目を操作"
        '
        'SelectItemAddBtm
        '
        Me.SelectItemAddBtm.AutoToolTip = True
        Me.SelectItemAddBtm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SelectItemAddBtm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.SelectItemAddBtm.Name = "SelectItemAddBtm"
        Me.SelectItemAddBtm.Size = New System.Drawing.Size(150, 22)
        Me.SelectItemAddBtm.Text = "プレイリスト追加"
        Me.SelectItemAddBtm.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.SelectItemAddBtm.ToolTipText = "ファイルリストの選択項目を追加"
        '
        'SelectItemNewBtm
        '
        Me.SelectItemNewBtm.AutoToolTip = True
        Me.SelectItemNewBtm.Name = "SelectItemNewBtm"
        Me.SelectItemNewBtm.Size = New System.Drawing.Size(150, 22)
        Me.SelectItemNewBtm.Text = "プレイリスト作成"
        Me.SelectItemNewBtm.ToolTipText = "ファイルリストの選択項目から作成"
        '
        'AllItemMenu
        '
        Me.AllItemMenu.AutoToolTip = True
        Me.AllItemMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllItemAddBtm, Me.AllItemNewBtm})
        Me.AllItemMenu.Name = "AllItemMenu"
        Me.AllItemMenu.Size = New System.Drawing.Size(152, 22)
        Me.AllItemMenu.Text = "全てのファイル"
        Me.AllItemMenu.ToolTipText = "ファイルリストの全項目を操作"
        '
        'AllItemAddBtm
        '
        Me.AllItemAddBtm.AutoToolTip = True
        Me.AllItemAddBtm.Name = "AllItemAddBtm"
        Me.AllItemAddBtm.Size = New System.Drawing.Size(150, 22)
        Me.AllItemAddBtm.Text = "プレイリスト追加"
        Me.AllItemAddBtm.ToolTipText = "ファイルリストの全項目を追加"
        '
        'AllItemNewBtm
        '
        Me.AllItemNewBtm.Name = "AllItemNewBtm"
        Me.AllItemNewBtm.Size = New System.Drawing.Size(150, 22)
        Me.AllItemNewBtm.Text = "プレイリスト作成"
        Me.AllItemNewBtm.ToolTipText = "ファイルリストの全項目から作成"
        '
        'RootSelectItem
        '
        Me.RootSelectItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RootSelectItemAddBtm, Me.RootSelectItemNewBtm})
        Me.RootSelectItem.Name = "RootSelectItem"
        Me.RootSelectItem.Size = New System.Drawing.Size(152, 22)
        Me.RootSelectItem.Text = "同ルートのみのファイル"
        Me.RootSelectItem.ToolTipText = "下位のルートを含まないファイルの操作"
        '
        'RootSelectItemAddBtm
        '
        Me.RootSelectItemAddBtm.Name = "RootSelectItemAddBtm"
        Me.RootSelectItemAddBtm.Size = New System.Drawing.Size(150, 22)
        Me.RootSelectItemAddBtm.Text = "プレイリスト追加"
        Me.RootSelectItemAddBtm.ToolTipText = "同ルートのみのファイルの項目を追加"
        '
        'RootSelectItemNewBtm
        '
        Me.RootSelectItemNewBtm.Name = "RootSelectItemNewBtm"
        Me.RootSelectItemNewBtm.Size = New System.Drawing.Size(150, 22)
        Me.RootSelectItemNewBtm.Text = "プレイリスト作成"
        Me.RootSelectItemNewBtm.ToolTipText = "同ルートのみのファイル項目から作成"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.LeftTable)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.RightTable)
        Me.SplitContainer1.Size = New System.Drawing.Size(704, 448)
        Me.SplitContainer1.SplitterDistance = 232
        Me.SplitContainer1.SplitterWidth = 1
        Me.SplitContainer1.TabIndex = 2
        '
        'RightTable
        '
        Me.RightTable.ColumnCount = 1
        Me.RightTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 471.0!))
        Me.RightTable.Controls.Add(Me.Label3, 0, 3)
        Me.RightTable.Controls.Add(Me.Label1, 0, 1)
        Me.RightTable.Controls.Add(Me.RootPath, 0, 2)
        Me.RightTable.Controls.Add(Me.FileList, 0, 4)
        Me.RightTable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RightTable.Location = New System.Drawing.Point(0, 0)
        Me.RightTable.Name = "RightTable"
        Me.RightTable.RowCount = 6
        Me.RightTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.RightTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.RightTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.RightTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.RightTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RightTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.RightTable.Size = New System.Drawing.Size(471, 448)
        Me.RightTable.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 58)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(465, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "- ファイル リスト -"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(465, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "- 場所 -"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'RootPath
        '
        Me.RootPath.BackColor = System.Drawing.Color.White
        Me.RootPath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RootPath.DetectUrls = False
        Me.RootPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RootPath.Location = New System.Drawing.Point(8, 38)
        Me.RootPath.Margin = New System.Windows.Forms.Padding(8, 3, 3, 3)
        Me.RootPath.Multiline = False
        Me.RootPath.Name = "RootPath"
        Me.RootPath.ReadOnly = True
        Me.RootPath.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.RootPath.Size = New System.Drawing.Size(460, 14)
        Me.RootPath.TabIndex = 17
        Me.RootPath.Text = "RootPath"
        Me.RootPath.WordWrap = False
        '
        'FileList
        '
        Me.FileList.AllowUserToAddRows = False
        Me.FileList.AllowUserToDeleteRows = False
        Me.FileList.AllowUserToOrderColumns = True
        Me.FileList.AllowUserToResizeRows = False
        Me.FileList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.FileList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FileList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.FileList.ColumnHeadersHeight = 20
        Me.FileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.FileList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FileName, Me.Place})
        Me.FileList.ContextMenuStrip = Me.FileListMenu
        Me.FileList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FileList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.FileList.Location = New System.Drawing.Point(8, 73)
        Me.FileList.Margin = New System.Windows.Forms.Padding(8, 3, 3, 3)
        Me.FileList.Name = "FileList"
        Me.FileList.ReadOnly = True
        Me.FileList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FileList.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.FileList.RowHeadersVisible = False
        Me.FileList.RowHeadersWidth = 23
        Me.FileList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.FileList.RowTemplate.Height = 17
        Me.FileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.FileList.ShowCellErrors = False
        Me.FileList.ShowEditingIcon = False
        Me.FileList.ShowRowErrors = False
        Me.FileList.Size = New System.Drawing.Size(460, 347)
        Me.FileList.StandardTab = True
        Me.FileList.TabIndex = 12
        '
        'FileName
        '
        Me.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Padding = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.FileName.DefaultCellStyle = DataGridViewCellStyle5
        Me.FileName.FillWeight = 150.0!
        Me.FileName.HeaderText = "ファイル名"
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        Me.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FileName.ToolTipText = "ファイル名"
        '
        'Place
        '
        Me.Place.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Place.HeaderText = "場所"
        Me.Place.Name = "Place"
        Me.Place.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MeInfo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 425)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(704, 23)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MeInfo
        '
        Me.MeInfo.AutoSize = False
        Me.MeInfo.AutoToolTip = True
        Me.MeInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.MeInfo.Name = "MeInfo"
        Me.MeInfo.Size = New System.Drawing.Size(689, 18)
        Me.MeInfo.Spring = True
        Me.MeInfo.Text = "MeInfo"
        Me.MeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.MeInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'FavoriteBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(704, 448)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FavoriteBox"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "お気に入り"
        Me.LeftTable.ResumeLayout(False)
        Me.LeftTable.PerformLayout()
        Me.RootTreeMenu.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.FileListMenu.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.RightTable.ResumeLayout(False)
        Me.RightTable.PerformLayout()
        CType(Me.FileList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LeftTable As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RootTree As System.Windows.Forms.TreeView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RightTable As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents FileListMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SelectItemMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectItemAddBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectItemNewBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllItemMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllItemAddBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllItemNewBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RootPath As System.Windows.Forms.RichTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FileList As System.Windows.Forms.DataGridView
    Friend WithEvents RootTreeMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NodeAdd_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NodeDeleteMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectNodeDel_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllNodeDel_Menu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NodeAdd_Btm As System.Windows.Forms.ToolStripButton
    Friend WithEvents SeletNodeDel_Btm As System.Windows.Forms.ToolStripButton
    Friend WithEvents AllNodeDel_Btm As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MeInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Place As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RootSelectItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RootSelectItemAddBtm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RootSelectItemNewBtm As System.Windows.Forms.ToolStripMenuItem
End Class
