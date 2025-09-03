<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfoDialog
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
        Me.InfoPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.PlayTime = New System.Windows.Forms.Label()
        Me.Artist = New System.Windows.Forms.Label()
        Me.Title = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Status = New System.Windows.Forms.Label()
        Me.CloseTimer = New System.Windows.Forms.Timer(Me.components)
        Me.InfoPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'InfoPanel
        '
        Me.InfoPanel.BackColor = System.Drawing.Color.Silver
        Me.InfoPanel.ColumnCount = 2
        Me.InfoPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.96011!))
        Me.InfoPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.03989!))
        Me.InfoPanel.Controls.Add(Me.PlayTime, 1, 3)
        Me.InfoPanel.Controls.Add(Me.Artist, 1, 2)
        Me.InfoPanel.Controls.Add(Me.Title, 1, 1)
        Me.InfoPanel.Controls.Add(Me.Label4, 0, 3)
        Me.InfoPanel.Controls.Add(Me.Label3, 0, 2)
        Me.InfoPanel.Controls.Add(Me.Label2, 0, 1)
        Me.InfoPanel.Controls.Add(Me.Label1, 0, 0)
        Me.InfoPanel.Controls.Add(Me.Status, 1, 0)
        Me.InfoPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InfoPanel.Location = New System.Drawing.Point(0, 0)
        Me.InfoPanel.Name = "InfoPanel"
        Me.InfoPanel.RowCount = 3
        Me.InfoPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.InfoPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.InfoPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.InfoPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.InfoPanel.Size = New System.Drawing.Size(351, 100)
        Me.InfoPanel.TabIndex = 0
        '
        'PlayTime
        '
        Me.PlayTime.AutoSize = True
        Me.PlayTime.BackColor = System.Drawing.Color.Transparent
        Me.PlayTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlayTime.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.PlayTime.Location = New System.Drawing.Point(53, 78)
        Me.PlayTime.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.PlayTime.Name = "PlayTime"
        Me.PlayTime.Size = New System.Drawing.Size(293, 19)
        Me.PlayTime.TabIndex = 8
        Me.PlayTime.Text = "PlayTime"
        Me.PlayTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Artist
        '
        Me.Artist.AutoSize = True
        Me.Artist.BackColor = System.Drawing.Color.Transparent
        Me.Artist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Artist.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Artist.Location = New System.Drawing.Point(53, 53)
        Me.Artist.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Artist.Name = "Artist"
        Me.Artist.Size = New System.Drawing.Size(293, 19)
        Me.Artist.TabIndex = 7
        Me.Artist.Text = "Artist"
        Me.Artist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.BackColor = System.Drawing.Color.Transparent
        Me.Title.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Title.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Title.Location = New System.Drawing.Point(53, 28)
        Me.Title.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(293, 19)
        Me.Title.TabIndex = 6
        Me.Title.Text = "Title"
        Me.Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 25)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "時 間:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "歌 手:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "曲 名:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "状 態:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Status
        '
        Me.Status.AutoSize = True
        Me.Status.BackColor = System.Drawing.Color.Transparent
        Me.Status.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Status.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Status.Location = New System.Drawing.Point(53, 3)
        Me.Status.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(293, 19)
        Me.Status.TabIndex = 5
        Me.Status.Text = "Status"
        Me.Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InfoDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(351, 100)
        Me.Controls.Add(Me.InfoPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "InfoDialog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "InfoDialog"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.InfoPanel.ResumeLayout(False)
        Me.InfoPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InfoPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PlayTime As System.Windows.Forms.Label
    Friend WithEvents Artist As System.Windows.Forms.Label
    Friend WithEvents Title As System.Windows.Forms.Label
    Friend WithEvents Status As System.Windows.Forms.Label
    Public WithEvents CloseTimer As System.Windows.Forms.Timer
End Class
